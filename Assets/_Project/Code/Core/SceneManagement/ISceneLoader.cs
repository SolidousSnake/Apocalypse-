using System;

namespace _Project.Code.Core.SceneManagement
{
    public interface ISceneLoader
    {
        public event Action Started;
        public event Action Finished;
        public event Action<float> Progressed;
        public void Load(string name);
    }
}