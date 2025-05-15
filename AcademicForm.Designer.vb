<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcademicForm
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        btnSearchAcademicEntity = New Button()
        txtSearchAcademicEntity = New TextBox()
        lblsearch = New Label()
        gbAcademicForms = New GroupBox()
        cmbSchedule = New ComboBox()
        lblSchedule = New Label()
        btnDeleteAE = New Button()
        cmbClassroomID = New ComboBox()
        btnEditAE = New Button()
        cmbGradeLevelID = New ComboBox()
        lblforcmb1 = New Label()
        lblforcmb2 = New Label()
        btnSave = New Button()
        txt2nd = New TextBox()
        txt1st = New TextBox()
        label2 = New Label()
        label1 = New Label()
        Label4 = New Label()
        lblHint = New Label()
        Panel1.SuspendLayout()
        gbAcademicForms.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveBorder
        Panel1.Controls.Add(lblHint)
        Panel1.Controls.Add(btnSearchAcademicEntity)
        Panel1.Controls.Add(txtSearchAcademicEntity)
        Panel1.Controls.Add(lblsearch)
        Panel1.Controls.Add(gbAcademicForms)
        Panel1.Controls.Add(Label4)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(20, 20)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(665, 433)
        Panel1.TabIndex = 0
        ' 
        ' btnSearchAcademicEntity
        ' 
        btnSearchAcademicEntity.Location = New Point(442, 30)
        btnSearchAcademicEntity.Name = "btnSearchAcademicEntity"
        btnSearchAcademicEntity.Size = New Size(23, 23)
        btnSearchAcademicEntity.TabIndex = 37
        btnSearchAcademicEntity.Text = "Q"
        btnSearchAcademicEntity.UseVisualStyleBackColor = True
        ' 
        ' txtSearchAcademicEntity
        ' 
        txtSearchAcademicEntity.Location = New Point(155, 30)
        txtSearchAcademicEntity.Name = "txtSearchAcademicEntity"
        txtSearchAcademicEntity.Size = New Size(281, 23)
        txtSearchAcademicEntity.TabIndex = 36
        ' 
        ' lblsearch
        ' 
        lblsearch.AutoSize = True
        lblsearch.Location = New Point(104, 38)
        lblsearch.Name = "lblsearch"
        lblsearch.Size = New Size(45, 15)
        lblsearch.TabIndex = 35
        lblsearch.Text = "Search:"
        ' 
        ' gbAcademicForms
        ' 
        gbAcademicForms.Anchor = AnchorStyles.None
        gbAcademicForms.Controls.Add(cmbSchedule)
        gbAcademicForms.Controls.Add(lblSchedule)
        gbAcademicForms.Controls.Add(btnDeleteAE)
        gbAcademicForms.Controls.Add(cmbClassroomID)
        gbAcademicForms.Controls.Add(btnEditAE)
        gbAcademicForms.Controls.Add(cmbGradeLevelID)
        gbAcademicForms.Controls.Add(lblforcmb1)
        gbAcademicForms.Controls.Add(lblforcmb2)
        gbAcademicForms.Controls.Add(btnSave)
        gbAcademicForms.Controls.Add(txt2nd)
        gbAcademicForms.Controls.Add(txt1st)
        gbAcademicForms.Controls.Add(label2)
        gbAcademicForms.Controls.Add(label1)
        gbAcademicForms.Location = New Point(81, 69)
        gbAcademicForms.Name = "gbAcademicForms"
        gbAcademicForms.Size = New Size(509, 321)
        gbAcademicForms.TabIndex = 4
        gbAcademicForms.TabStop = False
        gbAcademicForms.Text = "Form Name"
        ' 
        ' cmbSchedule
        ' 
        cmbSchedule.FormattingEnabled = True
        cmbSchedule.Location = New Point(184, 199)
        cmbSchedule.Name = "cmbSchedule"
        cmbSchedule.Size = New Size(121, 23)
        cmbSchedule.TabIndex = 41
        ' 
        ' lblSchedule
        ' 
        lblSchedule.AutoSize = True
        lblSchedule.Location = New Point(77, 207)
        lblSchedule.Name = "lblSchedule"
        lblSchedule.Size = New Size(58, 15)
        lblSchedule.TabIndex = 40
        lblSchedule.Text = "Schedule:"
        ' 
        ' btnDeleteAE
        ' 
        btnDeleteAE.Location = New Point(385, 212)
        btnDeleteAE.Name = "btnDeleteAE"
        btnDeleteAE.Size = New Size(56, 28)
        btnDeleteAE.TabIndex = 39
        btnDeleteAE.Text = "Delete"
        btnDeleteAE.UseVisualStyleBackColor = True
        ' 
        ' cmbClassroomID
        ' 
        cmbClassroomID.FormattingEnabled = True
        cmbClassroomID.Location = New Point(184, 163)
        cmbClassroomID.Name = "cmbClassroomID"
        cmbClassroomID.Size = New Size(121, 23)
        cmbClassroomID.TabIndex = 11
        ' 
        ' btnEditAE
        ' 
        btnEditAE.Location = New Point(385, 246)
        btnEditAE.Name = "btnEditAE"
        btnEditAE.Size = New Size(56, 28)
        btnEditAE.TabIndex = 38
        btnEditAE.Text = "Edit"
        btnEditAE.UseVisualStyleBackColor = True
        ' 
        ' cmbGradeLevelID
        ' 
        cmbGradeLevelID.FormattingEnabled = True
        cmbGradeLevelID.Location = New Point(184, 126)
        cmbGradeLevelID.Name = "cmbGradeLevelID"
        cmbGradeLevelID.Size = New Size(121, 23)
        cmbGradeLevelID.TabIndex = 10
        ' 
        ' lblforcmb1
        ' 
        lblforcmb1.AutoSize = True
        lblforcmb1.Location = New Point(77, 129)
        lblforcmb1.Name = "lblforcmb1"
        lblforcmb1.Size = New Size(45, 15)
        lblforcmb1.TabIndex = 9
        lblforcmb1.Text = "qweqw"
        lblforcmb1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblforcmb2
        ' 
        lblforcmb2.AutoSize = True
        lblforcmb2.Location = New Point(77, 170)
        lblforcmb2.Name = "lblforcmb2"
        lblforcmb2.Size = New Size(51, 15)
        lblforcmb2.TabIndex = 8
        lblforcmb2.Text = "qweqwe"
        lblforcmb2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(184, 234)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(88, 40)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txt2nd
        ' 
        txt2nd.Location = New Point(184, 85)
        txt2nd.Name = "txt2nd"
        txt2nd.Size = New Size(100, 23)
        txt2nd.TabIndex = 5
        ' 
        ' txt1st
        ' 
        txt1st.Location = New Point(184, 47)
        txt1st.Name = "txt1st"
        txt1st.Size = New Size(100, 23)
        txt1st.TabIndex = 3
        ' 
        ' label2
        ' 
        label2.AutoSize = True
        label2.Location = New Point(77, 88)
        label2.Name = "label2"
        label2.Size = New Size(51, 15)
        label2.TabIndex = 2
        label2.Text = "qweqwe"
        label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Location = New Point(77, 55)
        label1.Name = "label1"
        label1.Size = New Size(51, 15)
        label1.TabIndex = 0
        label1.Text = "qweqwe"
        label1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(32, 33)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 15)
        Label4.TabIndex = 3
        ' 
        ' lblHint
        ' 
        lblHint.AutoSize = True
        lblHint.Font = New Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHint.ForeColor = SystemColors.ControlDarkDark
        lblHint.Location = New Point(246, 55)
        lblHint.Name = "lblHint"
        lblHint.Size = New Size(190, 11)
        lblHint.TabIndex = 38
        lblHint.Text = "*Use [Subject Name::Grade Level] for better filtering"
        ' 
        ' AcademicForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        MinimumSize = New Size(705, 473)
        Name = "AcademicForm"
        Padding = New Padding(20)
        Size = New Size(705, 473)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        gbAcademicForms.ResumeLayout(False)
        gbAcademicForms.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbAcademicForms As GroupBox
    Friend WithEvents label2 As Label
    Friend WithEvents label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt2nd As TextBox
    Friend WithEvents txt1st As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lblforcmb2 As Label
    Friend WithEvents lblforcmb1 As Label
    Friend WithEvents cmbClassroomID As ComboBox
    Friend WithEvents cmbGradeLevelID As ComboBox
    Friend WithEvents btnSearchAcademicEntity As Button
    Friend WithEvents txtSearchAcademicEntity As TextBox
    Friend WithEvents lblsearch As Label
    Friend WithEvents btnDeleteAE As Button
    Friend WithEvents btnEditAE As Button
    Friend WithEvents lblSchedule As Label
    Friend WithEvents cmbSchedule As ComboBox
    Friend WithEvents lblHint As Label

End Class
