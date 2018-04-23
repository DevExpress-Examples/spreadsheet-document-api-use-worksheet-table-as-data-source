using DevExpress.Snap.Core.API;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Windows.Forms;

namespace SpreadsheetDocumentServerAsDataSourceExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            #region #datasource
            DevExpress.Spreadsheet.Workbook wb = 
                new DevExpress.Spreadsheet.Workbook();
            wb.LoadDocument("Employees.xlsx");
            DevExpress.Spreadsheet.RangeDataSourceOptions options = 
                new DevExpress.Spreadsheet.RangeDataSourceOptions();
            options.UseFirstRowAsHeader = true;
            options.CellValueConverter = new MyPictureProvider(wb.Worksheets[0]);
            options.DataSourceColumnTypeDetector = new MyColumnDetector();
            string dsName = wb.Worksheets[0].Tables[0].Name;
            object ds = wb.Worksheets[0].Tables[0].GetDataSource(options);
            snapControl1.DataSources.Add(dsName, ds);
            #endregion #datasource

            snapControl1.CreateNewDocument();
            SnapList list = snapControl1.Document.CreateSnList(snapControl1.Document.Range.End, "EmployeeList");

            list.BeginUpdate();
            list.DataSourceName = dsName;

            SnapDocument listHeader = list.ListHeader;
            Table listHeaderTable = listHeader.Tables.Create(listHeader.Range.End, 1, 3);
            TableCellCollection listHeaderCells = listHeaderTable.FirstRow.Cells;
            listHeader.InsertText(listHeaderCells[0].ContentRange.End, "First Name");
            listHeader.InsertText(listHeaderCells[1].ContentRange.End, "Last Name");
            listHeader.InsertText(listHeaderCells[2].ContentRange.End, "Photo");

            SnapDocument listRow = list.RowTemplate;
            Table listRowTable = listRow.Tables.Create(listRow.Range.End, 1, 3);
            TableCellCollection listRowCells = listRowTable.FirstRow.Cells;
            listRow.CreateSnText(listRowCells[0].ContentRange.End, "\"First Name\"");
            listRow.CreateSnText(listRowCells[1].ContentRange.End, "\"Last Name\"");
            listRow.CreateSnImage(listRowCells[2].ContentRange.End, "Photo");

            list.EndUpdate();

            list.Field.Update();
        }
        
    }
}
