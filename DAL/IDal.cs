using DalObject;
using IDAL.DO;
using System.Collections.Generic;

namespace IDAL
{
    public interface IDal
    {
        #region Create part of C.R.U.D
        void AddBaseStation(BaseStation baseStation);
        void AddCustomer(Customer customer);
        void AddDrone(Drone drone);
        int AddParcel(Parcel parcel);
        #endregion

        #region Read part of C.R.U.D.
        #region Read all elements 
        IEnumerable<BaseStation> GetAllBaseStations();
        IEnumerable<Customer> GetCustomerList();
        IEnumerable<Parcel> GetParcelList();
        double[] DroneElectricConsumations();
        IEnumerable<Drone> GetDroneList();
        #endregion
        #region Read a single element 
        BaseStation GetBaseStation(int id);
        Customer GetCustomer(int id);
        Drone GetDrone(int id);
        Parcel GetParcel(int id);
        #endregion
        #endregion
        void UpdateDrone(Drone dr);
        void UpdateDronePickUp(int id);
        void UpdateDroneToCharge(int idD, string baseName);
        void UpdatesParcelDelivery(int id);
        void UpdateParcelToDrone(int idP, int idD);
        void UpdateReleasDroneCharge(int idD, string baseName);
//double Distance(double d, double d1, double d2, double d3);
        void UpdateBaseStationFromBl(BaseStation bs);
        void UpdateCustomerInfoFromBL(Customer bs);
        void UpdateParcel(Parcel p);
    }
}