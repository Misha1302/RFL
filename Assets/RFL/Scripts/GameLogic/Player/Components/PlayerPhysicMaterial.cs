namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerPhysicMaterial : MonoBeh
    {
        protected override void OnStart()
        {
            Di.Get<Player>().Get<PlayerTransform>().SetPhysicsMaterial(new PhysicsMaterial2D { friction = 0f });
        }
    }
}