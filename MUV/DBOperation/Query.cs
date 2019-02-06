using System.Collections.Generic;

namespace MUV.DBOperation
{
    internal static class Query
    {
        /// <summary>
        /// Выбор записей из таблицы CalculationDetailed
        /// </summary>
        /// <returns></returns>
        internal static string SelectCalculationDetailed()
        {
            return "SELECT PaymentID, BillItemID FROM[HERIS].[dbo].[CalculationDetailed]";
        }
        /// <summary>
        /// Выбор PaymentID из таблицы BillItemPayment
        /// </summary>
        /// <param name="data">Список BillItemID</param>
        /// <returns></returns>                     
        internal static string SelectPaymentInBillItem(List<string> data)
        {
            string query;
            if (data.Count != 0)
            {
                query = $"USE [AdBoIntegration] SELECT PaymentID FROM [AdBoIntegration].[dbo].[BillItemPayment] " +
                            $"where BillItemID in({string.Join(",", data)})";
            }
            else
            {
                query = null;                
            }
                return query;            
        }
        /// <summary>
        /// Очистка HerisPaymentSuccess по PaymentID
        /// </summary>
        /// <returns></returns>
        internal static string ClearHerisPaymentSuccess(List<string> payment)
        {
            string query;
            if (payment.Count != 0)
            {
                query = $"DELETE [AdBoIntegration].[dbo].[HERIS_PaymentSuccess] " +
                            $"WHERE PaymentID in ({string.Join(",", payment)})";
            }
            else
            {
                query = null;
            }
            return query;
        }
        /// <summary>
        /// Очистка HerisPaymentSuccess по BillItemID
        /// </summary>
        /// <returns></returns>
        internal static string ClearHerisPaymentSuccessInBillItem(List<string> payment)
        {
            string query;
            if (payment.Count != 0)
            {
               query = $"DELETE [AdBoIntegration].[dbo].[HERIS_PaymentSuccess] " +
                            $"WHERE PaymentID in ({string.Join(",", payment)})";
            }
            else
            {
                query = null;
            }
            return query;
        }
        /// <summary>
        /// Очистка HerisPaymentSuccess по PaymentID из таблицы BillItemPayment
        /// </summary>
        /// <returns></returns>
        internal static string ClearHerisPaymentSuccessInBillItemPayment(List<string> payment)
        {
            string query;
            if (payment.Count != 0)
            {
                query = $"DELETE [AdBoIntegration].[dbo].[HERIS_PaymentSuccess] " +
                        $"WHERE PaymentID in ({string.Join(",", payment)})";
            }
            else
            {
                query = null;
            }
            return query;
        }
        /// <summary>
        /// Очистка таблицы BillItemSuccess
        /// </summary>
        /// <returns></returns>
        internal static string ClearHerisBillItemSuccess(List<string> payment)
        {
            string query;
            if (payment.Count != 0)
            {
                query = $"DELETE [AdBoIntegration].[dbo].[HERIS_BillItemSuccess] " +
                        $"WHERE BillItemID in ({string.Join(",", payment)})";
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}
