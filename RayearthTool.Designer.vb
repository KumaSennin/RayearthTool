<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RayearthTool
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RayearthTool))
        Me.ButtonCodePage = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonOut = New System.Windows.Forms.Button()
        Me.ButtonIn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBoxFont = New System.Windows.Forms.TextBox()
        Me.NumericUpDownX = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownY = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownSize = New System.Windows.Forms.NumericUpDown()
        Me.ButtonFont = New System.Windows.Forms.Button()
        Me.CheckBoxBold = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPixel = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ButtonFontOut = New System.Windows.Forms.Button()
        Me.ButtonCheckText = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ButtonGameOut = New System.Windows.Forms.Button()
        Me.TextBoxGameOut = New System.Windows.Forms.TextBox()
        Me.TextBoxDataOut = New System.Windows.Forms.TextBox()
        Me.ButtonDataOut = New System.Windows.Forms.Button()
        Me.TextBoxDataIn = New System.Windows.Forms.TextBox()
        Me.ButtonDataIn = New System.Windows.Forms.Button()
        Me.TextBoxGameIn = New System.Windows.Forms.TextBox()
        Me.ButtonGameIn = New System.Windows.Forms.Button()
        Me.TextBoxGameCodePage = New System.Windows.Forms.TextBox()
        Me.ButtonGameCodePage = New System.Windows.Forms.Button()
        Me.TextBoxDataCodePage = New System.Windows.Forms.TextBox()
        Me.ButtonDataCodePage = New System.Windows.Forms.Button()
        Me.TextBoxDataFont = New System.Windows.Forms.TextBox()
        Me.ButtonDataFont = New System.Windows.Forms.Button()
        Me.ButtonDebugIn = New System.Windows.Forms.Button()
        Me.TextBoxDebug = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonCodePage
        '
        Me.ButtonCodePage.Location = New System.Drawing.Point(292, 154)
        Me.ButtonCodePage.Name = "ButtonCodePage"
        Me.ButtonCodePage.Size = New System.Drawing.Size(94, 48)
        Me.ButtonCodePage.TabIndex = 0
        Me.ButtonCodePage.Text = "导出代码页"
        Me.ButtonCodePage.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 125)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(374, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'ButtonOut
        '
        Me.ButtonOut.Location = New System.Drawing.Point(292, 208)
        Me.ButtonOut.Name = "ButtonOut"
        Me.ButtonOut.Size = New System.Drawing.Size(94, 48)
        Me.ButtonOut.TabIndex = 2
        Me.ButtonOut.Text = "导出数据"
        Me.ButtonOut.UseVisualStyleBackColor = True
        '
        'ButtonIn
        '
        Me.ButtonIn.Location = New System.Drawing.Point(292, 262)
        Me.ButtonIn.Name = "ButtonIn"
        Me.ButtonIn.Size = New System.Drawing.Size(94, 48)
        Me.ButtonIn.TabIndex = 3
        Me.ButtonIn.Text = "导入数据"
        Me.ButtonIn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 26)
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem.Text = "保存预览图"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(206, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(102, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'TextBoxFont
        '
        Me.TextBoxFont.Location = New System.Drawing.Point(206, 42)
        Me.TextBoxFont.Name = "TextBoxFont"
        Me.TextBoxFont.Size = New System.Drawing.Size(102, 21)
        Me.TextBoxFont.TabIndex = 6
        Me.TextBoxFont.Text = "狮堂光"
        '
        'NumericUpDownX
        '
        Me.NumericUpDownX.Location = New System.Drawing.Point(152, 15)
        Me.NumericUpDownX.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDownX.Minimum = New Decimal(New Integer() {8, 0, 0, -2147483648})
        Me.NumericUpDownX.Name = "NumericUpDownX"
        Me.NumericUpDownX.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownX.TabIndex = 7
        Me.NumericUpDownX.Value = New Decimal(New Integer() {2, 0, 0, -2147483648})
        '
        'NumericUpDownY
        '
        Me.NumericUpDownY.Location = New System.Drawing.Point(152, 42)
        Me.NumericUpDownY.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDownY.Minimum = New Decimal(New Integer() {8, 0, 0, -2147483648})
        Me.NumericUpDownY.Name = "NumericUpDownY"
        Me.NumericUpDownY.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownY.TabIndex = 8
        '
        'NumericUpDownSize
        '
        Me.NumericUpDownSize.Location = New System.Drawing.Point(152, 69)
        Me.NumericUpDownSize.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.NumericUpDownSize.Minimum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDownSize.Name = "NumericUpDownSize"
        Me.NumericUpDownSize.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownSize.TabIndex = 9
        Me.NumericUpDownSize.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'ButtonFont
        '
        Me.ButtonFont.Location = New System.Drawing.Point(314, 42)
        Me.ButtonFont.Name = "ButtonFont"
        Me.ButtonFont.Size = New System.Drawing.Size(72, 23)
        Me.ButtonFont.TabIndex = 10
        Me.ButtonFont.Text = "字体"
        Me.ButtonFont.UseVisualStyleBackColor = True
        '
        'CheckBoxBold
        '
        Me.CheckBoxBold.AutoSize = True
        Me.CheckBoxBold.Location = New System.Drawing.Point(206, 71)
        Me.CheckBoxBold.Name = "CheckBoxBold"
        Me.CheckBoxBold.Size = New System.Drawing.Size(48, 16)
        Me.CheckBoxBold.TabIndex = 11
        Me.CheckBoxBold.Text = "粗体"
        Me.CheckBoxBold.UseVisualStyleBackColor = True
        '
        'CheckBoxPixel
        '
        Me.CheckBoxPixel.AutoSize = True
        Me.CheckBoxPixel.Location = New System.Drawing.Point(260, 71)
        Me.CheckBoxPixel.Name = "CheckBoxPixel"
        Me.CheckBoxPixel.Size = New System.Drawing.Size(48, 16)
        Me.CheckBoxPixel.TabIndex = 12
        Me.CheckBoxPixel.Text = "像素"
        Me.CheckBoxPixel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "X 偏移"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Y 偏移"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "字  号"
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = New System.Drawing.Font("青鸟华光简粗圆", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ButtonFontOut
        '
        Me.ButtonFontOut.Location = New System.Drawing.Point(292, 342)
        Me.ButtonFontOut.Name = "ButtonFontOut"
        Me.ButtonFontOut.Size = New System.Drawing.Size(94, 26)
        Me.ButtonFontOut.TabIndex = 17
        Me.ButtonFontOut.Text = "导出字符"
        Me.ButtonFontOut.UseVisualStyleBackColor = True
        '
        'ButtonCheckText
        '
        Me.ButtonCheckText.Location = New System.Drawing.Point(206, 342)
        Me.ButtonCheckText.Name = "ButtonCheckText"
        Me.ButtonCheckText.Size = New System.Drawing.Size(80, 26)
        Me.ButtonCheckText.TabIndex = 18
        Me.ButtonCheckText.Text = "文本校检"
        Me.ButtonCheckText.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(314, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(72, 21)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "output"
        Me.SaveFileDialog1.Filter = "PNG文件|*.png"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(314, 71)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "保留符号"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ButtonGameOut
        '
        Me.ButtonGameOut.Location = New System.Drawing.Point(206, 208)
        Me.ButtonGameOut.Name = "ButtonGameOut"
        Me.ButtonGameOut.Size = New System.Drawing.Size(80, 21)
        Me.ButtonGameOut.TabIndex = 21
        Me.ButtonGameOut.Text = "游戏目录"
        Me.ButtonGameOut.UseVisualStyleBackColor = True
        '
        'TextBoxGameOut
        '
        Me.TextBoxGameOut.Location = New System.Drawing.Point(12, 208)
        Me.TextBoxGameOut.Name = "TextBoxGameOut"
        Me.TextBoxGameOut.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxGameOut.TabIndex = 22
        '
        'TextBoxDataOut
        '
        Me.TextBoxDataOut.Location = New System.Drawing.Point(12, 235)
        Me.TextBoxDataOut.Name = "TextBoxDataOut"
        Me.TextBoxDataOut.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxDataOut.TabIndex = 24
        '
        'ButtonDataOut
        '
        Me.ButtonDataOut.Location = New System.Drawing.Point(206, 235)
        Me.ButtonDataOut.Name = "ButtonDataOut"
        Me.ButtonDataOut.Size = New System.Drawing.Size(80, 21)
        Me.ButtonDataOut.TabIndex = 23
        Me.ButtonDataOut.Text = "数据目录"
        Me.ButtonDataOut.UseVisualStyleBackColor = True
        '
        'TextBoxDataIn
        '
        Me.TextBoxDataIn.Location = New System.Drawing.Point(12, 289)
        Me.TextBoxDataIn.Name = "TextBoxDataIn"
        Me.TextBoxDataIn.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxDataIn.TabIndex = 26
        '
        'ButtonDataIn
        '
        Me.ButtonDataIn.Location = New System.Drawing.Point(206, 289)
        Me.ButtonDataIn.Name = "ButtonDataIn"
        Me.ButtonDataIn.Size = New System.Drawing.Size(80, 21)
        Me.ButtonDataIn.TabIndex = 25
        Me.ButtonDataIn.Text = "数据目录"
        Me.ButtonDataIn.UseVisualStyleBackColor = True
        '
        'TextBoxGameIn
        '
        Me.TextBoxGameIn.Location = New System.Drawing.Point(12, 262)
        Me.TextBoxGameIn.Name = "TextBoxGameIn"
        Me.TextBoxGameIn.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxGameIn.TabIndex = 28
        '
        'ButtonGameIn
        '
        Me.ButtonGameIn.Location = New System.Drawing.Point(206, 262)
        Me.ButtonGameIn.Name = "ButtonGameIn"
        Me.ButtonGameIn.Size = New System.Drawing.Size(80, 21)
        Me.ButtonGameIn.TabIndex = 27
        Me.ButtonGameIn.Text = "游戏目录"
        Me.ButtonGameIn.UseVisualStyleBackColor = True
        '
        'TextBoxGameCodePage
        '
        Me.TextBoxGameCodePage.Location = New System.Drawing.Point(12, 154)
        Me.TextBoxGameCodePage.Name = "TextBoxGameCodePage"
        Me.TextBoxGameCodePage.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxGameCodePage.TabIndex = 30
        '
        'ButtonGameCodePage
        '
        Me.ButtonGameCodePage.Location = New System.Drawing.Point(206, 154)
        Me.ButtonGameCodePage.Name = "ButtonGameCodePage"
        Me.ButtonGameCodePage.Size = New System.Drawing.Size(80, 21)
        Me.ButtonGameCodePage.TabIndex = 29
        Me.ButtonGameCodePage.Text = "游戏目录"
        Me.ButtonGameCodePage.UseVisualStyleBackColor = True
        '
        'TextBoxDataCodePage
        '
        Me.TextBoxDataCodePage.Location = New System.Drawing.Point(12, 181)
        Me.TextBoxDataCodePage.Name = "TextBoxDataCodePage"
        Me.TextBoxDataCodePage.Size = New System.Drawing.Size(188, 21)
        Me.TextBoxDataCodePage.TabIndex = 32
        '
        'ButtonDataCodePage
        '
        Me.ButtonDataCodePage.Location = New System.Drawing.Point(206, 181)
        Me.ButtonDataCodePage.Name = "ButtonDataCodePage"
        Me.ButtonDataCodePage.Size = New System.Drawing.Size(80, 21)
        Me.ButtonDataCodePage.TabIndex = 31
        Me.ButtonDataCodePage.Text = "数据目录"
        Me.ButtonDataCodePage.UseVisualStyleBackColor = True
        '
        'TextBoxDataFont
        '
        Me.TextBoxDataFont.Location = New System.Drawing.Point(12, 98)
        Me.TextBoxDataFont.Name = "TextBoxDataFont"
        Me.TextBoxDataFont.Size = New System.Drawing.Size(274, 21)
        Me.TextBoxDataFont.TabIndex = 34
        '
        'ButtonDataFont
        '
        Me.ButtonDataFont.Location = New System.Drawing.Point(292, 98)
        Me.ButtonDataFont.Name = "ButtonDataFont"
        Me.ButtonDataFont.Size = New System.Drawing.Size(94, 21)
        Me.ButtonDataFont.TabIndex = 33
        Me.ButtonDataFont.Text = "字符目录"
        Me.ButtonDataFont.UseVisualStyleBackColor = True
        '
        'ButtonDebugIn
        '
        Me.ButtonDebugIn.Location = New System.Drawing.Point(118, 342)
        Me.ButtonDebugIn.Name = "ButtonDebugIn"
        Me.ButtonDebugIn.Size = New System.Drawing.Size(82, 26)
        Me.ButtonDebugIn.TabIndex = 35
        Me.ButtonDebugIn.Text = "定向导入"
        Me.ButtonDebugIn.UseVisualStyleBackColor = True
        '
        'TextBoxDebug
        '
        Me.TextBoxDebug.Location = New System.Drawing.Point(12, 346)
        Me.TextBoxDebug.Name = "TextBoxDebug"
        Me.TextBoxDebug.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxDebug.TabIndex = 36
        Me.TextBoxDebug.Text = "ST.MSG"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "调试功能："
        '
        'RayearthTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 379)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxDebug)
        Me.Controls.Add(Me.ButtonDebugIn)
        Me.Controls.Add(Me.TextBoxDataFont)
        Me.Controls.Add(Me.ButtonDataFont)
        Me.Controls.Add(Me.TextBoxDataCodePage)
        Me.Controls.Add(Me.ButtonDataCodePage)
        Me.Controls.Add(Me.TextBoxGameCodePage)
        Me.Controls.Add(Me.ButtonGameCodePage)
        Me.Controls.Add(Me.TextBoxGameIn)
        Me.Controls.Add(Me.ButtonGameIn)
        Me.Controls.Add(Me.TextBoxDataIn)
        Me.Controls.Add(Me.ButtonDataIn)
        Me.Controls.Add(Me.TextBoxDataOut)
        Me.Controls.Add(Me.ButtonDataOut)
        Me.Controls.Add(Me.TextBoxGameOut)
        Me.Controls.Add(Me.ButtonGameOut)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.ButtonCheckText)
        Me.Controls.Add(Me.ButtonFontOut)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBoxPixel)
        Me.Controls.Add(Me.CheckBoxBold)
        Me.Controls.Add(Me.ButtonFont)
        Me.Controls.Add(Me.NumericUpDownSize)
        Me.Controls.Add(Me.NumericUpDownY)
        Me.Controls.Add(Me.NumericUpDownX)
        Me.Controls.Add(Me.TextBoxFont)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonIn)
        Me.Controls.Add(Me.ButtonOut)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonCodePage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(628, 472)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(228, 272)
        Me.Name = "RayearthTool"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RayearthTool"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCodePage As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonOut As Button
    Friend WithEvents ButtonIn As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBoxFont As TextBox
    Friend WithEvents NumericUpDownX As NumericUpDown
    Friend WithEvents NumericUpDownY As NumericUpDown
    Friend WithEvents NumericUpDownSize As NumericUpDown
    Friend WithEvents ButtonFont As Button
    Friend WithEvents CheckBoxBold As CheckBox
    Friend WithEvents CheckBoxPixel As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ButtonCheckText As Button
    Friend WithEvents ButtonFontOut As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ButtonGameOut As Button
    Friend WithEvents TextBoxGameOut As TextBox
    Friend WithEvents TextBoxDataOut As TextBox
    Friend WithEvents ButtonDataOut As Button
    Friend WithEvents TextBoxDataIn As TextBox
    Friend WithEvents ButtonDataIn As Button
    Friend WithEvents TextBoxGameIn As TextBox
    Friend WithEvents ButtonGameIn As Button
    Friend WithEvents TextBoxGameCodePage As TextBox
    Friend WithEvents ButtonGameCodePage As Button
    Friend WithEvents TextBoxDataCodePage As TextBox
    Friend WithEvents ButtonDataCodePage As Button
    Friend WithEvents TextBoxDataFont As TextBox
    Friend WithEvents ButtonDataFont As Button
    Friend WithEvents ButtonDebugIn As Button
    Friend WithEvents TextBoxDebug As TextBox
    Friend WithEvents Label4 As Label
End Class
