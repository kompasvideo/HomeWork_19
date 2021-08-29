using HomeWork_19_WPF.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model.Deposit
{
    public class DepositNoCapitalize : ICreateDeposit
    {
        /// <summary>
        /// Клиент
        /// </summary>
        Client selectedClient;

        public DepositNoCapitalize(Client client)
        {
            selectedClient = client;
        }

        /// <summary>
        /// Открыть вклад без капитализации %
        /// </summary>
        /// <param name="deposit"></param>
        public void CreateDeposit(Client client)
        {            
            BankModel contextLocal = new BankModel();
            contextLocal.Clients.Load();
            foreach (var clientL in contextLocal.Clients)
            {
                if (clientL.Id == selectedClient.Id)
                {
                    selectedClient = clientL;
                    break;
                }
            }
            selectedClient.DateOpen = client.DateOpen;
            selectedClient.Deposit = 1;
            selectedClient.Days = client.Days;
            selectedClient.Rate = client.Rate;
            contextLocal.SaveChanges();
            Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.AddDepositNoCapitalize, $"Открыт вклад без капитализации % для '{selectedClient.Name}'"));

        }
    }
}
