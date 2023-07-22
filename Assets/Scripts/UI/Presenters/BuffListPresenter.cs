using System;
using BuffSystem.Base;
using BuffSystem.NewBuffSystem;
using Entity.Core;
using UI.Views;
using Zenject;

namespace UI.Presenters
{
    public class BuffListPresenter : IInitializable,IDisposable
    {
        private readonly IEntity hero;
        private readonly BuffsListView view;
        private IBuffsList buffList;

        public BuffListPresenter(IEntity hero, HeroUI view)
        {
            this.hero = hero;
            this.view = view.buffsUI.buffsListView;
        }
        
        public void Initialize()
        {
            buffList = hero.Get<IBuffsList>();

            buffList.OnAddBuff += OnAddBuff;
            buffList.OnRemoveBuff += OnRemoveBuff;
        }

        private void OnRemoveBuff(BaseBuff buff)
        {
            view.Remove(buff);
        }

        private void OnAddBuff(BaseBuff buff)
        {
            view.Add(buff);
        }

        public void Dispose()
        {
            buffList.OnAddBuff -= OnAddBuff;
            buffList.OnRemoveBuff -= OnRemoveBuff;
        }
    }
}