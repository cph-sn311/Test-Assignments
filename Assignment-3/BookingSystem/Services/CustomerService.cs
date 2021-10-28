﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Models;

namespace BookingSystem.Services
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer newCustomer);
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomersByFirstName(string firstname);
    }
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerStorage _customerStorage;

        public CustomerService(ICustomerStorage customerStorage)
        {
            _customerStorage = customerStorage;
        }


        public Customer GetCustomer(int id)
            => _customerStorage.GetCustomer(id);

        public IEnumerable<Customer> GetCustomersByFirstName(string firstname)
            => _customerStorage.GetCustomers().Where(x => x.Firstname.ToLowerInvariant() == firstname.ToLowerInvariant());

        public bool CreateCustomer(Customer newCustomer)
            => _customerStorage.CreateCustomer(newCustomer) > 0;
    }
}
