Imports _1AccesoDatos
Imports _3Entidades

Public Class ProyectosLN
    Public Sub New()

    End Sub

    Public Sub InsertarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim myProyectosAD As New ProyectosAD

            If Not IsNothing(myProyectosAD.ObtenerProyectosPorID(pProyectos.Cod_Proyecto)) Then
                Throw New Exception("Ya existe ese ID")
            End If

            myProyectosAD.InsertarProyectos(pProyectos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim myProyectosAD As New ProyectosAD

            If IsNothing(myProyectosAD.ObtenerProyectosPorID(pProyectos.Cod_Proyecto)) Then
                Throw New Exception("No existe ese ID")
            End If

            myProyectosAD.ModificarProyectos(pProyectos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim myProyectosAD As New ProyectosAD
            myProyectosAD.EliminarProyectos(pProyectos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerProyectosPorID(ByVal pCod_Proyecto As String) As ProyectosEN
        Try
            Dim myProyectosAD As New ProyectosAD
            Return myProyectosAD.ObtenerProyectosPorID(pCod_Proyecto)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosProyectos() As List(Of ProyectosEN)
        Try
            Dim myProyectosAD As New ProyectosAD
            Return myProyectosAD.ObtenerTodosLosProyectos()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
