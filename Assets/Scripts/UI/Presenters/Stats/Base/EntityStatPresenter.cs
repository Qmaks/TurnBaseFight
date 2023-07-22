using System;
using Entity.Components.Stats.Base;
using Entity.Core;
using UI.Views;
using Zenject;

namespace UI.Presenters.Stats.Base
{
    public abstract class EntityStatPresenter<T> : IInitializable,IDisposable
        where T : IFloatStat
    {
        protected HeroUI view;
        private IEntity hero;

        protected EntityStatPresenter( IEntity hero, HeroUI view)
        {
            this.hero = hero;
            this.view = view;
        }

        public void Initialize()
        {
            hero.Get<T>().OnValueChanged += OnValueChanged;
            
            var health = hero.Get<T>().Value;
            var maxHealth = hero.Get<T>().MaxValue;
            
            OnValueChanged(health,maxHealth);
        }
        protected abstract void OnValueChanged(float value, float maxValue);
        
        public void Dispose()
        {
            hero.Get<T>().OnValueChanged -= OnValueChanged;
        }
    }
}