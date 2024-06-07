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
        public Player()
        {
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerJumper>(GetComponent<PlayerJumper>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerStepper>(GetComponent<PlayerStepper>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerHorizontalMovement>(
                GetComponent<PlayerHorizontalMovement>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerTransform>(GetComponent<PlayerTransform>);
            Dc.Instance.AddLazySingleScoped<PlayerScope, PlayerDataSaver>(GetComponent<PlayerDataSaver>);
        }
    }
}