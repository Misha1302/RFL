namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Player.Components;
    using RFL.Scripts.GameLogic.Player.Components.Movement;
    using RFL.Scripts.GameLogic.Player.Components.Movement.Stepper;
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
        private readonly Dc _dc = new();

        public Player()
        {
            Dc.Instance.AddSingle(this);

            _dc.AddLazySingle(GetComponent<PlayerImageFlipper>);
            _dc.AddLazySingle(GetComponent<PlayerJumper>);
            _dc.AddLazySingle(GetComponent<PlayerPauseHandler>);
            _dc.AddLazySingle(GetComponent<PlayerPhysicMaterial>);
            _dc.AddLazySingle(GetComponent<PlayerStepper>);
            _dc.AddLazySingle(GetComponent<PlayerHorizontalMovement>);
            _dc.AddLazySingle(GetComponent<PlayerTransform>);
            _dc.AddLazySingle(GetComponent<PlayerDataSaver>);
        }

        public T Get<T>() => _dc.GetSingle<T>();
    }
}