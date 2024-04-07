using Bank.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(string? customerName, Cpf cpf)
        {
            CustomerName = customerName;
            Cpf = cpf;
        }

        public string? CustomerName { get; private set; }

        public Cpf Cpf { get; set; }
    }
}
