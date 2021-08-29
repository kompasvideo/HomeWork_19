using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model.Clients
{
    public class ConcreteClient
    {
        public static void CreateClient(ICreateClient Obj)
        {
            Obj.CreateClient();
        }
        public static bool RemoveClient(IRemoveClient Obj)
        {
            return Obj.RemoveClient();
        }
        public static bool MoveMoney(IMoveMoney Obj, Dictionary<Client, int> client)
        {
            return Obj.MoveMoney(client);
        }
    }
}
