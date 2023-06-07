Imports DevExpress.Office.Utils
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraSpreadsheet.Model
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing

Namespace SpreadsheetDocumentServerAsDataSourceExample
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Using wb As Workbook = New Workbook()
                wb.LoadDocument("Employees.xlsx")
                Dim options As RangeDataSourceOptions = New RangeDataSourceOptions()
                options.UseFirstRowAsHeader = True
                options.CellValueConverter = New MyPictureProvider(wb.Worksheets(0))
                options.DataSourceColumnTypeDetector = New MyColumnDetector()
                Dim dsName As String = wb.Worksheets(0).Tables(0).Name

                Dim document = RichEditControl1.Document
                Dim rows As RangeDataSource = TryCast(wb.Worksheets(0).Tables(0).GetDataSource(options), RangeDataSource)
                Dim columns = rows(0).GetProperties()
                Dim columnsToDisplay As List(Of PropertyDescriptor) = New List(Of PropertyDescriptor)() From {
                        columns.Find("First Name", False),
                        columns.Find("Last Name", False),
                        columns.Find("Photo", False)
                }
                document.BeginUpdate()

                Dim table = InitTable(document, rows.Count, columnsToDisplay.Count)

                FillTable(document, table, rows, columnsToDisplay)

                document.EndUpdate()
            End Using
        End Sub
        Private Function InitTable(ByVal document As Document, ByVal rowsCount As Integer, ByVal columnsCount As Integer) As DevExpress.XtraRichEdit.API.Native.Table
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.End, rowsCount + 1, columnsCount, AutoFitBehaviorType.FixedColumnWidth)

            table.TableLayout = TableLayoutType.Fixed

            table.Borders.InsideHorizontalBorder.LineColor = Color.DarkBlue
            table.Borders.InsideVerticalBorder.LineColor = Color.DarkBlue
            table.Borders.InsideHorizontalBorder.LineThickness = 0.5F
            table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Single
            table.Borders.InsideVerticalBorder.LineThickness = 0.5F
            table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Single

            table.LeftPadding = Units.InchesToDocumentsF(0.01F)

            table.FirstRow.Height = Units.InchesToDocumentsF(0.5F)
            table.FirstRow.HeightType = HeightType.Exact

            Dim pp As ParagraphProperties = document.BeginUpdateParagraphs(table.FirstRow.Range)
            pp.Alignment = ParagraphAlignment.Center
            document.EndUpdateParagraphs(pp)

            Dim cp As CharacterProperties = document.BeginUpdateCharacters(table.FirstRow.Range)
            cp.FontName = "Courier New"
            cp.ForeColor = Color.White
            document.EndUpdateCharacters(cp)

            For i As Integer = 0 To table.FirstRow.Cells.Count - 1
                table.FirstRow.Cells(i).BackgroundColor = Color.DarkBlue
                table.FirstRow.Cells(i).VerticalAlignment = TableCellVerticalAlignment.Center
            Next
            Return table
        End Function
        Private Sub FillTable(ByVal document As Document, ByVal table As DevExpress.XtraRichEdit.API.Native.Table, ByVal rows As RangeDataSource, ByVal columns As List(Of PropertyDescriptor))
            ' Fill table header with column names
            For i = 0 To columns.Count - 1
                document.InsertText(table(0, i).Range.Start, columns(i).DisplayName)
            Next
            ' Fill table body with data
            table.ForEachCell(Sub(ByVal cell As TableCell, ByVal rowIndex As Integer, ByVal cellIndex As Integer)
                                  Select Case cellIndex
                                      Case 0
                                          cell.PreferredWidth = 200
                                      Case 1
                                          cell.PreferredWidth = 300
                                      Case 2
                                          cell.PreferredWidth = 500
                                  End Select

                                  If rowIndex > 0 Then
                                      Dim row = rows(rowIndex - 1)
                                      Dim value = columns(CInt(cellIndex)).GetValue(row)

                                      If value.GetType() Is GetType(Bitmap) Then
                                          document.Images.Insert(cell.Range.Start, CType(value, Bitmap))
                                      Else
                                          document.InsertText(cell.Range.Start, TryCast(columns(CInt(cellIndex)).GetValue(row), CellValue).TextValue)
                                      End If
                                  End If
                              End Sub)
        End Sub
    End Class
End Namespace
