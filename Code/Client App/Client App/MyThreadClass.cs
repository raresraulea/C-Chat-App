using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_App
{
    class MyThreadClass
    {
        Form1 myFormControl1;
        public MyThreadClass(Form1 myForm)
        {
            myFormControl1 = myForm;
        }
        
        public void Run(string delegateType)
        {
            switch (delegateType)
            {
                case "LoginUI":
                    myFormControl1.Invoke(myFormControl1.LoginUIDelegate);
                    break;
                case "LoginPopup":
                    myFormControl1.Invoke(myFormControl1.LoginPopupDelegate);
                    break;
                case "AdminUI":
                    myFormControl1.Invoke(myFormControl1.AdminUIDelegate);
                    break;
                case "WelcomeAdminPopup":
                    myFormControl1.Invoke(myFormControl1.WelcomeAdminPopupDelegate);
                    break;
                case "WrongCredentialsPopup":
                    myFormControl1.Invoke(myFormControl1.WrongCredentialsPopupDelegate);
                    break;
                case "ClearUsersListView":
                    myFormControl1.Invoke(myFormControl1.ClearUsersListViewDelegate);
                    break;
            }
            
        }
    }
}
