Namespace Attributes.Editors.DecimalProgressPropertyEditor
    Public Class DecimalProgressPropertyEditorAttribute
        Inherits Attribute

        Private _mMaximumValue As Integer = 100
        Public Property MaximumValue() As Integer
            Get
                Return _mMaximumValue
            End Get
            Set(ByVal Value As Integer)
                _mMaximumValue = Value
            End Set
        End Property

        Private _mIntervalStep As Integer = 1
        Public Property IntervalStep() As Integer 
            Get
                Return _mIntervalStep
            End Get
            Set(ByVal Value As Integer )
                _mIntervalStep = Value
            End Set
        End Property


        Public Sub New(ByVal MaximumValue As Integer, ByVal IntervalStep As Integer)
            Me.MaximumValue = MaximumValue
            Me.IntervalStep = IntervalStep
        End Sub


    End Class
End Namespace

