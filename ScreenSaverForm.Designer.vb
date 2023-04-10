<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScreenSaverForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScreenSaverForm))
        Me.backgroundChangeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'backgroundChangeTimer
        '
        Me.backgroundChangeTimer.Enabled = True
        Me.backgroundChangeTimer.Interval = 10000
        '
        'ScreenSaverForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(472, 459)
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScreenSaverForm"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents backgroundChangeTimer As System.Windows.Forms.Timer
    'Friend WithEvents label1 As System.Windows.Forms.Label

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
