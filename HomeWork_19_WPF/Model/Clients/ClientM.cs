using HomeWork_19_WPF.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork_19_WPF.Model.Clients
{
    public class ClientM : ICreateClient, IRemoveClient, IMoveMoney
    {
        /// <summary>
        /// Клиент
        /// </summary>
        Client client;

        /// <summary>
        /// Удаление клиента из БД
        /// </summary>
        /// <returns></returns>
        public bool RemoveClient()
        {
            if (MessageBox.Show($"Закрыть счёт для   '{client.Name}'", "Закрыть счёт", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return false;
            string SelectedClientName = client.Name;
            int SelectedClientMoney = client.Money;
            BankModel contextLocal = new BankModel();
            contextLocal.Clients.Load();
            foreach (var l_client in contextLocal.Clients)
            {
                if (l_client.Id == client.Id)
                    client = l_client;
            }
            contextLocal.Clients.Remove(client);
            contextLocal.SaveChanges();
            Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.CloseAccount, $"Закрыт счёт для '{SelectedClientName}' на сумму '{SelectedClientMoney}'"));
            return true;
        }

        /// <summary>
        /// Создание клиента в БД
        /// </summary>
        public void CreateClient()
        {
            BankModel contextLocal = new BankModel();
            contextLocal.Clients.Load();
            contextLocal.Clients.Add(client);
            contextLocal.SaveChanges();
            Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.AddAccount, $"Открыт счёт для '{client.Name}' на сумму '{client.Money}'"));
        }

        /// <summary>
        /// Перевод денег клинта другому клиенту
        /// </summary>
        /// <param name="l_client"></param>
        /// <returns></returns>
        public bool MoveMoney(Dictionary<Client, int> l_client)
        {
            int moveMoney = 0;
            Client moveClient = null;
            foreach (KeyValuePair<Client, int> kvp in l_client)
            {
                moveClient = kvp.Key;
                moveMoney = kvp.Value;
                break;
            }
            if (client.Money >= moveMoney)
            {
                int moveClientMoney = moveMoney;
                string SelectedClientName = client.Name;
                string moveClientName = moveClient.Name;

                BankModel contextLocal = new BankModel();
                contextLocal.Clients.Load();
                foreach (var clientL in contextLocal.Clients)
                {
                    if (clientL.Id == client.Id)
                        client = clientL;
                    if (clientL.Id == moveClient.Id)
                        moveClient = clientL;
                }
                client.Money -= moveMoney;
                moveClient.Money += moveMoney;
                contextLocal.SaveChanges();
                Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.MoveMoney, $"Переведена сумма '{moveClientMoney}' с счёта '{SelectedClientName}' на счёт '{moveClientName}'"));
                return true;
            }
            return false;
        }

        public ClientM(Client client)
        {
            this.client = client;
        }
    }
}
