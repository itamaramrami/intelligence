using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using intelligence.DEL;
using intelligence.Models;
using intelligence.Utils.Loger;

namespace intelligence.Utils.CSV
{
    internal class ImportCSV
    {
        public static void ImportCsv()
        {
            int count = 0;

            try
            {
                var reader = new StreamReader("C:\\Users\\IMOE001\\Desktop\\c#\\intelligence\\sample_import.csv");

                string header = reader.ReadLine();
                if (header == null)
                {
                    Console.WriteLine("CSV is empty.\n");
                    return;
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine($"line{line}");

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');

                    if (parts.Length < 4) continue;

                    string reporter = parts[0];
                    string target = parts[1];
                    string text = parts[2];
                    string timePart = parts[3];
                    
                    

                    if (!DateTime.TryParse(timePart, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var ts)) continue;
                    if (string.IsNullOrWhiteSpace(reporter) || string.IsNullOrWhiteSpace(target) || string.IsNullOrWhiteSpace(text)) continue;

                    int reporterId = DelPeople.InsertRandomPerson(reporter);
                    int targetId = DelPeople.InsertRandomPerson(target);
                    if (reporterId == null || targetId == null) continue;

                    Reports rep = new Reports(reporterId, targetId, text);
                    DelReports.InsertNewReport(rep);
                    count++;
                }

                Logger.Log($"CSVImport: Imported {count} reports from sample_import.csv");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("⚠️ File not found. Make sure the path is correct.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error occurred: {ex.Message}");
            }
        }






    }

}