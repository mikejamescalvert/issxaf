TODO:

Add Http Handler Prefix to Application Model

Add Option to Register Handler on Startup

How to implement:

- Set the HTTP Handler prefix in the model

- Create a link using prefix.
	Example: <httpprefix>://ViewId?RecId

Rename the Application method in the Program.vb to another name and remove the STAThread attribute, example:

Public Sub Main -> Public Sub MainApplicationSetup

Create a new Main Sub with the following code:

    <STAThread()>
    Public Shared Sub Main(ByVal arguments() As String)
        Dim strAssembly = GetType(Program).Assembly.GetName()
        Dim strMuteExName As String = strAssembly.Name + "_" + strAssembly.Version.ToString(3)
        Using mtxInstance As New ISS.HyperLinkHandler.MutexHandler(strMuteExName)
            If mtxInstance.IsFirstInstance = True Then

                AddHandler mtxInstance.ArgumentsReceived, AddressOf MuteEx_ArgumentsReceived
                mtxInstance.ListenForArgumentsFromSuccessiveInstances()
                MainApplicationSetup(arguments)
            Else
                mtxInstance.PassArgumentsToFirstInstance()
            End If
        End Using

    End Sub

Create a new event to handle the passed in arguments:

