namespace Entity.Core
{
    public interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T element);

        object[] GetAll();
    }
}