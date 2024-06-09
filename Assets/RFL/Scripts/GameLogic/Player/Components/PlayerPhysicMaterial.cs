namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerPhysicMaterial : MonoBeh
    {
        [Inject] private PlayerTransform _playerTransform;

        protected override void OnStart()
        {
            _playerTransform.SetPhysicsMaterial(new PhysicsMaterial2D { friction = 0f });
        }
    }
}