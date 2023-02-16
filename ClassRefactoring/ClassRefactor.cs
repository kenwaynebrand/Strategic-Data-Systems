using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African = 18, European = 16
    }

    public enum SwallowLoad
    {
        None = 4, Coconut = 0
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
            Load = SwallowLoad.None;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return (int)Type + (int)Load;
        }
    }
}