﻿using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HomeWork_19_WPF.ViewModel
{
    class AddDepositCapitalizeViewModel : ViewModelBase
    {
        /// <summary>
        /// Процентная ставка
        /// </summary>
        public static double InterestRate { get; set; }

        public AddDepositCapitalizeViewModel()
        {            
        }
        /// <summary>
        /// Принимает аргумент BankDepartment pBankDepartment
        /// </summary>
        /// <param name="pBankDepartment"></param>
        public static void SetBankDepartment(int pBankDepartment)
        {
            InterestRate  = Getrate(pBankDepartment);

            int Getrate(int pBankDepartment) => pBankDepartment switch
            {
                1 => 12,
                2 => 24,
                3 => 36,
            };
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
                    Dictionary<double, Client> bd = new Dictionary<double, Client>();
                    Client client = new Client();
                    bd.Add(0, client);
                    client.Rate = InterestRate;
                    client.DateOpen = DateTime.Now;
                    client.Days = 365;
                    Messenger.Default.Send(bd);

                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.Title == "Открыть вклад с капитализацией %")
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
                        if (window.Title == "Открыть вклад с капитализацией %")
                        {
                            window.Close();
                        }
                    }
                });
            }
        }
    }
}
