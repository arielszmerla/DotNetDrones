using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;
using IDAL;

namespace DalObject
{
    public partial class DalObject : IDal
    {
       




        /// <summary>
        /// send a new drone to database
        /// </summary>
        /// <param name="drone"></param>
        public void AddDrone(Drone drone)
        {
            if (DataSource.Drones.Any(dr => dr.Id == drone.Id))
            {
                throw new DroneException("id allready exist");
            }
            DataSource.Drones.Add(drone);
        }
        /// <summary>
        /// gets drone from database and return it to main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></drone>
        public Drone GetDrone(int id)
        {
            Drone? myDrone = null;
            for (int i = 0; i < DataSource.Drones.Count(); i++)
                if (DataSource.Drones[i].Id == id)
                    myDrone = DataSource.Drones[i];
            if (myDrone == null)
                throw new DroneException("id of drone not found");
            return (Drone)myDrone;
        }

        /// <summary>
        /// to set a time for when the drone pick's up a packet
        /// </summary>
        /// <param name="id"></param>
        public void UpdateDronePickUp(int id)
        {
            int i = DataSource.Drones.FindIndex(dr => dr.Id == id);
            if (i == -1)
                throw new DroneException("invalid drone id");
            int k = DataSource.Parcels.FindIndex(ps => ps.DroneId == id);
            if (k == -1)
                throw new ParcelExeption("invalid parcel id");
            Parcel tmp = DataSource.Parcels[k];
            tmp.PickedUp = DateTime.Now;
            DataSource.Parcels[k] = tmp;
        }
        /// <summary>
        /// func that returns list to print in console
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Drone> GetDroneList()
        {
            return DataSource.Drones.ToList();
        }

        public double[] DroneElectricConsumations()
        {
            double[] returnedArray ={ DataSource.Config.powerUseFreeDrone, DataSource.Config.powerUseLightCarrying,
                DataSource.Config.powerUseMediumCarrying, DataSource.Config.powerUseHeavyCarrying,
             DataSource.Config.chargePerHour };
            return returnedArray;
        }

    }
}
