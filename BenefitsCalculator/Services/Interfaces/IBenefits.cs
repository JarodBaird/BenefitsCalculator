using System.Collections.Generic;
using BenefitsCalculator.Data;

namespace BenefitsCalculator.Services.Interfaces
{
    public interface IBenefits
    {
        IEnumerable<Family> Deduct(IEnumerable<Family> families);
    }
}