using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void CanGetFactorialZero()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void CanGetNegativeFactorial()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(-1));
        }

        [Fact]
        public void CanHandleFactorialOverflow()
        {
            Assert.Throws<OverflowException>(() => Algorithms.GetFactorial(15));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        [Fact]
        public void CanFormatSeparatorsTwoItems()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }

        [Fact]
        public void CanFormatSeparatorsOneItem()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void CanFormatSeparatorsNoItem()
        {
            Assert.Equal("", Algorithms.FormatSeparators(""));
        }


        [Fact]
        public void CanFormatSeparatorsNullItem()
        {
            Assert.Throws<ArgumentNullException>(() => Algorithms.FormatSeparators(null));
        }
    }
}
