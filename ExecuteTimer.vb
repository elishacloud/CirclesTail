'Encapsulates the rendering of the description of an item.
'The type of item that this ItemDescriptionView will draw.
Public Class ExecuteTimer
    Implements IDisposable

    Public Event FadingComplete As EventHandler
    Private WithEvents m_fadeTimer As Timer

    Public ReadOnly Property FadeTimer() As Timer
        Get
            Return Me.m_fadeTimer
        End Get
    End Property

    Public Sub New()
        Me.m_fadeTimer = New Timer()
        m_fadeTimer.Enabled = True
        m_fadeTimer.Start()
    End Sub 'New

    'Dispose all disposable fields
    Public Sub Dispose() Implements IDisposable.Dispose
        m_fadeTimer.Dispose()
    End Sub

End Class 'ExecuteTimer