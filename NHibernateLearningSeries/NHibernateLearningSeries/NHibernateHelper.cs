using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using NHibernateLearningSeries.Domain;

namespace NHibernateLearningSeries
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = CreateSessionFactory();
                }

                return sessionFactory;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return
                Fluently.Configure().Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        @"Server=.\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=true"))
                //.Mappings(m =>
                //          m.AutoMappings.Add(CreateAutomappings).ExportTo(@"C:\MappingFile.txt"))
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Department>()).ExposeConfiguration(BuildSchema).
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Department>())
                    .BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Department>(new DefaultAutomappingConfiguration());
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            //new SchemaExport(config)
            //    .Create(false, true);

            //new SchemaExport(config).SetOutputFile(@"C:\Test.sql").Create(true, true);
            new SchemaExport(config).Create(true, true);
        }
    }
}