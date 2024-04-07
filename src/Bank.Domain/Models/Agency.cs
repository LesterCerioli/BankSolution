using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Domain.Models
{
    public class Agency : Entity, IAggregateRoot
    {
        private int? _agencyNumber;

        public int? AgencyNumber
        {
            get { return _agencyNumber; }
            private set
            {
                // Check if the agency number is in the correct format before setting the value
                if (IsValidAgencyNumber(value))
                {
                    _agencyNumber = value;
                }
                else
                {
                    throw new ArgumentException("Número da agência deve ter o formato XXXX-X.");
                }
            }
        }

        // Constructor to initialize the agency with a valid number
        public Agency(int? agencyNumber)
        {
            AgencyNumber = agencyNumber;
        }

        // Validation method to check if the agency number is in the correct format
        private bool IsValidAgencyNumber(int? agencyNumber)
        {
            if (agencyNumber.HasValue)
            {
                string pattern = @"^\d{4}-\d$";
                return Regex.IsMatch(agencyNumber.ToString(), pattern);
            }
            return false;
        }


    }
}
