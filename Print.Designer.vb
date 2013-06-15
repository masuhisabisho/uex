'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class Print
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Print))
		Me.Grb_Common = New System.Windows.Forms.GroupBox()
		Me.Txt_SizeY = New System.Windows.Forms.TextBox()
		Me.Txt_PrintDir = New System.Windows.Forms.TextBox()
		Me.Txt_SizeW = New System.Windows.Forms.TextBox()
		Me.Lbl_PosY = New System.Windows.Forms.Label()
		Me.Lbl_PosX = New System.Windows.Forms.Label()
		Me.Lbl_Font = New System.Windows.Forms.Label()
		Me.Lbl_PrintDir = New System.Windows.Forms.Label()
		Me.Lbl_SizeH = New System.Windows.Forms.Label()
		Me.Lbl_SizeW = New System.Windows.Forms.Label()
		Me.Lbl_Size = New System.Windows.Forms.Label()
		Me.Txt_PosY = New System.Windows.Forms.TextBox()
		Me.Txt_PosX = New System.Windows.Forms.TextBox()
		Me.Cmb_Font = New System.Windows.Forms.ComboBox()
		Me.Cmb_Size = New System.Windows.Forms.ComboBox()
		Me.Grb_Contents = New System.Windows.Forms.GroupBox()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.Pnl_Main = New System.Windows.Forms.Panel()
		Me.comboBox3 = New System.Windows.Forms.ComboBox()
		Me.textBox3 = New System.Windows.Forms.TextBox()
		Me.comboBox4 = New System.Windows.Forms.ComboBox()
		Me.Lbl_Rate = New System.Windows.Forms.Label()
		Me.Lbl_Num = New System.Windows.Forms.Label()
		Me.Lbl_Thick = New System.Windows.Forms.Label()
		Me.comboBox1 = New System.Windows.Forms.ComboBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.label16 = New System.Windows.Forms.Label()
		Me.label17 = New System.Windows.Forms.Label()
		Me.label18 = New System.Windows.Forms.Label()
		Me.label19 = New System.Windows.Forms.Label()
		Me.label24 = New System.Windows.Forms.Label()
		Me.label25 = New System.Windows.Forms.Label()
		Me.label26 = New System.Windows.Forms.Label()
		Me.label27 = New System.Windows.Forms.Label()
		Me.label28 = New System.Windows.Forms.Label()
		Me.label29 = New System.Windows.Forms.Label()
		Me.Grb_Common.SuspendLayout
		Me.Grb_Contents.SuspendLayout
		Me.panel1.SuspendLayout
		Me.SuspendLayout
		'
		'Grb_Common
		'
		Me.Grb_Common.Controls.Add(Me.Txt_SizeY)
		Me.Grb_Common.Controls.Add(Me.Txt_PrintDir)
		Me.Grb_Common.Controls.Add(Me.Txt_SizeW)
		Me.Grb_Common.Controls.Add(Me.Lbl_PosY)
		Me.Grb_Common.Controls.Add(Me.Lbl_PosX)
		Me.Grb_Common.Controls.Add(Me.Lbl_Font)
		Me.Grb_Common.Controls.Add(Me.Lbl_PrintDir)
		Me.Grb_Common.Controls.Add(Me.Lbl_SizeH)
		Me.Grb_Common.Controls.Add(Me.Lbl_SizeW)
		Me.Grb_Common.Controls.Add(Me.Lbl_Size)
		Me.Grb_Common.Controls.Add(Me.Txt_PosY)
		Me.Grb_Common.Controls.Add(Me.Txt_PosX)
		Me.Grb_Common.Controls.Add(Me.Cmb_Font)
		Me.Grb_Common.Controls.Add(Me.Cmb_Size)
		Me.Grb_Common.Location = New System.Drawing.Point(10, 3)
		Me.Grb_Common.Name = "Grb_Common"
		Me.Grb_Common.Size = New System.Drawing.Size(331, 148)
		Me.Grb_Common.TabIndex = 1
		Me.Grb_Common.TabStop = false
		Me.Grb_Common.Text = "共通設定"
		'
		'Txt_SizeY
		'
		Me.Txt_SizeY.Location = New System.Drawing.Point(99, 55)
		Me.Txt_SizeY.Name = "Txt_SizeY"
		Me.Txt_SizeY.ReadOnly = true
		Me.Txt_SizeY.Size = New System.Drawing.Size(223, 19)
		Me.Txt_SizeY.TabIndex = 16
		'
		'Txt_PrintDir
		'
		Me.Txt_PrintDir.Location = New System.Drawing.Point(99, 75)
		Me.Txt_PrintDir.Name = "Txt_PrintDir"
		Me.Txt_PrintDir.ReadOnly = true
		Me.Txt_PrintDir.Size = New System.Drawing.Size(223, 19)
		Me.Txt_PrintDir.TabIndex = 15
		'
		'Txt_SizeW
		'
		Me.Txt_SizeW.Location = New System.Drawing.Point(99, 35)
		Me.Txt_SizeW.Name = "Txt_SizeW"
		Me.Txt_SizeW.ReadOnly = true
		Me.Txt_SizeW.Size = New System.Drawing.Size(223, 19)
		Me.Txt_SizeW.TabIndex = 14
		'
		'Lbl_PosY
		'
		Me.Lbl_PosY.Location = New System.Drawing.Point(198, 123)
		Me.Lbl_PosY.Name = "Lbl_PosY"
		Me.Lbl_PosY.Size = New System.Drawing.Size(85, 16)
		Me.Lbl_PosY.TabIndex = 13
		Me.Lbl_PosY.Text = "印刷位置（Y)："
		'
		'Lbl_PosX
		'
		Me.Lbl_PosX.Location = New System.Drawing.Point(12, 123)
		Me.Lbl_PosX.Name = "Lbl_PosX"
		Me.Lbl_PosX.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PosX.TabIndex = 12
		Me.Lbl_PosX.Text = "印刷位置（X)："
		'
		'Lbl_Font
		'
		Me.Lbl_Font.Location = New System.Drawing.Point(12, 98)
		Me.Lbl_Font.Name = "Lbl_Font"
		Me.Lbl_Font.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_Font.TabIndex = 11
		Me.Lbl_Font.Text = "フォント："
		'
		'Lbl_PrintDir
		'
		Me.Lbl_PrintDir.Location = New System.Drawing.Point(12, 77)
		Me.Lbl_PrintDir.Name = "Lbl_PrintDir"
		Me.Lbl_PrintDir.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_PrintDir.TabIndex = 10
		Me.Lbl_PrintDir.Text = "印刷方向："
		'
		'Lbl_SizeH
		'
		Me.Lbl_SizeH.Location = New System.Drawing.Point(12, 57)
		Me.Lbl_SizeH.Name = "Lbl_SizeH"
		Me.Lbl_SizeH.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_SizeH.TabIndex = 9
		Me.Lbl_SizeH.Text = "用紙（高さ）："
		'
		'Lbl_SizeW
		'
		Me.Lbl_SizeW.Location = New System.Drawing.Point(12, 37)
		Me.Lbl_SizeW.Name = "Lbl_SizeW"
		Me.Lbl_SizeW.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_SizeW.TabIndex = 8
		Me.Lbl_SizeW.Text = "用紙（幅）："
		'
		'Lbl_Size
		'
		Me.Lbl_Size.Location = New System.Drawing.Point(12, 18)
		Me.Lbl_Size.Name = "Lbl_Size"
		Me.Lbl_Size.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_Size.TabIndex = 7
		Me.Lbl_Size.Text = "用紙："
		'
		'Txt_PosY
		'
		Me.Txt_PosY.Location = New System.Drawing.Point(282, 121)
		Me.Txt_PosY.Name = "Txt_PosY"
		Me.Txt_PosY.Size = New System.Drawing.Size(40, 19)
		Me.Txt_PosY.TabIndex = 6
		'
		'Txt_PosX
		'
		Me.Txt_PosX.Location = New System.Drawing.Point(99, 120)
		Me.Txt_PosX.Name = "Txt_PosX"
		Me.Txt_PosX.Size = New System.Drawing.Size(40, 19)
		Me.Txt_PosX.TabIndex = 5
		AddHandler Me.Txt_PosX.TextChanged, AddressOf Me.TextBox1_TextChanged
		'
		'Cmb_Font
		'
		Me.Cmb_Font.FormattingEnabled = true
		Me.Cmb_Font.Location = New System.Drawing.Point(99, 95)
		Me.Cmb_Font.Name = "Cmb_Font"
		Me.Cmb_Font.Size = New System.Drawing.Size(223, 20)
		Me.Cmb_Font.TabIndex = 4
		'
		'Cmb_Size
		'
		Me.Cmb_Size.FormattingEnabled = true
		Me.Cmb_Size.Location = New System.Drawing.Point(99, 14)
		Me.Cmb_Size.Name = "Cmb_Size"
		Me.Cmb_Size.Size = New System.Drawing.Size(223, 20)
		Me.Cmb_Size.TabIndex = 0
		'
		'Grb_Contents
		'
		Me.Grb_Contents.Controls.Add(Me.label29)
		Me.Grb_Contents.Controls.Add(Me.label28)
		Me.Grb_Contents.Controls.Add(Me.label27)
		Me.Grb_Contents.Controls.Add(Me.label26)
		Me.Grb_Contents.Controls.Add(Me.label25)
		Me.Grb_Contents.Controls.Add(Me.label24)
		Me.Grb_Contents.Controls.Add(Me.label19)
		Me.Grb_Contents.Controls.Add(Me.label18)
		Me.Grb_Contents.Controls.Add(Me.label17)
		Me.Grb_Contents.Controls.Add(Me.label16)
		Me.Grb_Contents.Controls.Add(Me.label15)
		Me.Grb_Contents.Controls.Add(Me.label14)
		Me.Grb_Contents.Controls.Add(Me.label13)
		Me.Grb_Contents.Controls.Add(Me.label12)
		Me.Grb_Contents.Controls.Add(Me.label11)
		Me.Grb_Contents.Controls.Add(Me.label10)
		Me.Grb_Contents.Controls.Add(Me.label9)
		Me.Grb_Contents.Controls.Add(Me.label8)
		Me.Grb_Contents.Controls.Add(Me.label7)
		Me.Grb_Contents.Controls.Add(Me.label6)
		Me.Grb_Contents.Controls.Add(Me.label5)
		Me.Grb_Contents.Controls.Add(Me.label4)
		Me.Grb_Contents.Controls.Add(Me.label3)
		Me.Grb_Contents.Controls.Add(Me.label2)
		Me.Grb_Contents.Controls.Add(Me.label1)
		Me.Grb_Contents.Controls.Add(Me.comboBox1)
		Me.Grb_Contents.Location = New System.Drawing.Point(3, 3)
		Me.Grb_Contents.Name = "Grb_Contents"
		Me.Grb_Contents.Size = New System.Drawing.Size(325, 468)
		Me.Grb_Contents.TabIndex = 2
		Me.Grb_Contents.TabStop = false
		Me.Grb_Contents.Text = "内容設定"
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.Grb_Contents)
		Me.panel1.Location = New System.Drawing.Point(10, 181)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(331, 474)
		Me.panel1.TabIndex = 3
		'
		'Pnl_Main
		'
		Me.Pnl_Main.Location = New System.Drawing.Point(347, 10)
		Me.Pnl_Main.Name = "Pnl_Main"
		Me.Pnl_Main.Size = New System.Drawing.Size(786, 645)
		Me.Pnl_Main.TabIndex = 4
		'
		'comboBox3
		'
		Me.comboBox3.FormattingEnabled = true
		Me.comboBox3.Location = New System.Drawing.Point(80, 156)
		Me.comboBox3.Name = "comboBox3"
		Me.comboBox3.Size = New System.Drawing.Size(56, 20)
		Me.comboBox3.TabIndex = 5
		'
		'textBox3
		'
		Me.textBox3.Location = New System.Drawing.Point(176, 156)
		Me.textBox3.Name = "textBox3"
		Me.textBox3.Size = New System.Drawing.Size(38, 19)
		Me.textBox3.TabIndex = 6
		'
		'comboBox4
		'
		Me.comboBox4.FormattingEnabled = true
		Me.comboBox4.Location = New System.Drawing.Point(276, 156)
		Me.comboBox4.Name = "comboBox4"
		Me.comboBox4.Size = New System.Drawing.Size(56, 20)
		Me.comboBox4.TabIndex = 7
		'
		'Lbl_Rate
		'
		Me.Lbl_Rate.Location = New System.Drawing.Point(21, 160)
		Me.Lbl_Rate.Name = "Lbl_Rate"
		Me.Lbl_Rate.Size = New System.Drawing.Size(62, 23)
		Me.Lbl_Rate.TabIndex = 12
		Me.Lbl_Rate.Text = "表示倍率："
		'
		'Lbl_Num
		'
		Me.Lbl_Num.Location = New System.Drawing.Point(140, 160)
		Me.Lbl_Num.Name = "Lbl_Num"
		Me.Lbl_Num.Size = New System.Drawing.Size(43, 18)
		Me.Lbl_Num.TabIndex = 13
		Me.Lbl_Num.Text = "部数："
		'
		'Lbl_Thick
		'
		Me.Lbl_Thick.Location = New System.Drawing.Point(217, 160)
		Me.Lbl_Thick.Name = "Lbl_Thick"
		Me.Lbl_Thick.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_Thick.TabIndex = 14
		Me.Lbl_Thick.Text = "印刷濃度："
		'
		'comboBox1
		'
		Me.comboBox1.FormattingEnabled = true
		Me.comboBox1.Location = New System.Drawing.Point(146, 31)
		Me.comboBox1.Name = "comboBox1"
		Me.comboBox1.Size = New System.Drawing.Size(134, 20)
		Me.comboBox1.TabIndex = 5
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(9, 177)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(81, 18)
		Me.label1.TabIndex = 13
		Me.label1.Text = "忌日："
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(9, 159)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(81, 18)
		Me.label2.TabIndex = 14
		Me.label2.Text = "供え物："
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(9, 141)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(81, 18)
		Me.label3.TabIndex = 15
		Me.label3.Text = "戒名："
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(9, 123)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(81, 18)
		Me.label4.TabIndex = 16
		Me.label4.Text = "時期２："
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(9, 105)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(81, 18)
		Me.label5.TabIndex = 17
		Me.label5.Text = "死亡告知："
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(9, 87)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(81, 18)
		Me.label6.TabIndex = 18
		Me.label6.Text = "俗名："
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(9, 69)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(81, 18)
		Me.label7.TabIndex = 19
		Me.label7.Text = "続柄："
		'
		'label8
		'
		Me.label8.Location = New System.Drawing.Point(9, 51)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(81, 18)
		Me.label8.TabIndex = 20
		Me.label8.Text = "時期１："
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(9, 33)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(81, 18)
		Me.label9.TabIndex = 21
		Me.label9.Text = "季語："
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(9, 15)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(81, 18)
		Me.label10.TabIndex = 22
		Me.label10.Text = "文例："
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(9, 339)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(81, 18)
		Me.label11.TabIndex = 23
		Me.label11.Text = "喪主名４："
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(9, 321)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(81, 18)
		Me.label12.TabIndex = 24
		Me.label12.Text = "喪主名３："
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(9, 303)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(81, 18)
		Me.label13.TabIndex = 25
		Me.label13.Text = "喪主名２："
		'
		'label14
		'
		Me.label14.Location = New System.Drawing.Point(9, 285)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(81, 18)
		Me.label14.TabIndex = 26
		Me.label14.Text = "喪主名："
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(9, 267)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(81, 18)
		Me.label15.TabIndex = 27
		Me.label15.Text = "施主・喪主："
		'
		'label16
		'
		Me.label16.Location = New System.Drawing.Point(9, 249)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(81, 18)
		Me.label16.TabIndex = 28
		Me.label16.Text = "住所２："
		'
		'label17
		'
		Me.label17.Location = New System.Drawing.Point(9, 231)
		Me.label17.Name = "label17"
		Me.label17.Size = New System.Drawing.Size(81, 18)
		Me.label17.TabIndex = 29
		Me.label17.Text = "住所１："
		'
		'label18
		'
		Me.label18.Location = New System.Drawing.Point(9, 213)
		Me.label18.Name = "label18"
		Me.label18.Size = New System.Drawing.Size(81, 18)
		Me.label18.TabIndex = 30
		Me.label18.Text = "法要年月日："
		'
		'label19
		'
		Me.label19.Location = New System.Drawing.Point(9, 195)
		Me.label19.Name = "label19"
		Me.label19.Size = New System.Drawing.Size(81, 18)
		Me.label19.TabIndex = 31
		Me.label19.Text = "結語："
		'
		'label24
		'
		Me.label24.Location = New System.Drawing.Point(9, 447)
		Me.label24.Name = "label24"
		Me.label24.Size = New System.Drawing.Size(81, 18)
		Me.label24.TabIndex = 36
		Me.label24.Text = "追伸６："
		'
		'label25
		'
		Me.label25.Location = New System.Drawing.Point(9, 429)
		Me.label25.Name = "label25"
		Me.label25.Size = New System.Drawing.Size(81, 18)
		Me.label25.TabIndex = 37
		Me.label25.Text = "追伸５："
		'
		'label26
		'
		Me.label26.Location = New System.Drawing.Point(9, 411)
		Me.label26.Name = "label26"
		Me.label26.Size = New System.Drawing.Size(81, 18)
		Me.label26.TabIndex = 38
		Me.label26.Text = "追伸４："
		'
		'label27
		'
		Me.label27.Location = New System.Drawing.Point(9, 393)
		Me.label27.Name = "label27"
		Me.label27.Size = New System.Drawing.Size(81, 18)
		Me.label27.TabIndex = 39
		Me.label27.Text = "追伸３："
		'
		'label28
		'
		Me.label28.Location = New System.Drawing.Point(9, 375)
		Me.label28.Name = "label28"
		Me.label28.Size = New System.Drawing.Size(81, 18)
		Me.label28.TabIndex = 40
		Me.label28.Text = "追伸２："
		'
		'label29
		'
		Me.label29.Location = New System.Drawing.Point(9, 357)
		Me.label29.Name = "label29"
		Me.label29.Size = New System.Drawing.Size(81, 18)
		Me.label29.TabIndex = 41
		Me.label29.Text = "追伸１："
		'
		'Print
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1142, 664)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.comboBox4)
		Me.Controls.Add(Me.textBox3)
		Me.Controls.Add(Me.comboBox3)
		Me.Controls.Add(Me.Pnl_Main)
		Me.Controls.Add(Me.Grb_Common)
		Me.Controls.Add(Me.Lbl_Thick)
		Me.Controls.Add(Me.Lbl_Num)
		Me.Controls.Add(Me.Lbl_Rate)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "Print"
		Me.Text = "Print"
		AddHandler Load, AddressOf Me.Print_Load
		Me.Grb_Common.ResumeLayout(false)
		Me.Grb_Common.PerformLayout
		Me.Grb_Contents.ResumeLayout(false)
		Me.panel1.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private Lbl_Thick As System.Windows.Forms.Label
	Private Lbl_Num As System.Windows.Forms.Label
	Private Lbl_Rate As System.Windows.Forms.Label
	Private comboBox1 As System.Windows.Forms.ComboBox
	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private label11 As System.Windows.Forms.Label
	Private label12 As System.Windows.Forms.Label
	Private label13 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private label15 As System.Windows.Forms.Label
	Private label16 As System.Windows.Forms.Label
	Private label17 As System.Windows.Forms.Label
	Private label18 As System.Windows.Forms.Label
	Private label19 As System.Windows.Forms.Label
	Private label24 As System.Windows.Forms.Label
	Private label25 As System.Windows.Forms.Label
	Private label26 As System.Windows.Forms.Label
	Private label27 As System.Windows.Forms.Label
	Private label28 As System.Windows.Forms.Label
	Private label29 As System.Windows.Forms.Label
	Private comboBox4 As System.Windows.Forms.ComboBox
	Private textBox3 As System.Windows.Forms.TextBox
	Private Lbl_Size As System.Windows.Forms.Label
	Private Lbl_SizeW As System.Windows.Forms.Label
	Private Lbl_SizeH As System.Windows.Forms.Label
	Private Lbl_PrintDir As System.Windows.Forms.Label
	Private Lbl_Font As System.Windows.Forms.Label
	Private Lbl_PosX As System.Windows.Forms.Label
	Private Lbl_PosY As System.Windows.Forms.Label
	Private Txt_SizeW As System.Windows.Forms.TextBox
	Private Txt_PrintDir As System.Windows.Forms.TextBox
	Private Txt_SizeY As System.Windows.Forms.TextBox
	Private comboBox3 As System.Windows.Forms.ComboBox
	Private Cmb_Size As System.Windows.Forms.ComboBox
	Private Cmb_Font As System.Windows.Forms.ComboBox
	Private Txt_PosX As System.Windows.Forms.TextBox
	Private Txt_PosY As System.Windows.Forms.TextBox
	Private Pnl_Main As System.Windows.Forms.Panel
	Private Grb_Contents As System.Windows.Forms.GroupBox
	Private Grb_Common As System.Windows.Forms.GroupBox
	Private panel1 As System.Windows.Forms.Panel
End Class
