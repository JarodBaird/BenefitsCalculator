using System.Collections.Generic;
using System.Linq;

namespace BenefitsCalculator.Data
{
    public class Family
    {
        public string Name { get; set; }
        public decimal TotalDeduction => Members.Sum(m => m.Deduction);
        public IEnumerable<Person> Members { get; set; } = new List<Person>();
    }
}
