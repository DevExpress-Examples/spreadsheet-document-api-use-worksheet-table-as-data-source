Imports DevExpress.Snap.Core.API
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Windows.Forms

Namespace SpreadsheetDocumentServerAsDataSourceExample
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
'            #Region "#datasource"
            Dim wb As New DevExpress.Spreadsheet.Workbook()
            wb.LoadDocument("Employees.xlsx")
            Dim options As New DevExpress.Spreadsheet.RangeDataSourceOptions()
            options.UseFirstRowAsHeader = True
            options.CellValueConverter = New MyPictureProvider(wb.Worksheets(0))
            options.DataSourceColumnTypeDetector = New MyColumnDetector()
            Dim dsName As String = wb.Worksheets(0).Tables(0).Name
            Dim ds As Object = wb.Worksheets(0).Tables(0).GetDataSource(options)
            snapControl1.DataSources.Add(dsName, ds)
'            #End Region ' #datasource

            snapControl1.CreateNewDocument()
            Dim list As SnapList = snapControl1.Document.CreateSnList(snapControl1.Document.Range.End, "EmployeeList")

            list.BeginUpdate()
            list.DataSourceName = dsName

            Dim listHeader As SnapDocument = list.ListHeader
            Dim listHeaderTable As Table = listHeader.Tables.Create(listHeader.Range.End, 1, 3)
            Dim listHeaderCells As TableCellCollection = listHeaderTable.FirstRow.Cells
            listHeader.InsertText(listHeaderCells(0).ContentRange.End, "First Name")
            listHeader.InsertText(listHeaderCells(1).ContentRange.End, "Last Name")
            listHeader.InsertText(listHeaderCells(2).ContentRange.End, "Photo")

            Dim listRow As SnapDocument = list.RowTemplate
            Dim listRowTable As Table = listRow.Tables.Create(listRow.Range.End, 1, 3)
            Dim listRowCells As TableCellCollection = listRowTable.FirstRow.Cells
            listRow.CreateSnText(listRowCells(0).ContentRange.End, """First Name""")
            listRow.CreateSnText(listRowCells(1).ContentRange.End, """Last Name""")
            listRow.CreateSnImage(listRowCells(2).ContentRange.End, "Photo")

            list.EndUpdate()

            list.Field.Update()
        End Sub

    End Class
End Namespace
