using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PCPW2
{
    class DataWriter
    {
        static DateTime date = DateTime.Now;
        static public bool WriteToFIle(List<ParsedProduct> products, string saveFilePath)
        {
            //checking is file was Written
            if (IsWritten(saveFilePath))
            {
                MessageBox.Show("Already Done", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int sum = 0;
            string completedLine, prepearedString = "";

            //adding all to one string which wiil be line in csv
            for (int i = 0; i < products.Count; i++)
            {
                prepearedString += products[i].Price.ToString() + ";";
                sum += products[i].Price;
            }
            prepearedString += sum.ToString() + ";";

            //making complete line which 
            completedLine = CsvLineMaker(prepearedString);

            try
            {
                //Writing
                File.AppendAllText(saveFilePath, completedLine);
                return true;
            }
            catch
            {
                //data write error
                MessageBox.Show("Error: Can't write data to file, close it if opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static private bool IsWritten(string saveFilePath)
        {
            if (!File.Exists(saveFilePath)) return false;
            try
            {
                string input = File.ReadAllText(saveFilePath);
                return input.Contains(date.Day + "." + date.Month + "." + date.Year + ";");
            }
            catch
            {
                MessageBox.Show("Error: Can't get access to file, close it if opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static private string CsvLineMaker(string input)
        {
            StringBuilder csv = new StringBuilder();
            csv.Append(string.Format(date.Day + "." + date.Month + "." + date.Year + ";" + input));
            csv.AppendLine();
            return csv.ToString();
        }
    }
}