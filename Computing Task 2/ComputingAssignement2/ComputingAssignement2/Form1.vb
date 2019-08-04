Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Creating the courses when the program loads
        'First courses combobox when registering
        ComboBox1.Items.Add("Computing Technologies")
        ComboBox1.Items.Add("Business Management")
        ComboBox1.Items.Add("General Medical Practice")
        ComboBox1.Text = "Select course..."
        'Second combobox with courses when listing
        ComboBox2.Items.Add("Computing Technologies")
        ComboBox2.Items.Add("Business Management")
        ComboBox2.Items.Add("General Medical Practice")
        ComboBox2.Text = "Select course..."
    End Sub

    'Forcing telephone text box to accept only numbers
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        'The underscore operator tells VB that the statement continues on a new line
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
            AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    'Creating coruse arrays
    Dim course1Array As New List(Of Student)
    Dim course2Array As New List(Of Student)
    Dim course3Array As New List(Of Student)

    'Variable declaration
    Dim firstName As String
    Dim surName As String
    Dim telNumber As Integer

    'Function for registering a student to a course
    Private Sub RegisterStudent(fName As String, sName As String, tNumber As Integer)
        If ComboBox1.SelectedItem = "Computing Technologies" Then
            course1Array.Add(New Student(firstName, surName, telNumber))
            MessageBox.Show("Student added to course " + ComboBox1.SelectedItem)
        End If

        If ComboBox1.SelectedItem = "Business Management" Then
            course2Array.Add(New Student(firstName, surName, telNumber))
            MessageBox.Show("Student added to course " + ComboBox1.SelectedItem)
        End If

        If ComboBox1.SelectedItem = "General Medical Practice" Then
            course3Array.Add(New Student(firstName, surName, telNumber))
            MessageBox.Show("Student added to course " + ComboBox1.SelectedItem)
        End If
    End Sub

    'Function for searching a student in a course
    Private Sub SearchStudent(fName As String, sName As String, tNumber As Integer)
        Dim found As Boolean = False

        If ComboBox1.SelectedItem = "Computing Technologies" Then
            For Each student As Student In course1Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next

            If found = True Then
                MessageBox.Show("Student found enrolled in this course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If

        If ComboBox1.SelectedItem = "Business Management" Then
            For Each student As Student In course2Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next

            If found = True Then
                MessageBox.Show("Student found enrolled in this course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If

        If ComboBox1.SelectedItem = "General Medical Practice" Then
            For Each student As Student In course3Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next

            If found = True Then
                MessageBox.Show("Student found enrolled in this course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If
    End Sub

    'Function for deleting a student in a course
    Private Sub DeleteStudent(fname As String, sName As String, tNumber As Integer)
        Dim found As Boolean = False
        Dim index As Integer = 0

        If ComboBox1.SelectedItem = "Computing Technologies" Then
            For Each student As Student In course1Array
                If student.Name = fname And student.LastName = sName And student.Number = tNumber Then
                    found = True
                    index = course1Array.IndexOf(student)
                End If
            Next

            If found = True Then
                course1Array.Remove(course1Array(index))
                MessageBox.Show("Student removed from the course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If

        If ComboBox1.SelectedItem = "Business Management" Then
            For Each student As Student In course2Array
                If student.Name = fname And student.LastName = sName And student.Number = tNumber Then
                    found = True
                    index = course2Array.IndexOf(student)
                End If
            Next

            If found = True Then
                course2Array.Remove(course2Array(index))
                MessageBox.Show("Student removed from the course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If

        If ComboBox1.SelectedItem = "General Medical Practice" Then
            For Each student As Student In course3Array
                If student.Name = fname And student.LastName = sName And student.Number = tNumber Then
                    found = True
                    index = course3Array.IndexOf(student)
                End If
            Next

            If found = True Then
                course1Array.Remove(course3Array(index))
                MessageBox.Show("Student removed from the course")
            Else
                MessageBox.Show("Student not enrolled in this course")
            End If
        End If
    End Sub

    'Function for listing all students registered to a course
    Private Sub ListStudents()
        If ComboBox2.SelectedItem = "Computing Technologies" Then
            For Each student As Student In course1Array
                ListBox1.Items.Add(student.Name + " " + student.LastName)
            Next
        End If

        If ComboBox2.SelectedItem = "Business Management" Then
            For Each student As Student In course2Array
                ListBox1.Items.Add(student.Name + " " + student.LastName)
            Next
        End If

        If ComboBox2.SelectedItem = "General Medical Practice" Then
            For Each student As Student In course3Array
                ListBox1.Items.Add(student.Name + " " + student.LastName)
            Next
        End If
    End Sub

    'Function to avoid duplicate entries
    Function isEnrolled(fName As String, sName As String, tNumber As Integer) As Boolean
        isEnrolled = False
        Dim found As Boolean = False

        If ComboBox1.SelectedItem = "Computing Technologies" Then
            For Each student As Student In course1Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next
        End If

        If ComboBox1.SelectedItem = "Business Management" Then
            For Each student As Student In course2Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next
        End If

        If ComboBox1.SelectedItem = "General Medical Practice" Then
            For Each student As Student In course3Array
                If student.Name = fName And student.LastName = sName And student.Number = tNumber Then
                    found = True
                End If
            Next
        End If


        If found = True Then
            isEnrolled = True
        End If


    End Function

    'Pressing the Register button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        firstName = TextBox1.Text
        surName = TextBox2.Text
        telNumber = TextBox3.Text

        If isEnrolled(firstName, surName, telNumber) Then
            MessageBox.Show("Student already enrolled")
        Else
            RegisterStudent(firstName, surName, telNumber)
        End If
    End Sub

    'Pressing the Search button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        firstName = TextBox1.Text
        surName = TextBox2.Text
        telNumber = TextBox3.Text

        SearchStudent(firstName, surName, telNumber)
    End Sub

    'Pressing the Delete button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        firstName = TextBox1.Text
        surName = TextBox2.Text
        telNumber = TextBox3.Text

        DeleteStudent(firstName, surName, telNumber)
    End Sub

    'Pressing the List button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListBox1.Items.Clear()
        ListStudents()
    End Sub
End Class

'Creating student class
Public Class Student

    Private firstName As String
    Private surName As String
    Private telNumber As Integer

    'Constructor
    Public Sub New(fName As String, sName As String, tNumber As Integer)
        Me.firstName = fName
        Me.surName = sName
        Me.telNumber = tNumber
    End Sub
    'Getters and setters
    Public Property Name() As String
        Get
            Return firstName
        End Get
        Set(value As String)
            firstName = value
        End Set
    End Property
    Public Property LastName() As String
        Get
            Return surName
        End Get
        Set(value As String)
            surName = value
        End Set
    End Property
    Public Property Number() As Integer
        Get
            Return telNumber
        End Get
        Set(value As Integer)
            telNumber = value
        End Set
    End Property


End Class
