using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African = 22, European = 20
    }

    public enum SwallowLoad
    {
        None = 0, Coconut = 4
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; } = SwallowLoad.None;

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return (int)Type - (int)Load;
        }
    }
}
