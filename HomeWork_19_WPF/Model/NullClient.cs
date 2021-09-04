using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    /// <summary>
    /// Класс типа Null при ошибке создания экземпляра типа Client
    /// </summary>
    class NullClient
    {
        Client client;
        public NullClient()
        {
            client = new Client("Not Determined", 0, 0);
        }
        /// <summary>
        /// Получить экземляр типа Client
        /// </summary>
        /// <returns>экземляр типа Client</returns>
        public Client GetClient()
        {
            return client;
        }
    }
}
