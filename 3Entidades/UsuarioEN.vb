Public Class UsuarioEN
#Region "Atributos"
    Dim _Login As String
    Dim _Nom_Completo As String
    Dim _Clave As String
    Dim _Administrador As Boolean
    Dim _Digitador As Boolean
#End Region
#Region "Constructores"
    Public Sub New()
        _Login = String.Empty
        _Nom_Completo = String.Empty
        _Clave = String.Empty
        _Administrador = False
        _Digitador = False
    End Sub

    Public Sub New(ByVal pLogin As String,
                   ByVal pNom_Completo As String,
                   ByVal pClave As String,
                   ByVal pAdministrador As Boolean,
                   ByVal pDigitador As Boolean)
        _Login = pLogin
        _Nom_Completo = pNom_Completo
        _Clave = pClave
        _Administrador = pAdministrador
        _Digitador = pDigitador
    End Sub
#End Region
#Region "Propiedades"
    Public Property Login As String
        Get
            Return _Login
        End Get
        Set(value As String)
            _Login = value
        End Set
    End Property

    Public Property Nom_Completo As String
        Get
            Return _Nom_Completo
        End Get
        Set(value As String)
            _Nom_Completo = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

    Public Property Administrador As Boolean
        Get
            Return _Administrador
        End Get
        Set(value As Boolean)
            _Administrador = value
        End Set
    End Property

    Public Property Digitador As Boolean
        Get
            Return _Digitador
        End Get
        Set(value As Boolean)
            _Digitador = value
        End Set
    End Property
#End Region
End Class
