Imports MySql.Data.MySqlClient
Imports System.IO

Public Class PersonForm

    Private selectedPersonID As String = ""
    Private selectedStudentID As String = ""
    Private uploadedFileName As String = ""
    Private lastInsertedStudentID As String = ""
    Private selectedFileData() As Byte = Nothing
    Private selectedReportCardData() As Byte = Nothing
    Private selectedReportCardName As String = ""
    Private selectedFileName As String = ""




    '--------------------------
    ' Form Load Process
    '--------------------------
    Private Sub PersonForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hide all panels initially
        pnlStudent.Visible = False
        pnlPersonDetails.Visible = False
        LinkLabel1.Visible = False
        LinkLabel2.Visible = False
        ' Show the correct panel based on DisplayTracker:
        '    1 = Student Enrollment, 2 = Teacher, 3 = Parent/Guardian.
        '    11 = Search/Edit Student, 21 = Search/Edit Teacher, 31 = Search/Edit Parent/Guardian.
        Select Case DisplayTracker
            Case 1
                pnlStudent.Visible = True
                Me.Text = "Enroll Student"
                InitializeFormControls()   ' Initialize only grade level combo box
                txtSearchStudent.Visible = False
                btnSearchStudent.Visible = False
                lblSearchStudent.Visible = False
                btnEditStudent.Visible = False
                btnDeleteStudent.Visible = False

            Case 11
                pnlStudent.Visible = True
                Me.Text = "Search Student"
                GroupBox1.Text = "Student Information"
                InitializeFormControls()
                txtSearchStudent.Visible = True
                btnSearchStudent.Visible = True
                lblSearchStudent.Visible = True
                btnEditStudent.Visible = True
                btnDeleteStudent.Visible = True
                LinkLabel1.Visible = True
                LinkLabel2.Visible = True
                ToggleStudentFields(False) ' Disable fields initially

            Case 2, 3
                pnlPersonDetails.Visible = True
                Me.Text = If(DisplayTracker = 2, "Add Teacher", "Add Parent/Guardian")

                ' For Parent/Guardian, show DOB controls; for Teacher, hide them.
                lblDOBpd.Visible = (DisplayTracker = 3)
                dtpDOBpd.Visible = (DisplayTracker = 3)
                lblRelatioshippd.Visible = (DisplayTracker = 3)
                txtRelationshippd.Visible = (DisplayTracker = 3)

                ' Update form labels accordingly.
                lblpdname.Text = If(DisplayTracker = 3, "Add Parent/Guardian Form", "Add Teacher Form")
                lblGB.Text = If(DisplayTracker = 3, "Parent/Guardian Form", "Teacher Form")
                ' Bind the Sex combo box for teacher/parent forms.
                cmbSexpd.DataSource = New List(Of String) From {"Male", "Female"}

                txtSearchPerson.Visible = False
                btnSearchPerson.Visible = False
                lblsearch.Visible = False
                btnEditpd.Visible = False
                btnDeletepd.Visible = False
            Case 21, 31
                pnlPersonDetails.Visible = True
                lblpdname.Text = If(DisplayTracker = 31, "Search Parent/Guardian Form", "Search Teacher Form")
                txtSearchPerson.Visible = True
                btnSearchPerson.Visible = True
                lblsearch.Visible = True
                btnEditpd.Visible = True
                btnDeletepd.Visible = True
                lblDOBpd.Visible = (DisplayTracker = 31)
                dtpDOBpd.Visible = (DisplayTracker = 31)
                lblRelatioshippd.Visible = (DisplayTracker = 31)
                txtRelationshippd.Visible = (DisplayTracker = 31)

        End Select

    End Sub
    Private Sub btnSearchPerson_Click(sender As Object, e As EventArgs) Handles btnSearchPerson.Click
        If txtSearchPerson.Text.Trim = "" Then
            MessageBox.Show("Please enter a name to search.")
            Exit Sub
        End If

        RetrievePerson()
        Debug.WriteLine("id: " & selectedStudentID)
    End Sub

    Private Sub btnEditpd_Click(sender As Object, e As EventArgs) Handles btnEditpd.Click

        ToggleFields(True)
    End Sub

    Private Sub RetrievePerson()
        Dim tableName As String = If(DisplayTracker = 21, "Teacher", "Parent_Guardian")
        Dim searchQuery As String = "SELECT * FROM " & tableName & " WHERE Fname LIKE '%" & txtSearchPerson.Text.Trim() & "%' " &
                                "OR Lname LIKE '%" & txtSearchPerson.Text.Trim() & "%'"

        ' Execute the query
        readquery(searchQuery)

        ' Load results into a DataTable
        Dim dt As New DataTable()
        dt.Load(cmdread)

        If cmdread IsNot Nothing Then cmdread.Close()

        If dt.Rows.Count > 0 Then
            ' Store the retrieved ID in the variable
            selectedPersonID = dt.Rows(0)(If(DisplayTracker = 21, "Teacher_ID", "Parent_Guardian_ID")).ToString()

            ' Populate fields with retrieved data
            txtFnamepd.Text = dt.Rows(0)("Fname").ToString()
            txtMnamepd.Text = dt.Rows(0)("Midname").ToString()
            txtLnamepd.Text = dt.Rows(0)("Lname").ToString()
            txtAddresspd.Text = dt.Rows(0)("Address").ToString()
            txtContactInfopd.Text = dt.Rows(0)("Contact_Info").ToString()

            ' First set the data source
            cmbSexpd.DataSource = New List(Of String) From {"Male", "Female"}

            ' Map database sex value to ComboBox selection
            Dim sexValue As String = dt.Rows(0)("Sex").ToString().Trim()
            If sexValue = "F" Then
                cmbSexpd.SelectedIndex = 1  ' Female
            Else
                cmbSexpd.SelectedIndex = 0  ' Male
            End If

            ' If searching for a Parent/Guardian, populate additional fields
            If DisplayTracker = 31 Then
                dtpDOBpd.Value = DateTime.Parse(dt.Rows(0)("DOB").ToString())
                txtRelationshippd.Text = dt.Rows(0)("Relationship").ToString()
            End If

            ' Disable fields initially
            ToggleFields(False)
        Else
            MessageBox.Show("No records found!")
        End If
    End Sub



    Private Sub ToggleFields(isEditable As Boolean)
        txtFnamepd.ReadOnly = Not isEditable
        txtMnamepd.ReadOnly = Not isEditable
        txtLnamepd.ReadOnly = Not isEditable
        txtAddresspd.ReadOnly = Not isEditable
        txtContactInfopd.ReadOnly = Not isEditable
        txtRelationshippd.ReadOnly = Not isEditable
        dtpDOBpd.Enabled = isEditable
        cmbSexpd.Enabled = isEditable
        btnSavepd.Enabled = isEditable ' Enable save button only when editing
    End Sub


    '--------------------------
    ' Initialize Form Controls
    '--------------------------
    Private Sub InitializeFormControls()
        ' Only bind the Grade Level initially
        BindGradeLevelCombo(cmbGradeLevel)

        ' Configure Section ComboBox for searching
        cmbSection.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbSection.AutoCompleteSource = AutoCompleteSource.ListItems

        ' Clear other controls
        cmbSection.DataSource = Nothing
        cmbSection.Items.Clear()
        cmbClassRoomAss.DataSource = Nothing
        cmbClassRoomAss.Items.Clear()
        clbSubjects.Items.Clear()

        ' Always bind the Sex combo box and Parent/Guardian combo box
        cmbSex.DataSource = New List(Of String) From {"Male", "Female"}
        BindComboBox(cmbParentGuardian, "SELECT Parent_Guardian_ID, CONCAT(Fname, ' ', Lname) AS ParentName FROM parent_guardian")
    End Sub

    '--------------------------
    ' Grade Level Selection Changed
    '--------------------------
    Private Sub cmbGradeLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGradeLevel.SelectedIndexChanged
        ' Only load sections if a grade level is selected
        If cmbGradeLevel.SelectedValue IsNot Nothing Then
            LoadSectionsForGradeLevel(cmbGradeLevel.SelectedValue.ToString())

            ' Clear classroom and subjects until a section is selected
            cmbClassRoomAss.DataSource = Nothing
            cmbClassRoomAss.Items.Clear()
            clbSubjects.Items.Clear()
        End If
    End Sub

    '--------------------------
    ' Section Selection Changed
    '--------------------------
    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        ' Only load classroom if a section is selected
        If cmbSection.SelectedValue IsNot Nothing Then
            LoadClassroomAss()
            LoadSubjects()  ' Now load subjects when a section is selected
        End If
    End Sub

    '--------------------------
    ' Load Sections for Selected Grade Level
    '--------------------------
    Private Sub LoadSectionsForGradeLevel(gradeLevel As String)
        Try
            ' Reset the section combo box
            cmbSection.DataSource = Nothing
            cmbSection.Items.Clear()

            ' Query only sections for this grade level
            Dim query As String = "SELECT Section_ID, Section_Name FROM Section " &
                                "WHERE Grade_Level_ID = " & gradeLevel & " " &
                                "ORDER BY Section_Name"

            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbSection.DataSource = dt
                cmbSection.DisplayMember = "Section_Name"
                cmbSection.ValueMember = "Section_ID"
                Debug.WriteLine("Loaded " & dt.Rows.Count & " sections for grade level " & gradeLevel)
            Else
                Debug.WriteLine("No sections found for grade level " & gradeLevel)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading sections: " & ex.Message)
        End Try
    End Sub

    '--------------------------
    ' Binding for Student ComboBoxes
    '--------------------------
    Private Sub BindStudentComboBoxes()
        ' For Grade Level, call our custom binding method.
        BindGradeLevelCombo(cmbGradeLevel)

        ' Bind the Section combo box.
        BindComboBox(cmbSection, "SELECT Section_ID, Section_Name FROM Section")

        ' Load subjects for the CheckedListBox (don't use BindComboBox)
        LoadSubjects()  ' This will now populate clbSubjects instead

        ' Bind the Parent/Guardian combo box.
        BindComboBox(cmbParentGuardian, "SELECT Parent_Guardian_ID, CONCAT(Fname, ' ', Lname) AS ParentName FROM parent_guardian")

        ' Bind the Sex combo box with a fixed list.
        cmbSex.DataSource = New List(Of String) From {"Male", "Female"}
    End Sub

    '--------------------------
    ' Custom Binding for Grade Level ComboBox
    '--------------------------
    Private Sub BindGradeLevelCombo(cmb As ComboBox)
        Try
            Dim dt As New DataTable()
            ' Retrieve grade levels from your table.
            ' This query should return Grade_Level_ID values (e.g., 1, 2, 3, …)
            readquery("SELECT Grade_Level_ID, Grade_Name FROM Grade_Level ORDER BY Grade_Level_ID")
            dt.Load(cmdread)
            cmdread.Close()

            ' Adjust the display name based on Grade_Level_ID.
            ' ID 1 remains "Kindergarten" while any ID greater than 1 becomes "Grade " & (ID - 1)
            For Each row As DataRow In dt.Rows
                Dim id As Integer = Convert.ToInt32(row("Grade_Level_ID"))
                If id = 1 Then
                    row("Grade_Name") = "Kindergarten"
                Else
                    row("Grade_Name") = "Grade " & (id - 1).ToString()
                End If
            Next

            cmb.DataSource = dt
            cmb.ValueMember = "Grade_Level_ID"
            cmb.DisplayMember = "Grade_Name"
        Catch ex As Exception
            MessageBox.Show("Error binding " & cmb.Name & ": " & ex.Message)
        End Try
    End Sub


    '--------------------------
    ' Helper method to Bind a ComboBox from a SQL query.
    '--------------------------
    Private Sub BindComboBox(cmb As ComboBox, sqlQuery As String)
        Try
            cmb.DataSource = Nothing
            cmb.Items.Clear()
            readquery(sqlQuery)
            Dim dt As New DataTable
            dt.Load(cmdread)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ColumnName
            cmb.DisplayMember = dt.Columns(1).ColumnName
        Catch ex As Exception
            MessageBox.Show("Error binding " & cmb.Name & ": " & ex.Message)
        End Try
    End Sub

    '--------------------------
    ' Student Input Validation
    '--------------------------
    Private Function ValidateStudentInputs() As Boolean
        ' Check basic text and combo validations for student enrollment.
        If String.IsNullOrEmpty(txtFname.Text.Trim()) Then
            MessageBox.Show("First name is required.")
            txtFname.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLname.Text.Trim()) Then
            MessageBox.Show("Last name is required.")
            txtLname.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddress.Text.Trim()) Then
            MessageBox.Show("Address is required.")
            txtAddress.Focus()
            Return False
        End If
        If cmbSex.SelectedIndex < 0 Then
            MessageBox.Show("Please select a sex.")
            cmbSex.Focus()
            Return False
        End If
        If cmbGradeLevel.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a grade level.")
            cmbGradeLevel.Focus()
            Return False
        End If
        If cmbSection.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a section.")
            cmbSection.Focus()
            Return False
        End If
        If clbSubjects.CheckedItems.Count = 0 Then
            MessageBox.Show("Please select at least one subject.")
            clbSubjects.Focus()
            Return False
        End If
        If cmbParentGuardian.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a parent/guardian.")
            cmbParentGuardian.Focus()
            Return False
        End If
        If cmbClassRoomAss.SelectedValue Is Nothing Then
            MessageBox.Show("Classroom assignment is required.")
            cmbClassRoomAss.Focus()
            Return False
        End If
        Return True
    End Function

    '--------------------------
    ' Teacher/Parent Input Validation
    '--------------------------
    Private Sub BlockNonLetters_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFname.KeyPress, txtLname.KeyPress, txtMname.KeyPress, txtFnamepd.KeyPress, txtLnamepd.KeyPress, txtMnamepd.KeyPress
        ' Allow control characters (like backspace), letters, and spaces.
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True ' Discard the character
        End If
    End Sub

    Private Function ValidatePersonDetailsInputs() As Boolean
        ' Validate required fields for Teacher or Parent/Guardian.
        If String.IsNullOrEmpty(txtFnamepd.Text.Trim()) Then
            MessageBox.Show("First name is required.")
            txtFnamepd.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLnamepd.Text.Trim()) Then
            MessageBox.Show("Last name is required.")
            txtLnamepd.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddresspd.Text.Trim()) Then
            MessageBox.Show("Address is required.")
            txtAddresspd.Focus()
            Return False
        End If
        If cmbSexpd.SelectedIndex < 0 Then
            MessageBox.Show("Please select a sex.")
            cmbSexpd.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtContactInfopd.Text.Trim()) Then
            MessageBox.Show("Contact information is required.")
            txtContactInfopd.Focus()
            Return False
        End If
        ' For Parent/Guardian, ensure DOB is provided.
        If DisplayTracker = 3 Then
            If dtpDOBpd.Value = Nothing Then
                MessageBox.Show("Date of birth is required.")
                dtpDOBpd.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    '--------------------------
    ' Student Save Routine (Updated)
    '--------------------------
    Private Sub btnSaveStudent_Click(sender As Object, e As EventArgs) Handles btnSaveStudent.Click
        ' Add confirmation dialog
        Dim confirmationMessage As String = If(DisplayTracker = 11 AndAlso Not String.IsNullOrEmpty(selectedStudentID), "Are you sure you want to update this student's record?", "Are you sure you want to save this new student?")
        Dim confirmationResult = MessageBox.Show(confirmationMessage, "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmationResult = DialogResult.No Then
            Return ' User chose not to save
        End If

        ' If updating an existing student, handle separately
        If DisplayTracker = 11 AndAlso Not String.IsNullOrEmpty(selectedStudentID) Then
            UpdateStudent()
            Return
        End If

        ' Validate inputs before starting transaction
        If Not ValidateStudentInputs() Then Return

        If IsStudentDuplicate(txtFname.Text.Trim(), txtLname.Text.Trim(), dtpDOB.Value) Then
            MessageBox.Show("A student with the same first name, last name, and birthdate already exists.", "Duplicate Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        opencon(db_name)
        Dim transaction As MySqlTransaction = conn.BeginTransaction()

        Try
            ' Step 1: Insert new student record
            Dim sqlStudent As String = "INSERT INTO Student (Fname, Midname, Lname, Address, DOB, Sex, Grade_Level_ID) VALUES (@Fname, @Midname, @Lname, @Address, @DOB, @Sex, @GradeLevelID)"
            Dim studentID As Long
            Using cmdStudent As New MySqlCommand(sqlStudent, conn, transaction)
                cmdStudent.Parameters.AddWithValue("@Fname", txtFname.Text.Trim())
                cmdStudent.Parameters.AddWithValue("@Midname", txtMname.Text.Trim())
                cmdStudent.Parameters.AddWithValue("@Lname", txtLname.Text.Trim())
                cmdStudent.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                cmdStudent.Parameters.AddWithValue("@DOB", dtpDOB.Value.ToString("yyyy-MM-dd"))
                cmdStudent.Parameters.AddWithValue("@Sex", If(cmbSex.SelectedItem.ToString() = "Female", "F", "M"))
                cmdStudent.Parameters.AddWithValue("@GradeLevelID", cmbGradeLevel.SelectedValue.ToString())
                cmdStudent.ExecuteNonQuery()
                studentID = cmdStudent.LastInsertedId
                lastInsertedStudentID = studentID.ToString()
            End Using

            ' Step 2: Enroll student in section
            Dim currentSchoolYear As String = DateTime.Now.Year.ToString() & "-" & (DateTime.Now.Year + 1).ToString()
            Dim sqlBelongsTo As String = "INSERT INTO belongs_to (Section_ID, Student_ID, SchoolYear) VALUES (@SectionID, @StudentID, @SchoolYear)"
            Using cmdBelongsTo As New MySqlCommand(sqlBelongsTo, conn, transaction)
                cmdBelongsTo.Parameters.AddWithValue("@SectionID", cmbSection.SelectedValue.ToString())
                cmdBelongsTo.Parameters.AddWithValue("@StudentID", studentID)
                cmdBelongsTo.Parameters.AddWithValue("@SchoolYear", currentSchoolYear)
                cmdBelongsTo.ExecuteNonQuery()
            End Using

            ' Step 3: Assign subjects
            For i As Integer = 0 To clbSubjects.CheckedItems.Count - 1
                Dim checkedIndex As Integer = clbSubjects.CheckedIndices(i)
                Dim subjectDict As Dictionary(Of Integer, Integer) = DirectCast(clbSubjects.Tag, Dictionary(Of Integer, Integer))
                Dim subjectID As Integer = subjectDict(checkedIndex)
                Dim sqlTakenBy As String = "INSERT INTO taken_by (Subject_ID, Student_ID, Grades, Year) VALUES (@SubjectID, @StudentID, 0, @Year)"
                Using cmdTakenBy As New MySqlCommand(sqlTakenBy, conn, transaction)
                    cmdTakenBy.Parameters.AddWithValue("@SubjectID", subjectID)
                    cmdTakenBy.Parameters.AddWithValue("@StudentID", studentID)
                    cmdTakenBy.Parameters.AddWithValue("@Year", currentSchoolYear)
                    cmdTakenBy.ExecuteNonQuery()
                End Using
            Next

            ' Step 4: Upload files
            If selectedFileData IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedFileName) Then
                UploadStudentFile(studentID.ToString(), selectedFileName, selectedFileData, transaction)
            End If
            If selectedReportCardData IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedReportCardName) Then
                UploadReportCard(studentID.ToString(), selectedReportCardName, selectedReportCardData, transaction)
            End If

            ' Step 5: Update counts
            UpdateTotalStudents(transaction)

            ' If all successful, commit the transaction
            transaction.Commit()
            MessageBox.Show("Student successfully enrolled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearStudentFields()

        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("An error occurred during enrollment. The operation was rolled back. Error: " & ex.Message, "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    '--------------------------
    ' Teacher / Parent-Guardian Save Routine
    '--------------------------
    Private Sub txtContactInfopd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactInfopd.KeyPress
        ' Allow only digits and control characters (like backspace).
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Also, prevent entry if the length is already 11, unless it's a control character.
        Dim textBox = CType(sender, TextBox)
        If textBox.Text.Length >= 11 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSavepd_Click(sender As Object, e As EventArgs) Handles btnSavepd.Click
        ' Validate inputs for teacher/parent/guardian.
        If Not ValidatePersonDetailsInputs() Then
            MsgBox("Validation failed. Please check your inputs.")
            Exit Sub
        End If

        Dim sql = ""

        Try
            Debug.WriteLine("DisplayTracker: " & DisplayTracker.ToString)
            Select Case DisplayTracker
                Case 2 ' Save Teacher
                    ' Validate Contact Information
                    Dim contactInfo As String = txtContactInfopd.Text.Trim()
                    If contactInfo.Length <> 11 OrElse Not contactInfo.All(AddressOf Char.IsDigit) Then
                        MessageBox.Show("Contact Information must be exactly 11 digits and contain only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtContactInfopd.Focus()
                        Return
                    End If

                    ' Ensure we have a selected item for the Gender combo box.
                    If cmbSexpd.SelectedItem Is Nothing Then
                        MsgBox("Please select a gender for the teacher.")
                        Exit Sub
                    End If



                    sql = "INSERT INTO teacher (Fname, Midname, Lname, Address, Sex, Contact_Info) VALUES (" &
              "'" & txtFnamepd.Text.Trim & "', " &
              "'" & txtMnamepd.Text.Trim & "', " &
              "'" & txtLnamepd.Text.Trim & "', " &
              "'" & txtAddresspd.Text.Trim & "', " &
              "'" & cmbSexpd.SelectedItem.ToString & "', " &
              "'" & txtContactInfopd.Text.Trim & "')"

                Case 3 ' Save Parent/Guardian
                    ' Ensure we have a selected item for the Gender combo box.
                    If cmbSexpd.SelectedItem Is Nothing Then
                        MsgBox("Please select a gender for the parent/guardian.")
                        Exit Sub
                    End If

                    sql = "INSERT INTO parent_guardian (Fname, Midname, Lname, Address, Sex, DOB, Contact_Info, Relationship) VALUES (" &
              "'" & txtFnamepd.Text.Trim & "', " &
              "'" & txtMnamepd.Text.Trim & "', " &
              "'" & txtLnamepd.Text.Trim & "', " &
              "'" & txtAddresspd.Text.Trim & "', " &
              "'" & cmbSexpd.SelectedItem.ToString & "', " &
              "'" & dtpDOBpd.Value.ToString("yyyy-MM-dd") & "', " &
              "'" & txtContactInfopd.Text.Trim & "', " &
              "'" & txtRelationshippd.Text.Trim & "')"

                Case 21 ' Update Teacher
                    ' Convert UI sex value to database format 
                    Dim sexForDB = If(cmbSexpd.SelectedItem.ToString = "Female", "F", "M")

                    sql = "UPDATE teacher SET " &
                          "Fname = '" & txtFnamepd.Text.Trim & "', " &
                          "Midname = '" & txtMnamepd.Text.Trim & "', " &
                          "Lname = '" & txtLnamepd.Text.Trim & "', " &
                          "Address = '" & txtAddresspd.Text.Trim & "', " &
                          "Sex = '" & sexForDB & "', " &
                          "Contact_Info = '" & txtContactInfopd.Text.Trim & "' " &
                          "WHERE Teacher_ID = " & selectedPersonID

                    Debug.WriteLine("Sex value to update: " & cmbSexpd.SelectedItem)

                Case 31 ' Update Parent/Guardian
                    ' Convert UI sex value to database format 
                    Dim sexForDB = If(cmbSexpd.SelectedItem.ToString = "Female", "F", "M")

                    sql = "UPDATE parent_guardian SET " &
                          "Fname = '" & txtFnamepd.Text.Trim & "', " &
                          "Midname = '" & txtMnamepd.Text.Trim & "', " &
                          "Lname = '" & txtLnamepd.Text.Trim & "', " &
                          "Address = '" & txtAddresspd.Text.Trim & "', " &
                          "Sex = '" & sexForDB & "', " &
                          "DOB = '" & dtpDOBpd.Value.ToString("yyyy-MM-dd") & "', " &
                          "Contact_Info = '" & txtContactInfopd.Text.Trim & "', " &
                          "Relationship = '" & txtRelationshippd.Text.Trim & "' " &
                          "WHERE Parent_Guardian_ID = " & selectedPersonID

            End Select

            Debug.WriteLine("SQL Query: " & sql)
            ' Optionally, uncomment next line to show SQL:
            ' MsgBox("SQL Query: " & sql)

            If MsgBox("Confirm Save?", vbYesNo) = vbYes Then
                readquery(sql)
                ' Check if cmdread exists and then close it.
                If cmdread IsNot Nothing Then
                    cmdread.Close()
                    Debug.WriteLine("cmdread closed successfully.")
                Else
                    Debug.WriteLine("cmdread was Nothing after executing readquery.")
                End If

                MessageBox.Show("Record saved successfully!")
                ClearPersonFields()

                ' After saving, rebind the Parent/Guardian combo box in the student enrollment panel.
                BindComboBox(cmbParentGuardian, "SELECT Parent_Guardian_ID, CONCAT(Fname, ' ', Lname) AS ParentName FROM parent_guardian")
                ' Optionally, hide the parent's panel if desired.

            End If

        Catch ex As MySqlException
            ' Capture detailed MySqlException information.
            Debug.WriteLine("MySqlException encountered: " & ex.ToString)
            MessageBox.Show("Error saving record (MySQL): " & ex.Message)
        Catch ex As Exception
            Debug.WriteLine("Exception encountered: " & ex.ToString)
            MessageBox.Show("Error saving record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddNewParent_Click(sender As Object, e As EventArgs) Handles btnAddNewParent.Click
        ' Since the Parent/Guardian entry fields are inside pnlPersonDetails,
        ' simply make the panel visible so the parent details can be entered.
        pnlPersonDetails.Visible = True
        pnlPersonDetails.BringToFront()

        ' Optionally set DisplayTracker to 3 if that is used to determine the panel mode.
        DisplayTracker = 3

        ' You can also clear the parent's fields if needed:
        txtFnamepd.Text = ""
        txtMnamepd.Text = ""
        txtLnamepd.Text = ""
        txtAddresspd.Text = ""
        txtContactInfopd.Text = ""
        dtpDOBpd.Value = DateTime.Today
        txtSearchPerson.Visible = False
        btnSearchPerson.Visible = False
        lblsearch.Visible = False
        btnEditpd.Visible = False
        btnDeletepd.Visible = False

        ' And update any label if necessary.
        lblpdname.Text = "Add Parent/Guardian Form"
        lblGB.Text = "Parent/Guardian Form"
    End Sub

    '--------------------------
    ' Load Subjects 
    '--------------------------
    Private Sub LoadSubjects()
        Try
            ' Create a new DataTable.
            Dim dt As New DataTable()

            ' Build a query to load subjects.
            ' If a grade level is selected, filter subjects based on that grade level.
            Dim query As String = "SELECT Subject_ID, Subject_Name FROM Subject"
            If cmbGradeLevel.SelectedValue IsNot Nothing Then
                query = "SELECT Subject_ID, Subject_Name FROM Subject " &
                    "WHERE Grade_Level_ID = " & cmbGradeLevel.SelectedValue.ToString() & " " &
                    "ORDER BY Subject_Name"
            End If

            ' First, clear the CheckedListBox to prevent duplicate or leftover items.
            clbSubjects.Items.Clear()

            ' Fill the DataTable using a MySqlDataAdapter.
            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            ' Add items manually to the CheckedListBox.
            If dt.Rows.Count > 0 Then
                ' Create a dictionary to store the mapping of item index to Subject_ID.
                Dim subjectDict As New Dictionary(Of Integer, Integer)()

                For Each row As DataRow In dt.Rows
                    Dim subjectID As Integer = Convert.ToInt32(row("Subject_ID"))
                    Dim subjectName As String = row("Subject_Name").ToString()

                    ' Use the current count as the key.
                    subjectDict.Add(clbSubjects.Items.Count, subjectID)

                    ' Add the subject name to the CheckedListBox.
                    clbSubjects.Items.Add(subjectName)
                Next

                ' Store the dictionary in the Tag property for later retrieval.
                clbSubjects.Tag = subjectDict

                ' Uncheck all items initially
                For i As Integer = 0 To clbSubjects.Items.Count - 1
                    clbSubjects.SetItemChecked(i, False)
                Next

                Debug.WriteLine("clbSubjects populated with " & dt.Rows.Count.ToString() & " items.")
            Else
                Debug.WriteLine("No subjects found in database.")
            End If
        Catch ex As Exception
            Debug.WriteLine("Error populating clbSubjects: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub


    '--------------------------
    ' Load Classroom Assignment
    '--------------------------
    Private Sub LoadClassroomAss()
        Try
            ' Ensure the required controls are not Nothing.
            If cmbSection Is Nothing OrElse cmbSection.SelectedValue Is Nothing Then
                Debug.WriteLine("Section not properly selected. Cannot load classroom assignment.")
                cmbClassRoomAss.DataSource = Nothing
                cmbClassRoomAss.Items.Clear()
                Exit Sub
            End If

            ' Get the selected section ID.
            Dim selectedSectionID As String = cmbSection.SelectedValue.ToString()

            ' First, reset the ComboBox to prevent any binding issues
            cmbClassRoomAss.DataSource = Nothing
            cmbClassRoomAss.Items.Clear()

            ' Create a DataTable and run the query that retrieves the room number.
            Dim dt As New DataTable()
            Dim query As String = "SELECT Room_Number FROM Classroom " &
                     "WHERE Classroom_ID = (SELECT Classroom_ID FROM Section WHERE Section_ID = " & selectedSectionID & ")"
            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            ' If we have a record, use the DataTable as the DataSource.
            If dt.Rows.Count > 0 Then
                cmbClassRoomAss.DataSource = dt
                cmbClassRoomAss.DisplayMember = "Room_Number"
                cmbClassRoomAss.ValueMember = "Room_Number"
                Debug.WriteLine("Classroom found for section " & cmbSection.Text)
            Else
                cmbClassRoomAss.Items.Add("No Classroom Assigned")
                cmbClassRoomAss.SelectedIndex = 0
                Debug.WriteLine("No classroom found for section " & cmbSection.Text)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading classroom assignment: " & ex.Message)
        End Try
    End Sub

    Private Sub btnChooseFile_Click(sender As Object, e As EventArgs) Handles btnUploadBirthCertificate.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "PDF Files|*.pdf|Word Documents|*.docx|Image Files|*.jpg;*.jpeg;*.png"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim fileInfo As New FileInfo(ofd.FileName)
                ' 4MB size limit
                If fileInfo.Length > 2 * 1024 * 1024 Then
                    MessageBox.Show("The selected file is too large. Please select a file smaller than 4MB.", "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                selectedFileData = File.ReadAllBytes(ofd.FileName)
                selectedFileName = Path.GetFileName(ofd.FileName)
                lblBirthCertificateFileName.Text = selectedFileName
                MessageBox.Show("File selected: " & selectedFileName)
            Else
                MessageBox.Show("No file selected.")
            End If
        End Using
    End Sub

    Private Sub UploadStudentFile(ByVal studentID As String, ByVal fileName As String, ByVal fileData() As Byte, ByVal transaction As MySqlTransaction)
        Dim uploadDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim formattedDocumentType As String = "BirthCertificate_" & fileName

        Dim sql As String = "INSERT INTO Requirements (Student_ID, Document_Type, FileData, Submission_Date, Submission_Status, Parent_Guardian_ID) VALUES (@StudentID, @DocumentType, @FileData, @SubmissionDate, 'Submitted', @ParentID) ON DUPLICATE KEY UPDATE FileData = @FileData, Submission_Date = @SubmissionDate, Submission_Status = 'Updated', Document_Type = @DocumentType"

        Using cmd As New MySqlCommand(sql, conn, transaction)
            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@DocumentType", formattedDocumentType)
            cmd.Parameters.AddWithValue("@FileData", fileData)
            cmd.Parameters.AddWithValue("@SubmissionDate", uploadDate)
            cmd.Parameters.AddWithValue("@ParentID", cmbParentGuardian.SelectedValue.ToString())
            cmd.ExecuteNonQuery()
        End Using
    End Sub


    Private Sub LoadStudentFile(ByVal studentID As String)
        Debug.Print("Attempting to load student file for Student ID: " & studentID) ' Debugging step 1

        ' Query to retrieve the full filename and file data
        Dim sql As String = "SELECT FileData, Document_Type FROM Requirements WHERE Student_ID = @studentID AND Document_Type LIKE '%BirthCertificate%'"

        Try
            Debug.Print("Executing SQL Query: " & sql) ' Debugging step 2
            opencon(db_name)

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@studentID", studentID)

            Debug.Print("Query parameters set: Student ID = " & studentID) ' Debugging step 3

            Dim dr As MySqlDataReader = cmd.ExecuteReader()
            Debug.Print("Query executed successfully.") ' Debugging step 4

            If dr.Read() Then
                Debug.Print("Data found for Student ID: " & studentID) ' Debugging step 5

                Dim fileData() As Byte = TryCast(dr("FileData"), Byte())
                Dim fileName As String = dr("Document_Type").ToString() ' Use actual filename from DB
                Debug.Print("Retrieved File Name: " & fileName) ' Debugging step 6
                Debug.Print("File Size: " & If(fileData IsNot Nothing, fileData.Length.ToString(), "No data")) ' Debugging step 7

                ' Ensure file data exists before binding
                If fileData IsNot Nothing AndAlso fileData.Length > 0 Then
                    Debug.Print("Binding file to LinkLabel1") ' Debugging step 8
                    BindUploadedFileToLinkLabel(LinkLabel1, fileName, fileData)
                Else
                    MsgBox("No file data found for this student.")
                    LinkLabel1.Visible = False
                    Debug.Print("File data is missing.") ' Debugging step 9
                End If
            Else
                MsgBox("No file record found for this student.")
                LinkLabel1.Visible = False
                Debug.Print("No records found for Student ID: " & studentID) ' Debugging step 10
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error loading student file: " & ex.Message)
            Debug.Print("Error encountered: " & ex.Message) ' Debugging step 11
        Finally
            conn.Close()
            Debug.Print("Database connection closed.") ' Debugging step 12
        End Try
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Query: Retrieve the actual filename and file data for the correct student
        Dim sql As String = "SELECT FileData, Document_Type FROM Requirements WHERE Student_ID = @studentID AND Document_Type LIKE '%BirthCertificate%'"

        Try
            opencon(db_name)
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@studentID", selectedStudentID)  ' Ensure this is set when a student is selected
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                Dim fileData() As Byte = TryCast(dr("FileData"), Byte())
                Dim fileName As String = dr("Document_Type").ToString() ' Use actual filename from DB
                Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), fileName) ' Use real filename

                ' Validate file data before proceeding
                If fileData IsNot Nothing AndAlso fileData.Length > 0 Then
                    ' Write the file to a temporary path
                    File.WriteAllBytes(tempFilePath, fileData)

                    ' Use ProcessStartInfo to ensure correct execution
                    Dim psi As New ProcessStartInfo() With {
                    .FileName = tempFilePath,
                    .UseShellExecute = True
                }
                    Process.Start(psi)
                Else
                    MsgBox("No valid file data found.")
                End If
            Else
                MsgBox("File not found in the database.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error retrieving file: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Button for Uploading Report Card (if applicable) ---
    ' Event handler for selecting a Report Card file
    Private Sub btnUploadReportCard_Click(sender As Object, e As EventArgs) Handles btnUploadReportCard.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "PDF Files|*.pdf|Word Documents|*.docx|Image Files|*.jpg;*.jpeg;*.png"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim fileInfo As New FileInfo(ofd.FileName)
                ' 2MB size limit
                If fileInfo.Length > 2 * 1024 * 1024 Then
                    MessageBox.Show("The selected file is too large. Please select a file smaller than 2MB.", "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                selectedReportCardData = File.ReadAllBytes(ofd.FileName)
                selectedReportCardName = Path.GetFileName(ofd.FileName)
                lblReportCardFileName.Text = selectedReportCardName
                MessageBox.Show("File selected: " & selectedReportCardName)
            Else
                MessageBox.Show("No file selected.")
            End If
        End Using
    End Sub

    ' Upload or update the Report Card in the database
    Private Sub UpdateTotalStudents(ByVal transaction As MySqlTransaction)
        ' Update section total
        Dim sqlUpdateSection As String = "UPDATE Section SET Total_Students = (SELECT COUNT(*) FROM belongs_to WHERE Section_ID = @SectionID) WHERE Section_ID = @SectionID"
        Using cmdUpdateSection As New MySqlCommand(sqlUpdateSection, conn, transaction)
            cmdUpdateSection.Parameters.AddWithValue("@SectionID", cmbSection.SelectedValue.ToString())
            cmdUpdateSection.ExecuteNonQuery()
        End Using

        ' Update grade level total
        Dim sqlUpdateGradeLevel As String = "UPDATE Grade_Level SET Total_Students = (SELECT COUNT(*) FROM Student WHERE Grade_Level_ID = @GradeLevelID) WHERE Grade_Level_ID = @GradeLevelID"
        Using cmdUpdateGradeLevel As New MySqlCommand(sqlUpdateGradeLevel, conn, transaction)
            cmdUpdateGradeLevel.Parameters.AddWithValue("@GradeLevelID", cmbGradeLevel.SelectedValue.ToString())
            cmdUpdateGradeLevel.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub UploadReportCard(ByVal studentID As String, ByVal fileName As String, ByVal fileData() As Byte, ByVal transaction As MySqlTransaction)
        Dim uploadDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim formattedDocumentType As String = "ReportCard_" & fileName

        Dim sql As String = "INSERT INTO Requirements (Student_ID, Document_Type, FileData, Submission_Date, Submission_Status, Parent_Guardian_ID) VALUES (@StudentID, @DocumentType, @FileData, @SubmissionDate, 'Submitted', @ParentID) ON DUPLICATE KEY UPDATE FileData = @FileData, Submission_Date = @SubmissionDate, Submission_Status = 'Updated', Document_Type = @DocumentType"

        Using cmd As New MySqlCommand(sql, conn, transaction)
            cmd.Parameters.AddWithValue("@StudentID", studentID)
            cmd.Parameters.AddWithValue("@DocumentType", formattedDocumentType)
            cmd.Parameters.AddWithValue("@FileData", fileData)
            cmd.Parameters.AddWithValue("@SubmissionDate", uploadDate)
            cmd.Parameters.AddWithValue("@ParentID", cmbParentGuardian.SelectedValue.ToString())
            cmd.ExecuteNonQuery()
        End Using
    End Sub



    ' Optional: Add this method if you want to show all available classrooms
    Private Sub LoadAllAvailableClassrooms()
        Try
            Dim dt As New DataTable()
            Dim query As String = "SELECT Room_Number FROM Classroom WHERE Classroom_ID NOT IN " &
                    "(SELECT Classroom_ID FROM Section WHERE Classroom_ID IS NOT NULL)"
            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbClassRoomAss.DataSource = dt
                cmbClassRoomAss.DisplayMember = "Room_Number"
                cmbClassRoomAss.ValueMember = "Room_Number"
                Debug.WriteLine("Showing " & dt.Rows.Count & " available classrooms.")
            Else
                cmbClassRoomAss.Items.Add("No Available Classrooms")
                cmbClassRoomAss.SelectedIndex = 0
                Debug.WriteLine("No available classrooms found.")
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading available classrooms: " & ex.Message)
        End Try
    End Sub

    Private Sub SetupAcademicControls()
        ' Populate the controls with data first.
        LoadSubjects()  ' This now populates clbSubjects
        LoadClassroomAss()

        GroupBox1.Controls.Add(clbSubjects)  ' Notice the change from cmbSubjects to clbSubjects
        GroupBox1.Controls.Add(cmbClassRoomAss)
    End Sub

    ' Delete-------------------------
    Private Sub btnDeletepd_Click(sender As Object, e As EventArgs) Handles btnDeletepd.Click

        ' Ensure a valid ID exists before proceeding
        If String.IsNullOrEmpty(selectedPersonID) Then
            MsgBox("No person selected for deletion. Please search first.")
            Exit Sub
        End If

        ' Confirm deletion with the user
        If MsgBox("Are you sure you want to delete this record?", vbYesNo) = vbYes Then
            DeletePerson()
        End If
    End Sub

    Private Sub DeletePerson()
        Dim tableName As String = If(DisplayTracker = 21, "Teacher", "Parent_Guardian")
        Dim idColumn As String = If(DisplayTracker = 21, "Teacher_ID", "Parent_Guardian_ID")
        Dim deleteQuery As String = "DELETE FROM " & tableName & " WHERE " & idColumn & " = " & selectedPersonID
        Dim resetAutoIncrementQuery As String = "ALTER TABLE " & tableName & " AUTO_INCREMENT = 1"

        Try
            Debug.WriteLine("Attempting to delete record with ID: " & selectedPersonID)
            Debug.WriteLine("Delete Query: " & deleteQuery)

            ' Execute delete query
            readquery(deleteQuery)

            ' Check if cmdread exists and close it
            If cmdread IsNot Nothing Then
                cmdread.Close()
                Debug.WriteLine("cmdread closed successfully after deletion.")
            Else
                Debug.WriteLine("cmdread was Nothing after executing deleteQuery.")
            End If

            ' Check if the deletion was successful
            Debug.WriteLine("Checking if record still exists...")
            readquery("SELECT COUNT(*) FROM " & tableName & " WHERE " & idColumn & " = " & selectedPersonID)
            Dim dt As New DataTable()
            dt.Load(cmdread)

            If dt.Rows.Count > 0 AndAlso dt.Rows(0)(0).ToString() <> "0" Then
                Debug.WriteLine("Error: Record still exists after deletion.")
                MessageBox.Show("Deletion failed! This record is connected to another table and cannot be deleted.")
                Exit Sub
            End If

            ' Proceed with resetting the auto-increment
            Debug.WriteLine("Record deleted successfully. Resetting AUTO_INCREMENT.")
            readquery(resetAutoIncrementQuery)

            MessageBox.Show("Record deleted successfully.")

            ' Clear fields after deletion
            ClearPersonFields()
        Catch ex As MySqlException
            If ex.Number = 1451 Then ' Foreign key constraint error
                Debug.WriteLine("Foreign Key Error: Record is being used elsewhere.")
                MessageBox.Show("This person is connected to other records and cannot be deleted.")
            Else
                Debug.WriteLine("MySqlException encountered: " & ex.ToString())
                MessageBox.Show("Error deleting record (MySQL): " & ex.Message)
            End If
        Catch ex As Exception
            Debug.WriteLine("Exception encountered: " & ex.ToString())
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub


    Private Sub ClearPersonFields()
        selectedPersonID = ""
        txtFnamepd.Clear()
        txtMnamepd.Clear()
        txtLnamepd.Clear()
        txtAddresspd.Clear()
        txtContactInfopd.Clear()
        txtRelationshippd.Clear()
        cmbSexpd.SelectedIndex = -1
        dtpDOBpd.Value = DateTime.Now
    End Sub

    ' Student search functionality
    Private Sub btnSearchStudent_Click(sender As Object, e As EventArgs) Handles btnSearchStudent.Click
        If txtSearchStudent.Text.Trim() = "" Then
            MessageBox.Show("Please enter a name to search.")
            Exit Sub
        End If

        RetrieveStudent()
    End Sub

    Private Sub btnEditStudent_Click(sender As Object, e As EventArgs) Handles btnEditStudent.Click
        ToggleStudentFields(True)
    End Sub

    Private Sub btnDeleteStudent_Click(sender As Object, e As EventArgs) Handles btnDeleteStudent.Click
        ' Ensure a valid ID exists before proceeding
        If String.IsNullOrEmpty(selectedStudentID) Then
            MsgBox("No student selected for deletion. Please search first.")
            Exit Sub
        End If

        ' Confirm deletion with the user
        If MsgBox("Are you sure you want to delete this student? This will also remove related records.", vbYesNo) = vbYes Then
            DeleteStudent()
        End If
    End Sub

    Private Sub RetrieveStudent()
        Dim searchQuery As String = "SELECT * FROM Student WHERE Fname LIKE '%" & txtSearchStudent.Text.Trim() & "%' " &
                                "OR Lname LIKE '%" & txtSearchStudent.Text.Trim() & "%'"

        ' Execute the query
        readquery(searchQuery)

        ' Load results into a DataTable
        Dim dt As New DataTable()
        dt.Load(cmdread)

        If cmdread IsNot Nothing Then cmdread.Close()

        If dt.Rows.Count > 0 Then
            ' Store the retrieved ID in the variable
            selectedStudentID = dt.Rows(0)("Student_ID").ToString()

            ' Populate fields with retrieved data
            txtFname.Text = dt.Rows(0)("Fname").ToString()
            txtMname.Text = dt.Rows(0)("Midname").ToString()
            txtLname.Text = dt.Rows(0)("Lname").ToString()
            txtAddress.Text = dt.Rows(0)("Address").ToString()
            dtpDOB.Value = DateTime.Parse(dt.Rows(0)("DOB").ToString())

            ' Set the Sex ComboBox
            cmbSex.DataSource = New List(Of String) From {"Male", "Female"}
            ' Map database sex value to ComboBox selection
            Dim sexValue As String = dt.Rows(0)("Sex").ToString().Trim()
            If sexValue = "F" Then
                cmbSex.SelectedIndex = 1  ' Female
            Else
                cmbSex.SelectedIndex = 0  ' Male
            End If

            ' Get the Grade Level
            Dim gradeLevelID As String = dt.Rows(0)("Grade_Level_ID").ToString()
            BindGradeLevelCombo(cmbGradeLevel)
            cmbGradeLevel.SelectedValue = gradeLevelID

            ' Get section, parent/guardian, and other details
            LoadStudentRelatedData()

            ' Disable fields initially
            ToggleStudentFields(False)

            LoadStudentFile(selectedStudentID)
            LoadReportCard(selectedStudentID)
        Else
            MessageBox.Show("No records found!")
        End If
    End Sub

    Private Sub LoadStudentRelatedData()
        ' Get the student's section
        Dim sectionQuery As String = "SELECT s.Section_ID, s.Section_Name " &
                                   "FROM Section s " &
                                   "JOIN belongs_to bt ON s.Section_ID = bt.Section_ID " &
                                   "WHERE bt.Student_ID = " & selectedStudentID & " " &
                                   "ORDER BY bt.SchoolYear DESC LIMIT 1"
        readquery(sectionQuery)
        Dim dtSection As New DataTable()
        dtSection.Load(cmdread)
        If cmdread IsNot Nothing Then cmdread.Close()

        If dtSection.Rows.Count > 0 Then
            LoadSectionsForGradeLevel(cmbGradeLevel.SelectedValue.ToString())
            cmbSection.SelectedValue = dtSection.Rows(0)("Section_ID").ToString()
        End If

        ' Get the student's parent/guardian
        Dim parentQuery As String = "SELECT pg.Parent_Guardian_ID, CONCAT(pg.Fname, ' ', pg.Lname) AS ParentName " &
                                 "FROM parent_guardian pg " &
                                 "JOIN Belong_to bt ON pg.Parent_Guardian_ID = bt.Parent_Guardian_ID " &
                                 "WHERE bt.Student_ID = " & selectedStudentID
        readquery(parentQuery)
        Dim dtParent As New DataTable()
        dtParent.Load(cmdread)
        If cmdread IsNot Nothing Then cmdread.Close()

        BindComboBox(cmbParentGuardian, "SELECT Parent_Guardian_ID, CONCAT(Fname, ' ', Lname) AS ParentName FROM parent_guardian")

        If dtParent.Rows.Count > 0 Then
            cmbParentGuardian.SelectedValue = dtParent.Rows(0)("Parent_Guardian_ID").ToString()
        End If

        ' Load classroom assignment
        LoadClassroomAss()

        ' Load and check subjects taken by the student
        LoadSubjects()
        LoadStudentSubjects()
    End Sub

    Private Sub LoadStudentSubjects()
        ' Get the subjects taken by the student
        Dim subjectQuery As String = "SELECT s.Subject_ID, s.Subject_Name " &
                                   "FROM Subject s " &
                                   "JOIN taken_by tb ON s.Subject_ID = tb.Subject_ID " &
                                   "WHERE tb.Student_ID = " & selectedStudentID
        readquery(subjectQuery)
        Dim dtSubjects As New DataTable()
        dtSubjects.Load(cmdread)
        If cmdread IsNot Nothing Then cmdread.Close()

        ' Get the subject dictionary from the Tag property
        If clbSubjects.Tag IsNot Nothing Then
            Dim subjectDict As Dictionary(Of Integer, Integer) = DirectCast(clbSubjects.Tag, Dictionary(Of Integer, Integer))

            ' Check the subjects taken by the student
            For Each row As DataRow In dtSubjects.Rows
                Dim subjectID As Integer = Convert.ToInt32(row("Subject_ID"))
                ' Find the index in the checkedlistbox where the subject ID matches
                For Each kvp As KeyValuePair(Of Integer, Integer) In subjectDict
                    If kvp.Value = subjectID Then
                        clbSubjects.SetItemChecked(kvp.Key, True)
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub ToggleStudentFields(isEditable As Boolean)
        txtFname.ReadOnly = Not isEditable
        txtMname.ReadOnly = Not isEditable
        txtLname.ReadOnly = Not isEditable
        txtAddress.ReadOnly = Not isEditable
        dtpDOB.Enabled = isEditable
        cmbSex.Enabled = isEditable
        cmbGradeLevel.Enabled = isEditable
        cmbSection.Enabled = isEditable
        cmbParentGuardian.Enabled = isEditable
        cmbClassRoomAss.Enabled = isEditable
        clbSubjects.Enabled = isEditable
        btnSaveStudent.Enabled = isEditable
        btnUploadBirthCertificate.Enabled = isEditable
        btnUploadReportCard.Enabled = isEditable
    End Sub

    Private Sub DeleteStudent()
        If String.IsNullOrEmpty(selectedStudentID) Then
            MessageBox.Show("No student selected for deletion.")
            Return
        End If

        opencon(db_name)
        Dim transaction As MySqlTransaction = conn.BeginTransaction()

        Try
            ' Delete related records first
            Dim queries As New List(Of String) From {
                "DELETE FROM taken_by WHERE Student_ID = @StudentID",
                "DELETE FROM belongs_to WHERE Student_ID = @StudentID",
                "DELETE FROM Belong_to WHERE Student_ID = @StudentID",
                "DELETE FROM Requirements WHERE Student_ID = @StudentID",
                "DELETE FROM Student WHERE Student_ID = @StudentID"
            }

            For Each query As String In queries
                Using cmd As New MySqlCommand(query, conn, transaction)
                    cmd.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            ' Update totals
            UpdateTotalStudents(transaction)

            transaction.Commit()
            MessageBox.Show("Student and all related records have been successfully deleted.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("An error occurred during deletion: " & ex.Message, "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        ' Refresh UI
        ClearStudentFields()
        RetrieveStudent() ' Or your method to refresh the student list
    End Sub

    Private Function IsStudentDuplicate(firstName As String, lastName As String, dob As DateTime) As Boolean
        Using connection As New MySqlConnection(GetConnectionString())
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM student WHERE Fname = @Fname AND Lname = @Lname AND DOB = @DOB"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Fname", firstName)
                command.Parameters.AddWithValue("@Lname", lastName)
                command.Parameters.AddWithValue("@DOB", dob.ToString("yyyy-MM-dd"))
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Sub ClearStudentFields()
        ' Clear all input fields for the student form
        txtFname.Clear()
        txtMname.Clear()
        txtLname.Clear()
        txtAddress.Clear()
        dtpDOB.Value = DateTime.Today
        cmbSex.SelectedIndex = -1
        cmbGradeLevel.SelectedIndex = -1
        cmbSection.DataSource = Nothing
        cmbClassRoomAss.DataSource = Nothing

        ' Uncheck all subjects
        For i As Integer = 0 To clbSubjects.Items.Count - 1
            clbSubjects.SetItemChecked(i, False)
        Next

        ' Reset file upload link labels
        LinkLabel1.Text = ""
        LinkLabel1.Tag = Nothing
        LinkLabel1.Visible = False
        LinkLabel2.Text = ""
        LinkLabel2.Tag = Nothing
        LinkLabel2.Visible = False
    End Sub

    Private Sub UpdateStudent()
        If Not ValidateStudentInputs() Then Exit Sub

        ' The duplicate check should be adjusted to exclude the current student ID
        ' If IsStudentDuplicate(txtFname.Text.Trim(), txtLname.Text.Trim(), dtpDOB.Value) Then
        '     MessageBox.Show("A student with the same first name, last name, and birthdate already exists.", "Duplicate Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '     Return
        ' End If
            ' End If

            opencon(db_name)
            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                ' Convert Sex value for database
                Dim sexForDB As String = If(cmbSex.SelectedItem.ToString() = "Female", "F", "M")

                ' 1. Update the Student record
                Dim sqlStudent As String = "UPDATE Student SET Fname = @Fname, Midname = @Midname, Lname = @Lname, Address = @Address, DOB = @DOB, Sex = @Sex, Grade_Level_ID = @GradeLevelID WHERE Student_ID = @StudentID"
                Using cmdStudent As New MySqlCommand(sqlStudent, conn, transaction)
                    cmdStudent.Parameters.AddWithValue("@Fname", txtFname.Text.Trim())
                    cmdStudent.Parameters.AddWithValue("@Midname", txtMname.Text.Trim())
                    cmdStudent.Parameters.AddWithValue("@Lname", txtLname.Text.Trim())
                    cmdStudent.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmdStudent.Parameters.AddWithValue("@DOB", dtpDOB.Value.ToString("yyyy-MM-dd"))
                    cmdStudent.Parameters.AddWithValue("@Sex", sexForDB)
                    cmdStudent.Parameters.AddWithValue("@GradeLevelID", cmbGradeLevel.SelectedValue.ToString())
                    cmdStudent.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdStudent.ExecuteNonQuery()
                End Using

                ' 2. Update section and parent assignments
                Dim currentSchoolYear As String = DateTime.Now.Year.ToString() & "-" & (DateTime.Now.Year + 1).ToString()
                Dim sqlBelongsTo As String = "INSERT INTO belongs_to (Student_ID, Section_ID, SchoolYear) VALUES (@StudentID, @SectionID, @SchoolYear) ON DUPLICATE KEY UPDATE Section_ID = @SectionID, SchoolYear = @SchoolYear"
                Using cmdBelongsTo As New MySqlCommand(sqlBelongsTo, conn, transaction)
                    cmdBelongsTo.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdBelongsTo.Parameters.AddWithValue("@SectionID", cmbSection.SelectedValue.ToString())
                    cmdBelongsTo.Parameters.AddWithValue("@SchoolYear", currentSchoolYear)
                    cmdBelongsTo.ExecuteNonQuery()
                End Using

                Dim sqlBelongToParent As String = "INSERT INTO Belong_to (Student_ID, Parent_Guardian_ID) VALUES (@StudentID, @ParentID) ON DUPLICATE KEY UPDATE Parent_Guardian_ID = @ParentID"
                Using cmdBelongToParent As New MySqlCommand(sqlBelongToParent, conn, transaction)
                    cmdBelongToParent.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdBelongToParent.Parameters.AddWithValue("@ParentID", cmbParentGuardian.SelectedValue.ToString())
                    cmdBelongToParent.ExecuteNonQuery()
                End Using

                ' 3. Update subject enrollments
                Dim deleteSubjects As String = "DELETE FROM taken_by WHERE Student_ID = @StudentID"
                Using cmdDelete As New MySqlCommand(deleteSubjects, conn, transaction)
                    cmdDelete.Parameters.AddWithValue("@StudentID", selectedStudentID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                For i As Integer = 0 To clbSubjects.CheckedItems.Count - 1
                    Dim subjectDict As Dictionary(Of Integer, Integer) = DirectCast(clbSubjects.Tag, Dictionary(Of Integer, Integer))
                    Dim subjectID As Integer = subjectDict(clbSubjects.CheckedIndices(i))
                    Dim sqlTakenBy As String = "INSERT INTO taken_by (Subject_ID, Student_ID, Grades, Year) VALUES (@SubjectID, @StudentID, 0, @Year)"
                    Using cmdTakenBy As New MySqlCommand(sqlTakenBy, conn, transaction)
                        cmdTakenBy.Parameters.AddWithValue("@SubjectID", subjectID)
                        cmdTakenBy.Parameters.AddWithValue("@StudentID", selectedStudentID)
                        cmdTakenBy.Parameters.AddWithValue("@Year", currentSchoolYear)
                        cmdTakenBy.ExecuteNonQuery()
                    End Using
                Next

                ' 4. Upload files
                If selectedFileData IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedFileName) Then
                    UploadStudentFile(selectedStudentID, selectedFileName, selectedFileData, transaction)
                End If
                If selectedReportCardData IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedReportCardName) Then
                    UploadReportCard(selectedStudentID, selectedReportCardName, selectedReportCardData, transaction)
                End If

                ' 5. Update totals
                UpdateTotalStudents(transaction)

                transaction.Commit()
                MessageBox.Show("Student information updated successfully!")

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("An error occurred while updating the student: " & ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try

            ' Refresh UI
            ClearStudentFields()
            RetrieveStudent()
        End Sub

    ''' <param name="linkLabel">The LinkLabel to bind the file to.</param>
    ''' <param name="fileName">The file name to display.</param>
    ''' <param name="fileData">The file data as a byte array.</param>
    Private Sub BindUploadedFileToLinkLabel(ByVal linkLabel As LinkLabel, ByVal fileName As String, ByVal fileData() As Byte)
        linkLabel.Text = fileName         ' Display the file name
        linkLabel.Tag = fileData          ' Store the file blob in Tag for later use
        linkLabel.Visible = True          ' Make sure the LinkLabel is visible
        uploadedFileName = fileName       ' Save the name for later reference (e.g., when reloading the panel)
    End Sub


    Private Sub LoadReportCard(ByVal studentID As String)
        ' Query to retrieve the Report Card file and filename
        Dim sql As String = "SELECT FileData, Document_Type FROM Requirements WHERE Student_ID = @studentID AND Document_Type LIKE '%ReportCard%' LIMIT 1"

        Try
            opencon(db_name)
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@studentID", studentID)
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                Dim fileData() As Byte = TryCast(dr("FileData"), Byte())
                Dim fileName As String = dr("Document_Type").ToString() ' Use actual filename from DB

                ' Ensure file data exists before binding
                If fileData IsNot Nothing AndAlso fileData.Length > 0 Then
                    BindUploadedFileToLinkLabel(LinkLabel2, fileName, fileData)
                Else
                    MsgBox("No Report Card data found for this student.")
                    LinkLabel2.Visible = False
                End If
            Else
                MsgBox("No Report Card record found for this student.")
                LinkLabel2.Visible = False
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error loading Report Card file: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Event handler for opening the Report Card when LinkLabel2 is clicked
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' Query to retrieve the actual filename and file data for the Report Card
        Dim sql As String = "SELECT FileData, Document_Type FROM Requirements WHERE Student_ID = @studentID AND Document_Type Like '%ReportCard%' LIMIT 1"

        Try
            opencon(db_name)
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@studentID", selectedStudentID)  ' Ensure this is set when a student is selected
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                Dim fileData() As Byte = TryCast(dr("FileData"), Byte())
                Dim fileName As String = dr("Document_Type").ToString() ' Use actual filename from DB
                Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), fileName) ' Use real filename

                ' Validate file data before proceeding
                If fileData IsNot Nothing AndAlso fileData.Length > 0 Then
                    ' Write the file to a temporary path
                    File.WriteAllBytes(tempFilePath, fileData)

                    ' Open the file using the system's default application
                    Dim psi As New ProcessStartInfo() With {
                    .FileName = tempFilePath,
                    .UseShellExecute = True
                }
                    Process.Start(psi)
                Else
                    MsgBox("No valid Report Card data found.")
                End If
            Else
                MsgBox("Report Card file not found in the database.")
            End If

            dr.Close()
        Catch ex As Exception
            MsgBox("Error retrieving Report Card: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        pnlStudent.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlPersonDetails.Hide()
    End Sub
End Class