Public Class ProyectosEN
#Region "Atributos"
    Dim _Cod_Proyecto As String
    Dim _Nombre_Proyecto As String
    Dim _Fec_Creacion As Date
    Dim _Fec_Finalizacion As Date
    Dim _Costo_Total As Double
    Dim _Observaciones As String
    Dim _Num_Cliente As String
#End Region
#Region "Constructores"
    Public Sub New()
        _Cod_Proyecto = String.Empty
        _Nombre_Proyecto = String.Empty
        _Fec_Creacion = CType("01/01/1900", Date)
        _Fec_Finalizacion = CType("01/01/1900", Date)
        _Costo_Total = 0
        _Observaciones = String.Empty
        _Num_Cliente = String.Empty
    End Sub
    Public Sub New(ByVal pCod_Proyecto As String,
                   ByVal pNombre_Proyecto As String,
                   ByVal pFec_Creacion As Date,
                   ByVal pFec_Finalizacion As Date,
                   ByVal pCosto_Total As Double,
                   ByVal pObservaciones As String,
                   ByVal pNum_Cliente As String)
        _Cod_Proyecto = pCod_Proyecto
        _Nombre_Proyecto = pNombre_Proyecto
        _Fec_Creacion = pFec_Creacion
        _Fec_Finalizacion = pFec_Finalizacion
        _Costo_Total = pCosto_Total
        _Observaciones = pObservaciones
        _Num_Cliente = pNum_Cliente
    End Sub
#End Region
#Region "Propiedades"
    Public Property Cod_Proyecto As String
        Get
            Return _Cod_Proyecto
        End Get
        Set(value As String)
            _Cod_Proyecto = value
        End Set
    End Property

    Public Property Nombre_Proyecto As String
        Get
            Return _Nombre_Proyecto
        End Get
        Set(value As String)
            _Nombre_Proyecto = value
        End Set
    End Property

    Public Property Fec_Creacion As Date
        Get
            Return _Fec_Creacion
        End Get
        Set(value As Date)
            _Fec_Creacion = value
        End Set
    End Property

    Public Property Fec_Finalizacion As Date
        Get
            Return _Fec_Finalizacion
        End Get
        Set(value As Date)
            _Fec_Finalizacion = value
        End Set
    End Property

    Public Property Costo_Total As Double
        Get
            Return _Costo_Total
        End Get
        Set(value As Double)
            _Costo_Total = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property Num_Cliente As String
        Get
            Return _Num_Cliente
        End Get
        Set(value As String)
            _Num_Cliente = value
        End Set
    End Property

#End Region
End Class
