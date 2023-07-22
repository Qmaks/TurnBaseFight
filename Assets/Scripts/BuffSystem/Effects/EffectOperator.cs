namespace BuffSystem.NewBuffSystem
{
    public class EffectOperatorSum : IEffectOperator
    {
        public float Apply(float value1,float value2)
        {
            return value1 + value2;
        }
        
        public float Revert(float value1,float value2)
        {
            return value1 - value2;
        }
    }
    
    public class EffectOperatorMultiply : IEffectOperator
    {
        public float Apply(float value1,float value2)
        {
            return value1 * value2;
        }
        
        public float Revert(float value1,float value2)
        {
            return value1 / value2;
        }
    }
}