using BuffSystem;
using BuffSystem.Base;
using BuffSystem.NewBuffSystem;
using UnityEngine;

namespace Zenject
{
    public class BuffsInstaller : MonoInstaller
    {
        [SerializeField] private BaseBuffDefinition[] buffDefinitions;
        
        public override void InstallBindings()
        {
            Container.Bind<BaseBuffDefinition[]>().FromInstance(buffDefinitions).AsSingle();
            Container.Bind<BuffFactory>().FromNew().AsSingle();
        }
    }
}