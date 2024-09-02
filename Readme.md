<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128612997/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830622)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Spreadsheet Document API - Use a Worksheet Table as a Data Source

The following example demonstrates how to use a [worksheet table](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.Table) as a data source to generate a report in a [RichEditControl](https://docs.devexpress.com/WindowsForms/DevExpress.XtraRichEdit.RichEditControl).

![](./media/f799c6c5-4065-11e7-80c0-00155d624807.png)

## Implementation Details

In this example, a worksheet containing a table with data is loaded in a [Workbook](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.Workbook) instance. The [Table.GetDataSource](https://docs.devexpress.com/OfficeFileAPI/devexpress.spreadsheet.table.getdatasource.overloads) method returns a data source which is subsequently used to create a report in a RichEditControl.

To modify worksheet data before they are exposed as data source fields, the application utilizes a custom converter that implements the [IBindingRangeValueConverter](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.IBindingRangeValueConverter) interface. The **MyPictureProvider** converter finds a picture in a worksheet by its name and returns a picture bitmap instead of a name specified in a worksheet column.
The custom **MyColumnDetector** object which implements the [IDataSourceColumnTypeDetector](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.IDataSourceColumnTypeDetector) interface is used to specify column names and types.  
Note that a table required to visualize the data in the **RichEditControl** component is created in code at runtime.

## Files to Review

* [Form1.cs](./CS/SpreadsheetDocumentServerAsDataSourceExample/Form1.cs) (VB: [Form1.vb](./VB/SpreadsheetDocumentServerAsDataSourceExample/Form1.vb))
* [MyColumnDetector.cs](./CS/SpreadsheetDocumentServerAsDataSourceExample/MyColumnDetector.cs) (VB: [MyColumnDetector.vb](./VB/SpreadsheetDocumentServerAsDataSourceExample/MyColumnDetector.vb))
* [MyPictureProvider.cs](./CS/SpreadsheetDocumentServerAsDataSourceExample/MyPictureProvider.cs) (VB: [MyPictureProvider.vb](./VB/SpreadsheetDocumentServerAsDataSourceExample/MyPictureProvider.vb))

## More Examples

* [How to: Bind a Worksheet to a Generic List or a BindingList Data Source](https://github.com/DevExpress-Examples/how-to-bind-a-worksheet-to-a-generic-list-or-a-bindinglist-data-source)

## Documentation

* [Spreadsheet Data Binding](https://docs.devexpress.com/OfficeFileAPI/118785/spreadsheet-document-api/data-binding)
* [How to: Export a Worksheet Range to a DataTable](https://docs.devexpress.com/OfficeFileAPI/118161/spreadsheet-document-api/examples/data-import-and-export/how-to-export-a-worksheet-range-to-a-data-table)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=spreadsheet-document-api-use-worksheet-table-as-data-source&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=spreadsheet-document-api-use-worksheet-table-as-data-source&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
