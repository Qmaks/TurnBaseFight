using System;
using BuffSystem.Base;
using Entity.Core;
using TurnSystem;
using Zenject;

namespace Entity
{
    public class HeroesRoundTicker : IInitializable, IDisposable
    {
        private IEntity[] heroes;
        private TurnPipelineRunner turnPipelineRunner;

        public HeroesRoundTicker(IEntity[] heroes,TurnPipelineRunner turnPipelineRunner)
        {
            this.heroes = heroes;
            this.turnPipelineRunner = turnPipelineRunner;
        }
        
        public void Initialize()
        {
            turnPipelineRunner.OnChangeRound += TickRound;                
        }

        private void TickRound(int round)
        {
            foreach (var entity in heroes)
            {
                entity.Get<IBuffsList>()?.Tick();
            }
        }

        public void Dispose()
        {
            turnPipelineRunner.OnChangeRound -= TickRound;                
        }
    }
}