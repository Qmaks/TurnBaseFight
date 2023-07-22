using System;
using Entity.Components.Stats.Base;

namespace Entity.Components.Stats
{
    [Serializable]
    public class Vampire : FloatStatComponent , IVampire
    {
        public Vampire(float value,float maxValue) : base(value, maxValue) { }
    }
    
    public interface IVampire : IFloatStat { }
}