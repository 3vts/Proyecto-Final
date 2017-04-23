Imports _3Entidades
Imports System.Data.OleDb

Public Class ClienteAD
    'Objeto que permite conectarse a la BD Access
    Dim miConexion As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Base de Datos.mdb")

    Public Sub New()
        'Clase sin atributos. Se deja vacio
    End Sub
    Public Sub InsertarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim strInsert As String
            strInsert = "INSERT INTO Cliente (Num_Cliente, Nombre, Telefono, Direccion, Indicador_Empresa, Indicador_Persona, Cedula_Juridica) VALUES (@Num_Cliente, @Nombre, @Telefono, @Direccion, @Indicador_Empresa, @Indicador_Persona, @Cedula_Juridica)"
            miConexion.Open()
            Dim cmdCliente As New OleDbCommand(strInsert, miConexion)
            cmdCliente.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pCliente.Num_Cliente
            cmdCliente.Parameters.Add("@Nombre", OleDbType.VarChar).Value = pCliente.Nombre
            cmdCliente.Parameters.Add("@Telefono", OleDbType.VarChar).Value = pCliente.Telefono
            cmdCliente.Parameters.Add("@Direccion", OleDbType.VarChar).Value = pCliente.Direccion
            cmdCliente.Parameters.Add("@Indicador_Empresa", OleDbType.Boolean).Value = pCliente.Indicador_Empresa
            cmdCliente.Parameters.Add("@Indicador_Persona", OleDbType.Boolean).Value = pCliente.Indicador_Persona
            cmdCliente.Parameters.Add("@Cedula_Juridica", OleDbType.VarChar).Value = pCliente.Cedula_Juridica

            cmdCliente.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ModificarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim strUpdate As String
            strUpdate = "UPDATE Cliente SET Num_Cliente=@Num_Cliente, Nombre=@Nombre, Telefono=@Telefono, Direccion=@Direccion, Indicador_Empresa=@Indicador_Empresa, Indicador_Persona=@Indicador_Persona, Cedula_Juridica=@Cedula_Juridica WHERE Num_Cliente=@Num_Cliente"
            miConexion.Open()
            Dim cmdCliente As New OleDbCommand(strUpdate, miConexion)
            cmdCliente.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pCliente.Num_Cliente
            cmdCliente.Parameters.Add("@Nombre", OleDbType.VarChar).Value = pCliente.Nombre
            cmdCliente.Parameters.Add("@Telefono", OleDbType.VarChar).Value = pCliente.Telefono
            cmdCliente.Parameters.Add("@Direccion", OleDbType.VarChar).Value = pCliente.Direccion
            cmdCliente.Parameters.Add("@Indicador_Empresa", OleDbType.Boolean).Value = pCliente.Indicador_Empresa
            cmdCliente.Parameters.Add("@Indicador_Persona", OleDbType.Boolean).Value = pCliente.Indicador_Persona
            cmdCliente.Parameters.Add("@Cedula_Juridica", OleDbType.VarChar).Value = pCliente.Cedula_Juridica

            cmdCliente.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub EliminarCliente(ByVal pCliente As ClienteEN)
        Try
            Dim strDelete As String
            strDelete = "DELETE FROM Cliente WHERE Num_Cliente=@Num_Cliente"
            miConexion.Open()
            Dim cmdCliente As New OleDbCommand(strDelete, miConexion)
            cmdCliente.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pCliente.Num_Cliente

            cmdCliente.ExecuteNonQuery()

            miConexion.Close()

        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Function ObtenerClientePorID(ByVal pNum_Cliente As String) As ClienteEN
        Try
            Dim strFindByID As String
            strFindByID = "SELECT Num_Cliente, Nombre, Telefono, Direccion, Indicador_Empresa, Indicador_Persona, Cedula_Juridica FROM Cliente WHERE Num_Cliente=@Num_Cliente"
            miConexion.Open()
            Dim cmdCliente As New OleDbCommand(strFindByID, miConexion)
            cmdCliente.Parameters.Add("@Num_Cliente", OleDbType.VarChar).Value = pNum_Cliente

            Dim drCliente As OleDbDataReader
            drCliente = cmdCliente.ExecuteReader()
            Dim myCliente As ClienteEN = Nothing
            While drCliente.Read
                myCliente = New ClienteEN
                With myCliente
                    .Num_Cliente = drCliente(0)
                    .Nombre = drCliente(1)
                    .Telefono = drCliente(2)
                    .Direccion = drCliente(3)
                    .Indicador_Empresa = drCliente(4)
                    .Indicador_Persona = drCliente(5)
                    .Cedula_Juridica = drCliente(6)
                End With
            End While

            drCliente.Close()

            miConexion.Close()
            Return myCliente
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function

    Public Function ObtenerTodosLosClientes() As List(Of ClienteEN)
        Try
            Dim strFindAll As String
            Dim lstClientes As New List(Of ClienteEN)
            strFindAll = "SELECT Num_Cliente, Nombre, Telefono, Direccion, Indicador_Empresa, Indicador_Persona, Cedula_Juridica FROM Cliente "
            miConexion.Open()
            Dim cmdCliente As New OleDbCommand(strFindAll, miConexion)

            Dim drCliente As OleDbDataReader
            drCliente = cmdCliente.ExecuteReader()
            Dim myCliente As ClienteEN = Nothing
            While drCliente.Read
                myCliente = New ClienteEN
                With myCliente
                    .Num_Cliente = drCliente(0)
                    .Nombre = drCliente(1)
                    .Telefono = drCliente(2)
                    .Direccion = drCliente(3)
                    .Indicador_Empresa = drCliente(4)
                    .Indicador_Persona = drCliente(5)
                    .Cedula_Juridica = drCliente(6)
                End With
                lstClientes.Add(myCliente)
            End While

            drCliente.Close()

            miConexion.Close()
            Return lstClientes
        Catch ex As Exception
            If (miConexion.State = ConnectionState.Open) Then
                miConexion.Close()
            End If
            Throw New Exception(ex.Message)
            Exit Function
        End Try
    End Function
End Class
