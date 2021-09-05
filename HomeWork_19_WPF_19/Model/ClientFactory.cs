using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    /// <summary>
    /// Класс, создающий экземпляр типа "Client"
    /// </summary>
    static class ClientFactory
    {
        /// <summary>
        /// Созданёт экземпляра типа Client
        /// </summary>
        /// <param name="DepartmentName">Имя департамента</param>
        /// <param name="Name">Имя клиента</param>
        /// <param name="Money">Сумма дипозита</param>
        /// <returns></returns>
        public static Client GetClient(string DepartmentName,
                                        string Name,
                                        int Money)
        {
            switch (DepartmentName)
            {
                case Const.departmentName_personal: 
                    return new Client(Name, Money, 1);
                case Const.departmentName_business: 
                    return new Client(Name, Money, 2);
                case Const.departmentName_VIP: 
                    return new Client(Name, Money, 3);
                default:
                    NullClient nullClient = new NullClient();
                    return nullClient.GetClient();
            }
        }
    }
}
