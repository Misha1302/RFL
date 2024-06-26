namespace RFL.Scripts.GameLogic.Sky
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class SkyMovement : MonoBeh
    {
        [ExtendedRange(1, 7, 2)] [SerializeField]
        private int skiesCount;

        [SerializeField] private float speed = -1;

        [Inject] private CreatorService _creatorService;

        private Transform _sky;
        private float _width;

        protected override void OnStart()
        {
            _sky = Resources.Load<Transform>("Sky/Background");
            _width = _sky.GetComponent<SpriteRenderer>().bounds.size.x;
            SpawnBackgrounds();
        }

        protected override void Tick()
        {
            Move();
            TeleportBackIfNeed();
        }

        private void TeleportBackIfNeed()
        {
            if (transform.localPosition.x < -_width || transform.localPosition.x > _width)
                transform.localPosition = transform.localPosition.WithX(0);
        }

        private void Move()
        {
            transform.position += new Vector3(speed * DeltaTime, 0f);
        }

        private void SpawnBackgrounds()
        {
            InstantiateSky(_sky, 0);
            for (var i = 1; i <= skiesCount / 2; i++)
            {
                InstantiateSky(_sky, i * _width);
                InstantiateSky(_sky, -i * _width);
            }
        }

        private void InstantiateSky(Transform obj, float xPos)
        {
            var instance = _creatorService.Instantiate(obj);
            instance.SetParent(transform);
            instance.localPosition = new Vector3(xPos, 0, 10);
        }
    }
}