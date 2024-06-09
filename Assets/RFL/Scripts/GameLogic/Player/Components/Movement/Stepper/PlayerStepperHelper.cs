namespace RFL.Scripts.GameLogic.Player.Components.Movement.Stepper
{
    using System.Collections.Generic;
    using System.Linq;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GameLogic.Tags;
    using UnityEngine;

    public class PlayerStepperHelper : InjectableBase, Player.IPlayerScope
    {
        [Inject] private PlayerStepper _playerStepper;

        private readonly StepperInfo _stepperInfo;

        public PlayerStepperHelper(StepperInfo stepperInfo)
        {
            _stepperInfo = stepperInfo;
        }

        public float CalcY(float y) => y + _playerStepper.Player2FootsDelta;

        public IEnumerable<RaycastHit2D> GetValidRayHits(int count) =>
            _stepperInfo.HitsBuffer.Slice(0, count).Where(x => !x.transform.HasComponent<PlayerTag>());

        public Vector2 GetHitPoint(Vector3 point, RaycastHit2D hit) =>
            IsValidPointToStep(point, hit) ? hit.point : Vectors2Extensions.MakeNan();

        private bool IsValidPointToStep(Vector3 point, RaycastHit2D hit) =>
            hit && NotGround(point, hit);

        private bool NotGround(Vector3 point, RaycastHit2D hit) =>
            point.y - hit.point.y >= _stepperInfo.MinStep;
    }
}