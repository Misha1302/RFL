namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GameLogic.Player.Components;
    using RFL.Scripts.GameLogic.Player.Components.Movement;
    using RFL.Scripts.GameLogic.Player.Components.Movement.Stepper;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Singletons;
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
        public Player()
        {
            var container = GameSingletons.DependencyInjector.DependencyContainer;
            container.AddLazySingle(GetComponent<Player>);
            container.AddLazySingle(GetComponent<PlayerImageFlipper>);
            container.AddLazySingle(GetComponent<PlayerJumper>);
            container.AddLazySingle(GetComponent<PlayerPauseHandler>);
            container.AddLazySingle(GetComponent<PlayerPhysicMaterial>);
            container.AddLazySingle(GetComponent<PlayerStepper>);
            container.AddLazySingle(GetComponent<PlayerHorizontalMovement>);
            container.AddLazySingle(GetComponent<PlayerTransform>);
            container.AddLazySingle(GetComponent<PlayerDataSaver>);
        }
    }
}