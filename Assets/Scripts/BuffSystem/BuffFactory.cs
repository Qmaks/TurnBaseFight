using BuffSystem.NewBuffSystem;
using Entity.Core;
using UnityEngine;
using Zenject;

namespace BuffSystem
{
    public class BuffFactory 
    {
        private readonly BaseBuffDefinition[] buffDefinitions;

        public BuffFactory(BaseBuffDefinition[] buffDefinitions)
        {
            this.buffDefinitions = buffDefinitions;
        }
        
        public BaseBuff CreateRandomBuff(IEntity entity)
        {
            var index =Random.Range(0, buffDefinitions.Length);
            return buffDefinitions[index].InitializeBuff(entity);
        }
    }
}