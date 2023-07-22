using Entity.Core;
using TurnSystem.Tasks;
using UI.Views;
using Zenject;

namespace TurnSystem
{
    public sealed class TurnPipelineInstaller : IInitializable
    {
        private readonly DiContainer diContainer;
        private readonly TurnPipeline turnPipeline;

        public TurnPipelineInstaller(DiContainer diContainer, TurnPipeline turnPipeline)
        {
            this.diContainer = diContainer;
            this.turnPipeline = turnPipeline;
        }
        
        public void Initialize()
        {
            turnPipeline.AddTask(diContainer.Instantiate<StartTurnTask>());
            
            turnPipeline.AddTask(diContainer.Instantiate<Player1TurnTask>());

            turnPipeline.AddTask(diContainer.Instantiate<Player2TurnTask>());
            
            turnPipeline.AddTask(diContainer.Instantiate<FinishTurnTask>());
        }
    }
}