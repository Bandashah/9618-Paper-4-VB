'Stack ADT Using Linked List

Module Module1
    ' NullPointer should be set to -1 IF using array element with index 0
    Const NULLPOINTER = -1
    ' Declare record type to store data and pointer
    Structure Node
        Dim Data As String
        Dim Pointer As Integer
    End Structure
    Dim Stack(0 To 6) As Node
    Dim TopOfStack As Integer
    Dim FreeListPtr As Integer
    Sub Main()

        Dim Choice As Char
        Dim Data As String
        InitialiseStack()
        Choice = GetOption()
        While Choice <> "4"
            Select Case Choice
                Case "1"
                    Console.WriteLine("Enter the value: ")
                    Data = Console.ReadLine()
                    Call Push(Data)
                    Call OutputAllNodes()
                Case "2"
                    Data = Pop()
                    Console.WriteLine("Data popped: " & Data)
                    Call OutputAllNodes()
                Case "3"
                    Call OutputAllNodes()
                    Console.WriteLine(TopOfStack & " " & FreeListPtr)
                    For i = 0 To 6
                        Console.WriteLine(i & " " & Stack(i).Data & " " & Stack(i).Pointer)
                    Next
            End Select
            Choice = GetOption()
        End While
    End Sub
    Function GetOption() As Char
        Dim Choice As Char
        Console.WriteLine("1: Push a value")
        Console.WriteLine("2: Pop a value")
        Console.WriteLine("3: Output stack")
        Console.WriteLine("4: Quit")
        Console.WriteLine("Enter your choice: ")
        Choice = Console.ReadLine()
        Return Choice
    End Function
    Sub InitialiseStack()
        TopOfStack = NULLPOINTER ' set start pointer
        FreeListPtr = 0 ' set starting position of free list
        For Index = 0 To 6 'link all nodes to make free list
            Stack(Index).Pointer = Index + 1
        Next
        Stack(6).Pointer = NULLPOINTER 'last node of free list
    End Sub
    Sub Push(ByVal NewItem)
        Dim NewNodePtr As Integer
        If FreeListPtr <> NULLPOINTER Then
            ' there is space in the array
            ' take node from free list and store data item
            NewNodePtr = FreeListPtr
            Stack(NewNodePtr).Data = NewItem
            FreeListPtr = Stack(FreeListPtr).Pointer
            ' insert new node at top of stack
            Stack(NewNodePtr).Pointer = TopOfStack
            TopOfStack = NewNodePtr
        Else
            Console.Writeline("no space FOR more data")
        End If
    End Sub
    Function Pop() As String
        Dim ThisNodePtr As Integer
        Dim Value As String
        If TopOfStack = NULLPOINTER Then
            Console.WriteLine("no data on stack")
            Value = ""
        Else
            Value = Stack(TopOfStack).Data
            ThisNodePtr = TopOfStack
            TopOfStack = Stack(TopOfStack).Pointer
            Stack(ThisNodePtr).Pointer = FreeListPtr
            FreeListPtr = ThisNodePtr
        End If
        Return Value
    End Function
    Sub OutputAllNodes()
        Dim CurrentNodePtr As Integer
        CurrentNodePtr = TopOfStack ' start at beginning of list
        If TopOfStack = NULLPOINTER Then
            Console.Writeline("No data on stack")
        End If
        While CurrentNodePtr <> NULLPOINTER ' while not END of list
            Console.WriteLine(CurrentNodePtr & " " & Stack(CurrentNodePtr).Data)
            ' follow the pointer to the NEXT node
            CurrentNodePtr = Stack(CurrentNodePtr).Pointer
        End While
    End Sub
End Module
