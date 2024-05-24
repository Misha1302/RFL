namespace RFL.Scripts.GlobalServices.Input.Axis
{
    using System;
    using RFL.Scripts.Extensions;
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
                < 0 => Value.ClampNeg10(),
                > 0 => Value.Clamp01(),
                _ => Value
            };

            Value = Value.MoveTowards(target, speed * Services.TimeService.DeltaTime);
        }

        public static implicit operator float(Axis axis) => axis.Value;
    }
}