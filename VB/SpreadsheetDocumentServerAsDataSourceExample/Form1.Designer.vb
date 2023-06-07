Namespace SpreadsheetDocumentServerAsDataSourceExample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
            Me.SuspendLayout()
            '
            'RichEditControl1
            '
            Me.RichEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichEditControl1.Location = New System.Drawing.Point(0, 0)
            Me.RichEditControl1.Name = "RichEditControl1"
            Me.RichEditControl1.Size = New System.Drawing.Size(920, 580)
            Me.RichEditControl1.TabIndex = 0
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(920, 580)
            Me.Controls.Add(Me.RichEditControl1)
            Me.Name = "Form1"
            Me.Text = "SpreadsheetDocumentServer as Data Source"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl

#End Region
    End Class
End Namespace

