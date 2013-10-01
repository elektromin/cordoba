using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordoba.DataAccess
{
    using Raven.Client.Document;

    public class CordobaDocumentStore
    {
        public static CordobaDocumentStore Instance = new CordobaDocumentStore();

        private DocumentStore documentStore;

        public CordobaDocumentStore()
        {
            this.documentStore = new DocumentStore { Url = "http://localhost:8080/", DefaultDatabase = "Cordoba" };
            this.documentStore.Initialize();
        }

        public string Create(ChangeRequest cr)
        {
            using (var session = this.documentStore.OpenSession())
            {
                session.Store(cr);
                session.SaveChanges();
                return cr.Id;
            }
        }

        public List<ChangeRequest> FindOngoingChangeRequests()
        {
            using (var session = this.documentStore.OpenSession())
            {
                return session.Query<ChangeRequest>().Where(
                    cr => cr.Status == CRStatus.Approved && cr.Duration.StartTime <= DateTime.Now && DateTime.Now <= cr.Duration.EndTime).
                    ToList();
            }
        }
    }
}
