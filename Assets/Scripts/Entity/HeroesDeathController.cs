using System;
using Entity.Components.Stats;
using Entity.Core;
using Events;
using Events.Base;
using Zenject;

namespace Entity
{
    public class HeroesDeathController : IInitializable,IDisposable
    {
        private readonly EventBus eventBus;
        private readonly IEntity[] heroes;

        public HeroesDeathController(EventBus eventBus,IEntity[] heroes)
        {
            this.eventBus = eventBus;
            this.heroes = heroes;
        }
        
        public void Initialize()
        {
            heroes[0].Get<IDeath>().OnDeath += OnDeath;
            heroes[1].Get<IDeath>().OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            eventBus.RaiseEvent(new RestartGameEvent());
        }

        public void Dispose()
        {
            heroes[0].Get<IDeath>().OnDeath += OnDeath;
            heroes[1].Get<IDeath>().OnDeath += OnDeath;
        }
    }
}