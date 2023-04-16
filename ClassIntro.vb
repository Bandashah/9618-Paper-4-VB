Public Class Animal
    Public Name As String
    Public Sound As String

    Public Sub MakeSound()
        Console.WriteLine(Name & " says " & Sound)
    End Sub
End Class

Public Class Dog
    Inherits Animal

    Public Sub New()
        Name = "Dog"
        Sound = "Woof"
    End Sub
End Class

Public Class Cat
    Inherits Animal

    Public Sub New()
        Name = "Cat"
        Sound = "Meow"
    End Sub
End Class

Module Module1
    Sub Main()
        Dim dog As New Dog()
        dog.MakeSound()

        Dim cat As New Cat()
        cat.MakeSound()

        Console.ReadLine()
    End Sub
End Module
