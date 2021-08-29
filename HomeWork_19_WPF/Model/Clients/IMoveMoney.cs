using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Model
{
    public interface IMoveMoney
    {
        bool MoveMoney(Dictionary<Client, int> client);
    }
}
