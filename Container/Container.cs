using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace DeveloperSample.Container
{
    public class Container
    {
        public Type _interface;
        public object _instance = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            _interface = interfaceType;
            _instance = Activator.CreateInstance(implementationType);
        }

        public T Get<T>()
        {
            if (_interface == typeof(T))
            {
                return (T)_instance;
            }
            else
            {
                return default(T);
            }

        }
    }
}