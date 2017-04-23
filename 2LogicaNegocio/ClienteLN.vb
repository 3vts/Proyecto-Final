Imports _3Entidades
Imports _1AccesoDatos
Public Class ClienteLN
    Public Sub New()

    End Sub

    Public Sub InsertarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim myClienteAD As New ClienteAD

            If Not IsNothing(myClienteAD.ObtenerClientePorID(pCliente.Num_Cliente)) Then
                Throw New Exception("Ya existe ese ID")
            End If

            myClienteAD.InsertarCliente(pCliente)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim myClienteAD As New ClienteAD

            If IsNothing(myClienteAD.ObtenerClientePorID(pCliente.Num_Cliente)) Then
                Throw New Exception("No existe ese ID")
            End If

            myClienteAD.ModificarCliente(pCliente)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim myClienteAD As New ClienteAD
            myClienteAD.EliminarCliente(pCliente)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerClientePorID(ByVal pNum_Cliente As String) As ClienteEN
        Try
            Dim myClienteAD As New ClienteAD
            Return myClienteAD.ObtenerClientePorID(pNum_Cliente)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosClientes() As List(Of ClienteEN)
        Try
            Dim myClienteAD As New ClienteAD
            Return myClienteAD.ObtenerTodosLosClientes()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
