namespace HomeWork_19_WPF
{
    /// <summary>
    /// Класс с расширяющим методом GetSumRateExt для Client
    /// - Расчёт % в рублях за месяц
    /// </summary>
    public static class StaticExt
    {
        public static byte[] daysOnMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// Расщиряющий метод - Расчёт % в рублях за месяц
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string[] GetSumRateExt(this Client client)
        {
            double[] sum = new double[12];
            double[] sumPlusDeposit = new double[12];
            double money = client.Money;
            double sumRate = client.Money * (double)client.Rate / 100 / 365;
            string[] sumStr = new string[12];
            for (int i = 0; i < 12; i++)
            {
                sum[i] = sumRate * daysOnMonth[i];
                money += sum[i];
                sumPlusDeposit[i] = money;
                sumStr[i] = string.Format($"{sum[i]:f2} руб   {sumPlusDeposit[i]:f2} руб");
            }
            return sumStr;
        }
         
    }
}
