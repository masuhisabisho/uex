'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/14
' 時刻: 23:49
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class HostRegister
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HostRegister))
		Me.Lbl_HostName = New System.Windows.Forms.Label()
		Me.Txt_HostName = New System.Windows.Forms.TextBox()
		Me.Txt_HostKana = New System.Windows.Forms.TextBox()
		Me.Txt_Zip = New System.Windows.Forms.TextBox()
		Me.Txt_Add = New System.Windows.Forms.TextBox()
		Me.Txt_Tel = New System.Windows.Forms.TextBox()
		Me.Txt_Fax = New System.Windows.Forms.TextBox()
		Me.Lbl_HostKana = New System.Windows.Forms.Label()
		Me.Lbl_Zip = New System.Windows.Forms.Label()
		Me.Lbl_Add = New System.Windows.Forms.Label()
		Me.Lbl_Tel = New System.Windows.Forms.Label()
		Me.Lbl_Fax = New System.Windows.Forms.Label()
		Me.Cmb_Style = New System.Windows.Forms.ComboBox()
		Me.Lbl_Style = New System.Windows.Forms.Label()
		Me.Lbl_DeadName = New System.Windows.Forms.Label()
		Me.Txt_DeadName = New System.Windows.Forms.TextBox()
		Me.Lbl_DeathDate = New System.Windows.Forms.Label()
		Me.Txt_Comment = New System.Windows.Forms.TextBox()
		Me.Lbl_Comment = New System.Windows.Forms.Label()
		Me.Dtp_DeathDate = New System.Windows.Forms.DateTimePicker()
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.label34 = New System.Windows.Forms.Label()
		Me.label33 = New System.Windows.Forms.Label()
		Me.label32 = New System.Windows.Forms.Label()
		Me.label31 = New System.Windows.Forms.Label()
		Me.label30 = New System.Windows.Forms.Label()
		Me.label29 = New System.Windows.Forms.Label()
		Me.label28 = New System.Windows.Forms.Label()
		Me.label27 = New System.Windows.Forms.Label()
		Me.label26 = New System.Windows.Forms.Label()
		Me.label25 = New System.Windows.Forms.Label()
		Me.label24 = New System.Windows.Forms.Label()
		Me.label23 = New System.Windows.Forms.Label()
		Me.label22 = New System.Windows.Forms.Label()
		Me.label21 = New System.Windows.Forms.Label()
		Me.label20 = New System.Windows.Forms.Label()
		Me.label19 = New System.Windows.Forms.Label()
		Me.label18 = New System.Windows.Forms.Label()
		Me.label17 = New System.Windows.Forms.Label()
		Me.label16 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.Btn_Print = New System.Windows.Forms.Button()
		Me.Btn_Register = New System.Windows.Forms.Button()
		Me.Btn_Close = New System.Windows.Forms.Button()
		Me.tableLayoutPanel1.SuspendLayout
		Me.SuspendLayout
		'
		'Lbl_HostName
		'
		Me.Lbl_HostName.Location = New System.Drawing.Point(12, 9)
		Me.Lbl_HostName.Name = "Lbl_HostName"
		Me.Lbl_HostName.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_HostName.TabIndex = 0
		Me.Lbl_HostName.Text = "施主名："
		'
		'Txt_HostName
		'
		Me.Txt_HostName.Location = New System.Drawing.Point(119, 9)
		Me.Txt_HostName.Name = "Txt_HostName"
		Me.Txt_HostName.Size = New System.Drawing.Size(100, 19)
		Me.Txt_HostName.TabIndex = 1
		'
		'Txt_HostKana
		'
		Me.Txt_HostKana.Location = New System.Drawing.Point(119, 36)
		Me.Txt_HostKana.Name = "Txt_HostKana"
		Me.Txt_HostKana.Size = New System.Drawing.Size(100, 19)
		Me.Txt_HostKana.TabIndex = 2
		'
		'Txt_Zip
		'
		Me.Txt_Zip.Location = New System.Drawing.Point(119, 63)
		Me.Txt_Zip.Name = "Txt_Zip"
		Me.Txt_Zip.Size = New System.Drawing.Size(100, 19)
		Me.Txt_Zip.TabIndex = 3
		'
		'Txt_Add
		'
		Me.Txt_Add.Location = New System.Drawing.Point(119, 90)
		Me.Txt_Add.Name = "Txt_Add"
		Me.Txt_Add.Size = New System.Drawing.Size(100, 19)
		Me.Txt_Add.TabIndex = 4
		'
		'Txt_Tel
		'
		Me.Txt_Tel.Location = New System.Drawing.Point(119, 117)
		Me.Txt_Tel.Name = "Txt_Tel"
		Me.Txt_Tel.Size = New System.Drawing.Size(100, 19)
		Me.Txt_Tel.TabIndex = 5
		'
		'Txt_Fax
		'
		Me.Txt_Fax.Location = New System.Drawing.Point(119, 144)
		Me.Txt_Fax.Name = "Txt_Fax"
		Me.Txt_Fax.Size = New System.Drawing.Size(100, 19)
		Me.Txt_Fax.TabIndex = 6
		'
		'Lbl_HostKana
		'
		Me.Lbl_HostKana.Location = New System.Drawing.Point(12, 36)
		Me.Lbl_HostKana.Name = "Lbl_HostKana"
		Me.Lbl_HostKana.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_HostKana.TabIndex = 7
		Me.Lbl_HostKana.Text = "施主名カナ："
		'
		'Lbl_Zip
		'
		Me.Lbl_Zip.Location = New System.Drawing.Point(13, 63)
		Me.Lbl_Zip.Name = "Lbl_Zip"
		Me.Lbl_Zip.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Zip.TabIndex = 8
		Me.Lbl_Zip.Text = "郵便番号："
		'
		'Lbl_Add
		'
		Me.Lbl_Add.Location = New System.Drawing.Point(12, 90)
		Me.Lbl_Add.Name = "Lbl_Add"
		Me.Lbl_Add.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Add.TabIndex = 9
		Me.Lbl_Add.Text = "住所："
		'
		'Lbl_Tel
		'
		Me.Lbl_Tel.Location = New System.Drawing.Point(12, 117)
		Me.Lbl_Tel.Name = "Lbl_Tel"
		Me.Lbl_Tel.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Tel.TabIndex = 10
		Me.Lbl_Tel.Text = "電話番号："
		'
		'Lbl_Fax
		'
		Me.Lbl_Fax.Location = New System.Drawing.Point(12, 144)
		Me.Lbl_Fax.Name = "Lbl_Fax"
		Me.Lbl_Fax.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Fax.TabIndex = 11
		Me.Lbl_Fax.Text = "FAX番号："
		'
		'Cmb_Style
		'
		Me.Cmb_Style.FormattingEnabled = true
		Me.Cmb_Style.Location = New System.Drawing.Point(119, 171)
		Me.Cmb_Style.Name = "Cmb_Style"
		Me.Cmb_Style.Size = New System.Drawing.Size(121, 20)
		Me.Cmb_Style.TabIndex = 12
		'
		'Lbl_Style
		'
		Me.Lbl_Style.Location = New System.Drawing.Point(12, 171)
		Me.Lbl_Style.Name = "Lbl_Style"
		Me.Lbl_Style.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Style.TabIndex = 13
		Me.Lbl_Style.Text = "式"
		'
		'Lbl_DeadName
		'
		Me.Lbl_DeadName.Location = New System.Drawing.Point(12, 198)
		Me.Lbl_DeadName.Name = "Lbl_DeadName"
		Me.Lbl_DeadName.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_DeadName.TabIndex = 15
		Me.Lbl_DeadName.Text = "戒名："
		'
		'Txt_DeadName
		'
		Me.Txt_DeadName.Location = New System.Drawing.Point(119, 199)
		Me.Txt_DeadName.Name = "Txt_DeadName"
		Me.Txt_DeadName.Size = New System.Drawing.Size(100, 19)
		Me.Txt_DeadName.TabIndex = 14
		'
		'Lbl_DeathDate
		'
		Me.Lbl_DeathDate.Location = New System.Drawing.Point(12, 225)
		Me.Lbl_DeathDate.Name = "Lbl_DeathDate"
		Me.Lbl_DeathDate.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_DeathDate.TabIndex = 16
		Me.Lbl_DeathDate.Text = "命日："
		'
		'Txt_Comment
		'
		Me.Txt_Comment.Location = New System.Drawing.Point(119, 251)
		Me.Txt_Comment.Name = "Txt_Comment"
		Me.Txt_Comment.Size = New System.Drawing.Size(100, 19)
		Me.Txt_Comment.TabIndex = 19
		'
		'Lbl_Comment
		'
		Me.Lbl_Comment.Location = New System.Drawing.Point(12, 250)
		Me.Lbl_Comment.Name = "Lbl_Comment"
		Me.Lbl_Comment.Size = New System.Drawing.Size(100, 23)
		Me.Lbl_Comment.TabIndex = 18
		Me.Lbl_Comment.Text = "コメント："
		'
		'Dtp_DeathDate
		'
		Me.Dtp_DeathDate.Location = New System.Drawing.Point(118, 225)
		Me.Dtp_DeathDate.Name = "Dtp_DeathDate"
		Me.Dtp_DeathDate.Size = New System.Drawing.Size(122, 19)
		Me.Dtp_DeathDate.TabIndex = 20
		'
		'tableLayoutPanel1
		'
		Me.tableLayoutPanel1.ColumnCount = 2
		Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
		Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
		Me.tableLayoutPanel1.Controls.Add(Me.label34, 1, 16)
		Me.tableLayoutPanel1.Controls.Add(Me.label33, 0, 16)
		Me.tableLayoutPanel1.Controls.Add(Me.label32, 1, 15)
		Me.tableLayoutPanel1.Controls.Add(Me.label31, 0, 15)
		Me.tableLayoutPanel1.Controls.Add(Me.label30, 1, 14)
		Me.tableLayoutPanel1.Controls.Add(Me.label29, 0, 14)
		Me.tableLayoutPanel1.Controls.Add(Me.label28, 1, 13)
		Me.tableLayoutPanel1.Controls.Add(Me.label27, 0, 13)
		Me.tableLayoutPanel1.Controls.Add(Me.label26, 1, 12)
		Me.tableLayoutPanel1.Controls.Add(Me.label25, 0, 12)
		Me.tableLayoutPanel1.Controls.Add(Me.label24, 1, 11)
		Me.tableLayoutPanel1.Controls.Add(Me.label23, 0, 11)
		Me.tableLayoutPanel1.Controls.Add(Me.label22, 1, 10)
		Me.tableLayoutPanel1.Controls.Add(Me.label21, 0, 10)
		Me.tableLayoutPanel1.Controls.Add(Me.label20, 1, 9)
		Me.tableLayoutPanel1.Controls.Add(Me.label19, 0, 9)
		Me.tableLayoutPanel1.Controls.Add(Me.label18, 1, 8)
		Me.tableLayoutPanel1.Controls.Add(Me.label17, 0, 8)
		Me.tableLayoutPanel1.Controls.Add(Me.label16, 1, 7)
		Me.tableLayoutPanel1.Controls.Add(Me.label15, 0, 7)
		Me.tableLayoutPanel1.Controls.Add(Me.label14, 1, 6)
		Me.tableLayoutPanel1.Controls.Add(Me.label2, 1, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.label13, 0, 6)
		Me.tableLayoutPanel1.Controls.Add(Me.label12, 1, 5)
		Me.tableLayoutPanel1.Controls.Add(Me.label11, 0, 5)
		Me.tableLayoutPanel1.Controls.Add(Me.label10, 1, 4)
		Me.tableLayoutPanel1.Controls.Add(Me.label9, 0, 4)
		Me.tableLayoutPanel1.Controls.Add(Me.label8, 1, 3)
		Me.tableLayoutPanel1.Controls.Add(Me.label7, 0, 3)
		Me.tableLayoutPanel1.Controls.Add(Me.label6, 1, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.label5, 0, 2)
		Me.tableLayoutPanel1.Controls.Add(Me.label4, 1, 1)
		Me.tableLayoutPanel1.Controls.Add(Me.label1, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 1)
		Me.tableLayoutPanel1.Location = New System.Drawing.Point(246, 6)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		Me.tableLayoutPanel1.RowCount = 17
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.tableLayoutPanel1.Size = New System.Drawing.Size(217, 340)
		Me.tableLayoutPanel1.TabIndex = 21
		'
		'label34
		'
		Me.label34.Location = New System.Drawing.Point(109, 320)
		Me.label34.Name = "label34"
		Me.label34.Size = New System.Drawing.Size(94, 20)
		Me.label34.TabIndex = 33
		Me.label34.Text = "label34"
		'
		'label33
		'
		Me.label33.Location = New System.Drawing.Point(3, 320)
		Me.label33.Name = "label33"
		Me.label33.Size = New System.Drawing.Size(94, 20)
		Me.label33.TabIndex = 32
		Me.label33.Text = "二十三回忌"
		'
		'label32
		'
		Me.label32.Location = New System.Drawing.Point(109, 300)
		Me.label32.Name = "label32"
		Me.label32.Size = New System.Drawing.Size(94, 20)
		Me.label32.TabIndex = 31
		Me.label32.Text = "label32"
		'
		'label31
		'
		Me.label31.Location = New System.Drawing.Point(3, 300)
		Me.label31.Name = "label31"
		Me.label31.Size = New System.Drawing.Size(94, 20)
		Me.label31.TabIndex = 30
		Me.label31.Text = "十七回忌"
		'
		'label30
		'
		Me.label30.Location = New System.Drawing.Point(109, 280)
		Me.label30.Name = "label30"
		Me.label30.Size = New System.Drawing.Size(94, 20)
		Me.label30.TabIndex = 29
		Me.label30.Text = "label30"
		'
		'label29
		'
		Me.label29.Location = New System.Drawing.Point(3, 280)
		Me.label29.Name = "label29"
		Me.label29.Size = New System.Drawing.Size(94, 20)
		Me.label29.TabIndex = 28
		Me.label29.Text = "十三回忌"
		'
		'label28
		'
		Me.label28.Location = New System.Drawing.Point(109, 260)
		Me.label28.Name = "label28"
		Me.label28.Size = New System.Drawing.Size(94, 20)
		Me.label28.TabIndex = 27
		Me.label28.Text = "label28"
		'
		'label27
		'
		Me.label27.Location = New System.Drawing.Point(3, 260)
		Me.label27.Name = "label27"
		Me.label27.Size = New System.Drawing.Size(94, 20)
		Me.label27.TabIndex = 26
		Me.label27.Text = "七回忌"
		'
		'label26
		'
		Me.label26.Location = New System.Drawing.Point(109, 240)
		Me.label26.Name = "label26"
		Me.label26.Size = New System.Drawing.Size(94, 20)
		Me.label26.TabIndex = 25
		Me.label26.Text = "label26"
		'
		'label25
		'
		Me.label25.Location = New System.Drawing.Point(3, 240)
		Me.label25.Name = "label25"
		Me.label25.Size = New System.Drawing.Size(94, 20)
		Me.label25.TabIndex = 24
		Me.label25.Text = "三回忌"
		'
		'label24
		'
		Me.label24.Location = New System.Drawing.Point(109, 220)
		Me.label24.Name = "label24"
		Me.label24.Size = New System.Drawing.Size(94, 20)
		Me.label24.TabIndex = 23
		Me.label24.Text = "label24"
		'
		'label23
		'
		Me.label23.Location = New System.Drawing.Point(3, 220)
		Me.label23.Name = "label23"
		Me.label23.Size = New System.Drawing.Size(94, 20)
		Me.label23.TabIndex = 22
		Me.label23.Text = "一周忌"
		'
		'label22
		'
		Me.label22.Location = New System.Drawing.Point(109, 200)
		Me.label22.Name = "label22"
		Me.label22.Size = New System.Drawing.Size(94, 20)
		Me.label22.TabIndex = 21
		Me.label22.Text = "label22"
		'
		'label21
		'
		Me.label21.Location = New System.Drawing.Point(3, 200)
		Me.label21.Name = "label21"
		Me.label21.Size = New System.Drawing.Size(94, 20)
		Me.label21.TabIndex = 20
		Me.label21.Text = "百か日"
		'
		'label20
		'
		Me.label20.Location = New System.Drawing.Point(109, 180)
		Me.label20.Name = "label20"
		Me.label20.Size = New System.Drawing.Size(94, 20)
		Me.label20.TabIndex = 19
		Me.label20.Text = "label20"
		'
		'label19
		'
		Me.label19.Location = New System.Drawing.Point(3, 180)
		Me.label19.Name = "label19"
		Me.label19.Size = New System.Drawing.Size(94, 20)
		Me.label19.TabIndex = 18
		Me.label19.Text = "初盆"
		'
		'label18
		'
		Me.label18.Location = New System.Drawing.Point(109, 160)
		Me.label18.Name = "label18"
		Me.label18.Size = New System.Drawing.Size(94, 20)
		Me.label18.TabIndex = 17
		Me.label18.Text = "label18"
		'
		'label17
		'
		Me.label17.Location = New System.Drawing.Point(3, 160)
		Me.label17.Name = "label17"
		Me.label17.Size = New System.Drawing.Size(94, 20)
		Me.label17.TabIndex = 16
		Me.label17.Text = "祥月命日"
		'
		'label16
		'
		Me.label16.Location = New System.Drawing.Point(109, 140)
		Me.label16.Name = "label16"
		Me.label16.Size = New System.Drawing.Size(94, 20)
		Me.label16.TabIndex = 15
		Me.label16.Text = "label16"
		'
		'label15
		'
		Me.label15.Location = New System.Drawing.Point(3, 140)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(94, 20)
		Me.label15.TabIndex = 14
		Me.label15.Text = "七七日"
		'
		'label14
		'
		Me.label14.Location = New System.Drawing.Point(109, 120)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(94, 20)
		Me.label14.TabIndex = 13
		Me.label14.Text = "label14"
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(109, 0)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(94, 20)
		Me.label2.TabIndex = 1
		Me.label2.Text = "日時"
		'
		'label13
		'
		Me.label13.Location = New System.Drawing.Point(3, 120)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(94, 20)
		Me.label13.TabIndex = 12
		Me.label13.Text = "六七日"
		'
		'label12
		'
		Me.label12.Location = New System.Drawing.Point(109, 100)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(94, 20)
		Me.label12.TabIndex = 11
		Me.label12.Text = "label12"
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(3, 100)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(94, 20)
		Me.label11.TabIndex = 10
		Me.label11.Text = "五七日"
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(109, 80)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(94, 20)
		Me.label10.TabIndex = 9
		Me.label10.Text = "label10"
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(3, 80)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(94, 20)
		Me.label9.TabIndex = 8
		Me.label9.Text = "四七日"
		'
		'label8
		'
		Me.label8.Location = New System.Drawing.Point(109, 60)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(94, 20)
		Me.label8.TabIndex = 7
		Me.label8.Text = "label8"
		'
		'label7
		'
		Me.label7.Location = New System.Drawing.Point(3, 60)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(94, 20)
		Me.label7.TabIndex = 6
		Me.label7.Text = "三七日"
		'
		'label6
		'
		Me.label6.Location = New System.Drawing.Point(109, 40)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(94, 20)
		Me.label6.TabIndex = 5
		Me.label6.Text = "label6"
		'
		'label5
		'
		Me.label5.Location = New System.Drawing.Point(3, 40)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(94, 20)
		Me.label5.TabIndex = 4
		Me.label5.Text = "二七日"
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(109, 20)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(94, 20)
		Me.label4.TabIndex = 3
		Me.label4.Text = "label4"
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(3, 0)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(100, 20)
		Me.label1.TabIndex = 0
		Me.label1.Text = "法事名"
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(3, 20)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(94, 20)
		Me.label3.TabIndex = 2
		Me.label3.Text = "初七日"
		'
		'Btn_Print
		'
		Me.Btn_Print.Location = New System.Drawing.Point(37, 358)
		Me.Btn_Print.Name = "Btn_Print"
		Me.Btn_Print.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Print.TabIndex = 22
		Me.Btn_Print.Text = "印刷"
		Me.Btn_Print.UseVisualStyleBackColor = true
		'
		'Btn_Register
		'
		Me.Btn_Register.Location = New System.Drawing.Point(231, 358)
		Me.Btn_Register.Name = "Btn_Register"
		Me.Btn_Register.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Register.TabIndex = 23
		Me.Btn_Register.Text = "登録"
		Me.Btn_Register.UseVisualStyleBackColor = true
		'
		'Btn_Close
		'
		Me.Btn_Close.Location = New System.Drawing.Point(362, 358)
		Me.Btn_Close.Name = "Btn_Close"
		Me.Btn_Close.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Close.TabIndex = 24
		Me.Btn_Close.Text = "戻る"
		Me.Btn_Close.UseVisualStyleBackColor = true
		'
		'HostRegister
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(466, 393)
		Me.Controls.Add(Me.Btn_Close)
		Me.Controls.Add(Me.Btn_Register)
		Me.Controls.Add(Me.Btn_Print)
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.Controls.Add(Me.Dtp_DeathDate)
		Me.Controls.Add(Me.Txt_Comment)
		Me.Controls.Add(Me.Lbl_Comment)
		Me.Controls.Add(Me.Lbl_DeathDate)
		Me.Controls.Add(Me.Lbl_DeadName)
		Me.Controls.Add(Me.Txt_DeadName)
		Me.Controls.Add(Me.Lbl_Style)
		Me.Controls.Add(Me.Cmb_Style)
		Me.Controls.Add(Me.Lbl_Fax)
		Me.Controls.Add(Me.Lbl_Tel)
		Me.Controls.Add(Me.Lbl_Add)
		Me.Controls.Add(Me.Lbl_Zip)
		Me.Controls.Add(Me.Lbl_HostKana)
		Me.Controls.Add(Me.Txt_Fax)
		Me.Controls.Add(Me.Txt_Tel)
		Me.Controls.Add(Me.Txt_Add)
		Me.Controls.Add(Me.Txt_Zip)
		Me.Controls.Add(Me.Txt_HostKana)
		Me.Controls.Add(Me.Txt_HostName)
		Me.Controls.Add(Me.Lbl_HostName)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "HostRegister"
		Me.Text = "HostRegister"
		AddHandler Load, AddressOf Me.HostRegisterLoad
		Me.tableLayoutPanel1.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private Btn_Close As System.Windows.Forms.Button
	Private Btn_Register As System.Windows.Forms.Button
	Private Btn_Print As System.Windows.Forms.Button
	Private label3 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
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
	Private label2 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private label15 As System.Windows.Forms.Label
	Private label16 As System.Windows.Forms.Label
	Private label17 As System.Windows.Forms.Label
	Private label18 As System.Windows.Forms.Label
	Private label19 As System.Windows.Forms.Label
	Private label20 As System.Windows.Forms.Label
	Private label21 As System.Windows.Forms.Label
	Private label22 As System.Windows.Forms.Label
	Private label23 As System.Windows.Forms.Label
	Private label24 As System.Windows.Forms.Label
	Private label25 As System.Windows.Forms.Label
	Private label26 As System.Windows.Forms.Label
	Private label27 As System.Windows.Forms.Label
	Private label28 As System.Windows.Forms.Label
	Private label29 As System.Windows.Forms.Label
	Private label30 As System.Windows.Forms.Label
	Private label31 As System.Windows.Forms.Label
	Private label32 As System.Windows.Forms.Label
	Private label33 As System.Windows.Forms.Label
	Private label34 As System.Windows.Forms.Label
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private Dtp_DeathDate As System.Windows.Forms.DateTimePicker
	Private Lbl_Comment As System.Windows.Forms.Label
	Private Txt_Comment As System.Windows.Forms.TextBox
	Private Lbl_DeathDate As System.Windows.Forms.Label
	Private Txt_DeadName As System.Windows.Forms.TextBox
	Private Lbl_DeadName As System.Windows.Forms.Label
	Private Lbl_Style As System.Windows.Forms.Label
	Private Cmb_Style As System.Windows.Forms.ComboBox
	Private Lbl_Fax As System.Windows.Forms.Label
	Private Lbl_Tel As System.Windows.Forms.Label
	Private Lbl_Add As System.Windows.Forms.Label
	Private Lbl_Zip As System.Windows.Forms.Label
	Private Lbl_HostKana As System.Windows.Forms.Label
	Private Txt_Fax As System.Windows.Forms.TextBox
	Private Txt_Tel As System.Windows.Forms.TextBox
	Private Txt_Add As System.Windows.Forms.TextBox
	Private Txt_Zip As System.Windows.Forms.TextBox
	Private Txt_HostKana As System.Windows.Forms.TextBox
	Private Txt_HostName As System.Windows.Forms.TextBox
	Private Lbl_HostName As System.Windows.Forms.Label
End Class
