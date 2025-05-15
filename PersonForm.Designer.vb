<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonForm
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
        pnlStudent = New Panel()
        GroupBox1 = New GroupBox()
        btnBack = New Button()
        LinkLabel2 = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        btnDeleteStudent = New Button()
        btnEditStudent = New Button()
        btnSearchStudent = New Button()
        txtSearchStudent = New TextBox()
        lblSearchStudent = New Label()
        clbSubjects = New CheckedListBox()
        cmbClassRoomAss = New ComboBox()
        btnAddNewParent = New LinkLabel()
        btnSaveStudent = New Button()
        btnUploadReportCard = New Button()
        btnUploadBirthCertificate = New Button()
        Label14 = New Label()
        Label15 = New Label()
        cmbParentGuardian = New ComboBox()
        Label12 = New Label()
        cmbSection = New ComboBox()
        cmbGradeLevel = New ComboBox()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        dtpDOB = New DateTimePicker()
        cmbSex = New ComboBox()
        txtFname = New TextBox()
        txtMname = New TextBox()
        txtAddress = New TextBox()
        txtLname = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        pnlPersonDetails = New Panel()
        Button1 = New Button()
        btnSearchPerson = New Button()
        txtSearchPerson = New TextBox()
        lblsearch = New Label()
        lblGB = New GroupBox()
        btnDeletepd = New Button()
        btnEditpd = New Button()
        txtRelationshippd = New TextBox()
        lblRelatioshippd = New Label()
        btnSavepd = New Button()
        dtpDOBpd = New DateTimePicker()
        lblDOBpd = New Label()
        txtContactInfopd = New TextBox()
        Label22 = New Label()
        cmbSexpd = New ComboBox()
        txtFnamepd = New TextBox()
        txtMnamepd = New TextBox()
        txtAddresspd = New TextBox()
        txtLnamepd = New TextBox()
        Label16 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        lblpdname = New Label()
        pnlStudent.SuspendLayout()
        GroupBox1.SuspendLayout()
        pnlPersonDetails.SuspendLayout()
        lblGB.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlStudent
        ' 
        pnlStudent.BackColor = SystemColors.ActiveBorder
        pnlStudent.Controls.Add(GroupBox1)
        pnlStudent.Dock = DockStyle.Fill
        pnlStudent.Location = New Point(20, 20)
        pnlStudent.Name = "pnlStudent"
        pnlStudent.Size = New Size(665, 433)
        pnlStudent.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.None
        GroupBox1.Controls.Add(btnBack)
        GroupBox1.Controls.Add(LinkLabel2)
        GroupBox1.Controls.Add(LinkLabel1)
        GroupBox1.Controls.Add(btnDeleteStudent)
        GroupBox1.Controls.Add(btnEditStudent)
        GroupBox1.Controls.Add(btnSearchStudent)
        GroupBox1.Controls.Add(txtSearchStudent)
        GroupBox1.Controls.Add(lblSearchStudent)
        GroupBox1.Controls.Add(clbSubjects)
        GroupBox1.Controls.Add(cmbClassRoomAss)
        GroupBox1.Controls.Add(btnAddNewParent)
        GroupBox1.Controls.Add(btnSaveStudent)
        GroupBox1.Controls.Add(btnUploadReportCard)
        GroupBox1.Controls.Add(btnUploadBirthCertificate)
        GroupBox1.Controls.Add(Label14)
        GroupBox1.Controls.Add(Label15)
        GroupBox1.Controls.Add(cmbParentGuardian)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(cmbSection)
        GroupBox1.Controls.Add(cmbGradeLevel)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(dtpDOB)
        GroupBox1.Controls.Add(cmbSex)
        GroupBox1.Controls.Add(txtFname)
        GroupBox1.Controls.Add(txtMname)
        GroupBox1.Controls.Add(txtAddress)
        GroupBox1.Controls.Add(txtLname)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(10, 9)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(644, 417)
        GroupBox1.TabIndex = 32
        GroupBox1.TabStop = False
        GroupBox1.Text = "Enrollment Form"
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBack.Location = New Point(563, 0)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(75, 23)
        btnBack.TabIndex = 41
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.Location = New Point(530, 266)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(63, 15)
        LinkLabel2.TabIndex = 40
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "LinkLabel2"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(530, 227)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(63, 15)
        LinkLabel1.TabIndex = 39
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "LinkLabel1"
        ' 
        ' btnDeleteStudent
        ' 
        btnDeleteStudent.Location = New Point(258, 373)
        btnDeleteStudent.Name = "btnDeleteStudent"
        btnDeleteStudent.Size = New Size(51, 23)
        btnDeleteStudent.TabIndex = 38
        btnDeleteStudent.Text = "Delete"
        btnDeleteStudent.UseVisualStyleBackColor = True
        ' 
        ' btnEditStudent
        ' 
        btnEditStudent.Location = New Point(202, 373)
        btnEditStudent.Name = "btnEditStudent"
        btnEditStudent.Size = New Size(50, 23)
        btnEditStudent.TabIndex = 37
        btnEditStudent.Text = "Edit"
        btnEditStudent.UseVisualStyleBackColor = True
        ' 
        ' btnSearchStudent
        ' 
        btnSearchStudent.Location = New Point(135, 374)
        btnSearchStudent.Name = "btnSearchStudent"
        btnSearchStudent.Size = New Size(28, 23)
        btnSearchStudent.TabIndex = 36
        btnSearchStudent.Text = "Q"
        btnSearchStudent.UseVisualStyleBackColor = True
        ' 
        ' txtSearchStudent
        ' 
        txtSearchStudent.Location = New Point(29, 373)
        txtSearchStudent.Name = "txtSearchStudent"
        txtSearchStudent.Size = New Size(100, 23)
        txtSearchStudent.TabIndex = 35
        ' 
        ' lblSearchStudent
        ' 
        lblSearchStudent.AutoSize = True
        lblSearchStudent.Location = New Point(29, 355)
        lblSearchStudent.Name = "lblSearchStudent"
        lblSearchStudent.Size = New Size(42, 15)
        lblSearchStudent.TabIndex = 34
        lblSearchStudent.Text = "Search"
        ' 
        ' clbSubjects
        ' 
        clbSubjects.FormattingEnabled = True
        clbSubjects.Location = New Point(449, 159)
        clbSubjects.Name = "clbSubjects"
        clbSubjects.Size = New Size(100, 58)
        clbSubjects.TabIndex = 33
        ' 
        ' cmbClassRoomAss
        ' 
        cmbClassRoomAss.FormattingEnabled = True
        cmbClassRoomAss.Location = New Point(449, 130)
        cmbClassRoomAss.Name = "cmbClassRoomAss"
        cmbClassRoomAss.Size = New Size(100, 23)
        cmbClassRoomAss.TabIndex = 32
        ' 
        ' btnAddNewParent
        ' 
        btnAddNewParent.Anchor = AnchorStyles.None
        btnAddNewParent.AutoSize = True
        btnAddNewParent.Font = New Font("Segoe UI", 7F)
        btnAddNewParent.LinkColor = Color.DimGray
        btnAddNewParent.Location = New Point(189, 289)
        btnAddNewParent.Name = "btnAddNewParent"
        btnAddNewParent.Size = New Size(76, 12)
        btnAddNewParent.TabIndex = 31
        btnAddNewParent.TabStop = True
        btnAddNewParent.Text = "Add New Parent"
        ' 
        ' btnSaveStudent
        ' 
        btnSaveStudent.Anchor = AnchorStyles.None
        btnSaveStudent.Location = New Point(449, 355)
        btnSaveStudent.Name = "btnSaveStudent"
        btnSaveStudent.Size = New Size(100, 42)
        btnSaveStudent.TabIndex = 30
        btnSaveStudent.Text = "Save"
        btnSaveStudent.UseVisualStyleBackColor = True
        ' 
        ' btnUploadReportCard
        ' 
        btnUploadReportCard.Anchor = AnchorStyles.None
        btnUploadReportCard.Location = New Point(449, 263)
        btnUploadReportCard.Name = "btnUploadReportCard"
        btnUploadReportCard.Size = New Size(75, 23)
        btnUploadReportCard.TabIndex = 29
        btnUploadReportCard.Text = "Upload"
        btnUploadReportCard.UseVisualStyleBackColor = True
        ' 
        ' btnUploadBirthCertificate
        ' 
        btnUploadBirthCertificate.Anchor = AnchorStyles.None
        btnUploadBirthCertificate.Location = New Point(449, 223)
        btnUploadBirthCertificate.Name = "btnUploadBirthCertificate"
        btnUploadBirthCertificate.Size = New Size(75, 23)
        btnUploadBirthCertificate.TabIndex = 28
        btnUploadBirthCertificate.Text = "Upload"
        btnUploadBirthCertificate.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.Location = New Point(351, 227)
        Label14.Name = "Label14"
        Label14.Size = New Size(92, 15)
        Label14.TabIndex = 27
        Label14.Text = "Birth Certificate:"
        ' 
        ' Label15
        ' 
        Label15.Anchor = AnchorStyles.None
        Label15.AutoSize = True
        Label15.Location = New Point(343, 257)
        Label15.Name = "Label15"
        Label15.Size = New Size(100, 30)
        Label15.TabIndex = 26
        Label15.Text = "School Records:" & vbCrLf & "(e.g. Report Card)"
        Label15.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbParentGuardian
        ' 
        cmbParentGuardian.Anchor = AnchorStyles.None
        cmbParentGuardian.FormattingEnabled = True
        cmbParentGuardian.Location = New Point(128, 263)
        cmbParentGuardian.Name = "cmbParentGuardian"
        cmbParentGuardian.Size = New Size(137, 23)
        cmbParentGuardian.TabIndex = 23
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.None
        Label12.AutoSize = True
        Label12.Location = New Point(29, 256)
        Label12.Name = "Label12"
        Label12.Size = New Size(93, 30)
        Label12.TabIndex = 22
        Label12.Text = "Parent/" & vbCrLf & "Guardian Name:"
        Label12.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbSection
        ' 
        cmbSection.Anchor = AnchorStyles.None
        cmbSection.FormattingEnabled = True
        cmbSection.Location = New Point(449, 98)
        cmbSection.Name = "cmbSection"
        cmbSection.Size = New Size(100, 23)
        cmbSection.TabIndex = 19
        ' 
        ' cmbGradeLevel
        ' 
        cmbGradeLevel.Anchor = AnchorStyles.None
        cmbGradeLevel.FormattingEnabled = True
        cmbGradeLevel.Location = New Point(449, 64)
        cmbGradeLevel.Name = "cmbGradeLevel"
        cmbGradeLevel.Size = New Size(100, 23)
        cmbGradeLevel.TabIndex = 18
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.Location = New Point(372, 72)
        Label11.Name = "Label11"
        Label11.Size = New Size(71, 15)
        Label11.TabIndex = 17
        Label11.Text = "Grade Level:"
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.None
        Label10.AutoSize = True
        Label10.Location = New Point(394, 106)
        Label10.Name = "Label10"
        Label10.Size = New Size(49, 15)
        Label10.TabIndex = 16
        Label10.Text = "Section:"
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.None
        Label9.AutoSize = True
        Label9.Location = New Point(311, 138)
        Label9.Name = "Label9"
        Label9.Size = New Size(132, 15)
        Label9.TabIndex = 15
        Label9.Text = "Classroom Assignment:"
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.Location = New Point(389, 167)
        Label8.Name = "Label8"
        Label8.Size = New Size(54, 15)
        Label8.TabIndex = 14
        Label8.Text = "Subjects:"
        ' 
        ' dtpDOB
        ' 
        dtpDOB.Anchor = AnchorStyles.None
        dtpDOB.Location = New Point(128, 223)
        dtpDOB.Name = "dtpDOB"
        dtpDOB.Size = New Size(149, 23)
        dtpDOB.TabIndex = 13
        ' 
        ' cmbSex
        ' 
        cmbSex.Anchor = AnchorStyles.None
        cmbSex.FormattingEnabled = True
        cmbSex.Location = New Point(128, 190)
        cmbSex.Name = "cmbSex"
        cmbSex.Size = New Size(100, 23)
        cmbSex.TabIndex = 12
        ' 
        ' txtFname
        ' 
        txtFname.Anchor = AnchorStyles.None
        txtFname.Location = New Point(128, 98)
        txtFname.Name = "txtFname"
        txtFname.Size = New Size(100, 23)
        txtFname.TabIndex = 11
        ' 
        ' txtMname
        ' 
        txtMname.Anchor = AnchorStyles.None
        txtMname.Location = New Point(128, 130)
        txtMname.Name = "txtMname"
        txtMname.Size = New Size(100, 23)
        txtMname.TabIndex = 10
        ' 
        ' txtAddress
        ' 
        txtAddress.Anchor = AnchorStyles.None
        txtAddress.Location = New Point(128, 159)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(137, 23)
        txtAddress.TabIndex = 9
        ' 
        ' txtLname
        ' 
        txtLname.Anchor = AnchorStyles.None
        txtLname.Location = New Point(128, 64)
        txtLname.Name = "txtLname"
        txtLname.Size = New Size(100, 23)
        txtLname.TabIndex = 7
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Location = New Point(95, 198)
        Label7.Name = "Label7"
        Label7.Size = New Size(28, 15)
        Label7.TabIndex = 6
        Label7.Text = "Sex:"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Location = New Point(64, 229)
        Label6.Name = "Label6"
        Label6.Size = New Size(58, 15)
        Label6.TabIndex = 5
        Label6.Text = "Birthdate:"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Location = New Point(56, 72)
        Label5.Name = "Label5"
        Label5.Size = New Size(66, 15)
        Label5.TabIndex = 4
        Label5.Text = "Last Name:"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Location = New Point(40, 138)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 15)
        Label4.TabIndex = 3
        Label4.Text = "Middle Name:"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Location = New Point(70, 167)
        Label3.Name = "Label3"
        Label3.Size = New Size(52, 15)
        Label3.TabIndex = 2
        Label3.Text = "Address:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(55, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 1
        Label2.Text = "First Name:"
        ' 
        ' pnlPersonDetails
        ' 
        pnlPersonDetails.BackColor = SystemColors.AppWorkspace
        pnlPersonDetails.Controls.Add(Button1)
        pnlPersonDetails.Controls.Add(btnSearchPerson)
        pnlPersonDetails.Controls.Add(txtSearchPerson)
        pnlPersonDetails.Controls.Add(lblsearch)
        pnlPersonDetails.Controls.Add(lblGB)
        pnlPersonDetails.Controls.Add(lblpdname)
        pnlPersonDetails.Dock = DockStyle.Fill
        pnlPersonDetails.Location = New Point(20, 20)
        pnlPersonDetails.Name = "pnlPersonDetails"
        pnlPersonDetails.Padding = New Padding(10)
        pnlPersonDetails.Size = New Size(665, 433)
        pnlPersonDetails.TabIndex = 50
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(10, 397)
        Button1.Name = "Button1"
        Button1.Size = New Size(48, 23)
        Button1.TabIndex = 35
        Button1.Text = "Back"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' btnSearchPerson
        ' 
        btnSearchPerson.Location = New Point(290, 31)
        btnSearchPerson.Name = "btnSearchPerson"
        btnSearchPerson.Size = New Size(23, 23)
        btnSearchPerson.TabIndex = 34
        btnSearchPerson.Text = "Q"
        btnSearchPerson.UseVisualStyleBackColor = True
        ' 
        ' txtSearchPerson
        ' 
        txtSearchPerson.Location = New Point(184, 31)
        txtSearchPerson.Name = "txtSearchPerson"
        txtSearchPerson.Size = New Size(100, 23)
        txtSearchPerson.TabIndex = 33
        ' 
        ' lblsearch
        ' 
        lblsearch.AutoSize = True
        lblsearch.Location = New Point(173, 79)
        lblsearch.Name = "lblsearch"
        lblsearch.Size = New Size(45, 15)
        lblsearch.TabIndex = 32
        lblsearch.Text = "Search:"
        ' 
        ' lblGB
        ' 
        lblGB.Controls.Add(btnDeletepd)
        lblGB.Controls.Add(btnEditpd)
        lblGB.Controls.Add(txtRelationshippd)
        lblGB.Controls.Add(lblRelatioshippd)
        lblGB.Controls.Add(btnSavepd)
        lblGB.Controls.Add(dtpDOBpd)
        lblGB.Controls.Add(lblDOBpd)
        lblGB.Controls.Add(txtContactInfopd)
        lblGB.Controls.Add(Label22)
        lblGB.Controls.Add(cmbSexpd)
        lblGB.Controls.Add(txtFnamepd)
        lblGB.Controls.Add(txtMnamepd)
        lblGB.Controls.Add(txtAddresspd)
        lblGB.Controls.Add(txtLnamepd)
        lblGB.Controls.Add(Label16)
        lblGB.Controls.Add(Label17)
        lblGB.Controls.Add(Label18)
        lblGB.Controls.Add(Label19)
        lblGB.Controls.Add(Label20)
        lblGB.Location = New Point(80, 60)
        lblGB.Name = "lblGB"
        lblGB.Size = New Size(481, 360)
        lblGB.TabIndex = 29
        lblGB.TabStop = False
        lblGB.Text = "GroupBox1"
        ' 
        ' btnDeletepd
        ' 
        btnDeletepd.Location = New Point(419, 292)
        btnDeletepd.Name = "btnDeletepd"
        btnDeletepd.Size = New Size(56, 28)
        btnDeletepd.TabIndex = 33
        btnDeletepd.Text = "Delete"
        btnDeletepd.UseVisualStyleBackColor = True
        ' 
        ' btnEditpd
        ' 
        btnEditpd.Location = New Point(419, 326)
        btnEditpd.Name = "btnEditpd"
        btnEditpd.Size = New Size(56, 28)
        btnEditpd.TabIndex = 32
        btnEditpd.Text = "Edit"
        btnEditpd.UseVisualStyleBackColor = True
        ' 
        ' txtRelationshippd
        ' 
        txtRelationshippd.Location = New Point(186, 270)
        txtRelationshippd.Name = "txtRelationshippd"
        txtRelationshippd.Size = New Size(137, 23)
        txtRelationshippd.TabIndex = 31
        ' 
        ' lblRelatioshippd
        ' 
        lblRelatioshippd.AutoSize = True
        lblRelatioshippd.Location = New Point(105, 278)
        lblRelatioshippd.Name = "lblRelatioshippd"
        lblRelatioshippd.Size = New Size(75, 15)
        lblRelatioshippd.TabIndex = 30
        lblRelatioshippd.Text = "Relationship:"
        ' 
        ' btnSavepd
        ' 
        btnSavepd.Location = New Point(186, 318)
        btnSavepd.Name = "btnSavepd"
        btnSavepd.Size = New Size(116, 35)
        btnSavepd.TabIndex = 29
        btnSavepd.Text = "Save"
        btnSavepd.UseVisualStyleBackColor = True
        ' 
        ' dtpDOBpd
        ' 
        dtpDOBpd.Location = New Point(186, 238)
        dtpDOBpd.Name = "dtpDOBpd"
        dtpDOBpd.Size = New Size(200, 23)
        dtpDOBpd.TabIndex = 27
        ' 
        ' lblDOBpd
        ' 
        lblDOBpd.AutoSize = True
        lblDOBpd.Location = New Point(104, 244)
        lblDOBpd.Name = "lblDOBpd"
        lblDOBpd.Size = New Size(76, 15)
        lblDOBpd.TabIndex = 26
        lblDOBpd.Text = "Date of Birth:"
        lblDOBpd.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtContactInfopd
        ' 
        txtContactInfopd.Location = New Point(186, 203)
        txtContactInfopd.Name = "txtContactInfopd"
        txtContactInfopd.Size = New Size(137, 23)
        txtContactInfopd.TabIndex = 25
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(107, 196)
        Label22.Name = "Label22"
        Label22.Size = New Size(73, 30)
        Label22.TabIndex = 24
        Label22.Text = "Contact " & vbCrLf & "Information:"
        Label22.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbSexpd
        ' 
        cmbSexpd.FormattingEnabled = True
        cmbSexpd.Location = New Point(186, 164)
        cmbSexpd.Name = "cmbSexpd"
        cmbSexpd.Size = New Size(100, 23)
        cmbSexpd.TabIndex = 22
        ' 
        ' txtFnamepd
        ' 
        txtFnamepd.Location = New Point(186, 72)
        txtFnamepd.Name = "txtFnamepd"
        txtFnamepd.Size = New Size(100, 23)
        txtFnamepd.TabIndex = 21
        ' 
        ' txtMnamepd
        ' 
        txtMnamepd.Location = New Point(186, 104)
        txtMnamepd.Name = "txtMnamepd"
        txtMnamepd.Size = New Size(100, 23)
        txtMnamepd.TabIndex = 20
        ' 
        ' txtAddresspd
        ' 
        txtAddresspd.Location = New Point(186, 133)
        txtAddresspd.Name = "txtAddresspd"
        txtAddresspd.Size = New Size(137, 23)
        txtAddresspd.TabIndex = 19
        ' 
        ' txtLnamepd
        ' 
        txtLnamepd.Location = New Point(186, 38)
        txtLnamepd.Name = "txtLnamepd"
        txtLnamepd.Size = New Size(100, 23)
        txtLnamepd.TabIndex = 18
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(153, 172)
        Label16.Name = "Label16"
        Label16.Size = New Size(28, 15)
        Label16.TabIndex = 17
        Label16.Text = "Sex:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(114, 46)
        Label17.Name = "Label17"
        Label17.Size = New Size(66, 15)
        Label17.TabIndex = 16
        Label17.Text = "Last Name:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(98, 112)
        Label18.Name = "Label18"
        Label18.Size = New Size(82, 15)
        Label18.TabIndex = 15
        Label18.Text = "Middle Name:"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(128, 141)
        Label19.Name = "Label19"
        Label19.Size = New Size(52, 15)
        Label19.TabIndex = 14
        Label19.Text = "Address:"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(113, 80)
        Label20.Name = "Label20"
        Label20.Size = New Size(67, 15)
        Label20.TabIndex = 13
        Label20.Text = "First Name:"
        ' 
        ' lblpdname
        ' 
        lblpdname.AutoSize = True
        lblpdname.Dock = DockStyle.Fill
        lblpdname.Location = New Point(10, 10)
        lblpdname.Name = "lblpdname"
        lblpdname.Size = New Size(106, 15)
        lblpdname.TabIndex = 23
        lblpdname.Text = "Add Teacher Form:"
        ' 
        ' PersonForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlPersonDetails)
        Controls.Add(pnlStudent)
        Name = "PersonForm"
        Padding = New Padding(20)
        Size = New Size(705, 473)
        pnlStudent.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        pnlPersonDetails.ResumeLayout(False)
        pnlPersonDetails.PerformLayout()
        lblGB.ResumeLayout(False)
        lblGB.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlStudent As Panel
    Friend WithEvents btnUploadReportCard As Button
    Friend WithEvents btnUploadBirthCertificate As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbParentGuardian As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents cmbGradeLevel As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDOB As DateTimePicker
    Friend WithEvents cmbSex As ComboBox
    Friend WithEvents txtFname As TextBox
    Friend WithEvents txtMname As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtLname As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSaveStudent As Button
    Friend WithEvents btnAddNewParent As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbClassRoomAss As ComboBox
    Friend WithEvents clbSubjects As CheckedListBox
    Friend WithEvents btnDeleteStudent As Button
    Friend WithEvents btnEditStudent As Button
    Friend WithEvents btnSearchStudent As Button
    Friend WithEvents txtSearchStudent As TextBox
    Friend WithEvents lblSearchStudent As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents btnBack As Button
    Friend WithEvents pnlPersonDetails As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSearchPerson As Button
    Friend WithEvents txtSearchPerson As TextBox
    Friend WithEvents lblsearch As Label
    Friend WithEvents lblGB As GroupBox
    Friend WithEvents btnDeletepd As Button
    Friend WithEvents btnEditpd As Button
    Friend WithEvents txtRelationshippd As TextBox
    Friend WithEvents lblRelatioshippd As Label
    Friend WithEvents btnSavepd As Button
    Friend WithEvents dtpDOBpd As DateTimePicker
    Friend WithEvents lblDOBpd As Label
    Friend WithEvents txtContactInfopd As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbSexpd As ComboBox
    Friend WithEvents txtFnamepd As TextBox
    Friend WithEvents txtMnamepd As TextBox
    Friend WithEvents txtAddresspd As TextBox
    Friend WithEvents txtLnamepd As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblpdname As Label

End Class
