'Visual Basic Console Application
'Stack Push and Pop
'Variant 43 M/J 2015

Module Module1

    Structure node
        Dim name As String
        Dim pointer As Integer
    End Structure
    Dim stack(5) As node
    Dim temppointer As Integer
    Dim freepointer As Integer
    Dim topofstackpointer As Integer
    Dim newname As String
    Dim name As String

    Sub pushname(ByVal newname As String)

        If freepointer = 0 Then
            Console.WriteLine("Error")
        Else
            stack(freepointer).name = newname
            temppointer = freepointer
            freepointer = stack(temppointer).pointer
            stack(temppointer).pointer = topofstackpointer
            topofstackpointer = temppointer
        End If
    End Sub

    Sub popname()

        If freepointer = 0 Then
            Console.WriteLine("Error")
        Else
            Console.WriteLine(stack(topofstackpointer).name)
            temppointer = topofstackpointer
            topofstackpointer = stack(temppointer).pointer
            stack(temppointer).pointer = freepointer
            freepointer = temppointer
        End If
    End Sub

    Sub main()
        temppointer = 0
        topofstackpointer = 0
        freepointer = 1
        'Const maxsize = 5
        stack(5).pointer = 0
        For c = 1 To 4
            stack(c).pointer = c + 1
        Next
        pushname("Ali")
        pushname("jatinder")
        pushname("ahmed")
        popname()
        pushname("kamal")

        For c = 1 To 5
            Console.Write(" the name in stack pointer number " & c & "is :")
            Console.WriteLine(stack(c).name)
            Console.Write(" the pointer in stack number " & c & "is :")
            Console.WriteLine(stack(c).pointer)
        Next
    End Sub
End Module
