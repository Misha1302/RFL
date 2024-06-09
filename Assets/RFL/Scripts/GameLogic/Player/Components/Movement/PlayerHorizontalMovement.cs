﻿namespace RFL.Scripts.GameLogic.Player.Components.Movement
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;
        [Inject] private IInputService _inputService;
        [Inject] private PlayerTransform _playerTransform;

        protected override void Tick()
        {
            _playerTransform.SetVelocityX(_inputService.Input.X * speed);
        }
    }
}