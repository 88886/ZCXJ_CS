using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    class QualityRecordItemMap : EntityTypeConfiguration<QualityRecordItem>
    {
        public QualityRecordItemMap()
        {
            HasKey(bt => bt.indicatorsNo);
            Property(wt => wt.indicatorsNo).IsRequired().HasMaxLength(64);
            Property(wt => wt.qcNo).IsRequired().HasMaxLength(64);
            Property(bt => bt.indicatorsName).IsRequired().HasMaxLength(64);
            Property(bt => bt.measureMethod).IsRequired().HasMaxLength(64);
        }
    }
}
