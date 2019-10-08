Imports DevExpress.Spreadsheet
Imports System

Namespace SpreadsheetDocumentServerAsDataSourceExample
#Region "#MyColumnDetector"
    Friend Class MyColumnDetector
        Implements IDataSourceColumnTypeDetector

        Public Function GetColumnName(ByVal index As Integer, ByVal offset As Integer, ByVal range As CellRange) As String Implements IDataSourceColumnTypeDetector.GetColumnName
            Return range(-1, offset).DisplayText
        End Function

        Public Function GetColumnType(ByVal index As Integer, ByVal offset As Integer, ByVal range As CellRange) As Type Implements IDataSourceColumnTypeDetector.GetColumnType
            Dim defaultType As Type = GetType(String)

            If offset = 13 Then
                Return GetType(System.Drawing.Bitmap)
            End If

            Dim value As CellValue = range(0, offset).Value
            If value.IsText Then
                Return GetType(String)
            End If
            If value.IsBoolean Then
                Return GetType(Boolean)
            End If
            If value.IsDateTime Then
                Return GetType(Date)
            End If
            If value.IsNumeric Then
                Return GetType(Double)
            End If
            Return defaultType
        End Function
    End Class
#End Region ' #MyColumnDetector
End Namespace