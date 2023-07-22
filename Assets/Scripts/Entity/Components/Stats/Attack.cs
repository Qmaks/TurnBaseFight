using System;
using Entity.Components.Stats.Base;

namespace Entity.Components.Stats
{
    [Serializable]
    public class Attack : FloatStatComponent , IAttack
    {
        public Attack(float value,float maxValue) : base(value,maxValue) { }
    }
    
    public interface IAttack : IFloatStat { }
}