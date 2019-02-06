using System.Collections.Generic;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using MUV.ModelData;
using MUV.FormObjects;
using System;
using TestTools;


namespace MUV
{
    [TestFixture]
    public class CreateBonusCalculationTest: TestBase
    {
        public CreateBonusCalculationTest()
        {

        }
        public static IEnumerable<BonusCalculationData> DataFromXmlFile()
        {
            var TestDirectory = TestContext.CurrentContext.TestDirectory;
            return (List<BonusCalculationData>)
                new XmlSerializer(typeof(List<BonusCalculationData>)).Deserialize(new StreamReader(TestDirectory + @"\TestData\BonusCalculationData.xml"));
        }

        [Test, Category("BonusCalculation"), TestCaseSource(nameof(DataFromXmlFile))]
        //Заполнение формы создания реестра
        public void Calc(BonusCalculationData data)
        {

            try
            {
                TestName = "[BonusCalculation " + data.ToString() + "]";
                Trace(TestName);
                AppManager.Instance.TestManager.OpenRegistryForm();
                AppManager.Instance.TestManager.DeleteOldRegistry(data);
                AppManager.Instance.TestManager.CreateRegistry(data);
                AppManager.Instance.TestManager.CalcRegistry(data);
                //Проверка
                AppManager.Instance.TestManager.CompareCalc(data);
        }
            catch (Exception e)
            {
                Log.Error(e, TestName);
                throw;
            }
}


        [Test, Category("Test_ui")]
        public void Test()
        {
            TestName = "[Test ui]";
            Trace(TestName);
            AppManager.Instance.Login.SingInSSO();
            AppManager.Instance.Menu.OpenSettingBeneficiary();
            AppManager.Instance.SettingsBeneficiaryForm.FillCodeFilter("0078000256");
        }
    }
}
