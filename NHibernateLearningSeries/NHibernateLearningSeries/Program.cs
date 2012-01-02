using System.Collections.Generic;

using NHibernateLearningSeries.DataGenerators;
using NHibernateLearningSeries.Domain;
using NHibernateLearningSeries.Repository;

namespace NHibernateLearningSeries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Department> departments = new DepartmentGenerator().GenerateDepartments(20);

            DepartmentRepository departmentRepository = new DepartmentRepository();

            departmentRepository.AddDepartments(departments);
        }
    }
}