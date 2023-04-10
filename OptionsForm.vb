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

Imports Microsoft.Win32

'Screen responsible for reading and writing common user settings.  
Public Class OptionsForm
    Private GotData As Boolean = False
    Private strTemplate As String = ""
    Private TemplateCount As Int16 = 12

    Public Function GetDoLine() As Boolean
        Return rdLine.Checked Or rdLineCircle.Checked
    End Function


    Public Function GetDoCircle() As Boolean
        Return rdCircle.Checked Or rdLineCircle.Checked
    End Function


    Public Function GetLineThickness() As Int16
        Return ticLineThickness.Value
    End Function


    Public Function GetMinRadSize() As Int16
        Return ticMinRadSize.Value
    End Function


    Public Function GetMaxRadSize() As Int16
        Return ticMaxRadSize.Value
    End Function


    Public Function GetIsColorRefresh() As Boolean
        Return (Not rdNoChangeRefresh.Checked And rdNoChangeRefresh.Enabled)
    End Function


    Public Function GetIsColorRandRefresh() As Boolean
        Return rdRandChangeRefresh.Checked
    End Function


    Public Function GetIsColorBump() As Boolean
        Return (Not rdNoChangeBump.Checked And rdNoChangeBump.Enabled)
    End Function


    Public Function GetIsColorRandBump() As Boolean
        Return rdRandChangeBump.Checked
    End Function


    Public Function GetColorChange() As Int16
        Return ticColorChange.Value
    End Function


    Public Function GetRefreshRate() As Int16
        Return ticRefreshRate.Value
    End Function


    Public Function GetNumItems() As Int16
        Return ticNumItems.Value
    End Function


    Public Function GetLineBouncyTail() As Boolean
        Return rdBouncyLineTail.Checked
    End Function


    Public Function GetLineTailLength() As Int16
        If rdLineTailLength.Checked Then
            Return ticLineTailLength.Value
        Else
            Return 0
        End If
    End Function


    Public Function GetCirBouncyTail() As Boolean
        Return rdBouncyCirTail.Checked
    End Function


    Public Function GetCirTailLength() As Int16
        If rdCirTailLength.Checked Then
            Return ticCirTailLength.Value
        Else
            Return 0
        End If
    End Function

    Private Function GetTemplate(ByVal TemplateIndex As Int16, Optional ByVal SetTemplate As Boolean = False) As String
        Select Case TemplateIndex
            Case 0
                Return "Select Template"
            Case 1
                Return "----------"
            Case 2
                If SetTemplate Then TemplateAnts()
                Return "Ants"
            Case 3
                If SetTemplate Then TemplateBigBubbles()
                Return "Big Bubbles"
            Case 4
                If SetTemplate Then TemplateBlizzard()
                Return "Blizzard"
            Case 5
                If SetTemplate Then TemplateBubbles()
                Return "Bubbles"
            Case 6
                If SetTemplate Then TemplateChaotic()
                Return "Chaotic"
            Case 7
                If SetTemplate Then TemplateCirclesTail()
                Return "CirclesTail"
            Case 8
                If SetTemplate Then TemplateMystify()
                Return "Mystify"
            Case 9
                If SetTemplate Then TemplatePipes()
                Return "Pipes"
            Case 10
                If SetTemplate Then TemplateTails()
                Return "Tails"
            Case 11
                If SetTemplate Then TemplateTunnelTail()
                Return "TunnelTail"
            Case 12
                If SetTemplate Then TemplateWorms()
                Return "Worms"
            Case Else
                Return ""
        End Select
    End Function


    Private Sub OptionsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Int16
        For x = 0 To TemplateCount
            lstTemplate.Items.Insert(x, GetTemplate(x))
        Next
        lstTemplate.Text = GetTemplate(0)
        GetOptions()
        GotData = True
        applyButton.Enabled = False
        cmdSet.Enabled = False
        cmdDelete.Enabled = False
        cmdSaveAs.Enabled = False
    End Sub


    Private Sub SetDisabledItems()
        applyButton.Enabled = True
        cmdSet.Enabled = False
        If lstTemplate.IsHandleCreated Then If lstTemplate.Items.Count > 1 Then lstTemplate.SelectedIndex = 0 : strTemplate = ""
        If rdCircle.Checked Then
            gbLineTailConfig.Enabled = False
            rdBouncyLineTail.Enabled = False
            rdLineTailLength.Enabled = False
        Else
            gbLineTailConfig.Enabled = True
            rdBouncyLineTail.Enabled = True
            rdLineTailLength.Enabled = True
        End If
        If rdLine.Checked Then
            gbCircleTailConfig.Enabled = False
            rdBouncyCirTail.Enabled = False
            rdCirTailLength.Enabled = False
        Else
            gbCircleTailConfig.Enabled = True
            rdBouncyCirTail.Enabled = True
            rdCirTailLength.Enabled = True
        End If
        If rdRandChangeRefresh.Checked Then
            gbChangeOnBump.Enabled = False
            rdNoChangeBump.Enabled = False
            rdGradChangeBump.Enabled = False
            rdRandChangeBump.Enabled = False
        Else
            gbChangeOnBump.Enabled = True
            rdNoChangeBump.Enabled = True
            rdGradChangeBump.Enabled = True
            rdRandChangeBump.Enabled = True
        End If
        If (rdGradChangeRefresh.Checked And rdGradChangeRefresh.Enabled) Or _
                (rdGradChangeBump.Checked And rdGradChangeBump.Enabled) Then
            lblColorChange.Enabled = True
            ticColorChange.Enabled = True
        Else
            lblColorChange.Enabled = False
            ticColorChange.Enabled = False
        End If
        If rdLineTailLength.Checked And rdLineTailLength.Enabled And Not rdCircle.Checked Then
            ticLineTailLength.Enabled = True
        Else
            ticLineTailLength.Enabled = False
        End If
        If rdCirTailLength.Checked And rdCirTailLength.Enabled And Not rdLine.Checked Then
            ticCirTailLength.Enabled = True
        Else
            ticCirTailLength.Enabled = False
        End If
    End Sub


    Public Sub GetOptions()
        'Load options from the current settings
        If Not GotData Then
            Try
                Dim regKey As RegistryKey
                Dim x As Int32
                regKey = Registry.CurrentUser.OpenSubKey("Software\Circle'sTail", True)
                Try 'Get NumItem
                    ticNumItems.Value = Str(regKey.GetValue("NumItems"))
                Catch
                    'Do nothing
                End Try
                Try 'Get DisplayLineCircle
                    x = regKey.GetValue("DisplayLineCircle")
                    If x = 1 Then
                        rdLineCircle.Checked = True
                    ElseIf x = 2 Then
                        rdLine.Checked = True
                    ElseIf x = 3 Then
                        rdCircle.Checked = True
                    End If
                Catch
                    'Do nothing
                End Try
                Try 'Get LineConfig
                    x = regKey.GetValue("LineConfig")
                    If x = 1 Then
                        rdBouncyLineTail.Checked = True
                    ElseIf x = 2 Then
                        ticLineNotRegrow.Checked = True
                    ElseIf x = 3 Then
                        rdLineTailLength.Checked = True
                    End If
                Catch
                    'Do nothing
                End Try
                Try 'Get LineNum
                    ticLineTailLength.Value = Str(regKey.GetValue("LineNum"))
                Catch
                    'Do nothing
                End Try
                Try 'Get CircleConfig
                    x = regKey.GetValue("CircleConfig")
                    If x = 1 Then
                        rdBouncyCirTail.Checked = True
                    ElseIf x = 2 Then
                        ticCirNotRegrow.Checked = True
                    ElseIf x = 3 Then
                        rdCirTailLength.Checked = True
                    End If
                Catch
                    'Do nothing
                End Try
                Try 'Get CircleNum
                    ticCirTailLength.Value = regKey.GetValue("CircleNum")
                Catch
                    'Do nothing
                End Try
                Try 'Get ColorOnRefresh
                    x = regKey.GetValue("ColorOnRefresh")
                    If x = 1 Then
                        rdNoChangeRefresh.Checked = True
                    ElseIf x = 2 Then
                        rdGradChangeRefresh.Checked = True
                    ElseIf x = 3 Then
                        rdRandChangeRefresh.Checked = True
                    End If
                Catch
                    'Do nothing
                End Try
                Try 'Get ColorOnBump
                    x = regKey.GetValue("ColorOnBump")
                    If x = 1 Then
                        rdNoChangeBump.Checked = True
                    ElseIf x = 2 Then
                        rdGradChangeBump.Checked = True
                    ElseIf x = 3 Then
                        rdRandChangeBump.Checked = True
                    End If
                Catch
                    'Do nothing
                End Try
                Try 'Get ColorChangeRate
                    ticColorChange.Value = Str(regKey.GetValue("ColorChangeRate"))
                Catch
                    'Do nothing
                End Try
                Try 'Get LineThikness
                    ticLineThickness.Value = Str(regKey.GetValue("LineThickness"))
                Catch
                    'Do nothing
                End Try
                Try 'Get MaximumRadiusSize
                    ticMaxRadSize.Value = Str(regKey.GetValue("MaxumimRadiusSize"))
                Catch
                    'Do nothing
                End Try
                Try 'Get MinimumRadiusSize
                    ticMinRadSize.Value = Str(regKey.GetValue("MinumimRadiusSize"))
                    If ticMinRadSize.Value > ticMaxRadSize.Value Then ticMinRadSize.Value = ticMaxRadSize.Value
                Catch
                    'Do nothing
                End Try
                Try 'Get RefreshRate
                    ticRefreshRate.Value = Str(regKey.GetValue("RefreshRate"))
                Catch
                    'Do nothing
                End Try
                Try 'Get RefreshRate
                    strTemplate = regKey.GetValue("Template")
                    lstTemplate.Text = strTemplate
                Catch
                    'Do nothing
                End Try
                regKey.Close()
            Catch
                'MessageBox.Show("There was a problem reading in the settings for your screen saver.")
            End Try
        End If
    End Sub


    Private Function ChangesMade() As Boolean
        ChangesMade = True
    End Function

    'Updates the apply button to be active only if changes 
    'have been made since apply was last pressed
    Private Sub UpdateApply()
        If ChangesMade() Then
            applyButton.Enabled = True
        Else
            applyButton.Enabled = False
        End If
    End Sub


    'Applies all the changes since apply button was last pressed
    Private Sub ApplyChanges()
        'My.Settings.Save()

        Dim regKey As RegistryKey
        Dim x As Int32
        regKey = Registry.CurrentUser.OpenSubKey("Software", True)
        regKey.CreateSubKey("Circle'sTail")
        regKey = Registry.CurrentUser.OpenSubKey("Software\Circle'sTail", True)
        x = Val(ticNumItems.Value)
        regKey.SetValue("NumItems", x)
        If rdLineCircle.Checked Then
            x = 1
        ElseIf rdLine.Checked Then
            x = 2
        ElseIf rdCircle.Checked Then
            x = 3
        End If
        regKey.SetValue("DisplayLineCircle", x)
        If rdBouncyLineTail.Checked Then
            x = 1
        ElseIf ticLineNotRegrow.Checked Then
            x = 2
        ElseIf rdLineTailLength.Checked Then
            x = 3
        End If
        regKey.SetValue("LineConfig", x)
        x = Val(ticLineTailLength.Value)
        regKey.SetValue("LineNum", x)
        If rdBouncyCirTail.Checked Then
            x = 1
        ElseIf ticCirNotRegrow.Checked Then
            x = 2
        ElseIf rdCirTailLength.Checked Then
            x = 3
        End If
        regKey.SetValue("CircleConfig", x)
        x = Val(ticCirTailLength.Value)
        regKey.SetValue("CircleNum", x)
        If rdNoChangeRefresh.Checked Then
            x = 1
        ElseIf rdGradChangeRefresh.Checked Then
            x = 2
        ElseIf rdRandChangeRefresh.Checked Then
            x = 3
        End If
        regKey.SetValue("ColorOnRefresh", x)
        If rdNoChangeBump.Checked Then
            x = 1
        ElseIf rdGradChangeBump.Checked Then
            x = 2
        ElseIf rdRandChangeBump.Checked Then
            x = 3
        End If
        regKey.SetValue("ColorOnBump", x)
        x = Val(ticColorChange.Value)
        regKey.SetValue("ColorChangeRate", x)
        x = Val(ticLineThickness.Value)
        regKey.SetValue("LineThickness", x)
        x = Val(ticMinRadSize.Value)
        regKey.SetValue("MinumimRadiusSize", x)
        x = Val(ticMaxRadSize.Value)
        regKey.SetValue("MaxumimRadiusSize", x)
        x = Val(ticRefreshRate.Value)
        regKey.SetValue("RefreshRate", x)
        regKey.SetValue("Template", strTemplate)
        regKey.Close()
    End Sub


    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Try
            If applyButton.Enabled Then ApplyChanges()
        Catch ex As Exception
            MessageBox.Show("Your settings couldn't be saved.  Make sure that you have a .config file in the same directory as your screensaver.", "Failed to Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Close()
        End Try
    End Sub


    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelButton1.Click
        Close()
    End Sub


    Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles applyButton.Click
        ApplyChanges()
        applyButton.Enabled = False
    End Sub


    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        My.Application.StartScreenSaver()
    End Sub

    Private Sub rdLineCircle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLineCircle.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdCircle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCircle.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLine.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub ticNumItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticNumItems.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticNumItems_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticNumItems.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub ticLineTailLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticLineTailLength.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticLineTailLength_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticLineTailLength.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub ticCirTailLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticCirTailLength.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticCirTailLength_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticCirTailLength.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub rdNoChangeRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNoChangeRefresh.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdGradChangeRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGradChangeRefresh.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdRandChangeRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdRandChangeRefresh.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdNoChangeBump_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNoChangeBump.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdGradChangeBump_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGradChangeBump.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdRandChangeBump_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdRandChangeBump.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub ticColorChange_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticColorChange.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticColorChange_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticColorChange.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub ticLineThickness_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticLineThickness.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticLineThickness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticLineThickness.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub ticMinRadSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticMinRadSize.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticMinRadSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticMinRadSize.ValueChanged
        If ticMinRadSize.Value > ticMaxRadSize.Value Then ticMinRadSize.Value = ticMaxRadSize.Value
        SetDisabledItems()
    End Sub

    Private Sub ticMaxRadSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticMaxRadSize.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticMaxRadSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticMaxRadSize.ValueChanged
        If ticMinRadSize.Value > ticMaxRadSize.Value Then ticMaxRadSize.Value = ticMinRadSize.Value
        SetDisabledItems()
    End Sub

    Private Sub ticRefreshRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ticRefreshRate.KeyPress
        SetDisabledItems()
    End Sub

    Private Sub ticRefreshRate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticRefreshRate.ValueChanged
        SetDisabledItems()
    End Sub

    Private Sub ticLineNotRegrow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticLineNotRegrow.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdLineTailLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLineTailLength.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdBouncyCirTail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdBouncyCirTail.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub ticCirNotRegrow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticCirNotRegrow.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub rdCirTailLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCirTailLength.CheckedChanged
        SetDisabledItems()
    End Sub

    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click
        Dim x As Int16 = lstTemplate.SelectedIndex
        strTemplate = GetTemplate(lstTemplate.SelectedIndex, True)
        lstTemplate.SelectedIndex = x
        cmdSet.Enabled = False
    End Sub

    Private Sub TemplateAnts()
        ticNumItems.Value = 100
        'rdLineCircle.Checked = True
        rdLine.Checked = True
        'rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        rdLineTailLength.Checked = True
        ticLineTailLength.Value = 6
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        'rdCirTailLength.Checked = True
        'ticCirTailLength.Value = 14
        'rdNoChangeRefresh.Checked = True
        'rdGradChangeRefresh.Checked = True
        rdRandChangeRefresh.Checked = True
        'rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        'ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMinRadSize.Value = 4
        ticMaxRadSize.Value = 4
        ticRefreshRate.Value = 30
    End Sub

    Private Sub TemplateBigBubbles()
        ticNumItems.Value = 20
        'rdLineCircle.Checked = True
        'rdLine.Checked = True
        rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 6
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 1
        rdNoChangeRefresh.Checked = True
        'rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        'rdNoChangeBump.Checked = True
        rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 5
        ticLineThickness.Value = 15
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 40
        ticRefreshRate.Value = 40
    End Sub

    Private Sub TemplateBlizzard()
        ticNumItems.Value = 200
        'rdLineCircle.Checked = True
        'rdLine.Checked = True
        rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 6
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 1
        rdNoChangeRefresh.Checked = True
        'rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        'ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMinRadSize.Value = 4
        ticMaxRadSize.Value = 4
        ticRefreshRate.Value = 10
    End Sub

    Private Sub TemplateBubbles()
        ticNumItems.Value = 100
        'rdLineCircle.Checked = True
        'rdLine.Checked = True
        rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 6
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 1
        rdNoChangeRefresh.Checked = True
        'rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        'rdNoChangeBump.Checked = True
        rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 40
        ticRefreshRate.Value = 40
    End Sub

    Private Sub TemplateChaotic()
        ticNumItems.Value = 999
        'rdLineCircle.Checked = True
        rdLine.Checked = True
        'rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        rdLineTailLength.Checked = True
        ticLineTailLength.Value = 12
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        'rdCirTailLength.Checked = True
        'ticCirTailLength.Value = 1
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 20
        ticLineThickness.Value = 1
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 10
        ticRefreshRate.Value = 10
    End Sub

    Private Sub TemplateCirclesTail()
        ticNumItems.Value = 1
        rdLineCircle.Checked = True
        'rdLine.Checked = True
        'rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 6
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 1
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 15
        ticRefreshRate.Value = 40
    End Sub

    Private Sub TemplateMystify()
        ticNumItems.Value = 1
        'rdLineCircle.Checked = True
        rdLine.Checked = True
        'rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        rdLineTailLength.Checked = True
        ticLineTailLength.Value = 150
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        'rdCirTailLength.Checked = True
        'ticCirTailLength.Value = 1
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 20
        ticLineThickness.Value = 1
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 200
        ticRefreshRate.Value = 40
    End Sub

    Private Sub TemplatePipes()
        ticNumItems.Value = 1
        'rdLineCircle.Checked = True
        'rdLine.Checked = True
        rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 150
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 100
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 2
        ticLineThickness.Value = 15
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 120
        ticMaxRadSize.Value = 120
        ticRefreshRate.Value = 20
    End Sub

    Private Sub TemplateTails()
        ticNumItems.Value = 100
        rdLineCircle.Checked = True
        'rdLine.Checked = True
        'rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        rdLineTailLength.Checked = True
        ticLineTailLength.Value = 12
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 1
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMinRadSize.Value = 4
        ticMaxRadSize.Value = 4
        ticRefreshRate.Value = 30
    End Sub

    Private Sub TemplateTunnelTail()
        ticNumItems.Value = 1
        rdLineCircle.Checked = True
        'rdLine.Checked = True
        'rdCircle.Checked = True
        rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 12
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 40
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        'rdRandChangeBump.Checked = True
        ticColorChange.Value = 2
        ticLineThickness.Value = 2
        ticMaxRadSize.Value = 2400
        ticMinRadSize.Value = 15
        ticRefreshRate.Value = 40
    End Sub

    Private Sub TemplateWorms()
        ticNumItems.Value = 45
        'rdLineCircle.Checked = True
        'rdLine.Checked = True
        rdCircle.Checked = True
        'rdBouncyLineTail.Checked = True
        'ticLineNotRegrow.Checked = True
        'rdLineTailLength.Checked = True
        'ticLineTailLength.Value = 1
        'rdBouncyCirTail.Checked = True
        'ticCirNotRegrow.Checked = True
        rdCirTailLength.Checked = True
        ticCirTailLength.Value = 14
        'rdNoChangeRefresh.Checked = True
        rdGradChangeRefresh.Checked = True
        'rdRandChangeRefresh.Checked = True
        'rdNoChangeBump.Checked = True
        'rdGradChangeBump.Checked = True
        rdRandChangeBump.Checked = True
        ticColorChange.Value = 5
        ticLineThickness.Value = 1
        ticMinRadSize.Value = 4
        ticMaxRadSize.Value = 4
        ticRefreshRate.Value = 10
    End Sub

    Private Sub lstTemplate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTemplate.SelectedIndexChanged
        'SetDisabledItems()
        If lstTemplate.SelectedIndex > 1 Then
            cmdSet.Enabled = True
        Else
            cmdSet.Enabled = False
            lstTemplate.SelectedIndex = 0
        End If
    End Sub
End Class