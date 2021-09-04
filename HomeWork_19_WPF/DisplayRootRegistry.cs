using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork_19_WPF
{
    /// <summary>
    /// Класс для привязки ViewModel к wpf-окну (xaml)
    /// </summary>
    public class DisplayRootRegistry
    {
        Dictionary<Type, Type> vmToWindowMapping = new Dictionary<Type, Type>();

        /// <summary>
        /// Регистрирует ViewModel и класс wpf-окна
        /// </summary>
        /// <typeparam name="VM"></typeparam>
        /// <typeparam name="Win"></typeparam>
        public void RegisterWindowType<VM, Win>() where Win : Window, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Не зарегистрирован интерфейс");
            if (vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Тип {vmType.FullName} зарегистрирован");
            vmToWindowMapping[vmType] = typeof(Win);
        }

        #region Не используется
        //public void UnregisterWindowType<VM>()
        //{
        //    var vmType = typeof(VM);
        //    if (vmType.IsInterface)
        //        throw new ArgumentException("Не зарегистрирован интерфейс");
        //    if (!vmToWindowMapping.ContainsKey(vmType))
        //        throw new InvalidOperationException(
        //            $"Тип {vmType.FullName} зарегистрирован");
        //    vmToWindowMapping.Remove(vmType);
        //}
        #endregion

        public Window CreateWindowInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type windowType = null;

            var vmType = vm.GetType();
            while (vmType != null && !vmToWindowMapping.TryGetValue(vmType, out windowType))
                vmType = vmType.BaseType;

            if (windowType == null)
                throw new ArgumentException(
                    $"Нет зарегистрированного типа окна для типа аргумента {vm.GetType().FullName}");

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;
            return window;
        }

        #region Не используется
        //Dictionary<object, Window> openWindows = new Dictionary<object, Window>();
        //public void ShowPresentation(object vm)
        //{
        //    if (vm == null)
        //        throw new ArgumentNullException("vm");
        //    if (openWindows.ContainsKey(vm))
        //        throw new InvalidOperationException("UI для этого VM уже отображается");
        //    var window = CreateWindowInstanceWithVM(vm);
        //    window.Show();
        //    openWindows[vm] = window;
        //}

        //public void HidePresentation(object vm)
        //{
        //    Window window;
        //    if (!openWindows.TryGetValue(vm, out window))
        //        throw new InvalidOperationException("UI для этого VM уже отображается");
        //    window.Close();
        //    openWindows.Remove(vm);
        //}
        #endregion

        /// <summary>
        /// Показать окно
        /// </summary>
        /// <param name="vm"></param>
        public void ShowModalPresentation(object vm)
        {
            var window = CreateWindowInstanceWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

    }
}
