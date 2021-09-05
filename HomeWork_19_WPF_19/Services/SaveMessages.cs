using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace HomeWork_19_WPF.Services
{
    /// <summary>
    /// Класс - загружает или сохраняет 1_000_000 сообщений
    /// </summary>
    class SaveMessages
    {
        const int kol = 1_000_000;
        static List<MessageParam> messageParams = new List<MessageParam>(10_000_000);

        /// <summary>
        /// Подготавливает 10 000 000 сообщений для записи
        /// </summary>
        public static void Save()
        {
            Random rnd = new Random();
            /// Создаём массив клиентов
            List<Client> Clients = new List<Client>(kol);
            for (int i = 0; i < kol; i++)
            {
                Clients.Add(new Client());
            }
            int count = 0;
            string clientName = "";
            int clientType;
            int clientID =0;
            int clientMoney;
            int select;
            string moveClientName = "";
            try
            {
                while (clientID < 1_000_000)
                {
                    clientType = rnd.Next(1, 4);
                    Clients[clientID].Department = clientType;
                    switch (clientType)
                    {
                        case 1:
                            Clients[clientID].Name = $"Физ. лицо - {Guid.NewGuid().ToString().Substring(0, 5)}";
                            break;
                        case 2:
                            Clients[clientID].Name = $"Юр. лицо - {Guid.NewGuid().ToString().Substring(0, 5)}";
                            break;
                        case 3:
                            Clients[clientID].Name = $"VIP - {Guid.NewGuid().ToString().Substring(0, 5)}";
                            break;
                    }
                    Clients[clientID].Money = (int)rnd.Next(10, 1001);
                    clientID++;
                }
                while (count < 10_000_000)
                {
                    select = rnd.Next(0, 6);
                    clientID = rnd.Next(0, kol);
                    switch (select)
                    {
                        case 0:
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.AddAccount, $"Открыт счёт для '{Clients[clientID].Name}' на сумму '{Clients[clientID].Money}'"));
                            count++;
                            break;
                        case 1:
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.CloseAccount, $"Закрыт счёт для '{Clients[clientID].Name}' на сумму '{Clients[clientID].Money}'"));
                            count++;
                            break;
                        case 2:
                            clientType = rnd.Next(0, 3);
                            clientMoney = (int)rnd.Next(10, 1001);
                            switch (clientType)
                            {
                                case 0:
                                    moveClientName = Clients[rnd.Next(0, kol)].Name;
                                    break;
                                case 1:
                                    moveClientName = Clients[rnd.Next(0, kol)].Name;
                                    break;
                                case 2:
                                    moveClientName = Clients[rnd.Next(0, kol)].Name;
                                    break;
                            }
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.MoveMoney, $"Переведена сумма '{clientMoney}' с счёта '{Clients[clientID].Name}' на счёт '{moveClientName}'"));
                            count++;
                            break;
                        case 3:
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.AddDepositNoCapitalize, $"Открыт вклад без капитализации % для '{clientName}'"));
                            count++;
                            break;
                        case 4:
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.AddDepositCapitalize, $"Открыт вклад c капитализацией % для '{clientName}'"));
                            count++;
                            break;
                        case 5:
                            messageParams.Add(new MessageParam(DateTime.Now, MessageType.RateView, $"Показано окно с расчётом % для '{clientName}'"));
                            count++;
                            break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("ArgumentOutOfRangeException", "Создать Log");
            }
            catch(OutOfMemoryException)
            {
                MessageBox.Show("OutOfMemoryException", "Создать Log");
            }
            SerializeMessageList(messageParams, "_listMessage_10_000_000.xml");
        }

        /// <summary>
        /// Сериализует на диск List сообщений
        /// </summary>
        /// <param name="messageParams"></param>
        /// <param name="path"></param>
        private static void SerializeMessageList(List<MessageParam> messageParams, string path)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MessageParam>));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, messageParams);

            // Закрываем поток
            fStream.Close();
        }

        /// <summary>
        /// Подготавливает 10 000 000 сообщений для загрузки
        /// </summary>
        public static async Task Load()
        {
            await Task.Run(() =>
            {
                messageParams.Clear();
                messageParams = DeserializeMessageList("_listMessage_10_000_000.xml");
                messageParams.Clear();
            });
        }

        /// <summary>
        /// Десериализует с диска List сообщений
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static List<MessageParam> DeserializeMessageList(string path)
        {
            List<MessageParam> tempWorkerCol = new List<MessageParam>();
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MessageParam>));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            tempWorkerCol = xmlSerializer.Deserialize(fStream) as List<MessageParam>;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempWorkerCol;
        }
    }
}
