using System;
using System.Collections.Generic;
using System.Linq;
using BenefitsCalculator.Data;
using BenefitsCalculator.Services.Interfaces;

namespace BenefitsCalculator.Services.Implementation
{
    public class Benefits : IBenefits
    {
        private const decimal EmployeeCost = 1000;
        private const decimal DependentCost = 500;
        private const decimal Discount = 0.1M;

        public IEnumerable<Family> Deduct(IEnumerable<Family> families)
        {
            if (families == null) { return Array.Empty<Family>(); }

            families = families.ToArray();

            foreach (Family family in families)
            {
                foreach (Person person in family.Members)
                {
                    person.Deduction = person.Type switch
                    {
                        PersonType.Employee => EmployeeCost,
                        PersonType.Dependent => DependentCost,
                        _ => 0.0M
                    };

                    if (person.Name.ToUpperInvariant().StartsWith('A'))
                    {
                        person.Deduction *= 1.0M - Discount;
                    }
                }
            }

            return families;
        }
    }
}