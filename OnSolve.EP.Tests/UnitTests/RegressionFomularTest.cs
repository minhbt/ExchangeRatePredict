using System;
using System.Collections.Generic;
using FluentAssertions;
using OnSolve.EP.Common.Helpers;
using OnSolve.EP.Models.Business;
using OnSolve.EP.Repositories;
using Xunit;

namespace OnSolve.EP.Tests.UnitTests
{
    public class RegressionFomularTest
    {
        [Fact]
        public void CreateCorrectRegressionEquation()
        {
            IRegressionFomularRepository factory = new RegressionFomularRepository();
            var targetDate = new DateTime(2017, 1, 17);
            var samples = new List<DataPoint2dBO>
            {
                new DataPoint2dBO(1, 3.04359m),
                new DataPoint2dBO(2, 2.945926m),
                new DataPoint2dBO(3, 2.893866m),
                new DataPoint2dBO(4, 2.854589m),
                new DataPoint2dBO(5, 2.970913m),
                new DataPoint2dBO(6, 2.925991m),
                new DataPoint2dBO(7, 2.990882m),
                new DataPoint2dBO(8, 2.944941m),
                new DataPoint2dBO(9, 2.970704m),
                new DataPoint2dBO(10, 3.089218m),
                new DataPoint2dBO(11, 3.284672m),
                new DataPoint2dBO(12, 3.503773m)
            };
            var expectedSlope = 0.035m;
            var expectedIntercept = 2.807m;

            // Actions
            RegressionFomularBO regressioFomular = factory.Create(samples);

            // Asse
            regressioFomular.Should().NotBeNull();
            regressioFomular.Intercept
                .AlmostEquals(expectedIntercept, 3)
                .Should().BeTrue();

            regressioFomular.Slope
                .AlmostEquals(expectedSlope, 3)
                .Should().BeTrue();
        }
    }
}
