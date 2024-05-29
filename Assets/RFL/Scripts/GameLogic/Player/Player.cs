namespace RFL.Scripts.GameLogic.Player
{
    using System;
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
    public class Player : MonoBeh
    {
        private readonly Lazy<PlayerHorizontalMovement> _playerHorizontalMovement;
        private readonly Lazy<PlayerImageFlipper> _playerImageFlipper;
        private readonly Lazy<PlayerJumper> _playerJumper;
        private readonly Lazy<PlayerPauseHandler> _playerPauseHandler;
        private readonly Lazy<PlayerPhysicMaterial> _playerPhysicMaterial;
        private readonly Lazy<PlayerStepper> _playerStepper;
        private readonly Lazy<PlayerTransform> _playerTransform;

        public Player()
        {
            Di.Instance.AddGlobalSingleton(this);
            _playerImageFlipper = new Lazy<PlayerImageFlipper>(GetComponent<PlayerImageFlipper>);
            _playerJumper = new Lazy<PlayerJumper>(GetComponent<PlayerJumper>);
            _playerPauseHandler = new Lazy<PlayerPauseHandler>(GetComponent<PlayerPauseHandler>);
            _playerPhysicMaterial = new Lazy<PlayerPhysicMaterial>(GetComponent<PlayerPhysicMaterial>);
            _playerStepper = new Lazy<PlayerStepper>(GetComponent<PlayerStepper>);
            _playerHorizontalMovement = new Lazy<PlayerHorizontalMovement>(GetComponent<PlayerHorizontalMovement>);
            _playerTransform = new Lazy<PlayerTransform>(GetComponent<PlayerTransform>);
        }

        public PlayerHorizontalMovement PlayerHorizontalMovement => _playerHorizontalMovement.Value;
        public PlayerImageFlipper PlayerImageFlipper => _playerImageFlipper.Value;
        public PlayerJumper PlayerJumper => _playerJumper.Value;
        public PlayerPauseHandler PlayerPauseHandler => _playerPauseHandler.Value;
        public PlayerPhysicMaterial PlayerPhysicMaterial => _playerPhysicMaterial.Value;
        public PlayerStepper PlayerStepper => _playerStepper.Value;
        public PlayerTransform PlayerTransform => _playerTransform.Value;
    }
}