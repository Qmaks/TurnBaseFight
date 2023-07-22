using Entity.Core;

namespace BuffSystem.NewBuffSystem
{
    public interface IEffect
    {
        public void Activate(IEntity entity);
        public void Finish(IEntity entity);
        public void ApplyOnAttack(IEntity entity);
    }
}