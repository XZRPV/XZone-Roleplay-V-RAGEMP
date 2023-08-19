using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;
using XZRPV.Factions;
using XZRPV.Library.Extensions;
using XZRPV.Vehicles;

namespace XZRPV.Jobs
{
    public class JobManager : Script
    {
        private static List<IJob> jobs;

        public static IJob GetJobByID(int jobId)
        {
            return jobs.FirstOrDefault(j => j.ID == jobId);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            CreateJobs();
            CreateJobVehicles();
        }

        private void CreateJobs()
        {
            jobs = new List<IJob>();

            IJob Trucker = new Trucker.Trucker();
            IJob Fisherman = new Fisherman.Fisherman();
            IJob Cabbie = new Cabbie.Cabbie();
            IJob Miner = new Miner.Miner();
            IJob Woodcutter = new Woodcutter.Woodcutter();
            IJob Carpenter = new Carpenter.Carpenter();
            IJob Trashman = new Trashman.Trashman();

            jobs.Add(Trucker);
            jobs.Add(Fisherman);
            jobs.Add(Cabbie);
            jobs.Add(Miner);
            jobs.Add(Woodcutter);
            jobs.Add(Carpenter);
            jobs.Add(Trashman);
        }

        private void CreateJobVehicles()
        {
            foreach (IJob job in jobs)
            {
                if (job.Vehicles != null)
                {
                    foreach (VehicleSystemData vehicleData in job.Vehicles)
                    {
                        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(
                            vehicleData.VehicleHash,
                            vehicleData.Position,
                            vehicleData.RotationZ,
                            vehicleData.Color1,
                            vehicleData.Color2
                        );

                        VehicleSystem.AddVehicle(vehicle, vehicleData);
                        VehicleSystem.SetVehicleJobId(vehicle, job.ID.ToString());
                    }
                }

                if (job.BlipData != null)
                {
                    CreateJobBlip(job.BlipData);
                }
            }
        }

        public void CreateJobBlip(BlipJobData blipData)
        {
            Blip jobBlip = NAPI.Blip.CreateBlip(blipData.BlipPosition);
            jobBlip.Name = blipData.BlipName;
            jobBlip.ShortRange = true;
            jobBlip.Sprite = blipData.BlipSprite;
        }

        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        public void OnPlayerEnterVehicleAttempt(Player player, Vehicle vehicle, sbyte seatId)
        {
            if (!vehicle.HasData("JobId"))
                return;

            if (seatId != (int)VehicleSeat.Driver)
                return;

            string jobId = VehicleSystem.GetVehicleJobId(vehicle);

            if (player.GetUserData().JobId.ToString() != jobId)
            {
                player.SendChatMessage("No tienes la llave para utilizar este vehiculo.");
                player.WarpOutOfVehicle();
            }
        }
    }
}
