'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class PrintReport
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintReport))
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
		Me.Btn_Dtp = New System.Windows.Forms.Button()
		Me.Lbl_Month = New System.Windows.Forms.Label()
		Me.Lbl_Day = New System.Windows.Forms.Label()
		Me.Lbl_year = New System.Windows.Forms.Label()
		Me.Cmb_Day = New System.Windows.Forms.ComboBox()
		Me.Cmb_Month = New System.Windows.Forms.ComboBox()
		Me.Cmb_Year = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHostName3 = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHostName4 = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointPS1 = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointName = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointDeadName = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointImibi = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointEndWord = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointCeremonyDate = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointAdd1 = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHostType = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHostName1 = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHostName2 = New System.Windows.Forms.ComboBox()
		Me.Txt_PS3 = New System.Windows.Forms.TextBox()
		Me.Txt_PS6 = New System.Windows.Forms.TextBox()
		Me.Txt_PS2 = New System.Windows.Forms.TextBox()
		Me.Txt_PS5 = New System.Windows.Forms.TextBox()
		Me.Txt_HostName1 = New System.Windows.Forms.TextBox()
		Me.Txt_PS4 = New System.Windows.Forms.TextBox()
		Me.Txt_HostName2 = New System.Windows.Forms.TextBox()
		Me.Txt_HostName3 = New System.Windows.Forms.TextBox()
		Me.Txt_HostName4 = New System.Windows.Forms.TextBox()
		Me.Cmb_PointTitle = New System.Windows.Forms.ComboBox()
		Me.Txt_PS1 = New System.Windows.Forms.TextBox()
		Me.Cmb_HostType = New System.Windows.Forms.ComboBox()
		Me.Txt_Add1 = New System.Windows.Forms.TextBox()
		Me.Txt_Add2 = New System.Windows.Forms.TextBox()
		Me.Cmb_EndWord = New System.Windows.Forms.ComboBox()
		Me.Cmb_Imibi = New System.Windows.Forms.ComboBox()
		Me.Cmb_Donation = New System.Windows.Forms.ComboBox()
		Me.Txt_DeadName = New System.Windows.Forms.TextBox()
		Me.Cmb_Time2 = New System.Windows.Forms.ComboBox()
		Me.Cmb_Style = New System.Windows.Forms.ComboBox()
		Me.Cmb_SeasonWord = New System.Windows.Forms.ComboBox()
		Me.Cmb_Time1 = New System.Windows.Forms.ComboBox()
		Me.Cmb_DeathWay = New System.Windows.Forms.ComboBox()
		Me.Txt_Name = New System.Windows.Forms.TextBox()
		Me.Cmb_Title = New System.Windows.Forms.ComboBox()
		Me.Lbl_PS1 = New System.Windows.Forms.Label()
		Me.Lbl_PS2 = New System.Windows.Forms.Label()
		Me.Lbl_PS3 = New System.Windows.Forms.Label()
		Me.Lbl_PS4 = New System.Windows.Forms.Label()
		Me.Lbl_PS5 = New System.Windows.Forms.Label()
		Me.Lbl_PS6 = New System.Windows.Forms.Label()
		Me.Lbl_EndWord = New System.Windows.Forms.Label()
		Me.Lbl_CeremonyDate = New System.Windows.Forms.Label()
		Me.Lbl_Add1 = New System.Windows.Forms.Label()
		Me.Lbl_Add2 = New System.Windows.Forms.Label()
		Me.Lbl_HostType = New System.Windows.Forms.Label()
		Me.Lbl_HostName1 = New System.Windows.Forms.Label()
		Me.Lbl_HostName2 = New System.Windows.Forms.Label()
		Me.Lbl_HostName3 = New System.Windows.Forms.Label()
		Me.Lbl_HostName4 = New System.Windows.Forms.Label()
		Me.Lbl_Style = New System.Windows.Forms.Label()
		Me.Lbl_SeasonWord = New System.Windows.Forms.Label()
		Me.Lbl_Time1 = New System.Windows.Forms.Label()
		Me.Lbl_Title = New System.Windows.Forms.Label()
		Me.Lbl_Name = New System.Windows.Forms.Label()
		Me.Lbl_DeathWay = New System.Windows.Forms.Label()
		Me.Lbl_Time2 = New System.Windows.Forms.Label()
		Me.Lbl_DeadName = New System.Windows.Forms.Label()
		Me.Lbl_Donation = New System.Windows.Forms.Label()
		Me.Lbl_Imibi = New System.Windows.Forms.Label()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.Cmb_Magnify = New System.Windows.Forms.ComboBox()
		Me.Txt_Copy = New System.Windows.Forms.TextBox()
		Me.Cmb_Thickness = New System.Windows.Forms.ComboBox()
		Me.Lbl_Rate = New System.Windows.Forms.Label()
		Me.Lbl_Num = New System.Windows.Forms.Label()
		Me.Lbl_Thick = New System.Windows.Forms.Label()
		Me.Pic_Main = New System.Windows.Forms.PictureBox()
		Me.panel2 = New System.Windows.Forms.Panel()
		Me.Grb_Common.SuspendLayout
		Me.Grb_Contents.SuspendLayout
		Me.panel1.SuspendLayout
		CType(Me.Pic_Main,System.ComponentModel.ISupportInitialize).BeginInit
		Me.panel2.SuspendLayout
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
		Me.Grb_Common.Size = New System.Drawing.Size(354, 148)
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
		Me.Lbl_PosX.Location = New System.Drawing.Point(7, 123)
		Me.Lbl_PosX.Name = "Lbl_PosX"
		Me.Lbl_PosX.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PosX.TabIndex = 12
		Me.Lbl_PosX.Text = "印刷位置（X)："
		'
		'Lbl_Font
		'
		Me.Lbl_Font.Location = New System.Drawing.Point(7, 98)
		Me.Lbl_Font.Name = "Lbl_Font"
		Me.Lbl_Font.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_Font.TabIndex = 11
		Me.Lbl_Font.Text = "フォント："
		'
		'Lbl_PrintDir
		'
		Me.Lbl_PrintDir.Location = New System.Drawing.Point(7, 77)
		Me.Lbl_PrintDir.Name = "Lbl_PrintDir"
		Me.Lbl_PrintDir.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_PrintDir.TabIndex = 10
		Me.Lbl_PrintDir.Text = "印刷方向："
		'
		'Lbl_SizeH
		'
		Me.Lbl_SizeH.Location = New System.Drawing.Point(7, 57)
		Me.Lbl_SizeH.Name = "Lbl_SizeH"
		Me.Lbl_SizeH.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_SizeH.TabIndex = 9
		Me.Lbl_SizeH.Text = "用紙（高さ）："
		'
		'Lbl_SizeW
		'
		Me.Lbl_SizeW.Location = New System.Drawing.Point(7, 37)
		Me.Lbl_SizeW.Name = "Lbl_SizeW"
		Me.Lbl_SizeW.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_SizeW.TabIndex = 8
		Me.Lbl_SizeW.Text = "用紙（幅）："
		'
		'Lbl_Size
		'
		Me.Lbl_Size.Location = New System.Drawing.Point(7, 18)
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
		Me.Grb_Contents.Controls.Add(Me.Btn_Dtp)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Month)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Day)
		Me.Grb_Contents.Controls.Add(Me.Lbl_year)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Day)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Month)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Year)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHostName3)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHostName4)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointPS1)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointName)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointDeadName)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointImibi)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointEndWord)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointCeremonyDate)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointAdd1)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHostType)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHostName1)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHostName2)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS3)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS6)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS2)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS5)
		Me.Grb_Contents.Controls.Add(Me.Txt_HostName1)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS4)
		Me.Grb_Contents.Controls.Add(Me.Txt_HostName2)
		Me.Grb_Contents.Controls.Add(Me.Txt_HostName3)
		Me.Grb_Contents.Controls.Add(Me.Txt_HostName4)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointTitle)
		Me.Grb_Contents.Controls.Add(Me.Txt_PS1)
		Me.Grb_Contents.Controls.Add(Me.Cmb_HostType)
		Me.Grb_Contents.Controls.Add(Me.Txt_Add1)
		Me.Grb_Contents.Controls.Add(Me.Txt_Add2)
		Me.Grb_Contents.Controls.Add(Me.Cmb_EndWord)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Imibi)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Donation)
		Me.Grb_Contents.Controls.Add(Me.Txt_DeadName)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Time2)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Style)
		Me.Grb_Contents.Controls.Add(Me.Cmb_SeasonWord)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Time1)
		Me.Grb_Contents.Controls.Add(Me.Cmb_DeathWay)
		Me.Grb_Contents.Controls.Add(Me.Txt_Name)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Title)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS1)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS2)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS3)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS4)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS5)
		Me.Grb_Contents.Controls.Add(Me.Lbl_PS6)
		Me.Grb_Contents.Controls.Add(Me.Lbl_EndWord)
		Me.Grb_Contents.Controls.Add(Me.Lbl_CeremonyDate)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Add1)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Add2)
		Me.Grb_Contents.Controls.Add(Me.Lbl_HostType)
		Me.Grb_Contents.Controls.Add(Me.Lbl_HostName1)
		Me.Grb_Contents.Controls.Add(Me.Lbl_HostName2)
		Me.Grb_Contents.Controls.Add(Me.Lbl_HostName3)
		Me.Grb_Contents.Controls.Add(Me.Lbl_HostName4)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Style)
		Me.Grb_Contents.Controls.Add(Me.Lbl_SeasonWord)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Time1)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Title)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Name)
		Me.Grb_Contents.Controls.Add(Me.Lbl_DeathWay)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Time2)
		Me.Grb_Contents.Controls.Add(Me.Lbl_DeadName)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Donation)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Imibi)
		Me.Grb_Contents.Location = New System.Drawing.Point(6, 3)
		Me.Grb_Contents.Name = "Grb_Contents"
		Me.Grb_Contents.Size = New System.Drawing.Size(348, 503)
		Me.Grb_Contents.TabIndex = 2
		Me.Grb_Contents.TabStop = false
		Me.Grb_Contents.Text = "内容設定"
		'
		'Btn_Dtp
		'
		Me.Btn_Dtp.Image = CType(resources.GetObject("Btn_Dtp.Image"),System.Drawing.Image)
		Me.Btn_Dtp.Location = New System.Drawing.Point(319, 230)
		Me.Btn_Dtp.Name = "Btn_Dtp"
		Me.Btn_Dtp.Size = New System.Drawing.Size(24, 20)
		Me.Btn_Dtp.TabIndex = 101
		Me.Btn_Dtp.UseVisualStyleBackColor = true
		AddHandler Me.Btn_Dtp.Click, AddressOf Me.Btn_Dtp_Click
		'
		'Lbl_Month
		'
		Me.Lbl_Month.Location = New System.Drawing.Point(183, 231)
		Me.Lbl_Month.Name = "Lbl_Month"
		Me.Lbl_Month.Size = New System.Drawing.Size(17, 14)
		Me.Lbl_Month.TabIndex = 100
		Me.Lbl_Month.Text = "月"
		Me.Lbl_Month.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Lbl_Day
		'
		Me.Lbl_Day.Location = New System.Drawing.Point(239, 231)
		Me.Lbl_Day.Name = "Lbl_Day"
		Me.Lbl_Day.Size = New System.Drawing.Size(14, 14)
		Me.Lbl_Day.TabIndex = 99
		Me.Lbl_Day.Text = "日"
		Me.Lbl_Day.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Lbl_year
		'
		Me.Lbl_year.Location = New System.Drawing.Point(125, 231)
		Me.Lbl_year.Name = "Lbl_year"
		Me.Lbl_year.Size = New System.Drawing.Size(17, 14)
		Me.Lbl_year.TabIndex = 98
		Me.Lbl_year.Text = "年"
		Me.Lbl_year.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Cmb_Day
		'
		Me.Cmb_Day.FormattingEnabled = true
		Me.Cmb_Day.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Day.Location = New System.Drawing.Point(201, 228)
		Me.Cmb_Day.Name = "Cmb_Day"
		Me.Cmb_Day.Size = New System.Drawing.Size(36, 20)
		Me.Cmb_Day.TabIndex = 97
		'
		'Cmb_Month
		'
		Me.Cmb_Month.FormattingEnabled = true
		Me.Cmb_Month.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Month.Location = New System.Drawing.Point(144, 228)
		Me.Cmb_Month.Name = "Cmb_Month"
		Me.Cmb_Month.Size = New System.Drawing.Size(36, 20)
		Me.Cmb_Month.TabIndex = 96
		'
		'Cmb_Year
		'
		Me.Cmb_Year.FormattingEnabled = true
		Me.Cmb_Year.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Year.Location = New System.Drawing.Point(75, 228)
		Me.Cmb_Year.Name = "Cmb_Year"
		Me.Cmb_Year.Size = New System.Drawing.Size(49, 20)
		Me.Cmb_Year.TabIndex = 95
		'
		'Cmb_PointHostName3
		'
		Me.Cmb_PointHostName3.FormattingEnabled = true
		Me.Cmb_PointHostName3.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName3.Location = New System.Drawing.Point(260, 343)
		Me.Cmb_PointHostName3.Name = "Cmb_PointHostName3"
		Me.Cmb_PointHostName3.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName3.TabIndex = 93
		'
		'Cmb_PointHostName4
		'
		Me.Cmb_PointHostName4.FormattingEnabled = true
		Me.Cmb_PointHostName4.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName4.Location = New System.Drawing.Point(260, 363)
		Me.Cmb_PointHostName4.Name = "Cmb_PointHostName4"
		Me.Cmb_PointHostName4.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName4.TabIndex = 92
		'
		'Cmb_PointPS1
		'
		Me.Cmb_PointPS1.FormattingEnabled = true
		Me.Cmb_PointPS1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointPS1.Location = New System.Drawing.Point(260, 382)
		Me.Cmb_PointPS1.Name = "Cmb_PointPS1"
		Me.Cmb_PointPS1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointPS1.TabIndex = 91
		'
		'Cmb_PointName
		'
		Me.Cmb_PointName.FormattingEnabled = true
		Me.Cmb_PointName.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointName.Location = New System.Drawing.Point(260, 89)
		Me.Cmb_PointName.Name = "Cmb_PointName"
		Me.Cmb_PointName.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointName.TabIndex = 90
		'
		'Cmb_PointDeadName
		'
		Me.Cmb_PointDeadName.FormattingEnabled = true
		Me.Cmb_PointDeadName.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointDeadName.Location = New System.Drawing.Point(260, 148)
		Me.Cmb_PointDeadName.Name = "Cmb_PointDeadName"
		Me.Cmb_PointDeadName.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointDeadName.TabIndex = 89
		'
		'Cmb_PointImibi
		'
		Me.Cmb_PointImibi.FormattingEnabled = true
		Me.Cmb_PointImibi.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointImibi.Location = New System.Drawing.Point(260, 188)
		Me.Cmb_PointImibi.Name = "Cmb_PointImibi"
		Me.Cmb_PointImibi.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointImibi.TabIndex = 88
		'
		'Cmb_PointEndWord
		'
		Me.Cmb_PointEndWord.FormattingEnabled = true
		Me.Cmb_PointEndWord.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointEndWord.Location = New System.Drawing.Point(260, 208)
		Me.Cmb_PointEndWord.Name = "Cmb_PointEndWord"
		Me.Cmb_PointEndWord.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointEndWord.TabIndex = 87
		'
		'Cmb_PointCeremonyDate
		'
		Me.Cmb_PointCeremonyDate.FormattingEnabled = true
		Me.Cmb_PointCeremonyDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointCeremonyDate.Location = New System.Drawing.Point(260, 228)
		Me.Cmb_PointCeremonyDate.Name = "Cmb_PointCeremonyDate"
		Me.Cmb_PointCeremonyDate.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointCeremonyDate.TabIndex = 86
		'
		'Cmb_PointAdd1
		'
		Me.Cmb_PointAdd1.FormattingEnabled = true
		Me.Cmb_PointAdd1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointAdd1.Location = New System.Drawing.Point(260, 248)
		Me.Cmb_PointAdd1.Name = "Cmb_PointAdd1"
		Me.Cmb_PointAdd1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointAdd1.TabIndex = 85
		'
		'Cmb_PointHostType
		'
		Me.Cmb_PointHostType.FormattingEnabled = true
		Me.Cmb_PointHostType.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostType.Location = New System.Drawing.Point(260, 285)
		Me.Cmb_PointHostType.Name = "Cmb_PointHostType"
		Me.Cmb_PointHostType.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostType.TabIndex = 84
		'
		'Cmb_PointHostName1
		'
		Me.Cmb_PointHostName1.FormattingEnabled = true
		Me.Cmb_PointHostName1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName1.Location = New System.Drawing.Point(260, 304)
		Me.Cmb_PointHostName1.Name = "Cmb_PointHostName1"
		Me.Cmb_PointHostName1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName1.TabIndex = 83
		'
		'Cmb_PointHostName2
		'
		Me.Cmb_PointHostName2.FormattingEnabled = true
		Me.Cmb_PointHostName2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName2.Location = New System.Drawing.Point(260, 323)
		Me.Cmb_PointHostName2.Name = "Cmb_PointHostName2"
		Me.Cmb_PointHostName2.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName2.TabIndex = 82
		'
		'Txt_PS3
		'
		Me.Txt_PS3.Location = New System.Drawing.Point(75, 420)
		Me.Txt_PS3.Name = "Txt_PS3"
		Me.Txt_PS3.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS3.TabIndex = 81
		'
		'Txt_PS6
		'
		Me.Txt_PS6.Location = New System.Drawing.Point(75, 477)
		Me.Txt_PS6.Name = "Txt_PS6"
		Me.Txt_PS6.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS6.TabIndex = 78
		'
		'Txt_PS2
		'
		Me.Txt_PS2.Location = New System.Drawing.Point(75, 401)
		Me.Txt_PS2.Name = "Txt_PS2"
		Me.Txt_PS2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS2.TabIndex = 77
		'
		'Txt_PS5
		'
		Me.Txt_PS5.Location = New System.Drawing.Point(75, 458)
		Me.Txt_PS5.Name = "Txt_PS5"
		Me.Txt_PS5.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS5.TabIndex = 79
		'
		'Txt_HostName1
		'
		Me.Txt_HostName1.Location = New System.Drawing.Point(75, 306)
		Me.Txt_HostName1.Name = "Txt_HostName1"
		Me.Txt_HostName1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName1.TabIndex = 76
		'
		'Txt_PS4
		'
		Me.Txt_PS4.Location = New System.Drawing.Point(75, 439)
		Me.Txt_PS4.Name = "Txt_PS4"
		Me.Txt_PS4.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS4.TabIndex = 80
		'
		'Txt_HostName2
		'
		Me.Txt_HostName2.Location = New System.Drawing.Point(75, 325)
		Me.Txt_HostName2.Name = "Txt_HostName2"
		Me.Txt_HostName2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName2.TabIndex = 75
		'
		'Txt_HostName3
		'
		Me.Txt_HostName3.Location = New System.Drawing.Point(75, 344)
		Me.Txt_HostName3.Name = "Txt_HostName3"
		Me.Txt_HostName3.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName3.TabIndex = 74
		'
		'Txt_HostName4
		'
		Me.Txt_HostName4.Location = New System.Drawing.Point(75, 363)
		Me.Txt_HostName4.Name = "Txt_HostName4"
		Me.Txt_HostName4.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName4.TabIndex = 73
		'
		'Cmb_PointTitle
		'
		Me.Cmb_PointTitle.FormattingEnabled = true
		Me.Cmb_PointTitle.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointTitle.Location = New System.Drawing.Point(260, 70)
		Me.Cmb_PointTitle.Name = "Cmb_PointTitle"
		Me.Cmb_PointTitle.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointTitle.TabIndex = 56
		'
		'Txt_PS1
		'
		Me.Txt_PS1.Location = New System.Drawing.Point(75, 382)
		Me.Txt_PS1.Name = "Txt_PS1"
		Me.Txt_PS1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS1.TabIndex = 72
		'
		'Cmb_HostType
		'
		Me.Cmb_HostType.FormattingEnabled = true
		Me.Cmb_HostType.Location = New System.Drawing.Point(75, 286)
		Me.Cmb_HostType.Name = "Cmb_HostType"
		Me.Cmb_HostType.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_HostType.TabIndex = 71
		'
		'Txt_Add1
		'
		Me.Txt_Add1.Location = New System.Drawing.Point(75, 248)
		Me.Txt_Add1.Name = "Txt_Add1"
		Me.Txt_Add1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Add1.TabIndex = 70
		'
		'Txt_Add2
		'
		Me.Txt_Add2.Location = New System.Drawing.Point(75, 267)
		Me.Txt_Add2.Name = "Txt_Add2"
		Me.Txt_Add2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Add2.TabIndex = 69
		'
		'Cmb_EndWord
		'
		Me.Cmb_EndWord.FormattingEnabled = true
		Me.Cmb_EndWord.Location = New System.Drawing.Point(75, 208)
		Me.Cmb_EndWord.Name = "Cmb_EndWord"
		Me.Cmb_EndWord.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_EndWord.TabIndex = 66
		'
		'Cmb_Imibi
		'
		Me.Cmb_Imibi.FormattingEnabled = true
		Me.Cmb_Imibi.Location = New System.Drawing.Point(75, 188)
		Me.Cmb_Imibi.Name = "Cmb_Imibi"
		Me.Cmb_Imibi.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Imibi.TabIndex = 65
		'
		'Cmb_Donation
		'
		Me.Cmb_Donation.FormattingEnabled = true
		Me.Cmb_Donation.Location = New System.Drawing.Point(75, 168)
		Me.Cmb_Donation.Name = "Cmb_Donation"
		Me.Cmb_Donation.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Donation.TabIndex = 64
		'
		'Txt_DeadName
		'
		Me.Txt_DeadName.Location = New System.Drawing.Point(75, 149)
		Me.Txt_DeadName.Name = "Txt_DeadName"
		Me.Txt_DeadName.Size = New System.Drawing.Size(180, 19)
		Me.Txt_DeadName.TabIndex = 62
		'
		'Cmb_Time2
		'
		Me.Cmb_Time2.FormattingEnabled = true
		Me.Cmb_Time2.Location = New System.Drawing.Point(75, 129)
		Me.Cmb_Time2.Name = "Cmb_Time2"
		Me.Cmb_Time2.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Time2.TabIndex = 61
		'
		'Cmb_Style
		'
		Me.Cmb_Style.FormattingEnabled = true
		Me.Cmb_Style.Location = New System.Drawing.Point(75, 10)
		Me.Cmb_Style.Name = "Cmb_Style"
		Me.Cmb_Style.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Style.TabIndex = 60
		'
		'Cmb_SeasonWord
		'
		Me.Cmb_SeasonWord.FormattingEnabled = true
		Me.Cmb_SeasonWord.Location = New System.Drawing.Point(75, 30)
		Me.Cmb_SeasonWord.Name = "Cmb_SeasonWord"
		Me.Cmb_SeasonWord.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_SeasonWord.TabIndex = 59
		'
		'Cmb_Time1
		'
		Me.Cmb_Time1.FormattingEnabled = true
		Me.Cmb_Time1.Location = New System.Drawing.Point(75, 50)
		Me.Cmb_Time1.Name = "Cmb_Time1"
		Me.Cmb_Time1.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Time1.TabIndex = 58
		'
		'Cmb_DeathWay
		'
		Me.Cmb_DeathWay.FormattingEnabled = true
		Me.Cmb_DeathWay.Location = New System.Drawing.Point(75, 109)
		Me.Cmb_DeathWay.Name = "Cmb_DeathWay"
		Me.Cmb_DeathWay.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_DeathWay.TabIndex = 57
		'
		'Txt_Name
		'
		Me.Txt_Name.Location = New System.Drawing.Point(75, 90)
		Me.Txt_Name.Name = "Txt_Name"
		Me.Txt_Name.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Name.TabIndex = 55
		'
		'Cmb_Title
		'
		Me.Cmb_Title.FormattingEnabled = true
		Me.Cmb_Title.Location = New System.Drawing.Point(75, 70)
		Me.Cmb_Title.Name = "Cmb_Title"
		Me.Cmb_Title.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Title.TabIndex = 52
		'
		'Lbl_PS1
		'
		Me.Lbl_PS1.Location = New System.Drawing.Point(5, 385)
		Me.Lbl_PS1.Name = "Lbl_PS1"
		Me.Lbl_PS1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS1.TabIndex = 41
		Me.Lbl_PS1.Text = "追伸１："
		'
		'Lbl_PS2
		'
		Me.Lbl_PS2.Location = New System.Drawing.Point(5, 405)
		Me.Lbl_PS2.Name = "Lbl_PS2"
		Me.Lbl_PS2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS2.TabIndex = 40
		Me.Lbl_PS2.Text = "追伸２："
		'
		'Lbl_PS3
		'
		Me.Lbl_PS3.Location = New System.Drawing.Point(5, 424)
		Me.Lbl_PS3.Name = "Lbl_PS3"
		Me.Lbl_PS3.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS3.TabIndex = 39
		Me.Lbl_PS3.Text = "追伸３："
		'
		'Lbl_PS4
		'
		Me.Lbl_PS4.Location = New System.Drawing.Point(5, 443)
		Me.Lbl_PS4.Name = "Lbl_PS4"
		Me.Lbl_PS4.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS4.TabIndex = 38
		Me.Lbl_PS4.Text = "追伸４："
		'
		'Lbl_PS5
		'
		Me.Lbl_PS5.Location = New System.Drawing.Point(5, 462)
		Me.Lbl_PS5.Name = "Lbl_PS5"
		Me.Lbl_PS5.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS5.TabIndex = 37
		Me.Lbl_PS5.Text = "追伸５："
		'
		'Lbl_PS6
		'
		Me.Lbl_PS6.Location = New System.Drawing.Point(5, 481)
		Me.Lbl_PS6.Name = "Lbl_PS6"
		Me.Lbl_PS6.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS6.TabIndex = 36
		Me.Lbl_PS6.Text = "追伸６："
		'
		'Lbl_EndWord
		'
		Me.Lbl_EndWord.Location = New System.Drawing.Point(5, 212)
		Me.Lbl_EndWord.Name = "Lbl_EndWord"
		Me.Lbl_EndWord.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_EndWord.TabIndex = 31
		Me.Lbl_EndWord.Text = "結語："
		'
		'Lbl_CeremonyDate
		'
		Me.Lbl_CeremonyDate.Location = New System.Drawing.Point(5, 232)
		Me.Lbl_CeremonyDate.Name = "Lbl_CeremonyDate"
		Me.Lbl_CeremonyDate.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_CeremonyDate.TabIndex = 30
		Me.Lbl_CeremonyDate.Text = "法要年月日："
		'
		'Lbl_Add1
		'
		Me.Lbl_Add1.Location = New System.Drawing.Point(5, 250)
		Me.Lbl_Add1.Name = "Lbl_Add1"
		Me.Lbl_Add1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Add1.TabIndex = 29
		Me.Lbl_Add1.Text = "住所１："
		'
		'Lbl_Add2
		'
		Me.Lbl_Add2.Location = New System.Drawing.Point(5, 270)
		Me.Lbl_Add2.Name = "Lbl_Add2"
		Me.Lbl_Add2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Add2.TabIndex = 28
		Me.Lbl_Add2.Text = "住所２："
		'
		'Lbl_HostType
		'
		Me.Lbl_HostType.Location = New System.Drawing.Point(5, 290)
		Me.Lbl_HostType.Name = "Lbl_HostType"
		Me.Lbl_HostType.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostType.TabIndex = 27
		Me.Lbl_HostType.Text = "施主・喪主："
		'
		'Lbl_HostName1
		'
		Me.Lbl_HostName1.Location = New System.Drawing.Point(5, 309)
		Me.Lbl_HostName1.Name = "Lbl_HostName1"
		Me.Lbl_HostName1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName1.TabIndex = 26
		Me.Lbl_HostName1.Text = "喪主名："
		'
		'Lbl_HostName2
		'
		Me.Lbl_HostName2.Location = New System.Drawing.Point(5, 328)
		Me.Lbl_HostName2.Name = "Lbl_HostName2"
		Me.Lbl_HostName2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName2.TabIndex = 25
		Me.Lbl_HostName2.Text = "喪主名２："
		'
		'Lbl_HostName3
		'
		Me.Lbl_HostName3.Location = New System.Drawing.Point(5, 346)
		Me.Lbl_HostName3.Name = "Lbl_HostName3"
		Me.Lbl_HostName3.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName3.TabIndex = 24
		Me.Lbl_HostName3.Text = "喪主名３："
		'
		'Lbl_HostName4
		'
		Me.Lbl_HostName4.Location = New System.Drawing.Point(5, 366)
		Me.Lbl_HostName4.Name = "Lbl_HostName4"
		Me.Lbl_HostName4.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName4.TabIndex = 23
		Me.Lbl_HostName4.Text = "喪主名４："
		'
		'Lbl_Style
		'
		Me.Lbl_Style.Location = New System.Drawing.Point(5, 13)
		Me.Lbl_Style.Name = "Lbl_Style"
		Me.Lbl_Style.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Style.TabIndex = 22
		Me.Lbl_Style.Text = "文例："
		'
		'Lbl_SeasonWord
		'
		Me.Lbl_SeasonWord.Location = New System.Drawing.Point(5, 33)
		Me.Lbl_SeasonWord.Name = "Lbl_SeasonWord"
		Me.Lbl_SeasonWord.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_SeasonWord.TabIndex = 21
		Me.Lbl_SeasonWord.Text = "季語："
		'
		'Lbl_Time1
		'
		Me.Lbl_Time1.Location = New System.Drawing.Point(5, 53)
		Me.Lbl_Time1.Name = "Lbl_Time1"
		Me.Lbl_Time1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Time1.TabIndex = 20
		Me.Lbl_Time1.Text = "時期１："
		'
		'Lbl_Title
		'
		Me.Lbl_Title.Location = New System.Drawing.Point(5, 74)
		Me.Lbl_Title.Name = "Lbl_Title"
		Me.Lbl_Title.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Title.TabIndex = 19
		Me.Lbl_Title.Text = "続柄："
		'
		'Lbl_Name
		'
		Me.Lbl_Name.Location = New System.Drawing.Point(5, 94)
		Me.Lbl_Name.Name = "Lbl_Name"
		Me.Lbl_Name.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Name.TabIndex = 18
		Me.Lbl_Name.Text = "俗名："
		'
		'Lbl_DeathWay
		'
		Me.Lbl_DeathWay.Location = New System.Drawing.Point(5, 112)
		Me.Lbl_DeathWay.Name = "Lbl_DeathWay"
		Me.Lbl_DeathWay.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_DeathWay.TabIndex = 17
		Me.Lbl_DeathWay.Text = "死亡告知："
		'
		'Lbl_Time2
		'
		Me.Lbl_Time2.Location = New System.Drawing.Point(5, 131)
		Me.Lbl_Time2.Name = "Lbl_Time2"
		Me.Lbl_Time2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Time2.TabIndex = 16
		Me.Lbl_Time2.Text = "時期２："
		'
		'Lbl_DeadName
		'
		Me.Lbl_DeadName.Location = New System.Drawing.Point(5, 151)
		Me.Lbl_DeadName.Name = "Lbl_DeadName"
		Me.Lbl_DeadName.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_DeadName.TabIndex = 15
		Me.Lbl_DeadName.Text = "戒名："
		'
		'Lbl_Donation
		'
		Me.Lbl_Donation.Location = New System.Drawing.Point(5, 171)
		Me.Lbl_Donation.Name = "Lbl_Donation"
		Me.Lbl_Donation.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Donation.TabIndex = 14
		Me.Lbl_Donation.Text = "供え物："
		'
		'Lbl_Imibi
		'
		Me.Lbl_Imibi.Location = New System.Drawing.Point(5, 192)
		Me.Lbl_Imibi.Name = "Lbl_Imibi"
		Me.Lbl_Imibi.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Imibi.TabIndex = 13
		Me.Lbl_Imibi.Text = "忌日："
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.Grb_Contents)
		Me.panel1.Location = New System.Drawing.Point(10, 181)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(359, 510)
		Me.panel1.TabIndex = 3
		'
		'Cmb_Magnify
		'
		Me.Cmb_Magnify.FormattingEnabled = true
		Me.Cmb_Magnify.Location = New System.Drawing.Point(89, 156)
		Me.Cmb_Magnify.Name = "Cmb_Magnify"
		Me.Cmb_Magnify.Size = New System.Drawing.Size(49, 20)
		Me.Cmb_Magnify.TabIndex = 5
		'
		'Txt_Copy
		'
		Me.Txt_Copy.Location = New System.Drawing.Point(185, 156)
		Me.Txt_Copy.Name = "Txt_Copy"
		Me.Txt_Copy.Size = New System.Drawing.Size(31, 19)
		Me.Txt_Copy.TabIndex = 6
		'
		'Cmb_Thickness
		'
		Me.Cmb_Thickness.FormattingEnabled = true
		Me.Cmb_Thickness.Location = New System.Drawing.Point(282, 156)
		Me.Cmb_Thickness.Name = "Cmb_Thickness"
		Me.Cmb_Thickness.Size = New System.Drawing.Size(49, 20)
		Me.Cmb_Thickness.TabIndex = 7
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
		Me.Lbl_Num.Location = New System.Drawing.Point(146, 160)
		Me.Lbl_Num.Name = "Lbl_Num"
		Me.Lbl_Num.Size = New System.Drawing.Size(43, 18)
		Me.Lbl_Num.TabIndex = 13
		Me.Lbl_Num.Text = "部数："
		'
		'Lbl_Thick
		'
		Me.Lbl_Thick.Location = New System.Drawing.Point(223, 160)
		Me.Lbl_Thick.Name = "Lbl_Thick"
		Me.Lbl_Thick.Size = New System.Drawing.Size(69, 23)
		Me.Lbl_Thick.TabIndex = 14
		Me.Lbl_Thick.Text = "印刷濃度："
		'
		'Pic_Main
		'
		Me.Pic_Main.BackColor = System.Drawing.Color.White
		Me.Pic_Main.ErrorImage = Nothing
		Me.Pic_Main.InitialImage = CType(resources.GetObject("Pic_Main.InitialImage"),System.Drawing.Image)
		Me.Pic_Main.Location = New System.Drawing.Point(3, 2)
		Me.Pic_Main.Name = "Pic_Main"
		Me.Pic_Main.Size = New System.Drawing.Size(768, 668)
		Me.Pic_Main.TabIndex = 16
		Me.Pic_Main.TabStop = false
		'
		'panel2
		'
		Me.panel2.AutoScroll = true
		Me.panel2.AutoScrollMargin = New System.Drawing.Size(5, 5)
		Me.panel2.Controls.Add(Me.Pic_Main)
		Me.panel2.Location = New System.Drawing.Point(375, 10)
		Me.panel2.Name = "panel2"
		Me.panel2.Size = New System.Drawing.Size(790, 687)
		Me.panel2.TabIndex = 17
		'
		'PrintReport
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1176, 714)
		Me.Controls.Add(Me.panel2)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.Cmb_Thickness)
		Me.Controls.Add(Me.Txt_Copy)
		Me.Controls.Add(Me.Cmb_Magnify)
		Me.Controls.Add(Me.Grb_Common)
		Me.Controls.Add(Me.Lbl_Thick)
		Me.Controls.Add(Me.Lbl_Num)
		Me.Controls.Add(Me.Lbl_Rate)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "PrintReport"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Print"
		AddHandler Load, AddressOf Me.Print_Load
		Me.Grb_Common.ResumeLayout(false)
		Me.Grb_Common.PerformLayout
		Me.Grb_Contents.ResumeLayout(false)
		Me.Grb_Contents.PerformLayout
		Me.panel1.ResumeLayout(false)
		CType(Me.Pic_Main,System.ComponentModel.ISupportInitialize).EndInit
		Me.panel2.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private panel2 As System.Windows.Forms.Panel
	Private Lbl_year As System.Windows.Forms.Label
	Private Lbl_Day As System.Windows.Forms.Label
	Private Lbl_Month As System.Windows.Forms.Label
	Private Btn_Dtp As System.Windows.Forms.Button
	Private Cmb_Year As System.Windows.Forms.ComboBox
	Private Cmb_Month As System.Windows.Forms.ComboBox
	Private Cmb_Day As System.Windows.Forms.ComboBox
	Private Pic_Main As System.Windows.Forms.PictureBox
	Private Cmb_PointPS1 As System.Windows.Forms.ComboBox
	Private Cmb_PointHostName4 As System.Windows.Forms.ComboBox
	Private Cmb_PointHostName3 As System.Windows.Forms.ComboBox
	Private Cmb_Title As System.Windows.Forms.ComboBox
	Private Txt_Name As System.Windows.Forms.TextBox
	Private Cmb_Time1 As System.Windows.Forms.ComboBox
	Private Cmb_SeasonWord As System.Windows.Forms.ComboBox
	Private Cmb_Style As System.Windows.Forms.ComboBox
	Private Cmb_Time2 As System.Windows.Forms.ComboBox
	Private Txt_DeadName As System.Windows.Forms.TextBox
	Private Cmb_Donation As System.Windows.Forms.ComboBox
	Private Cmb_Imibi As System.Windows.Forms.ComboBox
	Private Cmb_EndWord As System.Windows.Forms.ComboBox
	Private Txt_Add2 As System.Windows.Forms.TextBox
	Private Txt_Add1 As System.Windows.Forms.TextBox
	Private Cmb_HostType As System.Windows.Forms.ComboBox
	Private Txt_PS1 As System.Windows.Forms.TextBox
	Private Cmb_PointTitle As System.Windows.Forms.ComboBox
	Private Txt_HostName4 As System.Windows.Forms.TextBox
	Private Txt_HostName3 As System.Windows.Forms.TextBox
	Private Txt_HostName2 As System.Windows.Forms.TextBox
	Private Txt_PS4 As System.Windows.Forms.TextBox
	Private Txt_HostName1 As System.Windows.Forms.TextBox
	Private Txt_PS5 As System.Windows.Forms.TextBox
	Private Txt_PS2 As System.Windows.Forms.TextBox
	Private Txt_PS6 As System.Windows.Forms.TextBox
	Private Txt_PS3 As System.Windows.Forms.TextBox
	Private Cmb_PointHostName2 As System.Windows.Forms.ComboBox
	Private Cmb_PointHostName1 As System.Windows.Forms.ComboBox
	Private Cmb_PointHostType As System.Windows.Forms.ComboBox
	Private Cmb_PointAdd1 As System.Windows.Forms.ComboBox
	Private Cmb_PointCeremonyDate As System.Windows.Forms.ComboBox
	Private Cmb_PointEndWord As System.Windows.Forms.ComboBox
	Private Cmb_PointImibi As System.Windows.Forms.ComboBox
	Private Cmb_PointDeadName As System.Windows.Forms.ComboBox
	Private Cmb_PointName As System.Windows.Forms.ComboBox
	Private Lbl_Thick As System.Windows.Forms.Label
	Private Lbl_Num As System.Windows.Forms.Label
	Private Lbl_Rate As System.Windows.Forms.Label
	Private Cmb_DeathWay As System.Windows.Forms.ComboBox
	Private Lbl_Imibi As System.Windows.Forms.Label
	Private Lbl_Donation As System.Windows.Forms.Label
	Private Lbl_DeadName As System.Windows.Forms.Label
	Private Lbl_Time2 As System.Windows.Forms.Label
	Private Lbl_DeathWay As System.Windows.Forms.Label
	Private Lbl_Name As System.Windows.Forms.Label
	Private Lbl_Title As System.Windows.Forms.Label
	Private Lbl_Time1 As System.Windows.Forms.Label
	Private Lbl_SeasonWord As System.Windows.Forms.Label
	Private Lbl_Style As System.Windows.Forms.Label
	Private Lbl_HostName4 As System.Windows.Forms.Label
	Private Lbl_HostName3 As System.Windows.Forms.Label
	Private Lbl_HostName2 As System.Windows.Forms.Label
	Private Lbl_HostName1 As System.Windows.Forms.Label
	Private Lbl_HostType As System.Windows.Forms.Label
	Private Lbl_Add2 As System.Windows.Forms.Label
	Private Lbl_Add1 As System.Windows.Forms.Label
	Private Lbl_CeremonyDate As System.Windows.Forms.Label
	Private Lbl_EndWord As System.Windows.Forms.Label
	Private Lbl_PS6 As System.Windows.Forms.Label
	Private Lbl_PS5 As System.Windows.Forms.Label
	Private Lbl_PS4 As System.Windows.Forms.Label
	Private Lbl_PS3 As System.Windows.Forms.Label
	Private Lbl_PS2 As System.Windows.Forms.Label
	Private Lbl_PS1 As System.Windows.Forms.Label
	Private Cmb_Thickness As System.Windows.Forms.ComboBox
	Private Txt_Copy As System.Windows.Forms.TextBox
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
	Private Cmb_Magnify As System.Windows.Forms.ComboBox
	Private Cmb_Size As System.Windows.Forms.ComboBox
	Private Cmb_Font As System.Windows.Forms.ComboBox
	Private Txt_PosX As System.Windows.Forms.TextBox
	Private Txt_PosY As System.Windows.Forms.TextBox
	Private Grb_Contents As System.Windows.Forms.GroupBox
	Private Grb_Common As System.Windows.Forms.GroupBox
	Private panel1 As System.Windows.Forms.Panel
	
End Class
