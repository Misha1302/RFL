namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(PlayerStepper))]
    [RequireComponent(typeof(PlayerHorizontalMovement))]
    [RequireComponent(typeof(PlayerJumper))]
    [RequireComponent(typeof(PlayerImageFlipper))]
    [RequireComponent(typeof(PlayerPhysicMaterial))]
    [RequireComponent(typeof(Rigidbody2D))]
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
            Di.AddScopedSingleton<PlayerScope, Rigidbody2D>(GetComponent<Rigidbody2D>);
            Di.AddScopedSingleton<PlayerScope, PlayerHorizontalMovement>(GetComponent<PlayerHorizontalMovement>);
        }

        private static Di Di => Di.Instance;

        public static PlayerStepper PlayerStepper => Di.GetScopedSingleton<PlayerScope, PlayerStepper>();
        public static PlayerJumper PlayerJumper => Di.GetScopedSingleton<PlayerScope, PlayerJumper>();
        public static PlayerImageFlipper PlayerImageFlipper => Di.GetScopedSingleton<PlayerScope, PlayerImageFlipper>();

        public static PlayerPhysicMaterial PlayerPhysicMaterial =>
            Di.GetScopedSingleton<PlayerScope, PlayerPhysicMaterial>();

        public static Rigidbody2D Rigidbody2D => Di.Instance.GetScopedSingleton<PlayerScope, Rigidbody2D>();
        public static PlayerPauseHandler PlayerPauseHandler => Di.GetScopedSingleton<PlayerScope, PlayerPauseHandler>();

        public PlayerHorizontalMovement PlayerHorizontalMovement =>
            Di.GetScopedSingleton<PlayerScope, PlayerHorizontalMovement>();

        public static Player PlayerSingleton => Di.Instance.GetGlobalSingleton<Player>();
    }
}