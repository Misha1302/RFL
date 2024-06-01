namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Player.Movement;
    using RFL.Scripts.GameLogic.Player.Movement.Stepper;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(PlayerTransform))]
    [RequireComponent(typeof(PlayerStepper))]
    [RequireComponent(typeof(PlayerHorizontalMovement))]
    [RequireComponent(typeof(PlayerJumper))]
    [RequireComponent(typeof(PlayerImageFlipper))]
    [RequireComponent(typeof(PlayerPhysicMaterial))]
    [RequireComponent(typeof(PlayerPauseHandler))]
    [RequireComponent(typeof(PlayerDataSaver))]
    public class Player : MonoBeh
    {
        private readonly Di _di = new();

        public Player()
        {
            Di.Instance.AddSingle(this);

            _di.AddLazySingle(GetComponent<PlayerImageFlipper>);
            _di.AddLazySingle(GetComponent<PlayerJumper>);
            _di.AddLazySingle(GetComponent<PlayerPauseHandler>);
            _di.AddLazySingle(GetComponent<PlayerPhysicMaterial>);
            _di.AddLazySingle(GetComponent<PlayerStepper>);
            _di.AddLazySingle(GetComponent<PlayerHorizontalMovement>);
            _di.AddLazySingle(GetComponent<PlayerTransform>);
            _di.AddLazySingle(GetComponent<PlayerDataSaver>);
        }

        public T Get<T>() => _di.GetSingle<T>();
    }
}