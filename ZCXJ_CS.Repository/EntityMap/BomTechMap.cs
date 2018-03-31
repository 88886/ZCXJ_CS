using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    class BomTechMap : EntityTypeConfiguration<BomTech>
    {
        public BomTechMap()
        {
            HasKey(bt => bt.id);
            Property(wt => wt.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(bt => bt.techNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.prodNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.machineNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.dataType).IsRequired().HasMaxLength(64);
            //Property(bt => bt.dataJson).HasColumnType("text");
        }
    }
}
