using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ZCXJ_CS.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZCXJ_CS.Repository
{
    public class TeamHandoverMap : EntityTypeConfiguration<TeamHandover>
    {
        public TeamHandoverMap()
        {
            HasKey(wt => wt.shiftId);
            Property(wt => wt.shiftId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(wt => wt.groupId).IsRequired();
            Property(wt => wt.deptId);
            Property(wt => wt.workshopId);
            Property(wt => wt.machineId);
            //Property(wt => wt.shiftId).HasMaxLength(20);
            Property(wt => wt.handoverTime);
            Property(wt => wt.handTeamLeader).HasMaxLength(64);
            Property(wt => wt.handTeamNo).HasMaxLength(32);
            Property(wt => wt.handPersons).HasMaxLength(500);
            Property(wt => wt.handShift).HasMaxLength(32);
            Property(wt => wt.receiveTeamLeader).HasMaxLength(64);
            Property(wt => wt.receiveTeamNo).HasMaxLength(32);
            Property(wt => wt.receiveShift).HasMaxLength(32);
            Property(wt => wt.receiveTime);
            Property(wt => wt.receivePersons).HasMaxLength(500);
            Property(wt => wt.describe).HasMaxLength(500);
            Property(wt => wt.json).HasMaxLength(500);
        }
    }
}
