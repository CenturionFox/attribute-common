using System;
using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Common.Enumeration
{
    public enum TimeUnit
    {
        [DisplayValue("Tick"), DataValue("0.0000001")]
        Tick = -2,
        [DisplayValue("Millisecond"), DataValue("0.001")]
        Millisecond = -1,
        [DisplayValue("Second"), DataValue("1")]
        Second = 0,
        [DisplayValue("Minute"), DataValue("60")]
        Minute = 1,
        [DisplayValue("Hour"), DataValue("3600")]
        Hour = 2,
        [DisplayValue("Day"), DataValue("86400")]
        Day = 3
    }

    public static class TimeUnitExtensions
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        public static double GetMilliseconds(this TimeUnit timeUnit)
        {
            switch (timeUnit)
            {
                case TimeUnit.Day:
                    return TimeSpan.FromDays(1).TotalMilliseconds;
                case TimeUnit.Hour:
                    return TimeSpan.FromHours(1).TotalMilliseconds;
                case TimeUnit.Minute:
                    return TimeSpan.FromMinutes(1).TotalMilliseconds;
                case TimeUnit.Second:
                    return TimeSpan.FromSeconds(1).TotalMilliseconds;
                case TimeUnit.Tick:
                    return TimeSpan.FromTicks(1).TotalMilliseconds;
                default:
                    return 1;
            }
        }

        #endregion
    }
}
