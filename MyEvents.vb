Namespace My

    'The following events are available for MyApplication
    '
    'Startup: Raised when the application starts, before the startup form is created.
    'Shutdown: Raised after all application forms are closed.  This event is not raised if the application is terminating abnormally.
    'UnhandledException: Raised if the application encounters an unhandled exception.
    'StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    'NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Class MyApplication

        Dim TotalNumScreens As Int16 = 0
        Dim myForms() As ScreenSaverForm

#If _MyType = "WindowsForms" Then
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            TotalNumScreens = Screen.AllScreens.Length
            ReDim myForms(TotalNumScreens)
            If e.CommandLine.Count > 0 Then
                ' Get the 2 character command line argument
                Dim arg As String = e.CommandLine(0).ToLower(System.Globalization.CultureInfo.InvariantCulture).Trim().Substring(0, 2)
                Select Case arg
                    Case "/c"
                        ' Show the options dialog
                        Me.MainForm = My.Forms.OptionsForm
                    Case "/p"
                        ' Show preview
                        Try
                            ScreenSaverForm.SetForm(ScreenSaverForm, e.CommandLine(1))
                        Catch
                            MessageBox.Show("Invalid command line argument: " + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End
                        End Try
                    Case "/s"
                        My.Application.StartScreenSaver()
                    Case Else
                        MessageBox.Show("Invalid command line argument: " + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End
                End Select
            Else
                ' If no arguments were passed in, show the options page
                Me.MainForm = My.Forms.OptionsForm
            End If

        End Sub

        Public Sub StartScreenSaver()
            Dim x As Int16
            Cursor.Hide()
            For x = 0 To TotalNumScreens - 1
                If x = 0 Then
                    myForms(x) = My.Forms.ScreenSaverForm
                Else
                    myForms(x) = New ScreenSaverForm
                End If
                myForms(x).ScreenNum = x
                myForms(x).Show()
            Next
        End Sub

        Public Sub StopScreenSaver()
            Dim x As Int16
            For x = 0 To TotalNumScreens - 1
                Try
                    myForms(x).DoQuit(False)
                Catch
                    ' Form is not open
                End Try
            Next
        End Sub

        'OnInitialize is used for advanced customization of the My Application Model (MyApplication).
        'Startup code for your specific application should be placed in a Startup event handler.
        <Global.System.Diagnostics.DebuggerStepThrough()>
        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
#End If

    End Class
End Namespace
