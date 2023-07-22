using Entity.Components;
using Entity.Core;
using Zenject;

namespace Entity
{
    public class HeroesTargetInstaller : IInitializable
    {
        private readonly IEntity[] heroes;

        public HeroesTargetInstaller(IEntity[] heroes)
        {
            this.heroes = heroes;
        }
        
        public void Initialize()
        {
            heroes[0].Get<ITarget>().Value = heroes[1];
            heroes[1].Get<ITarget>().Value = heroes[0];
        }
    }
}