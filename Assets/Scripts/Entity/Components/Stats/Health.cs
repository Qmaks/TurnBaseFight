using System;
using Entity.Components.Stats.Base;

namespace Entity.Components.Stats
{
    [Serializable]
    public class Health : FloatStatComponent , IHealth
    {
        public Health(float value,float maxValue) : base(value,maxValue)
        {
        }
    }
    
    public interface IHealth : IFloatStat { }
}