using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestTools;
using TestStack.White.UIItems.TreeItems;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;


namespace MUV.FormObjects
{
    public class SettingsBeneficiaryForm
    {
        public SettingsBeneficiaryForm()
        {

        }

        #region Form element
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

        protected TextBox _codeTextBoxFilter
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBoxFilter"));
            }
        }

        protected ListView _dGrid
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }


        #endregion

        #region Form action

        public SettingsBeneficiaryForm SetShowHideFilter(bool show)
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

        public SettingsBeneficiaryForm SetFilterRowsCount(string count)
        {
            Trace($"Установить кол-во элементом {count}");
            _filterRowsCount.SetValue(count);
            return this;
        }

        public SettingsBeneficiaryForm SetsearchInSelected(bool search)
        {
            Trace($"Устанавливаем отображение фильтров {search}");
            _searchInSelectedCheckBox.Checked = search;
            return this;
        }

        public SettingsBeneficiaryForm FillCodeFilter(string code)
        {
            _codeTextBoxFilter.SetValue(code);
            return this;
        }

        public void ClickBeneficiary(string beneficiary)
        {
            Trace($"Выбираем получателя ! {beneficiary}");
            foreach (var row in _dGrid.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Name.Contains(beneficiary))
                    {
                        row.Click();
                        break;
                    }
                }
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
