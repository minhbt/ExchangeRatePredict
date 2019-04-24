using System;
using System.Collections.Generic;

namespace OnSolve.EP.Services
{
    public class TimeSeriesService:ITimeSeriesService
    {
       
        public IEnumerable<DateTime> MoveBackwardByMonth(DateTime targetDate, int count, bool includeTargetDate)
        {
            var startPoint = includeTargetDate ? 0 : 1;
            for (int i = startPoint; i <= count; i++)
            {
                yield return targetDate.AddMonths(-i);
            }
        }
    }
}
