using System;
using Xunit;

namespace DeveloperSample.ClassRefactoring
{


    internal class AfricanSwallow : ISwallowInterface
    {
        public int Speed { get { return 22; } }
    }

    internal class EuropeanSwallow : ISwallowInterface
    {
        public int Speed { get { return 20; } }
    }

    internal class LighterThanAirSwallow : ISwallowInterface
    {
        public int Speed { get { return -10; } }
    }

    internal class WeightlessSwallow : ISwallowInterface
    {
        public int Speed { get { return 0; } }
    }
    internal class CoconutLoad : ILoadInterface
    {
        public int Penalty { get { return 4; } }
    }

    internal class NoLoad : ILoadInterface
    {
        public int Penalty { get { return 0; } }
    }

    internal class LighterThanAirLoad : ILoadInterface
    {
        public int Penalty { get { return -5; } }
    }

    public class ClassRefactorTest
    {

        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            var swallow = new Swallow(typeof(AfricanSwallow), typeof(NoLoad));
            Assert.Equal(22, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            var swallow = new Swallow(typeof(AfricanSwallow), typeof(CoconutLoad));
            Assert.Equal(18, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            var swallow = new Swallow(typeof(EuropeanSwallow), typeof(NoLoad));
            Assert.Equal(20, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            var swallow = new Swallow(typeof(EuropeanSwallow), typeof(CoconutLoad));
            Assert.Equal(16, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void WrongSwallowType()
        {
            Assert.Throws<ArgumentException>(() => new Swallow(typeof(CoconutLoad), typeof(CoconutLoad)));
        }

        [Fact]
        public void WrongLoadType()
        {
            Assert.Throws<ArgumentException>(() =>  new Swallow(typeof(EuropeanSwallow), typeof(EuropeanSwallow)));
        }

        [Fact]
        public void BadSwallowSpeedZeroType()
        {
            Assert.Throws<ArgumentException>(() => new Swallow(typeof(WeightlessSwallow), typeof(CoconutLoad)));
        }

        [Fact]
        public void BadSwallowSpeedNegativeType()
        {
            Assert.Throws<ArgumentException>(() => new Swallow(typeof(LighterThanAirSwallow), typeof(CoconutLoad)));
        }

        [Fact]
        public void BadSwallowLoadType()
        {
            Assert.Throws<ArgumentException>(() => new Swallow(typeof(EuropeanSwallow), typeof(LighterThanAirLoad)));
        }
    }
}
