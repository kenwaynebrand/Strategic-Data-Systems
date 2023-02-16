using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace DeveloperSample.Container
{
    public class Container
    {
        public Type _interface;
        public Type _instance;

        public void Bind(Type interfaceType, Type implementationType)
        {
            _interface = interfaceType;
            _instance = implementationType;
        }

        public T Get<T>()
        {
            object res = Activator.CreateInstance(_instance);
            if (_interface == typeof(T))
            {
                return (T)res;
            }
            else
            {
                return default(T);
            }

        }
    }
}
