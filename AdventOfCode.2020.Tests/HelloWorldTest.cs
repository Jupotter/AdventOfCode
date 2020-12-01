using System;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class HelloWorld
    {
        [Fact]
        public void HelloWorldTest()
        {
            Assert.Equal("Hello World", Program.Hello());
        }
    }
}
