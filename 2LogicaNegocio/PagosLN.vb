Imports _1AccesoDatos
Imports _3Entidades

Public Class PagosLN
    Public Sub New()

    End Sub

    Public Sub InsertarPagos(ByVal pPagos As PagosEN)
        Try
            Dim myPagosAD As New PagosAD

            If Not IsNothing(myPagosAD.ObtenerPagosPorID(pPagos.Num_Pago)) Then
                Throw New Exception("Ya existe ese ID")
            End If

            myPagosAD.InsertarPagos(pPagos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarPagos(ByVal pPagos As PagosEN)
        Try
            Dim myPagosAD As New PagosAD

            If IsNothing(myPagosAD.ObtenerPagosPorID(pPagos.Num_Pago)) Then
                Throw New Exception("No existe ese ID")
            End If

            myPagosAD.ModificarPagos(pPagos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarPagos(ByVal pPagos As PagosEN)
        Try
            Dim myPagosAD As New PagosAD
            myPagosAD.EliminarPagos(pPagos)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerPagosPorID(ByVal pNum_Pago As String) As PagosEN
        Try
            Dim myPagosAD As New PagosAD
            Return myPagosAD.ObtenerPagosPorID(pNum_Pago)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosPagos() As List(Of PagosEN)
        Try
            Dim myPagosAD As New PagosAD
            Return myPagosAD.ObtenerTodosLosPagos()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
