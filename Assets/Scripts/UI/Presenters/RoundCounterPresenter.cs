using System;
using TurnSystem;
using UI.Views;
using Zenject;

namespace UI.Presenters
{
    public class RoundCounterPresenter : IInitializable, IDisposable
    {
        private TurnPipelineRunner pipelineRunner;
        private RoundCounterView view;

        public RoundCounterPresenter(TurnPipelineRunner pipelineRunner,RoundCounterView view)
        {
            this.pipelineRunner = pipelineRunner;
            this.view = view;
        }
        
        public void Initialize()
        {
            pipelineRunner.OnChangeRound += UpdateView;
            UpdateView(pipelineRunner.Round);
        }

        private void UpdateView(int value)
        {
            view.Set($"{value}");
        }

        public void Dispose()
        {
            pipelineRunner.OnChangeRound -= UpdateView;
        }
    }
}