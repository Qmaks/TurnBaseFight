using UI.Views;
using UnityEngine;
using Zenject;

namespace TurnSystem.Tasks
{
    public sealed class Player2TurnTask : Task
    {
        private HeroUI[] views;

        public Player2TurnTask(HeroUI[] views)
        {
            this.views = views;
        }
        
        protected override void OnRun()
        {
            Debug.Log("Turn Player2");
            
            views[0].Deactivate();
            views[1].Activate();
            
            views[1].OnAttackButton += OnAttackButton;
        }

        private void OnAttackButton()
        {
            Finish();
        }

        protected override void OnFinish()
        {
            views[0].OnAttackButton -= OnAttackButton;
            
            views[0].Activate();
            views[1].Deactivate();
        }
    }
}