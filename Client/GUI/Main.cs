using RAGE;

namespace XZRPV.Client.GUI
{
    public class Main : Events.Script
    {
        public RAGE.Ui.HtmlWindow GUI = null;
        protected string localPackageUrl = "package://XZRPV_GUI/index.html";
        protected string viteBuildUrl = "http://localhost:5173/";
        protected bool isDev = false;

        public Main()
        {
            GUI = new RAGE.Ui.HtmlWindow(isDev ? viteBuildUrl : localPackageUrl);
        }
    }
}
