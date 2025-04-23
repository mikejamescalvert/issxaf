Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors.Filtering
Imports DevExpress.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.DC

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class CriteriaEditorViewController
    Inherits ViewController(Of DetailView)
    Public Sub New()
        InitializeComponent()

        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        For Each ppeEditor In View.GetItems(Of CriteriaPropertyEditor)()

            AddHandler ppeEditor.ValueRead, AddressOf CriteriaPropertyEditor_ValueRead

        Next

        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub


    Private Sub CriteriaPropertyEditor_ValueRead(sender As Object, e As EventArgs)
        Dim ppeEditor As CriteriaPropertyEditor = sender
        Dim cpe As DevExpress.ExpressApp.Win.Editors.FilterEditorControlHelper

        Dim fecControl As DevExpress.XtraFilterEditor.FilterEditorControl = ppeEditor.Control
        GenerateColumnCollectionValues(fecControl.FilterColumns)
        'For Each objColumn In fecControl.FilterColumns
        '    Throw New NotImplementedException
        'Next
    End Sub

    Public Sub GenerateColumnCollectionValues(ByRef SourceFilterColumnCollection As FilterColumnCollection)
        Dim col As DataColumnInfoFilterColumn
        Dim colToAdd As DataColumnInfoFilterColumn

        Dim dciDataColumn As DataColumnInfo
        Dim itiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo

        Dim xpdRootDescriptor As XafPropertyDescriptor
        Dim xpdDescriptor As XafPropertyDescriptor
        For intLoop As Integer = SourceFilterColumnCollection.Count - 1 To 0 Step -1
            If TypeOf SourceFilterColumnCollection(intLoop) Is DataColumnInfoFilterColumn Then
                col = SourceFilterColumnCollection(intLoop)
                'todo: get descendant types
                itiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(col.ColumnType)
                xpdRootDescriptor = col.Column.PropertyDescriptor
                For Each dti In itiTypeInfo.Descendants

                    For Each mmi In dti.OwnMembers
                        'xpdDescriptor = New XafPropertyDescriptor(mmi, "[" + dti.Name + "]" + mmi.Name)
                        'dciDataColumn = New DataColumnInfo(xpdDescriptor)
                        'colToAdd = New DataColumnInfoFilterColumn(dciDataColumn, mmi.IsList)

                        'If mmi.MemberType Is GetType(String) Then
                        '    colToAdd.SetColumnEditor(New RepositoryItemStringEdit)
                        'ElseIf mmi.MemberType Is GetType(DateTime) Then
                        '    colToAdd.SetColumnEditor(New RepositoryItemDateEdit)
                        'End If
                        col.Children.Add(New UnboundColumnInfo("[" + dti.Name + "]" + mmi.Name, UnboundColumnType.String, False, "<" + dti.Name + ">" + col.FieldName + "." + mmi.Name, True))

                    Next

                    'dciDataColumn = New DescendantDataInfo(xpdRootDescriptor, dti)
                    'colToAdd = New DescendantFilterColumn(dciDataColumn, dti.IsListType)
                    'colToAdd.SetColumnEditor(col.ColumnEditor)
                    'SourceFilterColumnCollection.Add(colToAdd)
                    'colToAdd = New DataColumnInfoFilterColumn(
                    'colToAdd
                    'colToAdd = New DataColumnInfoFilterColumn(String.Format("{0} [{1}]", col.ColumnCaption, dti.Name), "<" + dti.Name + ">" + col.FieldName, dti.Type, col.ColumnEditor, DevExpress.Data.Filtering.Helpers.FilterColumnClauseClass.Lookup)
                    'SourceFilterColumnCollection.Add(colToAdd)
                    'For Each mmiMember In dti.OwnMembers
                    '    colMember = Nothing
                    '    If mmiMember.MemberType Is GetType(String) Then
                    '        colMember = New CustomFilterColumn(mmiMember.Name, String.Format("{0}.{1}", colToAdd.FieldName, mmiMember.BindingName), mmiMember.MemberType, colToAdd.ColumnEditor, DevExpress.Data.Filtering.Helpers.FilterColumnClauseClass.String)
                    '    ElseIf mmiMember.MemberType Is GetType(DateTime) Then
                    '        colMember = New CustomFilterColumn(mmiMember.Name, String.Format("{0}.{1}", colToAdd.FieldName, mmiMember.BindingName), mmiMember.MemberType, colToAdd.ColumnEditor, DevExpress.Data.Filtering.Helpers.FilterColumnClauseClass.DateTime)
                    '    ElseIf mmiMember.MemberTypeInfo.IsPersistent = True Then
                    '        colMember = New CustomFilterColumn(mmiMember.Name, String.Format("{0}.{1}", colToAdd.FieldName, mmiMember.BindingName), mmiMember.MemberType, colToAdd.ColumnEditor, DevExpress.Data.Filtering.Helpers.FilterColumnClauseClass.Lookup)
                    '    End If
                    '    If colMember IsNot Nothing Then
                    '        colToAdd.AddChild(colMember)
                    '    End If


                    'Next

                Next
            End If

        Next

    End Sub

    Public Function GetDescendants() As List(Of Type)

    End Function


End Class

Public Class DescendantFilterColumn
    Inherits DataColumnInfoFilterColumn

    Public Overrides ReadOnly Property FieldName As String
        Get
            Return String.Format("<{0}>{1}", DescendantColumn.DescendantType.Name, MyBase.FieldName)
        End Get
    End Property

    Public Overrides ReadOnly Property HasChildren As Boolean
        Get
            Return Children.Count > 0
        End Get
    End Property

    Public Property DescendantColumn As DescendantDataInfo
    Public Sub New(ByVal column As DescendantDataInfo, ByVal IsList As Boolean)

        MyBase.New(column, IsList)
        DescendantColumn = column
    End Sub

    Public Overrides ReadOnly Property ColumnType As Type
        Get
            Return DescendantColumn.DescendantType.Type
        End Get
    End Property

    Private _mChildren As List(Of IBoundProperty)
    Public Overrides ReadOnly Property Children As List(Of IBoundProperty)
        Get
            If _mChildren Is Nothing Then

                Dim dciDataColumn As DataColumnInfo
                Dim colToAdd As DataColumnInfoFilterColumn
                Dim xpdDescriptor As XafPropertyDescriptor
                _mChildren = MyBase.Children
                _mChildren.Clear()
                For Each mmi In DescendantColumn.DescendantType.OwnMembers
                    xpdDescriptor = New XafPropertyDescriptor(mmi, mmi.Name)
                    dciDataColumn = New DataColumnInfo(xpdDescriptor)
                    colToAdd = New DataColumnInfoFilterColumn(dciDataColumn, mmi.IsList)
                    'If mmi.MemberType Is GetType(String) Then
                    '    colToAdd.SetColumnEditor(New RepositoryItemStringEdit)
                    'ElseIf mmi.MemberType Is GetType(DateTime) Then
                    '    colToAdd.SetColumnEditor(New RepositoryItemDateEdit)
                    'End If
                    _mChildren.Add(colToAdd)
                Next

            End If

            Return _mChildren
        End Get
    End Property

    Public Overrides ReadOnly Property ColumnCaption As String
        Get
            Return String.Format("[{0}] {1}", DescendantColumn.DescendantType.Name, MyBase.ColumnCaption)
        End Get
    End Property

End Class

Public Class DescendantDataInfo
    Inherits DataColumnInfo
    Public Property DescendantType As ITypeInfo
    Public Sub New(ByVal descriptor As XafPropertyDescriptor, ByVal DescendantType As ITypeInfo)
        MyBase.New(descriptor)
        Me.DescendantType = DescendantType
    End Sub

End Class
