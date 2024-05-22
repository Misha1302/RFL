namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.GameLogic.Player.Movement;
    using RFL.Scripts.GameLogic.Player.Stepper;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(PlayerTransform))]
    [RequireComponent(typeof(PlayerStepper))]
    [RequireComponent(typeof(PlayerHorizontalMovement))]
    [RequireComponent(typeof(PlayerJumper))]
    [RequireComponent(typeof(PlayerImageFlipper))]
    [RequireComponent(typeof(PlayerPhysicMaterial))]
    [RequireComponent(typeof(PlayerPauseHandler))]
    public class Player : MonoBeh
    {
        public Player()
        {
            Di.AddScopedSingleton<PlayerScope, PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            Di.AddScopedSingleton<PlayerScope, PlayerJumper>(GetComponent<PlayerJumper>);
            Di.AddScopedSingleton<PlayerScope, PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            Di.AddScopedSingleton<PlayerScope, PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            Di.AddScopedSingleton<PlayerScope, PlayerStepper>(GetComponent<PlayerStepper>);
            Di.AddScopedSingleton<PlayerScope, PlayerHorizontalMovement>(GetComponent<PlayerHorizontalMovement>);
            Di.AddScopedSingleton<PlayerScope, PlayerTransform>(GetComponent<PlayerTransform>);
        }

        private static Di Di => Di.Instance;

        public static PlayerStepper PlayerStepper => Di.GetScopedSingleton<PlayerScope, PlayerStepper>();
        public static PlayerTransform PlayerTransform => Di.GetScopedSingleton<PlayerScope, PlayerTransform>();
        public static PlayerJumper PlayerJumper => Di.GetScopedSingleton<PlayerScope, PlayerJumper>();
        public static PlayerImageFlipper PlayerImageFlipper => Di.GetScopedSingleton<PlayerScope, PlayerImageFlipper>();

        public static PlayerPhysicMaterial PlayerPhysicMaterial =>
            Di.GetScopedSingleton<PlayerScope, PlayerPhysicMaterial>();

        public static PlayerPauseHandler PlayerPauseHandler => Di.GetScopedSingleton<PlayerScope, PlayerPauseHandler>();

        public PlayerHorizontalMovement PlayerHorizontalMovement =>
            Di.GetScopedSingleton<PlayerScope, PlayerHorizontalMovement>();

        public static Player PlayerSingleton => Di.Instance.GetGlobalSingleton<Player>();
    }
}