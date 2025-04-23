Imports DevExpress.ExpressApp.Win.Core.ModelEditor
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.XtraEditors.Popup
Imports System.Windows.Forms
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Win.Controls
Imports DevExpress.XtraTreeList.Nodes

Public Class CustomFieldPicker
    Inherits FieldPicker

    ' Fields...
    Private _mPropertyFilter As String
    Public Property PropertyFilter As String
        Get
            Return _mPropertyFilter
        End Get
        Set(ByVal Value As String)
            _mPropertyFilter = Value
        End Set
    End Property


    Protected Overrides Sub DoShowPopup()
        MyBase.DoShowPopup()
        
        Dim ppcPopup As DevExpress.ExpressApp.Win.Core.ModelEditor.FieldPickerPopupForm = Me.PopupForm
        Dim cntContainer As DevExpress.XtraEditors.PopupContainerControl = ppcPopup.Controls(2)
        Dim otfTreeForm As DevExpress.ExpressApp.Win.Controls.ObjectTreeList = cntContainer.Controls(0)
        If PropertyFilter > String.Empty Then
            KillBadNodes(otfTreeForm.Nodes)    
        End If
    End Sub

    Public Sub KillBadNodes(ByVal Nodes As TreeListNodes)
        Dim obj As ObjectTreeListNode
        Dim dtsSource As DevExpress.ExpressApp.DC.XafMemberInfo
        For intLoop As Integer = Nodes.Count - 1 To 0 Step -1
            obj= Nodes(intLoop)
            If TypeOf obj.Object is DevExpress.ExpressApp.DC.XafMemberInfo Then


                dtsSource = obj.Object
                If dtsSource.MemberType.FullName <> PropertyFilter Then
                    Nodes.RemoveAt(intLoop)
                End If

                
            Else
                KillBadNodes(Nodes(intLoop).Nodes)
            End If

        Next
    End Sub


End Class

Public Class CustomModelBrowser
    Inherits ModelBrowser
    Public Sub New(ByVal objectType As Type, ByVal canAddListProperty As Boolean, ByVal disabledMemberNames As IList(Of String))
        MyBase.New(objectType, canAddListProperty, disabledMemberNames)

    End Sub
    Public Sub New(ByVal objectType As Type, ByVal canAddListProperty As Boolean)
        MyBase.New(objectType, canAddListProperty)

    End Sub



End Class