using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    /// <summary>
    /// Хранит context таблицы Clients из EF
    /// </summary>
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

        /// <summary>
        /// Добавление нового экземпляра в таблицу Clients EF
        /// </summary>
        /// <param name="client">экземляр типа Client</param>
        public void Add(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }
        /// <summary>
        /// Удаление экземпляра типа Client из таблицы Clients EF
        /// </summary>
        /// <param name="client"></param>
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
