using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace HomeWork_19_WPF.ViewModel
{
    class AddDepositNoCapitalizeViewModel : ViewModelBase
    {
        public static double InterestRate { get; set; }

        public AddDepositNoCapitalizeViewModel()
        {            
        }
        /// <summary>
        /// Принимает аргумент BankDepartment pBankDepartment
        /// </summary>
        /// <param name="pBankDepartment"></param>
        public static void SetBankDepartment(Dictionary<int, int> pBankDepartment)
        {
            foreach (KeyValuePair<int, int> kvp in pBankDepartment)
            {               
                switch (kvp.Key)
                {
                    case 1:
                        InterestRate = 10;
                        break;
                    case 2:
                        InterestRate = 20;
                        break;
                    case 3:
                        InterestRate = 30;
                        break;
                }
            }
        }
        /// <summary>
        /// Нажата кнопка "Ок"
        /// </summary>
        public ICommand bOK_Click
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Client client = new Client();
                    Dictionary<uint, Client> bd = new Dictionary<uint, Client>();
                    bd.Add(0, client);
                    client.Rate = InterestRate;
                    client.DateOpen = DateTime.Now;
                    client.Days = 365;
                    Messenger.Default.Send(bd);

                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                        {
                            if (window.Title == "Открыть вклад без капитализации %")
                            {
                                window.Close();
                            }
                        }
                    
                });
            }
        }

        /// <summary>
        /// Нажата кнопка "Отмена"
        /// </summary>
        public ICommand bCancel_Click
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.Title == "Открыть вклад без капитализации %")
                        {
                            window.Close();
                        }
                    }
                });
            }
        }
    }
}
