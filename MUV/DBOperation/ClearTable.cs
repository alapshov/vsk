using System.Data.SqlClient;
using System.Diagnostics;
using TestTools;


namespace MUV.DBOperation
{
    internal static class ClearTable
    {
        
        internal static void ClearHerisPaymentSuccess(SqlConnection connection, PaymentIDAndBillItemID payment)
        {
            Trace("Выполняем чистку платежей");
            SqlCommand command;
            if (Query.ClearHerisPaymentSuccess(payment.PaymentIDList) != null ||
                Query.ClearHerisPaymentSuccessInBillItem(payment.BillItemIDList) != null ||
                Query.ClearHerisPaymentSuccessInBillItemPayment(payment.PaymentIDInBillItem) != null)

            {
                try
                {
                    command = new SqlCommand(Query.ClearHerisPaymentSuccess(payment.PaymentIDList), connection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(Query.ClearHerisPaymentSuccessInBillItem(payment.BillItemIDList), connection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(Query.ClearHerisPaymentSuccessInBillItemPayment(payment.PaymentIDInBillItem), connection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(Query.ClearHerisBillItemSuccess(payment.BillItemIDList), connection);
                    command.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    Trace("Не удалось выполнить чистку платежей");
                }
                
            }
            else
            {
                Trace("");
            }               
        }
        internal static void ClearCalulationRegistry(SqlConnection connection)
        {
            Trace("Выполняем чисту реестров расчета");
            SqlCommand command;
            try
            {
                command = new SqlCommand("delete HERIS..CalculationDetailedRoadLacet", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("delete HERIS..CalculationDetailed", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("delete HERIS..BonusCalculationFilter", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("delete HERIS..BonusCalculation", connection);
                command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {

                Trace("Не удалось выполнить очистку реестров рассчета");
            }
                     
            
        }
        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private static void Trace(string msg)
        {
            Log.Trace($"ClearTable: {msg}", Level.Start);
        }

    }
}
