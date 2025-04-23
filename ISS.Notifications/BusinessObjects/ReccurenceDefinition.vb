Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Model

<System.ComponentModel.DefaultProperty("SummaryInfo")>
Public Class RecurrenceDefinition
    Inherits BaseObject

    Public Enum RecurrencePatternTypes
        Hourly = 0
        Daily = 1
        Weekly = 2
        Monthly = 3
        Yearly = 4
        Minutes = 5
    End Enum
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub


#Region "Properties"
    <Persistent("NextExecutionDateTime")> _
    Private _mNextExecutionDateTime As Date?
    Protected Overridable Sub SetNextExecutionDateTime(ByVal Value As Date?)
        SetPropertyValue("NextExecutionDateTime", _mNextExecutionDateTime, Value)
    End Sub
    <PersistentAlias("_mNextExecutionDateTime")> _
    Public ReadOnly Property NextExecutionDateTime As Date?
        Get
            Return _mNextExecutionDateTime
        End Get
    End Property


    Public ReadOnly Property SummaryInfo As String
        Get
            If Due Then
                Return String.Format("{0} (DUE)", RecurrencePattern)
            Else
                Return RecurrencePattern.ToString
            End If
        End Get
    End Property



    Private _mRecurrencePattern As RecurrencePatternTypes
    <RuleRequiredField()>
    <ImmediatePostData()>
    Public Property RecurrencePattern As RecurrencePatternTypes
        Get
            Return _mRecurrencePattern
        End Get
        Set(ByVal Value As RecurrencePatternTypes)
            SetPropertyValue("RecurrencePattern", _mRecurrencePattern, Value)
        End Set
    End Property

        Private _mMinutesRecurrence As Integer
    <RuleValueComparison("MinutesRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Minutes'")>
    Public Property MinutesRecurrence As Integer
        Get
            Return _mMinutesRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("MinutesRecurrence", _mMinutesRecurrence, Value)
        End Set
    End Property

    Private _mHourlyRecurrence As Integer
    <RuleValueComparison("HourlyRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Hourly'")>
    Public Property HourlyRecurrence As Integer
        Get
            Return _mHourlyRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("HourlyRecurrence", _mHourlyRecurrence, Value)
        End Set
    End Property

    Private _mDailyRecurrence As Integer
    <RuleValueComparison("DailyRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Daily'")>
    Public Property DailyRecurrence As Integer
        Get
            Return _mDailyRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("DailyRecurrence", _mDailyRecurrence, Value)
        End Set
    End Property


    Private _mWeeklyRecurrence As Integer
    <RuleValueComparison("WeeklyRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Weekly'")>
    Public Property WeeklyRecurrence As Integer
        Get
            Return _mWeeklyRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("WeeklyRecurrence", _mWeeklyRecurrence, Value)
        End Set
    End Property

    Private _mWeeklyOnMonday As Boolean
    Public Property WeeklyOnMonday As Boolean
        Get
            Return _mWeeklyOnMonday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnMonday", _mWeeklyOnMonday, Value)
        End Set
    End Property
    Private _mWeeklyOnTuesday As Boolean
    Public Property WeeklyOnTuesday As Boolean
        Get
            Return _mWeeklyOnTuesday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnTuesday", _mWeeklyOnTuesday, Value)
        End Set
    End Property
    Private _mWeeklyOnWednesday As Boolean
    Public Property WeeklyOnWednesday As Boolean
        Get
            Return _mWeeklyOnWednesday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnWednesday", _mWeeklyOnWednesday, Value)
        End Set
    End Property
    Private _mWeeklyOnThursday As Boolean
    Public Property WeeklyOnThursday As Boolean
        Get
            Return _mWeeklyOnThursday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnThursday", _mWeeklyOnThursday, Value)
        End Set
    End Property
    Private _mWeeklyOnFriday As Boolean
    Public Property WeeklyOnFriday As Boolean
        Get
            Return _mWeeklyOnFriday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnFriday", _mWeeklyOnFriday, Value)
        End Set
    End Property
    Private _mWeeklyOnSaturday As Boolean
    Public Property WeeklyOnSaturday As Boolean
        Get
            Return _mWeeklyOnSaturday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnSaturday", _mWeeklyOnSaturday, Value)
        End Set
    End Property
    Private _mWeeklyOnSunday As Boolean
    Public Property WeeklyOnSunday As Boolean
        Get
            Return _mWeeklyOnSunday
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("WeeklyOnSunday", _mWeeklyOnSunday, Value)
        End Set
    End Property
    Private _mMonthlyDayOfMonth As Integer
    <RuleRange("MonthlyDayRange", DefaultContexts.Save, 1, 31, TargetCriteria:="RecurrencePattern='Monthly'")>
    Public Property MonthlyDayOfMonth As Integer
        Get
            Return _mMonthlyDayOfMonth
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("MonthlyDayOfMonth", _mMonthlyDayOfMonth, Value)
        End Set
    End Property
    Private _mMonthlyRecurrence As Integer
    <RuleValueComparison("MonthlyRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Monthly'")>
    Public Property MonthlyRecurrence As Integer
        Get
            Return _mMonthlyRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("MonthlyRecurrence", _mMonthlyRecurrence, Value)
        End Set
    End Property
    Private _mYearlyRecurrence As Integer
    <RuleValueComparison("YearlyRecurrenceRange", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0, TargetCriteria:="RecurrencePattern='Yearly'")>
    Public Property YearlyRecurrence As Integer
        Get
            Return _mYearlyRecurrence
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("YearlyRecurrence", _mYearlyRecurrence, Value)
        End Set
    End Property
    Private _mYearlyMonth As Integer
    <RuleRange("YearlyMonthRange", DefaultContexts.Save, 1, 12, TargetCriteria:="RecurrencePattern='Yearly'")>
    Public Property YearlyMonth As Integer
        Get
            Return _mYearlyMonth
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("YearlyMonth", _mYearlyMonth, Value)
        End Set
    End Property
    Private _mYearlyDay As Integer
    <RuleRange("YearlyDayRange", DefaultContexts.Save, 1, 31, TargetCriteria:="RecurrencePattern='Yearly'")>
    Public Property YearlyDay As Integer
        Get
            Return _mYearlyDay
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("YearlyDay", _mYearlyDay, Value)
        End Set
    End Property

    Private _mTimeToExecute As Date?

    <ToolTip("The next date/time to execute")>
    <RuleRequiredField()>
    Public Property TimeToExecute As Date?
        Get
            Return _mTimeToExecute
        End Get
        Set(ByVal Value As Date?)
            SetPropertyValue("TimeToExecute", _mTimeToExecute, Value)

        End Set
    End Property
    Private _mStartTime As DateTime
    <ModelDefault("DisplayFormat", "{0:t}"), _
ModelDefault("EditMask", "t")> _
    Public Property StartTime As DateTime
        Get
            Return _mStartTime
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue("StartTime", _mStartTime, Value)
        End Set
    End Property
    Private _mEndTime As DateTime
    <ModelDefault("DisplayFormat", "{0:t}"), _
ModelDefault("EditMask", "t")> _
    Public Property EndTime As DateTime
        Get
            Return _mEndTime
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue("EndTime", _mEndTime, Value)
        End Set
    End Property


    <Persistent("LastExecutionDateTime")> _
    Private _mLastExecutionDateTime As Date?
    Protected Overridable Sub SetLastExecutionDateTime(ByVal Value As Date?)
        SetPropertyValue("LastExecutionDateTime", _mLastExecutionDateTime, Value)
    End Sub
    <PersistentAlias("_mLastExecutionDateTime")> _
    Public ReadOnly Property LastExecutionDateTime As Date?
        Get
            Return _mLastExecutionDateTime
        End Get
    End Property
    
    Public ReadOnly Property Due As Boolean
        Get
            If TimeToExecute > Now
                Return False
            End If
            If StartTime <> Nothing And Now.TimeOfDay < StartTime.TimeOfDay
                Return False
            End If
            If EndTime <> Nothing And Now.TimeOfDay > EndTime.TimeOfDay
                Return False
            End If
            If RecurrencePattern = 0 And HourlyRecurrence <= 0
                Return False
            End If
            If RecurrencePattern = 1 And DailyRecurrence <= 0
                Return False
            End If
            If RecurrencePattern = 2 And WeeklyRecurrence <= 0
                Return False
            End If
            If RecurrencePattern = 3 And MonthlyRecurrence <= 0
                Return False
            End If
            If RecurrencePattern = 4 And YearlyRecurrence <= 0
                Return False
            End If
                        If RecurrencePattern =5 And MinutesRecurrence <= 0
                Return False
            End If

            Return True
        End Get
    End Property


    'Public ReadOnly Property Due As Boolean
    '	Get
    '		Return IsDue()
    '	End Get
    'End Property




#End Region

#Region "Behaviors"
    ''' <summary>
    ''' Update the last executed date and time to now
    ''' and updates the next time to execute
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub Update()
        SetLastExecutionDateTime(Now)
        UpdateNextExecutionDatetime()
    End Sub

    Private Sub UpdateNextExecutionDatetime()

        If Not TimeToExecute.HasValue Then
            TimeToExecute = Now
        End If

         If RecurrencePattern = 0 And HourlyRecurrence <= 0
                Return
            End If
            If RecurrencePattern = 1 And DailyRecurrence <= 0
                Return
            End If
            If RecurrencePattern = 2 And WeeklyRecurrence <= 0
                Return
            End If
            If RecurrencePattern = 3 And MonthlyRecurrence <= 0
                Return
            End If
            If RecurrencePattern = 4 And YearlyRecurrence <= 0
                Return
            End If
                    If RecurrencePattern = 5 And MinutesRecurrence <= 0
                Return
            End If
        Dim dteNextTimeToExecute As Date = TimeToExecute.Value
        Dim dowWeek = GetDaysOfWeekToExecute

        'todo: implement days of week skipping


        Do While dteNextTimeToExecute < Now
            Select Case RecurrencePattern
                                Case RecurrencePatternTypes.Minutes
                    If Me.MinutesRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If
                    If dowWeek.Count = 0
                        Return
                    End If
                    dteNextTimeToExecute = dteNextTimeToExecute.AddMinutes(Me.MinutesRecurrence)
                    
                Case RecurrencePatternTypes.Hourly
                    If Me.HourlyRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If

                    dteNextTimeToExecute = dteNextTimeToExecute.AddHours(Me.HourlyRecurrence)

                Case RecurrencePatternTypes.Daily
                    If Me.DailyRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If
                    dteNextTimeToExecute = dteNextTimeToExecute.AddDays(Me.DailyRecurrence)
                Case RecurrencePatternTypes.Monthly
                    If Me.MonthlyRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If
                    dteNextTimeToExecute = dteNextTimeToExecute.AddMonths(Me.MonthlyRecurrence)
                Case RecurrencePatternTypes.Yearly
                    If Me.YearlyRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If
                    dteNextTimeToExecute = dteNextTimeToExecute.AddYears(Me.YearlyRecurrence)
                Case RecurrencePatternTypes.Weekly
                     If Me.WeeklyRecurrence = 0
                        TimeToExecute = Nothing
                        Return
                    End If
                    dteNextTimeToExecute = dteNextTimeToExecute.AddDays(Me.WeeklyRecurrence * 7)
            End Select
        Loop
        TimeToExecute = dteNextTimeToExecute
        OnChanged("Due")


    End Sub

    Private Function GetDaysOfWeekToExecute() As Collection
        Dim DOW As New Collection
        If WeeklyOnSunday Then DOW.Add(0)
        If WeeklyOnMonday Then DOW.Add(1)
        If WeeklyOnTuesday Then DOW.Add(2)
        If WeeklyOnWednesday Then DOW.Add(3)
        If WeeklyOnThursday Then DOW.Add(4)
        If WeeklyOnFriday Then DOW.Add(5)
        If WeeklyOnSaturday Then DOW.Add(6)
        Return DOW
    End Function
    Protected Overrides Sub OnChanged(propertyName As String, oldValue As Object, newValue As Object)
        MyBase.OnChanged(propertyName, oldValue, newValue)
        Select Case propertyName
            Case "OptimisticLockField", "OptimisticLockFieldInDataLayer", "TimeToExecute", "LastExecutionDateTime", "Due", "GCRecord"


            Case Else
                UpdateNextExecutionDatetime()
        End Select

    End Sub


    'Private Function IsDue() As Boolean
    '	'if past the execution time check values

    '	Select Case RecurrencePattern
    '		Case RecurrencePatternTypes.Hourly
    '			If LastExecutionDateTime Is Nothing Then
    '				If TimeToExecute Is Nothing Then
    '					Return True
    '				Else
    '					Return Now >= TimeToExecute.Value
    '				End If
    '			End If


    '			If Now.Subtract(LastExecutionDateTime).TotalHours >= Me.HourlyRecurrence Then
    '				If TimeToExecute Is Nothing Then
    '					Return True
    '				Else
    '					Return Now >= TimeToExecute.Value
    '				End If

    '			End If
    '			Return False



    '		Case RecurrencePatternTypes.Daily
    '			If LastExecutionDateTime Is Nothing Then
    '				If TimeToExecute Is Nothing Then
    '					Return True
    '				Else
    '					Return Now >= TimeToExecute.Value
    '				End If
    '			End If
    '			If Now.Subtract(LastExecutionDateTime.Value).TotalDays >= Me.DailyRecurrence Then
    '				If TimeToExecute Is Nothing Then
    '					Return True
    '				Else
    '					Return Now >= TimeToExecute.Value
    '				End If
    '			End If

    '			Return False

    '		Case RecurrencePatternTypes.Weekly

    '			If LastExecutionDateTime Is Nothing Then
    '				If TimeToExecute Is Nothing Then
    '					Return True
    '				Else
    '					Return Now >= TimeToExecute.Value
    '				End If
    '			End If
    '			If Now > TimeToExecute.Value AndAlso Now.TimeOfDay >= TimeToExecute.Value.TimeOfDay Then
    '				Dim colWeeklyDays As Collection = GetDaysOfWeekToExecute()
    '				For Each intDay As Integer In colWeeklyDays
    '					If Today.DayOfWeek = intDay Then
    '						If LastExecutionDateTime.Value.Date < Today.Date Then
    '							Return True
    '						End If
    '					End If
    '				Next
    '			End If

    '			Return False


    '		Case RecurrencePatternTypes.Monthly
    '			If TimeToExecute Is Nothing OrElse (Now > TimeToExecute.Value AndAlso Now.TimeOfDay >= TimeToExecute.Value.TimeOfDay) Then
    '				Dim intTargetDayOfMonth As Integer
    '				If DateTime.DaysInMonth(Today.Year, Today.Month) < MonthlyDayOfMonth Then
    '					intTargetDayOfMonth = DateTime.DaysInMonth(Today.Year, Today.Month)
    '				Else
    '					intTargetDayOfMonth = MonthlyDayOfMonth
    '				End If
    '				If LastExecutionDateTime Is Nothing Then
    '					If Today.Day >= intTargetDayOfMonth Then
    '						Return True
    '					Else
    '						Return True
    '					End If
    '				End If

    '				'determine if we are into a future reporting month and if today's day is equal or past the target day.
    '				If DateDiff(DateInterval.Month, DateSerial(LastExecutionDateTime.Value.Year, LastExecutionDateTime.Value.Month, 1), DateSerial(Today.Year, Today.Month, 1)) >= MonthlyRecurrence AndAlso intTargetDayOfMonth <= Today.Day Then
    '					Return True
    '				Else
    '					Return False
    '				End If
    '			End If
    '			Return False

    '		Case RecurrencePatternTypes.Yearly
    '			If TimeToExecute Is Nothing OrElse (Now > TimeToExecute.Value AndAlso Now.TimeOfDay >= TimeToExecute.Value.TimeOfDay) Then
    '				Dim intTargetDayOfMonth As Integer
    '				If DateTime.DaysInMonth(Today.Year, YearlyMonth) < YearlyDay Then
    '					intTargetDayOfMonth = DateTime.DaysInMonth(Today.Year, Today.Month)
    '				Else
    '					intTargetDayOfMonth = YearlyDay
    '				End If

    '				If LastExecutionDateTime Is Nothing Then
    '					If Today.Month >= YearlyMonth AndAlso Today.Day >= intTargetDayOfMonth Then
    '						Return True
    '					Else
    '						Return False
    '					End If
    '				End If

    '				'determine if we are into a future reporting year and if the today's month and day is equal or past the target month and day.
    '				If DateDiff(DateInterval.Year, DateSerial(LastExecutionDateTime.Value.Year, 1, 1), DateSerial(Today.Year, 1, 1)) >= YearlyRecurrence AndAlso YearlyMonth <= Today.Month AndAlso intTargetDayOfMonth <= Today.Day Then
    '					Return True
    '				Else
    '					Return False
    '				End If
    '			End If
    '			Return False

    '		Case Else
    '			Return False
    '	End Select



    'End Function

#End Region


End Class
