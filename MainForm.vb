Public Class MainForm
    ' Placeholder for the currently displayed UserControl
    Private currentControl As UserControl = Nothing

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
End Class
