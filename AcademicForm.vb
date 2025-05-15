Imports MySql.Data.MySqlClient

Public Class AcademicForm

    Private selectedAcademicEntityID As String = ""


    '------------------------------------------------
    ' Configure the form based on the selected entity type.
    '------------------------------------------------
    Private Sub ConfigureAcademicForm()
        ' Clear input fields for a fresh entry.
        txt1st.Text = ""
        txt2nd.Text = ""

        ' Hide extra labels by default.
        lblforcmb1.Visible = False
        lblforcmb2.Visible = False

        Select Case DisplayTracker
            Case 10   ' Classroom Management
                gbAcademicForms.Text = "Manage Classrooms"
                ' For classrooms, only Room Number and Building are needed.
                label1.Text = "Room Number:"
                label2.Text = "Building:"

                ' Hide extra labels and combo boxes that are not used.
                lblforcmb1.Visible = False
                lblforcmb2.Visible = False
                cmbGradeLevelID.Visible = False
                cmbClassroomID.Visible = False
                lblsearch.Visible = False
                btnDeleteAE.Visible = False
                btnEditAE.Visible = False
                txtSearchAcademicEntity.Visible = False
                btnSearchAcademicEntity.Visible = False
                lblSchedule.Visible = False
                cmbSchedule.Visible = False

                ' Bind the classroom combo box if needed.
                BindComboBox(cmbClassroomID, "SELECT Classroom_ID, Room_Number FROM Classroom")
                lblHint.Visible = False

            Case 11   ' Section Management
                gbAcademicForms.Text = "Manage Sections"
                ' For sections, these are required: Section Name, Total Students (max capacity),
                ' a Grade Level, and a Classroom.
                lblforcmb1.Visible = True
                lblforcmb2.Visible = True
                lblforcmb1.Text = "Grade Level:"
                lblforcmb2.Text = "Classroom:"
                label1.Text = "Section Name:"
                label2.Text = "Total Students:"   ' represents maximum capacity


                ' Bind the Classroom combo box.
                BindComboBox(cmbClassroomID, "SELECT Classroom_ID, Room_Number FROM Classroom")
                ' Bind the Grade Level combo using our custom binding to adjust display names.
                BindGradeLevelCombo(cmbGradeLevelID)


                lblsearch.Visible = False
                btnDeleteAE.Visible = False
                btnEditAE.Visible = False
                txtSearchAcademicEntity.Visible = False
                btnSearchAcademicEntity.Visible = False

                txt2nd.Enabled = False

                lblSchedule.Visible = False
                cmbSchedule.Visible = False
                lblHint.Visible = False
            Case 12   ' Subject Management
                gbAcademicForms.Text = "Manage Subjects"
                ' For subjects, only Subject Name and Description are needed.
                label1.Text = "Subject Name:"
                label2.Text = "Description:"
                ' Hide extra labels and combo boxes not used for subject management.
                lblforcmb1.Visible = True
                lblforcmb2.Visible = True


                lblforcmb1.Text = "Grade Level:"
                lblforcmb2.Text = "Teacher:"

                cmbClassroomID.Visible = True
                cmbClassroomID.Enabled = True
                cmbGradeLevelID.Visible = True
                cmbGradeLevelID.Enabled = True
                LoadTeachersComboBox()
                BindGradeLevelCombo(cmbGradeLevelID)


                lblsearch.Visible = False
                btnDeleteAE.Visible = False
                btnEditAE.Visible = False
                txtSearchAcademicEntity.Visible = False
                btnSearchAcademicEntity.Visible = False

                FillScheduleComboBox()
                lblHint.Visible = False
            Case 20
                gbAcademicForms.Text = "Manage Classrooms"

                ' For classrooms, only Room Number and Building are needed.
                label1.Text = "Room Number:"
                label2.Text = "Building:"

                ' Hide extra labels and combo boxes that are not used.
                lblforcmb1.Visible = False
                lblforcmb2.Visible = False
                cmbGradeLevelID.Visible = False
                cmbClassroomID.Visible = False
                lblHint.Visible = False
                lblSchedule.Visible = False
                cmbSchedule.Visible = False

                ToggleFields(False)

            Case 21
                gbAcademicForms.Text = "Manage Sections"
                ' For sections, these are required: Section Name, Total Students (max capacity),
                ' a Grade Level, and a Classroom.
                lblforcmb1.Visible = True
                lblforcmb2.Visible = True
                lblforcmb1.Text = "Grade Level:"
                lblforcmb2.Text = "Classroom:"
                label1.Text = "Section Name:"
                label2.Text = "Total Students:"   ' represents maximum capacity


                ' Bind the Classroom combo box.
                BindComboBox(cmbClassroomID, "SELECT Classroom_ID, Room_Number FROM Classroom")
                ' Bind the Grade Level combo using our custom binding to adjust display names.
                BindGradeLevelCombo(cmbGradeLevelID)
                lblHint.Visible = False
                lblSchedule.Visible = False
                cmbSchedule.Visible = False

                ToggleFields(False)

            Case 22
                gbAcademicForms.Text = "Manage Subjects"
                ' For subjects, only Subject Name and Description are needed.
                label1.Text = "Subject Name:"
                label2.Text = "Description:"
                ' Hide extra labels and combo boxes not used for subject management.
                lblforcmb1.Visible = True
                lblforcmb2.Visible = True


                lblforcmb1.Text = "Grade Level:"
                lblforcmb2.Text = "Teacher:"

                cmbClassroomID.Visible = True
                cmbClassroomID.Enabled = True
                cmbGradeLevelID.Visible = True
                cmbGradeLevelID.Enabled = True
                LoadTeachersComboBox()
                BindGradeLevelCombo(cmbGradeLevelID)
                FillScheduleComboBox()


                ToggleFields(False)
        End Select
    End Sub



    Private Sub btnSearchAcademicEntity_Click(sender As Object, e As EventArgs) Handles btnSearchAcademicEntity.Click
        ' Check if input is provided
        If String.IsNullOrEmpty(txtSearchAcademicEntity.Text.Trim()) Then
            MessageBox.Show("Please enter a search term before proceeding.")
            Exit Sub
        End If

        ' Proceed with the search
        RetrieveAcademicEntity(DisplayTracker)
    End Sub

    Private Sub LoadTeachersComboBox()
        Try
            Debug.WriteLine("----------------------------------------------")
            Debug.WriteLine("LOADING TEACHERS INTO COMBO BOX - " & DateTime.Now.ToString())

            ' Clear any existing items
            cmbClassroomID.DataSource = Nothing

            ' Get all teachers
            Dim query As String = "SELECT Teacher_ID, CONCAT(Fname, ' ', Lname) AS TeacherName FROM Teacher ORDER BY Lname, Fname"
            Debug.WriteLine("Teacher query: " & query)

            ' Use your existing binding method
            readquery(query)

            Dim dt As New DataTable

            Try
                dt.Load(cmdread)
                Debug.WriteLine("Teachers loaded: " & dt.Rows.Count)

                ' Debug first few teacher records
                For i As Integer = 0 To Math.Min(dt.Rows.Count - 1, 5)
                    Debug.WriteLine("Teacher " & (i + 1) & ": ID=" & dt.Rows(i)(0).ToString() & ", Name=" & dt.Rows(i)(1).ToString())
                Next

                ' Add an option for "No Teacher Assigned"
                Dim newRow As DataRow = dt.NewRow()
                newRow(0) = -1  ' Use -1 as ID for "No Teacher"
                newRow(1) = "-- No Teacher Assigned --"
                dt.Rows.InsertAt(newRow, 0)

                ' Re-bind with the updated DataTable
                cmbClassroomID.DataSource = dt
                cmbClassroomID.ValueMember = dt.Columns(0).ColumnName
                cmbClassroomID.DisplayMember = dt.Columns(1).ColumnName

                Debug.WriteLine("ValueMember set to: " & dt.Columns(0).ColumnName)
                Debug.WriteLine("DisplayMember set to: " & dt.Columns(1).ColumnName)

                ' Default to "No Teacher Assigned"
                cmbClassroomID.SelectedIndex = 0

                Debug.WriteLine("ComboBox SelectedValue after loading: " &
                                If(cmbClassroomID.SelectedValue IsNot Nothing,
                                   cmbClassroomID.SelectedValue.ToString(),
                                   "Nothing"))
                Debug.WriteLine("ComboBox Text after loading: " & cmbClassroomID.Text)

            Catch dtEx As Exception
                Debug.WriteLine("ERROR LOADING DATA TABLE: " & dtEx.Message)
            End Try

            Debug.WriteLine("----------------------------------------------")
        Catch ex As Exception
            Debug.WriteLine("ERROR IN LOADTEACHERSCOMBOBOX: " & ex.Message)
            Debug.WriteLine("Stack Trace: " & ex.StackTrace)
        End Try
    End Sub

    Private Sub FillScheduleComboBox()
        ' Clear existing items, if any
        cmbSchedule.Items.Clear()

        ' Add schedule entries to the combobox
        cmbSchedule.Items.Add("AM - 7:30 to 8:30")
        cmbSchedule.Items.Add("AM - 8:30 to 9:30")
        cmbSchedule.Items.Add("AM - 9:45 to 10:45")
        cmbSchedule.Items.Add("AM - 10:45 to 11:45")
        cmbSchedule.Items.Add("PM - 1:00 to 2:00")
        cmbSchedule.Items.Add("PM - 2:00 to 3:00")
        cmbSchedule.Items.Add("PM - 3:00 to 4:00")

        ' Make the combobox visible so that users can see the options
        cmbSchedule.Visible = True
    End Sub

    '===========================================================
    ' Helper Function to Convert User Grade Input to Internal ID
    '===========================================================
    Function ConvertUserGradeInputToInternal(ByVal gradeInput As String) As Integer
        Dim internalGradeLevel As Integer = -1
        Dim gradeNumeric As Integer
        Dim cleanedInput As String = gradeInput.Trim().ToLower()

        ' Check if input indicates Kindergarten
        If cleanedInput = "kindergarten" OrElse cleanedInput = "kinder" OrElse cleanedInput = "k" Then
            internalGradeLevel = 1
        ElseIf Integer.TryParse(cleanedInput, gradeNumeric) Then
            ' If user enters 0, treat it as Kindergarten as well.
            If gradeNumeric = 0 Then
                internalGradeLevel = 1
            Else
                ' For example, user input 1 (Grade 1) corresponds to internal ID 2,
                ' user input 2 (Grade 2) corresponds to internal ID 3, and so on.
                internalGradeLevel = gradeNumeric + 1
            End If
        Else
            MessageBox.Show("Please enter a valid grade level (0, kinder, kindergarten, or numeric value for grade).")
        End If

        Return internalGradeLevel
    End Function

    '===========================================================
    ' RetrieveAcademicEntity: Search and Populate Entity Data
    '===========================================================
    Private Sub RetrieveAcademicEntity(ByVal tracker As Integer)
        ToggleFields(False)

        ' Ensure the search input is not empty
        If String.IsNullOrEmpty(txtSearchAcademicEntity.Text.Trim()) Then
            MessageBox.Show("Please enter search criteria.")
            Exit Sub
        End If

        Dim tableName As String = ""
        Dim idColumn As String = ""
        Dim searchQuery As String = ""
        Dim userInput As String = txtSearchAcademicEntity.Text.Trim()

        Select Case tracker
            Case 20   ' Search Classroom
                tableName = "Classroom"
                idColumn = "Classroom_ID"
                searchQuery = "SELECT * FROM Classroom WHERE Room_Number LIKE '%" & userInput & "%' " &
                          "OR Building LIKE '%" & userInput & "%'"

            Case 21   ' Search Section
                tableName = "Section"
                idColumn = "Section_ID"
                searchQuery = "SELECT * FROM Section WHERE Section_Name LIKE '%" & userInput & "%' " &
                          "OR Total_Students LIKE '%" & userInput & "%'"

            Case 22   ' Search Subject (with special query support)
                tableName = "Subject"
                idColumn = "Subject_ID"

                If userInput.Contains("::") Then
                    Dim parts() As String = userInput.Split(New String() {"::"}, StringSplitOptions.None)
                    If parts.Length = 2 Then
                        Dim subjectName As String = parts(0).Trim()
                        Dim gradeInput As String = parts(1).Trim()
                        Dim internalGrade As Integer = ConvertUserGradeInputToInternal(gradeInput)

                        If internalGrade <> -1 Then
                            searchQuery = "SELECT s.*, ts.Teacher_ID, ts.Schedule FROM Subject s " &
                                      "LEFT JOIN taught_by ts ON s.Subject_ID = ts.Subject_ID " &
                                      "WHERE s.Subject_Name LIKE '%" & subjectName & "%' " &
                                      "AND s.Grade_Level_ID = " & internalGrade
                        Else
                            MessageBox.Show("Invalid grade level. Please try again.")
                            Exit Sub
                        End If
                    Else
                        ' Fall back to a standard search if the format isn't exactly two parts.
                        searchQuery = "SELECT s.*, ts.Teacher_ID, ts.Schedule FROM Subject s " &
                                  "LEFT JOIN taught_by ts ON s.Subject_ID = ts.Subject_ID " &
                                  "WHERE s.Subject_Name LIKE '%" & userInput & "%' " &
                                  "OR s.Subject_Description LIKE '%" & userInput & "%'"
                    End If
                Else
                    searchQuery = "SELECT s.*, ts.Teacher_ID, ts.Schedule FROM Subject s " &
                              "LEFT JOIN taught_by ts ON s.Subject_ID = ts.Subject_ID " &
                              "WHERE s.Subject_Name LIKE '%" & userInput & "%' " &
                              "OR s.Subject_Description LIKE '%" & userInput & "%'"
                End If
        End Select

        Debug.WriteLine("----------------------------------------------")
        Debug.WriteLine("EXECUTING SEARCH QUERY - " & DateTime.Now.ToString())
        Debug.WriteLine("Tracker Input: " & tracker.ToString())
        Debug.WriteLine("Search Query: " & searchQuery)

        Try
            readquery(searchQuery)

            ' Load results into a DataTable
            Dim dt As New DataTable()
            dt.Load(cmdread)

            If cmdread IsNot Nothing Then cmdread.Close()

            Debug.WriteLine("Search returned " & dt.Rows.Count & " results")

            If dt.Rows.Count > 0 Then
                selectedAcademicEntityID = dt.Rows(0)(idColumn).ToString()
                Debug.WriteLine("Selected " & tableName & " ID: " & selectedAcademicEntityID)

                ' Populate fields based on the tracker type
                Select Case tracker
                    Case 20
                        txt1st.Text = dt.Rows(0)("Room_Number").ToString()
                        txt2nd.Text = dt.Rows(0)("Building").ToString()

                    Case 21
                        txt1st.Text = dt.Rows(0)("Section_Name").ToString()
                        txt2nd.Text = dt.Rows(0)("Total_Students").ToString()
                        cmbGradeLevelID.SelectedValue = dt.Rows(0)("Grade_Level_ID").ToString()
                        cmbClassroomID.SelectedValue = dt.Rows(0)("Classroom_ID").ToString()

                    Case 22
                        txt1st.Text = dt.Rows(0)("Subject_Name").ToString()

                        If dt.Columns.Contains("Subject_Description") Then
                            txt2nd.Text = dt.Rows(0)("Subject_Description").ToString()
                        ElseIf dt.Columns.Contains("Description") Then
                            txt2nd.Text = dt.Rows(0)("Description").ToString()
                        End If

                        If dt.Columns.Contains("Grade_Level_ID") Then
                            cmbGradeLevelID.SelectedValue = dt.Rows(0)("Grade_Level_ID").ToString()
                        End If

                        If dt.Columns.Contains("Teacher_ID") Then
                            If Not IsDBNull(dt.Rows(0)("Teacher_ID")) Then
                                cmbClassroomID.SelectedValue = dt.Rows(0)("Teacher_ID").ToString()
                            Else
                                cmbClassroomID.SelectedValue = -1
                            End If
                        Else
                            cmbClassroomID.SelectedValue = -1
                        End If

                        If dt.Columns.Contains("Schedule") Then
                            cmbSchedule.Text = dt.Rows(0)("Schedule").ToString()
                            Debug.WriteLine("Set Schedule to: " & cmbSchedule.Text)
                        End If
                End Select

                ToggleFields(False)
            Else
                MessageBox.Show("No records found!")
            End If
        Catch ex As Exception
            Debug.WriteLine("GENERAL ERROR: " & ex.Message)
            Debug.WriteLine("Stack Trace: " & ex.StackTrace)
            MessageBox.Show("Error searching for record: " & ex.Message)
        End Try
    End Sub



    Private Sub btnEditAE_Click(sender As Object, e As EventArgs) Handles btnEditAE.Click
        If String.IsNullOrEmpty(selectedAcademicEntityID) Then
            MessageBox.Show("No entity selected for editing. Please search first.")
            Exit Sub
        End If

        ToggleFields(True)
        btnSave.Text = "Update"
    End Sub

    Private Sub btnDeleteAE_Click(sender As Object, e As EventArgs) Handles btnDeleteAE.Click
        If String.IsNullOrEmpty(selectedAcademicEntityID) Then
            MessageBox.Show("No entity selected for deletion. Please search first.")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this record?", vbYesNo) = vbYes Then
            DeleteAcademicEntity()
        End If
    End Sub

    Private Sub DeleteAcademicEntity()
        Dim tableName As String
        Dim idColumn As String

        Select Case DisplayTracker
            Case 10, 20  ' Classroom Management & Search
                tableName = "Classroom"
                idColumn = "Classroom_ID"
            Case 11, 21  ' Section Management & Search
                tableName = "Section"
                idColumn = "Section_ID"
            Case 12, 22  ' Subject Management & Search
                tableName = "Subject"
                idColumn = "Subject_ID"
            Case Else
                MessageBox.Show("Invalid entity type. Cannot delete.")
                Exit Sub
        End Select

        Dim deleteQuery As String = "DELETE FROM " & tableName & " WHERE " & idColumn & " = " & selectedAcademicEntityID
        Dim resetAutoIncrementQuery As String = "ALTER TABLE " & tableName & " AUTO_INCREMENT = 1"

        Try
            Debug.WriteLine("Attempting to delete record with ID: " & selectedAcademicEntityID)
            Debug.WriteLine("Delete Query: " & deleteQuery)

            readquery(deleteQuery)

            ' Check if cmdread exists and close it
            If cmdread IsNot Nothing Then
                cmdread.Close()
                Debug.WriteLine("cmdread closed successfully after deletion.")
            Else
                Debug.WriteLine("cmdread was Nothing after executing deleteQuery.")
            End If

            ' Verify deletion success
            readquery("SELECT COUNT(*) FROM " & tableName & " WHERE " & idColumn & " = " & selectedAcademicEntityID)
            Dim dt As New DataTable()
            dt.Load(cmdread)

            If cmdread IsNot Nothing Then cmdread.Close()

            If dt.Rows.Count > 0 AndAlso dt.Rows(0)(0).ToString() <> "0" Then
                Debug.WriteLine("Record still exists after deletion!")
                MessageBox.Show("Deletion failed! This entity is still linked or incorrectly referenced.")
                Exit Sub
            End If

            ' Reset auto-increment AFTER deletion
            Debug.WriteLine("Resetting AUTO_INCREMENT...")
            readquery(resetAutoIncrementQuery)
            If cmdread IsNot Nothing Then cmdread.Close()

            MessageBox.Show("Record deleted successfully!")
            ClearAcademicFields()
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("This entity is connected to other records and cannot be deleted.")
            Else
                MessageBox.Show("Error deleting record (MySQL): " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub


    Private Sub ClearAcademicFields()
        ' Reset selected entity ID
        selectedAcademicEntityID = ""

        ' Clear text fields
        txt1st.Clear()
        txt2nd.Clear()

        ' Reset combo boxes
        cmbGradeLevelID.SelectedIndex = -1
        cmbClassroomID.SelectedIndex = -1

        ' Ensure combo boxes visibility based on DisplayTracker
        cmbGradeLevelID.Visible = (DisplayTracker = 11 Or DisplayTracker = 12)
        cmbClassroomID.Visible = (DisplayTracker = 11)

        ' Reset form labels
        gbAcademicForms.Text = "Select an Option"

        ' Disable editing mode
        ToggleFields(False)
    End Sub

    Private Sub ToggleFields(isEditable As Boolean)
        ' Enable or disable text fields
        txt1st.ReadOnly = Not isEditable
        txt2nd.ReadOnly = Not isEditable

        ' Enable or disable combo boxes
        cmbGradeLevelID.Enabled = isEditable
        cmbClassroomID.Enabled = isEditable
        cmbSchedule.Enabled = isEditable

        ' Enable save button only when editing
        btnSave.Enabled = isEditable
    End Sub

    '------------------------------------------------
    ' Helper method to bind a ComboBox from a SQL query.
    ' This version correctly sets both ValueMember and DisplayMember.
    '------------------------------------------------
    Private Sub BindComboBox(cmb As ComboBox, sqlQuery As String)
        Try
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

    '------------------------------------------------
    ' Custom method to bind the Grade Level ComboBox with correct display text.
    ' Adjusts the Grade_Level names so that ID 1 becomes "Kindergarten" and IDs >1 become "Grade (ID-1)".
    '------------------------------------------------
    Private Sub BindGradeLevelCombo(cmb As ComboBox)
        Try
            cmb.Items.Clear()
            readquery("SELECT Grade_Level_ID, Grade_Name FROM Grade_Level ORDER BY Grade_Level_ID")
            Dim dt As New DataTable
            dt.Load(cmdread)

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
            MessageBox.Show("Error binding Grade Level: " & ex.Message)
        End Try
    End Sub

    '------------------------------------------------
    ' Input Validation Function.
    ' Validates inputs depending on the current DisplayTracker.
    '------------------------------------------------
    Private Function ValidateAcademicInputs() As Boolean
        Select Case DisplayTracker
            Case 10 ' Classroom Management
                If String.IsNullOrWhiteSpace(txt1st.Text) Then
                    MessageBox.Show("Room Number is required.")
                    txt1st.Focus()
                    Return False
                End If
                If String.IsNullOrWhiteSpace(txt2nd.Text) Then
                    MessageBox.Show("Building is required.")
                    txt2nd.Focus()
                    Return False
                End If

            Case 11 ' Section Management
                If String.IsNullOrWhiteSpace(txt1st.Text) Then
                    MessageBox.Show("Section Name is required.")
                    txt1st.Focus()
                    Return False
                End If
                If cmbGradeLevelID.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select a Grade Level.")
                    cmbGradeLevelID.Focus()
                    Return False
                End If
                If cmbClassroomID.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select a Classroom.")
                    cmbClassroomID.Focus()
                    Return False
                End If

            Case 12 ' Subject Management
                If String.IsNullOrWhiteSpace(txt1st.Text) Then
                    MessageBox.Show("Subject Name is required.")
                    txt1st.Focus()
                    Return False
                End If
                If String.IsNullOrWhiteSpace(txt2nd.Text) Then
                    MessageBox.Show("Description is required.")
                    txt2nd.Focus()
                    Return False
                End If
                If cmbGradeLevelID.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select a Grade Level.")
                    cmbGradeLevelID.Focus()
                    Return False
                End If
        End Select

        Return True
    End Function

    '------------------------------------------------
    ' Event: AcademicForm Load.
    '------------------------------------------------
    Private Sub AcademicForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureAcademicForm()
    End Sub

    '------------------------------------------------
    ' Save Button Click Event - Inserts record based on DisplayTracker setting.
    ' Includes input validation and error handling.
    '------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' First, validate the input fields.
        If Not ValidateAcademicInputs() Then Exit Sub

        ' Initialize variables for duplicate checking.
        Dim duplicateCheckSQL As String = ""
        Dim recordCount As Integer = 0
        Dim sql As String = ""

        ' Determine whether this is an insert or update operation
        Dim isUpdating As Boolean = (DisplayTracker = 20 Or DisplayTracker = 21 Or DisplayTracker = 22)

        ' === Duplicate Check (For Inserts Only) ===
        If Not isUpdating Then
            Select Case DisplayTracker
                Case 10   ' Classroom Management
                    duplicateCheckSQL = "SELECT COUNT(*) FROM Classroom WHERE Room_Number = '" & txt1st.Text.Trim() & "' AND Building = '" & txt2nd.Text.Trim() & "'"
                Case 11   ' Section Management
                    duplicateCheckSQL = "SELECT COUNT(*) FROM Section WHERE Section_Name = '" & txt1st.Text.Trim() & "' AND Grade_Level_ID = '" & cmbGradeLevelID.SelectedValue.ToString() & "'"
                Case 12   ' Subject Management
                    duplicateCheckSQL = "SELECT COUNT(*) FROM Subject WHERE Subject_Name = '" & txt1st.Text.Trim() & "' AND Grade_Level_ID = '" & cmbGradeLevelID.SelectedValue.ToString() & "'"
            End Select

            ' If a duplicate check query is defined, run it.
            If duplicateCheckSQL <> "" Then
                readquery(duplicateCheckSQL)
                If cmdread.Read() Then
                    recordCount = Convert.ToInt32(cmdread(0))
                End If

                ' If a duplicate record exists, notify the user and exit.
                If recordCount > 0 Then
                    Select Case DisplayTracker
                        Case 10
                            MessageBox.Show("A Classroom with this Room Number in the same Building already exists. Please enter a unique Classroom record.")
                        Case 11
                            MessageBox.Show("A Section with this name already exists for this Grade Level. Please choose a unique Section Name for this grade.")
                        Case 12
                            MessageBox.Show("A Subject with this name already exists. Please enter a unique Subject record.")
                    End Select
                    Exit Sub
                End If
            End If
        End If

        ' === Insert Queries ===
        If Not isUpdating Then
            Select Case DisplayTracker
                Case 10   ' Insert Classroom
                    sql = "INSERT INTO Classroom (Room_Number, Building) VALUES ('" & txt1st.Text.Trim() & "', '" & txt2nd.Text.Trim() & "')"
                Case 11   ' Insert Section
                    sql = "INSERT INTO Section (Section_Name, Total_Students, Grade_Level_ID, Classroom_ID) VALUES (" &
                          "'" & txt1st.Text.Trim() & "', '" & "0" & "', " &
                          "'" & cmbGradeLevelID.SelectedValue.ToString() & "', '" & cmbClassroomID.SelectedValue.ToString() & "')"
                Case 12   ' Insert Subject
                    Debug.WriteLine("Building Subject INSERT SQL")
                    sql = "INSERT INTO Subject (Subject_Name, Subject_Description, Grade_Level_ID) VALUES (" &
                          "'" & txt1st.Text.Trim() & "', '" & txt2nd.Text.Trim() & "', '" & cmbGradeLevelID.SelectedValue.ToString() & "');"

                    ' Handle the teacher association after subject is inserted
                    Debug.WriteLine("Teacher selection state:")
                    Debug.WriteLine("- cmbClassroomID.SelectedValue is Nothing: " & (cmbClassroomID.SelectedValue Is Nothing).ToString())

                    If cmbClassroomID.SelectedValue IsNot Nothing Then
                        Debug.WriteLine("- cmbClassroomID.SelectedValue: " & cmbClassroomID.SelectedValue.ToString())
                        Debug.WriteLine("- cmbClassroomID.Text: " & cmbClassroomID.Text)
                    End If

                    If cmbClassroomID.SelectedValue IsNot Nothing AndAlso cmbClassroomID.SelectedValue.ToString() <> "-1" Then
                        Debug.WriteLine("Valid teacher selected with ID: " & cmbClassroomID.SelectedValue.ToString())
                        sql += " SET @last_id = LAST_INSERT_ID(); " &
                               "INSERT INTO taught_by (Teacher_ID, Subject_ID, Schedule) VALUES (" &
                               cmbClassroomID.SelectedValue.ToString() & ", @last_id, '" & cmbSchedule.Text.Trim() & "');"
                    Else
                        Debug.WriteLine("No valid teacher selected - skipping INSERT into taught_by")
                    End If
            End Select
        End If

        ' === Update Queries ===
        If isUpdating Then
            ' Ensure a valid selected ID before updating
            If String.IsNullOrEmpty(selectedAcademicEntityID) Then
                MessageBox.Show("No record selected for updating. Please search first.")
                Exit Sub
            End If

            Select Case DisplayTracker
                Case 20   ' Update Classroom
                    sql = "UPDATE Classroom SET Room_Number = '" & txt1st.Text.Trim() & "', " &
                          "Building = '" & txt2nd.Text.Trim() & "' WHERE Classroom_ID = " & selectedAcademicEntityID
                Case 21   ' Update Section
                    sql = "UPDATE Section SET Section_Name = '" & txt1st.Text.Trim() & "', " &
                          "Total_Students = '" & txt2nd.Text.Trim() & "', " &
                          "Grade_Level_ID = '" & cmbGradeLevelID.SelectedValue.ToString() & "', " &
                          "Classroom_ID = '" & cmbClassroomID.SelectedValue.ToString() & "' " &
                          "WHERE Section_ID = " & selectedAcademicEntityID
                Case 22   ' Update Subject
                    Debug.WriteLine("Building Subject update SQL for Subject_ID: " & selectedAcademicEntityID)
                    sql = "UPDATE Subject SET Subject_Name = '" & txt1st.Text.Trim() & "', " &
                          "Subject_Description = '" & txt2nd.Text.Trim() & "', " &
                          "Grade_Level_ID = '" & cmbGradeLevelID.SelectedValue.ToString() & "' " &
                          "WHERE Subject_ID = " & selectedAcademicEntityID & "; "

                    ' Always delete existing teacher associations
                    Debug.WriteLine("Adding DELETE from taught_by for Subject_ID: " & selectedAcademicEntityID)
                    sql += "DELETE FROM taught_by WHERE Subject_ID = " & selectedAcademicEntityID & "; "

                    ' Update Teacher association only if a valid teacher is selected (not 'No Teacher')
                    Debug.WriteLine("Teacher selection state:")
                    Debug.WriteLine("- cmbClassroomID.SelectedValue is Nothing: " & (cmbClassroomID.SelectedValue Is Nothing).ToString())

                    If cmbClassroomID.SelectedValue IsNot Nothing Then
                        Debug.WriteLine("- cmbClassroomID.SelectedValue: " & cmbClassroomID.SelectedValue.ToString())
                        Debug.WriteLine("- cmbClassroomID.Text: " & cmbClassroomID.Text)
                    End If

                    If cmbClassroomID.SelectedValue IsNot Nothing AndAlso cmbClassroomID.SelectedValue.ToString() <> "-1" Then
                        Dim teacherID = cmbClassroomID.SelectedValue.ToString()
                        Debug.WriteLine("Valid teacher selected with ID: " & teacherID)
                        ' Add new association
                        sql += "INSERT INTO taught_by (Teacher_ID, Subject_ID) VALUES (" &
                              teacherID & ", " & selectedAcademicEntityID & ");"
                    Else
                        Debug.WriteLine("No valid teacher selected - skipping INSERT into taught_by")
                    End If
            End Select
        End If

        ' === Execute Query ===
        Try
            Dim action As String = If(isUpdating, "Update", "Save")
            If MsgBox("Confirm " & action & "?", vbYesNo) = vbYes Then
                Debug.WriteLine("----------------------------------------------")
                Debug.WriteLine("EXECUTING SQL QUERY - " & DateTime.Now.ToString())
                Debug.WriteLine("DisplayTracker: " & DisplayTracker.ToString())
                Debug.WriteLine("isUpdating: " & isUpdating.ToString())
                Debug.WriteLine("SQL Query: " & sql)

                ' For Subject-Teacher relationship debugging
                If DisplayTracker = 12 Or DisplayTracker = 22 Then
                    Debug.WriteLine("SUBJECT-TEACHER ASSOCIATION DETAILS:")
                    If cmbClassroomID.SelectedValue IsNot Nothing Then
                        Debug.WriteLine("Selected Teacher ID: " & cmbClassroomID.SelectedValue.ToString())
                        Debug.WriteLine("Selected Teacher Text: " & cmbClassroomID.Text)
                    Else
                        Debug.WriteLine("No teacher selected (SelectedValue is Nothing)")
                    End If

                    If Not String.IsNullOrEmpty(selectedAcademicEntityID) Then
                        Debug.WriteLine("Subject ID for update: " & selectedAcademicEntityID)
                    End If
                End If

                ' Special case for Subject Insert with Teacher association (Case 12)
                If DisplayTracker = 12 AndAlso sql.Contains("SET @last_id = LAST_INSERT_ID()") Then
                    ' Extract the subject insert statement from the SQL
                    Dim subjectInsertSQL As String = sql.Substring(0, sql.IndexOf(";"))
                    Debug.WriteLine("Executing subject insert only: " & subjectInsertSQL)

                    Try
                        ' Execute the subject insert
                        readquery(subjectInsertSQL)
                        Debug.WriteLine("Subject inserted successfully")

                        ' Get the last insert ID
                        Dim lastIdSql As String = "SELECT LAST_INSERT_ID()"
                        readquery(lastIdSql)

                        Dim newSubjectId As String = ""
                        If cmdread.Read() Then
                            newSubjectId = cmdread(0).ToString()
                            Debug.WriteLine("New Subject ID: " & newSubjectId)
                        End If

                        If cmdread IsNot Nothing Then cmdread.Close()

                        ' If we have a teacher selected, insert the association with schedule
                        If Not String.IsNullOrEmpty(newSubjectId) AndAlso
                           cmbClassroomID.SelectedValue IsNot Nothing AndAlso
                           cmbClassroomID.SelectedValue.ToString() <> "-1" Then

                            Dim teacherSql As String = "INSERT INTO taught_by (Teacher_ID, Subject_ID, Schedule) VALUES (" &
                                                       cmbClassroomID.SelectedValue.ToString() & ", " & newSubjectId & ", '" &
                                                       cmbSchedule.Text.Trim() & "')"

                            Debug.WriteLine("Executing teacher association insert: " & teacherSql)
                            readquery(teacherSql)
                            Debug.WriteLine("Teacher association inserted successfully")
                        End If

                        MessageBox.Show("Record " & action.ToLower() & "d successfully!")
                        selectedAcademicEntityID = ""  ' Reset selected ID after save
                    Catch ex As Exception
                        Debug.WriteLine("Error in subject insertion or teacher association: " & ex.Message)
                        MessageBox.Show("Error saving record: " & ex.Message)
                    End Try

                    ' Special case for Subject Update with Teacher association (Case 22)
                ElseIf DisplayTracker = 22 AndAlso sql.Contains("DELETE FROM taught_by") Then
                    ' Extract the subject update statement from the SQL
                    Dim subjectUpdateSQL As String = sql.Substring(0, sql.IndexOf("DELETE FROM taught_by") - 2)
                    Debug.WriteLine("Executing subject update only: " & subjectUpdateSQL)

                    Try
                        ' Execute the subject update
                        readquery(subjectUpdateSQL)
                        Debug.WriteLine("Subject updated successfully")

                        ' Delete any existing teacher associations
                        Dim deleteAssocSQL As String = "DELETE FROM taught_by WHERE Subject_ID = " & selectedAcademicEntityID
                        Debug.WriteLine("Executing delete associations: " & deleteAssocSQL)
                        readquery(deleteAssocSQL)
                        Debug.WriteLine("Existing teacher associations deleted")

                        ' If we have a teacher selected, insert the new association with schedule
                        If cmbClassroomID.SelectedValue IsNot Nothing AndAlso
                           cmbClassroomID.SelectedValue.ToString() <> "-1" Then

                            Dim teacherSql As String = "INSERT INTO taught_by (Teacher_ID, Subject_ID, Schedule) VALUES (" &
                                                       cmbClassroomID.SelectedValue.ToString() & ", " & selectedAcademicEntityID & ", '" &
                                                       cmbSchedule.Text.Trim() & "')"

                            Debug.WriteLine("Executing teacher association insert: " & teacherSql)
                            readquery(teacherSql)
                            Debug.WriteLine("Teacher association inserted successfully")
                        End If

                        MessageBox.Show("Record " & action.ToLower() & "d successfully!")
                        selectedAcademicEntityID = ""  ' Reset selected ID after update
                    Catch ex As Exception
                        Debug.WriteLine("Error in subject update or teacher association: " & ex.Message)
                        MessageBox.Show("Error updating record: " & ex.Message)
                    End Try

                Else
                    ' For all other cases, execute the SQL normally
                    Try
                        readquery(sql)
                        Debug.WriteLine("SQL QUERY EXECUTED SUCCESSFULLY")
                        MessageBox.Show("Record " & action.ToLower() & "d successfully!")
                        selectedAcademicEntityID = ""  ' Reset selected ID after update/save
                    Catch ex As MySqlException
                        Debug.WriteLine("SQL ERROR: " & ex.Message)
                        Debug.WriteLine("Error Number: " & ex.Number)
                        Debug.WriteLine("Error Source: " & ex.Source)
                        MessageBox.Show("Database Error: " & ex.Message)
                    End Try
                End If

                Debug.WriteLine("----------------------------------------------")
            End If
        Catch ex As Exception
            Debug.WriteLine("GENERAL ERROR: " & ex.Message)
            Debug.WriteLine("Stack Trace: " & ex.StackTrace)
            MessageBox.Show("Error saving record: " & ex.Message)
        End Try

    End Sub


End Class
