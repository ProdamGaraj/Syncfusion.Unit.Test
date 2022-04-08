using System;
using System.Collections.Generic;
using System.Linq;
using Example.DataAccess;
using Example.DataRepository;

namespace Example.BusinessLogic
{
    public class CustomerService
    {
        private IEntityRepository<Customer> _customerRepository { get; set; }
        public CustomerService(IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetActiveCustomers()
        {
            var result = new List<Customer>();

            result = _customerRepository.GetAllQueryable().Where(s => s.IsDeleted == false).ToList();

            return result;
        }

        public bool GetActiveCustomers(Customer customer)
        {
            var isAdded = false;
            try
            {
                _customerRepository.Insert(customer);
                isAdded = true;
            }
            catch (Exception ex)
            {
                isAdded = false;
            }

            return isAdded;
        }

    }
}
