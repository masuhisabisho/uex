'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/27
' 時刻: 20:23
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class PrintSetting
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintSetting))
		Me.Lbl_SelectedDirection = New System.Windows.Forms.Label()
		Me.Lbl_Direction = New System.Windows.Forms.Label()
		Me.Lbl_Paper = New System.Windows.Forms.Label()
		Me.Grp2 = New System.Windows.Forms.GroupBox()
		Me.Nud_Ypos = New System.Windows.Forms.NumericUpDown()
		Me.Nud_Xpos = New System.Windows.Forms.NumericUpDown()
		Me.Cmb_PaperSize = New System.Windows.Forms.ComboBox()
		Me.Lbl_SelectPrinter = New System.Windows.Forms.Label()
		Me.Cmb_SelectPrinter = New System.Windows.Forms.ComboBox()
		Me.Lbl_PosY = New System.Windows.Forms.Label()
		Me.Lbl_PosX = New System.Windows.Forms.Label()
		Me.Nud_Num = New System.Windows.Forms.NumericUpDown()
		Me.Lbl_Num = New System.Windows.Forms.Label()
		Me.Btn_Print = New System.Windows.Forms.Button()
		Me.Btn_Cancel = New System.Windows.Forms.Button()
		Me.printDocument1 = New System.Drawing.Printing.PrintDocument()
		Me.Grp2.SuspendLayout
		CType(Me.Nud_Ypos,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.Nud_Xpos,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.Nud_Num,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Lbl_SelectedDirection
		'
		Me.Lbl_SelectedDirection.Location = New System.Drawing.Point(140, 81)
		Me.Lbl_SelectedDirection.Name = "Lbl_SelectedDirection"
		Me.Lbl_SelectedDirection.Size = New System.Drawing.Size(100, 12)
		Me.Lbl_SelectedDirection.TabIndex = 7
		'
		'Lbl_Direction
		'
		Me.Lbl_Direction.Location = New System.Drawing.Point(13, 81)
		Me.Lbl_Direction.Name = "Lbl_Direction"
		Me.Lbl_Direction.Size = New System.Drawing.Size(100, 12)
		Me.Lbl_Direction.TabIndex = 3
		Me.Lbl_Direction.Text = "用紙設定方向："
		'
		'Lbl_Paper
		'
		Me.Lbl_Paper.Location = New System.Drawing.Point(13, 52)
		Me.Lbl_Paper.Name = "Lbl_Paper"
		Me.Lbl_Paper.Size = New System.Drawing.Size(100, 12)
		Me.Lbl_Paper.TabIndex = 0
		Me.Lbl_Paper.Text = "用紙："
		'
		'Grp2
		'
		Me.Grp2.Controls.Add(Me.Nud_Ypos)
		Me.Grp2.Controls.Add(Me.Nud_Xpos)
		Me.Grp2.Controls.Add(Me.Cmb_PaperSize)
		Me.Grp2.Controls.Add(Me.Lbl_SelectedDirection)
		Me.Grp2.Controls.Add(Me.Lbl_Paper)
		Me.Grp2.Controls.Add(Me.Lbl_SelectPrinter)
		Me.Grp2.Controls.Add(Me.Lbl_Direction)
		Me.Grp2.Controls.Add(Me.Cmb_SelectPrinter)
		Me.Grp2.Controls.Add(Me.Lbl_PosY)
		Me.Grp2.Controls.Add(Me.Lbl_PosX)
		Me.Grp2.Controls.Add(Me.Nud_Num)
		Me.Grp2.Controls.Add(Me.Lbl_Num)
		Me.Grp2.Location = New System.Drawing.Point(16, 111)
		Me.Grp2.Name = "Grp2"
		Me.Grp2.Size = New System.Drawing.Size(425, 167)
		Me.Grp2.TabIndex = 1
		Me.Grp2.TabStop = false
		Me.Grp2.Text = "設定"
		'
		'Nud_Ypos
		'
		Me.Nud_Ypos.DecimalPlaces = 1
		Me.Nud_Ypos.Location = New System.Drawing.Point(300, 103)
		Me.Nud_Ypos.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
		Me.Nud_Ypos.Minimum = New Decimal(New Integer() {20, 0, 0, -2147483648})
		Me.Nud_Ypos.Name = "Nud_Ypos"
		Me.Nud_Ypos.Size = New System.Drawing.Size(65, 19)
		Me.Nud_Ypos.TabIndex = 22
		'
		'Nud_Xpos
		'
		Me.Nud_Xpos.DecimalPlaces = 1
		Me.Nud_Xpos.Location = New System.Drawing.Point(140, 103)
		Me.Nud_Xpos.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
		Me.Nud_Xpos.Minimum = New Decimal(New Integer() {20, 0, 0, -2147483648})
		Me.Nud_Xpos.Name = "Nud_Xpos"
		Me.Nud_Xpos.Size = New System.Drawing.Size(65, 19)
		Me.Nud_Xpos.TabIndex = 21
		'
		'Cmb_PaperSize
		'
		Me.Cmb_PaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PaperSize.FormattingEnabled = true
		Me.Cmb_PaperSize.Location = New System.Drawing.Point(140, 48)
		Me.Cmb_PaperSize.Name = "Cmb_PaperSize"
		Me.Cmb_PaperSize.Size = New System.Drawing.Size(275, 20)
		Me.Cmb_PaperSize.TabIndex = 20
		'
		'Lbl_SelectPrinter
		'
		Me.Lbl_SelectPrinter.Location = New System.Drawing.Point(13, 23)
		Me.Lbl_SelectPrinter.Name = "Lbl_SelectPrinter"
		Me.Lbl_SelectPrinter.Size = New System.Drawing.Size(100, 12)
		Me.Lbl_SelectPrinter.TabIndex = 19
		Me.Lbl_SelectPrinter.Text = "使用するプリンター："
		'
		'Cmb_SelectPrinter
		'
		Me.Cmb_SelectPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_SelectPrinter.FormattingEnabled = true
		Me.Cmb_SelectPrinter.Location = New System.Drawing.Point(140, 18)
		Me.Cmb_SelectPrinter.Name = "Cmb_SelectPrinter"
		Me.Cmb_SelectPrinter.Size = New System.Drawing.Size(275, 20)
		Me.Cmb_SelectPrinter.TabIndex = 18
		'
		'Lbl_PosY
		'
		Me.Lbl_PosY.Location = New System.Drawing.Point(219, 110)
		Me.Lbl_PosY.Name = "Lbl_PosY"
		Me.Lbl_PosY.Size = New System.Drawing.Size(85, 16)
		Me.Lbl_PosY.TabIndex = 17
		Me.Lbl_PosY.Text = "印刷位置（Y)："
		'
		'Lbl_PosX
		'
		Me.Lbl_PosX.Location = New System.Drawing.Point(13, 110)
		Me.Lbl_PosX.Name = "Lbl_PosX"
		Me.Lbl_PosX.Size = New System.Drawing.Size(81, 12)
		Me.Lbl_PosX.TabIndex = 16
		Me.Lbl_PosX.Text = "印刷位置（X)："
		'
		'Nud_Num
		'
		Me.Nud_Num.Location = New System.Drawing.Point(140, 137)
		Me.Nud_Num.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.Nud_Num.Name = "Nud_Num"
		Me.Nud_Num.Size = New System.Drawing.Size(40, 19)
		Me.Nud_Num.TabIndex = 2
		Me.Nud_Num.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Lbl_Num
		'
		Me.Lbl_Num.Location = New System.Drawing.Point(13, 139)
		Me.Lbl_Num.Name = "Lbl_Num"
		Me.Lbl_Num.Size = New System.Drawing.Size(100, 12)
		Me.Lbl_Num.TabIndex = 3
		Me.Lbl_Num.Text = "枚数："
		'
		'Btn_Print
		'
		Me.Btn_Print.Location = New System.Drawing.Point(274, 286)
		Me.Btn_Print.Name = "Btn_Print"
		Me.Btn_Print.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Print.TabIndex = 4
		Me.Btn_Print.Text = "印刷"
		Me.Btn_Print.UseVisualStyleBackColor = true
		AddHandler Me.Btn_Print.Click, AddressOf Me.Btn_Print_Click
		'
		'Btn_Cancel
		'
		Me.Btn_Cancel.Location = New System.Drawing.Point(364, 286)
		Me.Btn_Cancel.Name = "Btn_Cancel"
		Me.Btn_Cancel.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Cancel.TabIndex = 5
		Me.Btn_Cancel.Text = "キャンセル"
		Me.Btn_Cancel.UseVisualStyleBackColor = true
		AddHandler Me.Btn_Cancel.Click, AddressOf Me.Btn_Cancel_Click
		'
		'printDocument1
		'
		AddHandler Me.printDocument1.PrintPage, AddressOf Me.PrintDocument1_PrintPage
		'
		'PrintSetting
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(459, 314)
		Me.Controls.Add(Me.Btn_Cancel)
		Me.Controls.Add(Me.Btn_Print)
		Me.Controls.Add(Me.Grp2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "PrintSetting"
		Me.Text = "印刷"
		AddHandler Load, AddressOf Me.PrintSetting_Load
		Me.Grp2.ResumeLayout(false)
		CType(Me.Nud_Ypos,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.Nud_Xpos,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.Nud_Num,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private Nud_Xpos As System.Windows.Forms.NumericUpDown
	Private Nud_Ypos As System.Windows.Forms.NumericUpDown
	Private Cmb_PaperSize As System.Windows.Forms.ComboBox
	Private Cmb_SelectPrinter As System.Windows.Forms.ComboBox
	Private Lbl_SelectPrinter As System.Windows.Forms.Label
	Private printDocument1 As System.Drawing.Printing.PrintDocument
	Private Lbl_PosX As System.Windows.Forms.Label
	Private Lbl_PosY As System.Windows.Forms.Label
	Private Lbl_Direction As System.Windows.Forms.Label
	Private Lbl_SelectedDirection As System.Windows.Forms.Label
	Private Lbl_Paper As System.Windows.Forms.Label
	Private Btn_Cancel As System.Windows.Forms.Button
	Private Btn_Print As System.Windows.Forms.Button
	Private Lbl_Num As System.Windows.Forms.Label
	Private Nud_Num As System.Windows.Forms.NumericUpDown
	Private Grp2 As System.Windows.Forms.GroupBox
End Class
