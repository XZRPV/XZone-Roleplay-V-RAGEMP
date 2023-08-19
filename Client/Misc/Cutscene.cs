using RAGE;

namespace XZRPV.Client.Misc
{
    public class Cutscene : Events.Script
    {
        public Cutscene()
        {
            Events.Add("Cutscene", CutsceneHandler);
        }

        private async void CutsceneHandler(object[] args)
        {
            string cutscene = (string)args[0];

            RAGE.Elements.Player.LocalPlayer.ClearTasksImmediately();
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-1117.778f, -1557.625f, 3.3819f);

            RAGE.Game.Cutscene.RequestCutscene(cutscene, 1);

            while (!RAGE.Game.Cutscene.HasThisCutsceneLoaded(cutscene))
            {
                await Task.WaitAsync(0);
            }

            RAGE.Game.Cutscene.StartCutscene(4);
        }
    }
}
