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
                                        int Money) => DepartmentName switch
        {
            Const.departmentName_personal => new Client(Name, Money, 1),
            Const.departmentName_business => new Client(Name, Money, 2),
            Const.departmentName_VIP => new Client(Name, Money, 3),
            _ => new NullClient().GetClient(),            
        };
    }
}
