using System;

namespace TurnSystem
{
    public abstract class Task
    {
        private Action<Task> _callback;

        public void Run(Action<Task> callback = null)
        {
            _callback = callback;
            OnRun();
        }

        protected abstract void OnRun();
        
        protected void Finish()
        {
            OnFinish();

            if (_callback != null)
            {
                var callback = _callback;
                _callback = null;
                
                callback?.Invoke(this);
            }
        }

        protected virtual void OnFinish()
        {
            
        }
    }
}
