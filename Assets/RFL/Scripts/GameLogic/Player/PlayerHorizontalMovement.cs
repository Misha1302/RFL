﻿namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;


        public override void Tick()
        {
            Rb.velocity = Rb.velocity.WithX(Services.InputService.Input.x * speed);
        }
    }
}