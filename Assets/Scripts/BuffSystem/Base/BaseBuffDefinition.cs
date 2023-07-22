using Entity.Core;
using UnityEngine;

namespace BuffSystem.NewBuffSystem
{
    [CreateAssetMenu(menuName = "NewBuffDefinition")]
    public class BaseBuffDefinition : ScriptableObject
    {
        public string visualName;
        public int duration;
                
        [SerializeReference]
        public IEffect[] effectList;

        public  BaseBuff InitializeBuff(IEntity entity)
        {
            return new BaseBuff(this, entity);
        }
    }
}