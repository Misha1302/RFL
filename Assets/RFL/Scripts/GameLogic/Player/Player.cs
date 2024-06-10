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
            container.AddSingle(this);
            container.AddSingleScoped<IPlayerScope, PlayerTransform>(GetComponent<PlayerTransform>);
            container.AddSingleScoped<IPlayerScope, PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            container.AddSingleScoped<IPlayerScope, PlayerJumper>(GetComponent<PlayerJumper>);
            container.AddSingleScoped<IPlayerScope, PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            container.AddSingleScoped<IPlayerScope, PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            container.AddSingleScoped<IPlayerScope, PlayerStepper>(GetComponent<PlayerStepper>);
            container.AddSingleScoped<IPlayerScope, PlayerHorizontalMovement>(GetComponent<PlayerHorizontalMovement>);
            container.AddSingleScoped<IPlayerScope, PlayerDataSaver>(GetComponent<PlayerDataSaver>);
        }

        public interface IPlayerScope { }
    }
}