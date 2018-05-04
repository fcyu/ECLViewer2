using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ECLViewer.IO
{
    class ParseResult
    {

        private DataTable resultTD = new DataTable();
        private HashSet<int> indexSet = new HashSet<int>();

        public ParseResult(string result_path)
        {
            resultTD.Clear();
            DataColumn dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Int32");
            dataColumn.ColumnName = "scan_num";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "spectrum_id";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "spectrum_mz";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "spectrum_mass";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "peptide_mass";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "rt";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Int32");
            dataColumn.ColumnName = "C13_correction";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Int32");
            dataColumn.ColumnName = "charge";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "score";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "delta_C";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "ppm";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "peptide";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "protein";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "e_value";
            resultTD.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.Double");
            dataColumn.ColumnName = "q_value";
            resultTD.Columns.Add(dataColumn);

            string[] text = File.ReadAllLines(result_path);
            if (text[0].StartsWith("scan_num"))
            {
                // ECL2 results
                for (int i = 1; i < text.Length; ++i)
                {
                    string[] parts = Regex.Split(text[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    DataRow dataRow = resultTD.NewRow();
                    dataRow["scan_num"] = int.Parse(parts[0], new CultureInfo("en-US"));
                    indexSet.Add(int.Parse(parts[0], new CultureInfo("en-US")));
                    dataRow["spectrum_id"] = parts[1];
                    dataRow["spectrum_mz"] = float.Parse(parts[2], new CultureInfo("en-US"));
                    dataRow["spectrum_mass"] = float.Parse(parts[3], new CultureInfo("en-US"));
                    dataRow["peptide_mass"] = float.Parse(parts[4], new CultureInfo("en-US"));
                    dataRow["rt"] = float.Parse(parts[5], new CultureInfo("en-US"));
                    dataRow["C13_correction"] = (int) float.Parse(parts[6], new CultureInfo("en-US"));
                    dataRow["charge"] = (int) float.Parse(parts[7], new CultureInfo("en-US"));
                    dataRow["score"] = float.Parse(parts[8], new CultureInfo("en-US"));
                    dataRow["delta_C"] = float.Parse(parts[9], new CultureInfo("en-US"));
                    dataRow["ppm"] = float.Parse(parts[10], new CultureInfo("en-US"));
                    dataRow["peptide"] = parts[11];
                    dataRow["protein"] = parts[12];
                    if (parts[15].Equals("-"))
                    {
                        dataRow["e_value"] = -1;
                    }
                    else
                    {
                        dataRow["e_value"] = float.Parse(parts[15], new CultureInfo("en-US"));
                    }

                    dataRow["q_value"] = float.Parse(parts[16], new CultureInfo("en-US"));

                    resultTD.Rows.Add(dataRow);
                }
            } else if (text[0].StartsWith("ScanNum"))
            {
                // todo: Xolik results
            }
        }

        public DataTable getDataTable()
        {
            return resultTD;
        }

        public HashSet<int> getScanNumSet()
        {
            return indexSet;
        }
    }
}
