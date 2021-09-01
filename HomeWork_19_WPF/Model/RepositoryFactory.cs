using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    class RepositoryFactory
    {
        static Random r;
        static RepositoryFactory() { r = new Random(); }

        public static RepositoryClient GetRepository(int Count)
        {

            BankModel context = new BankModel();
            for (int i = 0; i < 10; i++)
            {
                switch (r.Next(3))
                {
                    case 1:                        
                        context.Clients.Add(new Client($"Физ. лицо - {Guid.NewGuid().ToString().Substring(0, 5)}", (int)r.Next(10, 1001), 1)); 
                        break;
                    case 2:
                        context.Clients.Add(new Client($"Юр. лицо - {Guid.NewGuid().ToString().Substring(0, 5)}", (int)r.Next(10, 1001), 2));
                        break;
                    default:
                        context.Clients.Add(new Client($"VIP - {Guid.NewGuid().ToString().Substring(0, 5)}", (int)r.Next(10, 1001), 3));
                        break;
                }
            }
            context.SaveChanges();
            return new RepositoryClient(context);
        }
    }
}
