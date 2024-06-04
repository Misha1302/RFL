namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class FpsText : MonoBeh
    {
        [SerializeField] private string format = "{0}";

        private void OnValidate()
        {
            format = GetComponent<TMP_Text>().text;
        }

        protected override void OnStart()
        {
            Di.Get<RepositoryService>().GameData.targetFps.OnChanged += SetText;
        }

        public override void SelfDestroy()
        {
            Di.Get<RepositoryService>().GameData.targetFps.OnChanged -= SetText;
        }

        private void SetText()
        {
            var targetFps = Di.Get<RepositoryService>().GameData.targetFps.Value;
            GetComponent<TMP_Text>().text = string.Format(format, targetFps);
        }
    }
}