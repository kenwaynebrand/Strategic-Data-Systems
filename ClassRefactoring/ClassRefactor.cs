using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Reflection;

namespace DeveloperSample.ClassRefactoring
{
    internal interface ISwallowInterface
    {
        int Speed { get; }
    }

    internal interface ILoadInterface
    {
        int Penalty { get; }
    }

    public class swallowBase : ISwallowInterface
    {
        public swallowBase()
        {
            if (Speed <= 0)
            {
                throw new ArgumentException("Chile Swallow Class was defined with an incorrect Speed parameter. Speed must by greater than zero.");
            }
        }

        public virtual int Speed { get; }
            
    }

    public class loadBase : ILoadInterface
    {
        public loadBase()
        {
            if (Penalty < 0)
            {
                throw new ArgumentException("Child Load Class was defined with an incorrect Penalty parameter. Penalty must by greater than or equal to zero.");
            }
        }

        public virtual int Penalty { get; }

    }


    public class Swallow
    {
        internal ISwallowInterface Type { get; }
        internal ILoadInterface Load { get; private set; }

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

            Load = (ILoadInterface)Activator.CreateInstance(swallowLoad);

        }

        public double GetAirspeedVelocity()
        {
            return Type.Speed - Load.Penalty;
        }
    }
}
