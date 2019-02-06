using TestStack.White.UIItems.Finders;
using MUV.FormObjects;
using System.Diagnostics;
using TestTools;


namespace MUV
{
    public class Menu
    {
        public Menu()
        {

        }

        #region Form element

        protected TestStack.White.UIItems.WindowStripControls.MenuBar _menuBar
        {
            get
            {
                return AppManager.Instance.MainWindow.MenuBar;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSettings
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TestStack.White.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Настройка"));
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSettingCalcMatrix
        {
            get
            {
                var settingCalcMatrix = _menuBar.MenuItem("Настройка", "Настройка", "Настройка матрицы расчета");
                settingCalcMatrix = _menuBar.MenuItemBy(SearchCriteria.ByText("Настройка матрицы расчета"));
                return settingCalcMatrix;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSettingBeneficiary
        {
            get
            {
                var settingBeneficiary = _menuBar.MenuItem("Настройка", "Настройка", "Настройка получателей");
                settingBeneficiary = _menuBar.MenuItemBy(SearchCriteria.ByText("Настройка получателей"));
                return settingBeneficiary;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSettingAgent
        {
            get
            {
                var settingAgent = _menuBar.MenuItem("Настройка", "Настройка", "Настройка агентов");
                settingAgent = _menuBar.MenuItemBy(SearchCriteria.ByText("Настройка агентов"));
                return settingAgent;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSettingBranch
        {
            get
            {
                var settingBranch = _menuBar.MenuItem("Настройка", "Настройка", "Настройка филиалов");
                settingBranch = _menuBar.MenuItemBy(SearchCriteria.ByText("Настройка филиалов"));
                return settingBranch;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuCalcMatrix
        {
            get
            {
                var calcMatrix = _menuBar.MenuItem("Настройка", "Матрицы расчетов");
                calcMatrix = _menuBar.MenuItemBy(SearchCriteria.ByText("Матрицы расчетов"));
                return calcMatrix;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuProgramm
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TestStack.White.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Программа"));
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuCalcRegisters
        {
            get
            {
                var calcRegisters = _menuBar.MenuItem("Программа", "Реестры расчета");
                calcRegisters = _menuBar.MenuItemBy(SearchCriteria.ByText("Реестры расчета"));
                return calcRegisters;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuManualRegistersDS
        {
            get
            {
                var manualRegistersDS = _menuBar.MenuItem("Программа", "Ручной реестр ДС");
                manualRegistersDS = _menuBar.MenuItemBy(SearchCriteria.ByText("Ручной реестр ДС"));
                return manualRegistersDS;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSummaryList
        {
            get
            {
                var summaryList = _menuBar.MenuItem("Программа", "Сводная опись");
                summaryList = _menuBar.MenuItemBy(SearchCriteria.ByText("Сводная опись"));
                return summaryList;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuService
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TestStack.White.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Сервис"));
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSyncBranch
        {
            get
            {
                var syncBranch = _menuBar.MenuItem("Сервис", "Синхронизация филиалов");
                syncBranch = _menuBar.MenuItemBy(SearchCriteria.ByText("Синхронизация филиалов"));
                return syncBranch;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSyncContractor
        {
            get
            {
                var syncContractor = _menuBar.MenuItem("Сервис", "Синхронизация контрагентов");
                syncContractor = _menuBar.MenuItemBy(SearchCriteria.ByText("Синхронизация контрагентов"));
                return syncContractor;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSyncSubjectsContract
        {
            get
            {
                var syncSubjectsContract = _menuBar.MenuItem("Сервис", "Синхронизация договоров субъектов");
                syncSubjectsContract = _menuBar.MenuItemBy(SearchCriteria.ByText("Синхронизация договоров субъектов"));
                return syncSubjectsContract;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuSystem
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TestStack.White.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Система"));
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuGlobalSettings
        {
            get
            {
                var globalSettings = _menuBar.MenuItem("Система", "Глобальные настройки");
                globalSettings = _menuBar.MenuItemBy(SearchCriteria.ByText("Глобальные настройки"));
                return globalSettings;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuUserSettings
        {
            get
            {
                var userSettings = _menuBar.MenuItem("Система", "Пользовательские настройки");
                userSettings = _menuBar.MenuItemBy(SearchCriteria.ByText("Пользовательские настройки"));
                return userSettings;
            }
        }

        protected TestStack.White.UIItems.MenuItems.Menu _menuOpenFolderLog
        {
            get
            {
                var openFolderLog = _menuBar.MenuItem("Система", "Открыть папку с логами");
                openFolderLog = _menuBar.MenuItemBy(SearchCriteria.ByText("Открыть папку с логами"));
                return openFolderLog;
            }
        }

        #endregion

        /// <summary>
        /// Выбор меню Настройка -> Настройка -> Настройка матрицы расчета
        /// </summary>
        public void OpenSettingCalcMatrix()
        {
            Trace("Открываем настройки рассчетов матрицы");
            _menuSettingCalcMatrix.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Настройка -> Настройка -> Настройка получателей
        /// </summary>
        public void OpenSettingBeneficiary()
        {
            Trace("Открываем настройки получателей");
            _menuSettingBeneficiary.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Настройка -> Настройка -> Настройка агетов
        /// </summary>
        public void OpenSettingAgents()
        {
            Trace("Открываем настройка агетов");
            _menuSettingAgent.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Настройка -> Настройка -> Настройка филиалов
        /// </summary>
        public void OpenSettingBranchs()
        {
            Trace("Открываем настройка филиалов");
            _menuSettingBranch.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Настройка -> Матрицы расчетов
        /// </summary>
        public void OpenCalcMatrix()
        {
            Trace("Открываем Настройка -> Матрицы расчетов");
            _menuCalcMatrix.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню программа -> Реестры расчета
        /// </summary>
        public void OpenFormAutoRegistry()
        {
            Trace("Выбор меню программа -> Реестры расчета");
            _menuCalcRegisters.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню программа -> Ручной реестр ДС
        /// </summary>
        public void OpenManualRegistersDS()
        {
            Trace("Выбор меню программа -> Ручной реестр ДС");
            _menuManualRegistersDS.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню программа -> Сводная опись
        /// </summary>
        public void OpenSummaryList()
        {
            Trace("Выбор меню программа -> Сводная опись");
            _menuSummaryList.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Сервис -> Синхронизация филиалов
        /// </summary>
        public void OpenSyncBranch()
        {
            Trace("Выбор меню Сервис -> Синхронизация филиалов");
            _menuSyncBranch.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Сервис -> Синхронизация контрагентов
        /// </summary>
        public void OpenSyncContractor()
        {
            Trace("Выбор меню Сервис -> Синхронизация контрагентов");
            _menuSyncContractor.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
        }

        /// <summary>
        /// Выбор меню Сервис -> Синхронизация договоров субъектов
        /// </summary>
        public void OpenSyncSubjectsContract()
        {
            Trace("Выбор меню Сервис -> Синхронизация договоров субъектов");
            _menuSyncSubjectsContract.Click();
            AppManager.Instance.MainWindow.WaitWhileBusy();
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
