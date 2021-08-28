﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using HomeWork_19_WPF.Model;

namespace HomeWork_19_WPF.ViewModel
{
    class AddDepositNoCapitalizeViewModel : ViewModelBase
    {
        public static DepositC DepositV { get; set; }
        static BankDepartment bankDepartment;

        public AddDepositNoCapitalizeViewModel()
        {            
        }
        /// <summary>
        /// Принимает аргумент BankDepartment pBankDepartment
        /// </summary>
        /// <param name="pBankDepartment"></param>
        public static void SetBankDepartment(Dictionary<BankDepartment, uint> pBankDepartment)
        {
            DepositV = new DepositC();

            foreach (KeyValuePair<BankDepartment, uint> kvp in pBankDepartment)
            {
                bankDepartment = kvp.Key;
                switch (bankDepartment)
                {
                    case BankDepartment.BusinessDepartment:
                        DepositV.InterestRate = 10;
                        break;
                    case BankDepartment.PersonalDepartment:
                        DepositV.InterestRate = 20;
                        break;
                    case BankDepartment.VIPDepartment:
                        DepositV.InterestRate = 30;
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
                    Messenger.Default.Send(DepositV);

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
