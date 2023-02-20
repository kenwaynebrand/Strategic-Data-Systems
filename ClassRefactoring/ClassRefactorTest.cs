using System;
using Xunit;

namespace DeveloperSample.ClassRefactoring
{


    internal class AfricanSwallow : swallowBase
    {
        public override int Speed { get { return 22; } }
    }

    internal class EuropeanSwallow : swallowBase
    {
        public override int Speed { get { return 20; } }
    }

    internal class LighterThanAirSwallow : swallowBase
    {
        public override int Speed { get { return -10; } }
    }

    internal class WeightlessSwallow : swallowBase
    {
        public override int Speed { get { return 0; } }
    }
    internal class CoconutLoad : loadBase
    {
        public override int Penalty { get { return 4; } }
    }

    internal class NoLoad : loadBase
    {
        public override int Penalty { get { return 0; } }
    }

    internal class LighterThanAirLoad : loadBase
    {
        public override int Penalty { get { return -5; } }
    }

    public class ClassRefactorTest
    {

        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            AfricanSwallow swallow = new();
            NoLoad load = new();
            var Swallow = new Swallow(swallow, load);
            Assert.Equal(22, Swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            AfricanSwallow swallow = new();
            CoconutLoad load = new();
            var Swallow = new Swallow(swallow, load);
            Assert.Equal(18, Swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            EuropeanSwallow swallow = new();
            NoLoad load = new();
            var Swallow = new Swallow(swallow, load);
            Assert.Equal(20, Swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            EuropeanSwallow swallow = new();
            CoconutLoad load = new();
            var Swallow = new Swallow(swallow, load);
            Assert.Equal(16, Swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void BadSwallowSpeedZeroType()
        {
            Assert.Throws<ArgumentException>(() => new WeightlessSwallow());
        }

        [Fact]
        public void BadSwallowSpeedNegativeType()
        {
            Assert.Throws<ArgumentException>(() => new LighterThanAirSwallow());
        }

        [Fact]
        public void BadSwallowLoadType()
        {
            Assert.Throws<ArgumentException>(() => new LighterThanAirLoad());
        }
    }
}
