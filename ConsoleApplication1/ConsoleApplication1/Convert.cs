using System.Data;
using System.IO;

namespace ConsoleApplication1
{
    public class Convert
    {
        public string[] ConvertCSVtoDataTable(string strFilePath)
        {
            string CSVFilePathName = strFilePath;
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string first = Lines[0];
            return Lines;
            //string[] Fields;
            //Fields = Lines[0].Split(new char[] { ',' });
            //int Cols = Fields.GetLength(0);
            //DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            //for (int i = 0; i < Cols; i++)
            //    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            //DataRow Row;
            //for (int i = 1; i < Lines.GetLength(0); i++)
            //{

            //    //Row = dt.NewRow();
            //    //for (int f = 0; f < Cols; f++)
            //    //    Row[f] = Fields[f];
            //    //dt.Rows.Add(Row);
            //}
            //return dt;
            //DataTable dt = new DataTable();
            //using (StreamReader sr = new StreamReader(strFilePath))
            //{
            //    string[] headers = sr.ReadLine().Split(',');
            //    foreach (string header in headers)
            //    {
            //        dt.Columns.Add(header);
            //    }
            //    while (!sr.EndOfStream)
            //    {
            //        string[] rows = sr.ReadLine().Split(',');
            //        DataRow dr = dt.NewRow();
            //        for (int i = 0; i < headers.Length; i++)
            //        {
            //            dr[i] = rows[i];
            //        }
            //        dt.Rows.Add(dr);
            //    }

            //}
            //return dt;
        }
    }
}