﻿using Ambev.DeveloperEvaluation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.Customer.GetCustomerById
{
    public class GetCustomerByIdResult
    {
        public CustomerModel CustomerModel { get; set; }

        public GetCustomerByIdResult(CustomerModel customerModel)
        {
            CustomerModel = customerModel;
        }
    }
}
