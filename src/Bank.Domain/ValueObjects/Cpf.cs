using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        private string _cpfNumber;

        public string CpfNumber
        {
            get { return _cpfNumber; }
            private set
            {
                if (IsValidCPF(value))
                {
                    _cpfNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid CPF. CPF must have exactly 11 digits and be a valid CPF number.");
                }
            }
        }

        public Cpf(string cpfNumber)
        {
            CpfNumber = cpfNumber;
        }

        private bool IsValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove any non-digit characters
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Check if CPF has exactly 11 digits
            if (cpf.Length != 11)
                return false;

            // Validate CPF according to the algorithm
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCPF = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCPF[i].ToString()) * multiplier1[i];
            }

            int remainder = sum % 11;
            if (remainder < 2)
            {
                remainder = 0;
            }
            else
            {
                remainder = 11 - remainder;
            }

            string digit = remainder.ToString();
            tempCPF += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCPF[i].ToString()) * multiplier2[i];
            }

            remainder = sum % 11;
            if (remainder < 2)
            {
                remainder = 0;
            }
            else
            {
                remainder = 11 - remainder;
            }

            digit += remainder.ToString();
            return cpf.EndsWith(digit);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CpfNumber;
        }
    }
}
