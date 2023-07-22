using System;
using Entity.Core;
using Events;
using Events.Base;
using TurnSystem;
using UI.Views;
using Zenject;

namespace UI.Presenters
{
    public class AddBuffButtonPresenter : IInitializable, IDisposable
    {
        private TurnPipelineRunner turnPipelineRunner;
        private EventBus eventBus;
        private HeroUI view;
        private IEntity hero;
        private bool IsAdded;

        public AddBuffButtonPresenter(TurnPipelineRunner turnPipelineRunner,EventBus eventBus,IEntity hero, HeroUI view)
        {
            this.turnPipelineRunner = turnPipelineRunner;
            this.eventBus = eventBus;
            this.view = view;
            this.hero = hero;
        }
        
        public void Initialize()
        {
            turnPipelineRunner.OnChangeRound += OnChangeRound;
            view.buffsUI.OnAddBuffButtonClick += AddBuffClick;
        }

        private void OnChangeRound(int obj)
        {
            IsAdded = false;
        }

        private void AddBuffClick()
        {
            if (IsAdded)
                return;
            
            IsAdded = true;
            eventBus.RaiseEvent(new AddBuffEvent(hero));
        }

        public void Dispose()
        {
            view.buffsUI.OnAddBuffButtonClick -= AddBuffClick;
            turnPipelineRunner.OnChangeRound -= OnChangeRound;
        }
    }
}