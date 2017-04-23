Imports _1AccesoDatos
Imports _3Entidades

Public Class UsuarioLN
    Public Sub New()

    End Sub

    Public Sub InsertarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim myUsuarioAD As New UsuarioAD

            If Not IsNothing(myUsuarioAD.ObtenerUsuarioPorID(pUsuario.Login)) Then
                Throw New Exception("Ya existe ese Login")
            End If

            myUsuarioAD.InsertarUsuario(pUsuario)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim myUsuarioAD As New UsuarioAD

            If IsNothing(myUsuarioAD.ObtenerUsuarioPorID(pUsuario.Login)) Then
                Throw New Exception("No existe ese Login")
            End If

            myUsuarioAD.ModificarUsuario(pUsuario)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarUsuario(ByVal pUsuario As UsuarioEN)
        Try
            Dim myUsuarioAD As New UsuarioAD
            myUsuarioAD.EliminarUsuario(pUsuario)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerUsuarioPorID(ByVal pLogin As String) As UsuarioEN
        Try
            Dim myUsuarioAD As New UsuarioAD
            Return myUsuarioAD.ObtenerUsuarioPorID(pLogin)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosUsuarios() As List(Of UsuarioEN)
        Try
            Dim myUsuarioAD As New UsuarioAD
            Return myUsuarioAD.ObtenerTodosLosUsuarios()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
