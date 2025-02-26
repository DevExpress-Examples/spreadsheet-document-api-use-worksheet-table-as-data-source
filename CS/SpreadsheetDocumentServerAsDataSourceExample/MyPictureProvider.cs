using System;
using DevExpress.Spreadsheet;
using System.Collections.Generic;
using System.IO;
using DevExpress.Office.Utils;
using DevExpress.Drawing;

namespace SpreadsheetDocumentServerAsDataSourceExample
{
    #region #MyPictureProvider
    public class MyPictureProvider : IBindingRangeValueConverter
    {
        Dictionary<string, DXImage> pictures;

        public MyPictureProvider(Worksheet sheet)
        {
            pictures = GetPictures(sheet);
        }

        public object ConvertToObject(CellValue value, Type requiredType, int columnIndex)
        {
            if (columnIndex == 13)
            {
                DXImage pic;
                if (pictures.TryGetValue(value.TextValue, out pic))
                    return pic;
            }
            return value;
        }

        public CellValue TryConvertFromObject(object value)
        {
            return CellValue.Empty;
        }

        public Dictionary<string, DXImage> GetPictures(Worksheet sheet)
        {
            Dictionary<string, DevExpress.Drawing.DXImage> employeePictures = new Dictionary<string, DevExpress.Drawing.DXImage>();
            foreach (Picture pic in sheet.Pictures)
            {
                employeePictures.Add(pic.Name, DXImage.FromStream(new MemoryStream(pic.Image.GetImageBytes(OfficeImageFormat.Bmp))));
            }
            return employeePictures;
        }
    }
    #endregion #MyPictureProvider
}