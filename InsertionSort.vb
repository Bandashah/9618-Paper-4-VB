'Insertion Sort Visual Basic Code

Module Module1

    Sub Main()
        Dim height(5) As Integer
        Dim temp As Integer
        Dim maxsize As Integer
        Dim insert As Integer

        maxsize = 6

        For count = 0 To 5
            height(count) = Console.ReadLine()
        Next

        'sort the elements
        For count = 0 To maxsize - 1
            
            temp = height(count)
            insert = count
            While insert > 0 AndAlso height(insert - 1) >= temp
                height(insert) = height(insert - 1)
                insert = insert - 1
            End While
            height(insert) = temp
        Next

        'Print out the elements
        For count = 0 To maxsize - 1
            Console.WriteLine(count & ": " & height(count))
        Next
        Console.ReadKey()
    End Sub

End Module
