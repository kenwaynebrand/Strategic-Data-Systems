using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Reflection;

namespace DeveloperSample.ClassRefactoring
{
    public interface ISwallowInterface
    {
        int Speed { get; }
    }

    public interface ILoadInterface
    {
        int Penalty { get; }
    }

    public class Swallow
    {
        public ISwallowInterface Type { get; }
        public ILoadInterface Load { get; private set; }

        public Swallow(Type swallowType, Type swallowLoad)
        {
            if (!typeof(ISwallowInterface).IsAssignableFrom(swallowType))
            {
                throw new ArgumentException(nameof(swallowType), $" Is of the wrong type. This should implement the ISwallowInterface.");
            }
            if (!typeof(ILoadInterface).IsAssignableFrom(swallowLoad))
            {
                throw new ArgumentException(nameof(swallowLoad), $" Is of the wrong type. This should implement the ILoadInterface.");
            }
            Type = (ISwallowInterface)Activator.CreateInstance(swallowType);
            if (Type.Speed <= 0)
            {
                throw new ArgumentException(nameof(swallowType), $" was created with an incorrect Speed parameter. Speed must by greater than zero.");
            }
            Load = (ILoadInterface)Activator.CreateInstance(swallowLoad);
            if (Load.Penalty < 0)
            {
                throw new ArgumentException(nameof(swallowLoad), $" was created with an incorrect Penalty parameter. Penalty must by greater than or equal to zero.");
            }
        }

        public double GetAirspeedVelocity()
        {
            return Type.Speed - Load.Penalty;
        }
    }
}
