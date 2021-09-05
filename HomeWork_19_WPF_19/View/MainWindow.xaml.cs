using HomeWork_19_WPF.Services;
using HomeWork_19_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HomeWork_19_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Подписывается на сообщение ReturnAddClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register <Client>(MainViewModel.ReturnAddClient);
            Messenger.Default.Register<Dictionary<Client, int>>(MainViewModel.ReturnMoveMoney);
            Messenger.Default.Register<Dictionary<uint, Client>>(MainViewModel.ReturnAddDepositNoCapitalize);
            Messenger.Default.Register<Dictionary<double, Client>>(MainViewModel.ReturnAddDepositCapitalize);
            Messenger.Default.Register<int>(AddDepositCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Register<Dictionary<int, int>>(AddDepositNoCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Register<Dictionary<Client, short>>(RateViewModel.SetClient);
        }

        /// <summary>
        /// Отписывается от сообщение ReturnAddClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<Client>(MainViewModel.ReturnAddClient);
            Messenger.Default.Unregister<Dictionary<Client, int>>(MainViewModel.ReturnMoveMoney);
            Messenger.Default.Unregister<Dictionary<uint, Client>>(MainViewModel.ReturnAddDepositNoCapitalize);
            Messenger.Default.Unregister<Dictionary<double, Client>>(MainViewModel.ReturnAddDepositCapitalize);
            Messenger.Default.Unregister<int>(AddDepositCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Unregister<Dictionary<int, int>>(AddDepositNoCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Unregister<Dictionary<Client, short>>(RateViewModel.SetClient);
        }

        /// <summary>
        /// Событие - Закрытие окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Messenger.Default.Send(new MessageParam(DateTime.Now, MessageType.Save, $"Закрытие"));
        }
    }
}
