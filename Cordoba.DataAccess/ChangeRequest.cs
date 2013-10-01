namespace Cordoba.DataAccess
{
    using System.Collections.Generic;

    public class ChangeRequest
    {
        public ChangeRequest() { 
            Status = CRStatus.New; 
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CRStatus Status { get; set; }

        public TimePeriod Duration { get; set; }

        public List<Customer> AffectedCustomers { get; set; }
    }
}