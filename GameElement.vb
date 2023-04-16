Module Module1
    Class GameElement
        Private PositionX As Integer
        Private PositionY As Integer
        Private Width As Integer
        Private Height As Integer
        Private ImageFilename As String

        Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, Filename As String)
            PositionX = X
            PositionY = Y
            Width = W
            Height = H
            ImageFilename = Filename
        End Sub
        Public Function GetDetails()
            Dim Message As String
            Message = "PositionX: " & PositionX & "PositionY: " & PositionY & ", width: " & Width & ", height: " & Height & ", ImageFilename:" & ImageFilename
            Return Message
        End Function
    End Class

    Class Scenery
        Inherits GameElement
        Private CauseDamage As Boolean
        Private DamagePoints As Integer
        Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, Filename As String, ByVal CD As Boolean, ByVal DP As Integer)
            MyBase.New(X, Y, W, H, Filename)
            CauseDamage = CD
            DamagePoints = DP
        End Sub
        Public Function GiveDamagePoints() As Integer
            If (CauseDamage) Then
                Return DamagePoints
            Else
                Return 0
            End If
        End Function
        Public Function GetScenery() As String
            Dim Message As String
            Message = MyBase.GetDetails()
            Message = Message & "CauseDamage: " & CauseDamage & "" & "DamagePoints: " & DamagePoints
            Return Message
        End Function
    End Class

    Sub Main()
        Dim giftbox As Scenery
        giftbox = New Scenery(150, 150, 50, 75, "box.png", True, 50)

        Console.WriteLine(giftbox.GetScenery)
        Console.ReadKey()
    End Sub

End Module
