using _Project.Code.Data;
using _Project.Code.Services.SaveLoadService;
using _Project.Code.UI.Screen;
using VContainer;

namespace _Project.Code.Gameplay.GameResult
{
    public sealed class FailureResult
    {
        [Inject] private readonly ISaveLoadService _saveLoadService;
        [Inject] private readonly FailureResultView _failureResultView;
        [Inject] private readonly Stopwatch.Stopwatch _stopwatch;
        
        public void SetResult()
        {
            _stopwatch.Stop();

            var progress = _saveLoadService.Load();
            
            _failureResultView.SetAmount(_stopwatch.ElapsedTime, progress.BestTime);
            _failureResultView.Show();
            SaveData();
        }
        
        private void SaveData()
        {
            var savedProgress = _saveLoadService.Load();
            
            var playerProgress = new PlayerProgress
            {
                BestTime = savedProgress.BestTime < _stopwatch.ElapsedTime ? _stopwatch.ElapsedTime : savedProgress.BestTime
            };
            
            _saveLoadService.Save(playerProgress);
        }
    }
}