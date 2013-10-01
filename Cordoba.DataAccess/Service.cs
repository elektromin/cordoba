namespace Cordoba.DataAccess
{
    using System.Collections.Generic;

    public class Service
    {
        public string ServiceName { get; set; }

        public string SiteA { get; set; }

        public string SiteZ { get; set; }

        public List<TimePeriod> AffectedDuring { get; set; }
    }
}