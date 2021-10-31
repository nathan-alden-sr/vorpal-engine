// Copyright (c) Nathan Alden, Sr. and Contributors.
// Licensed under the MIT License (MIT). See LICENSE.md in the repository root for more information.

using System.Data;

namespace VorpalEngine.Samples.ConsoleHelpers;

public static class DataTableExtensions
{
    public static IEnumerable<DataColumn> Columns(this DataTable dataTable)
        => dataTable.Columns.Cast<DataColumn>();

    public static IEnumerable<DataRow> Rows(this DataTable dataTable)
        => dataTable.Rows.Cast<DataRow>();
}