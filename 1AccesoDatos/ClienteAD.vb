Imports System.Data.OleDb
Imports _3Entidades
Public Class ClienteAD
    'Objeto que permite conectarse a la BD Access
    Dim miConexion As New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data_Source = Base de Datos.mdb")

    Public Sub New()
        'Clase sin atributos. Se deja vacio
    End Sub
    'Public Sub InsertarCliente(ByVal pCliente As ClienteEN)

    'End Sub
End Class
