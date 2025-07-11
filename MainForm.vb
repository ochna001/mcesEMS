Imports System.Text
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe
Imports System.Security.Cryptography
Imports System.Windows.Forms.DataVisualization.Charting


Public Class MainForm
    ' Placeholder for the currently displayed UserControl
    Private currentControl As UserControl = Nothing
    Private isCreatingAccount As Boolean = False


    ' Method to switch panels dynamically
    Private Sub LoadUserControl(newControl As UserControl)
        Debug.WriteLine("LoadUserControl called. New control type: " & newControl.GetType().ToString())

        If currentControl IsNot Nothing Then
            Debug.WriteLine("Removing current control: " & currentControl.GetType().ToString())
            Controls.Remove(currentControl)
        End If

        currentControl = newControl
        newControl.Dock = DockStyle.Fill
        Debug.WriteLine("Adding new control: " & newControl.GetType().ToString())
        Controls.Add(newControl)
        newControl.BringToFront()
        Debug.WriteLine("New control should now be visible on the form.")
    End Sub

    ' Menu item click events—each sets DisplayTracker and then loads the appropriate control
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        ' Ask for confirmation before logging out
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", 
                                                   "Confirm Logout", 
                                                   MessageBoxButtons.YesNo, 
                                                   MessageBoxIcon.Question)
        
        If result = DialogResult.Yes Then
            ' Show login panel and hide main content
            GroupBox1.Show()
            MenuStrip1.Visible = False

            ' Hide all main content panels
            Label3.Visible = False
            dgvStudent.Visible = False
            NumericUpDown1.Visible = False
            Label4.Visible = False
            dgvTeachers.Visible = False
            NumericUpDown2.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            Panel4.Visible = False

            ' Clear any existing user control
            If currentControl IsNot Nothing Then
                currentControl.Dispose()
                Controls.Remove(currentControl)
                currentControl = Nothing
            End If

            ' Clear login fields
            txtAdminName.Text = ""
            txtPassword.Text = ""
            txtPassword2.Text = ""

            ' Reset to login mode if in account creation mode
            isCreatingAccount = False
            txtPassword2.Visible = False
            lblPassword2.Visible = False
            Button1.Text = "Login"
            btnCancel.Visible = False
            
            ' Set focus to username field
            txtAdminName.Focus()
            
            ' Show logout success message
            MessageBox.Show("You have been successfully logged out.", "Logout Successful", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        Debug.WriteLine("Student menu clicked.")
        DisplayTracker = 1
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub TeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeacherToolStripMenuItem.Click
        Debug.WriteLine("Teacher menu clicked.")
        DisplayTracker = 2
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub ParentGuardianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParentGuardianToolStripMenuItem.Click
        Debug.WriteLine("Parent/Guardian menu clicked.")
        DisplayTracker = 3
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub ClassroomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassroomToolStripMenuItem.Click
        Debug.WriteLine("Classroom menu clicked.")
        DisplayTracker = 10
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub SubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectToolStripMenuItem.Click
        Debug.WriteLine("Subject menu clicked.")
        DisplayTracker = 12
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub SectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SectionToolStripMenuItem.Click
        Debug.WriteLine("Section menu clicked.")
        DisplayTracker = 11
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("MainForm_Load event called.")
        InitializeGradeLevels()
        MenuStrip1.Visible = False
        btnCancel.Visible = False

        txtPassword2.Visible = False
        lblPassword2.Visible = False
        Label3.Visible = False
        dgvStudent.Visible = False
        NumericUpDown1.Visible = False

        ' Initialize NumericUpDown1 properties
        NumericUpDown1.Minimum = 1
        NumericUpDown1.Maximum = 1
        NumericUpDown1.Value = 1
        NumericUpDown1.ReadOnly = False
        NumericUpDown1.Enabled = True
        ' Explicitly attach the event handler
        AddHandler NumericUpDown1.ValueChanged, AddressOf NumericUpDown1_ValueChanged

        Label4.Visible = False
        dgvTeachers.Visible = False
        NumericUpDown2.Visible = False
        ' Same initialization for NumericUpDown2
        NumericUpDown2.Minimum = 1
        NumericUpDown2.Maximum = 1
        NumericUpDown2.Value = 1
        NumericUpDown2.ReadOnly = False
        NumericUpDown2.Enabled = True
        AddHandler NumericUpDown2.ValueChanged, AddressOf NumericUpDown2_ValueChanged

        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub searchTeacherToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles searchTeacherToolStripMenuItem1.Click
        Debug.WriteLine("Searching for Teacher...")
        DisplayTracker = 21
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub searchParentGuardianToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles searchParentGuardianToolStripMenuItem1.Click
        Debug.WriteLine("Searching for Parent/Guardian...")
        DisplayTracker = 31
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub SubjectToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClassroomToolStripMenuItem1.Click
        DisplayTracker = 20
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub SubjectToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SubjectToolStripMenuItem2.Click
        DisplayTracker = 22
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub SectionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SectionToolStripMenuItem1.Click
        DisplayTracker = 21
        LoadUserControl(New AcademicForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub searchStudentToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles searchStudentToolStripMenuItem2.Click
        DisplayTracker = 11
        LoadUserControl(New PersonForm())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Input validation
        If String.IsNullOrWhiteSpace(txtAdminName.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdminName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If isCreatingAccount Then
            ' Additional validation for account creation
            If String.IsNullOrWhiteSpace(txtPassword2.Text) Then
                MessageBox.Show("Please confirm your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword2.Focus()
                Return
            End If

            If txtPassword.Text.Length < 8 Then
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If

            ' Register a new account
            RegisterUser(txtAdminName.Text.Trim(), txtPassword.Text.Trim(), txtPassword2.Text.Trim())
        Else
            ' Attempt login
            Me.Cursor = Cursors.WaitCursor
            Try
                If AuthenticateUser(txtAdminName.Text.Trim(), txtPassword.Text.Trim()) Then
                    GroupBox1.Hide()
                    MenuStrip1.Visible = True

                    ' First set up the paginations before showing data
                    SetPagingLimits()
                    SetTeacherPagingLimits()

                    ' Now set up the UI elements
                    Label3.Visible = True
                    dgvStudent.Visible = True
                    NumericUpDown1.Visible = True
                    NumericUpDown1.Enabled = True

                    ' Load initial data (page 1)
                    LoadStudentData(1)

                    Label4.Visible = True
                    dgvTeachers.Visible = True
                    NumericUpDown2.Visible = True
                    LoadTeacherData(1)

                    LoadGradeLevels(cmbGradeLevel)
                    LoadSections(cmbGradeLevel, cmbSection)
                    LoadEnrollmentChart()

                    Panel1.Visible = True
                    Panel2.Visible = True
                    Panel3.Visible = True
                    Panel4.Visible = True
                    
                    ' Show login success message
                    MessageBox.Show("Login successful! Welcome, " & txtAdminName.Text.Trim() & ".", 
                                  "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Show login failed message
                    MessageBox.Show("Invalid username or password. Please try again.", 
                                  "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPassword.SelectAll()
                    txtPassword.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred during login: " & ex.Message, 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            opencon(db_name)

            ' Hash input password for comparison
            Dim hashedPassword As String = ComputeSHA256Hash(password)

            ' Query to verify credentials
            Dim sql As String = "SELECT COUNT(*) FROM Admin WHERE Adminname = @Username AND Password = @Password"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", hashedPassword)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0 ' Returns True if credentials match
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conn.Close()
        End Try

    End Function


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Switch mode to "Creating Account"
        isCreatingAccount = True
        btnCancel.Visible = True

        ' Show the second password field (for confirmation)
        txtPassword2.Visible = True
        lblPassword2.Visible = True

        ' Change button text from "Login" to "Save"
        Button1.Text = "Save"
    End Sub

    Private Sub RegisterUser(username As String, password_1 As String, password_2 As String)
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password_1) OrElse String.IsNullOrEmpty(password_2) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If password_1 <> password_2 Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            opencon(db_name)

            ' Hash password
            Dim hashedPassword As String = ComputeSHA256Hash(password_1)

            ' Insert new user into the database
            Dim sql As String = "INSERT INTO Admin (Adminname, Password) VALUES (@Username, @Password)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", hashedPassword)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset form back to login mode
            isCreatingAccount = False
            txtPassword2.Visible = False
            lblPassword2.Visible = False
            Button1.Text = "Login"
            btnCancel.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error creating account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Reset form back to login mode
        isCreatingAccount = False
        txtPassword2.Visible = False
        lblPassword2.Visible = False
        Button1.Text = "Login"
        btnCancel.Visible = False
    End Sub

    Private Function ComputeSHA256Hash(input As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Function

    Private Async Sub LoadStudentData(Optional page As Integer = 1)
        Me.Cursor = Cursors.WaitCursor
        dgvStudent.Enabled = False

        Try
            Dim dt As DataTable = Await Task.Run(Function()
                                                     Dim pageSize As Integer = 10
                                                     Dim offset As Integer = (page - 1) * pageSize
                                                     Dim dataTable As New DataTable()

                                                     Using connection As New MySqlConnection(GetConnectionString())
                                                         connection.Open()
                                                         Dim query As String = "SELECT " &
                        "s.Student_ID, " &
                        "CONCAT(s.Lname, ', ', s.Fname, ' ', s.Midname) AS StudentName, " &
                        "s.DOB, " &
                        "s.Sex, " &
                        "GROUP_CONCAT(DISTINCT CONCAT(pg.Fname, ' ', pg.Lname) SEPARATOR ', ') AS ParentGuardian, " &
                        "MAX(sec.Section_Name) AS Section, " &
                        "MAX(gl.Grade_Name) AS GradeLevel, " &
                        "MAX(r.Submission_Status) AS RequirementStatus " &
                        "FROM student s " &
                        "LEFT JOIN belong_to bt ON s.Student_ID = bt.Student_ID " &
                        "LEFT JOIN parent_guardian pg ON bt.Parent_Guardian_ID = pg.Parent_Guardian_ID " &
                        "LEFT JOIN belongs_to bsec ON s.Student_ID = bsec.Student_ID " &
                        "LEFT JOIN section sec ON bsec.Section_ID = sec.Section_ID " &
                        "LEFT JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                        "LEFT JOIN requirements r ON s.Student_ID = r.Student_ID " &
                        "GROUP BY s.Student_ID " &
                        "ORDER BY s.Student_ID " &
                        "LIMIT " & pageSize & " OFFSET " & offset

                                                         Using adapter As New MySqlDataAdapter(query, connection)
                                                             adapter.Fill(dataTable)
                                                         End Using
                                                     End Using
                                                     Return dataTable
                                                 End Function)

            dgvStudent.SuspendLayout()
            dgvStudent.DataSource = dt

            Dim friendlyHeaders As New Dictionary(Of String, String) From {
                {"Student_ID", "Student ID"},
                {"StudentName", "Student Name"},
                {"DOB", "Date of Birth"},
                {"Sex", "Sex"},
                {"ParentGuardian", "Parent/Guardian"},
                {"Section", "Section"},
                {"GradeLevel", "Grade Level"},
                {"RequirementStatus", "Requirement Status"}
            }

            For Each kvp As KeyValuePair(Of String, String) In friendlyHeaders
                If dgvStudent.Columns.Contains(kvp.Key) Then
                    dgvStudent.Columns(kvp.Key).HeaderText = kvp.Value
                End If
            Next

            With dgvStudent
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Padding = New Padding(10)
                .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                .EnableHeadersVisualStyles = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64)
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .RowTemplate.Height = 40
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(144, 202, 249)
                .DefaultCellStyle.SelectionForeColor = Color.Black
            End With

            dgvStudent.ResumeLayout()

        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message)
        Finally
            dgvStudent.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SetPagingLimits()
        Try
            opencon(db_name)
            Dim countQuery As String = "SELECT COUNT(*) FROM student"
            Dim totalRecords As Integer

            Using cmd As New MySqlCommand(countQuery, conn)
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            Dim totalPages As Integer = Math.Ceiling(totalRecords / 10.0)

            NumericUpDown1.Minimum = 1
            NumericUpDown1.Maximum = If(totalPages > 0, totalPages, 1)

            If NumericUpDown1.Value > NumericUpDown1.Maximum Then
                NumericUpDown1.Value = NumericUpDown1.Maximum
            ElseIf NumericUpDown1.Value < NumericUpDown1.Minimum Then
                NumericUpDown1.Value = NumericUpDown1.Minimum
            End If

        Catch ex As Exception
            MessageBox.Show("Error getting total page count: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Dim selectedPage As Integer = Convert.ToInt32(NumericUpDown1.Value)
        LoadStudentData(selectedPage)
    End Sub

    Private Async Sub LoadTeacherData(Optional page As Integer = 1)
        Me.Cursor = Cursors.WaitCursor
        dgvTeachers.Enabled = False

        Try
            Dim dt As DataTable = Await Task.Run(Function()
                                                     Dim pageSize As Integer = 10
                                                     Dim offset As Integer = (page - 1) * pageSize
                                                     Dim dataTable As New DataTable()

                                                     Using connection As New MySqlConnection(GetConnectionString())
                                                         connection.Open()
                                                         Dim query As String = "SELECT " &
                        "t.Teacher_ID, " &
                        "t.Fname, " &
                        "t.Lname, " &
                        "t.Contact_info, " &
                        "GROUP_CONCAT(DISTINCT s.Subject_Name SEPARATOR ', ') AS SubjectsTaught " &
                        "FROM teacher t " &
                        "LEFT JOIN taught_by tb ON t.Teacher_ID = tb.Teacher_ID " &
                        "LEFT JOIN subject s ON tb.Subject_ID = s.Subject_ID " &
                        "GROUP BY t.Teacher_ID " &
                        "ORDER BY t.Teacher_ID " &
                        "LIMIT " & pageSize & " OFFSET " & offset

                                                         Using adapter As New MySqlDataAdapter(query, connection)
                                                             adapter.Fill(dataTable)
                                                         End Using
                                                     End Using
                                                     Return dataTable
                                                 End Function)

            dgvTeachers.SuspendLayout()
            dgvTeachers.DataSource = dt

            Dim teacherHeaders As New Dictionary(Of String, String) From {
                {"Teacher_ID", "Teacher ID"},
                {"Fname", "First Name"},
                {"Lname", "Last Name"},
                {"Contact_info", "Contact Number"},
                {"SubjectsTaught", "Subjects Taught"}
            }

            For Each kvp As KeyValuePair(Of String, String) In teacherHeaders
                If dgvTeachers.Columns.Contains(kvp.Key) Then
                    dgvTeachers.Columns(kvp.Key).HeaderText = kvp.Value
                End If
            Next

            With dgvTeachers
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Padding = New Padding(10)
                .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                .EnableHeadersVisualStyles = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64)
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .RowTemplate.Height = 40
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(144, 202, 249)
                .DefaultCellStyle.SelectionForeColor = Color.Black
            End With

            dgvTeachers.ResumeLayout()

        Catch ex As Exception
            MessageBox.Show("Error loading teacher data: " & ex.Message)
        Finally
            dgvTeachers.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        ' Get the selected page from NumericUpDown2 and reload the teacher data accordingly.
        Dim selectedPage As Integer = NumericUpDown2.Value
        LoadTeacherData(selectedPage)
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Sub LoadEnrollmentChart()
        Try
            ' Open connection using your existing opencon() method.
            opencon(db_name)

            Dim dt As New DataTable()
            Dim query As String = ""

            ' Retrieve current selections.
            Dim gradeFilter As String = ""
            Dim sectionFilter As String = ""

            If cmbGradeLevel.SelectedItem IsNot Nothing Then
                gradeFilter = cmbGradeLevel.SelectedItem.ToString()
            End If
            If cmbSection.SelectedItem IsNot Nothing Then
                sectionFilter = cmbSection.SelectedItem.ToString()
            End If

            ' Consider "All" as no filter.
            Dim hasGrade As Boolean = (Not String.IsNullOrEmpty(gradeFilter) AndAlso gradeFilter <> "All")
            Dim hasSection As Boolean = (Not String.IsNullOrEmpty(sectionFilter) AndAlso sectionFilter <> "All")

            ' Build the SQL query based on the applied filters.
            If Not hasGrade AndAlso Not hasSection Then
                query = "SELECT gl.Grade_Name AS GradeLevel, SUM(s.Total_Students) AS TotalEnrolled " &
                    "FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "GROUP BY gl.Grade_Name"
            ElseIf hasGrade And Not hasSection Then
                query = "SELECT sec.Section_Name AS Section, COUNT(bt.Student_ID) AS TotalEnrolled " &
                    "FROM section sec " &
                    "LEFT JOIN belongs_to bt ON sec.Section_ID = bt.Section_ID " &
                    "WHERE sec.Grade_Level_ID = (SELECT Grade_Level_ID FROM grade_level WHERE Grade_Name = @GradeLevel) " &
                    "GROUP BY sec.Section_Name " &
                    "ORDER BY TotalEnrolled DESC LIMIT 10"
            ElseIf hasGrade And hasSection Then
                query = "SELECT s.Section_Name AS Section, s.Total_Students AS TotalEnrolled " &
                    "FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "WHERE gl.Grade_Name = @GradeLevel AND s.Section_Name = @Section " &
                    "GROUP BY s.Section_Name"
            Else
                query = "SELECT sec.Section_Name AS Section, COUNT(bt.Student_ID) AS TotalEnrolled " &
                    "FROM section sec " &
                    "LEFT JOIN belongs_to bt ON sec.Section_ID = bt.Section_ID " &
                    "WHERE sec.Section_Name = @Section " &
                    "GROUP BY sec.Section_Name"
            End If

            Dim cmd As New MySqlCommand(query, conn)
            If hasGrade Then
                cmd.Parameters.AddWithValue("@GradeLevel", gradeFilter)
            End If
            If hasSection Then
                cmd.Parameters.AddWithValue("@Section", sectionFilter)
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            ' Clear any previous settings on Chart1.
            Chart1.Series.Clear()
            Chart1.ChartAreas.Clear()
            Chart1.Titles.Clear()
            Chart1.Legends.Clear()

            ' Configure the Chart Area.
            Dim chartArea As New ChartArea("EnrollmentArea")
            With chartArea
                .BackColor = Color.White
                .AxisX.MajorGrid.LineColor = Color.LightGray
                .AxisY.MajorGrid.LineColor = Color.LightGray
                .AxisX.Interval = 1
                .AxisX.IsMarginVisible = True
                .AxisY.Minimum = 0
            End With
            Chart1.ChartAreas.Add(chartArea)

            ' Set overall appearance.
            Chart1.Palette = ChartColorPalette.BrightPastel  ' You can change the palette if required.
            Chart1.BackColor = Color.WhiteSmoke

            ' Create and configure the Legend.
            Dim legend As New Legend("EnrollmentLegend")
            With legend
                .Docking = Docking.Bottom
                .Alignment = StringAlignment.Center
                .BorderColor = Color.LightGray
                .BorderWidth = 1
                .BackColor = Color.White
                .Font = New Font("Verdana", 9)
            End With
            Chart1.Legends.Add(legend)

            ' Create the chart series.
            If Not hasGrade AndAlso Not hasSection Then
                ' Unfiltered view: each grade as its own series (bars won't overlap).
                For Each row As DataRow In dt.Rows
                    Dim grade As String = row("GradeLevel").ToString()
                    Dim total As Integer = Convert.ToInt32(row("TotalEnrolled"))
                    Dim s As New Series(grade)
                    s.ChartType = SeriesChartType.Column
                    s.IsValueShownAsLabel = True

                    s.Points.AddXY(grade, total)
                    s.BorderWidth = 2
                    s.BorderColor = Color.DarkGray

                    s.Legend = "EnrollmentLegend"
                    Chart1.Series.Add(s)
                Next
            Else
                ' Filtered view: use a single series.
                Dim series As New Series("Enrollment")
                series.ChartType = SeriesChartType.Column
                series.IsValueShownAsLabel = True

                ' This property forces the points to be evenly distributed.
                series.IsXValueIndexed = True

                ' Adjust the bar width to avoid interlocking.
                series("PointWidth") = "0.4"
                series.BorderWidth = 2
                series.BorderColor = Color.DarkGray

                ' When filtered, assume the x-values represent Section names.
                series.XValueMember = "Section"
                series.YValueMembers = "TotalEnrolled"
                series.Legend = "EnrollmentLegend"
                Chart1.Series.Add(series)

                Chart1.DataSource = dt
                Chart1.DataBind()
            End If

            ' Set an appropriate chart title.
            Dim titleText As String = ""
            If Not hasGrade AndAlso Not hasSection Then
                titleText = "Total Enrollment by Grade Level"
            ElseIf hasGrade And Not hasSection Then
                titleText = "Top 10 Sections by Enrollment for Grade " & gradeFilter
            ElseIf hasGrade And hasSection Then
                titleText = "Enrollment for Grade " & gradeFilter & ", Section " & sectionFilter
            Else
                titleText = "Total Enrollment by Section"
            End If

            Dim title As New Title(titleText, Docking.Top, New Font("Verdana", 12, FontStyle.Bold), Color.Black)
            Chart1.Titles.Add(title)

            ' Additional formatting for axis labels.
            Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Verdana", 9)
            Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Verdana", 9)

        Catch ex As Exception
            MessageBox.Show("Error loading enrollment chart: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub SetTeacherPagingLimits()
        Try
            opencon(db_name)
            Dim countQuery As String = "SELECT COUNT(*) FROM teacher"
            Dim totalRecords As Integer

            Using cmd As New MySqlCommand(countQuery, conn)
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' Calculate total number of pages, assuming 20 records per page
            Dim totalPages As Integer = Math.Ceiling(totalRecords / 20.0)

            ' Always ensure minimum is 1 and maximum is at least 1
            NumericUpDown2.Minimum = 1
            NumericUpDown2.Maximum = If(totalPages > 0, totalPages, 1)

            ' Make sure current value is within range
            If NumericUpDown2.Value > NumericUpDown2.Maximum Then
                NumericUpDown2.Value = NumericUpDown2.Maximum
            ElseIf NumericUpDown2.Value < NumericUpDown2.Minimum Then
                NumericUpDown2.Value = NumericUpDown2.Minimum
            End If

            Debug.WriteLine($"Teacher Pagination setup: Total records = {totalRecords}, Total pages = {totalPages}")
            Debug.WriteLine($"NumericUpDown2: Min = {NumericUpDown2.Minimum}, Max = {NumericUpDown2.Maximum}, Current = {NumericUpDown2.Value}")

        Catch ex As Exception
            MessageBox.Show("Error getting teacher total page count: " & ex.Message)
            Debug.WriteLine($"Error in SetTeacherPagingLimits: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadSections(ByVal cmbGrade As ComboBox, ByVal cmbSec As ComboBox)
        Try
            opencon(db_name)
            Dim dt As New DataTable()
            Dim query As String

            If cmbGrade.SelectedIndex > 0 AndAlso cmbGrade.SelectedItem IsNot Nothing Then
                query = "SELECT s.Section_Name FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "WHERE gl.Grade_Name = @GradeLevel ORDER BY s.Section_Name"
            Else
                query = "SELECT DISTINCT Section_Name FROM section ORDER BY Section_Name"
            End If

            Using cmd As New MySqlCommand(query, conn)
                If cmbGrade.SelectedIndex > 0 AndAlso cmbGrade.SelectedItem IsNot Nothing Then
                    cmd.Parameters.AddWithValue("@GradeLevel", cmbGrade.SelectedItem.ToString())
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            cmbSec.Items.Clear()
            cmbSec.Items.Add("All")

            For Each row As DataRow In dt.Rows
                cmbSec.Items.Add(row("Section_Name").ToString())
            Next

            cmbSec.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading sections: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadGradeLevels(ByVal cmb As ComboBox)
        Try
            opencon(db_name)
            Dim dt As New DataTable()
            Dim query As String = "SELECT DISTINCT Grade_Name FROM grade_level ORDER BY Grade_Name"

            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            cmb.Items.Clear()
            cmb.Items.Add("All")

            For Each row As DataRow In dt.Rows
                cmb.Items.Add(row("Grade_Name").ToString())
            Next

            cmb.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading grade levels: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub InitializeGradeLevels()
        LoadGradeLevels(cmbGradeLevel)
    End Sub

    ' When grade level changes, reload sections to match the selected grade.
    Private Sub cmbGradeLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGradeLevel.SelectedIndexChanged
        LoadSections(cmbGradeLevel, cmbSection)
        LoadEnrollmentChart()
    End Sub

    ' Update the chart when the section selection changes.
    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        LoadEnrollmentChart()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub BackUpDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackUpDatabaseToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
        saveFileDialog.Title = "Save Database Backup"
        saveFileDialog.FileName = "mces_backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName
            Try
                Dim process As New Process()
                process.StartInfo.FileName = "C:\xampp3\mysql\bin\mysqldump.exe"
                process.StartInfo.ArgumentList.Add("--host=" & db_server)
                process.StartInfo.ArgumentList.Add("--user=" & db_uid)
                process.StartInfo.ArgumentList.Add("--password=" & db_pwd)
                process.StartInfo.ArgumentList.Add("--databases")
                process.StartInfo.ArgumentList.Add(db_name)
                process.StartInfo.ArgumentList.Add("--routines")
                process.StartInfo.ArgumentList.Add("--events")
                process.StartInfo.UseShellExecute = False
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.CreateNoWindow = True
                process.Start()

                Using writer As New System.IO.StreamWriter(filePath)
                    writer.Write(process.StandardOutput.ReadToEnd())
                End Using

                Dim errorOutput As String = process.StandardError.ReadToEnd()
                process.WaitForExit()

                If process.ExitCode = 0 Then
                    MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Backup failed: " & errorOutput, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred during backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadFileToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
        openFileDialog.Title = "Restore Database from Backup"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Try
                Dim process As New Process()
                process.StartInfo.FileName = "C:\xampp3\mysql\bin\mysql.exe"
                process.StartInfo.ArgumentList.Add("--host=" & db_server)
                process.StartInfo.ArgumentList.Add("--user=" & db_uid)
                process.StartInfo.ArgumentList.Add("--password=" & db_pwd)
                process.StartInfo.ArgumentList.Add(db_name)
                process.StartInfo.UseShellExecute = False
                process.StartInfo.RedirectStandardInput = True
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.CreateNoWindow = True
                process.Start()

                Using reader As New System.IO.StreamReader(filePath)
                    process.StandardInput.Write(reader.ReadToEnd())
                    process.StandardInput.Close()
                End Using

                Dim errorOutput As String = process.StandardError.ReadToEnd()
                process.WaitForExit()

                If process.ExitCode = 0 Then
                    MessageBox.Show("Database restore completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Restore failed: " & errorOutput, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred during restore: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        GroupBox1.Hide()

        MenuStrip1.Visible = True

        Label3.Visible = True
        dgvStudent.Visible = True
        SetPagingLimits()  ' Sets up the NumericUpDown limits
        LoadStudentData(1)
        NumericUpDown1.Visible = True


        Label4.Visible = True
        dgvTeachers.Visible = True
        NumericUpDown2.Visible = True

        SetTeacherPagingLimits()
        LoadTeacherData(1)

        LoadGradeLevels(cmbGradeLevel)
        LoadSections(cmbGradeLevel, cmbSection)
        LoadEnrollmentChart()


        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        Panel4.Visible = True

        If currentControl IsNot Nothing AndAlso currentControl.Visible Then
            currentControl.Hide()
        End If

    End Sub

    Private Sub EnrollmentListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollmentListToolStripMenuItem.Click
        pnlReportConfig.Visible = True
        LoadGradeLevels(cmbReportGradeLevel)
    End Sub

    Private Sub btnCloseReportPanel_Click(sender As Object, e As EventArgs) Handles btnCloseReportPanel.Click
        pnlReportConfig.Visible = False
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        Dim gradeLevel As String = If(cmbReportGradeLevel.SelectedItem IsNot Nothing AndAlso cmbReportGradeLevel.SelectedIndex > 0, cmbReportGradeLevel.SelectedItem.ToString(), "All")
        Dim section As String = If(cmbReportSection.SelectedItem IsNot Nothing AndAlso cmbReportSection.SelectedIndex > 0, cmbReportSection.SelectedItem.ToString(), "All")

        Try
            opencon(db_name)

            Dim query As String = "SELECT g.Grade_Name, sec.Section_Name, COUNT(s.Student_ID) AS TotalStudents " &
                                  "FROM student s " &
                                  "JOIN belongs_to b ON s.Student_ID = b.Student_ID " &
                                  "JOIN section sec ON b.Section_ID = sec.Section_ID " &
                                  "JOIN grade_level g ON s.Grade_Level_ID = g.Grade_Level_ID "

            Dim groupBy As String = " GROUP BY g.Grade_Name, sec.Section_Name ORDER BY g.Grade_Name, sec.Section_Name"

            Dim conditions As New List(Of String)
            If gradeLevel <> "All" Then
                conditions.Add("g.Grade_Name = @GradeLevel")
            End If
            If section <> "All" Then
                conditions.Add("sec.Section_Name = @Section")
            End If

            If conditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", conditions)
            End If

            query &= groupBy

            Dim cmd As New MySqlCommand(query, conn)
            If gradeLevel <> "All" Then
                cmd.Parameters.AddWithValue("@GradeLevel", gradeLevel)
            End If
            If section <> "All" Then
                cmd.Parameters.AddWithValue("@Section", section)
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            conn.Close()

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data found for the selected filters.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Create and show the report viewer form
            Dim reportForm As New ReportViewerForm(dt)
            reportForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating the report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub cmbReportGradeLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportGradeLevel.SelectedIndexChanged
        LoadSections(cmbReportGradeLevel, cmbReportSection)
    End Sub


End Class
