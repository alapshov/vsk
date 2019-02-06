using MUV.Properties;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestTools;


namespace MUV.FormObjects
{
    public class AppManager
    {

        private AppManager() { }
        private sealed class SingletonCreator
        {
            private static readonly AppManager instance = new AppManager();
            public static AppManager Instance { get { return instance; } }
        }
        public static AppManager Instance { get { return SingletonCreator.Instance; } }


        private Login _login;
        private Menu _menu;
        private RegistryForm _registryFrom;
        private CBCManager _testManager;
        private CreateCalcForm _createCalcForm;
        private CalcDetailedForm _calcDetailedForm;
        private SettingCalcMatrixForm _settingsCalcMatrixForm;
        private SettingsBeneficiaryForm _settingsBeneficiary;

        /// <summary>
        /// Запущенное приложение
        /// </summary>
        public Application AppWhite { get; set; }

        /// <summary>
        /// Главная форма приложения
        /// </summary>
        public Window MainWindow { get; set; }

        /// <summary>
        /// Авторизация
        /// </summary>
        public CBCManager TestManager
        {
            get
            {
                if (_testManager == null) _testManager = new CBCManager();
                return _testManager;
            }
        }
        public Login Login
        {
            get
            {
                if (_login == null) _login = new Login();
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        /// <summary>
        /// Верхнее меню приложения
        /// </summary>
        public Menu Menu
        {
            get
            {
                if (_menu == null) _menu = new Menu();
                return _menu;
            }
        }
        /// <summary>
        /// Форма реестров расчета
        /// </summary>
        public RegistryForm RegistryForm
        {
            get
            {
                if (_registryFrom == null) _registryFrom = new RegistryForm();
                return _registryFrom;
            }
        }
        /// <summary>
        /// Форма создания реестра расчетов
        /// </summary>
        public CreateCalcForm CreateCalcForm
        {
            get
            {
                if (_createCalcForm == null) _createCalcForm = new CreateCalcForm();
                return _createCalcForm;
            }
        }
        /// <summary>
        /// Форма детализации реестра расчетов
        /// </summary>
        public CalcDetailedForm CalcDetailedForm
        {
            get
            {
                if (_calcDetailedForm == null) _calcDetailedForm = new CalcDetailedForm();
                return _calcDetailedForm;
            }
        }

        public SettingCalcMatrixForm SettingCalcMatrixForm
        {
            get
            {
                if (_settingsCalcMatrixForm == null) _settingsCalcMatrixForm = new SettingCalcMatrixForm();
                return _settingsCalcMatrixForm;
            }
        }

        public SettingsBeneficiaryForm SettingsBeneficiaryForm
        {
            get
            {
                if (_settingsBeneficiary == null) _settingsBeneficiary = new SettingsBeneficiaryForm();
                return _settingsBeneficiary;
            }
        }

        //public object Tools { get; internal set; }

        public void StartTest()
        {
            Trace("Запуск приложения");
            if (File.Exists(Settings.Default.AppPath))
            {
                ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.AppPath);
                AppWhite = Application.AttachOrLaunch(psi);
                Assert.IsNotNull(AppWhite);
                _login = null;
                _menu = null;
                _registryFrom = null;
                _testManager = null;
                _createCalcForm = null;
                _calcDetailedForm = null;
                _settingsCalcMatrixForm = null;
                _settingsBeneficiary = null;          
            }
            else
                Assert.Fail("Не найдено приложение для запуска: " + Settings.Default.AppPath);
        }

        private void Trace(string msg)
        {
            Log.Trace($"{ToString()}: {msg}", Level.Start);
        }
    }

}