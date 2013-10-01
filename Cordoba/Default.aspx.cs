using System;
using System.Collections;
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
        private List<ChangeRequest> OngoingCrs { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OngoingCrs = CordobaDocumentStore.Instance.FindOngoingChangeRequests();
            this.OngoingGrid.DataSource = this.OngoingCrs;
            this.OngoingGrid.DataBind();

            this.Status.DataSource = new List<CRStatus> { CRStatus.New, CRStatus.Approved, CRStatus.Denied };
            this.Status.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var cr = new ChangeRequest
            {
                Title = Heading.Text,
                Description = Description.Text,
                Duration = new TimePeriod { StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) },
                Status = Convert(this.Status.SelectedValue)
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

        private CRStatus Convert(string status)
        {
            if (status == CRStatus.New.ToString()) return CRStatus.New;
            if (status == CRStatus.Approved.ToString()) return CRStatus.Approved;
            if (status == CRStatus.Denied.ToString()) return CRStatus.Denied;
            return CRStatus.New;
        }
    }
}