using Entity.Components.Stats;
using Entity.Core;
using UI.Presenters.Stats.Base;
using UI.Views;

namespace UI.Presenters.Stats
{
    public class VampireBarPresenter : EntityStatPresenter<IVampire>
    {
        public VampireBarPresenter(IEntity hero, HeroUI view) 
            : base(hero, view) { }

        protected override void OnValueChanged(float value, float maxValue)
        {
            var progress = maxValue > 0 ? value / maxValue : 0;
            view.SetVampire($"{value}/{maxValue}",progress);
        }
    }
}