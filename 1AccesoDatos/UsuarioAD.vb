Imports System.Data.OleDb
Imports _3Entidades

Public Class UsuarioAD
    'Objeto que permite conectarse a la BD Access
    Dim miConexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base de Datos.mdb")

    Public Sub New()
        'Clase sin atributos. Se deja vacio
    End Sub
    Public Sub InsertarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim strInsert As String
            strInsert = "INSERT INTO Usuario (Login, Nom_Completo, Clave, Administrador, Digitador) VALUES (@Login, @Nom_Completo, @Clave, @Administrador, @Digitador)"
            miConexion.Open()
            Dim cmdUsuario As New OleDbCommand(strInsert, miConexion)
            cmdUsuario.Parameters.Add("@Login", OleDbType.VarChar).Value = pUsuario.Login
            cmdUsuario.Parameters.Add("@Nom_Completo", OleDbType.VarChar).Value = pUsuario.Nom_Completo
            cmdUsuario.Parameters.Add("@Clave", OleDbType.VarChar).Value = pUsuario.Clave
            cmdUsuario.Parameters.Add("@Administrador", OleDbType.Boolean).Value = pUsuario.Administrador
            cmdUsuario.Parameters.Add("@Digitador", OleDbType.Boolean).Value = pUsuario.Digitador

            cmdUsuario.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim strUpdate As String
            strUpdate = "UPDATE Usuario SET Login=@Login, Nom_Completo=@Nom_Completo, Clave=@Clave, Administrador=@Administrador, Digitador=@Digitador"
            miConexion.Open()
            Dim cmdUsuario As New OleDbCommand(strUpdate, miConexion)
            cmdUsuario.Parameters.Add("@Login", OleDbType.VarChar).Value = pUsuario.Login
            cmdUsuario.Parameters.Add("@Nom_Completo", OleDbType.VarChar).Value = pUsuario.Nom_Completo
            cmdUsuario.Parameters.Add("@Clave", OleDbType.VarChar).Value = pUsuario.Clave
            cmdUsuario.Parameters.Add("@Administrador", OleDbType.Boolean).Value = pUsuario.Administrador
            cmdUsuario.Parameters.Add("@Digitador", OleDbType.Boolean).Value = pUsuario.Digitador

            cmdUsuario.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim strDelete As String
            strDelete = "DELETE FROM Usuario WHERE Login=@Login"
            miConexion.Open()
            Dim cmdUsuario As New OleDbCommand(strDelete, miConexion)
            cmdUsuario.Parameters.Add("@Login", OleDbType.VarChar).Value = pUsuario.Login

            cmdUsuario.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerUsuarioPorID(ByVal pLogin As String) As UsuarioEN
        Try
            Dim strFindByID As String
            strFindByID = "SELECT Login, Nom_Completo, Clave, Administrador, Digitador FROM Usuario WHERE Login=@Login"
            miConexion.Open()
            Dim cmdUsuario As New OleDbCommand(strFindByID, miConexion)
            cmdUsuario.Parameters.Add("@Login", OleDbType.VarChar).Value = pLogin

            Dim drUsuario As OleDbDataReader
            drUsuario = cmdUsuario.ExecuteReader()
            Dim myUsuario As UsuarioEN = Nothing
            While drUsuario.Read
                myUsuario = New UsuarioEN
                With myUsuario
                    .Login = drUsuario(0)
                    .Nom_Completo = drUsuario(1)
                    .Clave = drUsuario(2)
                    .Administrador = drUsuario(3)
                    .Digitador = drUsuario(4)
                End With
            End While

            drUsuario.Close()

            miConexion.Close()
            Return myUsuario
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosUsuarios() As List(Of UsuarioEN)
        Try
            Dim strFindAll As String
            Dim lstUsuarios As New List(Of UsuarioEN)
            strFindAll = "SELECT Login, Nom_Completo, Clave, Administrador, Digitador FROM Usuario"
            miConexion.Open()
            Dim cmdUsuario As New OleDbCommand(strFindAll, miConexion)

            Dim drUsuario As OleDbDataReader
            drUsuario = cmdUsuario.ExecuteReader()
            Dim myUsuario As UsuarioEN = Nothing
            While drUsuario.Read
                myUsuario = New UsuarioEN
                With myUsuario
                    .Login = drUsuario(0)
                    .Nom_Completo = drUsuario(1)
                    .Clave = drUsuario(2)
                    .Administrador = drUsuario(3)
                    .Digitador = drUsuario(4)
                End With
                lstUsuarios.Add(myUsuario)
            End While

            drUsuario.Close()

            miConexion.Close()
            Return lstUsuarios
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
