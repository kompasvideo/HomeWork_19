using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model.Deposit
{
    public class ConcreteDeposit
    {
        public static void CreateDeposit(ICreateDeposit Obj, Client client)
        {
            Obj.CreateDeposit(client);
        }
    }
}
