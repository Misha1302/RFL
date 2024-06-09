namespace RFL.Scripts.GameLogic.Player.Components.Movement
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh, Player.IPlayerScope
    {
        [SerializeField] private float speed = 5f;
        [Inject] private Lazy<IInputService> _inputService;
        [Inject] private Lazy<PlayerTransform> _playerTransform;

        protected override void Tick()
        {
            _playerTransform.Value.SetVelocityX(_inputService.Value.Input.X * speed);
        }
    }
}