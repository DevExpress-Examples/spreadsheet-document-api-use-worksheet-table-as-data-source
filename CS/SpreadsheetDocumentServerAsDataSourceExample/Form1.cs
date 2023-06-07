using DevExpress.Office.Utils;
using DevExpress.Spreadsheet;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SpreadsheetDocumentServerAsDataSourceExample
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Workbook wb = new Workbook())
            {
                wb.LoadDocument("Employees.xlsx");
                RangeDataSourceOptions options = new RangeDataSourceOptions();
                options.UseFirstRowAsHeader = true;
                options.CellValueConverter = new MyPictureProvider(wb.Worksheets[0]);
                options.DataSourceColumnTypeDetector = new MyColumnDetector();
                string dsName = wb.Worksheets[0].Tables[0].Name;

                var document = richEditControl1.Document;
                RangeDataSource rows = wb.Worksheets[0].Tables[0].GetDataSource(options) as RangeDataSource;
                var columns = rows[0].GetProperties();
                List<PropertyDescriptor> columnsToDisplay = new List<PropertyDescriptor>()
                    {
                        columns.Find("First Name", false),
                        columns.Find("Last Name", false),
                        columns.Find("Photo", false)
                    };
                document.BeginUpdate();

                var table = InitTable(document, rows.Count, columnsToDisplay.Count);

                FillTable(document, table, rows, columnsToDisplay);

                document.EndUpdate();
            }
        }
        DevExpress.XtraRichEdit.API.Native.Table InitTable(Document document, int rowsCount, int columnsCount)
        {
            DevExpress.XtraRichEdit.API.Native.Table table = document.Tables.Create(document.Range.End, rowsCount + 1, columnsCount, AutoFitBehaviorType.FixedColumnWidth);

            table.TableLayout = TableLayoutType.Fixed;

            table.Borders.InsideHorizontalBorder.LineColor = Color.DarkBlue;
            table.Borders.InsideVerticalBorder.LineColor = Color.DarkBlue;
            table.Borders.InsideHorizontalBorder.LineThickness = 0.5f;
            table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Single;
            table.Borders.InsideVerticalBorder.LineThickness = 0.5f;
            table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Single;

            table.LeftPadding = Units.InchesToDocumentsF(0.01f);

            table.FirstRow.Height = Units.InchesToDocumentsF(0.5f);
            table.FirstRow.HeightType = HeightType.Exact;

            ParagraphProperties pp = document.BeginUpdateParagraphs(table.FirstRow.Range);
            pp.Alignment = ParagraphAlignment.Center;
            document.EndUpdateParagraphs(pp);

            CharacterProperties cp = document.BeginUpdateCharacters(table.FirstRow.Range);
            cp.FontName = "Courier New";
            cp.ForeColor = Color.White;
            document.EndUpdateCharacters(cp);

            for (int i = 0; i < table.FirstRow.Cells.Count; i++)
            {
                table.FirstRow.Cells[i].BackgroundColor = Color.DarkBlue;
                table.FirstRow.Cells[i].VerticalAlignment = TableCellVerticalAlignment.Center;
            }
            return table;
        }
        void FillTable(Document document, DevExpress.XtraRichEdit.API.Native.Table table, RangeDataSource rows, List<PropertyDescriptor> columns)
        {
            // Fill table header with column names
            for (int i = 0; i < columns.Count; i++)
            {
                document.InsertText(table[0, i].Range.Start, columns[i].DisplayName);
            }
            // Fill table body with data
            table.ForEachCell(delegate (TableCell cell, int rowIndex, int cellIndex)
            {
                switch (cellIndex)
                {
                    case 0:
                        cell.PreferredWidth = 200;
                        break;
                    case 1:
                        cell.PreferredWidth = 300;
                        break;
                    case 2:
                        cell.PreferredWidth = 500;
                        break;
                }
                if (rowIndex > 0)
                {
                    var row = rows[rowIndex - 1];
                    var value = columns[cellIndex].GetValue(row);
                    if (value is Bitmap bitmap)
                        document.Images.Insert(cell.Range.Start, bitmap);
                    else
                        document.InsertText(cell.Range.Start, (columns[cellIndex].GetValue(row) as CellValue).TextValue);
                }
            });
        }
    }
}
