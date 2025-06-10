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
            //        Console.Write("CSV file path: ");
            //        var path = Console.ReadLine();
            //        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            //        {
            //            Console.WriteLine("File not found.\n");
            //            return;
            //        }

            //        int count = 0;
            //        using var reader = new StreamReader(path);
            //        string  header = reader.ReadLine();
            //        if (header == null)
            //        {
            //            Console.WriteLine("CSV is empty.\n");
            //            return;
            //        }

            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            if (string.IsNullOrWhiteSpace(line)) continue;
            //            var parts = line.Split(',');
            //            if (parts.Length < 3) continue;

            //            var reporterName = parts[0].Trim();
            //            var targetName = parts[1].Trim();
            //            var text = parts[2].Trim();
            //            DateTime? ts = null;
            //            if (parts.Length >= 4)
            //            {
            //                DateTime parsedDate;
            //                if (DateTime.TryParse(parts[3].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out parsedDate))
            //                    ts = parsedDate;
            //            }

            //            if (string.IsNullOrWhiteSpace(reporterName) || string.IsNullOrWhiteSpace(targetName) || string.IsNullOrWhiteSpace(text))
            //                continue;

            //            int reporterId = Utils.Helpers.GetOrCreatePerson(reporterName);
            //            int targetId = Utils.Helpers.GetOrCreatePerson(targetName);

            //            Reports newReport = new Reports(reporterId, targetId, text);
            //            DelReports.InsertNewReport(newReport);

            //            count++;
            //        }

            //        Logger.Log($"CSVImport: Imported {count} reports from {path}");
            //        Console.WriteLine($"Imported {count} reports.\n");
            //    }
        }
    }
}