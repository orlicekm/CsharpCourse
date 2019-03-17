using System;
using System.Collections.Generic;
using Xunit;

namespace XUnit.Tests
{
    public class StackTests : IDisposable
    {
        public StackTests()
        {
            stackSUT = new Stack<int>();
        }

        public void Dispose()
        {
            //stackSUT.Dispose();
        }

        private readonly Stack<int> stackSUT;

        [Fact]
        public void AfterPushingItem_CountShouldReturnOne()
        {
            stackSUT.Push(42);

            var count = stackSUT.Count;

            Assert.Equal(1, count);
        }

        [Fact]
        public void WithNoItems_CountShouldReturnZero()
        {
            var count = stackSUT.Count;

            Assert.Equal(0, count);
        }
    }
}