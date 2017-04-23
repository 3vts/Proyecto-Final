Imports _3Entidades
Imports System.Data.OleDb


Public Class ProyectosAD
    'Objeto que permite conectarse a la BD Access
    Dim miConexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base de Datos.mdb")

    Public Sub New()
        'Clase sin atributos. Se deja vacio
    End Sub
    Public Sub InsertarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim strInsert As String
            strInsert = "INSERT INTO Proyectos (Cod_Proyecto, Nombre_Proyecto, Fec_Creacion, Fec_Finalizacion, Costo_Total, Observaciones, Num_Cliente) VALUES (@Cod_Proyecto, @Nombre_Proyecto, @Fec_Creacion, @Fec_Finalizacion, @Costo_Total, @Observaciones, @Num_Cliente)"
            miConexion.Open()
            Dim cmdProyectos As New OleDbCommand(strInsert, miConexion)
            cmdProyectos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pProyectos.Cod_Proyecto
            cmdProyectos.Parameters.Add("@Nombre_Proyecto", OleDbType.VarChar).Value = pProyectos.Nombre_Proyecto
            cmdProyectos.Parameters.Add("@Fec_Creacion", OleDbType.Date).Value = pProyectos.Fec_Creacion
            cmdProyectos.Parameters.Add("@Fec_Finalizacion", OleDbType.Date).Value = pProyectos.Fec_Finalizacion
            cmdProyectos.Parameters.Add("@Costo_Total", OleDbType.Currency).Value = pProyectos.Costo_Total
            cmdProyectos.Parameters.Add("@Observaciones", OleDbType.VarChar).Value = pProyectos.Observaciones
            cmdProyectos.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pProyectos.Num_Cliente

            cmdProyectos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim strUpdate As String
            strUpdate = "UPDATE Proyectos SET Cod_Proyecto=@Cod_Proyecto, Nombre_Proyecto=@Nombre_Proyecto, Fec_Creacion=@Fec_Creacion, Fec_Finalizacion=@Fec_Finalizacion, Costo_Total=@Costo_Total, Observaciones=@Observaciones, Num_Cliente=@Num_Cliente WHERE Cod_Proyecto=@Cod_Proyecto"
            miConexion.Open()
            Dim cmdProyectos As New OleDbCommand(strUpdate, miConexion)
            cmdProyectos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pProyectos.Cod_Proyecto
            cmdProyectos.Parameters.Add("@Nombre_Proyecto", OleDbType.VarChar).Value = pProyectos.Nombre_Proyecto
            cmdProyectos.Parameters.Add("@Fec_Creacion", OleDbType.Date).Value = pProyectos.Fec_Creacion
            cmdProyectos.Parameters.Add("@Fec_Finalizacion", OleDbType.Date).Value = pProyectos.Fec_Finalizacion
            cmdProyectos.Parameters.Add("@Costo_Total", OleDbType.Currency).Value = pProyectos.Costo_Total
            cmdProyectos.Parameters.Add("@Observaciones", OleDbType.VarChar).Value = pProyectos.Observaciones
            cmdProyectos.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pProyectos.Num_Cliente

            cmdProyectos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarProyectos(ByVal pProyectos As ProyectosEN)
        Try
            Dim strDelete As String
            strDelete = "DELETE FROM Proyectos WHERE Cod_Proyecto=@Cod_Proyecto"
            miConexion.Open()
            Dim cmdProyectos As New OleDbCommand(strDelete, miConexion)
            cmdProyectos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pProyectos.Cod_Proyecto

            cmdProyectos.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerProyectosPorID(ByVal pCod_Proyecto As String) As ProyectosEN
        Try
            Dim strFindByID As String
            strFindByID = "SELECT Cod_Proyecto, Nombre_Proyecto, Fec_Creacion, Fec_Finalizacion, Costo_Total, Observaciones, Num_Cliente FROM Proyectos WHERE Cod_Proyecto=@Cod_Proyecto"
            miConexion.Open()
            Dim cmdProyectos As New OleDbCommand(strFindByID, miConexion)
            cmdProyectos.Parameters.Add("@Cod_Proyecto", OleDbType.VarChar).Value = pCod_Proyecto

            Dim drProyectos As OleDbDataReader
            drProyectos = cmdProyectos.ExecuteReader()
            Dim myProyectos As ProyectosEN = Nothing
            While drProyectos.Read
                myProyectos = New ProyectosEN
                With myProyectos
                    .Cod_Proyecto = drProyectos(0)
                    .Nombre_Proyecto = drProyectos(1)
                    .Fec_Creacion = drProyectos(2)
                    .Fec_Finalizacion = drProyectos(3)
                    .Costo_Total = drProyectos(4)
                    .Observaciones = drProyectos(5)
                    .Num_Cliente = drProyectos(6)
                End With
            End While

            drProyectos.Close()

            miConexion.Close()
            Return myProyectos
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosProyectos() As List(Of ProyectosEN)
        Try
            Dim strFindAll As String
            Dim lstProyectoss As New List(Of ProyectosEN)
            strFindAll = "SELECT Cod_Proyecto, Nombre_Proyecto, Fec_Creacion, Fec_Finalizacion, Costo_Total, Observaciones, Num_Cliente FROM Proyectos"
            miConexion.Open()
            Dim cmdProyectos As New OleDbCommand(strFindAll, miConexion)

            Dim drProyectos As OleDbDataReader
            drProyectos = cmdProyectos.ExecuteReader()
            Dim myProyectos As ProyectosEN = Nothing
            While drProyectos.Read
                myProyectos = New ProyectosEN
                With myProyectos
                    .Cod_Proyecto = drProyectos(0)
                    .Nombre_Proyecto = drProyectos(1)
                    .Fec_Creacion = drProyectos(2)
                    .Fec_Finalizacion = drProyectos(3)
                    .Costo_Total = drProyectos(4)
                    .Observaciones = drProyectos(5)
                    .Num_Cliente = drProyectos(6)
                End With
                lstProyectoss.Add(myProyectos)
            End While

            drProyectos.Close()

            miConexion.Close()
            Return lstProyectoss
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
