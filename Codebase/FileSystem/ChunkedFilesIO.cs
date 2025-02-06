using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Codebase.FileSystem
{
    /// <summary>
    /// Allows to write/read files by chunks within directory
    /// </summary>
    public class ChunkedFilesIO
    {
        public byte[] ReadChunk(string path, int chunkIndex)
        {
            try
            {
                CheckFileExists(path);

                byte[] chunkBytes;
                
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    int chunkSize = ReadSizeOfTargetChunk(stream, chunkIndex);
                    
                    chunkBytes = new byte[chunkSize];
                    int bytesRead = stream.Read(chunkBytes, 0, chunkBytes.Length);
                    
                    if(bytesRead < chunkSize)
                        throw new EndOfStreamException($"Failed to read chunk with index {chunkIndex} from {path}. File is corrupted or incomplete.");
                }
                
#if UNITY_EDITOR
                StreamUtility.LogSuccessfulReading(path, chunkIndex, chunkBytes);
#endif
                
                return chunkBytes;
            }
            catch (Exception e)
            {
                Debug.LogError($"Can't read chunk of file with index {chunkIndex}, path {path}. Check log exception below.");
                Debug.LogException(e);
                return null;
            }
        }
        
        private int ReadSizeOfTargetChunk(FileStream stream, int chunkIndex)
        {
            for (int index = 0; index < chunkIndex; index++)
                stream.Position += ReadSizeOfChunk(stream, index);

            return ReadSizeOfChunk(stream, chunkIndex);
        }

        private int ReadSizeOfChunk(FileStream stream, int currentChunkIndex)
        {
            byte[] chunkSizeBytes = new byte[sizeof(int)];
            int bytesRead = stream.Read(chunkSizeBytes, 0, chunkSizeBytes.Length);
            if (bytesRead < 4) throw new EndOfStreamException($"Can't read size of chunk with index {currentChunkIndex}.");
            return BitConverter.ToInt32(chunkSizeBytes, 0);
        }

        public void WriteFile(string path, string directoryPath, List<byte[]> fileChunks)
        {
            DirectoryUtils.CheckOrCreateDirectory(directoryPath);

            long totalLength;
            
            using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                foreach (byte[] chunkBytes in fileChunks)
                {
                    //Write file chunk size
                    stream.Write(BitConverter.GetBytes(chunkBytes.Length), 0, sizeof(int));
                    //Write file chunk data
                    stream.Write(chunkBytes, 0, chunkBytes.Length);
                }

                totalLength = stream.Length;
            }
            
#if UNITY_EDITOR
            StreamUtility.LogSuccessfulWriting(path, fileChunks, totalLength);
#endif
        }

        public void DeleteFile(string path)
        {
            try
            {
                CheckFileExists(path);
                File.Delete(path);
            }
            catch (Exception e)
            {
                Debug.LogError($"Can't delete file, path {path}. Check log exception below.");
                Debug.LogException(e);
            }
        }
        
        private static void CheckFileExists(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Can't find file {path}.");
        }
    }
}