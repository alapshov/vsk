using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestTools;
using TestStack.White.UIItems.TreeItems;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace MUV.FormObjects
{
    public class SettingCalcMatrixForm
    {
        public SettingCalcMatrixForm()
        {

        }

        #region Form element

        /// <summary>
        /// Список настроек
        /// </summary>
        protected Tree _settingsTree
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Tree>(SearchCriteria.ByAutomationId("treeView"));
            }
        }

        /// <summary>
        /// Список настроек для программ
        /// </summary>
        protected TreeNode _settingsProgramm
        {
            get
            {
                TreeNode treeNode = _settingsTree.Node("Программы");
                return treeNode;
            }
        }

        /// <summary>
        /// Наименование
        /// </summary>
        protected TextBox _txtName
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtName"));
            }
        }

        /// <summary>
        /// Описание
        /// </summary>
        protected TextBox _txtDescription
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtDescription"));
            }
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        protected TextBox _txtRequestNumber
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtRequestNumber"));
            }
        }

        /// <summary>
        /// Статус
        /// </summary>
        protected TextBox _lblStatus
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("lblStatus"));
            }
        }

        /// <summary>
        /// Период с
        /// </summary>
        protected DateTimePicker _dtTo
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtTo"));
            }
        }

        /// <summary>
        /// Период по
        /// </summary>
        protected DateTimePicker _dtFrom
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtFrom"));
            }
        }

        /// <summary>
        /// Открытый период
        /// </summary>
        protected CheckBox _chkOpenPeriod
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("chkOpenPeriod"));
            }
        }

        /// <summary>
        /// Учитывать связку агентов с получателями в предварительном отборе
        /// </summary>
        protected CheckBox _chkPresetRefferenceBeneficiaryAgent
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("chkPresetRefferenceBeneficiaryAgent"));
            }
        }

        /// <summary>
        /// Выполнять автоматическое связывание получается с самим собой, если он является страховым агентом
        /// </summary>
        protected CheckBox _chkAutoLinkBeneficiaryHimself
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("chkAutoLinkBeneficiaryHimself"));
            }
        }
               
        /// <summary>
        /// Правила округления
        /// </summary>
        protected ComboBox _comboBoxRoundingRule
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxRoundingRule"));
            }
        }

        /// <summary>
        /// Показать/скрыть фильтр
        /// </summary>
        protected CheckBox _showHideFilterCheckBox
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("ShowHideFilterCheckBox"));
            }
        }

        /// <summary>
        /// Очистить фильтр
        /// </summary>
        protected Button _btnFilterClear
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnFilterClear"));
            }
        }

        /// <summary>
        /// Фильтр для таблицы с филиалами
        /// </summary>
        protected TextBox _filterBranch
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBoxFilter"));
            }
        }

        /// <summary>
        /// Таблица с филиалами
        /// </summary>
        protected ListView _dGrid
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }

        /// <summary>
        /// Таблица с матрицами
        /// </summary>
        protected ListView _gvMatrix
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("gvMatrix"));
            }
        }

        /// <summary>
        /// Сохранить
        /// </summary>
        protected Button _btnSave
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnSave"));
            }
        }

        /// <summary>
        /// Обновить
        /// </summary>
        protected Button _btnRestore
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnRestore"));
            }
        }

        /// <summary>
        /// Удалить
        /// </summary>
        protected Button _btnRemove
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnRemove"));
            }
        }

        #endregion 

        /// <summary>
        /// Открыть настройки программы
        /// </summary>
        /// <param name="name"></param>
        public void OpenProgrammByName(string name)
        {
            Trace($"Открываем настройки программы {name}");
            _settingsProgramm.Nodes.GetItem(name).Click();
        }        
        
        /// <summary>
        /// Открыть создание нового шаблона для программы
        /// </summary>
        /// <param name="name"></param>
        public void OpenNewTamplateByProgram(string name)
        {
            Trace($"Открываем новый шаблон лля программы {name}");
            var node = _settingsProgramm.Nodes.GetItem(name);
            if (node.DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.Expand();
            if (node.GetItem("Шаблоны").DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.GetItem("Шаблоны").Expand();
            node.GetItem("Шаблоны").GetItem("Новый шаблон").Click();            
        }

        /// <summary>
        /// Открыть шаблон для программы
        /// </summary>
        /// <param name="name"></param>
        public void OpenCurrentTamplateByProgram(string name, string tamplate)
        {
            Trace($"Открываем новый шаблон лля программы {name}");
            var node = _settingsProgramm.Nodes.GetItem(name);
            if (node.DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.Expand();
            if (node.GetItem("Шаблоны").DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.GetItem("Шаблоны").Expand();
            node.GetItem("Шаблоны").GetItem(tamplate).Click();
        }

        /// <summary>
        /// Открыть создание нового периода для программы
        /// </summary>
        /// <param name="name"></param>
        public void OpenNewPeriodByProgram(string name)
        {
            Trace($"Открываем новый период лля программы {name}");
            var node = _settingsProgramm.Nodes.GetItem(name);
            if (node.DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.Expand();
            if (node.GetItem("Периоды").DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.GetItem("Периоды").Expand();
            node.GetItem("Периоды").GetItem("Новый период").Click();
        }

        /// <summary>
        /// Открыть период для программы
        /// </summary>
        /// <param name="name"></param>
        public void OpenCurrentPeriodByProgram(string name, string tamplate)
        {
            Trace($"Открываем новый период лля программы {name}");
            var node = _settingsProgramm.Nodes.GetItem(name);
            if (node.DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.Expand();
            if (node.GetItem("Периоды").DisplayState == System.Windows.Automation.ExpandCollapseState.Collapsed)
                node.GetItem("Периоды").Expand();
            node.GetItem("Периоды").GetItem(tamplate).Click();
        }

        public SettingCalcMatrixForm FillName(string name)
        {

            _txtName.BulkText = name;
            return this;
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
