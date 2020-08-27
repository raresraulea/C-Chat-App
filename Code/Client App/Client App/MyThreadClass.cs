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

        public void Run()
        {
            // Execute the specified delegate on the thread that owns
            // 'myFormControl1' control's underlying window handle.
            myFormControl1.Invoke(myFormControl1.LoginUIDelegate);
        }
    }
}
