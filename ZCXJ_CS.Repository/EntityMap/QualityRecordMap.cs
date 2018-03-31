using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    class QualityRecordMap : EntityTypeConfiguration<QualityRecord>
    {
        public QualityRecordMap()
        {
            HasKey(bt => bt.qcNo);
            Property(wt => wt.qcNo).IsRequired().HasMaxLength(64);
            Property(wt => wt.planNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.prodNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.qcPlanNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.qcType).IsRequired().HasMaxLength(64);
            Property(bt => bt.turnoverNo).IsRequired().HasMaxLength(128);
            Property(bt => bt.prodType).IsRequired().HasMaxLength(64);
            Property(bt => bt.machineNo).IsRequired().HasMaxLength(64);
        }
    }
}
