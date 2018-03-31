using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ZCXJ_CS.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZCXJ_CS.Repository
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(wt => wt.userId);
            //Property(wt => wt.userId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            //    .IsRequired();
            Property(wt => wt.groupId).IsRequired();
            Property(wt => wt.deptId);
            Property(wt => wt.workshopId);
            Property(wt => wt.machineId);

            Property(wt => wt.userName).IsRequired().HasMaxLength(64);
            Property(wt => wt.cardNo).IsRequired().HasMaxLength(32);
            Property(wt => wt.password).HasMaxLength(64);
            //Property(wt => wt.roleList).HasMaxLength(500);
            Property(wt => wt.shift).HasMaxLength(32);
         
        }
    }
}
