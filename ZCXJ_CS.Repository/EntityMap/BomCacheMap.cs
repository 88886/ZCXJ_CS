using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    class BomCacheMap : EntityTypeConfiguration<BomCache>
    {
        public BomCacheMap()
        {
            HasKey(bt => bt.id);
            Property(wt => wt.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(bt => bt.planNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.dataType).IsRequired().HasMaxLength(64);
        }
    }
}
