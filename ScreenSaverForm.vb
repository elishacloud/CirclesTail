'Copyright (C) 2023 Elisha Riedlinger
'
'This software is  provided 'as-is', without any express  or implied  warranty. In no event will the
'authors be held liable for any damages arising from the use of this software.
'Permission  is granted  to anyone  to use  this software  for  any  purpose,  including  commercial
'applications, and to alter it and redistribute it freely, subject to the following restrictions:
'
'  1. The origin of this software must not be misrepresented; you must not claim that you  wrote the
'     original  software. If you use this  software  in a product, an  acknowledgment in the product
'     documentation would be appreciated but is not required.
'  2. Altered source versions must  be plainly  marked as such, and  must not be  misrepresented  as
'     being the original software.
'  3. This notice may not be removed or altered from any source distribution.

Imports System.Math

'Screen responsible for rendering the primary visual content of the screen saver.
'The form is entirely custom drawn using GDI+ graphics objects.  To alter display, 
'modify graphics code or host new UI controls on the form.
Public Class ScreenSaverForm

    Private Declare Function GetClientRect Lib "user32" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewInteger As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function SetParent Lib "user32" (ByVal hWndChild As Integer, ByVal hWndNewParent As Integer) As Integer
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    Private Class Win32Corners
        Public WS_CHILD As Object = &H40000000
        Public GWL_STYLE As Object = (-16)
        Public GWL_HWNDPARENT As Object = (-8)
        Public HWND_TOP As Object = 0&
        Public SWP_NOZORDER As Object = &H4
        Public SWP_NOACTIVATE As Object = &H10
        Public SWP_SHOWWINDOW As Object = &H40
    End Class

    'Declare Structures
    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Structure XY
        Public X As Int16
        Public Y As Int16
    End Structure

    Private Structure CIRTYPE
        Public COORD As XY
        Public RADIUS As Int16
    End Structure

    Private Structure CURTYPE
        Public CIR As CIRTYPE
        Public CIRSTEP As CIRTYPE
        Public CirNum() As CIRTYPE
        Public CirNumCol() As System.Drawing.Pen
        Public LineCOORD() As XY
        Public LINESTEP() As XY
        Public LineNum(,) As XY
        Public LineNumCol() As System.Drawing.Pen
        Public LastLineErase As Integer
        Public LastCirErase As Integer
        Public COL As System.Drawing.Pen
        Public RedHue, BlueHue, GreenHue As Int16
        Public RedStep, BlueStep, GreenStep As Int16
    End Structure

    Private SetupNewTimer As ExecuteTimer
    Private WithEvents NewFadeTimer As Timer

    Private isActive As Boolean = False  'Keep track of whether the screensaver has become active.
    Private mouseLocation As Point  'Keep track of the location of the mouse

    Private ePage As PaintEventArgs
    Private OldCircle As CIRTYPE
    Private c() As CURTYPE
    Private ZXY As XY
    Private isPreview As Boolean = False
    Private DoCircleDraw, DoLineDraw As Boolean
    Private IsConstLineLength, IsConstCirLength As Boolean
    Private IsBegin, IsDebug, LineBouncyTail, CirBouncyTail, GotBumped As Boolean
    Private IsColorRefresh, IsColorRandRefresh, IsColorBump, IsColorRandBump As Boolean
    Private t, x, z As Int16
    Private RedHue, BlueHue, GreenHue, HueMaxStep As Int16
    Private RedStep, BlueStep, GreenStep As Int16
    Private LineNum As Int16
    Private Temp, Temp1, Temp2, counter As Int16
    Private LineThinkness, LineDraw, StrLine As Int16
    Private ScreenWidth, ScreenHeight, MaxTotalLine, MaxTotalCir As Int16
    Private MinRadSize, MaxRadSize, MaxNumItems, NumItems, n As Int16
    Private CirNum, CirDraw As Int16
    Private InitItemCount, MaxMoveStepSize, MaxRadStepSize As Int16
    Private MakeBig As Int64 = 0
    Public ScreenNum As Int16 = 0


    Private Sub InitVars()
        'Init vars
        IsBegin = True
        ScreenWidth = Me.Width
        ScreenHeight = Me.Height
        LineNum = 1
        CirNum = 1
        InitItemCount = 0
        ZXY.X = 0
        ZXY.Y = 0
        If isPreview Then
            MaxMoveStepSize = 2
            MaxRadStepSize = 2
        Else
            MaxMoveStepSize = 7
            MaxRadStepSize = 7
        End If

        'Enable Debug
        IsDebug = False

        'User changable vars ****
        OptionsForm.GetOptions()
        'Get minumim raduis size
        MinRadSize = OptionsForm.GetMinRadSize
        If isPreview Then MinRadSize = Round(MinRadSize \ 10) 'For preview page
        If MinRadSize > ScreenHeight \ 4 Then MinRadSize = ScreenHeight \ 4 'Makes sure radius is not too big
        If MinRadSize < 4 Then MinRadSize = 4 'Makes sure that radius is never too small
        'Get maxumim raduis size
        MaxRadSize = OptionsForm.GetMaxRadSize
        If isPreview Then MaxRadSize = Round(MaxRadSize \ 10) 'For preview page
        If MinRadSize > MaxRadSize Then MaxRadSize = MinRadSize
        If (MaxRadSize - MinRadSize) \ 2 < MaxRadStepSize Then MaxRadStepSize = (MaxRadSize - MinRadSize) \ 2
        'Get line thickness
        LineThinkness = OptionsForm.GetLineThickness
        If isPreview Then LineThinkness = Round(Sqrt(LineThinkness)) 'For preview page
        If LineThinkness > ScreenHeight \ 10 Then LineThinkness = ScreenHeight \ 10 'Makes sure line thickness is not too big
        'Get max number of items
        MaxNumItems = ((MakeBig + ScreenHeight) * ScreenWidth) \ ((ScreenHeight + ScreenWidth) + ((MinRadSize ^ 2) * 2 + (LineThinkness ^ 2) * 3) * 6)
        'Get number of items
        NumItems = OptionsForm.GetNumItems
        If NumItems = 0 Then NumItems = Rand(MaxNumItems - 1) + 1
        If NumItems > MaxNumItems Then NumItems = MaxNumItems
        'Get line type and number
        DoLineDraw = OptionsForm.GetDoLine()
        LineBouncyTail = OptionsForm.GetLineBouncyTail
        MaxTotalLine = OptionsForm.GetLineTailLength
        IsConstLineLength = (MaxTotalLine <> 0)
        If Not DoLineDraw Then
            MaxTotalLine = 1
        ElseIf Not IsConstLineLength Then
            MaxTotalLine = ScreenHeight \ 2 + 1
        ElseIf isPreview And MaxTotalLine > 5 Then
            MaxTotalLine = MaxTotalLine \ 5 + 5
        End If
        'Get circle type and number
        DoCircleDraw = OptionsForm.GetDoCircle()
        CirBouncyTail = OptionsForm.GetCirBouncyTail
        MaxTotalCir = OptionsForm.GetCirTailLength
        IsConstCirLength = (MaxTotalCir <> 0)
        If Not DoCircleDraw Then
            MaxTotalCir = 1
        ElseIf Not IsConstCirLength Then
            MaxTotalCir = ScreenHeight \ 2 + 1
        ElseIf isPreview And MaxTotalCir > 5 Then
            MaxTotalCir = MaxTotalCir \ 5 + 5
        End If
        'Get color user changable vars
        IsColorRefresh = OptionsForm.GetIsColorRefresh
        IsColorRandRefresh = OptionsForm.GetIsColorRandRefresh
        IsColorBump = OptionsForm.GetIsColorBump
        IsColorRandBump = OptionsForm.GetIsColorRandBump
        HueMaxStep = OptionsForm.GetColorChange

        'init number of items array
        ReDim c(NumItems)

        'Run timer
        SetupNewTimer = New ExecuteTimer
        SetupNewTimer.FadeTimer.Interval = OptionsForm.GetRefreshRate
        NewFadeTimer = SetupNewTimer.FadeTimer
    End Sub


    Private Sub InitItems(ByVal elem As Integer)
        'init new circle item
        c(elem).CIR.RADIUS = MinRadSize
        counter = 0
        While CheckStep(elem)
            c(elem).CIR.COORD.X = Rand(ScreenWidth)
            c(elem).CIR.COORD.Y = Rand(ScreenHeight)
            c(elem).CIRSTEP.RADIUS = RadiusStep()
            c(elem).CIRSTEP.COORD.X = XSTEP()
            c(elem).CIRSTEP.COORD.Y = YSTEP()
            counter = counter + 1
            If counter > 5 Then
                Exit Sub
            End If
        End While

        'init new color
        c(elem).RedHue = Rand(240) + 1
        c(elem).BlueHue = Rand(240) + 1
        c(elem).GreenHue = Rand(240) + 1
        c(elem).RedStep = (Rand(HueMaxStep) + 1) * PosNeg()
        c(elem).BlueStep = (Rand(HueMaxStep) + 1) * PosNeg()
        c(elem).GreenStep = (Rand(HueMaxStep) + 1) * PosNeg()
        RandColor(c(elem).COL)

        'Init circle array
        ReDim c(elem).CirNum(MaxTotalCir), c(elem).CirNumCol(MaxTotalCir)
        For Temp = 0 To MaxTotalCir
            c(elem).CirNum(Temp) = c(elem).CIR
            c(elem).CirNumCol(Temp) = c(elem).COL
        Next

        'Init circle coordinents
        ReDim c(elem).LineCOORD(2)
        c(elem).LineCOORD(1) = c(elem).CIR.COORD
        c(elem).LineCOORD(2) = c(elem).CIR.COORD
        c(elem).LastCirErase = 0

        'Init line array
        ReDim c(elem).LineNum(MaxTotalLine, 2), c(elem).LineNumCol(MaxTotalLine)
        For Temp = 0 To MaxTotalLine
            For x = 1 To 2
                c(elem).LineNum(Temp, x) = ZXY
            Next
            c(elem).LineNumCol(Temp) = c(elem).COL
        Next

        'Init line step
        ReDim c(elem).LINESTEP(2)
        c(elem).LINESTEP(1).X = 10000
        c(elem).LINESTEP(1).Y = 10000
        c(elem).LINESTEP(2) = c(elem).LINESTEP(1)
        c(elem).LastLineErase = 0
        InitItemCount = n
    End Sub


    'Set up the main form as a full screen screensaver.
    Private Sub SetupScreenSaver()
        ' Use double buffering to improve drawing performance
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

        ' Set the application to full screen mode and hide the mouse
        If Not isPreview Then Cursor.Hide()
        Bounds = Screen.AllScreens(ScreenNum).Bounds
        WindowState = FormWindowState.Maximized
        ShowInTaskbar = False
        DoubleBuffered = True
        BackgroundImageLayout = ImageLayout.Stretch
    End Sub


    Public Sub SetForm(ByRef f As Form, ByRef arg As String)
        Dim style As Integer
        Dim previewHandle As Integer = Int32.Parse(CType(arg, String))
        Dim corners As New Win32Corners
        Dim r As New RECT

        If previewHandle > 0 Then
            isPreview = True
            GetClientRect(previewHandle, r)
            With f
                .WindowState = FormWindowState.Normal
                .FormBorderStyle = FormBorderStyle.None
                .Width = r.right - r.left
                .Height = r.bottom - r.top
            End With

            style = GetWindowLong(f.Handle.ToInt32, corners.GWL_STYLE)
            style = style Or corners.WS_CHILD
            SetWindowLong(f.Handle.ToInt32, corners.GWL_STYLE, style)
            SetParent(f.Handle.ToInt32, previewHandle)
            SetWindowLong(f.Handle.ToInt32, corners.GWL_HWNDPARENT, previewHandle)
            SetWindowPos(f.Handle.ToInt32, 0, r.left, r.top, r.right, r.bottom, corners.SWP_NOACTIVATE Or corners.SWP_NOZORDER Or corners.SWP_SHOWWINDOW)
        End If
    End Sub


    'Close program if key is pressed
    Private Sub ScreenSaverForm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        ' Set IsActive and MouseLocation only the first time this event is called.
        If Not isPreview Then
            If Not isActive Then
                mouseLocation = MousePosition
                isActive = True
            Else
                ' If the mouse has moved significantly since first call, close.
                If Math.Abs(MousePosition.X - mouseLocation.X) > 10 OrElse Math.Abs(MousePosition.Y - mouseLocation.Y) > 10 Then
                    DoQuit()
                End If
            End If
        End If
    End Sub


    'Update screen on new timer
    Private Sub FadeTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewFadeTimer.Tick
        If IsBegin Then
            Me.Refresh()
            IsBegin = False
        Else
            Me.Invalidate()
        End If
    End Sub


    'Close program if key is pressed
    Private Sub ScreenSaverForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If Not isPreview Then DoQuit()
    End Sub


    'Close program if key is pressed
    Private Sub ScreenSaverForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If Not isPreview Then DoQuit()
    End Sub


    Private Sub backgroundChangeTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles backgroundChangeTimer.Tick
        'Do nothing
    End Sub


    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        'Do nothing
    End Sub


    Public Sub DoQuit(Optional ByVal flag = True)
        Cursor.Show()
        IsBegin = False
        If flag Then My.Application.StopScreenSaver()
        Close()
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ePage = e     'Set graphics var globally
        If isPreview Then ePage.Graphics.Clear(Color.Black)
        DrawGraphs() 'Draw graphs
    End Sub


    'Draw debug line
    Private Sub DrawStrNL(ByRef S$)
        If IsDebug Then
            ePage.Graphics.DrawString(S$, Font, Brushes.Azure, n * 40, StrLine * 15)
            StrLine = StrLine + 1
        End If
    End Sub


    'Debug lines
    Private Sub pt(ByRef Where$)
        If IsDebug Then
            StrLine = 1
            ePage.Graphics.Clear(Color.Black)
            DrawStrNL(Where$)
            DrawStrNL("CirX:      " & c(n).CIR.COORD.X)
            DrawStrNL("CirY:      " & c(n).CIR.COORD.Y)
            DrawStrNL("CirRadius: " & c(n).CIR.RADIUS)
            DrawStrNL("CirX-Step: " & c(n).CIRSTEP.COORD.X)
            DrawStrNL("CirY-Step: " & c(n).CIRSTEP.COORD.Y)
            DrawStrNL("CirRadius-Step: " & c(n).CIRSTEP.RADIUS)
            DrawStrNL("LineCord1-x: " & c(n).LineCOORD(1).X)
            DrawStrNL("LineCord1-y: " & c(n).LineCOORD(1).Y)
            DrawStrNL("LineStep1-x: " & c(n).LINESTEP(1).X)
            DrawStrNL("LineStep1-y: " & c(n).LINESTEP(1).Y)
            DrawStrNL("LineCord2-x: " & c(n).LineCOORD(2).X)
            DrawStrNL("LineCord2-y: " & c(n).LineCOORD(2).Y)
            DrawStrNL("LineStep2-x: " & c(n).LINESTEP(2).X)
            DrawStrNL("LineStep2-y: " & c(n).LINESTEP(2).Y)
        End If
    End Sub


    Private Function Rand(ByVal X As Int16) As Int16
        Rand = Round(Rnd() * X)
    End Function


    Private Function PosNeg() As Int16
        PosNeg = Rand(1) * 2 - 1
    End Function


    Private Sub ShiftColor(ByRef NewColor As System.Drawing.Pen)
        NewColor = Nothing
        HueStep(c(n).RedHue, c(n).RedStep) : HueStep(c(n).BlueHue, c(n).BlueStep) : HueStep(c(n).GreenHue, c(n).GreenStep)
        NewColor = New Pen(Color.FromArgb(255, c(n).RedHue, c(n).GreenHue, c(n).BlueHue), LineThinkness)
    End Sub


    Private Sub RandColor(ByRef NewColor As System.Drawing.Pen)
        NewColor = Nothing
        c(n).RedHue = Rand(255) : c(n).GreenHue = Rand(255) : c(n).BlueHue = Rand(255)
        NewColor = New Pen(Color.FromArgb(255, c(n).RedHue, c(n).GreenHue, c(n).BlueHue), LineThinkness)
    End Sub


    Private Function CircleBounce(ByVal n As Int16) As Boolean
        Dim elem As Integer, b As Boolean = False

        For elem = 1 To InitItemCount
            If elem <> n Then
                If (MakeBig + c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS + LineThinkness + c(elem).CIR.RADIUS) ^ 2 > _
                        (MakeBig + c(n).CIR.COORD.X + c(n).CIRSTEP.COORD.X - c(elem).CIR.COORD.X) ^ 2 + (MakeBig + c(n).CIR.COORD.Y + c(n).CIRSTEP.COORD.Y - c(elem).CIR.COORD.Y) ^ 2 Then
                    b = True
                    Exit For
                End If
            End If
        Next
        CircleBounce = b
    End Function


    Private Function CheckStep(ByVal n As Int16) As Boolean
        CheckStep = (c(n).CIR.COORD.X + c(n).CIRSTEP.COORD.X) - (c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS) < LineThinkness Or _
                c(n).CIR.COORD.X + c(n).CIRSTEP.COORD.X + (c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS) >= ScreenWidth - LineThinkness Or _
                (c(n).CIR.COORD.Y + c(n).CIRSTEP.COORD.Y) - (c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS) < LineThinkness Or _
                c(n).CIR.COORD.Y + c(n).CIRSTEP.COORD.Y + (c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS) >= ScreenHeight - LineThinkness Or _
                c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS < MinRadSize Or CircleBounce(n) Or _
                c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS > MaxRadSize Or _
                (c(n).CIRSTEP.RADIUS = 0 And c(n).CIRSTEP.COORD.X = 0 And c(n).CIRSTEP.COORD.Y = 0)
    End Function


    Private Sub HueStep(ByRef Hue As Int16, ByRef cStep As Int16)
        While Hue + cStep < 1 Or Hue + cStep > 255
            cStep = (Rand(HueMaxStep) + 1) * PosNeg()
        End While
        Hue = Hue + cStep
    End Sub


    Private Function XSTEP() As Int16
        XSTEP = (Rand(MaxMoveStepSize) + 1) * PosNeg()
    End Function


    Private Function YSTEP() As Int16
        YSTEP = (Rand(MaxMoveStepSize) + 1) * PosNeg()
    End Function


    Private Function RadiusStep() As Int16
        RadiusStep = Rand(MaxRadStepSize * 2) - MaxRadStepSize
    End Function


    Private Sub LineXYnum(ByVal E As Int16)
        LineXY(c(n).LineNum(E, 1), c(n).LineNum(E, 2), Pens.Black)
    End Sub


    Private Sub LineXY(ByRef w As XY, ByRef z As XY, ByRef COL As System.Drawing.Pen)
        ePage.Graphics.DrawLine(COL, w.X, w.Y, z.X, z.Y)
    End Sub


    Private Sub CIR(ByRef C As CIRTYPE, ByRef COL As System.Drawing.Pen)
        ePage.Graphics.DrawArc(COL, C.COORD.X - C.RADIUS, C.COORD.Y - C.RADIUS, C.RADIUS * 2, C.RADIUS * 2, 0, 360)
    End Sub


    Private Sub DrawGraphs()
        Randomize()
        StrLine = 1 'Debug line

        If InitItemCount < NumItems Then
            InitItems(InitItemCount + 1)
            'If Not isPreview Then ePage.Graphics.DrawString(Str(InitItemCount) & "/" & Str(NumItems), Font, Brushes.Azure, 1, 1)
        Else
            InitItemCount = NumItems
        End If

        For n = 1 To InitItemCount
            'Assign old vars
            OldCircle.RADIUS = c(n).CIR.RADIUS
            OldCircle.COORD = c(n).CIR.COORD
            GotBumped = False

            'Get new circle step
            'This will only change the step if needed
            If c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS < MinRadSize Then
                c(n).CIRSTEP.RADIUS = Abs(RadiusStep())
            ElseIf c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS > MaxRadSize Then
                c(n).CIRSTEP.RADIUS = -Abs(RadiusStep())
            End If

            'Get new circle coordinates and step
            counter = 0
            While CheckStep(n)
                c(n).CIRSTEP.RADIUS = RadiusStep()
                c(n).CIRSTEP.COORD.X = XSTEP()
                c(n).CIRSTEP.COORD.Y = YSTEP()
                GotBumped = True
                counter = counter + 1
                If counter > 20 Then
                    c(n).CIRSTEP.RADIUS = 0
                    c(n).CIRSTEP.COORD.X = 0
                    c(n).CIRSTEP.COORD.Y = 0
                    Exit While
                End If
                pt("WhileGetStep")
            End While
            c(n).CIR.RADIUS = c(n).CIR.RADIUS + c(n).CIRSTEP.RADIUS
            c(n).CIR.COORD.X = c(n).CIR.COORD.X + c(n).CIRSTEP.COORD.X
            c(n).CIR.COORD.Y = c(n).CIR.COORD.Y + c(n).CIRSTEP.COORD.Y

            'Get new line step and coordinates
            If DoLineDraw Then
                For Temp = 1 To 2
                    While Sqrt((MakeBig + c(n).LineCOORD(Temp).X + c(n).LINESTEP(Temp).X - c(n).CIR.COORD.X) ^ 2 + _
                            (MakeBig + c(n).LineCOORD(Temp).Y + c(n).LINESTEP(Temp).Y - c(n).CIR.COORD.Y) ^ 2) >= c(n).CIR.RADIUS
                        c(n).LINESTEP(Temp).X = XSTEP() + c(n).CIRSTEP.COORD.X
                        c(n).LINESTEP(Temp).Y = YSTEP() + c(n).CIRSTEP.COORD.Y
                        GotBumped = True
                        DrawStrNL("Line" & Temp)
                    End While
                    c(n).LineCOORD(Temp).X = c(n).LineCOORD(Temp).X + c(n).LINESTEP(Temp).X
                    c(n).LineCOORD(Temp).Y = c(n).LineCOORD(Temp).Y + c(n).LINESTEP(Temp).Y
                Next
            End If

            'Change color
            If GotBumped And IsColorBump Then
                'Get color on bump
                If IsColorRandBump Then
                    RandColor(c(n).COL)
                Else
                    ShiftColor(c(n).COL)
                End If
                'Change color on refresh
            ElseIf IsColorRefresh Then
                If IsColorRandRefresh Then
                    RandColor(c(n).COL)
                Else
                    ShiftColor(c(n).COL)
                End If
            End If
            If IsColorRefresh Or IsColorBump Then
                If DoLineDraw Then
                    c(n).LineNumCol(LineNum) = Nothing
                    c(n).LineNumCol(LineNum) = c(n).COL
                End If
                If DoCircleDraw Then
                    c(n).CirNumCol(CirNum) = Nothing
                    c(n).CirNumCol(CirNum) = c(n).COL
                End If
            End If
        Next

        'Draw lines
        If DoLineDraw Then
            For n = 1 To InitItemCount
                'Remove old line
                'LineXYnum(OldCircle.RADIUS)
                'LineXYnum(CUR.LineNum)

                'Draw new line
                DrawStrNL("LineXY") 'Debug
                LineXY(c(n).LineCOORD(1), c(n).LineCOORD(2), c(n).COL)  'Draw new line

                'Assign LineNum
                DrawStrNL("z") ' Debug
                For z = 1 To 2
                    c(n).LineNum(LineNum, z) = c(n).LineCOORD(z)
                Next

                'Get tail end
                If IsConstLineLength Then
                    Temp1 = LineNum
                    Temp2 = LineNum + MaxTotalLine
                Else
                    If LineBouncyTail Then
                        Temp1 = LineNum - c(n).CIR.RADIUS
                        Temp2 = LineNum
                    Else
                        'Get last line of the tail
                        If (((c(n).LastLineErase < LineNum - c(n).CIR.RADIUS) Or _
                            ((c(n).LastLineErase > LineNum) And _
                            (c(n).LastLineErase < LineNum - c(n).CIR.RADIUS + MaxTotalLine) And _
                            (LineNum - c(n).CIR.RADIUS + MaxTotalLine < LineNum + MaxTotalLine)) _
                            )) Then
                            'Set new LastLine
                            c(n).LastLineErase = LineNum - c(n).CIR.RADIUS
                        End If
                        Temp1 = c(n).LastLineErase
                        If Temp1 > LineNum Then
                            Temp2 = LineNum + MaxTotalLine
                        Else
                            Temp2 = LineNum
                        End If
                    End If
                End If

                'Draw the tail
                For Temp = Temp1 To Temp2
                    DrawStrNL("LineXY " & Temp & " Start: " & Temp1 & " End: " & Temp2) 'Debug
                    LineDraw = (Temp + MaxTotalLine) Mod MaxTotalLine
                    LineXY(c(n).LineNum(LineDraw, 1), c(n).LineNum(LineDraw, 2), c(n).LineNumCol(LineDraw))
                Next
            Next

            'Update Array LineNum
            If LineNum >= MaxTotalLine - 1 Then
                LineNum = 0
            Else
                LineNum = LineNum + 1
            End If
        End If

        'Draw circle
        If DoCircleDraw Then
            For n = 1 To InitItemCount
                'Get tail end
                c(n).CirNum(CirNum) = c(n).CIR
                If IsConstCirLength Then
                    Temp1 = CirNum
                    Temp2 = CirNum + MaxTotalCir
                Else
                    If CirBouncyTail Then
                        Temp1 = CirNum - c(n).CIR.RADIUS
                        Temp2 = CirNum
                    Else
                        'Get last cir of the tail
                        If (((c(n).LastCirErase < CirNum - c(n).CIR.RADIUS) Or _
                            ((c(n).LastCirErase > CirNum) And _
                            (c(n).LastCirErase < CirNum - c(n).CIR.RADIUS + MaxTotalCir) And _
                            (CirNum - c(n).CIR.RADIUS + MaxTotalCir < CirNum + MaxTotalCir)) _
                            )) Then
                            'Set new Lastcir
                            c(n).LastCirErase = CirNum - c(n).CIR.RADIUS
                        End If
                        Temp1 = c(n).LastCirErase
                        If Temp1 > CirNum Then
                            Temp2 = CirNum + MaxTotalCir
                        Else
                            Temp2 = CirNum
                        End If
                    End If
                End If

                'Draw the tail
                For Temp = Temp1 To Temp2
                    DrawStrNL("LineXY " & Temp) 'Debug
                    CirDraw = (Temp + MaxTotalCir) Mod MaxTotalCir
                    CIR(c(n).CirNum(CirDraw), c(n).CirNumCol(CirDraw))  'Draw new circle
                Next
                'CIR(OldCircle, Pens.Black) 'Remove old crcle
                CIR(c(n).CIR, c(n).COL)  'Draw new circle
            Next

            'Update Array CirNum
            If CirNum >= MaxTotalCir - 1 Then
                CirNum = 0
            Else
                CirNum = CirNum + 1
            End If
        End If
    End Sub

    Private Sub ScreenSaverForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        SetupScreenSaver()
        InitVars()
    End Sub
End Class