namespace RFL.Scripts.GameLogic.Player.Components.Movement.Stepper
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Extensions.Math.Numbers;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    public class PlayerStepperWorker
    {
        private readonly PlayerStepperHelper _playerStepperHelper;
        private readonly StepperInfo _stepperInfo;


        public PlayerStepperWorker(StepperInfo stepperInfo)
        {
            _stepperInfo = stepperInfo;
            _playerStepperHelper = new PlayerStepperHelper(_stepperInfo);
        }

        public void TryWork()
        {
            if (!CanStep()) return;

            Raycasts(out var castLeft, out var castRight);

            if (!TryGetY(castLeft, castRight, out var y)) return;

            MovePlayer(y);
        }

        private static bool CanStep() => Dc.Get<Player>().Get<PlayerJumper>().GroundChecker.IsGroundedWithOutCoyote;

        private void Raycasts(out StepperRaycastInfo castLeft, out StepperRaycastInfo castRight)
        {
            castLeft = Raycast(_stepperInfo.LeftRayPoint.position);
            castRight = Raycast(_stepperInfo.RightRayPoint.position);
        }

        private void MovePlayer(float y)
        {
            var finishX = Dc.Get<Player>().Get<PlayerTransform>().Pos.x +
                          Dc.Get<IInputService>().Input.X.Sign() * _stepperInfo.XOffset;
            var finishY = _playerStepperHelper.CalcY(y);

            Dc.Get<Player>().Get<PlayerTransform>().Pos = new Vector3(finishX, finishY);
        }

        private static bool TryGetY(StepperRaycastInfo castLeft, StepperRaycastInfo castRight, out float y)
        {
            y = 0f;
            if (castLeft.WasHit && !castRight.WasAnyHitOnPath)
                y = castLeft.HitPoint.y;
            else if (!castLeft.WasAnyHitOnPath && castRight.WasHit)
                y = castRight.HitPoint.y;
            else if (castRight.WasHit && castLeft.WasHit)
                y = castLeft.HitPoint.y.Max(castRight.HitPoint.y);
            else return false;
            return true;
        }

        private StepperRaycastInfo Raycast(Vector3 point)
        {
            var count =
                Physics2D.Raycast(point, Vector2.down, PlayerStepper.ContactFilter2D, _stepperInfo.HitsBuffer,
                    _stepperInfo.MaxStep);

            var hits = _playerStepperHelper.GetValidRayHits(count);
            var hit = hits.GetBy((x, y) => x.point.y.CompareTo(y.point.y) > 0);
            var hitPoint = _playerStepperHelper.GetHitPoint(point, hit);

            DrawRay(point, hitPoint);
            return new StepperRaycastInfo(hitPoint, hit != default);
        }

        private void DrawRay(Vector3 point, Vector2 end)
        {
            Debug.DrawLine(point, point + Vector3.down * _stepperInfo.MaxStep, Color.red);
            if (!end.IsNan())
                Debug.DrawLine(point, end, Color.green);
        }
    }
}