using MUV.ModelData;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestTools;
using WhiteExtensions;

namespace MUV.FormObjects
{
    public class CalcDetailedForm
    {
        #region Form element

        protected Window _calcDetailedForm
        {
            get
            {
                return AppManager.Instance.MainWindow.ModalWindow(SearchCriteria.ByAutomationId("formCalculationRegistryDetails"));
            }
        }

        protected Button _calcRegistry
        {
            get
            {
                return _calcDetailedForm.Get<Button>(SearchCriteria.ByAutomationId("calcRegistry"));
            }
        }

        protected Window _dialogMsg
        {
            get
            {
                return AppManager.Instance.AppWhite.GetWindow(SearchCriteria.ByClassName("#32770"), TestStack.White.Factory.InitializeOption.NoCache);
            }
        }

        #endregion

        
        /// <summary>
        /// Сформировать реестр
        /// </summary>
        public void BtnCalcRegistryClick()
        {
            Trace("Нажимаем кнопку сформировать реестр");
            _calcRegistry.Click();
            _calcDetailedForm.WaitWhileBusy();
        }
        /// <summary>
        /// Развернуть на весь экран
        /// </summary>
        public void CalcRegistryFullScreen()
        {
            Trace("Разворачиваем форму реестра на весь экран");
            _calcDetailedForm.DisplayState = DisplayState.Maximized;
        }
        /// <summary>
        /// Результаты реестров расчета
        /// </summary>
        public ReadDataCalc RegistryResult()
        {
            Trace("CalcDetailedForm: Получаем данные из таблицы реестра расчетов");
            if (IsDialogErrorShow())
            {
                Assert.Fail(_dialogMsg.Items[2].Name);
            }
            Wait.SpinWait(_calcDetailedForm, SearchCriteria.ByClassName("DataGridRow"));
            return GetRowFromDataGrid(AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid")));
        }
        /// <summary>
        /// Чтение данных из таблицы с пролистыванием вниз
        /// </summary>
        /// <param name="listView">Грид из формы</param>
        /// <returns>Заполненая таблица</returns>
        private ReadDataCalc GetRowFromDataGrid(ListView listView)
        {
            Trace("CalcDetailedForm: Чтение данных из таблицы с пролистыванием вниз");
            ReadDataCalc collection = new ReadDataCalc();           
            if (listView.ScrollBars.Vertical.IsScrollable)
            {
                listView.ScrollBars.Vertical.SetToMinimum();
                listView.Rows[0].Click();
                Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.PAGEDOWN);
                collection = new ReadDataCalc(listView.Rows);
                do
                {
                    
                    Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.PAGEDOWN);
                    collection.AddItem(listView.Rows);
                }
                while (listView.ScrollBars.Vertical.Value < listView.ScrollBars.Vertical.MaximumValue);                
                Trace("CalcDetailedForm: Удаление дублей");
                collection.Distinct();
            }
            else
                collection = new ReadDataCalc(listView.Rows);
            return collection;
        }


        /// <summary>
        /// Закрыть форму реестра расчетов
        /// </summary>
        public void CloseRegisrtyForm()
        {
            Trace("CalcDetailedForm: Закрывем форму реестра расчетов");
            _calcDetailedForm.Close();

        }

        public bool IsDialogErrorShow()
        {
            try
            {
                return _dialogMsg.IsClosed == false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private void Trace(string msg)
        {
            Log.Trace($"{ToString()}: {msg}", Level.Form);
        }
    }
}
