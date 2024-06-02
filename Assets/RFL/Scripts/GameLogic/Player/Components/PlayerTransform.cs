namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTransform : MonoBeh
    {
        private Rigidbody2D _rb2D;

        public Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Vector3 Vel
        {
            get => _rb2D.velocity;
            set => _rb2D.velocity = value;
        }

        protected override void OnStart()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }


        public void MoveToX(float x) => Pos = Pos.WithX(x);
        public void MoveToY(float y) => Pos = Pos.WithY(y);

        public void SetVelocityX(float x) => _rb2D.velocity = _rb2D.velocity.WithX(x);
        public void SetVelocityY(float y) => _rb2D.velocity = _rb2D.velocity.WithY(y);

        public void AddForce(Vector2 vec) => _rb2D.AddForce(vec);

        public void UnFreeze() => _rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        public void Freeze() => _rb2D.constraints = RigidbodyConstraints2D.FreezeAll;

        public void SetPhysicsMaterial(PhysicsMaterial2D mat) => _rb2D.sharedMaterial = mat;
    }
}