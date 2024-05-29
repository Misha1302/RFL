namespace RFL.Scripts.GlobalServices.Pause
{
    using System;

    public class PauseService : IService
    {
        private bool _pause;
        public Action<bool> OnPausedChanged;

        public bool Pause
        {
            get => _pause;
            set
            {
                _pause = value;
                OnPausedChanged?.Invoke(_pause);
            }
        }
    }
}