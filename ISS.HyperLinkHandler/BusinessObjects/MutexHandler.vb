Imports System.Deployment.Application
Imports System.Globalization
Imports System.IO
Imports System.IO.Pipes
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Public Class MutexHandler
    Implements IDisposable

    Private _mApplication As XafApplication
    Public Property Application As XafApplication
        Get
            Return _mApplication
        End Get
        Set(value As XafApplication)
            _mApplication = value
        End Set
    End Property


    Private ReadOnly _OwnsMutex As Boolean
    Private _Identifier As String = Guid.Empty.ToString()
    Private _Mutex As Mutex

    Public Sub New(ByVal identifier As String)
        _Identifier = identifier
        _Mutex = New Mutex(True, identifier.ToString(CultureInfo.InvariantCulture), _OwnsMutex)
    End Sub

    Public ReadOnly Property IsFirstInstance As Boolean
        Get
            Return _OwnsMutex OrElse Arguments.Length = 0
        End Get
    End Property

    Private Function PassArgumentsToFirstInstance(ByVal arguments As String()) As Boolean
        If arguments Is Nothing Then Return False

        If Not _OwnsMutex Then

            Try

                Using client = New NamedPipeClientStream(_Identifier)

                    Using writer = New StreamWriter(client)
                        client.Connect(200)

                        For Each argument As String In arguments

                            If Not String.IsNullOrEmpty(argument) Then
                                writer.WriteLine(argument)
                            End If
                        Next
                    End Using
                End Using

                Return True
            Catch __unusedTimeoutException1__ As TimeoutException
            Catch __unusedIOException2__ As IOException
            End Try
        End If

        Return False
    End Function

    Public Sub ListenForArgumentsFromSuccessiveInstances()
        If _OwnsMutex Then ThreadPool.QueueUserWorkItem(AddressOf ListenForArguments)
    End Sub

    Private Sub ListenForArguments(ByVal state As Object)
        If _OwnsMutex Then

            Try

                Using server = New NamedPipeServerStream(_Identifier)

                    Using reader = New StreamReader(server)
                        server.WaitForConnection()
                        Dim arguments = New List(Of String)()

                        While server.IsConnected
                            Dim result As String = reader.ReadLine()
                            If Not String.IsNullOrEmpty(result) Then arguments.Add(result)
                        End While

                        ThreadPool.QueueUserWorkItem(AddressOf CallOnArgumentsReceived, arguments.ToArray())
                    End Using
                End Using

            Catch __unusedIOException1__ As IOException
            Finally
                ListenForArguments(Nothing)
            End Try
        End If
    End Sub

    Private Sub CallOnArgumentsReceived(ByVal state As Object)
        OnArgumentsReceived(CType(state, String()))
    End Sub

    Private Shared _lock As Object = New Object()

    Public Event ArgumentsReceived As EventHandler(Of ArgumentsReceivedEventArgs)

    Private _ArgumentsReceived As EventHandler(Of ArgumentsReceivedEventArgs)

    'Public Event ArgumentsReceived As EventHandler(Of ArgumentsReceivedEventArgs)
    'AddHandler(ByVal value As EventHandler(Of ArgumentsReceivedEventArgs))

    'SyncLock _lock

    'If _OwnsMutex Then
    '                    _ArgumentsReceived += value
    '                End If
    'End SyncLock
    'End AddHandler
    'RemoveHandler(ByVal value As EventHandler(Of ArgumentsReceivedEventArgs))

    'SyncLock _lock
    '                _ArgumentsReceived -= value
    '            End SyncLock
    'End RemoveHandler
    'End Event

    Private Sub OnArgumentsReceived(ByVal arguments As String())
        Dim lstArguements As New List(Of String)

        SyncLock _lock

            If _OwnsMutex Then
                RaiseEvent ArgumentsReceived(Me, New ArgumentsReceivedEventArgs With {
                    .args = arguments
                })
            End If
        End SyncLock


    End Sub

    Private disposed As Boolean

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not disposed Then

            If _Mutex IsNot Nothing AndAlso _OwnsMutex Then
                _Mutex.ReleaseMutex()
                _Mutex = Nothing
            End If

            disposed = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    Public Sub PassArgumentsToFirstInstance()
        PassArgumentsToFirstInstance(Arguments)
    End Sub

    Private Shared Function FilterAndAppendSlash(ByVal args As IEnumerable(Of String)) As String()
        Dim listOfArgs = New List(Of String)()
        If args Is Nothing Then Return listOfArgs.ToArray()

        For Each argument In args

            If Not String.IsNullOrEmpty(argument) Then

                If Regex.IsMatch(argument, "[\w-]{3,}://") Then
                    listOfArgs.Add(argument)
                Else
                    Dim arg = argument
                    If Not arg.StartsWith("/", StringComparison.InvariantCultureIgnoreCase) Then arg = "/" & arg
                    listOfArgs.Add(arg)
                End If
            End If
        Next

        Return listOfArgs.ToArray()
    End Function


    Public Shared ReadOnly Property Arguments As String()
        Get

            If ApplicationDeployment.IsNetworkDeployed AndAlso AppDomain.CurrentDomain.SetupInformation.ActivationArguments IsNot Nothing Then
                Dim args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData
                If args IsNot Nothing AndAlso args.Length >= 1 Then args = args.Except({ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString()}).ToArray()
                Return FilterAndAppendSlash(args)
            End If

            Dim environmentArgs = Environment.GetCommandLineArgs()

            If environmentArgs.Length >= 2 Then
                Return FilterAndAppendSlash(environmentArgs.Skip(1))
            End If

            Return New String(-1) {}
        End Get
    End Property

    Public Sub HandleApplicationArguments(ByVal Arguments As String, ByVal Application As XafApplication)
        Dim uri As New Uri(Arguments)
        Dim strViewObjectQuery As String = uri.Query
        Dim dctDictionary = Web.HttpUtility.ParseQueryString(strViewObjectQuery)
        Dim svsShortcut As New ViewShortcut
        svsShortcut.ViewId = dctDictionary("id")
        svsShortcut.ObjectKey = dctDictionary("objectkey")

        MutexViewHandlerController.AddShortcutToQueue(svsShortcut)
    End Sub

End Class

Public Class ArgumentsReceivedEventArgs
    Inherits EventArgs

    Public Property args As String()
End Class
