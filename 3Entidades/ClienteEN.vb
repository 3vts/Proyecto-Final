Public Class ClienteEN
#Region "Atributos"
    Dim _Num_Cliente As String
    Dim _Nombre As String
    Dim _Telefono As String
    Dim _Direccion As String
    Dim _Indicador_Empresa As Boolean
    Dim _Indicador_Persona As Boolean
    Dim _Cedula_Juridica As String
#End Region
#Region "Constructores"
    'Constructor vacio de la clase
    Public Sub New()
        _Num_Cliente = String.Empty
        _Nombre = String.Empty
        _Telefono = String.Empty
        _Direccion = String.Empty
        _Indicador_Empresa = False
        _Indicador_Persona = False
        _Cedula_Juridica = String.Empty
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pNum_Cliente">Numero de cliente</param>
    ''' <param name="pNombre">Nombre de cliente</param>
    ''' <param name="pTelefono">Telefono de cliente</param>
    ''' <param name="pDireccion">Direccion de cliente</param>
    ''' <param name="pIndicador_Empresa">Indicador si cliente es empresa</param>
    ''' <param name="pIndicador_Persona">Indicador si cliente es persona</param>
    ''' <param name="pCedula_Juridica">Cedula Juridica cliente</param>
    Public Sub New(ByVal pNum_Cliente As String,
                   ByVal pNombre As String,
                   ByVal pTelefono As String,
                   ByVal pDireccion As String,
                   ByVal pIndicador_Empresa As Boolean,
                   ByVal pIndicador_Persona As Boolean,
                   ByVal pCedula_Juridica As String)
        _Num_Cliente = pNum_Cliente
        _Nombre = pNombre
        _Telefono = pTelefono
        _Direccion = pDireccion
        _Indicador_Empresa = pIndicador_Empresa
        _Indicador_Persona = pIndicador_Persona
        _Cedula_Juridica = pCedula_Juridica

    End Sub

#End Region
#Region "Propiedades"
    Public Property Num_Cliente As String
        Get
            Return _Num_Cliente
        End Get
        Set(value As String)
            _Num_Cliente = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Indicador_Empresa As Boolean
        Get
            Return _Indicador_Empresa
        End Get
        Set(value As Boolean)
            _Indicador_Empresa = value
        End Set
    End Property

    Public Property Indicador_Persona As Boolean
        Get
            Return _Indicador_Persona
        End Get
        Set(value As Boolean)
            _Indicador_Persona = value
        End Set
    End Property

    Public Property Cedula_Juridica As String
        Get
            Return _Cedula_Juridica
        End Get
        Set(value As String)
            _Cedula_Juridica = value
        End Set
    End Property
#End Region
End Class
