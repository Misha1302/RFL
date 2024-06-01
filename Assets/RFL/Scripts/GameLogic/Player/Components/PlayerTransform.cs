namespace RFL.Scripts.GameLogic.Player.Components
{
    using System;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTransform : MonoBeh
    {
        private readonly Lazy<Rigidbody2D> _rb2D;

        public PlayerTransform()
        {
            _rb2D = new Lazy<Rigidbody2D>(GetComponent<Rigidbody2D>);
        }

        private Rigidbody2D Rb2D => _rb2D.Value;


        public Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Vector3 Vel
        {
            get => Rb2D.velocity;
            set => Rb2D.velocity = value;
        }


        public void MoveToX(float x) => Pos = Pos.WithX(x);

        public void MoveToY(float y) => Pos = Pos.WithY(y);

        public void SetVelocityX(float x) => Rb2D.velocity = Rb2D.velocity.WithX(x);
        public void SetVelocityY(float y) => Rb2D.velocity = Rb2D.velocity.WithY(y);

        public void AddForce(Vector2 vec) => Rb2D.AddForce(vec);

        public void UnFreeze() => Rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        public void Freeze() => Rb2D.constraints = RigidbodyConstraints2D.FreezeAll;

        public void SetPhysicsMaterial(PhysicsMaterial2D mat) => Rb2D.sharedMaterial = mat;
    }
}