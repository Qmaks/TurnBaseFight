using BuffSystem.Base;
using Entity.Components.Stats;
using Entity.Core;

namespace Entity.Components
{
    public interface IAttacker
    {
        void Attack();
    }

    public class Attacker : IAttacker
    {
        private readonly IEntity owner;

        public Attacker(IEntity owner)
        {
            this.owner = owner;
        }

        public void Attack()
        {
            ApplyAttackBuffs();
            ApplyDamage();
        }
        
        private void ApplyAttackBuffs()
        {
            var targetEntity = owner.Get<ITarget>().Value;
            var buffList = owner.Get<IBuffsList>();
            
            buffList.ApplyOnAttack(targetEntity);
        }
        
        private void ApplyDamage()
        {
            var damageTaker = owner.Get<ITarget>().Value;
            
            var attack = owner.Get<IAttack>().Value;
            var vampire = owner.Get<IVampire>().Value;
            
            var damage = damageTaker.Get<IDamageReceiver>().ReceiveDamage(attack);
            
            var heal = damage * (vampire / 100);
            owner.Get<IHealth>().Value += heal;
        }
    }
}