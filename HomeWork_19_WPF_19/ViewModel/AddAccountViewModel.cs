using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;

namespace HomeWork_19_WPF.ViewModel
{
    class AddAccountViewModel : ViewModelBase
    {
        /// <summary>
        /// Выбранный департамент в списке
        /// </summary>
        public static string SelectedDep { get; set; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Сумма на счёте
        /// </summary>
        public int Money { get; set; }
        public AddAccountViewModel()
        {
        }
        public AddAccountViewModel(string Name, int Money)
        {
            this.Name = Name;
            this.Money = Money;
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

                    Client client;
                    switch (SelectedDep)
                    {
                        case Const.departmentName_personal:
                            client = new Client();
                            client.Name = Name;
                            client.Money = Money;
                            client.Department = 1;
                            Messenger.Default.Send(client);
                            break;
                        case Const.departmentName_business:
                            client = new Client();
                            client.Name = Name;
                            client.Money = Money;
                            client.Department = 2;
                            Messenger.Default.Send(client);
                            break;
                        case Const.departmentName_VIP:
                            client = new Client();
                            client.Name = Name;
                            client.Money = Money;
                            client.Department = 3;
                            Messenger.Default.Send(client);
                            break;
                        default:
                            break;
                    }
                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.Title == "Открыть счёт")
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
                        if (window.Title == "Открыть счёт")
                        {
                            window.Close();
                        }
                    }
                });
            }
        }
    }
}
