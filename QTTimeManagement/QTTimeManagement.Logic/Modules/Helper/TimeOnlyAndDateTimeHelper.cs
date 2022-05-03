using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Modules.Helper
{
    public static class TimeOnlyAndDateTimeHelper
    {
        public static TimeOnly ToTimeOnly (DateTime? dateTime)
        {
            return TimeOnly.FromDateTime (dateTime ?? new DateTime(1990, 1, 1, 0, 0, 0, 0));
        }

        public static DateTime ToDateTime (TimeOnly? timeOnly)
        {
            return timeOnly != null ? new DateTime(1990, 1, 1, timeOnly.Value.Hour, timeOnly.Value.Minute, timeOnly.Value.Second, timeOnly.Value.Millisecond) : 
                                      new DateTime(1990, 1, 1, 0, 0, 0, 0);
                                        
        }

        //public static DateTime DefaultDate()
        //{
        //    return new DateTime(1990, 1, 1, 0, 0, 0, 0); 
        //}
    }
}
