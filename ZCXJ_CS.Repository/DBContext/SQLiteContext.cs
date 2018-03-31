using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SQLite.CodeFirst;
using System.Data.Entity.ModelConfiguration.Conventions;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext() : base("ZCXJ_CS_DB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
            var sqliteInitializer = new MyDbInitializer(modelBuilder);
            Database.SetInitializer(sqliteInitializer);

            modelBuilder.Configurations.Add(new WorkTicketMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TeamHandoverMap());
            modelBuilder.Configurations.Add(new BomTechMap());
            modelBuilder.Configurations.Add(new BomCacheMap());
            modelBuilder.Configurations.Add(new TurnOverCardMap());
            modelBuilder.Configurations.Add(new MES_CallEventMap());
            modelBuilder.Configurations.Add(new QualityRecordItemMap());
            modelBuilder.Configurations.Add(new QualityStandardMap());
            modelBuilder.Configurations.Add(new QualityRecordMap());
            base.OnModelCreating(modelBuilder);
        }


    }

    public class MyDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<SQLiteContext>
    {
        public MyDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        protected override void Seed(SQLiteContext context)
        {
            base.Seed(context);
        }
    }

}
