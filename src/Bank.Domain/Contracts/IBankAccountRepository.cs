using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Contracts
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetByAccountNumber(string accountNumber);

        Task<IEnumerable<BankAccount>> GetEveryoneAccount();

        Task Add(BankAccount bankAccount);

        void Update(BankAccount bankAccount);

        void Remove(BankAccount bankAccount);
    }
}
