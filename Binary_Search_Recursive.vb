Module Module1
    Dim Middle As Integer
    Dim NameList() = {"Anas", "Danish", "Qasim", "Talha", "Umair"}

    Dim Check As Integer
    Sub Main()



        Check = Find("Umair", 0, 4)
        If Check = -1 Then
            Console.WriteLine("Error Error Error Error")
        Else : Console.WriteLine(NameList(Check))
        End If
        Console.ReadKey()
    End Sub
    Function Find(ByVal Name As String, ByVal Start As Integer, ByVal Finish As Integer) As Integer

        If Finish < Start Then
            Return -1
        Else : Middle = (Start + Finish) / 2


            If NameList(Middle) = Name Then
                Return Middle
            ElseIf Name > NameList(Middle) Then
                Find(Name, Middle + 1, Finish)
            Else : Find(Name, Start, Middle - 1)

            End If
        End If
        Return Middle
    End Function
End Module
