<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        MenuStrip1 = New MenuStrip()
        AddToolStripMenuItem = New ToolStripMenuItem()
        PersonToolStripMenuItem = New ToolStripMenuItem()
        StudentToolStripMenuItem = New ToolStripMenuItem()
        TeacherToolStripMenuItem = New ToolStripMenuItem()
        ParentGuardianToolStripMenuItem = New ToolStripMenuItem()
        BuildingToolStripMenuItem = New ToolStripMenuItem()
        ClassroomToolStripMenuItem = New ToolStripMenuItem()
        SubjectToolStripMenuItem = New ToolStripMenuItem()
        SectionToolStripMenuItem = New ToolStripMenuItem()
        SearchToolStripMenuItem = New ToolStripMenuItem()
        SPersonToolStripMenuItem1 = New ToolStripMenuItem()
        searchStudentToolStripMenuItem2 = New ToolStripMenuItem()
        searchTeacherToolStripMenuItem1 = New ToolStripMenuItem()
        searchParentGuardianToolStripMenuItem1 = New ToolStripMenuItem()
        SAcademicStructureToolStripMenuItem = New ToolStripMenuItem()
        ClassroomToolStripMenuItem1 = New ToolStripMenuItem()
        SubjectToolStripMenuItem2 = New ToolStripMenuItem()
        SectionToolStripMenuItem1 = New ToolStripMenuItem()
        DashboardToolStripMenuItem = New ToolStripMenuItem()
        GroupBox1 = New GroupBox()
        txtPassword2 = New TextBox()
        lblPassword2 = New Label()
        LinkLabel1 = New LinkLabel()
        Button1 = New Button()
        txtPassword = New TextBox()
        txtAdminName = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        NumericUpDown1 = New NumericUpDown()
        dgvStudent = New DataGridView()
        Label3 = New Label()
        Panel2 = New Panel()
        NumericUpDown2 = New NumericUpDown()
        dgvTeachers = New DataGridView()
        Label4 = New Label()
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Panel3 = New Panel()
        Chart1 = New DataVisualization.Charting.Chart()
        Panel4 = New Panel()
        cmbSection = New ComboBox()
        cmbGradeLevel = New ComboBox()
        Label6 = New Label()
        Label5 = New Label()
        MenuStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        Panel1.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvStudent, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvTeachers, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {AddToolStripMenuItem, SearchToolStripMenuItem, DashboardToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(802, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' AddToolStripMenuItem
        ' 
        AddToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PersonToolStripMenuItem, BuildingToolStripMenuItem})
        AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        AddToolStripMenuItem.Size = New Size(41, 20)
        AddToolStripMenuItem.Text = "Add"
        ' 
        ' PersonToolStripMenuItem
        ' 
        PersonToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {StudentToolStripMenuItem, TeacherToolStripMenuItem, ParentGuardianToolStripMenuItem})
        PersonToolStripMenuItem.Name = "PersonToolStripMenuItem"
        PersonToolStripMenuItem.Size = New Size(178, 22)
        PersonToolStripMenuItem.Text = "Person"
        ' 
        ' StudentToolStripMenuItem
        ' 
        StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        StudentToolStripMenuItem.Size = New Size(161, 22)
        StudentToolStripMenuItem.Text = "Student"
        ' 
        ' TeacherToolStripMenuItem
        ' 
        TeacherToolStripMenuItem.Name = "TeacherToolStripMenuItem"
        TeacherToolStripMenuItem.Size = New Size(161, 22)
        TeacherToolStripMenuItem.Text = "Teacher"
        ' 
        ' ParentGuardianToolStripMenuItem
        ' 
        ParentGuardianToolStripMenuItem.Name = "ParentGuardianToolStripMenuItem"
        ParentGuardianToolStripMenuItem.Size = New Size(161, 22)
        ParentGuardianToolStripMenuItem.Text = "Parent/Guardian"
        ' 
        ' BuildingToolStripMenuItem
        ' 
        BuildingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ClassroomToolStripMenuItem, SubjectToolStripMenuItem, SectionToolStripMenuItem})
        BuildingToolStripMenuItem.Name = "BuildingToolStripMenuItem"
        BuildingToolStripMenuItem.Size = New Size(178, 22)
        BuildingToolStripMenuItem.Text = "Academic Structure"
        ' 
        ' ClassroomToolStripMenuItem
        ' 
        ClassroomToolStripMenuItem.Name = "ClassroomToolStripMenuItem"
        ClassroomToolStripMenuItem.Size = New Size(130, 22)
        ClassroomToolStripMenuItem.Text = "Classroom"
        ' 
        ' SubjectToolStripMenuItem
        ' 
        SubjectToolStripMenuItem.Name = "SubjectToolStripMenuItem"
        SubjectToolStripMenuItem.Size = New Size(130, 22)
        SubjectToolStripMenuItem.Text = "Subject"
        ' 
        ' SectionToolStripMenuItem
        ' 
        SectionToolStripMenuItem.Name = "SectionToolStripMenuItem"
        SectionToolStripMenuItem.Size = New Size(130, 22)
        SectionToolStripMenuItem.Text = "Section"
        ' 
        ' SearchToolStripMenuItem
        ' 
        SearchToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SPersonToolStripMenuItem1, SAcademicStructureToolStripMenuItem})
        SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        SearchToolStripMenuItem.Size = New Size(42, 20)
        SearchToolStripMenuItem.Text = "Find"
        ' 
        ' SPersonToolStripMenuItem1
        ' 
        SPersonToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {searchStudentToolStripMenuItem2, searchTeacherToolStripMenuItem1, searchParentGuardianToolStripMenuItem1})
        SPersonToolStripMenuItem1.Name = "SPersonToolStripMenuItem1"
        SPersonToolStripMenuItem1.Size = New Size(178, 22)
        SPersonToolStripMenuItem1.Text = "Person"
        ' 
        ' searchStudentToolStripMenuItem2
        ' 
        searchStudentToolStripMenuItem2.Name = "searchStudentToolStripMenuItem2"
        searchStudentToolStripMenuItem2.Size = New Size(161, 22)
        searchStudentToolStripMenuItem2.Text = "Student"
        ' 
        ' searchTeacherToolStripMenuItem1
        ' 
        searchTeacherToolStripMenuItem1.Name = "searchTeacherToolStripMenuItem1"
        searchTeacherToolStripMenuItem1.Size = New Size(161, 22)
        searchTeacherToolStripMenuItem1.Text = "Teacher"
        ' 
        ' searchParentGuardianToolStripMenuItem1
        ' 
        searchParentGuardianToolStripMenuItem1.Name = "searchParentGuardianToolStripMenuItem1"
        searchParentGuardianToolStripMenuItem1.Size = New Size(161, 22)
        searchParentGuardianToolStripMenuItem1.Text = "Parent/Guardian"
        ' 
        ' SAcademicStructureToolStripMenuItem
        ' 
        SAcademicStructureToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ClassroomToolStripMenuItem1, SubjectToolStripMenuItem2, SectionToolStripMenuItem1})
        SAcademicStructureToolStripMenuItem.Name = "SAcademicStructureToolStripMenuItem"
        SAcademicStructureToolStripMenuItem.Size = New Size(178, 22)
        SAcademicStructureToolStripMenuItem.Text = "Academic Structure"
        ' 
        ' ClassroomToolStripMenuItem1
        ' 
        ClassroomToolStripMenuItem1.Name = "ClassroomToolStripMenuItem1"
        ClassroomToolStripMenuItem1.Size = New Size(130, 22)
        ClassroomToolStripMenuItem1.Text = "Classroom"
        ' 
        ' SubjectToolStripMenuItem2
        ' 
        SubjectToolStripMenuItem2.Name = "SubjectToolStripMenuItem2"
        SubjectToolStripMenuItem2.Size = New Size(130, 22)
        SubjectToolStripMenuItem2.Text = "Subject"
        ' 
        ' SectionToolStripMenuItem1
        ' 
        SectionToolStripMenuItem1.Name = "SectionToolStripMenuItem1"
        SectionToolStripMenuItem1.Size = New Size(130, 22)
        SectionToolStripMenuItem1.Text = "Section"
        ' 
        ' DashboardToolStripMenuItem
        ' 
        DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
        DashboardToolStripMenuItem.Size = New Size(76, 20)
        DashboardToolStripMenuItem.Text = "Dashboard"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtPassword2)
        GroupBox1.Controls.Add(lblPassword2)
        GroupBox1.Controls.Add(LinkLabel1)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(txtPassword)
        GroupBox1.Controls.Add(txtAdminName)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(232, 54)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(328, 363)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        ' 
        ' txtPassword2
        ' 
        txtPassword2.Location = New Point(149, 199)
        txtPassword2.Name = "txtPassword2"
        txtPassword2.Size = New Size(100, 23)
        txtPassword2.TabIndex = 7
        ' 
        ' lblPassword2
        ' 
        lblPassword2.AutoSize = True
        lblPassword2.Location = New Point(67, 199)
        lblPassword2.Name = "lblPassword2"
        lblPassword2.Size = New Size(60, 15)
        lblPassword2.TabIndex = 6
        lblPassword2.Text = "Password:"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(117, 315)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(104, 15)
        LinkLabel1.TabIndex = 5
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Add New Account"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(107, 246)
        Button1.Name = "Button1"
        Button1.Size = New Size(123, 55)
        Button1.TabIndex = 4
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(149, 147)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(100, 23)
        txtPassword.TabIndex = 3
        ' 
        ' txtAdminName
        ' 
        txtAdminName.Location = New Point(149, 88)
        txtAdminName.Name = "txtAdminName"
        txtAdminName.Size = New Size(100, 23)
        txtAdminName.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(67, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 15)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(67, 88)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 0
        Label1.Text = "Username:"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(NumericUpDown1)
        Panel1.Controls.Add(dgvStudent)
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 24)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(802, 270)
        Panel1.TabIndex = 8
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        NumericUpDown1.Location = New Point(642, 20)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(120, 23)
        NumericUpDown1.TabIndex = 7
        ' 
        ' dgvStudent
        ' 
        dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudent.Location = New Point(14, 49)
        dgvStudent.Margin = New Padding(3, 3, 3, 30)
        dgvStudent.Name = "dgvStudent"
        dgvStudent.Size = New Size(757, 202)
        dgvStudent.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(14, 29)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 15)
        Label3.TabIndex = 5
        Label3.Text = "Student Table:"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(NumericUpDown2)
        Panel2.Controls.Add(dgvTeachers)
        Panel2.Controls.Add(Label4)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 500)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(802, 249)
        Panel2.TabIndex = 9
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        NumericUpDown2.Location = New Point(642, 17)
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(120, 23)
        NumericUpDown2.TabIndex = 10
        ' 
        ' dgvTeachers
        ' 
        dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTeachers.Location = New Point(14, 59)
        dgvTeachers.Name = "dgvTeachers"
        dgvTeachers.Size = New Size(757, 179)
        dgvTeachers.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(14, 25)
        Label4.Name = "Label4"
        Label4.Size = New Size(85, 15)
        Label4.TabIndex = 8
        Label4.Text = "Teachers Table:"
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CacheAge = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.EnableCaching = False
        MySqlCommand1.Transaction = Nothing
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Chart1)
        Panel3.Controls.Add(Panel4)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 294)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(802, 206)
        Panel3.TabIndex = 10
        ' 
        ' Chart1
        ' 
        ChartArea1.BorderWidth = 5
        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Chart1.Dock = DockStyle.Fill
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New Point(0, 42)
        Chart1.Name = "Chart1"
        Series1.BorderWidth = 5
        Series1.ChartArea = "ChartArea1"
        Series1.CustomProperties = "PointWidth=.2"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New Size(802, 164)
        Chart1.TabIndex = 3
        Chart1.Text = "Chart1"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(cmbSection)
        Panel4.Controls.Add(cmbGradeLevel)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label5)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(802, 42)
        Panel4.TabIndex = 2
        ' 
        ' cmbSection
        ' 
        cmbSection.FormattingEnabled = True
        cmbSection.Location = New Point(299, 10)
        cmbSection.Name = "cmbSection"
        cmbSection.Size = New Size(97, 23)
        cmbSection.TabIndex = 7
        ' 
        ' cmbGradeLevel
        ' 
        cmbGradeLevel.FormattingEnabled = True
        cmbGradeLevel.Location = New Point(102, 10)
        cmbGradeLevel.Name = "cmbGradeLevel"
        cmbGradeLevel.Size = New Size(97, 23)
        cmbGradeLevel.TabIndex = 6
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(25, 18)
        Label6.Name = "Label6"
        Label6.Size = New Size(71, 15)
        Label6.TabIndex = 5
        Label6.Text = "Grade Level:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(244, 18)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 15)
        Label5.TabIndex = 4
        Label5.Text = "Section:"
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ActiveBorder
        ClientSize = New Size(802, 749)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(GroupBox1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        MinimumSize = New Size(816, 500)
        Name = "MainForm"
        Text = "MCES Enrollment MS"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvStudent, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvTeachers, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuildingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TeacherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassroomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParentGuardianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SPersonToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SAcademicStructureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents searchStudentToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents searchTeacherToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents searchParentGuardianToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ClassroomToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SubjectToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SectionToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtAdminName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtPassword2 As TextBox
    Friend WithEvents lblPassword2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents dgvStudent As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents dgvTeachers As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents cmbGradeLevel As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DashboardToolStripMenuItem As ToolStripMenuItem

End Class
