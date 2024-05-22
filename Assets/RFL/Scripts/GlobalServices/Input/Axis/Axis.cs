namespace RFL.Scripts.GlobalServices.Input.Axis
{
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class Axis
    {
        private readonly float _speed;

        public Axis(float speed)
        {
            Value = 0f;
            _speed = speed;
        }

        public float Value { get; private set; }

        public void Increase() => MoveTo(_speed, 1f);
        public void Decrease() => MoveTo(_speed, -1f);
        public void Zero() => MoveTo(_speed, 0f);

        private void MoveTo(float speed, float target)
        {
            Value = target switch
            {
                < 0 => Mathf.Clamp(Value, -1, 0),
                > 0 => Mathf.Clamp(Value, 0, 1),
                _ => Value
            };

            Value = Mathf.MoveTowards(Value, target, speed * TimeService.DeltaTime);
        }

        public static implicit operator float(Axis axis) => axis.Value;
    }
}