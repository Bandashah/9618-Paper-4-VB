Module Module1
    Dim stack(4) As String
    Dim stptr As Integer
    Sub Main()
        push("Ahmed Baloch")
        push("Abdur Rehman")
        push("Ahmed Raza")
        push("ImanUllah")
        showstack()
        pop()

        push("jatin")
        showstack()
        Console.ReadKey()
    End Sub
    Sub push(ByVal name As String)
        If stptr > 4 Then
            Console.WriteLine(" stack overflow ")
            Exit Sub
        End If
        stack(stptr) = name
        stptr = stptr + 1
    End Sub

    Sub pop()
        stptr = stptr - 1
        Console.WriteLine(" The poped element : " & stack(stptr))
    End Sub

    Sub showstack()
        For c = 0 To 4
            Console.WriteLine(" the stack ptr " & c & " is " & stack(c))
            Console.WriteLine()
            Console.ReadKey()
        Next
    End Sub
End Module
