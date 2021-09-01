using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    class NullClient
    {
        Client client;
        public NullClient()
        {
            client = new Client("Not Determined", 0, 0);
        }
        public Client GetClient()
        {
            return client;
        }
    }
}
