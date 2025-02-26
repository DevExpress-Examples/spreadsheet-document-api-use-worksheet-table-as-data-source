Imports System.IO
Imports DevExpress.Drawing
Imports DevExpress.Office.Utils
Imports DevExpress.Spreadsheet

Namespace SpreadsheetDocumentServerAsDataSourceExample
#Region "#MyPictureProvider"
    Public Class MyPictureProvider
        Implements IBindingRangeValueConverter

        Private pictures As Dictionary(Of String, DXImage)

        Public Sub New(ByVal sheet As Worksheet)
            pictures = GetPictures(sheet)
        End Sub

        Public Function ConvertToObject(ByVal value As CellValue, ByVal requiredType As Type, ByVal columnIndex As Integer) As Object Implements IBindingRangeValueConverter.ConvertToObject
            If columnIndex = 13 Then
                Dim pic As DXImage = Nothing
                If pictures.TryGetValue(value.TextValue, pic) Then
                    Return pic
                End If
            End If
            Return value
        End Function

        Public Function TryConvertFromObject(ByVal value As Object) As CellValue Implements IBindingRangeValueConverter.TryConvertFromObject
            Return CellValue.Empty
        End Function

        Public Function GetPictures(ByVal sheet As Worksheet) As Dictionary(Of String, DXImage)
            Dim employeePictures As Dictionary(Of String, DXImage) = New Dictionary(Of String, DXImage)()
            For Each pic As Picture In sheet.Pictures
                employeePictures.Add(pic.Name, DXImage.FromStream(New MemoryStream(pic.Image.GetImageBytes(OfficeImageFormat.Bmp))))
            Next pic
            Return employeePictures
        End Function
    End Class
#End Region
End Namespace