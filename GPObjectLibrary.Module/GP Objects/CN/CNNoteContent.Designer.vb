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
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.CN

    Partial Public Class NoteContent
        Inherits XPLiteObject
        Dim fNOTEINDX As Decimal
        <Key()>
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property
        Dim fTXTFIELD As String
        <Size(SizeAttribute.Unlimited)>
        Public Property TXTFIELD() As String
            Get
                Return fTXTFIELD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXTFIELD", fTXTFIELD, value)
            End Set
        End Property
    End Class

End Namespace
