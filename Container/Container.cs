using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> TypesLookup  = new();
        public void Bind(Type interfaceType, Type implementationType)
        {
            if (TypesLookup.ContainsKey(interfaceType)) // verify the interface hasn't been added
            {
               TypesLookup.TryGetValue(interfaceType, out Type existingImplementationType);
                if (implementationType != existingImplementationType) // existing interface, verify it need to be updated
                {
                    TypesLookup.Remove(interfaceType);
                    TypesLookup.Add(interfaceType, implementationType);
                }
            }
            else // new interface, add it to the container
            {
                TypesLookup.Add(interfaceType, implementationType);
            }
        }

        public T Get<T>()
        {
            TypesLookup.TryGetValue(typeof(T), out Type newImplementation);
            object res = Activator.CreateInstance(newImplementation);
            return (T)res;
        }
    }
}
