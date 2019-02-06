using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using System.Diagnostics;
using MUV.ModelData;
using MUV.FormObjects;
using TestTools;
using System.Threading;
using NUnit.Framework;

namespace MUV
{
    public class RegistryForm
    {
        public RegistryForm()
        {

        }

        #region Form element

        protected Window _formMessageBox
        {
            get
            {
                return AppManager.Instance.MainWindow.MessageBox("Сообщения");
            }
        }

        protected ListView _listViewMessages
        {
            get
            {
                return _formMessageBox.Get<ListView>(SearchCriteria.ByAutomationId("ListViewMessages"));
            }
        }

        protected TextBox _textBoxMessageText
        {
            get
            {
                return _formMessageBox.Get<TextBox>(SearchCriteria.ByAutomationId("TextBoxMessageText"));
            }
        }

        protected Button _newRegistry
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Новый"));
            }
        }

        protected Button _delRegistry
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Удалить"));
            }
        }

        protected ListView _dataGrid
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }
        #endregion 

        /// <summary>
        /// Отрыть форму создания реестра
        /// </summary>
        public void BtnCreateNewRegistryFormClick()
        {
            Trace("Открывается форма создания реестра");
            _newRegistry.Click();
        }

        /// <summary>
        /// Выбрать реестр расчета и удалить
        /// </summary>
        /// <param name="Beneficiary"></param>
        public void SelectAndDeleteRegistry(string Beneficiary)
        {
            Trace("Выбираем реестр расчета для удаления");
            foreach (var row in _dataGrid.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Text.Contains(Beneficiary))
                    {
                        row.Click();
                        Trace("Удаляем реестр");
                        _delRegistry.Click();
                        //Thread.Sleep(1000);
                        if (IsErrorShow())
                        {
                            foreach (var mess in _listViewMessages.Rows)
                            {
                                mess.Click();
                                Trace($"{mess.Cells[0].Text} \n{_textBoxMessageText.Text}");
                            }
                            _formMessageBox.Close();
                            Assert.Fail("Не удалось удалить реестры");
                        }
                    }
                }
            }
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        public bool IsErrorShow()
        {
            try
            {
                return _formMessageBox.IsModal;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Открыть реестр расчета
        /// </summary>
        public void OpenRegistry()
        {
            Trace("Открываем реестр");
            AppManager.Instance.MainWindow.Get(SearchCriteria.ByText("0018803244")).Click();
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
