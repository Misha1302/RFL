namespace RFL.Scripts.GameLogic.SettingsCanvas
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class DropDataButton : MonoBeh
    {
        protected override void OnStart()
        {
            GetComponent<Button>().onClick.AddListener(Di.Get<RepositoryService>().Reset);
        }
    }
}