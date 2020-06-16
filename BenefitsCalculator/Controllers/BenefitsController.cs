using System.Collections.Generic;
using BenefitsCalculator.Data;
using BenefitsCalculator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsCalculator.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly IBenefits _benefits;

        public BenefitsController(IBenefits benefits)
        {
            _benefits = benefits;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] IEnumerable<Family> families)
        {
            IEnumerable<Family> result = _benefits.Deduct(families);
            return Ok(result);
        }
    }
}