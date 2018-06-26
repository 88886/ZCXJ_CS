using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;

namespace ZCXJ_CS.Utilities
{
    public interface IDBHelper
    {
        DataSet GetDataSet(string sql);

        DataTable GetDataTable(string sql);

        DataRow GetDataRow(string cmdText);

        DbDataReader ExecuteReader(string sql);

        int ExecuteNonQuery(string sql);

        int ExecuteNonQueryBatch(string sql);

        object ExecuteScalar(string sql);

        void ChangeConnString(string connStr);

    }
}
