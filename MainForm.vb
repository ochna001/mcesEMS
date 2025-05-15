Imports System.Text
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe
Imports System.Security.Cryptography


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

        ' Option 2 (recommended): Use a dedicated panel (for example, pnlMain)
        ' If you have a dedicated panel, use:
        ' pnlMain.Controls.Clear()
        ' pnlMain.Controls.Add(newControl)
        ' newControl.Dock = DockStyle.Fill

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
    End Sub

    Private Sub TeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeacherToolStripMenuItem.Click
        Debug.WriteLine("Teacher menu clicked.")
        DisplayTracker = 2
        LoadUserControl(New PersonForm())
    End Sub

    Private Sub ParentGuardianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParentGuardianToolStripMenuItem.Click
        Debug.WriteLine("Parent/Guardian menu clicked.")
        DisplayTracker = 3
        LoadUserControl(New PersonForm())
    End Sub

    Private Sub ClassroomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassroomToolStripMenuItem.Click
        Debug.WriteLine("Classroom menu clicked.")
        DisplayTracker = 10
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub SubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectToolStripMenuItem.Click
        Debug.WriteLine("Subject menu clicked.")
        DisplayTracker = 12
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub SectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SectionToolStripMenuItem.Click
        Debug.WriteLine("Section menu clicked.")
        DisplayTracker = 11
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("MainForm_Load event called.")
        InitializeGradeLevels()
        MenuStrip1.Visible = False

        txtPassword2.Visible = False
        lblPassword2.Visible = False
    End Sub

    Private Sub searchTeacherToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles searchTeacherToolStripMenuItem1.Click
        Debug.WriteLine("Searching for Teacher...")
        DisplayTracker = 21
        LoadUserControl(New PersonForm())
    End Sub

    Private Sub searchParentGuardianToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles searchParentGuardianToolStripMenuItem1.Click
        Debug.WriteLine("Searching for Parent/Guardian...")
        DisplayTracker = 31
        LoadUserControl(New PersonForm())
    End Sub

    Private Sub SubjectToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClassroomToolStripMenuItem1.Click
        DisplayTracker = 20
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub SubjectToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SubjectToolStripMenuItem2.Click
        DisplayTracker = 22
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub SectionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SectionToolStripMenuItem1.Click
        DisplayTracker = 21
        LoadUserControl(New AcademicForm())
    End Sub

    Private Sub searchStudentToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles searchStudentToolStripMenuItem2.Click
        DisplayTracker = 11
        LoadUserControl(New PersonForm())
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


End Class
