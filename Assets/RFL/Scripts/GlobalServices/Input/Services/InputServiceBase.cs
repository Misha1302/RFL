namespace RFL.Scripts.GlobalServices.Input.Services
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Axis;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class InputServiceBase : MonoBeh, IInputService
    {
        public Axis2D Input { get; private set; }
        public bool Jump { get; protected set; }
        public Action OnPause { get; set; }


        protected override void OnCreated()
        {
            Input = new Axis2D(Dc.Get<RepositoryService>().GameData.inputSpeed.Value);
        }

        protected override void OnStart()
        {
            SubscribeOnButtonPause();
        }

        protected static float CalcDir(bool neg, bool pos)
        {
            float dir = 0;
            if (pos) dir++;
            if (neg) dir--;
            return dir;
        }

        private void SubscribeOnButtonPause()
        {
            var pauseCanvas = Resources.Load("UI/PauseCanvas");
            var pauseCanvasInstance = Dc.Get<CreatorService>().Instantiate(pauseCanvas);
            var button = pauseCanvasInstance.GetComponentInChildren<PauseButtonTag>().GetComponent<Button>();
            button.onClick.AddListener(OnPause.Invoke);
        }
    }
}