using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cordoba.DataAccess;

namespace Cordoba
{
    public partial class _Default : Page
    {
        private List<ChangeRequest> OngoingCrs;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OngoingCrs = CordobaDocumentStore.Instance.FindOngoingChangeRequests();
            this.OngoingGrid.DataSource = this.OngoingCrs;
            this.OngoingGrid.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var cr = new ChangeRequest
            {
                Title = Heading.Text,
                Description = Description.Text,
                Duration = new TimePeriod { StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) }
            };

            if (this.CustomerName.Text != "") 
            {
                cr.AffectedCustomers = new List<Customer> 
                { 
                    new Customer {
                        CustomerName = this.CustomerName.Text
                    }
                };

                if (this.CustomerService.Text != "") {
                    cr.AffectedCustomers.First().AffectedServices = new List<Service>  {
                        new Service{
                            ServiceName = this.CustomerService.Text
                        }
                    };
                }
            };

            var id = CordobaDocumentStore.Instance.Create(cr);
            this.CreateResult.Text = "Skapat ärende: " + id;
            this.OngoingCrs.Add(cr);
            this.OngoingGrid.DataBind();
        }
    }
}