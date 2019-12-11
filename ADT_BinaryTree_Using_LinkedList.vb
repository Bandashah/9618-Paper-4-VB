'TASK 1 A2 Paper 4 PRM 2019 MJ
'Binary Tree code with Linked List Data Structure and Root/Free Pointers usage

Module Module1
    'Binary Tree code with Linked List Data Structure and Root/Free Pointers usage:
    'NullPointer should be set to -1 IF using array element with index 0
    Const NULLPOINTER = -1
    'Declare record type to store data AND pointer
    Structure TreeNode
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure
    Const UB = 9
    Const LB = 0
    Dim Tree(0 To UB) As TreeNode
    Dim RootPointer As Integer
    Dim FreePtr As Integer
    Dim StackPtr As Integer = NULLPOINTER
    Dim Stack(0 To UB) As TreeNode
    Sub Main()
        Dim Choice As Integer = 0
        Dim Data As String = ""
        Dim CurrentPtr As Integer = 0
        InitialiseTree()
        While Choice <> "4"
            Choice = GetOption()
            Select Case Choice
                Case 1
                    Console.WriteLine("Enter new data item... ")
                    Data = Console.ReadLine()
                    Call InsertNode(Data)
                Case 2
                    Console.WriteLine("Enter search value: ")
                    Data = Console.ReadLine()
                    'CurrentPtr = FindNode(Data) 'non recursive search
                    CurrentPtr = recursiveFind(RootPointer, Data) 'recursive search
                    If CurrentPtr = NULLPOINTER Then
                        Console.WriteLine("Value not found")
                    Else
                        Console.WriteLine("Value found at: " & CurrentPtr)
                    End If
                Case 3
                    Console.WriteLine("Inorder Traversed Data")
                    Console.WriteLine("----------------------")
                    'Call InOrderTraverse(RootPointer) 'recursive inorder traversal
                    inorderIteration() 'iterative inorder traversal
                    Console.WriteLine("")
                    Console.WriteLine("Root Pointer = " & RootPointer & ", Free Pointer = " & FreePtr)
                    Console.WriteLine("")
                    Console.WriteLine("Index " & "LP " & "Data" & Space(26) & "RP")
                    For i = LB To UB
                        Console.WriteLine(i & Space(5) & Tree(i).LeftPointer & Space(5 - Len(Tree(i).LeftPointer.ToString)) & Tree(i).Data & Space(30 - Len(Tree(i).Data)) & Tree(i).RightPointer)
                    Next
            End Select
        End While
    End Sub
    Function GetOption() As Integer
        Dim Choice As Integer
        Console.WriteLine("Binary Tree Main Menu")
        Console.WriteLine("1: Add Data Item")
        Console.WriteLine("2: Find Data Item")
        Console.WriteLine("3: Read/Traverse Binary Tree Inorder (left-root-right)")
        Console.WriteLine("4: Quit")
        Console.WriteLine("")
        Console.WriteLine("Menu option...? ")
        Choice = Console.ReadLine()
        Return Choice
    End Function
    Sub InitialiseTree()
        RootPointer = NULLPOINTER 'set start pointer
        FreePtr = 0 'set starting position of free list
        For Index = LB To UB 'link all nodes to make free list
            Tree(Index).LeftPointer = NULLPOINTER
            Tree(Index).Data = ""
            Tree(Index).RightPointer = Index + 1
        Next
        Tree(UB).RightPointer = NULLPOINTER 'last node of free list
    End Sub
    Function FindNode(ByVal SearchItem) As Integer
        Dim CurrentPtr As Integer
        CurrentPtr = RootPointer
        While CurrentPtr <> NULLPOINTER And Tree(CurrentPtr).Data <> SearchItem
            If SearchItem < Tree(CurrentPtr).Data Then
                CurrentPtr = Tree(CurrentPtr).LeftPointer
            Else
                CurrentPtr = Tree(CurrentPtr).RightPointer
            End If
        End While
        Return CurrentPtr
    End Function
    Sub InsertNode(ByVal NewItem As String)
        Dim NewNodePtr, CurrentPtr, PrevNodePtr As Integer
        Dim TurnedLeft As Boolean
        If FreePtr <> NULLPOINTER Then
            'there is space in the array
            'take node from free list AND store data item
            NewNodePtr = FreePtr
            Tree(NewNodePtr).Data = NewItem
            FreePtr = Tree(FreePtr).RightPointer
            Tree(NewNodePtr).RightPointer = NULLPOINTER
            'check IF empty tree
            If RootPointer = NULLPOINTER Then

                RootPointer = NewNodePtr
            Else 'find insertion point
                CurrentPtr = RootPointer
                While CurrentPtr <> NULLPOINTER
                    PrevNodePtr = CurrentPtr
                    If NewItem < Tree(CurrentPtr).Data Then
                        TurnedLeft = True
                        CurrentPtr = Tree(CurrentPtr).LeftPointer
                    Else
                        TurnedLeft = False
                        CurrentPtr = Tree(CurrentPtr).RightPointer
                    End If
                End While
                If TurnedLeft = True Then
                    Tree(PrevNodePtr).LeftPointer = NewNodePtr
                Else
                    Tree(PrevNodePtr).RightPointer = NewNodePtr
                End If
            End If
        Else
            Console.WriteLine("Overflow occured. No space for more data...")
        End If
    End Sub

    'Recursive FUNCTION FOR INORDER Tree Traversal
    Sub InOrderTraverse(ByVal Root As Integer)
        If Root <> NULLPOINTER Then

            'Move Left , traverse left PROCEDURE tree
            InOrderTraverse(Tree(Root).LeftPointer)
            'Output
            Console.WriteLine(Tree(Root).Data)
            'Move Right, traverse right PROCEDURE tree
            Call InOrderTraverse(Tree(Root).RightPointer)
        End If
    End Sub

    Function recursiveFind(ByVal currPtr As Integer, ByVal sVal As String) As Integer
        If currPtr <> NULLPOINTER Then
            Select Case Tree(currPtr).Data
                Case sVal : Return currPtr
                Case Is > sVal : Return recursiveFind(Tree(currPtr).LeftPointer, sVal)
                Case Is < sVal : Return recursiveFind(Tree(currPtr).RightPointer, sVal)
            End Select
        Else
            Return NULLPOINTER
        End If
    End Function

    Sub inorderIteration()
        Dim root As Integer
        StackPtr = NULLPOINTER
        root = RootPointer
        While (True)
            ' Go to the left extreme AND
            ' on the move insert of all the elements to stack
            While (root <> NULLPOINTER)
                Push(Root)
                root = Tree(Root).LeftPointer
            End While
            ' check IF Stack is empty, IF yes, exit from everywhere
            If StackPtr = NULLPOINTER Then
                Exit Sub
            Else
                ' pop the element from the stack , print it AND add the nodes at
                ' the right to the Stack
                root = Pop()
                Console.Writeline(Stack(Root).Data)
                root = Stack(Root).RightPointer
            End If
        End While
    End Sub
    Function Pop() As Integer
        Dim currPtr As Integer
        currPtr = StackPtr
        StackPtr = StackPtr - 1
        Return currPtr
    End Function
    Sub Push(ByVal currPtr As Integer)
        StackPtr = StackPtr + 1
        Stack(StackPtr) = Tree(currPtr)
    End Sub
End Module
