using System;
using System.Diagnostics;
using MontyHall.Services;
using Xunit;
using Xunit.Abstractions;

namespace MontyHall.Tests
{
    public class SimulationServiceTests
    {
        private readonly ITestOutputHelper testOutputHelper_;
        private readonly ISimulationService simulationService_;

        public SimulationServiceTests(
            ITestOutputHelper testOutputHelper)
        {
            testOutputHelper_ = testOutputHelper;
            simulationService_ = new SimulationService();
        }

        [Fact]
        public void ChangeStrategyTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var result = simulationService_.Simulate(1000000000, true);
            Assert.Equal(67, Math.Round(result * 100));

            sw.Stop();
            testOutputHelper_.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        [Fact]
        public void NotChangeStrategyTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var result = simulationService_.Simulate(1000000000, false);
            Assert.Equal(33, Math.Round(result * 100));

            sw.Stop();
            testOutputHelper_.WriteLine("Elapsed={0}", sw.Elapsed);
        }
    }
}