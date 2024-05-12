namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    [RequireComponent(typeof(PlayerHorizontalMovement))]
    [RequireComponent(typeof(PlayerJumper))]
    [RequireComponent(typeof(PlayerImageFlipper))]
    [RequireComponent(typeof(PlayerPhysicMaterial))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBeh
    {
    }
}