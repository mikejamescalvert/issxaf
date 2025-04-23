Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class WorkflowWinHelper



    ''' <summary>
    ''' Sets the controls visibility/editability based on the current workflow step rules.
    ''' </summary>
    ''' <param name="ControlObject"></param>
    ''' <param name="CurrentObject"></param>
    ''' <param name="PropertyName"></param>
    ''' <remarks>Internal Use Only</remarks>
    Public Shared Sub SetupWorkflowControl(ByVal ControlObject As System.Windows.Forms.Control, ByVal CurrentObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication, Optional ByVal EnableAll As Boolean = False)
        Dim objTest As Object
        Dim blnIsEnabled As System.Nullable(Of Boolean)
        Dim blnIsReadonly As System.Nullable(Of Boolean)
        Dim blnDisabledIfExists As System.Nullable(Of Boolean)
        If EnableAll = False Then
            blnIsEnabled = Helpers.WorkflowHelper.IsPropertyEnabled(CurrentObject, PropertyName, ObjectType, Application)
            blnDisabledIfExists = Helpers.WorkflowHelper.IsDisabledIfExists(CurrentObject, PropertyName, ObjectType, Application)
            If blnDisabledIfExists.HasValue = True AndAlso blnDisabledIfExists = True Then
                objTest = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(PropertyName, CurrentObject)
                If TypeOf objTest Is String Or TypeOf objTest Is DateTime Then
                    If objTest <> Nothing Then
                        blnIsEnabled = False
                    End If
                Else
                    If objTest IsNot Nothing Then
                        blnIsEnabled = False
                    End If
                End If
            End If

            blnIsReadonly = Helpers.WorkflowHelper.IsReadOnly(CurrentObject, PropertyName, ObjectType, Application)
            If blnIsReadonly.HasValue = True AndAlso blnIsReadonly = False Then
                If Helpers.WorkflowHelper.IsReadOnlyIfExists(CurrentObject, PropertyName, ObjectType, Application) = True Then
                    objTest = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(PropertyName, CurrentObject)
                    If TypeOf objTest Is String Or TypeOf objTest Is DateTime Then
                        If objTest <> Nothing Then
                            blnIsReadonly = False
                        End If
                    Else
                        If objTest IsNot Nothing Then
                            blnIsReadonly = False
                        End If
                    End If
                End If
            End If


            ISS.Base.Win.WinLayoutHelper.SetupPropertyEditor(ControlObject, blnIsEnabled, Helpers.WorkflowHelper.IsPropertyVisible(CurrentObject, PropertyName, ObjectType, Application), Helpers.WorkflowHelper.IsPropertyRequired(CurrentObject, PropertyName, ObjectType, Application), blnIsReadonly, Helpers.WorkflowHelper.GetEditorColor(CurrentObject, PropertyName, ObjectType, Application))
        Else
            ISS.Base.Win.WinLayoutHelper.SetupPropertyEditor(ControlObject, True, True, Helpers.WorkflowHelper.IsPropertyRequired(CurrentObject, PropertyName, ObjectType, Application), False, Helpers.WorkflowHelper.GetEditorColor(CurrentObject, PropertyName, ObjectType, Application))
        End If

    End Sub
    Public Shared Sub SetupWorkflowListView(ByVal ListView As Editors.ListPropertyEditor, ByVal CurrentObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication, Optional ByVal EnableAll As Boolean = False)
        If EnableAll = False Then
            ISS.Base.Win.WinLayoutHelper.SetupListView(ListView, Helpers.WorkflowHelper.IsPropertyEnabled(CurrentObject, PropertyName, ObjectType, Application), Helpers.WorkflowHelper.IsPropertyVisible(CurrentObject, PropertyName, ObjectType, Application))
        Else
            ISS.Base.Win.WinLayoutHelper.SetupListView(ListView, True, True)
        End If

    End Sub

End Class
