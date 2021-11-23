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
        /// send a new customer to database
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            if (DataSource.Customers.Any(cos => cos.Id == customer.Id))
            {
                throw new CostumerExeption("id allready exist");
            }
            DataSource.Customers.Add(customer);
        }
        /// <summary>
        /// gets customer from database and return it to main
        /// </summary>
        /// <param name="id"></param>
        /// <returns></the customer got>
        public Customer GetCustomer(int id)
        {
            Customer? costumer = null;
            for (int i = 0; i < DataSource.Customers.Count(); i++)
                if (DataSource.Customers[i].Id == id)
                    costumer = DataSource.Customers[i];
            if (costumer == null)
                throw new CostumerExeption("id of customer not found");
            return (Customer)costumer;
        }
        /// <summary>
        /// func that returns list to print in console
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomerList()
        {
            return DataSource.Customers.ToList();
        }
        public void UpdateCustomerInfoFromBL(Customer customer)
        {
            int index = DataSource.Customers.FindIndex(cs => cs.Id == customer.Id);
            DataSource.Customers[index] = customer;
        }


    }
}
