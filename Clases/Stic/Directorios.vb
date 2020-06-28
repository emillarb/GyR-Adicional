

Namespace Stic
    Public Class Directorios

        Public Shared ReadOnly Property Aplicacion
            Get
                Return My.Application.Info.DirectoryPath & "\"
            End Get
        End Property
        Public Shared ReadOnly Property Stic
            Get
                Dim R As String = Aplicacion & "Stic\"
                If Not IO.Directory.Exists(R) Then
                    IO.Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property Imagenes
            Get
                Dim R As String = Stic & "Img\"
                If Not IO.Directory.Exists(R) Then
                    IO.Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property Tmp
            Get
                Dim R As String = Stic & "Tmp\"
                If Not IO.Directory.Exists(R) Then
                    IO.Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property


    End Class
End Namespace

