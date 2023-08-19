using RAGE;

namespace XZRPV.Client.GUI
{
    public class Authentication : Main
    {
        public Authentication()
        {
            Events.Add("ShowLoginPage::Client", ShowLoginPage);
            Events.Add("RemoveLoading::Client", RemoveLoading);
            Events.Add("DestroyLogin::Client", DestroyLogin);
        }

        public void RemoveLoading(object[] args)
        {
            GUI.ExecuteJs("appData.shared.setLoading(false)");
        }

        public void DestroyLogin(object[] args)
        {
            RAGE.Ui.Cursor.Visible = false;
            Chat.Show(!false);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);

            GUI.ExecuteJs("router.push('home')");
            GUI.Destroy();
        }

        public void ShowLoginPage(object[] args)
        {
            RAGE.Ui.Cursor.Visible = true;
            Chat.Show(!true);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(true);

            GUI.ExecuteJs("router.push('login')");
        }
    }
}
