using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }
    internal interface IContainerTestInterface2
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    internal class ContainerTestClass2 : IContainerTestInterface
    {
    }

    internal class ContainerTestClass3 : IContainerTestInterface2
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }


        [Fact]
        public void CanBindMultipleInterfaceAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(IContainerTestInterface2), typeof(ContainerTestClass3));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void CanUpdateBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass2));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass2>(testInstance);
        }
    }
}
