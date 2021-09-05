using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF.Services
{
    /// <summary>
    /// Типы операций для Клиента 
    /// </summary>
    public enum MessageType
    {
        AddAccount,
        CloseAccount,
        MoveMoney,
        AddDepositNoCapitalize,
        AddDepositCapitalize,
        RateView,
        Save
    }
}
