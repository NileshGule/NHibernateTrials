using System.Collections.Generic;

using NHibernate;

using NHibernateLearningSeries.Domain;

namespace NHibernateLearningSeries.Repository
{
    public class DepartmentRepository
    {
        public void AddDepartments(IList<Department> departments)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (Department department in departments)
                    {
                        session.SaveOrUpdate(department);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}