using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using MUV.FormObjects;
using TestTools;
using TestStack.White;
using System.Diagnostics;
using TestStack.White.UIItems.WindowItems;
using WhiteExtensions;

namespace MUV
{
   public class Login
    {
        
        public Login()
        {
            AppManager.Instance.MainWindow = AppManager.Instance.AppWhite.GetWindow(SearchCriteria.ByAutomationId("MDIForm"), InitializeOption.NoCache);
        }

        #region Form object
        
        /// <summary>
        /// Модальное окно с входом
        /// </summary>
        protected Window _modalLogin
        {
            get
            {
                return AppManager.Instance.MainWindow.ModalWindow(SearchCriteria.ByAutomationId("formLogin"), InitializeOption.NoCache); 
            }
        }

        /// <summary>
        /// Тип авторизации
        /// </summary>
        protected ComboBox _loginType
        {
            get
            {
                return _modalLogin.Get<ComboBox>(SearchCriteria.ByAutomationId("comboBoxIdentityType"));
            }
        }

        /// <summary>
        /// Поле 
        /// </summary>
        protected TextBox _login
        {
            get
            {
                return _modalLogin.Get<TextBox>(SearchCriteria.ByAutomationId("textBoxLogin"));
            }
        }

        protected TextBox _password
        {
            get
            {
                return _modalLogin.Get<TextBox>(SearchCriteria.ByAutomationId("textBoxPass"));
            }
        }

        protected Button _btnLogin
        {
            get
            {
                return _modalLogin.Get<Button>(SearchCriteria.ByAutomationId("buttonOk"));
            }
        }

        protected Button _btnCancel
        {
            get
            {
                return _modalLogin.Get<Button>(SearchCriteria.ByAutomationId("buttonCancel"));
            }
        }

        #endregion

                
        /// <summary>
        /// Вход в систему используя проверку подлинности Windows
        /// </summary>
        public void SingInSSO()
        {            
            AppManager.Instance.AppWhite.WaitWhileBusy();
            //если приложение запущено то не выполнять вход
            if (!IsLoginFormShow())
            {
                Trace("Пользователь уже авторизован");
                return;
            }
            Trace("Вход в систему используя проверку подлинности Windows");
            _loginType.Select("Проверка подлинности Windows");
            _btnLogin.Click();
            //try
            //{
            //    Wait.WaitForClose(_modalLogin, 100, 10);
            //}
            //catch (AutomationException)
            //{
            //
            //}
            

        }

        /// <summary>
        /// Вход в систему используя проверку подлинности по паролю
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SingInBasic(string user, string pass)
        {
            AppManager.Instance.AppWhite.WaitWhileBusy();
            //если приложение запущено то не выполнять вход
            if (!IsLoginFormShow())
            {
                Trace("Пользователь уже авторизован");
                return;
            }
            Trace($"Вход в систему используя логин {user} и пароль: {pass}");
            _loginType.Select("Проверка подлинности по паролю");
            _login.Text = user;
            _password.Text = pass;
            _btnLogin.Click();
            try
            {
                Wait.WaitForClose(_modalLogin, 100, 10);
            }
            catch (AutomationException)
            {

            }
        }

        /// <summary>
        /// Проверить наличие формы авторизации
        /// </summary>
        /// <returns></returns>
        public bool IsLoginFormShow()
        {
            return AppManager.Instance.AppWhite.GetWindows().Exists(obj => obj.AutomationElement.Current.AutomationId.Equals("formLogin"));
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
