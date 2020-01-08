Module Module1

    'QUEUE Visual Basic
    'PP variant 41 may/june year 2015

    Structure node
        Dim name As String
        Dim pointer As Integer
    End Structure
    Dim queue(5) As node
    Dim headpointer As Integer
    Dim freepointer As Integer
    Dim tailpointer As Integer
    Dim currentpointer As Integer
    Dim newname As String
    Dim name As String

    Sub addname(ByVal newname As String)

        'Report error if Queue is empty
        If freepointer = 0 Then
            Console.WriteLine("Error")
        Else
            currentpointer = freepointer
            queue(currentpointer).name = newname
            freepointer = queue(currentpointer).pointer
            If headpointer = 0 Then
                headpointer = currentpointer
            End If
            queue(currentpointer).pointer = 0
            tailpointer = currentpointer
        End If
    End Sub

    Sub main()
        headpointer = 0
        tailpointer = 0
        freepointer = 1
        For c = 1 To 5
            queue(c).pointer = c + 1
        Next
        For c = 1 To 5
            Console.Write("Enter the name to pass in queue : ")
            name = Console.ReadLine()
            addname(name)
        Next


        For c = 1 To 5
            Console.Write(" the name in queue pointer number " & c & "is :")
            Console.WriteLine(queue(c))
        Next
    End Sub

End Module
