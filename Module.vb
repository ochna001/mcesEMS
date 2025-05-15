Imports MySql.Data.MySqlClient
Module Module1
    Public DisplayTracker As Integer
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public cmdread As MySqlDataReader
    Public db_server As String = "localhost"
    Public db_uid As String = "root"
    Public db_pwd As String = ""
    Public db_name As String = "mcesdb_test"
    Public strconnection As String = "server = " & db_server & "; uid =" & db_uid & "; password =" & db_pwd & "; database =" & db_name & ""
    Public Sub opencon(ByVal db_name As String)
        Try
            With conn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strconnection
                .Open()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub readquery(ByVal sql As String)
        Try
            opencon(db_name)
            With cmd
                .Connection = conn
                .CommandText = sql
                cmdread = .ExecuteReader
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub InitializeGradeLevels()
        ' Pre-populate grade levels only if they don’t already exist
        Dim sqlCheck As String = "SELECT COUNT(*) FROM Grade_Level"
        readquery(sqlCheck)

        Dim totalRecords As Integer
        If cmdread.Read() Then
            totalRecords = cmdread.GetInt32(0)
        End If

        ' If no grade levels exist, populate them
        If totalRecords = 0 Then
            Dim sqlInsert As String =
            "INSERT INTO Grade_Level (Grade_Level_ID, Grade_Name, Total_Students) VALUES
            (1, 'Kindergarten', 0),
            (2, 'Grade 1', 0),
            (3, 'Grade 2', 0),
            (4, 'Grade 3', 0),
            (5, 'Grade 4', 0),
            (6, 'Grade 5', 0),
            (7, 'Grade 6', 0);"
            readquery(sqlInsert)
        End If
    End Sub

    ' Auto-update total students for each grade level
    Public Sub UpdateTotalStudents()
        Dim sqlUpdate As String =
        "UPDATE Grade_Level 
        SET Total_Students = (
            SELECT COUNT(*) FROM Student WHERE Grade_Level_ID = Grade_Level.Grade_Level_ID
        );"
        readquery(sqlUpdate)
    End Sub

    Public Function GetDefaultCurriculumSubject(ByVal gradeLevelID As String) As String
        Dim iGrade As Integer
        Dim subjectName As String = ""
        Dim defaultSubjectID As String = ""

        ' Try to convert the grade level ID to an integer.
        If Not Integer.TryParse(gradeLevelID, iGrade) Then
            iGrade = 0 ' Fallback value if parsing fails.
        End If

        ' Use a hardcoded mapping for DepEd elementary subjects.
        ' Example Mapping (adjust as required):
        '   1 -> "Mother Tongue" (Kindergarten)
        '   2 -> "Mathematics" (Grade 1)
        '   3 -> "Science" (Grade 2)
        '   4 -> "English" (Grade 3)
        '   5 -> "Araling Panlipunan" (Grade 4)
        '   6 -> "MAPEH" (Grade 5)
        ' Default for any other value is "Mathematics".
        Select Case iGrade
            Case 1
                subjectName = "Mother Tongue"
            Case 2
                subjectName = "Mathematics"
            Case 3
                subjectName = "Science"
            Case 4
                subjectName = "English"
            Case 5
                subjectName = "Araling Panlipunan"
            Case 6
                subjectName = "MAPEH"
            Case Else
                subjectName = "Mathematics"
        End Select

        ' Look up the Subject_ID from the Subject table.
        Dim sql As String = "SELECT Subject_ID FROM Subject WHERE Subject_Name = '" & subjectName & "' LIMIT 1"
        readquery(sql)
        If cmdread.Read() Then
            defaultSubjectID = cmdread(0).ToString()
        End If

        Return defaultSubjectID
    End Function


End Module
