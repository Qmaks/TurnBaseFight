namespace BuffSystem.NewBuffSystem
{
    public interface IEffectOperator
    {
        float Apply(float value1,float value2);
        float Revert(float value1,float value2);
    }
}