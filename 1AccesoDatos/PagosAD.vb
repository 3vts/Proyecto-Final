Imports System.Data.OleDb
Imports _3Entidades

Public Class PagosAD
    'Objeto que permite conectarse a la BD Access
    Dim miConexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base de Datos.mdb")

    Public Sub New()
        'Clase sin atributos. Se deja vacio
    End Sub
    Public Sub InsertarPagos(ByVal pPagos As PagosEN)
        Try
            Dim strInsert As String
            strInsert = "INSERT INTO Pagos (Num_Pago, Fecha_Pago, Monto_Pago, Observaciones, Banco_Del_Pago, Cod_Proyecto) VALUES (@Num_Pago, @Fecha_Pago, @Monto_Pago, @Observaciones, @Banco_Del_Pago, @Cod_Proyecto)"
            miConexion.Open()
            Dim cmdPagos As New OleDbCommand(strInsert, miConexion)
            cmdPagos.Parameters.Add("@Num_Pago", OleDbType.VarChar).Value = pPagos.Num_Pago
            cmdPagos.Parameters.Add("@Fecha_Pago", OleDbType.Date).Value = pPagos.Fecha_Pago
            cmdPagos.Parameters.Add("@Monto_Pago", OleDbType.Double).Value = pPagos.Monto_Pago
            cmdPagos.Parameters.Add("@Observaciones", OleDbType.VarChar).Value = pPagos.Observaciones
            cmdPagos.Parameters.Add("@Banco_Del_Pago", OleDbType.VarChar).Value = pPagos.Banco_Del_Pago
            cmdPagos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pPagos.Cod_Proyecto

            cmdPagos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarPagos(ByVal pPagos As PagosEN)
        Try
            Dim strUpdate As String
            strUpdate = "UPDATE Pagos SET Num_Pago=@Num_Pago, Fecha_Pago=@Fecha_Pago, Monto_Pago=@Monto_Pago, Observaciones=@Observaciones, Banco_Del_Pago=@Banco_Del_Pago, Cod_Proyecto= @Cod_Proyecto WHERE Num_Pago=@Num_Pago"
            miConexion.Open()
            Dim cmdPagos As New OleDbCommand(strUpdate, miConexion)
            cmdPagos.Parameters.Add("@Num_Pago", OleDbType.VarChar).Value = pPagos.Num_Pago
            cmdPagos.Parameters.Add("@Fecha_Pago", OleDbType.Date).Value = pPagos.Fecha_Pago
            cmdPagos.Parameters.Add("@Monto_Pago", OleDbType.Double).Value = pPagos.Monto_Pago
            cmdPagos.Parameters.Add("@Observaciones", OleDbType.VarChar).Value = pPagos.Observaciones
            cmdPagos.Parameters.Add("@Banco_Del_Pago", OleDbType.VarChar).Value = pPagos.Banco_Del_Pago
            cmdPagos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pPagos.Cod_Proyecto
            cmdPagos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarPagos(ByVal pPagos As PagosEN)
        Try
            Dim strDelete As String
            strDelete = "DELETE FROM Pagos WHERE Num_Pago=@Num_Pago"
            miConexion.Open()
            Dim cmdPagos As New OleDbCommand(strDelete, miConexion)
            cmdPagos.Parameters.Add("@Num_Pago", OleDbType.VarChar).Value = pPagos.Num_Pago

            cmdPagos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerPagosPorID(ByVal pNum_Pago As String) As PagosEN
        Try
            Dim strFindByID As String
            strFindByID = "SELECT Num_Pago, Fecha_Pago, Monto_Pago, Observaciones, Banco_Del_Pago, Cod_Proyecto FROM Pagos WHERE Num_Pago=@Num_Pago"
            miConexion.Open()
            Dim cmdPagos As New OleDbCommand(strFindByID, miConexion)
            cmdPagos.Parameters.Add("@Num_Pago", OleDbType.VarChar).Value = pNum_Pago

            Dim drPagos As OleDbDataReader
            drPagos = cmdPagos.ExecuteReader()
            Dim myPagos As PagosEN = Nothing
            While drPagos.Read
                myPagos = New PagosEN
                With myPagos
                    .Num_Pago = drPagos(0)
                    .Fecha_Pago = drPagos(1)
                    .Monto_Pago = drPagos(2)
                    .Observaciones = drPagos(3)
                    .Banco_Del_Pago = drPagos(4)
                    .Cod_Proyecto = drPagos(5)
                End With
            End While

            drPagos.Close()

            miConexion.Close()
            Return myPagos
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosPagos() As List(Of PagosEN)
        Try
            Dim strFindAll As String
            Dim lstPagoss As New List(Of PagosEN)
            strFindAll = "SELECT Num_Pago, Fecha_Pago, Monto_Pago, Observaciones, Banco_Del_Pago, Cod_Proyecto FROM Pagos"
            miConexion.Open()
            Dim cmdPagos As New OleDbCommand(strFindAll, miConexion)

            Dim drPagos As OleDbDataReader
            drPagos = cmdPagos.ExecuteReader()
            Dim myPagos As PagosEN = Nothing
            While drPagos.Read
                myPagos = New PagosEN
                With myPagos
                    .Num_Pago = drPagos(0)
                    .Fecha_Pago = drPagos(1)
                    .Monto_Pago = drPagos(2)
                    .Observaciones = drPagos(3)
                    .Banco_Del_Pago = drPagos(4)
                    .Cod_Proyecto = drPagos(5)
                End With
                lstPagoss.Add(myPagos)
            End While

            drPagos.Close()

            miConexion.Close()
            Return lstPagoss
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
