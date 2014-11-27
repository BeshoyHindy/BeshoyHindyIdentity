using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace DAL.Extensions
{
    static public class ConvertDataTable
    {
        public static DataTable ToDataTable(this IQueryable query)
        {
            try
            {
                DataTable dtReturn = new DataTable();
                PropertyInfo[] columnProperties = null;

                foreach (var record in query)
                {
                    // use reflection to get column names for the table, only first time, others will follow
                    if (columnProperties == null)
                    {
                        columnProperties = record.GetType().GetProperties();
                        foreach (PropertyInfo propertyInfo in columnProperties)
                        {
                            // sort out the issue of nullable types
                            Type columnType = propertyInfo.PropertyType;
                            if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                columnType = columnType.GetGenericArguments()[0];
                            }

                            // add a column to the table
                            dtReturn.Columns.Add(new DataColumn(propertyInfo.Name, columnType));
                        }
                    }

                    DataRow dataRow = dtReturn.NewRow();

                    foreach (PropertyInfo propertyInfo in columnProperties)
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(record, null) == null ? DBNull.Value : propertyInfo.GetValue(record, null);
                    }

                    dtReturn.Rows.Add(dataRow);
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public static DataTable ToDataTable(this IQueryable query, string SortColName, string SortType)
        {
            try
            {
                DataTable dtReturn = new DataTable();
                PropertyInfo[] columnProperties = null;

                foreach (var record in query)
                {
                    // use reflection to get column names for the table, only first time, others will follow
                    if (columnProperties == null)
                    {
                        columnProperties = record.GetType().GetProperties();
                        foreach (PropertyInfo propertyInfo in columnProperties)
                        {
                            // sort out the issue of nullable types
                            Type columnType = propertyInfo.PropertyType;
                            if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                columnType = columnType.GetGenericArguments()[0];
                            }

                            // add a column to the table
                            dtReturn.Columns.Add(new DataColumn(propertyInfo.Name, columnType));
                        }
                    }

                    DataRow dataRow = dtReturn.NewRow();

                    foreach (PropertyInfo propertyInfo in columnProperties)
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(record, null) == null ? DBNull.Value : propertyInfo.GetValue(record, null);
                    }

                    dtReturn.Rows.Add(dataRow);
                }
                dtReturn.DefaultView.Sort = SortColName + " " + SortType;
                return dtReturn.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static DataTable ToDataTable(this IEnumerable query)
        {
            try
            {
                DataTable dtReturn = new DataTable();
                PropertyInfo[] columnProperties = null;

                foreach (var record in query)
                {
                    // use reflection to get column names for the table, only first time, others will follow
                    if (columnProperties == null)
                    {
                        columnProperties = record.GetType().GetProperties();
                        foreach (PropertyInfo propertyInfo in columnProperties)
                        {
                            // sort out the issue of nullable types
                            Type columnType = propertyInfo.PropertyType;
                            if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                columnType = columnType.GetGenericArguments()[0];
                            }

                            // add a column to the table
                            dtReturn.Columns.Add(new DataColumn(propertyInfo.Name, columnType));
                        }
                    }

                    DataRow dataRow = dtReturn.NewRow();

                    foreach (PropertyInfo propertyInfo in columnProperties)
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(record, null) == null ? DBNull.Value : propertyInfo.GetValue(record, null);
                    }

                    dtReturn.Rows.Add(dataRow);
                }

                return dtReturn;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static DataTable ToDataTable(this IEnumerable query, string SortColName, string SortType)
        {
            try
            {
                DataTable dtReturn = new DataTable();
                PropertyInfo[] columnProperties = null;

                foreach (var record in query)
                {
                    // use reflection to get column names for the table, only first time, others will follow
                    if (columnProperties == null)
                    {
                        columnProperties = record.GetType().GetProperties();
                        foreach (PropertyInfo propertyInfo in columnProperties)
                        {
                            // sort out the issue of nullable types
                            Type columnType = propertyInfo.PropertyType;
                            if ((columnType.IsGenericType) && (columnType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            {
                                columnType = columnType.GetGenericArguments()[0];
                            }

                            // add a column to the table
                            dtReturn.Columns.Add(new DataColumn(propertyInfo.Name, columnType));
                        }
                    }

                    DataRow dataRow = dtReturn.NewRow();

                    foreach (PropertyInfo propertyInfo in columnProperties)
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(record, null) == null ? DBNull.Value : propertyInfo.GetValue(record, null);
                    }

                    dtReturn.Rows.Add(dataRow);
                }
                dtReturn.DefaultView.Sort = SortColName + " " + SortType;
                return dtReturn.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

    }
}
