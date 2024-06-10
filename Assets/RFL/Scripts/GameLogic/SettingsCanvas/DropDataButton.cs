namespace RFL.Scripts.GameLogic.SettingsCanvas
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class DropDataButton : MonoBeh
    {
        [Inject] private RepositoryService _repositoryService;

        protected override void OnStart()
        {
            GetComponent<Button>().onClick.AddListener(_repositoryService.Reset);
        }
    }
}