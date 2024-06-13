using _Project.Code.Config;
using _Project.Code.Gameplay.Spawner;
using _Project.Code.Gameplay.Unit;
using _Project.Code.UI.Button;
using _Project.Code.UI.Label;
using VContainer;

namespace _Project.Code.Services.MiniGameService
{
    public sealed class MiniGameService
    {
        [Inject] private readonly Player _player;
        [Inject] private readonly LootLabel _lootLabel;
        [Inject] private readonly ButtonsParent _buttonsParent;
        [Inject] private readonly CircleSpawner _circleSpawner;
        [Inject] private readonly CircleSpawnerLabel _circleSpawnerLabel;
        [Inject] private readonly CircleMiniGameConfig _config;
        [Inject] private readonly YouWasRobbedLabel _youWasRobbedLabel;
        
        public void StartGame()
        {
            ChangeUI();
            _circleSpawner.Reset();
            _circleSpawner.Finished += FinishGame;

            _circleSpawner.SpawnCircle().Forget();
        }

        private void FinishGame()
        {
            ChangeUI();
            int missedCircles = _circleSpawner.MissedCircles;

            if (missedCircles > _config.CountToWin)
            {
                _youWasRobbedLabel.Show();
                _player.Health.ApplyDamage(missedCircles * _config.DamagePercent);
            }

            else
            {
                _circleSpawner.ReduceTime();
            }
        }

        private void ChangeUI()
        {
            _lootLabel.gameObject.SetActive(!_lootLabel.isActiveAndEnabled);
            _buttonsParent.gameObject.SetActive(!_buttonsParent.isActiveAndEnabled);
            _circleSpawnerLabel.gameObject.SetActive(!_circleSpawnerLabel.isActiveAndEnabled);
        }
    }
}