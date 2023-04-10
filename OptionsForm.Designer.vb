<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OptionsForm
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
        Me.rssGroupBox = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ticMaxRadSize = New System.Windows.Forms.NumericUpDown
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblNumCircles = New System.Windows.Forms.Label
        Me.ticNumItems = New System.Windows.Forms.NumericUpDown
        Me.gbCircleTailConfig = New System.Windows.Forms.GroupBox
        Me.ticCirTailLength = New System.Windows.Forms.NumericUpDown
        Me.rdBouncyCirTail = New System.Windows.Forms.RadioButton
        Me.ticCirNotRegrow = New System.Windows.Forms.RadioButton
        Me.rdCirTailLength = New System.Windows.Forms.RadioButton
        Me.gbLineTailConfig = New System.Windows.Forms.GroupBox
        Me.ticLineTailLength = New System.Windows.Forms.NumericUpDown
        Me.rdBouncyLineTail = New System.Windows.Forms.RadioButton
        Me.ticLineNotRegrow = New System.Windows.Forms.RadioButton
        Me.rdLineTailLength = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdLineCircle = New System.Windows.Forms.RadioButton
        Me.rdCircle = New System.Windows.Forms.RadioButton
        Me.rdLine = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.ticRefreshRate = New System.Windows.Forms.NumericUpDown
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblColorChange = New System.Windows.Forms.Label
        Me.ticColorChange = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdNoChangeRefresh = New System.Windows.Forms.RadioButton
        Me.rdGradChangeRefresh = New System.Windows.Forms.RadioButton
        Me.rdRandChangeRefresh = New System.Windows.Forms.RadioButton
        Me.gbChangeOnBump = New System.Windows.Forms.GroupBox
        Me.rdNoChangeBump = New System.Windows.Forms.RadioButton
        Me.rdGradChangeBump = New System.Windows.Forms.RadioButton
        Me.rdRandChangeBump = New System.Windows.Forms.RadioButton
        Me.lblMinRadSize = New System.Windows.Forms.Label
        Me.lblLineThicken = New System.Windows.Forms.Label
        Me.ticMinRadSize = New System.Windows.Forms.NumericUpDown
        Me.ticLineThickness = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.okButton = New System.Windows.Forms.Button
        Me.applyButton = New System.Windows.Forms.Button
        Me.cancelButton1 = New System.Windows.Forms.Button
        Me.cmdPreview = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSet = New System.Windows.Forms.Button
        Me.cmdSaveAs = New System.Windows.Forms.Button
        Me.lstTemplate = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rssGroupBox.SuspendLayout()
        CType(Me.ticMaxRadSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.ticNumItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCircleTailConfig.SuspendLayout()
        CType(Me.ticCirTailLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLineTailConfig.SuspendLayout()
        CType(Me.ticLineTailLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ticRefreshRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ticColorChange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbChangeOnBump.SuspendLayout()
        CType(Me.ticMinRadSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ticLineThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rssGroupBox
        '
        Me.rssGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rssGroupBox.Controls.Add(Me.Label1)
        Me.rssGroupBox.Controls.Add(Me.ticMaxRadSize)
        Me.rssGroupBox.Controls.Add(Me.GroupBox5)
        Me.rssGroupBox.Controls.Add(Me.Label2)
        Me.rssGroupBox.Controls.Add(Me.ticRefreshRate)
        Me.rssGroupBox.Controls.Add(Me.GroupBox4)
        Me.rssGroupBox.Controls.Add(Me.lblMinRadSize)
        Me.rssGroupBox.Controls.Add(Me.lblLineThicken)
        Me.rssGroupBox.Controls.Add(Me.ticMinRadSize)
        Me.rssGroupBox.Controls.Add(Me.ticLineThickness)
        Me.rssGroupBox.Location = New System.Drawing.Point(3, 3)
        Me.rssGroupBox.Name = "rssGroupBox"
        Me.rssGroupBox.Size = New System.Drawing.Size(483, 379)
        Me.rssGroupBox.TabIndex = 3
        Me.rssGroupBox.TabStop = False
        Me.rssGroupBox.Text = "Options"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(236, 327)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Maximum Radius Size:"
        '
        'ticMaxRadSize
        '
        Me.ticMaxRadSize.Location = New System.Drawing.Point(402, 325)
        Me.ticMaxRadSize.Maximum = New Decimal(New Integer() {2400, 0, 0, 0})
        Me.ticMaxRadSize.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.ticMaxRadSize.Name = "ticMaxRadSize"
        Me.ticMaxRadSize.Size = New System.Drawing.Size(56, 20)
        Me.ticMaxRadSize.TabIndex = 18
        Me.ticMaxRadSize.Value = New Decimal(New Integer() {2400, 0, 0, 0})
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblNumCircles)
        Me.GroupBox5.Controls.Add(Me.ticNumItems)
        Me.GroupBox5.Controls.Add(Me.gbCircleTailConfig)
        Me.GroupBox5.Controls.Add(Me.gbLineTailConfig)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(208, 354)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Lines and circles"
        '
        'lblNumCircles
        '
        Me.lblNumCircles.AutoSize = True
        Me.lblNumCircles.Location = New System.Drawing.Point(6, 20)
        Me.lblNumCircles.Name = "lblNumCircles"
        Me.lblNumCircles.Size = New System.Drawing.Size(151, 13)
        Me.lblNumCircles.TabIndex = 21
        Me.lblNumCircles.Text = "Number of items (0 for random)"
        '
        'ticNumItems
        '
        Me.ticNumItems.Location = New System.Drawing.Point(163, 18)
        Me.ticNumItems.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.ticNumItems.Name = "ticNumItems"
        Me.ticNumItems.Size = New System.Drawing.Size(39, 20)
        Me.ticNumItems.TabIndex = 20
        Me.ticNumItems.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gbCircleTailConfig
        '
        Me.gbCircleTailConfig.Controls.Add(Me.ticCirTailLength)
        Me.gbCircleTailConfig.Controls.Add(Me.rdBouncyCirTail)
        Me.gbCircleTailConfig.Controls.Add(Me.ticCirNotRegrow)
        Me.gbCircleTailConfig.Controls.Add(Me.rdCirTailLength)
        Me.gbCircleTailConfig.Location = New System.Drawing.Point(6, 249)
        Me.gbCircleTailConfig.Name = "gbCircleTailConfig"
        Me.gbCircleTailConfig.Size = New System.Drawing.Size(197, 98)
        Me.gbCircleTailConfig.TabIndex = 19
        Me.gbCircleTailConfig.TabStop = False
        Me.gbCircleTailConfig.Text = "Circle tail configuration"
        '
        'ticCirTailLength
        '
        Me.ticCirTailLength.Location = New System.Drawing.Point(151, 65)
        Me.ticCirTailLength.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.ticCirTailLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ticCirTailLength.Name = "ticCirTailLength"
        Me.ticCirTailLength.Size = New System.Drawing.Size(39, 20)
        Me.ticCirTailLength.TabIndex = 25
        Me.ticCirTailLength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rdBouncyCirTail
        '
        Me.rdBouncyCirTail.AutoSize = True
        Me.rdBouncyCirTail.Location = New System.Drawing.Point(6, 19)
        Me.rdBouncyCirTail.Name = "rdBouncyCirTail"
        Me.rdBouncyCirTail.Size = New System.Drawing.Size(127, 17)
        Me.rdBouncyCirTail.TabIndex = 22
        Me.rdBouncyCirTail.Text = "Bouncy Tail (regrows)"
        Me.rdBouncyCirTail.UseVisualStyleBackColor = True
        '
        'ticCirNotRegrow
        '
        Me.ticCirNotRegrow.AutoSize = True
        Me.ticCirNotRegrow.Location = New System.Drawing.Point(6, 42)
        Me.ticCirNotRegrow.Name = "ticCirNotRegrow"
        Me.ticCirNotRegrow.Size = New System.Drawing.Size(114, 17)
        Me.ticCirNotRegrow.TabIndex = 23
        Me.ticCirNotRegrow.Text = "Tail doesn't regrow"
        Me.ticCirNotRegrow.UseVisualStyleBackColor = True
        '
        'rdCirTailLength
        '
        Me.rdCirTailLength.AutoSize = True
        Me.rdCirTailLength.Checked = True
        Me.rdCirTailLength.Location = New System.Drawing.Point(6, 65)
        Me.rdCirTailLength.Name = "rdCirTailLength"
        Me.rdCirTailLength.Size = New System.Drawing.Size(108, 17)
        Me.rdCirTailLength.TabIndex = 24
        Me.rdCirTailLength.TabStop = True
        Me.rdCirTailLength.Text = "Specify tail length"
        Me.rdCirTailLength.UseVisualStyleBackColor = True
        '
        'gbLineTailConfig
        '
        Me.gbLineTailConfig.Controls.Add(Me.ticLineTailLength)
        Me.gbLineTailConfig.Controls.Add(Me.rdBouncyLineTail)
        Me.gbLineTailConfig.Controls.Add(Me.ticLineNotRegrow)
        Me.gbLineTailConfig.Controls.Add(Me.rdLineTailLength)
        Me.gbLineTailConfig.Location = New System.Drawing.Point(6, 149)
        Me.gbLineTailConfig.Name = "gbLineTailConfig"
        Me.gbLineTailConfig.Size = New System.Drawing.Size(196, 94)
        Me.gbLineTailConfig.TabIndex = 18
        Me.gbLineTailConfig.TabStop = False
        Me.gbLineTailConfig.Text = "Line tail configuration"
        '
        'ticLineTailLength
        '
        Me.ticLineTailLength.Location = New System.Drawing.Point(151, 65)
        Me.ticLineTailLength.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.ticLineTailLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ticLineTailLength.Name = "ticLineTailLength"
        Me.ticLineTailLength.Size = New System.Drawing.Size(39, 20)
        Me.ticLineTailLength.TabIndex = 21
        Me.ticLineTailLength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'rdBouncyLineTail
        '
        Me.rdBouncyLineTail.AutoSize = True
        Me.rdBouncyLineTail.Checked = True
        Me.rdBouncyLineTail.Location = New System.Drawing.Point(6, 19)
        Me.rdBouncyLineTail.Name = "rdBouncyLineTail"
        Me.rdBouncyLineTail.Size = New System.Drawing.Size(127, 17)
        Me.rdBouncyLineTail.TabIndex = 9
        Me.rdBouncyLineTail.TabStop = True
        Me.rdBouncyLineTail.Text = "Bouncy Tail (regrows)"
        Me.rdBouncyLineTail.UseVisualStyleBackColor = True
        '
        'ticLineNotRegrow
        '
        Me.ticLineNotRegrow.AutoSize = True
        Me.ticLineNotRegrow.Location = New System.Drawing.Point(6, 42)
        Me.ticLineNotRegrow.Name = "ticLineNotRegrow"
        Me.ticLineNotRegrow.Size = New System.Drawing.Size(114, 17)
        Me.ticLineNotRegrow.TabIndex = 10
        Me.ticLineNotRegrow.Text = "Tail doesn't regrow"
        Me.ticLineNotRegrow.UseVisualStyleBackColor = True
        '
        'rdLineTailLength
        '
        Me.rdLineTailLength.AutoSize = True
        Me.rdLineTailLength.Location = New System.Drawing.Point(6, 65)
        Me.rdLineTailLength.Name = "rdLineTailLength"
        Me.rdLineTailLength.Size = New System.Drawing.Size(108, 17)
        Me.rdLineTailLength.TabIndex = 11
        Me.rdLineTailLength.Text = "Specify tail length"
        Me.rdLineTailLength.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdLineCircle)
        Me.GroupBox1.Controls.Add(Me.rdCircle)
        Me.GroupBox1.Controls.Add(Me.rdLine)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 94)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display lines or circles"
        '
        'rdLineCircle
        '
        Me.rdLineCircle.AutoSize = True
        Me.rdLineCircle.Checked = True
        Me.rdLineCircle.Location = New System.Drawing.Point(6, 19)
        Me.rdLineCircle.Name = "rdLineCircle"
        Me.rdLineCircle.Size = New System.Drawing.Size(130, 17)
        Me.rdLineCircle.TabIndex = 6
        Me.rdLineCircle.TabStop = True
        Me.rdLineCircle.Text = "Show lines and circles"
        Me.rdLineCircle.UseVisualStyleBackColor = True
        '
        'rdCircle
        '
        Me.rdCircle.AutoSize = True
        Me.rdCircle.Location = New System.Drawing.Point(6, 65)
        Me.rdCircle.Name = "rdCircle"
        Me.rdCircle.Size = New System.Drawing.Size(107, 17)
        Me.rdCircle.TabIndex = 7
        Me.rdCircle.Text = "Show only circles"
        Me.rdCircle.UseVisualStyleBackColor = True
        '
        'rdLine
        '
        Me.rdLine.AutoSize = True
        Me.rdLine.Location = New System.Drawing.Point(6, 42)
        Me.rdLine.Name = "rdLine"
        Me.rdLine.Size = New System.Drawing.Size(98, 17)
        Me.rdLine.TabIndex = 8
        Me.rdLine.Text = "Show only lines"
        Me.rdLine.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 353)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Refresh rate (ms)"
        '
        'ticRefreshRate
        '
        Me.ticRefreshRate.Location = New System.Drawing.Point(402, 351)
        Me.ticRefreshRate.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ticRefreshRate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ticRefreshRate.Name = "ticRefreshRate"
        Me.ticRefreshRate.Size = New System.Drawing.Size(56, 20)
        Me.ticRefreshRate.TabIndex = 12
        Me.ticRefreshRate.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblColorChange)
        Me.GroupBox4.Controls.Add(Me.ticColorChange)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.gbChangeOnBump)
        Me.GroupBox4.Location = New System.Drawing.Point(220, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(244, 248)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Color"
        '
        'lblColorChange
        '
        Me.lblColorChange.AutoSize = True
        Me.lblColorChange.Location = New System.Drawing.Point(13, 226)
        Me.lblColorChange.Name = "lblColorChange"
        Me.lblColorChange.Size = New System.Drawing.Size(178, 13)
        Me.lblColorChange.TabIndex = 15
        Me.lblColorChange.Text = "Maximum gradual color change rate:"
        '
        'ticColorChange
        '
        Me.ticColorChange.Location = New System.Drawing.Point(197, 224)
        Me.ticColorChange.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.ticColorChange.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ticColorChange.Name = "ticColorChange"
        Me.ticColorChange.Size = New System.Drawing.Size(41, 20)
        Me.ticColorChange.TabIndex = 14
        Me.ticColorChange.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdNoChangeRefresh)
        Me.GroupBox2.Controls.Add(Me.rdGradChangeRefresh)
        Me.GroupBox2.Controls.Add(Me.rdRandChangeRefresh)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 94)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Change color on refresh"
        '
        'rdNoChangeRefresh
        '
        Me.rdNoChangeRefresh.AutoSize = True
        Me.rdNoChangeRefresh.Location = New System.Drawing.Point(10, 17)
        Me.rdNoChangeRefresh.Name = "rdNoChangeRefresh"
        Me.rdNoChangeRefresh.Size = New System.Drawing.Size(104, 17)
        Me.rdNoChangeRefresh.TabIndex = 6
        Me.rdNoChangeRefresh.Text = "No color change"
        Me.rdNoChangeRefresh.UseVisualStyleBackColor = True
        '
        'rdGradChangeRefresh
        '
        Me.rdGradChangeRefresh.AutoSize = True
        Me.rdGradChangeRefresh.Checked = True
        Me.rdGradChangeRefresh.Location = New System.Drawing.Point(10, 40)
        Me.rdGradChangeRefresh.Name = "rdGradChangeRefresh"
        Me.rdGradChangeRefresh.Size = New System.Drawing.Size(127, 17)
        Me.rdGradChangeRefresh.TabIndex = 7
        Me.rdGradChangeRefresh.TabStop = True
        Me.rdGradChangeRefresh.Text = "Gradual color change"
        Me.rdGradChangeRefresh.UseVisualStyleBackColor = True
        '
        'rdRandChangeRefresh
        '
        Me.rdRandChangeRefresh.AutoSize = True
        Me.rdRandChangeRefresh.Location = New System.Drawing.Point(10, 63)
        Me.rdRandChangeRefresh.Name = "rdRandChangeRefresh"
        Me.rdRandChangeRefresh.Size = New System.Drawing.Size(130, 17)
        Me.rdRandChangeRefresh.TabIndex = 8
        Me.rdRandChangeRefresh.Text = "Random color change"
        Me.rdRandChangeRefresh.UseVisualStyleBackColor = True
        '
        'gbChangeOnBump
        '
        Me.gbChangeOnBump.Controls.Add(Me.rdNoChangeBump)
        Me.gbChangeOnBump.Controls.Add(Me.rdGradChangeBump)
        Me.gbChangeOnBump.Controls.Add(Me.rdRandChangeBump)
        Me.gbChangeOnBump.Location = New System.Drawing.Point(6, 119)
        Me.gbChangeOnBump.Name = "gbChangeOnBump"
        Me.gbChangeOnBump.Size = New System.Drawing.Size(232, 94)
        Me.gbChangeOnBump.TabIndex = 13
        Me.gbChangeOnBump.TabStop = False
        Me.gbChangeOnBump.Text = "Change color on bump"
        '
        'rdNoChangeBump
        '
        Me.rdNoChangeBump.AutoSize = True
        Me.rdNoChangeBump.Checked = True
        Me.rdNoChangeBump.Location = New System.Drawing.Point(10, 17)
        Me.rdNoChangeBump.Name = "rdNoChangeBump"
        Me.rdNoChangeBump.Size = New System.Drawing.Size(104, 17)
        Me.rdNoChangeBump.TabIndex = 6
        Me.rdNoChangeBump.TabStop = True
        Me.rdNoChangeBump.Text = "No color change"
        Me.rdNoChangeBump.UseVisualStyleBackColor = True
        '
        'rdGradChangeBump
        '
        Me.rdGradChangeBump.AutoSize = True
        Me.rdGradChangeBump.Location = New System.Drawing.Point(10, 40)
        Me.rdGradChangeBump.Name = "rdGradChangeBump"
        Me.rdGradChangeBump.Size = New System.Drawing.Size(127, 17)
        Me.rdGradChangeBump.TabIndex = 7
        Me.rdGradChangeBump.Text = "Gradual color change"
        Me.rdGradChangeBump.UseVisualStyleBackColor = True
        '
        'rdRandChangeBump
        '
        Me.rdRandChangeBump.AutoSize = True
        Me.rdRandChangeBump.Location = New System.Drawing.Point(10, 63)
        Me.rdRandChangeBump.Name = "rdRandChangeBump"
        Me.rdRandChangeBump.Size = New System.Drawing.Size(130, 17)
        Me.rdRandChangeBump.TabIndex = 8
        Me.rdRandChangeBump.Text = "Random color change"
        Me.rdRandChangeBump.UseVisualStyleBackColor = True
        '
        'lblMinRadSize
        '
        Me.lblMinRadSize.AutoSize = True
        Me.lblMinRadSize.Location = New System.Drawing.Point(236, 301)
        Me.lblMinRadSize.Name = "lblMinRadSize"
        Me.lblMinRadSize.Size = New System.Drawing.Size(110, 13)
        Me.lblMinRadSize.TabIndex = 17
        Me.lblMinRadSize.Text = "Minimum Radius Size:"
        '
        'lblLineThicken
        '
        Me.lblLineThicken.AutoSize = True
        Me.lblLineThicken.Location = New System.Drawing.Point(236, 275)
        Me.lblLineThicken.Name = "lblLineThicken"
        Me.lblLineThicken.Size = New System.Drawing.Size(59, 13)
        Me.lblLineThicken.TabIndex = 15
        Me.lblLineThicken.Text = "Thickness:"
        '
        'ticMinRadSize
        '
        Me.ticMinRadSize.Location = New System.Drawing.Point(402, 299)
        Me.ticMinRadSize.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.ticMinRadSize.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.ticMinRadSize.Name = "ticMinRadSize"
        Me.ticMinRadSize.Size = New System.Drawing.Size(56, 20)
        Me.ticMinRadSize.TabIndex = 16
        Me.ticMinRadSize.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'ticLineThickness
        '
        Me.ticLineThickness.Location = New System.Drawing.Point(402, 273)
        Me.ticLineThickness.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.ticLineThickness.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ticLineThickness.Name = "ticLineThickness"
        Me.ticLineThickness.Size = New System.Drawing.Size(56, 20)
        Me.ticLineThickness.TabIndex = 14
        Me.ticLineThickness.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.rssGroupBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(489, 466)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.okButton, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.applyButton, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cancelButton1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdPreview, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 433)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(483, 30)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'okButton
        '
        Me.okButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.okButton.Location = New System.Drawing.Point(243, 3)
        Me.okButton.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(75, 23)
        Me.okButton.TabIndex = 4
        Me.okButton.Text = "OK"
        '
        'applyButton
        '
        Me.applyButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.applyButton.Location = New System.Drawing.Point(405, 3)
        Me.applyButton.Name = "applyButton"
        Me.applyButton.Size = New System.Drawing.Size(75, 23)
        Me.applyButton.TabIndex = 2
        Me.applyButton.Text = "Apply"
        '
        'cancelButton1
        '
        Me.cancelButton1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cancelButton1.Location = New System.Drawing.Point(323, 3)
        Me.cancelButton1.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.cancelButton1.Name = "cancelButton1"
        Me.cancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton1.TabIndex = 1
        Me.cancelButton1.Text = "Cancel"
        '
        'cmdPreview
        '
        Me.cmdPreview.AutoSize = True
        Me.cmdPreview.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdPreview.Location = New System.Drawing.Point(3, 3)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreview.Size = New System.Drawing.Size(75, 24)
        Me.cmdPreview.TabIndex = 3
        Me.cmdPreview.Text = "Preview"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cmdDelete, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdSet, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdSaveAs, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lstTemplate, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 388)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(483, 29)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(324, 3)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 4
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSet
        '
        Me.cmdSet.Location = New System.Drawing.Point(243, 3)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(75, 23)
        Me.cmdSet.TabIndex = 3
        Me.cmdSet.Text = "Set"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'cmdSaveAs
        '
        Me.cmdSaveAs.Location = New System.Drawing.Point(405, 3)
        Me.cmdSaveAs.Name = "cmdSaveAs"
        Me.cmdSaveAs.Size = New System.Drawing.Size(74, 23)
        Me.cmdSaveAs.TabIndex = 1
        Me.cmdSaveAs.Text = "Save As"
        Me.cmdSaveAs.UseVisualStyleBackColor = True
        '
        'lstTemplate
        '
        Me.lstTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstTemplate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lstTemplate.FormattingEnabled = True
        Me.lstTemplate.Location = New System.Drawing.Point(3, 3)
        Me.lstTemplate.Name = "lstTemplate"
        Me.lstTemplate.Size = New System.Drawing.Size(234, 21)
        Me.lstTemplate.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 423)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(483, 4)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'OptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 484)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "OptionsForm"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowIcon = False
        Me.Text = "Circle's Tail Settings"
        Me.rssGroupBox.ResumeLayout(False)
        Me.rssGroupBox.PerformLayout()
        CType(Me.ticMaxRadSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.ticNumItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCircleTailConfig.ResumeLayout(False)
        Me.gbCircleTailConfig.PerformLayout()
        CType(Me.ticCirTailLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLineTailConfig.ResumeLayout(False)
        Me.gbLineTailConfig.PerformLayout()
        CType(Me.ticLineTailLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ticRefreshRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ticColorChange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbChangeOnBump.ResumeLayout(False)
        Me.gbChangeOnBump.PerformLayout()
        CType(Me.ticMinRadSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ticLineThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rssGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdGradChangeRefresh As System.Windows.Forms.RadioButton
    Friend WithEvents rdRandChangeRefresh As System.Windows.Forms.RadioButton
    Friend WithEvents rdNoChangeRefresh As System.Windows.Forms.RadioButton
    Friend WithEvents gbChangeOnBump As System.Windows.Forms.GroupBox
    Friend WithEvents rdNoChangeBump As System.Windows.Forms.RadioButton
    Friend WithEvents rdGradChangeBump As System.Windows.Forms.RadioButton
    Friend WithEvents rdRandChangeBump As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblColorChange As System.Windows.Forms.Label
    Friend WithEvents ticColorChange As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ticRefreshRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdLineCircle As System.Windows.Forms.RadioButton
    Friend WithEvents rdCircle As System.Windows.Forms.RadioButton
    Friend WithEvents rdLine As System.Windows.Forms.RadioButton
    Friend WithEvents gbCircleTailConfig As System.Windows.Forms.GroupBox
    Friend WithEvents gbLineTailConfig As System.Windows.Forms.GroupBox
    Friend WithEvents lblMinRadSize As System.Windows.Forms.Label
    Friend WithEvents ticMinRadSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLineThicken As System.Windows.Forms.Label
    Friend WithEvents ticLineThickness As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNumCircles As System.Windows.Forms.Label
    Friend WithEvents ticNumItems As System.Windows.Forms.NumericUpDown
    Friend WithEvents rdBouncyLineTail As System.Windows.Forms.RadioButton
    Friend WithEvents ticLineNotRegrow As System.Windows.Forms.RadioButton
    Friend WithEvents rdLineTailLength As System.Windows.Forms.RadioButton
    Friend WithEvents ticLineTailLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents ticCirTailLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents rdBouncyCirTail As System.Windows.Forms.RadioButton
    Friend WithEvents ticCirNotRegrow As System.Windows.Forms.RadioButton
    Friend WithEvents rdCirTailLength As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ticMaxRadSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdSaveAs As System.Windows.Forms.Button
    Friend WithEvents lstTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents applyButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton1 As System.Windows.Forms.Button
    Friend WithEvents cmdPreview As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    'InitializeComponent 
End Class
