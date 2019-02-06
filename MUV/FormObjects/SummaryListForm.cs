using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestTools;
using TestStack.White.UIItems.TreeItems;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using System;

namespace MUV.FormObjects
{
    public class SummaryListForm
    {
        public SummaryListForm()
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

        protected Button _btnNew
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Новый"));
            }
        }

        protected Button _btnDelete
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Удалить"));
            }
        }

        protected Button _btnFunction
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Функции"));
            }
        }

        protected Button _btnPrint
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByText("Печать")); 
            }
        }

        protected CheckBox _showHideFilterCheckBox
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("ShowHideFilterCheckBox"));
            }
        }

        protected Button _btnFilterClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnFilterClear"));
            }
        }

        protected TextBox _filterRowsCount
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("FilterRowsCount"));
            }
        }

        protected CheckBox _searchInSelectedCheckBox
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("SearchInSelectedCheckBox"));
            }
        }

        protected Button _btnCheckedClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnCheckedClear"));
            }
        }

        protected ListView _dGrid
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }

        #region Form new summary

        protected DateTimePicker _dtDateStamp
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtDateStamp"));
            }
        }

        protected ComboBox _cboBonusProgram
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cboBonusProgram"));
            }
        }

        protected ComboBox _cboSubjectType
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cboSubjectType"));
            }
        }

        #endregion

        #endregion

        #region Form action

        public void CreateSummaryList()
        {
            Trace("Нажимаем создание новой сводной описи");
            _btnNew.Click();
        }

        public void ClickDelete()
        {
            Trace("Нажимаем удаление сводной описи");
            _btnDelete.Click();
        }

        public SummaryListForm SetShowHideFilter(bool show)
        {
            Trace($"Устанавливаем отображение фильтров {show}");
            _showHideFilterCheckBox.Checked = show;
            return this;
        }

        public void ClearFilter()
        {
            Trace("Очищаем фильтры");
            _btnFilterClear.Click();
        }

        public SummaryListForm SetFilterRowsCount(string count)
        {
            Trace($"Установить кол-во элементом {count}");
            _filterRowsCount.SetValue(count);
            return this;
        }

        public SummaryListForm SetSearchInSelected(bool search)
        {
            Trace($"Устанавливаем отображение фильтров {search}");
            _searchInSelectedCheckBox.Checked = search;
            return this;
        }

        /// <summary>
        /// Выбрать реестр расчета и удалить
        /// </summary>
        /// <param name="summary"></param>
        public void SelectAndDeleteRegistry(string summary)
        {
            Trace("Выбираем реестр расчета для удаления");
            foreach (var row in _dGrid.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Text.Contains(summary))
                    {
                        row.Click();
                        Trace("Удаляем опись");
                        _dGrid.Click();
                        //Thread.Sleep(1000);
                        if (IsErrorShow())
                        {
                            foreach (var mess in _listViewMessages.Rows)
                            {
                                mess.Click();
                                Trace($"{mess.Cells[0].Text} \n{_textBoxMessageText.Text}");
                            }
                            _formMessageBox.Close();
                            Assert.Fail("Не удалось удалить опись");
                        }
                    }
                }
            }
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        #endregion

        #region Public data

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

        #endregion


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
