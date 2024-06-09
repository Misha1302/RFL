namespace RFL.Scripts.GameLogic.Player.Components
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerPhysicMaterial : MonoBeh, Player.IPlayerScope
    {
        [Inject] private Lazy<PlayerTransform> _playerTransform;

        protected override void OnStart()
        {
            _playerTransform.Value.SetPhysicsMaterial(new PhysicsMaterial2D { friction = 0f });
        }
    }
}