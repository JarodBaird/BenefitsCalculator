using System;
using System.Collections.Generic;
using System.Linq;
using BenefitsCalculator.Data;
using BenefitsCalculator.Services.Implementation;
using Xunit;

namespace BenefitsCalculator.Tests
{
    public class BenefitsTests
    {
        private readonly Benefits _benefits;

        public BenefitsTests()
        {
            _benefits = new Benefits();
        }

        [Fact]
        public void Deduct_Null()
        {
            IEnumerable<Family> result = _benefits.Deduct(null);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Deduct_Empty()
        {
            IEnumerable<Family> result = _benefits.Deduct(Array.Empty<Family>());

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Deduct_Employee()
        {
            IEnumerable<Family> result = _benefits.Deduct(new List<Family> {
                new Family
                {
                    Members = new List<Person>
                    {
                        new Person { Name = "B", Type = PersonType.Employee }
                    },
                }
            });

            Person[] family = result.ElementAt(0).Members.ToArray();
            Assert.Equal(1000, family.ElementAt(0).Deduction);
        }

        [Fact]
        public void Deduct_Dependent()
        {
            IEnumerable<Family> result = _benefits.Deduct(new List<Family> {
                new Family
                {
                    Members = new List<Person>
                    {
                        new Person { Name = "B", Type = PersonType.Dependent }
                    },
                }
            });

            Person[] family = result.ElementAt(0).Members.ToArray();
            Assert.Equal(500, family.ElementAt(0).Deduction);
        }

        [Fact]
        public void Deduct_ANamedEmployeeDiscount()
        {
            IEnumerable<Family> result = _benefits.Deduct(new List<Family> {
                new Family
                {
                    Members = new List<Person>
                    {
                        new Person{ Name = "A test", Type = PersonType.Employee },
                        new Person{ Name = "a test", Type = PersonType.Employee }
                    },
                }
            });

            Person[] family = result.ElementAt(0).Members.ToArray();
            Assert.Equal(900, family.ElementAt(0).Deduction);
            Assert.Equal(900, family.ElementAt(1).Deduction);
        }


        [Fact]
        public void Deduct_ANamedDependentDiscount()
        {
            IEnumerable<Family> result = _benefits.Deduct(new List<Family> {
                new Family
                {
                    Members = new List<Person>
                    {
                        new Person{ Name = "A test", Type = PersonType.Dependent },
                        new Person{ Name = "a test", Type = PersonType.Dependent }
                    },
                }
            });

            Person[] family = result.ElementAt(0).Members.ToArray();
            Assert.Equal(450, family.ElementAt(0).Deduction);
            Assert.Equal(450, family.ElementAt(1).Deduction);
        }

        [Fact]
        public void Deduct_Complex()
        {
            IEnumerable<Family> result = _benefits.Deduct(new List<Family> {
                new Family
                {
                    Members = new List<Person>
                    {
                        new Person{ Name = "A test", Type = PersonType.Employee },
                        new Person{ Name = "B test", Type = PersonType.Employee },
                        new Person{ Name = "a test", Type = PersonType.Dependent },
                        new Person{ Name = "b test", Type = PersonType.Dependent },
                    },
                }
            });

            Family family = result.ElementAt(0);
            Assert.Equal(2850, family.TotalDeduction);
            Assert.Equal(900, family.Members.ElementAt(0).Deduction);
            Assert.Equal(1000, family.Members.ElementAt(1).Deduction);
            Assert.Equal(450, family.Members.ElementAt(2).Deduction);
            Assert.Equal(500, family.Members.ElementAt(3).Deduction);
        }
    }
}