using System;
using System.Collections.Generic;
using Xunit;
using Statistics;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void ReportsAverageMinMax()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float>{1.5F, 8.9F, 3.2F, 4.5F});
            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }

        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float>{});
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1

            Assert.True(float.IsNaN(computedStats.max));
            Assert.True(float.IsNaN(computedStats.min));
            Assert.True(float.IsNaN(computedStats.average));
        }

        [Fact]
        public void ReportsNaNForMoreThanOneNaNValue()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float> {2.8F, float.NaN, 5.96F, 6.14F, 9.6F, float.NaN, float.NaN, 4.123F});

            float epsilon = 0.001F;

            Assert.True(Math.Abs(computedStats.average - 5.7246) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 9.6) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 2.8) <= epsilon);

        }
    }
}
