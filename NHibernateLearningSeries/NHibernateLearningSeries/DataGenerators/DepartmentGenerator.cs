using System.Collections.Generic;

using FizzWare.NBuilder;

using NHibernateLearningSeries.Domain;

namespace NHibernateLearningSeries.DataGenerators
{
    public class DepartmentGenerator
    {
        public IList<Department> GenerateDepartments(int requiredNumber)
        {
            SequentialGenerator<int> sequentialGenerator = new SequentialGenerator<int>
                {
                    Direction = GeneratorDirection.Ascending,
                    Increment = 1
                };

            sequentialGenerator.StartingWith(1);

            IList<Department> departments =
                Builder<Department>.CreateListOfSize(requiredNumber).All().With(
                    x => x.DepartmentNumber = string.Concat("P", sequentialGenerator.Generate())).Build();

            return departments;
        }
    }
}