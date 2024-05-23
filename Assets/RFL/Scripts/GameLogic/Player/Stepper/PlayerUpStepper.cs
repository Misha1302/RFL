namespace RFL.Scripts.GameLogic.Player.Stepper
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class PlayerUpStepper : MonoBeh
    {
        private PlayerStepper _playerStepper;

        public void Init(PlayerStepper playerStepper)
        {
            _playerStepper = playerStepper;
        }
    }
}