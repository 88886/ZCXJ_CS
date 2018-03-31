using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    class QualityStandardMap : EntityTypeConfiguration<QualityStandard>
    {
        public QualityStandardMap()
        {
            HasKey(bt => bt.indicatorsNo);
            Property(wt => wt.indicatorsNo).IsRequired();
            Property(wt => wt.machineNo).IsRequired();
            Property(wt => wt.prodNo).IsRequired();
            Property(bt => bt.indicatorsName).IsRequired().HasMaxLength(64);
            Property(bt => bt.measureMethod).IsRequired().HasMaxLength(64);
        }
    }
}
