<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128612997/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830622)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Spreadsheet Document API - How to use a worksheet as a data source for the Snap report


In this example, a worksheet containing a <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.Table.class">table</a> with data is loaded in a <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.Workbook.class">Workbook</a> instance. The <a href="https://docs.devexpress.com/CoreLibraries/DevExpress.Spreadsheet.Table.GetDataSource.overloads">Table.GetDataSource</a> method returns a data source which is subsequently used to create a report in a <a href="https://docs.devexpress.com/WindowsForms/DevExpress.Snap.SnapControl?v=17.2">SnapControl</a>.<br>To modify worksheet data before they are exposed as data source fields, the application utilizes a custom converter which implements the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.IBindingRangeValueConverter.class">IBindingRangeValueConverter</a> interface. The <strong>MyPictureProvider </strong>converter finds a picture in a worksheet by its name and returns a picture bitmap instead of a name specified in a worksheet column. <br>The custom <strong>MyColumnDetector</strong> object which implements the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Spreadsheet.IDataSourceColumnTypeDetector.class">IDataSourceColumnTypeDetector</a> interface is used to specify column names and types.<br>Note that a <a href="https://docs.devexpress.com/WindowsForms/15716/Controls-and-Libraries/Snap/Fundamental-Concepts/Developer-Guidelines/Snap-List-and-Document-Template?v=17.2">Snap report template</a> which is required to visualize the data in the <a href="https://docs.devexpress.com/WindowsForms/11373/Controls-and-Libraries/Snap?v=17.2">Snap</a> application is created in code at runtime.<br><br><img src="/media/f799c6c5-4065-11e7-80c0-00155d624807.png">
<br/>
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=spreadsheet-document-api-use-worksheet-table-as-data-source&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=spreadsheet-document-api-use-worksheet-table-as-data-source&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
