using System;
using Xunit;
using OnSolve.EP.Services;
using System.Linq;
using FluentAssertions;

namespace OnSolve.EP.Tests.UnitTests
{
    public class TimeSeriesTest
    {
        [Fact]
        public void MoveBackwardByMonthShouldCorret()
        {
            // Arrange
            ITimeSeriesService generator = new TimeSeriesService();
            var targetDate = new DateTime(2018, 01, 15);
            var count = 12;
            var includeTargetDate = false;

            // Action
            var series = generator.MoveBackwardByMonth(targetDate, count, includeTargetDate);

            // Assertions
            var list = series.ToList();
            list.Count.Should().Be(count);
            for (int i = 0; i < count - 1; i += 2)
            {
                list[i].AddMonths(-1).Ticks.Should().Be(list[i + 1].Ticks);
            }
        }

        [Fact]
        public void MoveBackwardByMonthShouldCorret2()
        {
            // Arrange
            var generator = new TimeSeriesService();
            var targetDate = new DateTime(2018, 01, 15);
            var count = 12;
            var includeTargetDate = true;

            // Action
            var series = generator.MoveBackwardByMonth(targetDate, count, includeTargetDate);

            // Assertions
            var list = series.ToList();
            list.Count.Should().Be(count + 1);
            for (int i = 0; i < list.Count - 1; i += 2)
            {
                list[i].AddMonths(-1).Ticks.Should().Be(list[i + 1].Ticks);
            }
        }
    }
}
