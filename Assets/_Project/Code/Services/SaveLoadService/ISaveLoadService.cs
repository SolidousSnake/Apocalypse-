using _Project.Code.Data;

namespace _Project.Code.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        public void Save(PlayerProgress playerProgress);
        public PlayerProgress Load();
        public void Reset();
    }
}