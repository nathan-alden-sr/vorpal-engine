using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NathanAldenSr.VorpalEngine.Samples.ConsoleHelpers
{
    public static class DataTableExtensions
    {
        public static IEnumerable<DataColumn> Columns(this DataTable dataTable) => dataTable.Columns.Cast<DataColumn>();
        public static IEnumerable<DataRow> Rows(this DataTable dataTable) => dataTable.Rows.Cast<DataRow>();
    }
}