﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Reflection
Namespace Objects.DTA

    <MasterProvider.Module.AllowDataModificationsInMasterProvider>
    <Persistent("DTA10200")>
    Partial Public Class DTACodeAssignmentDetails
        Inherits XPLiteObject
        Dim fDOCNUMBR As String
        <Size(21)>
        Public Property DOCNUMBR() As String
            Get
                Return fDOCNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(DOCNUMBR), fDOCNUMBR, value)
            End Set
        End Property
        Dim fRMDTYPAL As Short
        Public Property RMDTYPAL() As Short
            Get
                Return fRMDTYPAL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)(NameOf(RMDTYPAL), fRMDTYPAL, value)
            End Set
        End Property
        Dim fPOSTDESC As String
        <Size(51)>
        Public Property POSTDESC() As String
            Get
                Return fPOSTDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(POSTDESC), fPOSTDESC, value)
            End Set
        End Property
        Dim fDTAQNTY As Decimal
        Public Property DTAQNTY() As Decimal
            Get
                Return fDTAQNTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)(NameOf(DTAQNTY), fDTAQNTY, value)
            End Set
        End Property
        Dim fCODEAMT As Decimal
        Public Property CODEAMT() As Decimal
            Get
                Return fCODEAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)(NameOf(CODEAMT), fCODEAMT, value)
            End Set
        End Property
        Dim fTRXDATE As DateTime
        Public Property TRXDATE() As DateTime
            Get
                Return fTRXDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)(NameOf(TRXDATE), fTRXDATE, value)
            End Set
        End Property
        Public Structure CompoundKey1Struct
            <Persistent("DTASERIES")>
            Public Property DTASERIES As Short
            <Size(25)>
            <Persistent("DTAREF")>
            Public Property DTAREF As String
            <Persistent("ACTINDX")>
            Public Property ACTINDX As Integer
            <Persistent("SEQNUMBR")>
            Public Property SEQNUMBR As Integer
            <Size(15)>
            <Persistent("GROUPID")>
            Public Property GROUPID As String
            <Size(15)>
            <Persistent("CODEID")>
            Public Property CODEID As String
        End Structure
        <Key(), Persistent()>
        Public CompoundKey1 As CompoundKey1Struct
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class

End Namespace
