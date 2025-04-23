Imports DevExpress.Xpo

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10401
    ''' </summary>
    <Persistent("IV10401")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVPricesheetLineItemDetail
        Inherits XPLiteObject

        Public Structure IVPricesheetLineItemDetailKey
            Private fPRCSHID As String
            <Size(15)>
            <Persistent("PRCSHID")>
            Public Property PRCSHID() As String
                Get
                    Return fPRCSHID
                End Get
                Set(ByVal value As String)
                    fPRCSHID = value
                End Set
            End Property

            Private fSEQNUMBR As Integer
            <Persistent("SEQNUMBR")>
            Public Property SEQNUMBR() As Integer
                Get
                    Return fSEQNUMBR
                End Get
                Set(ByVal value As Integer)
                    fSEQNUMBR = value
                End Set
            End Property
        End Structure

        Dim fOid As IVPricesheetLineItemDetailKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVPricesheetLineItemDetailKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVPricesheetLineItemDetailKey)
                SetPropertyValue(Of IVPricesheetLineItemDetailKey)("Oid", fOid, value)
            End Set
        End Property


        Dim fEPITMTYP As Char
        Public Property EPITMTYP() As Char
            Get
                Return fEPITMTYP
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("EPITMTYP", fEPITMTYP, value)
            End Set
        End Property
        Dim fITEMNMBR As String
        <Size(31)>
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
            End Set
        End Property
        Dim fBRKPTPRC As Byte
        Public Property BRKPTPRC() As Byte
            Get
                Return fBRKPTPRC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BRKPTPRC", fBRKPTPRC, value)
            End Set
        End Property
        Dim fACTIVE As Byte
        Public Property ACTIVE() As Byte
            Get
                Return fACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ACTIVE", fACTIVE, value)
            End Set
        End Property
        Dim fBASEUOFM As String
        <Size(9)>
        Public Property BASEUOFM() As String
            Get
                Return fBASEUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BASEUOFM", fBASEUOFM, value)
            End Set
        End Property
        Dim fPRODTCOD As Char
        Public Property PRODTCOD() As Char
            Get
                Return fPRODTCOD
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("PRODTCOD", fPRODTCOD, value)
            End Set
        End Property
        Dim fPROMOTYP As Short
        Public Property PROMOTYP() As Short
            Get
                Return fPROMOTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PROMOTYP", fPROMOTYP, value)
            End Set
        End Property
        Dim fPROMOLVL As Short
        Public Property PROMOLVL() As Short
            Get
                Return fPROMOLVL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PROMOLVL", fPROMOLVL, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
