Imports Microsoft.Reporting.WinForms
Imports System.Data

Public Class ReportViewerForm
    Inherits System.Windows.Forms.Form

    Private _dataSource As DataTable

    Public Sub New(dataSource As DataTable)
        InitializeComponent()
        _dataSource = dataSource
    End Sub

    Private Sub ReportViewerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reportDataSource As New ReportDataSource("EnrollmentSummary", _dataSource)
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "mcesEMS.EnrollmentReport.rdlc"
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
