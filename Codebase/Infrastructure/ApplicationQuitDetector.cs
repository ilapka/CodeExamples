using System;
using UnityEngine;

namespace Codebase.Infrastructure
{
    public class ApplicationQuitDetector : MonoBehaviour
    {
        public event Action OnApplicationQuited;
        public event Action OnApplicationPaused;

        private void OnApplicationQuit()
        {
            OnApplicationQuited?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OnApplicationPaused?.Invoke();
        }
    }
}