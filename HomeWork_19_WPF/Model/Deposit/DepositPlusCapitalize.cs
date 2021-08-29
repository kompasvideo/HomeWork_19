using HomeWork_19_WPF.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model.Deposit
{
    public class DepositPlusCapitalize : ICreateDeposit
    {
        /// <summary>
        /// Клиент
        /// </summary>
        Client selectedClient;
        public DepositPlusCapitalize(Client client)
        {
            selectedClient = client;
        }
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
            selectedClient.Deposit = 2;
            selectedClient.Days = client.Days;
            selectedClient.Rate = client.Rate;
            contextLocal.SaveChanges();
            Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.AddDepositCapitalize, $"Открыт вклад c капитализацией % для '{selectedClient.Name}'"));
        }
    }
}
