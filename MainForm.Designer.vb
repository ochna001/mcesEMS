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
        GroupBox1 = New GroupBox()
        Button1 = New Button()
        txtPassword = New TextBox()
        txtAdminName = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        LinkLabel1 = New LinkLabel()
        txtPassword2 = New TextBox()
        lblPassword2 = New Label()
        MenuStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {AddToolStripMenuItem, SearchToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
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
        GroupBox1.Location = New Point(236, 42)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(328, 363)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
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
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveBorder
        ClientSize = New Size(800, 450)
        Controls.Add(GroupBox1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "MainForm"
        Text = "MCES Enrollment MS"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
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

End Class
