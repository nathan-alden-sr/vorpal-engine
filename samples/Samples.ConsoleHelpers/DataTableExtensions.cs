// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VorpalEngine.Samples.ConsoleHelpers;

public static class DataTableExtensions
{
    public static IEnumerable<DataColumn> Columns(this DataTable dataTable)
        => dataTable.Columns.Cast<DataColumn>();

    public static IEnumerable<DataRow> Rows(this DataTable dataTable)
        => dataTable.Rows.Cast<DataRow>();
}