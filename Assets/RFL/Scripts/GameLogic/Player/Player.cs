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
            container.AddLazySingle(() => this);
            container.AddLazySingleScoped<IPlayerScope, PlayerTransform>(GetComponent<PlayerTransform>);
            container.AddLazySingleScoped<IPlayerScope, PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            container.AddLazySingleScoped<IPlayerScope, PlayerJumper>(GetComponent<PlayerJumper>);
            container.AddLazySingleScoped<IPlayerScope, PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            container.AddLazySingleScoped<IPlayerScope, PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            container.AddLazySingleScoped<IPlayerScope, PlayerStepper>(GetComponent<PlayerStepper>);
            container.AddLazySingleScoped<IPlayerScope, PlayerHorizontalMovement>(
                GetComponent<PlayerHorizontalMovement>);
            container.AddLazySingleScoped<IPlayerScope, PlayerDataSaver>(GetComponent<PlayerDataSaver>);
        }

        public interface IPlayerScope { }
    }
}