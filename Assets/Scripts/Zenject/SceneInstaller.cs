using Entity;
using Entity.Core;
using Events;
using Events.Base;
using TurnSystem;
using UI.Presenters;
using UI.Presenters.Stats;
using UI.Views;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("Entites")]
    [SerializeField] private HeroEntity hero1;
    [SerializeField] private HeroEntity hero2;

    [Header("UI")] 
    [SerializeField] private Hud hud;
    
    public override void InstallBindings()
    {
        BindHeroes();
        var eventBus = BindEvents();
        BindTurnSystem();
        BindUI(eventBus);
    }

    private void BindTurnSystem()
    {
        Container.Bind<TurnPipeline>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TurnPipelineRunner>().FromNew().AsSingle().NonLazy();
    }

    private void BindHeroes()
    {
        Container.Bind<IEntity>().FromInstance(hero1).AsCached();
        Container.Bind<IEntity>().FromInstance(hero2).AsCached();
        
        Container.BindInterfacesAndSelfTo<HeroesTargetInstaller>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<HeroesDeathController>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<HeroesRoundTicker>().FromNew().AsSingle().NonLazy();
    }

    private EventBus BindEvents()
    {
        var eventBus = new EventBus();
        Container.Bind<EventBus>().FromInstance(eventBus).AsSingle();
        
        Container.BindInterfacesAndSelfTo<AttackHandler>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<RestartGameHandler>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<AddBuffHandler>().FromNew().AsSingle().NonLazy();
        return eventBus;
    }

    private void BindUI(EventBus eventBus)
    {
        Container.Bind<Hud>().FromComponentInHierarchy().AsSingle();

        Container.Bind<RoundCounterView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesTo<RoundCounterPresenter>().FromNew().AsSingle().NonLazy();

        Container.Bind<HeroUI>().FromInstance(hud.heroUILeft).AsCached();
        Container.Bind<HeroUI>().FromInstance(hud.heroUIRight).AsCached();

        BindHeroPresenter(hero1,hud.heroUILeft);
        BindHeroPresenter(hero2,hud.heroUIRight);
    }

    private void BindHeroPresenter(IEntity hero, HeroUI view)
    {
        Container.BindInterfacesTo<AddBuffButtonPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);

        Container.BindInterfacesTo<BuffListPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);

        Container.BindInterfacesTo<AttackButtonPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);

        Container.BindInterfacesTo<VampireBarPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);
        
        Container.BindInterfacesTo<ArmorBarPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);

        Container.BindInterfacesTo<HealthBarPresenter>().FromNew().AsCached()
            .WithArguments(hero, view);
    }
}
