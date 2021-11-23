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
        /// send new parcel to database
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></int as value of new index>
        public int AddParcel(Parcel parcel)
        {
            if (DataSource.Parcels.Any(pr => pr.Id == parcel.Id))
            {
                throw new ParcelExeption("id already exist");
            }
            DataSource.Parcels.Add(parcel);
            DataSource.Config.totalNumOfParcels++;
            return DataSource.Config.totalNumOfParcels;
        }
        /// <summary>
        /// gets parcel from database and return it to main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></the parcel got >
        public Parcel GetParcel(int id)
        {
            Parcel? myParcel = null;
            for (int i = 0; i < DataSource.Parcels.Count(); i++)
                if (DataSource.Parcels[i].Id == id)
                    myParcel = DataSource.Parcels[i];
            if (myParcel == null)
                throw new ParcelExeption("id of parcel not found");
            return (Parcel)myParcel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void UpdateParcelToDrone(int idP, int idD)
        {
            if (DataSource.Parcels.TrueForAll(ps => ps.Id != idP))
            {
                throw new ParcelExeption(" Id of parcel not found\n");
            }
            if (DataSource.Drones.TrueForAll(dr => dr.Id != idD))
            {
                throw new DroneException(" Id of drone not found\n");
            }
            int i = DataSource.Parcels.FindIndex(ps => ps.Id == idP);
            Parcel myParcel = DataSource.Parcels[i];
            myParcel.DroneId = idD;
            myParcel.Requested = DateTime.Now;
            DataSource.Parcels[i] = myParcel;

        }
        /// <summary>
        /// method that sets the delivery time 
        /// </summary>
        /// <param name="id"></param>
        public void UpdatesParcelDelivery(int id)
        {
            int k = DataSource.Parcels.FindIndex(ps => ps.DroneId == id);
            if (k == -1)
                throw new ParcelExeption("invalid parcel id");
            Parcel tmp = DataSource.Parcels[k];
            tmp.Delivered = DateTime.Now;
            tmp.DroneId = 0;
            DataSource.Parcels[k] = tmp;
        }
        /// <summary>
        /// func that returns list to print in console
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Parcel> GetParcelList()
        {

            return DataSource.Parcels.ToList();
        }

      public  void UpdateParcel(Parcel p) {

            int index = DataSource.Parcels.FindIndex(pc => pc.Id == p.Id);
            if (index == -1)
                throw new ParcelExeption("this parcel do not exists");
            DataSource.Parcels[index] = p;
        }
    }
}
