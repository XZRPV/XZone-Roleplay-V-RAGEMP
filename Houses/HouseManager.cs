using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;
using XZRPV.Database;
using XZRPV.Models;

namespace XZRPV.Houses
{
    public class HouseManager : Script
    {
        private readonly static List<House> houses = new List<House>();

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            FetchHouses();
        }

        public static House GetHouseById(int houseId)
        {
            return houses.FirstOrDefault(h => h.HouseId == houseId);
        }

        public static void CreateHouse(House house)
        {
            using (DbConn db = new DbConn())
            {
                db.Houses.Add(house);
                db.SaveChanges();
            }

            CreateMarkerEntrance(house);

            houses.Add(house);
        }

        public static void UpdateHouse(House house)
        {
            using (DbConn db = new DbConn())
            {
                db.Houses.Update(house);
                db.SaveChanges();
            }

            House houseToUpdate = houses.FirstOrDefault(h => h.HouseId == house.HouseId);
            houseToUpdate = house;
        }

        public static void DeleteHouse(House house)
        {
            using (DbConn db = new DbConn())
            {
                db.Houses.Remove(house);
                db.SaveChanges();
            }

            houses.Remove(house);
            house.MarkerEntrance.Delete();
            house.MarkerExit.Delete();
        }

        public static void CreateMarkerEntrance(House house)
        {
            if (house.MarkerEntrance != null)
            {
                house.MarkerEntrance.Delete();
            }

            house.MarkerEntrance = NAPI.Marker.CreateMarker(MarkerType.UpsideDownCone, house.Entrance, new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 0, 100));
        }

        public static void CreateMarkerExit(House house)
        {
            if (house.MarkerExit != null)
            {
                house.MarkerExit.Delete();
            }

            house.MarkerExit = NAPI.Marker.CreateMarker(MarkerType.UpsideDownCone, house.Exit, new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 0, 100));
        }

        private void FetchHouses()
        {
            NAPI.Util.ConsoleOutput("Fetching houses...");

            using (DbConn db = new DbConn())
            {
                var fetchedHouses = db.Houses.ToList();
                houses.AddRange(fetchedHouses);
            }

            foreach (House house in houses)
            {
                CreateMarkerEntrance(house);
                CreateMarkerExit(house);
            }
        }
    }
}
