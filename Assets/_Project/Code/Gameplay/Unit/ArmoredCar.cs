using _Project.Code.Services.MiniGameService;
using VContainer;

namespace _Project.Code.Gameplay.Unit
{
    public sealed class ArmoredCar : Car
    {
        [Inject] private MiniGameService _miniGameService;
        
        protected override void InitializeBehaviour()
        {
            _beingAttackedBehaviour.BeingAttacked += _miniGameService.StartGame;
        }
    }
}