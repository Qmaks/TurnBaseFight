using System;
using UnityEngine;

namespace Entity.Components.Stats.Base
{
    [Serializable]
    public abstract class FloatStatComponent : IFloatStat
    {
        public float Value
        {
            get => currentValue;
            set => SetValue(value);
        }
        
        public float MaxValue
        {
            get => maxValue;
            set => maxValue = value;
        }

        public event Action<float,float> OnValueChanged;

        private float currentValue;
        private float maxValue;

        protected FloatStatComponent(float value,float maxValue)
        {
            currentValue = value;
            this.maxValue = maxValue;
        }
        
        protected virtual void SetValue(float value)
        {
            this.currentValue = Filter(value);
            
            OnValueChanged?.Invoke(this.currentValue,maxValue);
        }

        protected float Filter(float value)
        {
            return Mathf.Clamp(value,0f, maxValue);
        }
    }
    
    public interface IFloatStat
    {
        public float Value { get; set; }
        public float MaxValue { get; set; }
        
        public event Action<float,float> OnValueChanged;
    }
}