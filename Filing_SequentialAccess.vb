Module Module1
    Dim RollNo As Integer
    Dim sName As String

    Sub Main()
        Dim choice As Integer
        choice = 0
        While choice <> 7
            Console.Clear()
            Console.WriteLine("Enter 1 to APPEND record to the file")
            Console.WriteLine("Enter 2 to READ record from the file")
            Console.WriteLine("Enter 3 to ADD a record in sequence")
            Console.WriteLine("Enter 4 to DELETE a record from the file")
            Console.WriteLine("Enter 5 to EDIT a record in the file")
            Console.WriteLine("Enter 6 to SEARCH a record from the file")
            Console.WriteLine("Enter 7 to Exit")
            Console.Write("Your choice... ")
            choice = Console.ReadLine
            Select Case choice
                Case 1 : APPEND()
                Case 2 : READ()
                Case 3 : ADD()
                Case 4 : DELETE()
                Case 5 : EDIT()
                Case 6 : SEARCH()
                Case 7
                Case Else
                    Console.WriteLine("Wrong choice made... Press any key to continue.")
                    Console.ReadKey()
            End Select
        End While
    End Sub

    Private Sub APPEND()
        RollNo = 0
        sName = ""
        Console.Write("Enter Student Roll Number:")
        RollNo = Console.ReadLine()
        Console.Write("Enter Student Name:")
        sName = Console.ReadLine
        FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Append)
        WriteLine(1, RollNo, sName)
        FileClose(1)
        READ()
    End Sub

    Private Sub READ()
        RollNo = 0
        sName = ""
        Console.Clear()
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            Do While Not EOF(1)
                Input(1, RollNo)
                Input(1, sName)
                Console.WriteLine(RollNo & ", " & sName)
            Loop
            FileClose(1)
        Catch
            Console.WriteLine("File doesn't exisit, so operation is not possible...")
        Finally
            Console.Write("Press any key to continue...")
            Console.ReadKey()
        End Try
    End Sub

    Private Sub ADD()
        Dim rn As Integer
        Dim nm As String
        Dim flag As Boolean
        RollNo = 0
        sName = ""
        rn = 0
        nm = ""
        flag = False
        Console.Write("Enter Roll No:")
        rn = Console.ReadLine
        If recordChk(rn) = True Then
            Console.WriteLine("Already exists. Skipping operation.")
            Console.ReadKey()
            Exit Sub
        End If
        Console.Write("Enter Student Name:")
        nm = Console.ReadLine
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            FileOpen(2, My.Application.Info.DirectoryPath & "\tempFile.txt", OpenMode.Append)
            While Not EOF(1)
                Input(1, RollNo)
                Input(1, sName)
                If rn < RollNo And flag = False Then
                    WriteLine(2, rn, nm)
                    flag = True
                End If
                WriteLine(2, RollNo, sName)
            End While
            If flag = False Then
                WriteLine(2, rn, nm)
            End If
            FileClose(1)
            FileClose(2)
            Kill(My.Application.Info.DirectoryPath & "\stuFile.txt")
            My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\tempFile.txt", "stuFile.txt")
        Catch
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Output)
            WriteLine(1, rn, nm)
            FileClose(1)
        Finally
            READ()
        End Try
    End Sub

    Private Sub DELETE()
        Dim rn As Integer
        RollNo = 0
        sName = ""
        rn = 0
        Console.Write("Enter Roll No:")
        rn = Console.ReadLine()
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            FileOpen(2, My.Application.Info.DirectoryPath & "\tempFile.txt", OpenMode.Append)
            Do While Not EOF(1)
                Input(1, RollNo)
                Input(1, sName)
                If rn <> RollNo Then
                    WriteLine(2, RollNo, sName)
                End If
            Loop
            FileClose(1)
            FileClose(2)
            Kill(My.Application.Info.DirectoryPath & "\stuFile.txt")
            My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\tempFile.txt", "stuFile.txt")
            READ()
        Catch
            Console.WriteLine("File doesn't exist, so operation is not possible...")
            Console.ReadKey()
        End Try
    End Sub

    Private Sub EDIT()
        Dim rn As Integer
        Dim nm As String
        Dim flag As Boolean
        RollNo = 0
        sName = ""
        rn = 0
        nm = ""
        flag = False
        Console.Write("Enter Roll No:")
        rn = Console.ReadLine()
        Console.Write("Enter Student Name:")
        nm = Console.ReadLine()
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            FileOpen(2, My.Application.Info.DirectoryPath & "\tempFile.txt", OpenMode.Append)
            While Not EOF(1)
                Input(1, RollNo)
                Input(1, sName)
                If rn = RollNo Then
                    WriteLine(2, rn, nm)
                    flag = True
                Else
                    WriteLine(2, RollNo, sName)
                End If
            End While
            FileClose(1)
            FileClose(2)
            Kill(My.Application.Info.DirectoryPath & "\stuFile.txt")
            My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\tempFile.txt", "stuFile.txt")
            If flag = False Then
                Console.WriteLine("Record not found.")
                Console.ReadKey()
            End If
            READ()
        Catch
            Console.WriteLine("File doesn't exist, so operation is not possible...")
            Console.ReadKey()
        End Try
    End Sub

    Private Sub SEARCH()
        Dim rn As Integer
        Dim flag As Boolean
        RollNo = 0
        sName = ""
        rn = 0
        flag = False
        Console.Write("Enter Roll No:")
        rn = Console.ReadLine()
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            While Not EOF(1)
                Input(1, RollNo)
                Input(1, sName)
                If rn = RollNo Then
                    Console.WriteLine(RollNo & ", " & sName & " is found.")
                    flag = True
                End If
            End While
            FileClose(1)
        Catch
            Console.WriteLine("File doesn't exist, so operation is not possible...")
        Finally
            If flag = False Then
                Console.WriteLine("Record not found...")
            End If
            Console.ReadKey()
        End Try
    End Sub

    Function recordChk(ByVal rn1 As Integer) As Boolean
        Dim isFound As Boolean
        Dim RNo As Integer
        Dim sNme As String
        isFound = False
        RNo = 0
        sNme = ""
        Try
            FileOpen(1, My.Application.Info.DirectoryPath & "\stuFile.txt", OpenMode.Input)
            Do While Not EOF(1)
                Input(1, RNo)
                Input(1, sName)
                If rn1 = RNo Then
                    isFound = True
                End If
            Loop
            FileClose(1)
        Catch
        Finally
            recordChk = isFound
        End Try
    End Function
End Module
