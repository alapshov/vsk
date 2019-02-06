using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestTools;
using TestStack.White.UIItems.TreeItems;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace MUV.FormObjects
{
    public class CalcMatrixForm
    {
        public CalcMatrixForm()
        {

        }

        #region Form element

        #region Main form
        protected ComboBox _cboReportType
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cboReportType"));
            }
        }

        protected TextBox _txtBranches
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtBranches"));
            }
        }

        protected Button _brnBranchEdit
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("brnBranchEdit"));
            }
        }

        protected Button _brnBranchClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("brnBranchClear"));
            }
        }

        protected TextBox _txtBeneficiaries
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtBeneficiaries"));
            }
        }

        protected Button _btnBeneficiaries
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnBeneficiaries"));
            }
        }

        protected Button _btnBeneficiariesClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnBeneficiariesClear"));
            }
        }

        protected TextBox _txtIssuredPersons
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtIssuredPersons"));
            }
        }

        protected Button _bntInseredPersonsEdit
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("bntInseredPersonsEdit"));
            }
        }

        protected Button _bntInseredPersonsClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("bntInseredPersonsClear"));
            }
        }

        protected Button _btnReport
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));
            }
        }
        #endregion

        #region Add element form

        protected ListView _lstSelectedValues
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("lstSelectedValues"));
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

        protected ListView _dGrid
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }

        protected Button _btnSave
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnSave"));
            }
        }

        protected Button _btnClose
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnClose"));
            }
        }

        #endregion

        #endregion

        #region Form action

        public CalcMatrixForm SelectReportType(string type)
        {
            Trace($"Выбираем тип сводного отчета {type}");
            _cboReportType.Select(type);
            return this;
        }

        public void OpenSearchBranch()
        {
            Trace("Открываем форму добавления филиала");
            _brnBranchEdit.Click();
        }

        public void OpenSearchBeneficiaries()
        {
            Trace("Открываем форму добавления получателя");
            _btnBeneficiaries.Click();
        }

        public void OpenSearchIssuredPerson()
        {
            Trace("Открываем форму добавления страхователя");
            _bntInseredPersonsEdit.Click();
        }

        public void ClearBranch()
        {
            Trace("Очищаем поле с выбранными филиалами");
            _brnBranchClear.Click();
        }

        public void ClearBeneficiaries()
        {
            Trace("Очищаем поле с выбранными получателями");
            _btnBeneficiariesClear.Click();
        }

        public void ClearInseredPersons()
        {
            Trace("Очищаем поле с выбранными страхователями");
            _bntInseredPersonsClear.Click();
        }

        public void GenerateReport()
        {
            Trace("Нажимаем сформировать");
            _btnReport.Click();
        }
         
        public CalcMatrixForm SetShowHideFilter(bool show)
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

        public CalcMatrixForm SetFilterRowsCount(string count)
        {
            Trace($"Установить кол-во элементом {count}");
            _filterRowsCount.SetValue(count);
            return this;
        }

        public CalcMatrixForm ClickEntity(string entity)
        {
            Trace($"Выбираем сущность ! {entity}");
            foreach (var row in _dGrid.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Name.Contains(entity))
                    {
                        row.Click();
                        return this;
                    }
                }
            }
            throw new System.Exception($"Сущность {entity} не найдена");
        }

        public void SaveEntity()
        {
            Trace("Сохраняем выбранные сущности");
            _btnSave.Click();
        }

        public void CancelEntity()
        {
            Trace("Отменяем выбранные сущности");
            _btnClose.Click();
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
