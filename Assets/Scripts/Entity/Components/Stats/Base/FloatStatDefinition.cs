using System;
using UnityEngine;

namespace Entity.Components.Stats.Base
{
    [Serializable]
    public class FloatStatDefinition
    {
        [SerializeReference]
        private IFloatStat statReference;
        
        public int value;
        public int maxValue;

        public IFloatStat CreateStat()
        {
            var type = statReference.GetType();
            return (IFloatStat)System.Activator.CreateInstance(type,value,maxValue);
        }
    }
}