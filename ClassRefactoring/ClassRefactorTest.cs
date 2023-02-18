using System;
using Xunit;

namespace DeveloperSample.ClassRefactoring
{


    internal class AfricanSwallow : ISwallowInterface
    {
        public int getUnladenSpeed() { return 22; }
    }

    internal class EuropeanSwallow : ISwallowInterface
    {
        public int getUnladenSpeed() { return 20; }
    }

    internal class CoconutLoad : ILoadInterface
    {
        public int getLadingPenalty() { return 4; }
    }

    internal class NoLoad : ILoadInterface
    {
        public int getLadingPenalty() { return 0; }
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
    }
}
