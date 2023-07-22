using Entity.Core;

namespace BuffSystem.NewBuffSystem
{
    public class BaseBuff
    {
        public string VisualName => definition.visualName;

        public bool isFinished { get; set; }
        
        private readonly BaseBuffDefinition definition;
        private readonly IEntity entity;

        private IEffect[] effects;
        private int duration;
        public BaseBuff(BaseBuffDefinition definition, IEntity entity)
        {
            this.definition = definition;
            this.entity = entity;

            duration = definition.duration;
        }
        
        public void Tick()
        {
            duration -= 1;
            if (duration <= 0)
            {
                Finish();
                isFinished = true;
            }
        }
        
        public void Activate()
        {
            foreach (var effect in definition.effectList)
            {
                effect.Activate(entity);
            }
        }
        
        public void ApplyOnAttack(IEntity _entity)
        {
            foreach (var effect in definition.effectList)
            {
                effect.ApplyOnAttack(_entity);
            }
        }

        private void Finish()
        {
            foreach (var effect in definition.effectList)
            {
                effect.Finish(entity);
            } 
        }
        public bool Equals(BaseBuff other)
        {
            return (this == other) || (this.definition.Equals(other.definition));
        }
        
    }
}