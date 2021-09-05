using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19_WPF
{
    /// <summary>
    /// Класс сообщения между ViewModel
    /// </summary>
    public class Messenger
    {
        public static Messenger Default { get; } = new Messenger();

        protected readonly Dictionary<Type, List<Delegate>> actions = new Dictionary<Type, List<Delegate>>();

        /// <summary>
        /// Регистрация параметризированного делегата для посылки сообщений между ViewModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public void Register<T>(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            lock (actions)
            {
                Type type = typeof(T);
                if (actions.TryGetValue(type, out List<Delegate> list))
                {
                    if (!list.Contains(action))
                        list.Add(action);
                }
                else
                {
                    actions.Add(type, new List<Delegate>(1) { action });
                }
            }
        }

        /// <summary>
        /// отмена регистрации параметризированного делегата для посылки сообщений между ViewModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public void Unregister<T>(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            lock (actions)
            {
                Type type = typeof(T);
                if (actions.TryGetValue(type, out List<Delegate> list))
                    list.RemoveAll(act => (Action<T>)act == action);
            }

        }

        /// <summary>
        /// Посылает сообщения между ViewModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void Send<T>(T message)
        {
            lock (actions)
            {
                Type type = typeof(T);
                if (actions.TryGetValue(type, out List<Delegate> list))
                    list.ForEach(dlgt => ((Action<T>)dlgt)(message));
            }
        }
    }
}
