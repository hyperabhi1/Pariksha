using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf.qrcode;

namespace Pariksha
{
    static class Common
    {
        public static Tuple<DataTable,List<DataTable>> ConvertKeyValuePairToDataTable(List<KeyValuePair<string, string>> pairs)
        {
            DataTable metaDataTable = new DataTable();
            metaDataTable.Columns.Add("QNo", typeof(string));
            metaDataTable.Columns.Add("Ans", typeof(string));
            List<DataTable> tables = new List<DataTable>();
            DataTable table1 = new DataTable();
            table1.Columns.Add("QNo", typeof(string));
            table1.Columns.Add("Ans", typeof(string));
            for (int i = 0; i < 25; i++)
            {
                table1.Rows.Add((i + 1), "");
            }

            DataTable table2 = new DataTable();
            table2.Columns.Add("QNo", typeof(string));
            table2.Columns.Add("Ans", typeof(string));
            for (int i = 25; i < 50; i++)
            {
                table2.Rows.Add((i + 1), "");
            }

            DataTable table3 = new DataTable();
            table3.Columns.Add("QNo", typeof(string));
            table3.Columns.Add("Ans", typeof(string));
            for (int i = 50; i < 75; i++)
            {
                table3.Rows.Add((i + 1), "");
            }

            DataTable table4 = new DataTable();
            table4.Columns.Add("QNo", typeof(string));
            table4.Columns.Add("Ans", typeof(string));
            for (int i = 75; i < 100; i++)
            {
                table4.Rows.Add((i + 1), "");
            }
            tables.Add(table1);
            tables.Add(table2);
            tables.Add(table3);
            tables.Add(table4);

            for (int i = 0; i < pairs.Count; i++)
            {
                metaDataTable.Rows.Add((i + 1), pairs[i].Key.ToUpper());
            }

            return Tuple.Create(metaDataTable,tables);
        }
        public static Tuple<bool,string> ConvertPdf2Txt(string filePath)
        {
            var sb = new StringBuilder();
            var isParsed = false;
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    string prevPage = "";
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                        var s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                        if (prevPage != s) sb.Append(s);
                        prevPage = s;
                    }
                    reader.Close();
                }
                isParsed = true;
            }
            
            catch (Exception ex)
            {
                isParsed = false;
            }
            return Tuple.Create(isParsed, sb.ToString());
        }

        public static string PutCommaBetweenNDigits(this string bytes, int n)
        {
            var result = string.Empty;
            int x = 0;
            for (int i = bytes.Length - 1; i > -1; i--)
            {
                if (x != 0 && x % n == 0)
                    result = result + "," + bytes[i];
                else
                    result = result + bytes[i];
                x++;
            }

            return string.Join("", result.Reverse());
        }

        public static string ConvertModelsToHtml(Models models)
        {
            StringBuilder htmlString = new StringBuilder();

            StringBuilder answertable = new StringBuilder();

            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            var sb3 = new StringBuilder();
            var sb4 = new StringBuilder();

            string greenColor = " style='background-color: chartreuse;' ";
            string redColor = " style='background-color: orangered;' ";
            string greyColor = " style='background-color: lightgray;' ";

            htmlString.AppendLine("<!DOCTYPE html>");
            htmlString.AppendLine("<html>");
            htmlString.AppendLine("<body style='text-align:center;'>");
            htmlString.AppendLine("    <h2 style='font-size:50px;text-decoration: underline;'>Answer Sheet Report</h2><br>");
            htmlString.AppendLine("    <div>");
            htmlString.AppendLine("        <div>");
            htmlString.AppendLine("            <table border=1 style='display: inline-block;font-size: x-large;'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:75px;background-color: darkgray;font-weight: bold;'>QNo</th>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:50px;background-color: darkgray;font-weight: bold;'>Ans</th>");
            htmlString.AppendLine("                </tr>");
            
            for (int i = 0; i < 25; i++)
            {
                var color = (models.AnswerSheet[i] == 0) ? greyColor : ((models.AnswerSheet[i] == 1) ? greenColor : redColor);
                htmlString.AppendLine("                <tr>");
                htmlString.AppendLine($"                    <td {color}>{i + 1}</td>");
                htmlString.AppendLine($"                    <td>{models.submittedAnswers[i]}</td>");
                htmlString.AppendLine("                </tr>");
            }

            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("            <table border=1 style='display: inline-block;font-size: x-large;'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:75px;background-color: darkgray;font-weight: bold;'>QNo</th>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:50px;background-color: darkgray;font-weight: bold;'>Ans</th>");
            htmlString.AppendLine("                </tr>");

            for (int i = 25; i < 50; i++)
            {
                var color = (models.AnswerSheet[i] == 0) ? greyColor : ((models.AnswerSheet[i] == 1) ? greenColor : redColor);
                htmlString.AppendLine("                <tr>");
                htmlString.AppendLine($"                    <td {color}>{i + 1}</td>");
                htmlString.AppendLine($"                    <td>{models.submittedAnswers[i]}</td>");
                htmlString.AppendLine("                </tr>");
            }

            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("            <table border=1 style='display: inline-block;font-size: x-large;'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:75px;background-color: darkgray;font-weight: bold;'>QNo</th>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:50px;background-color: darkgray;font-weight: bold;'>Ans</th>");
            htmlString.AppendLine("                </tr>");


            for (int i = 50; i < 75; i++)
            {
                var color = (models.AnswerSheet[i] == 0) ? greyColor : ((models.AnswerSheet[i] == 1) ? greenColor : redColor);
                htmlString.AppendLine("                <tr>");
                htmlString.AppendLine($"                    <td {color}>{i + 1}</td>");
                htmlString.AppendLine($"                    <td>{models.submittedAnswers[i]}</td>");
                htmlString.AppendLine("                </tr>");
            }

            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("            <table border=1 style='display: inline-block;font-size: x-large;'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:75px;background-color: darkgray;font-weight: bold;'>QNo</th>");
            htmlString.AppendLine("                    <th style='text-align:center;height:10px;width:50px;background-color: darkgray;font-weight: bold;'>Ans</th>");
            htmlString.AppendLine("                </tr>");


            for (int i = 75; i < 100; i++)
            {
                var color = (models.AnswerSheet[i] == 0) ? greyColor : ((models.AnswerSheet[i] == 1) ? greenColor : redColor);
                htmlString.AppendLine("                <tr>");
                htmlString.AppendLine($"                    <td {color}>{i + 1}</td>");
                htmlString.AppendLine($"                    <td>{models.submittedAnswers[i]}</td>");
                htmlString.AppendLine("                </tr>");
            }

            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("        </div>");
            htmlString.AppendLine("        <br>");
            htmlString.AppendLine("        <div style='margin: auto; width: 30%; padding: 10px;'>");
            htmlString.AppendLine("            <table border='3' style='text-align:center'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <th style='text-align: center; font-size: x-large; height: 25px; width: 405px; vertical-align: middle;'>Total correct answers</th>");
            htmlString.AppendLine("                    <th style='text-align: center; font-size: x-large; height: 10px; width: 135px; background-color: chartreuse;'>" + models.Score.Correct + "</th>");
            htmlString.AppendLine("                </tr>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <td style='text-align: center; font-size: x-large; height: 25px; width: 405px; vertical-align: middle;'>Total incorrect answers</td>");
            htmlString.AppendLine("                    <td style='font-size: x-large; background-color: orangered'>" + models.Score.InCorrect + "</td>");
            htmlString.AppendLine("                </tr>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <td style='text-align:center;height: 25px;width:405px;font-size: x-large;vertical-align: middle;'>Total skipped answers</td>");
            htmlString.AppendLine("                    <td style='font-size: x-large; background-color: lightgray;'>" + models.Score.Skipped + "</td>");
            htmlString.AppendLine("                </tr>");
            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("        </div>");
            htmlString.AppendLine("        <br>");
            htmlString.AppendLine("        <div style='margin: auto; width: 30%; padding: 10px;'>");
            htmlString.AppendLine("            <table border='3' style='text-align:center'>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <td rowspan=2 style='text-align:center;height: 25px;width:405px;font-size: x-large;vertical-align: middle;'>Total score</td>");
            htmlString.AppendLine("                    <td style='text-align:center;font-size: x-large;height:10px;width:135px;background-color: yellow;'>" + models.Score.MarksObtained + "</td>");
            htmlString.AppendLine("                </tr>");
            htmlString.AppendLine("                <tr>");
            htmlString.AppendLine("                    <td style='font-size: x-large; background-color: yellow'>");
            htmlString.AppendLine("                        200");
            htmlString.AppendLine("                    </td>");
            htmlString.AppendLine("                </tr>");
            htmlString.AppendLine("            </table>");
            htmlString.AppendLine("        </div>");
            htmlString.AppendLine("    </div>");
            htmlString.AppendLine("    <br>");
            htmlString.AppendLine("</body>");
            htmlString.AppendLine("</html>");

            return htmlString.ToString();
        }
    }
}
