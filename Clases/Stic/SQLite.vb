Imports System.Data.SQLite
Namespace Stic
    Public Class SQLite
        Private Structure Mensajes
            Public Const SinSentenciaSQL As String = "No existe una sentencia SQL para ejecutar"
        End Structure
        Private Class DLLs
            Public Shared ReadOnly Property System_Data_SQLite As String = Stic.Directorios.Aplicacion & "System.Data.SQLite.dll"
            Public Shared ReadOnly Property System_Data_SQLite_EF6 As String = Stic.Directorios.Aplicacion & "System.Data.SQLite.EF6.dll"
            Public Shared ReadOnly Property System_Data_SQLite_Linq As String = Stic.Directorios.Aplicacion & "System.Data.SQLite.Linq.dll"
            Public Shared ReadOnly Property x64_SQLite_Interop As String
                Get
                    Dim Carpeta As String = Stic.Directorios.Aplicacion & "x64"
                    If Not System.IO.Directory.Exists(Carpeta) Then
                        System.IO.Directory.CreateDirectory(Carpeta)
                    End If
                    Return Carpeta & "\SQLite.Interop.dll"
                End Get
            End Property
            Public Shared ReadOnly Property x86_SQLite_Interop As String
                Get
                    Dim Carpeta As String = Stic.Directorios.Aplicacion & "x86"
                    If Not System.IO.Directory.Exists(Carpeta) Then
                        System.IO.Directory.CreateDirectory(Carpeta)
                    End If
                    Return Carpeta & "\SQLite.Interop.dll"
                End Get
            End Property
        End Class

        Private connetionString As String = "Data Source=" & Me.BaseDatos & ";Version=3;New=True;Compress=True;"
        Private Cnx As SQLiteConnection ' = New SQLiteConnection(connetionString)
        Private _Count As Integer = 0
        Public Property SentenciaSQL As String
        Public Shared Property BaseDatos As String = Stic.Directorios.Stic & "local.stic"
        Public ReadOnly Property Count As Integer
            Get
                Return _Count
            End Get
        End Property
        Private Sub PreRequisitos()
            If Not System.IO.File.Exists(DLLs.System_Data_SQLite) Then
                System.IO.File.WriteAllBytes(DLLs.System_Data_SQLite, My.Resources.System_Data_SQLite)
            End If
            If Not System.IO.File.Exists(DLLs.System_Data_SQLite_EF6) Then
                System.IO.File.WriteAllBytes(DLLs.System_Data_SQLite_EF6, My.Resources.System_Data_SQLite_EF6)
            End If
            If Not System.IO.File.Exists(DLLs.System_Data_SQLite_Linq) Then
                System.IO.File.WriteAllBytes(DLLs.System_Data_SQLite_Linq, My.Resources.System_Data_SQLite_Linq)
            End If

            If Not System.IO.File.Exists(DLLs.x64_SQLite_Interop) Then
                System.IO.File.WriteAllBytes(DLLs.x64_SQLite_Interop, My.Resources.SQLite_Interop_x64)
            End If

            If Not System.IO.File.Exists(DLLs.x86_SQLite_Interop) Then
                System.IO.File.WriteAllBytes(DLLs.x86_SQLite_Interop, My.Resources.SQLite_Interop_x86)
            End If

        End Sub
        Public Sub New()
            PreRequisitos()
            Cnx = New SQLiteConnection(connetionString)
            SentenciaSQL = ""
        End Sub
        Public Sub New(BaseDatos As String)
            PreRequisitos()
            connetionString = "Data Source=" & BaseDatos & ";Version=3;New=True;Compress=True;"
            Cnx = New SQLiteConnection(connetionString)
            SentenciaSQL = ""
        End Sub
        Public Function AbrirBaseDatos()
            Try
                Cnx.Open()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function LeerDatos() As DataTable
            Dim DT As New DataTable
            Try
                If SentenciaSQL.Trim.Length = 0 Then Throw New System.Exception(Mensajes.SinSentenciaSQL)
                Dim adapter As SQLiteDataAdapter
                Dim ds As DataSet = New DataSet()
                adapter = New SQLiteDataAdapter(SentenciaSQL, Cnx)
                adapter.Fill(ds)
                DT = ds.Tables(0)
                _Count = DT.Rows.Count
                adapter.Dispose()
                ds.Dispose()
                Return DT

            Catch ex As Exception
                Throw
            Finally
                SentenciaSQL = ""
                DT.Dispose()
            End Try
        End Function
        Public Function GuardarDatos() As Integer
            Try
                If SentenciaSQL.Trim.Length = 0 Then Throw New System.Exception(Mensajes.SinSentenciaSQL)
                Dim comandoSQL = New SQLiteCommand(SentenciaSQL, Cnx)
                Dim resultadoSQL = comandoSQL.ExecuteReader()
                'Dim ss = resultadoSQL.RecordsAffected

                _Count = resultadoSQL.RecordsAffected
                comandoSQL.Dispose()
                resultadoSQL.Dispose()
                Return _Count

            Catch ex As Exception
                Throw
            Finally
                SentenciaSQL = ""
            End Try
        End Function
        Public Sub CerrarBaseDatos()
            Try
                Cnx.Close()
            Catch ex As Exception
                Throw
            End Try
        End Sub
    End Class
End Namespace
