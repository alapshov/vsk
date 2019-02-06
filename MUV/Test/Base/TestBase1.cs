using MUV.DBOperation;
using MUV.FormObjects;
using NUnit.Framework;
using System;
using TestStack.White.Configuration;
using TestTools;
using NUnit.Framework;
using System;
using System.Diagnostics;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestTools;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using NUnit.Framework.Interfaces;


namespace MUV
{
    public class TestBase1
    {
        public string TestName { get; set; }

        [OneTimeSetUp]
        public void InitApplication()
        {

            //Запуск логирования с указанием пути
            //Log.Start(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            PaymentIDAndBillItemID payment = new PaymentIDAndBillItemID();
            DBConnectionAndLoad connect = new DBConnectionAndLoad();
            //Соединение с БД
            //var herisConnection = connect.Connection(@"Persist Security Info=False;Integrated Security=true;
            //                                      Initial Catalog=Heris;server=TestDb2\Inst1");
            //var adBoConnection = connect.Connection(@"Persist Security Info=False;Integrated Security=true;
            //                                      Initial Catalog=AdBoIntegration;server=TestDb2\Integr");
            //herisConnection.Open();
            //adBoConnection.Open();
            //payment.LoadDataLists(herisConnection, adBoConnection);
            //ClearTable.ClearHerisPaymentSuccess(adBoConnection, payment);
            //ClearTable.ClearCalulationRegistry(herisConnection);
            //herisConnection.Close();
            //adBoConnection.Close();
        }
        [SetUp]
        //Инициализация формы реестров расчета
        public void InitRegistryForm()
        {
            CoreAppXmlConfiguration.Instance.BusyTimeout = 5000;
            AppManager.Instance.StartTest();
            //Логин
            AppManager.Instance.Login.SingInSSO();
        }

        [TearDown, Category("BonusCalculation")]
        //Закрываем форму реестра расчетов
        public void StopRegistryForm()
        {
            Log.Separator();
            AppManager.Instance.AppWhite.Kill();
        }
        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        public void Trace(string msg)
        {
            Log.Trace($"{ToString()}: {msg}", Level.Test);
        }

    }
}
