Public Class PagosEN
#Region "Atributos"
    Dim _Num_Pago As String
    Dim _Fecha_Pago As Date
    Dim _Monto_Pago As Double
    Dim _Observaciones As String
    Dim _Banco_Del_Pago As String
    Dim _Cod_Proyecto As String
#End Region
#Region "Constructores"
    ''' <summary>
    ''' Constructor vacio de la clase
    ''' </summary>
    Public Sub New()
        _Num_Pago = String.Empty
        _Fecha_Pago = CType("01/01/1900", Date)
        _Monto_Pago = 0
        _Observaciones = String.Empty
        _Banco_Del_Pago = String.Empty
        _Cod_Proyecto = String.Empty
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pNum_Pago">Numero de pago</param>
    ''' <param name="pFecha_Pago">Fecha de pago</param>
    ''' <param name="pMonto_Pago">Monto del pago</param>
    ''' <param name="pObservaciones">Observaciones del pago</param>
    ''' <param name="pBanco_Del_Pago">Banco del pago</param>
    ''' <param name="pCod_Proyecto">Codigo de proyecto</param>
    Public Sub New(ByVal pNum_Pago As String,
                   ByVal pFecha_Pago As Date,
                   ByVal pMonto_Pago As Double,
                   ByVal pObservaciones As String,
                   ByVal pBanco_Del_Pago As String,
                   ByVal pCod_Proyecto As String)
        _Num_Pago = pNum_Pago
        _Fecha_Pago = pFecha_Pago
        _Monto_Pago = pMonto_Pago
        _Observaciones = pObservaciones
        _Banco_Del_Pago = pBanco_Del_Pago
        _Cod_Proyecto = pCod_Proyecto

    End Sub
#End Region
#Region "Propiedades"
    Public Property Num_Pago As String
        Get
            Return _Num_Pago
        End Get
        Set(value As String)
            _Num_Pago = value
        End Set
    End Property

    Public Property Fecha_Pago As Date
        Get
            Return _Fecha_Pago
        End Get
        Set(value As Date)
            _Fecha_Pago = value
        End Set
    End Property

    Public Property Monto_Pago As Double
        Get
            Return _Monto_Pago
        End Get
        Set(value As Double)
            _Monto_Pago = value
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

    Public Property Banco_Del_Pago As String
        Get
            Return _Banco_Del_Pago
        End Get
        Set(value As String)
            _Banco_Del_Pago = value
        End Set
    End Property

    Public Property Cod_Proyecto As String
        Get
            Return _Cod_Proyecto
        End Get
        Set(value As String)
            _Cod_Proyecto = value
        End Set
    End Property
#End Region
End Class
