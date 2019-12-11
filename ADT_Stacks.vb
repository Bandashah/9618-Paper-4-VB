'Task 2.1 Stacks

Module Module1
Dim StackPtr As Integer
Dim Stack(0 To 9) As String

Sub Main()

StackPtr = 0
Dim MenuChoice As Integer = 0
While MenuChoice <> 4
Console.WriteLine("1. To PUSH to STACK")
Console.WriteLine("2. To POP from STACK")
Console.WriteLine("3. Traverse STACK")
Console.WriteLine("4. To EXIT this module.")
MenuChoice = Console.ReadLine()
Select MenuChoice
Case 1 : cmdPush_Click()
Case 2 : cmdPop_Click()
Case 3 : cmdTraverse()
Case 4
Case Else : Console.WriteLine("Wrong choice. Please try again.")
End Select
End While
End Sub
Sub cmdPop_Click()
If StackPtr < 1 Then
Console.WriteLine("Underflow")
Exit Sub
End If
StackPtr = StackPtr - 1
Console.WriteLine(Stack(StackPtr))
End Sub
Sub cmdPush_Click()
Dim newVal As String
Console.WriteLine("Enter new Value: ")
newVal = Console.ReadLine()
If StackPtr > 9 Then
Console.WriteLine("Overflow")
Exit Sub
End If
Stack(StackPtr) = newVal
StackPtr = StackPtr + 1
End Sub
Sub cmdTraverse()
For count = 9 To 0 Step -1
Console.WriteLine(Stack(count))
Next
End Sub
End Module
