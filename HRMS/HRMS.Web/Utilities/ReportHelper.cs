using OfficeOpenXml;

namespace HRMS.Web.Utilities {
    public static class ReportHelper {
        public static byte[] ExportToExcel<T>(IList<T> data, string fileName) where T : class {
            using ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(fileName);
            worksheet.Cells["A1"].LoadFromCollection(data, true, OfficeOpenXml.Table.TableStyles.Light1);
            return package.GetAsByteArray();
        }
    }
}
