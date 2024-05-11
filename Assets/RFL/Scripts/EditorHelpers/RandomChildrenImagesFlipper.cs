namespace RFL.Scripts.EditorHelpers
{
    using System;
    using RFL.Scripts.Extensions;
    using UnityEngine;
    using Random = RFL.Scripts.Helpers.Random;

    public class RandomChildrenImagesFlipper : MonoBehaviour
    {
        [SerializeField] private bool changeToFlip;
        [SerializeField] private bool changeToReset;

        private void OnValidate()
        {
            if (changeToFlip) FlipSprites();
            if (changeToReset) ResetSprites();
            changeToFlip = changeToReset = false;
        }

        private void ResetSprites()
        {
            ForAllSprites(x => x.flipX = x.flipY = false);
        }

        private void FlipSprites()
        {
            ForAllSprites(x =>
            {
                x.flipX = Random.Bool(50f);
                x.flipY = Random.Bool(50f);
            });
        }

        private void ForAllSprites(Action<SpriteRenderer> act)
        {
            GetComponentsInChildren<SpriteRenderer>().ForAll(act);
        }
    }
}