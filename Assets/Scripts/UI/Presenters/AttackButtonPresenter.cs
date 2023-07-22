using System;
using Entity.Core;
using Events;
using Events.Base;
using UI.Views;
using Zenject;

namespace UI.Presenters
{
    public class AttackButtonPresenter : IInitializable, IDisposable
    {
        private EventBus eventBus;
        
        private HeroUI view;
        private IEntity hero;

        public AttackButtonPresenter(EventBus eventBus,IEntity hero, HeroUI view)
        {
            this.eventBus = eventBus;
            this.hero = hero;
            this.view = view;
        }

        public void Initialize()
        {
            view.OnAttackButton += OnAttackButton;
        }

        private void OnAttackButton()
        {
            eventBus.RaiseEvent(new AttackEvent(hero));
        }

        public void Dispose()
        {
            view.OnAttackButton -= OnAttackButton;
        }
    }
}