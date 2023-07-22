using BuffSystem;
using BuffSystem.Base;
using Entity.Core;
using Events.Base;

namespace Events
{
    public class AddBuffEvent
    {
        public readonly IEntity Entity;
        public AddBuffEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
    
    public class AddBuffHandler : BaseHandler<AddBuffEvent>
    {
        private BuffFactory buffFactory;
        
        public AddBuffHandler(BuffFactory buffFactory,EventBus eventBus) : base(eventBus)
        {
            this.buffFactory = buffFactory;
        }
        
        protected override void HandleEvent(AddBuffEvent evt)
        {
            var hero = evt.Entity;
            var buffsList = hero.Get<IBuffsList>();

            if (!buffsList.HasFreeSpace())
                return;

            var unique = false;
            while (!unique)
            {
                var buff = buffFactory.CreateRandomBuff(hero);
                if (!buffsList.Contains(buff))
                {
                    buffsList.Add(buff);
                    unique = true;
                }                    
            }
        }
    }
}