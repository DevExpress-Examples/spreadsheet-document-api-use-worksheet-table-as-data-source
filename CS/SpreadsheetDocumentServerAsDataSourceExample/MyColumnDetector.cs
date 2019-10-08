using DevExpress.Spreadsheet;
using System;

namespace SpreadsheetDocumentServerAsDataSourceExample
{
    #region #MyColumnDetector
    class MyColumnDetector : IDataSourceColumnTypeDetector
    {
        public string GetColumnName(int index, int offset, CellRange range)
        {
            return range[-1, offset].DisplayText;
        }

        public Type GetColumnType(int index, int offset, CellRange range)
        {
            Type defaultType = typeof(string);

            if (offset == 13) return typeof(System.Drawing.Bitmap);

            CellValue value = range[0, offset].Value;
            if (value.IsText) return typeof(string);
            if (value.IsBoolean) return typeof(bool);
            if (value.IsDateTime) return typeof(DateTime);
            if (value.IsNumeric) return typeof(double);
            return defaultType;
        }
    }
    #endregion #MyColumnDetector
}