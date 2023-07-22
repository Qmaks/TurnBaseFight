using BuffSystem.Base;
using Entity.Components;
using Entity.Components.Stats;
using Entity.Components.Stats.Base;
using Entity.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entity
{
    public class HeroEntity : MonoEntity
    {
        [FormerlySerializedAs("definitions")]
        [Header("Stats")]
        [SerializeField] private FloatStatDefinition[] statDefinitions;

        
        [Header("Links")]
        [SerializeField] private SpriteRenderer sprite;
        private void Awake()
        {
            //Stats..
            foreach (var statDefinition in statDefinitions)
            {
                Add(statDefinition.CreateStat());
            }
            
            //Logic..
            Add(new Attacker(this));
            Add(new DamageReceiver(this));
            Add(new DamageEffect(sprite));
            Add(new Death(Get<IHealth>()));
            Add(new Target());
        
            //Buffs
            Add(new BuffsList());
        }
    }
}