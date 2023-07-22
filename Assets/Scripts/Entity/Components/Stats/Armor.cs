using System;
using Entity.Components.Stats.Base;

namespace Entity.Components.Stats
{
    [Serializable]
    public class Armor : FloatStatComponent , IArmor
    {
        public Armor(float value,float maxValue) : base(value,maxValue) { }
    }
    
    public interface IArmor : IFloatStat { }
}