namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    public class PlayerPhysicMaterial : MonoBeh
    {
        public override void OnStart()
        {
            Rb.sharedMaterial = new PhysicsMaterial2D
            {
                friction = 0f
            };
        }
    }
}