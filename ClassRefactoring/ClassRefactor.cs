using System;
using System.Reflection;

namespace DeveloperSample.ClassRefactoring
{
    public interface ISwallowInterface
    {
        int getUnladenSpeed();
    }

    public interface ILoadInterface
    {
        int getLadingPenalty();
    }

    public class Swallow
    {
        public ISwallowInterface Type { get; }
        public ILoadInterface Load { get; private set; }

        public Swallow(Type swallowType, Type swallowLoad)
        {
            if (!typeof(ISwallowInterface).IsAssignableFrom(swallowType))
            {
                throw new ArgumentException(nameof(swallowType), $"Is of the wrong type. This should implement the ISwallowInterface.");
            }
            if (!typeof(ILoadInterface).IsAssignableFrom(swallowLoad))
            {
                throw new ArgumentException(nameof(swallowLoad), $"Is of the wrong type. This should implement the ILoadInterface.");
            }

            Type = (ISwallowInterface)Activator.CreateInstance(swallowType);
            Load = (ILoadInterface)Activator.CreateInstance(swallowLoad);
        }

        public double GetAirspeedVelocity()
        {
            return Type.getUnladenSpeed() - Load.getLadingPenalty();
        }
    }
}
