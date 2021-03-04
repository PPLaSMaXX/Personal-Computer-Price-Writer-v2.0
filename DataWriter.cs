using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PCPW2
{
    class DataWriter
    {
        DateTime date = DateTime.Now;
        public bool WriteToFIle(List<ParsedProduct> products, string saveFilePath)
        {
            if (isWritten(saveFilePath)) return false;

            int sum = 0;
            string completedLine, prepearedString = "";
            for (int i = 0; i < products.Count; i++)
            {
                prepearedString += products[i].price.ToString() + ";";
                sum += products[i].price;
            }
            prepearedString += sum.ToString() + ";";

            completedLine = csvLineMaker(prepearedString);

            try
            {
                File.AppendAllText(saveFilePath, completedLine);
                return true;
            }
            catch
            {
                MessageBox.Show("Error: Can't write data to file, close him if opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool isWritten(string saveFilePath)
        {
            if (!File.Exists(saveFilePath)) return true;
            try
            {
                string input = File.ReadAllText(saveFilePath);
                return input.Contains(date.Day + "." + date.Month + "." + date.Year + ";");
            }
            catch
            {
                MessageBox.Show("Error: Can't get access to file, close him if opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private string csvLineMaker(string input)
        {
            StringBuilder csv = new StringBuilder();
            csv.Append(string.Format(date.Day + "." + date.Month + "." + date.Year + ";" + input));
            csv.AppendLine();
            return csv.ToString();
        }
    }
}