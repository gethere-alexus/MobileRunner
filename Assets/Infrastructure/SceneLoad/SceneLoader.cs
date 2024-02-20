using System;
using System.Collections;
using Infrastructure.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneLoad
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action sceneLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, sceneLoaded));

        private IEnumerator LoadScene(string sceneName, Action sceneLoaded = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                sceneLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!sceneAsync.isDone)
                yield return null;

            sceneLoaded?.Invoke();
        }
    }
}