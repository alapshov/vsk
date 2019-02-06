//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MUV.DBOperation
{

    internal class PaymentIDAndBillItemID
    {
        /// <summary>
        /// Список ID платежей
        /// </summary>
        internal List<string> PaymentIDList {get; set;}
        /// <summary>
        /// Список ID счетов
        /// </summary>
        internal List<string> BillItemIDList { get; set; }
        /// <summary>
        /// Список ID платежей связанных со счетами
        /// </summary>
        internal List<string> PaymentIDInBillItem { get; set; }

        /// <summary>
        /// Выгрузка данных по платежам
        /// </summary>
        /// <param name="herisConnection">соединение с херис</param>
        /// <param name="adBoConnection">соединение с АдБо</param>

        internal void LoadDataLists(SqlConnection herisConnection, SqlConnection adBoConnection)
        {   // Соединение с БД
            DBConnectionAndLoad Connection = new DBConnectionAndLoad();
            PaymentIDList = new List<string>();
            BillItemIDList = new List<string>();
            PaymentIDInBillItem = new List<string>();

            //Получаем PaymentID и BillItemID в datatable из [HERIS].[dbo].[CalculationDetailed]
            var dataTableCalc = Connection.DataLoad(Query.SelectCalculationDetailed(), herisConnection);

            //Забираем значения PaymentID и BillItemID из datatable (Херис) в список
            foreach (DataRow row in dataTableCalc.Rows)
            {
                if (row["PaymentID"] != DBNull.Value)
                {
                    PaymentIDList.Add(row["PaymentID"].ToString());
                }
                if (row["BillItemID"] != DBNull.Value)
                {
                    BillItemIDList.Add(row["BillItemID"].ToString());
                }
            }
            if (Query.SelectPaymentInBillItem(BillItemIDList) != null)
            {
                var dataTableBill = Connection.DataLoad(Query.SelectPaymentInBillItem(BillItemIDList), adBoConnection);
                //[AdBoIntegration].[dbo].[BillItemPayment]
                foreach (DataRow row in dataTableBill.Rows)
                {
                    if (row["PaymentID"] != DBNull.Value)
                    {
                        PaymentIDInBillItem.Add(row["PaymentID"].ToString());
                    }
                }
            }

        }

    }
}
