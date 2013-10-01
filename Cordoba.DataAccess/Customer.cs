namespace Cordoba.DataAccess
{
    using System.Collections.Generic;

    public class Customer
    {
        public string CustomerNo { get; set; }

        public string CustomerName { get; set; }

        public List<Service> AffectedServices { get; set; }
    }
}