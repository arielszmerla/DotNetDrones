using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;
using DalObject;
using IDAL;


namespace DalObject
{
    public partial class DalObject : IDal
    {
        public void UpdateDrone(Drone dr)
        {
            int index = DataSource.Drones.FindIndex(drone => drone.Id == dr.Id);
            DataSource.Drones[index] = dr;
        }
        /// <summary>
        /// gets basestation from database and return it to main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns the basestation got>
        public BaseStation GetBaseStation(int id)
        {
            BaseStation? myBase = null;
            for (int i = 0; i < DataSource.BaseStations.Count(); i++)
                if (DataSource.BaseStations[i].Id == id)
                    myBase = DataSource.BaseStations[i];
            if (myBase == null)
                throw new BaseExeption("id of base not found");
            return (BaseStation)myBase;
        }
        /// <summary>
        /// send a new base to database
        /// </summary>
        /// <param name="baseStation"></param>
        public void AddBaseStation(BaseStation baseStation)
        {
            if (DataSource.BaseStations.Any(bs => bs.Id == baseStation.Id))
            {
                throw new BaseExeption("id allready exist");
            }
            DataSource.BaseStations.Add(baseStation);
        }
        /// <summary>
        /// get list of base stations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseStation> GetAllBaseStations()
        {
            return DataSource.BaseStations.ToList();
        }
        public void UpdateBaseStationFromBl(BaseStation bs)
        {
                int index = DataSource.BaseStations.FindIndex(ba => ba.Id == bs.Id);
            if (index == -1)
            {
                throw new BaseExeption("id not found");
            }
            DataSource.BaseStations[index] = bs;
        }

      
    }

}