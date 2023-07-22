using Entity.Components.Stats;
using Entity.Core;
using UI.Presenters.Stats.Base;
using UI.Views;

namespace UI.Presenters.Stats
{
    public class HealthBarPresenter : EntityStatPresenter<IHealth>
    {
        public HealthBarPresenter(IEntity hero, HeroUI view) 
            : base(hero, view) { }

        protected override void OnValueChanged(float value, float maxValue)
        {
            var progress = maxValue > 0 ? value / maxValue : 0;
            view.SetHealth($"{value}/{maxValue}",progress);
        }
    }
}