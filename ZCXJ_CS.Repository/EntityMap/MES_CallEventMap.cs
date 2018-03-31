using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ZCXJ_CS.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZCXJ_CS.Repository
{
    public class MES_CallEventMap : EntityTypeConfiguration<CallEvent>
    {
        public MES_CallEventMap()
        {
            HasKey(wt => wt.callId);
            Property(wt => wt.callId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
          
        }

    }
}
