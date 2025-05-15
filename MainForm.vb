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

        ' Option 1: Directly clear the form's controls (if that's your design)
        If currentControl IsNot Nothing Then
            Debug.WriteLine("Removing current control: " & currentControl.GetType().ToString())
            Controls.Remove(currentControl)
        End If



        ' Set new UserControl for this example using the MainForm itself:
        currentControl = newControl
        newControl.Dock = DockStyle.Fill
        Debug.WriteLine("Adding new control: " & newControl.GetType().ToString())
        Controls.Add(newControl)
        newControl.BringToFront()
        Debug.WriteLine("New control should now be visible on the form.")



    End Sub

    ' Menu item click events—each sets DisplayTracker and then loads the appropriate control
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

        txtPassword2.Visible = False
        lblPassword2.Visible = False
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
        If isCreatingAccount Then
            ' Register a new account
            RegisterUser(txtAdminName.Text.Trim(), txtPassword.Text.Trim(), txtPassword2.Text.Trim())
        Else
            ' Attempt login
            AuthenticateUser(txtAdminName.Text.Trim(), txtPassword.Text.Trim())
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
            LoadTeacherData(1)

            LoadSections()
            LoadGradeLevels()
            LoadEnrollmentChart()


            Panel1.Visible = True
            Panel2.Visible = True
            Panel3.Visible = True
            Panel4.Visible = True

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

        ' Show the second password field (for confirmation)
        txtPassword2.Visible = True
        lblPassword2.Visible = True

        ' Change button text from "Login" to "Save"
        Button1.Text = "Save"
    End Sub

    Private Sub RegisterUser(username As String, password1 As String, password2 As String)
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password1) OrElse String.IsNullOrEmpty(password2) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If password1 <> password2 Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            opencon(db_name)

            ' Hash password
            Dim hashedPassword As String = ComputeSHA256Hash(password1)

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

        Catch ex As Exception
            MessageBox.Show("Error creating account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function ComputeSHA256Hash(input As String) As String
        Dim sha256 As SHA256 = sha256.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Function

    Private Sub LoadStudentData(Optional page As Integer = 1)
        Try
            ' Open MySQL connection using your existing opencon() method.
            opencon(db_name)

            Dim pageSize As Integer = 20
            Dim offset As Integer = (page - 1) * pageSize

            ' SQL query with joins based on your ERD and added pagination.
            Dim query As String = "SELECT " &
            "s.Student_ID, " &
            "CONCAT(s.Lname, ', ', s.Fname, ' ', s.Midname) AS StudentName, " &
            "s.DOB, " &
            "s.Sex, " &
            "CONCAT(pg.Lname, ', ', pg.Fname, ' ', pg.Midname) AS ParentGuardian, " &
            "sec.Section_Name AS Section, " &
            "gl.Grade_Name AS GradeLevel, " &
            "r.Submission_Status AS RequirementStatus " &
            "FROM student s " &
            "LEFT JOIN belong_to bt ON s.Student_ID = bt.Student_ID " &
            "LEFT JOIN parent_guardian pg ON bt.Parent_Guardian_ID = pg.Parent_Guardian_ID " &
            "LEFT JOIN belongs_to bsec ON s.Student_ID = bsec.Student_ID " &
            "LEFT JOIN section sec ON bsec.Section_ID = sec.Section_ID " &
            "LEFT JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
            "LEFT JOIN requirements r ON s.Student_ID = r.Student_ID " &
            "ORDER BY s.Student_ID " &
            "LIMIT " & pageSize & " OFFSET " & offset

            Dim dt As New DataTable()
            Using adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using

            ' Bind the DataTable as the DataSource for dgvStudent.
            dgvStudent.DataSource = dt

            ' Map the original column names to user-friendly headers.
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

            ' Loop through the mapping and update the DataGridView headers.
            For Each kvp As KeyValuePair(Of String, String) In friendlyHeaders
                If dgvStudent.Columns.Contains(kvp.Key) Then
                    dgvStudent.Columns(kvp.Key).HeaderText = kvp.Value
                End If
            Next

            ' Apply modern styling to the DataGridView.
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

        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message)
        Finally
            ' Ensure the connection is closed.
            conn.Close()
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

            ' Calculate total number of pages, assuming 20 records per page.
            Dim totalPages As Integer = Math.Ceiling(totalRecords / 20D)
            NumericUpDown1.Minimum = 1
            NumericUpDown1.Maximum = If(totalPages > 0, totalPages, 1)
        Catch ex As Exception
            MessageBox.Show("Error getting total page count: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        ' Get the selected page from NumericUpDown and call LoadStudentData with it.
        Dim selectedPage As Integer = NumericUpDown1.Value
        LoadStudentData(selectedPage)
    End Sub

    Private Sub LoadTeacherData(Optional page As Integer = 1)
        Try
            ' Open MySQL connection using your existing opencon() method.
            opencon(db_name)

            Dim pageSize As Integer = 20
            Dim offset As Integer = (page - 1) * pageSize

            ' SQL query with joins to get teacher details, contact info, and the subjects they teach.
            ' GROUP_CONCAT is used to combine all subjects for a teacher into one comma‐separated string.
            Dim query As String = "SELECT " &
            "t.Teacher_ID, " &
            "CONCAT(t.Lname, ', ', t.Fname, ' ', t.Midname) AS TeacherName, " &
            "t.Sex, " &
            "t.Contact_Info AS ContactInfo, " &
            "GROUP_CONCAT(sub.Subject_Name SEPARATOR ', ') AS SubjectsTaught " &
            "FROM teacher t " &
            "LEFT JOIN taught_by tb ON t.Teacher_ID = tb.Teacher_ID " &
            "LEFT JOIN subject sub ON tb.Subject_ID = sub.Subject_ID " &
            "GROUP BY t.Teacher_ID " &
            "ORDER BY t.Teacher_ID " &
            "LIMIT " & pageSize & " OFFSET " & offset

            Dim dt As New DataTable()
            Using adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using

            ' Bind the DataTable as the DataSource for dgvTeachers.
            dgvTeachers.DataSource = dt

            ' Map the original column names to user-friendly headers.
            Dim friendlyHeaders As New Dictionary(Of String, String) From {
            {"Teacher_ID", "Teacher ID"},
            {"TeacherName", "Teacher Name"},
            {"DOB", "Date of Birth"},
            {"Sex", "Sex"},
            {"ContactInfo", "Contact Information"},
            {"SubjectsTaught", "Subjects Taught"}
        }

            ' Loop through the mapping and update the DataGridView headers.
            For Each kvp As KeyValuePair(Of String, String) In friendlyHeaders
                If dgvTeachers.Columns.Contains(kvp.Key) Then
                    dgvTeachers.Columns(kvp.Key).HeaderText = kvp.Value
                End If
            Next

            ' Apply modern styling to the DataGridView.
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

        Catch ex As Exception
            MessageBox.Show("Error loading teacher data: " & ex.Message)
        Finally
            ' Ensure the connection is closed.
            conn.Close()
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
                query = "SELECT s.Section_Name AS Section, s.Total_Students AS TotalEnrolled " &
                    "FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "WHERE gl.Grade_Name = @GradeLevel " &
                    "GROUP BY s.Section_Name"
            ElseIf hasGrade And hasSection Then
                query = "SELECT s.Section_Name AS Section, s.Total_Students AS TotalEnrolled " &
                    "FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "WHERE gl.Grade_Name = @GradeLevel AND s.Section_Name = @Section " &
                    "GROUP BY s.Section_Name"
            Else
                query = "SELECT s.Section_Name AS Section, s.Total_Students AS TotalEnrolled " &
                    "FROM section s " &
                    "GROUP BY s.Section_Name"
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
                titleText = "Enrollment by Section for Grade " & gradeFilter
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



    Private Sub LoadSections(Optional ByVal gradeFilter As String = "")
        Try
            opencon(db_name)
            Dim dt As New DataTable()
            Dim query As String = ""

            If String.IsNullOrEmpty(gradeFilter) OrElse gradeFilter = "All" Then
                query = "SELECT DISTINCT Section_Name FROM section ORDER BY Section_Name"
            Else
                query = "SELECT s.Section_Name FROM section s " &
                    "INNER JOIN grade_level gl ON s.Grade_Level_ID = gl.Grade_Level_ID " &
                    "WHERE gl.Grade_Name = @GradeLevel ORDER BY s.Section_Name"
            End If

            Dim cmd As New MySqlCommand(query, conn)
            If Not String.IsNullOrEmpty(gradeFilter) AndAlso gradeFilter <> "All" Then
                cmd.Parameters.AddWithValue("@GradeLevel", gradeFilter)
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)

            cmbSection.Items.Clear()
            cmbSection.Items.Add("All")  ' "All" for no filtering

            For Each row As DataRow In dt.Rows
                cmbSection.Items.Add(row("Section_Name").ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading sections: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub LoadGradeLevels()
        Try
            opencon(db_name)
            Dim dt As New DataTable()
            Dim query As String = "SELECT DISTINCT Grade_Name FROM grade_level ORDER BY Grade_Name"
            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.Fill(dt)

            cmbGradeLevel.Items.Clear()
            cmbGradeLevel.Items.Add("All")  ' "All" for no filtering

            For Each row As DataRow In dt.Rows
                cmbGradeLevel.Items.Add(row("Grade_Name").ToString())
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading grade levels: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    ' When grade level changes, reload sections to match the selected grade.
    Private Sub cmbGradeLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGradeLevel.SelectedIndexChanged
        Dim selectedGrade As String = cmbGradeLevel.SelectedItem.ToString()
        LoadSections(selectedGrade)
        LoadEnrollmentChart()
    End Sub

    ' Update the chart when the section selection changes.
    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        LoadEnrollmentChart()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

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
        LoadTeacherData(1)

        LoadSections()
        LoadGradeLevels()
        LoadEnrollmentChart()


        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        Panel4.Visible = True

        If currentControl IsNot Nothing AndAlso currentControl.Visible Then
            currentControl.Hide()
        End If

    End Sub
End Class
