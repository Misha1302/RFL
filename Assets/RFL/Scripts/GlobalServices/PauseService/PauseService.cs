namespace RFL.Scripts.GlobalServices.PauseService
{
    using System;

    public class PauseService
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