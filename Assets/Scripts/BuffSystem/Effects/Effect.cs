using Entity.Components.Stats;
using Entity.Components.Stats.Base;
using Entity.Core;
using UnityEngine;

namespace BuffSystem.NewBuffSystem
{
    public abstract class Effect<T> : IEffect
        where T : IFloatStat
    {
        
        [SerializeReference] protected IEffectOperator Operator;

        [SerializeField] protected float Value;

        public virtual void Activate(IEntity entity){}
        public virtual void Finish(IEntity entity){}
        public virtual void ApplyOnAttack(IEntity entity){}
    }

    public abstract class EffectSelf<T> : Effect<T> 
        where T : IFloatStat
    {
        public override void Activate(IEntity entity)
        {
            if (entity==null)
                return;
            
            var type = entity.Get<T>();

            if (type != null)
            {
                type.Value = Operator.Apply(type.Value, Value);
            }
        }

        public override void Finish(IEntity entity)
        {
            if (entity==null)
                return;
            
            var type = entity.Get<T>();

            if (type != null)
            {
                type.Value = Operator.Revert(type.Value, Value);
            }
        }
        
    }
    
    public abstract class EffectOnAttack<T> : Effect<T> 
        where T : IFloatStat
    {
        public override void ApplyOnAttack(IEntity entity)
        {
            if (entity==null)
                return;
            
            var type = entity.Get<T>();
                
            if (type!=null)
            {
                type.Value = Operator.Apply(type.Value, Value);

            }
        }
    }
   
    public class ArmorEffectOnAttack : EffectOnAttack<IArmor> { }
    public class VampirismEffectOnAttack : EffectOnAttack<IVampire> { }

    public class DoubleDamageSelf : EffectSelf<IAttack> { }
    public class ArmorEffectSelf : EffectSelf<IArmor> { }
    public class DamageEffectSelf : EffectSelf<IAttack> { }
    public class VampirismEffectSelf : EffectSelf<IVampire> { }
}