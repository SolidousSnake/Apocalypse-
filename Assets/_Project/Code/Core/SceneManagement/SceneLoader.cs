using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Code.Core.SceneManagement
{
    public sealed class SceneLoader : ISceneLoader
    {
        public event Action Started;
        public event Action Finished;
        public event Action<float> Progressed;
        
        public void Load(string name)
        {
            LoadSceneAsync(name).Forget();
        }

        private async UniTask LoadSceneAsync(string name)
        {
            Started?.Invoke();
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                Progressed?.Invoke(progress);
                await UniTask.Yield();
            }

            Finished?.Invoke();
        }
    }
}
