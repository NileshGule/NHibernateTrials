using FluentNHibernate.Mapping;

using NHibernateLearningSeries.Domain;

namespace NHibernateLearningSeries.Mappings
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.DepartmentNumber);
            Map(x => x.DepartmentName);
            Map(x => x.Location);
        }
    }
}