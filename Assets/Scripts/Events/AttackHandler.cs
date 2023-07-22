using Entity.Components;
using Entity.Core;
using Events.Base;

namespace Events
{
    public class AttackEvent
    {
        public readonly IEntity Attacker;
        public AttackEvent(IEntity attacker)
        {
            Attacker = attacker;
        }
    }
    
    public class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus) { }

        protected override void HandleEvent(AttackEvent evt)
        {
            evt.Attacker.Get<IAttacker>()?.Attack();
        }
    }
}