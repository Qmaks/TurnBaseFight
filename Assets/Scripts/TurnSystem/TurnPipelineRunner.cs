using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TurnSystem
{
    public sealed class TurnPipelineRunner : IInitializable,IDisposable
    {
        public event Action<int> OnChangeRound;
        public int Round { get; set; }
        
        [Inject] private TurnPipeline turnPipeline;
        
        public void Initialize()
        {
            turnPipeline.Finished += OnTurnPipelineFinished;
            Round = 1;
            turnPipeline.Run();
        }
        
        private void OnTurnPipelineFinished()
        {
            Round++;
            OnChangeRound?.Invoke(Round);
            
            turnPipeline.Run();
        }

        public void Dispose()
        {
            turnPipeline.Finished -= OnTurnPipelineFinished;
        }
    }
}