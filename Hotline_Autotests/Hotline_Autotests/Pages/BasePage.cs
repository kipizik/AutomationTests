using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hotline_Autotests.Pages
{
    internal interface IWebPage
    {
        IWebPage Open(String url);
        IWebPage Refresh();
        void Close();
    }
}
