using Entity.Components.Stats;
using Entity.Core;

namespace Entity.Components
{
    public interface IDamageReceiver
    {
        float ReceiveDamage(float damage);
    }

    public class DamageReceiver : IDamageReceiver
    {
        private readonly IEntity owner;

        public DamageReceiver(IEntity owner)
        {
            this.owner = owner;
        }

        public float ReceiveDamage(float attack)
        {
            var armor = owner.Get<IArmor>().Value;
            
            var damage = attack * (1 - armor / 100);
            owner.Get<IHealth>().Value -= damage;
            
            var effect = owner.Get<IDamageEffect>();
            effect.ApplyDamageEffect();
            
            return damage;
        }
    }
}