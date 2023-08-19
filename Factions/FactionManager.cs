using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;
using XZRPV.Library.Extensions;
using XZRPV.Vehicles;

namespace XZRPV.Factions
{
    public class FactionManager : Script
    {
        private static List<IFaction> factions;

        public static IFaction GetFactionByID(int factionID)
        {
            return factions.FirstOrDefault(f => f.ID == factionID);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            CreateFactions();
            CreateFactionVehicles();
        }

        public void CreateFactions()
        {
            factions = new List<IFaction>();

            IFaction SAPD = new SAPD.SAPD();
            IFaction SAMD = new SAMD.SAMD();
            IFaction FIB = new FIB.FIB();
            IFaction WeazelNews = new WeazelNews.WeazelNews();
            IFaction LaCosaNostra = new LaCosaNostra.LaCosaNostra();
            IFaction Yakuza = new Yakuza.Yakuza();
            IFaction GrooveSt = new GrooveSt.GrooveSt();
            IFaction Ballas = new Ballas.Ballas();

            factions.Add(SAPD);
            factions.Add(SAMD);
            factions.Add(FIB);
            factions.Add(WeazelNews);
            factions.Add(LaCosaNostra);
            factions.Add(Yakuza);
            factions.Add(GrooveSt);
            factions.Add(Ballas);
        }

        public void CreateFactionVehicles()
        {
            foreach (IFaction faction in factions)
            {
                if (faction.Vehicles != null)
                {
                    foreach (VehicleSystemData vehicleData in faction.Vehicles)
                    {
                        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(
                            vehicleData.VehicleHash,
                            vehicleData.Position,
                            vehicleData.RotationZ,
                            vehicleData.Color1,
                            vehicleData.Color2
                        );

                        VehicleSystem.AddVehicle(vehicle, vehicleData);
                        VehicleSystem.SetVehicleFactionId(vehicle, faction.ID.ToString());
                    }
                }

                if (faction.BlipData != null)
                {
                    CreateFactionBlip(faction.BlipData);
                }
            }
        }

        public void CreateFactionBlip(BlipFactionData blipData)
        {
            Blip factionBlip = NAPI.Blip.CreateBlip(blipData.BlipPosition);
            factionBlip.Name = blipData.BlipName;
            factionBlip.ShortRange = true;
            factionBlip.Sprite = blipData.BlipSprite;
        }

        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void OnPlayerEnterVehicleAttempt(Player player, Vehicle vehicle, sbyte seatId)
        {
            if (!vehicle.HasData("FactionId"))
                return;

            if (seatId != (int)VehicleSeat.Driver)
                return;

            string factionId = VehicleSystem.GetVehicleFactionId(vehicle);

            if (player.GetUserData().FactionId.ToString() != factionId)
            {
                player.SendChatMessage("No tienes la llave para utilizar este vehiculo.");
                player.WarpOutOfVehicle();
            }
        }
    }
}
