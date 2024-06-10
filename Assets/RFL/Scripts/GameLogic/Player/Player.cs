namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DependenciesManagement.Container;
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
            Container.AddSingle(this);
            Container.AddSingleScoped<IPlayerScope, PlayerTransform>(GetComponent<PlayerTransform>);
            Container.AddSingleScoped<IPlayerScope, PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            Container.AddSingleScoped<IPlayerScope, PlayerJumper>(GetComponent<PlayerJumper>);
            Container.AddSingleScoped<IPlayerScope, PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            Container.AddSingleScoped<IPlayerScope, PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            Container.AddSingleScoped<IPlayerScope, PlayerStepper>(GetComponent<PlayerStepper>);
            Container.AddSingleScoped<IPlayerScope, PlayerHorizontalMovement>(GetComponent<PlayerHorizontalMovement>);
            Container.AddSingleScoped<IPlayerScope, PlayerDataSaver>(GetComponent<PlayerDataSaver>);
        }

        private static DependencyContainer Container => GameSingletons.DependencyInjector.DependencyContainer;

        public override void SelfDestroy()
        {
            Container.RemoveScope<IPlayerScope>();
        }

        public interface IPlayerScope { }
    }
}