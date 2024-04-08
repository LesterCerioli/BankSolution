using Bank.Domain.Models;
using Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByCpf(Cpf cpf);

        Task<Customer> GetByCustomerName(string customerName);

        Task<IEnumerable<Customer>> GetList();

        Task Add(Customer customer);

        void Update(Customer customer);

        void remove(Customer customer);
    }
}
