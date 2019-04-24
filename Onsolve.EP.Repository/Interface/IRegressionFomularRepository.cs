using System;
using System.Collections.Generic;
using OnSolve.EP.Models.Business;
namespace OnSolve.EP.Repositories
{
    public interface IRegressionFomularRepository
    {
        RegressionFomularBO Create(List<DataPoint2dBO> samples);
    }
}
