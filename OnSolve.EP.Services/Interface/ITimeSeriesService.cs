using System;
using System.Collections.Generic;

namespace OnSolve.EP.Services
{
    public interface ITimeSeriesService
    {
        IEnumerable<DateTime> MoveBackwardByMonth(DateTime targetDate, int count, bool includeTargetDate);
    }
}
