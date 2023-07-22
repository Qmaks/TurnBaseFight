using System;

namespace Entity.Components.Stats
{
    public interface IDeath
    {
        event Action OnDeath;
        bool IsDeath { get; set; }
    }

    public class Death : IDisposable, IDeath
    {
        public event Action OnDeath;
        public bool IsDeath { get; set; }
        
        private readonly IHealth health;
        
        public Death(IHealth health)
        {
            this.health = health;
            health.OnValueChanged += OnHealthChange;
        }

        private void OnHealthChange(float hp, float maxHp)
        {
            if (hp <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void Dispose()
        {
            health.OnValueChanged -= OnHealthChange;
        }
    }
}