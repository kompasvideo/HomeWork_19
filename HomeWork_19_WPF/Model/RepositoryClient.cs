using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    class RepositoryClient
    {
        BankModel context;
        public RepositoryClient()
        {
            context = new BankModel();
        }
        public RepositoryClient(BankModel context)
        {
            this.context = context;
        }
        public void Add(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }
        public void Remove(Client client)
        {
            Client r_client = null;
            foreach (var l_client in context.Clients)
            {
                if (l_client.Id == client.Id)
                    r_client = l_client;
            }
            context.Clients.Remove(r_client);
            context.SaveChanges();
        }
    }
}
