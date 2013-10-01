namespace Cordoba.DataAccess
{
    using System;

    public class TimePeriod
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// Returns true if the given DateTime is larger than the StartTime and less than the EndTime
        /// </summary>
        internal bool Between(DateTime dateTime)
        {
            return this.StartTime <= dateTime && dateTime <= this.EndTime;
        }
    }
}