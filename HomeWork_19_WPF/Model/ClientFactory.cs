using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    static class ClientFactory
    {
        public static Client GetWorker(string TypeClient,
                                        string Name,
                                        int Money,
                                        int Department)
        {
            switch (TypeClient)
            {
                case "Физ. лицо": 
                    return new Client(Name, Money, 1);
                case "Юр. лицо": 
                    return new Client(Name, Money, 2);
                case "VIP": 
                    return new Client(Name, Money, 3);
                default:
                    NullClient nullClient = new NullClient();
                    return nullClient.GetClient();
            }
        }
    }
}
