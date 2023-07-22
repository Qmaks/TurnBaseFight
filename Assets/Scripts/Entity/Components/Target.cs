using Entity.Core;

namespace Entity.Components
{
    public class Target : ITarget
    {
        public IEntity Value { get; set; }
    }

    public interface ITarget
    {
        public IEntity Value { get; set; }
    }
}