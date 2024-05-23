namespace RFL.Scripts.GlobalServices.Input.Axis
{
    using System;
    using UnityEngine;
    using Services = RFL.Scripts.GlobalServices.Services;

    public class Axis
    {
        private readonly float _speed;

        public Axis(float speed)
        {
            Value = 0f;
            _speed = speed;
        }

        public float Value { get; private set; }

        public void HandleDirection(float dir) => MoveTo(_speed, Math.Sign(dir));

        private void MoveTo(float speed, float target)
        {
            Value = target switch
            {
                < 0 => Mathf.Clamp(Value, -1, 0),
                > 0 => Mathf.Clamp(Value, 0, 1),
                _ => Value
            };

            Value = Mathf.MoveTowards(Value, target, speed * Services.TimeService.DeltaTime);
        }

        public static implicit operator float(Axis axis) => axis.Value;
    }
}