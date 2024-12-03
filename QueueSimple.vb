Module Module1

    Sub Main()
        Dim QueueArray(0 To 9) As String
        Dim HeadPointer As Integer
        Dim TailPointer As Integer
        Dim NumberItems As Integer
        Dim MyLine As String
        For x = 0 To 10
            Console.Write(" Enter a Value :")
            MyLine = Console.ReadLine()
            If (EnQueue(QueueArray, HeadPointer, TailPointer, NumberItems, MyLine)) Then
                Console.WriteLine("Successful")
            Else
                Console.WriteLine("Unsuccessful")
            End If
        Next
        Console.WriteLine(Dequeue(QueueArray, HeadPointer, TailPointer, NumberItems))
        Console.WriteLine(Dequeue(QueueArray, HeadPointer, TailPointer, NumberItems))
        Console.ReadKey()
    End Sub
    Function EnQueue(QueueArray As Array, ByRef HeadPointer As Integer, ByRef TailPointer As Integer, ByRef NumberItems As Integer, DataToAdd As String) As Boolean
        If NumberItems = 10 Then
            Return False
        End If
        QueueArray(TailPointer) = DataToAdd
        If TailPointer >= 9 Then
            TailPointer = 0
        Else
            TailPointer = TailPointer + 1
        End If
        NumberItems = NumberItems + 1
        Return True
    End Function
    Function Dequeue(ByRef QueueArray As Array, ByRef QueueHeadPointer As String, ByRef QueueTailPointer As Integer, ByRef NumberOfItems As Integer) As String
        Dim ReturnValue As String
        If NumberOfItems = 0 Then
            Return False
        Else
            ReturnValue = QueueArray(QueueHeadPointer)
            QueueHeadPointer = QueueHeadPointer + 1
            If QueueHeadPointer >= 9 Then
                QueueHeadPointer = 0
            End If
            NumberOfItems = NumberOfItems - 1
            Return ReturnValue
        End If
    End Function
End Module
