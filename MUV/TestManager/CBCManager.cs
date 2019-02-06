using MUV.FormObjects;
using MUV.ModelData;
using NUnit.Framework;
using System.Diagnostics;
using System;
using TestTools;


namespace MUV
{
    /// <summary>
    /// Менеджер теста проверки расчета BonusCalculation
    /// </summary>
    public class CBCManager
    {
        /// <summary>
        /// Переход в форму реестров
        /// </summary>
        public void OpenRegistryForm()
        {
            Trace("CBCManager: Переход в форму реестров");
            AppManager.Instance.Menu.OpenFormAutoRegistry();
        }
        /// <summary>
        /// Запуск расчета реестра
        /// </summary>
        /// <param name="data"></param>
        internal void CalcRegistry(BonusCalculationData data)
        {
            Trace("CBCManager:Расчет реестра");
            AppManager.Instance.CalcDetailedForm.CalcRegistryFullScreen();
            AppManager.Instance.CalcDetailedForm.BtnCalcRegistryClick();
        }

        /// <summary>
        /// Создать реестр
        /// </summary>
        /// <param name="data">параметры xml</param>
        internal void CreateRegistry(BonusCalculationData data)
        {
            Trace("CBCManager: Создание реестра");
            AppManager.Instance.RegistryForm.BtnCreateNewRegistryFormClick();
            AppManager.Instance.CreateCalcForm.SelectBranch(data.Branch);
            AppManager.Instance.CreateCalcForm.SelectProgramm(data.Programm);
            //Ударжание
            if (data.HoldValue == "1")
            {
                AppManager.Instance.CreateCalcForm.Hold();
            }

            AppManager.Instance.CreateCalcForm.BeneficiarySelect(data.BeneficiaryCode);

            //Дата расчета
            if (data.CalculationDate != null)
            {
                AppManager.Instance.CreateCalcForm.CalulationDateToFilter(data.CalculationDate);
            }
            //Период страхового взноса
            if (data.InsurancePremiumDateStart != null || data.InsurancePremiumDateEnd != null)
            {
                AppManager.Instance.CreateCalcForm.InsurancePremiumPeriod(data.InsurancePremiumDateStart, data.InsurancePremiumDateEnd);
            }
            //Выбор страхователя
            if (data.InsurersCode1 != null & data.InsurersCode2 != null)
            {
                AppManager.Instance.CreateCalcForm.InsurersSelect(data.InsurersCode1, data.InsurersCode2);
            }
            //Выбор вида страхования
            if (data.VidStrah1 != null || data.VidStrah2 != null)
            {
                AppManager.Instance.CreateCalcForm.VidStrahSelect(data.VidStrah1, data.VidStrah2);
            }
            //По номеру документа
            if (data.DocNumber != null)
            {
                AppManager.Instance.CreateCalcForm.TxtPaymentDocNumberFilter(data.DocNumber);
            }
            // По номеру АВР
            if (data.AVR != null)
            {
                AppManager.Instance.CreateCalcForm.TxtAVRFilter(data.AVR);
            }

            AppManager.Instance.CreateCalcForm.BtnCreateClick();
        }

        /// <summary>
        /// Удаление ранее созданного реестра
        /// </summary>
        /// <param name="data">параметры xml</param>
        internal void DeleteOldRegistry(BonusCalculationData data)
        {
            Trace("CBCManager: Удаление ранее созданного реестра");
            AppManager.Instance.RegistryForm.SelectAndDeleteRegistry(data.Beneficiary);
        }
        /// <summary>
        /// Сравнение результатов расчеов
        /// </summary>
        /// <param name="data">параметры xml</param>
        public void CompareCalc(BonusCalculationData data)
        {
            Trace("CBCManager: Сравнение результатов расчеов");
            var RegistryTable = AppManager.Instance.CalcDetailedForm.RegistryResult();
            if (RegistryTable != null && (RegistryTable.product != ReadDataCalc.ProductEnum.Other))
            {
                ReadDataCalc.RegistryValidation(data, RegistryTable.item);
            }
            else Assert.Fail("Не совпадает количество столбцов для проверки, количество солбцов = {0}", RegistryTable.cellsCount);
        }

        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private void Trace(string msg)
        {
            Log.Trace($"{ToString()}: {msg}", Level.Manager);
        }

    }

}