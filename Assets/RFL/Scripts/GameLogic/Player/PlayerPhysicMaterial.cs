namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerPhysicMaterial : MonoBeh
    {
        protected override void OnStart()
        {
            Player.PlayerTransform.SetPhysicsMaterial(new PhysicsMaterial2D { friction = 0f });
        }
    }
}