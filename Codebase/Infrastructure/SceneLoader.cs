using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private Coroutine _loadSceneRoutine;
        private AsyncOperation _loadingOperation;

        public event Action<string> OnLoaded;
        
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null)
        {
            if (_loadSceneRoutine != null)
            {
                _coroutineRunner.StopCoroutine(_loadSceneRoutine);
            }

            _loadSceneRoutine = _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            yield return _coroutineRunner.StartCoroutine(TryCancelLoadingOperation());
            
            _loadingOperation = SceneManager.LoadSceneAsync(sceneName);
            
            while (!_loadingOperation.isDone)
            {
                yield return null;
            }

            _loadingOperation = null;
            onLoaded?.Invoke();
            OnLoaded?.Invoke(CurrentScene);
        }
        
        private IEnumerator TryCancelLoadingOperation()
        {
            if (_loadingOperation != null)
            {
                _loadingOperation.allowSceneActivation = false;
                yield return _loadingOperation;
                _loadingOperation = null;
            }
        }

        public string CurrentScene => SceneManager.GetActiveScene().name;
    }
}