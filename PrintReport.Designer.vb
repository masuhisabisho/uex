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
		Me.Btn_Print = New System.Windows.Forms.Button()
		Me.Txt_SizeY = New System.Windows.Forms.TextBox()
		Me.Cmb_Thickness = New System.Windows.Forms.ComboBox()
		Me.Txt_PrintDir = New System.Windows.Forms.TextBox()
		Me.Txt_SizeW = New System.Windows.Forms.TextBox()
		Me.Lbl_Thick = New System.Windows.Forms.Label()
		Me.Cmb_Magnify = New System.Windows.Forms.ComboBox()
		Me.Lbl_Font = New System.Windows.Forms.Label()
		Me.Lbl_PrintDir = New System.Windows.Forms.Label()
		Me.Lbl_SizeH = New System.Windows.Forms.Label()
		Me.Lbl_Rate = New System.Windows.Forms.Label()
		Me.Lbl_SizeW = New System.Windows.Forms.Label()
		Me.Lbl_Size = New System.Windows.Forms.Label()
		Me.Cmb_Font = New System.Windows.Forms.ComboBox()
		Me.Cmb_Size = New System.Windows.Forms.ComboBox()
		Me.Grb_Contents = New System.Windows.Forms.GroupBox()
		Me.Txt_Namae = New System.Windows.Forms.TextBox()
		Me.Cmb_PointNamae = New System.Windows.Forms.ComboBox()
		Me.Cmb_PointHyodai = New System.Windows.Forms.ComboBox()
		Me.Cmb_Hyodai = New System.Windows.Forms.ComboBox()
		Me.LblNamae = New System.Windows.Forms.Label()
		Me.Lbl_Namae = New System.Windows.Forms.Label()
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
		Me.Pnl_Menu01 = New System.Windows.Forms.Panel()
		Me.Pnl_Main = New System.Windows.Forms.Panel()
		Me.Pnl_PanelAdjuster = New System.Windows.Forms.Panel()
		Me.Pic_Main = New System.Windows.Forms.PictureBox()
		Me.Pnl_Frame = New System.Windows.Forms.Panel()
		Me.Grb_Common.SuspendLayout
		Me.Grb_Contents.SuspendLayout
		Me.Pnl_Menu01.SuspendLayout
		Me.Pnl_Main.SuspendLayout
		Me.Pnl_PanelAdjuster.SuspendLayout
		CType(Me.Pic_Main,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Grb_Common
		'
		Me.Grb_Common.Controls.Add(Me.Btn_Print)
		Me.Grb_Common.Controls.Add(Me.Txt_SizeY)
		Me.Grb_Common.Controls.Add(Me.Cmb_Thickness)
		Me.Grb_Common.Controls.Add(Me.Txt_PrintDir)
		Me.Grb_Common.Controls.Add(Me.Txt_SizeW)
		Me.Grb_Common.Controls.Add(Me.Lbl_Thick)
		Me.Grb_Common.Controls.Add(Me.Cmb_Magnify)
		Me.Grb_Common.Controls.Add(Me.Lbl_Font)
		Me.Grb_Common.Controls.Add(Me.Lbl_PrintDir)
		Me.Grb_Common.Controls.Add(Me.Lbl_SizeH)
		Me.Grb_Common.Controls.Add(Me.Lbl_Rate)
		Me.Grb_Common.Controls.Add(Me.Lbl_SizeW)
		Me.Grb_Common.Controls.Add(Me.Lbl_Size)
		Me.Grb_Common.Controls.Add(Me.Cmb_Font)
		Me.Grb_Common.Controls.Add(Me.Cmb_Size)
		Me.Grb_Common.Location = New System.Drawing.Point(10, 1)
		Me.Grb_Common.Name = "Grb_Common"
		Me.Grb_Common.Size = New System.Drawing.Size(347, 146)
		Me.Grb_Common.TabIndex = 1
		Me.Grb_Common.TabStop = false
		Me.Grb_Common.Text = "共通設定"
		'
		'Btn_Print
		'
		Me.Btn_Print.Location = New System.Drawing.Point(268, 119)
		Me.Btn_Print.Name = "Btn_Print"
		Me.Btn_Print.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Print.TabIndex = 17
		Me.Btn_Print.Text = "印刷"
		Me.Btn_Print.UseVisualStyleBackColor = true
		AddHandler Me.Btn_Print.Click, AddressOf Me.Btn_Print_Click
		'
		'Txt_SizeY
		'
		Me.Txt_SizeY.Location = New System.Drawing.Point(78, 55)
		Me.Txt_SizeY.Name = "Txt_SizeY"
		Me.Txt_SizeY.ReadOnly = true
		Me.Txt_SizeY.Size = New System.Drawing.Size(223, 19)
		Me.Txt_SizeY.TabIndex = 16
		'
		'Cmb_Thickness
		'
		Me.Cmb_Thickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Thickness.FormattingEnabled = true
		Me.Cmb_Thickness.Location = New System.Drawing.Point(193, 117)
		Me.Cmb_Thickness.Name = "Cmb_Thickness"
		Me.Cmb_Thickness.Size = New System.Drawing.Size(49, 20)
		Me.Cmb_Thickness.TabIndex = 7
		'
		'Txt_PrintDir
		'
		Me.Txt_PrintDir.Location = New System.Drawing.Point(78, 75)
		Me.Txt_PrintDir.Name = "Txt_PrintDir"
		Me.Txt_PrintDir.ReadOnly = true
		Me.Txt_PrintDir.Size = New System.Drawing.Size(223, 19)
		Me.Txt_PrintDir.TabIndex = 15
		'
		'Txt_SizeW
		'
		Me.Txt_SizeW.Location = New System.Drawing.Point(78, 35)
		Me.Txt_SizeW.Name = "Txt_SizeW"
		Me.Txt_SizeW.ReadOnly = true
		Me.Txt_SizeW.Size = New System.Drawing.Size(223, 19)
		Me.Txt_SizeW.TabIndex = 14
		'
		'Lbl_Thick
		'
		Me.Lbl_Thick.Location = New System.Drawing.Point(134, 121)
		Me.Lbl_Thick.Name = "Lbl_Thick"
		Me.Lbl_Thick.Size = New System.Drawing.Size(69, 18)
		Me.Lbl_Thick.TabIndex = 14
		Me.Lbl_Thick.Text = "印刷濃度："
		'
		'Cmb_Magnify
		'
		Me.Cmb_Magnify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Magnify.FormattingEnabled = true
		Me.Cmb_Magnify.Location = New System.Drawing.Point(78, 117)
		Me.Cmb_Magnify.Name = "Cmb_Magnify"
		Me.Cmb_Magnify.Size = New System.Drawing.Size(49, 20)
		Me.Cmb_Magnify.TabIndex = 5
		'
		'Lbl_Font
		'
		Me.Lbl_Font.Location = New System.Drawing.Point(7, 98)
		Me.Lbl_Font.Name = "Lbl_Font"
		Me.Lbl_Font.Size = New System.Drawing.Size(69, 17)
		Me.Lbl_Font.TabIndex = 11
		Me.Lbl_Font.Text = "フォント："
		'
		'Lbl_PrintDir
		'
		Me.Lbl_PrintDir.Location = New System.Drawing.Point(7, 77)
		Me.Lbl_PrintDir.Name = "Lbl_PrintDir"
		Me.Lbl_PrintDir.Size = New System.Drawing.Size(69, 17)
		Me.Lbl_PrintDir.TabIndex = 10
		Me.Lbl_PrintDir.Text = "印刷方向："
		'
		'Lbl_SizeH
		'
		Me.Lbl_SizeH.Location = New System.Drawing.Point(7, 57)
		Me.Lbl_SizeH.Name = "Lbl_SizeH"
		Me.Lbl_SizeH.Size = New System.Drawing.Size(69, 17)
		Me.Lbl_SizeH.TabIndex = 9
		Me.Lbl_SizeH.Text = "用紙（高さ）："
		'
		'Lbl_Rate
		'
		Me.Lbl_Rate.Location = New System.Drawing.Point(7, 120)
		Me.Lbl_Rate.Name = "Lbl_Rate"
		Me.Lbl_Rate.Size = New System.Drawing.Size(62, 13)
		Me.Lbl_Rate.TabIndex = 12
		Me.Lbl_Rate.Text = "表示倍率："
		'
		'Lbl_SizeW
		'
		Me.Lbl_SizeW.Location = New System.Drawing.Point(7, 37)
		Me.Lbl_SizeW.Name = "Lbl_SizeW"
		Me.Lbl_SizeW.Size = New System.Drawing.Size(69, 17)
		Me.Lbl_SizeW.TabIndex = 8
		Me.Lbl_SizeW.Text = "用紙（幅）："
		'
		'Lbl_Size
		'
		Me.Lbl_Size.Location = New System.Drawing.Point(7, 18)
		Me.Lbl_Size.Name = "Lbl_Size"
		Me.Lbl_Size.Size = New System.Drawing.Size(69, 17)
		Me.Lbl_Size.TabIndex = 7
		Me.Lbl_Size.Text = "用紙："
		'
		'Cmb_Font
		'
		Me.Cmb_Font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Font.FormattingEnabled = true
		Me.Cmb_Font.Location = New System.Drawing.Point(78, 95)
		Me.Cmb_Font.Name = "Cmb_Font"
		Me.Cmb_Font.Size = New System.Drawing.Size(223, 20)
		Me.Cmb_Font.TabIndex = 4
		'
		'Cmb_Size
		'
		Me.Cmb_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Size.FormattingEnabled = true
		Me.Cmb_Size.Location = New System.Drawing.Point(78, 14)
		Me.Cmb_Size.Name = "Cmb_Size"
		Me.Cmb_Size.Size = New System.Drawing.Size(223, 20)
		Me.Cmb_Size.TabIndex = 0
		'
		'Grb_Contents
		'
		Me.Grb_Contents.Controls.Add(Me.Txt_Namae)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointNamae)
		Me.Grb_Contents.Controls.Add(Me.Cmb_PointHyodai)
		Me.Grb_Contents.Controls.Add(Me.Cmb_Hyodai)
		Me.Grb_Contents.Controls.Add(Me.LblNamae)
		Me.Grb_Contents.Controls.Add(Me.Lbl_Namae)
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
		Me.Grb_Contents.Size = New System.Drawing.Size(348, 586)
		Me.Grb_Contents.TabIndex = 2
		Me.Grb_Contents.TabStop = false
		Me.Grb_Contents.Text = "内容設定"
		'
		'Txt_Namae
		'
		Me.Txt_Namae.Location = New System.Drawing.Point(75, 50)
		Me.Txt_Namae.Name = "Txt_Namae"
		Me.Txt_Namae.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Namae.TabIndex = 108
		'
		'Cmb_PointNamae
		'
		Me.Cmb_PointNamae.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointNamae.FormattingEnabled = true
		Me.Cmb_PointNamae.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointNamae.Location = New System.Drawing.Point(260, 50)
		Me.Cmb_PointNamae.Name = "Cmb_PointNamae"
		Me.Cmb_PointNamae.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointNamae.TabIndex = 107
		'
		'Cmb_PointHyodai
		'
		Me.Cmb_PointHyodai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHyodai.FormattingEnabled = true
		Me.Cmb_PointHyodai.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHyodai.Location = New System.Drawing.Point(260, 31)
		Me.Cmb_PointHyodai.Name = "Cmb_PointHyodai"
		Me.Cmb_PointHyodai.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHyodai.TabIndex = 106
		'
		'Cmb_Hyodai
		'
		Me.Cmb_Hyodai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Hyodai.FormattingEnabled = true
		Me.Cmb_Hyodai.Location = New System.Drawing.Point(75, 30)
		Me.Cmb_Hyodai.Name = "Cmb_Hyodai"
		Me.Cmb_Hyodai.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Hyodai.TabIndex = 105
		'
		'LblNamae
		'
		Me.LblNamae.Location = New System.Drawing.Point(5, 33)
		Me.LblNamae.Name = "LblNamae"
		Me.LblNamae.Size = New System.Drawing.Size(81, 18)
		Me.LblNamae.TabIndex = 103
		Me.LblNamae.Text = "表題："
		'
		'Lbl_Namae
		'
		Me.Lbl_Namae.Location = New System.Drawing.Point(5, 53)
		Me.Lbl_Namae.Name = "Lbl_Namae"
		Me.Lbl_Namae.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Namae.TabIndex = 102
		Me.Lbl_Namae.Text = "名前："
		'
		'Btn_Dtp
		'
		Me.Btn_Dtp.Image = CType(resources.GetObject("Btn_Dtp.Image"),System.Drawing.Image)
		Me.Btn_Dtp.Location = New System.Drawing.Point(291, 290)
		Me.Btn_Dtp.Name = "Btn_Dtp"
		Me.Btn_Dtp.Size = New System.Drawing.Size(24, 20)
		Me.Btn_Dtp.TabIndex = 101
		Me.Btn_Dtp.UseVisualStyleBackColor = true
		AddHandler Me.Btn_Dtp.Click, AddressOf Me.Btn_Dtp_Click
		'
		'Lbl_Month
		'
		Me.Lbl_Month.Location = New System.Drawing.Point(82, 291)
		Me.Lbl_Month.Name = "Lbl_Month"
		Me.Lbl_Month.Size = New System.Drawing.Size(17, 14)
		Me.Lbl_Month.TabIndex = 100
		Me.Lbl_Month.Text = "月"
		Me.Lbl_Month.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Lbl_Day
		'
		Me.Lbl_Day.Location = New System.Drawing.Point(83, 313)
		Me.Lbl_Day.Name = "Lbl_Day"
		Me.Lbl_Day.Size = New System.Drawing.Size(14, 14)
		Me.Lbl_Day.TabIndex = 99
		Me.Lbl_Day.Text = "日"
		Me.Lbl_Day.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Lbl_year
		'
		Me.Lbl_year.Location = New System.Drawing.Point(83, 270)
		Me.Lbl_year.Name = "Lbl_year"
		Me.Lbl_year.Size = New System.Drawing.Size(17, 14)
		Me.Lbl_year.TabIndex = 98
		Me.Lbl_year.Text = "年"
		Me.Lbl_year.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Cmb_Day
		'
		Me.Cmb_Day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Day.FormattingEnabled = true
		Me.Cmb_Day.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Day.Location = New System.Drawing.Point(109, 309)
		Me.Cmb_Day.Name = "Cmb_Day"
		Me.Cmb_Day.Size = New System.Drawing.Size(145, 20)
		Me.Cmb_Day.TabIndex = 97
		'
		'Cmb_Month
		'
		Me.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Month.FormattingEnabled = true
		Me.Cmb_Month.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Month.Location = New System.Drawing.Point(109, 288)
		Me.Cmb_Month.Name = "Cmb_Month"
		Me.Cmb_Month.Size = New System.Drawing.Size(145, 20)
		Me.Cmb_Month.TabIndex = 96
		'
		'Cmb_Year
		'
		Me.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Year.FormattingEnabled = true
		Me.Cmb_Year.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_Year.Location = New System.Drawing.Point(109, 268)
		Me.Cmb_Year.Name = "Cmb_Year"
		Me.Cmb_Year.Size = New System.Drawing.Size(145, 20)
		Me.Cmb_Year.TabIndex = 95
		'
		'Cmb_PointHostName3
		'
		Me.Cmb_PointHostName3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHostName3.FormattingEnabled = true
		Me.Cmb_PointHostName3.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName3.Location = New System.Drawing.Point(260, 424)
		Me.Cmb_PointHostName3.Name = "Cmb_PointHostName3"
		Me.Cmb_PointHostName3.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName3.TabIndex = 93
		'
		'Cmb_PointHostName4
		'
		Me.Cmb_PointHostName4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHostName4.FormattingEnabled = true
		Me.Cmb_PointHostName4.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName4.Location = New System.Drawing.Point(260, 444)
		Me.Cmb_PointHostName4.Name = "Cmb_PointHostName4"
		Me.Cmb_PointHostName4.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName4.TabIndex = 92
		'
		'Cmb_PointPS1
		'
		Me.Cmb_PointPS1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointPS1.FormattingEnabled = true
		Me.Cmb_PointPS1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointPS1.Location = New System.Drawing.Point(260, 463)
		Me.Cmb_PointPS1.Name = "Cmb_PointPS1"
		Me.Cmb_PointPS1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointPS1.TabIndex = 91
		'
		'Cmb_PointName
		'
		Me.Cmb_PointName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointName.FormattingEnabled = true
		Me.Cmb_PointName.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointName.Location = New System.Drawing.Point(260, 129)
		Me.Cmb_PointName.Name = "Cmb_PointName"
		Me.Cmb_PointName.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointName.TabIndex = 90
		'
		'Cmb_PointDeadName
		'
		Me.Cmb_PointDeadName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointDeadName.FormattingEnabled = true
		Me.Cmb_PointDeadName.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointDeadName.Location = New System.Drawing.Point(260, 188)
		Me.Cmb_PointDeadName.Name = "Cmb_PointDeadName"
		Me.Cmb_PointDeadName.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointDeadName.TabIndex = 89
		'
		'Cmb_PointImibi
		'
		Me.Cmb_PointImibi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointImibi.FormattingEnabled = true
		Me.Cmb_PointImibi.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointImibi.Location = New System.Drawing.Point(260, 228)
		Me.Cmb_PointImibi.Name = "Cmb_PointImibi"
		Me.Cmb_PointImibi.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointImibi.TabIndex = 88
		'
		'Cmb_PointEndWord
		'
		Me.Cmb_PointEndWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointEndWord.FormattingEnabled = true
		Me.Cmb_PointEndWord.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointEndWord.Location = New System.Drawing.Point(260, 248)
		Me.Cmb_PointEndWord.Name = "Cmb_PointEndWord"
		Me.Cmb_PointEndWord.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointEndWord.TabIndex = 87
		'
		'Cmb_PointCeremonyDate
		'
		Me.Cmb_PointCeremonyDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointCeremonyDate.FormattingEnabled = true
		Me.Cmb_PointCeremonyDate.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointCeremonyDate.Location = New System.Drawing.Point(260, 268)
		Me.Cmb_PointCeremonyDate.Name = "Cmb_PointCeremonyDate"
		Me.Cmb_PointCeremonyDate.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointCeremonyDate.TabIndex = 86
		'
		'Cmb_PointAdd1
		'
		Me.Cmb_PointAdd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointAdd1.FormattingEnabled = true
		Me.Cmb_PointAdd1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointAdd1.Location = New System.Drawing.Point(260, 329)
		Me.Cmb_PointAdd1.Name = "Cmb_PointAdd1"
		Me.Cmb_PointAdd1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointAdd1.TabIndex = 85
		'
		'Cmb_PointHostType
		'
		Me.Cmb_PointHostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHostType.FormattingEnabled = true
		Me.Cmb_PointHostType.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostType.Location = New System.Drawing.Point(260, 366)
		Me.Cmb_PointHostType.Name = "Cmb_PointHostType"
		Me.Cmb_PointHostType.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostType.TabIndex = 84
		'
		'Cmb_PointHostName1
		'
		Me.Cmb_PointHostName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHostName1.FormattingEnabled = true
		Me.Cmb_PointHostName1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName1.Location = New System.Drawing.Point(260, 385)
		Me.Cmb_PointHostName1.Name = "Cmb_PointHostName1"
		Me.Cmb_PointHostName1.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName1.TabIndex = 83
		'
		'Cmb_PointHostName2
		'
		Me.Cmb_PointHostName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointHostName2.FormattingEnabled = true
		Me.Cmb_PointHostName2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointHostName2.Location = New System.Drawing.Point(260, 404)
		Me.Cmb_PointHostName2.Name = "Cmb_PointHostName2"
		Me.Cmb_PointHostName2.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointHostName2.TabIndex = 82
		'
		'Txt_PS3
		'
		Me.Txt_PS3.Location = New System.Drawing.Point(74, 501)
		Me.Txt_PS3.Name = "Txt_PS3"
		Me.Txt_PS3.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS3.TabIndex = 81
		'
		'Txt_PS6
		'
		Me.Txt_PS6.Location = New System.Drawing.Point(74, 558)
		Me.Txt_PS6.Name = "Txt_PS6"
		Me.Txt_PS6.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS6.TabIndex = 78
		'
		'Txt_PS2
		'
		Me.Txt_PS2.Location = New System.Drawing.Point(74, 482)
		Me.Txt_PS2.Name = "Txt_PS2"
		Me.Txt_PS2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS2.TabIndex = 77
		'
		'Txt_PS5
		'
		Me.Txt_PS5.Location = New System.Drawing.Point(74, 539)
		Me.Txt_PS5.Name = "Txt_PS5"
		Me.Txt_PS5.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS5.TabIndex = 79
		'
		'Txt_HostName1
		'
		Me.Txt_HostName1.Location = New System.Drawing.Point(74, 387)
		Me.Txt_HostName1.Name = "Txt_HostName1"
		Me.Txt_HostName1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName1.TabIndex = 76
		'
		'Txt_PS4
		'
		Me.Txt_PS4.Location = New System.Drawing.Point(74, 520)
		Me.Txt_PS4.Name = "Txt_PS4"
		Me.Txt_PS4.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS4.TabIndex = 80
		'
		'Txt_HostName2
		'
		Me.Txt_HostName2.Location = New System.Drawing.Point(74, 406)
		Me.Txt_HostName2.Name = "Txt_HostName2"
		Me.Txt_HostName2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName2.TabIndex = 75
		'
		'Txt_HostName3
		'
		Me.Txt_HostName3.Location = New System.Drawing.Point(74, 425)
		Me.Txt_HostName3.Name = "Txt_HostName3"
		Me.Txt_HostName3.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName3.TabIndex = 74
		'
		'Txt_HostName4
		'
		Me.Txt_HostName4.Location = New System.Drawing.Point(74, 444)
		Me.Txt_HostName4.Name = "Txt_HostName4"
		Me.Txt_HostName4.Size = New System.Drawing.Size(180, 19)
		Me.Txt_HostName4.TabIndex = 73
		'
		'Cmb_PointTitle
		'
		Me.Cmb_PointTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_PointTitle.FormattingEnabled = true
		Me.Cmb_PointTitle.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
		Me.Cmb_PointTitle.Location = New System.Drawing.Point(260, 110)
		Me.Cmb_PointTitle.Name = "Cmb_PointTitle"
		Me.Cmb_PointTitle.Size = New System.Drawing.Size(55, 20)
		Me.Cmb_PointTitle.TabIndex = 56
		'
		'Txt_PS1
		'
		Me.Txt_PS1.Location = New System.Drawing.Point(74, 463)
		Me.Txt_PS1.Name = "Txt_PS1"
		Me.Txt_PS1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_PS1.TabIndex = 72
		'
		'Cmb_HostType
		'
		Me.Cmb_HostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_HostType.FormattingEnabled = true
		Me.Cmb_HostType.Location = New System.Drawing.Point(74, 367)
		Me.Cmb_HostType.Name = "Cmb_HostType"
		Me.Cmb_HostType.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_HostType.TabIndex = 71
		'
		'Txt_Add1
		'
		Me.Txt_Add1.Location = New System.Drawing.Point(74, 329)
		Me.Txt_Add1.Name = "Txt_Add1"
		Me.Txt_Add1.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Add1.TabIndex = 70
		'
		'Txt_Add2
		'
		Me.Txt_Add2.Location = New System.Drawing.Point(74, 348)
		Me.Txt_Add2.Name = "Txt_Add2"
		Me.Txt_Add2.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Add2.TabIndex = 69
		'
		'Cmb_EndWord
		'
		Me.Cmb_EndWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_EndWord.FormattingEnabled = true
		Me.Cmb_EndWord.Location = New System.Drawing.Point(75, 248)
		Me.Cmb_EndWord.Name = "Cmb_EndWord"
		Me.Cmb_EndWord.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_EndWord.TabIndex = 66
		'
		'Cmb_Imibi
		'
		Me.Cmb_Imibi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Imibi.FormattingEnabled = true
		Me.Cmb_Imibi.Location = New System.Drawing.Point(75, 228)
		Me.Cmb_Imibi.Name = "Cmb_Imibi"
		Me.Cmb_Imibi.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Imibi.TabIndex = 65
		'
		'Cmb_Donation
		'
		Me.Cmb_Donation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Donation.FormattingEnabled = true
		Me.Cmb_Donation.Location = New System.Drawing.Point(75, 208)
		Me.Cmb_Donation.Name = "Cmb_Donation"
		Me.Cmb_Donation.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Donation.TabIndex = 64
		'
		'Txt_DeadName
		'
		Me.Txt_DeadName.Location = New System.Drawing.Point(75, 189)
		Me.Txt_DeadName.Name = "Txt_DeadName"
		Me.Txt_DeadName.Size = New System.Drawing.Size(180, 19)
		Me.Txt_DeadName.TabIndex = 62
		'
		'Cmb_Time2
		'
		Me.Cmb_Time2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Time2.FormattingEnabled = true
		Me.Cmb_Time2.Location = New System.Drawing.Point(75, 169)
		Me.Cmb_Time2.Name = "Cmb_Time2"
		Me.Cmb_Time2.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Time2.TabIndex = 61
		'
		'Cmb_Style
		'
		Me.Cmb_Style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Style.FormattingEnabled = true
		Me.Cmb_Style.Location = New System.Drawing.Point(75, 10)
		Me.Cmb_Style.Name = "Cmb_Style"
		Me.Cmb_Style.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Style.TabIndex = 60
		'
		'Cmb_SeasonWord
		'
		Me.Cmb_SeasonWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_SeasonWord.FormattingEnabled = true
		Me.Cmb_SeasonWord.Location = New System.Drawing.Point(75, 70)
		Me.Cmb_SeasonWord.Name = "Cmb_SeasonWord"
		Me.Cmb_SeasonWord.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_SeasonWord.TabIndex = 59
		'
		'Cmb_Time1
		'
		Me.Cmb_Time1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Time1.FormattingEnabled = true
		Me.Cmb_Time1.Location = New System.Drawing.Point(75, 90)
		Me.Cmb_Time1.Name = "Cmb_Time1"
		Me.Cmb_Time1.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Time1.TabIndex = 58
		'
		'Cmb_DeathWay
		'
		Me.Cmb_DeathWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_DeathWay.FormattingEnabled = true
		Me.Cmb_DeathWay.Location = New System.Drawing.Point(75, 149)
		Me.Cmb_DeathWay.Name = "Cmb_DeathWay"
		Me.Cmb_DeathWay.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_DeathWay.TabIndex = 57
		'
		'Txt_Name
		'
		Me.Txt_Name.Location = New System.Drawing.Point(75, 130)
		Me.Txt_Name.Name = "Txt_Name"
		Me.Txt_Name.Size = New System.Drawing.Size(180, 19)
		Me.Txt_Name.TabIndex = 55
		'
		'Cmb_Title
		'
		Me.Cmb_Title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Cmb_Title.FormattingEnabled = true
		Me.Cmb_Title.Location = New System.Drawing.Point(75, 110)
		Me.Cmb_Title.Name = "Cmb_Title"
		Me.Cmb_Title.Size = New System.Drawing.Size(180, 20)
		Me.Cmb_Title.TabIndex = 52
		'
		'Lbl_PS1
		'
		Me.Lbl_PS1.Location = New System.Drawing.Point(5, 466)
		Me.Lbl_PS1.Name = "Lbl_PS1"
		Me.Lbl_PS1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS1.TabIndex = 41
		Me.Lbl_PS1.Text = "追伸１："
		'
		'Lbl_PS2
		'
		Me.Lbl_PS2.Location = New System.Drawing.Point(5, 486)
		Me.Lbl_PS2.Name = "Lbl_PS2"
		Me.Lbl_PS2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS2.TabIndex = 40
		Me.Lbl_PS2.Text = "追伸２："
		'
		'Lbl_PS3
		'
		Me.Lbl_PS3.Location = New System.Drawing.Point(5, 505)
		Me.Lbl_PS3.Name = "Lbl_PS3"
		Me.Lbl_PS3.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS3.TabIndex = 39
		Me.Lbl_PS3.Text = "追伸３："
		'
		'Lbl_PS4
		'
		Me.Lbl_PS4.Location = New System.Drawing.Point(5, 524)
		Me.Lbl_PS4.Name = "Lbl_PS4"
		Me.Lbl_PS4.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS4.TabIndex = 38
		Me.Lbl_PS4.Text = "追伸４："
		'
		'Lbl_PS5
		'
		Me.Lbl_PS5.Location = New System.Drawing.Point(5, 543)
		Me.Lbl_PS5.Name = "Lbl_PS5"
		Me.Lbl_PS5.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS5.TabIndex = 37
		Me.Lbl_PS5.Text = "追伸５："
		'
		'Lbl_PS6
		'
		Me.Lbl_PS6.Location = New System.Drawing.Point(5, 562)
		Me.Lbl_PS6.Name = "Lbl_PS6"
		Me.Lbl_PS6.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_PS6.TabIndex = 36
		Me.Lbl_PS6.Text = "追伸６："
		'
		'Lbl_EndWord
		'
		Me.Lbl_EndWord.Location = New System.Drawing.Point(5, 252)
		Me.Lbl_EndWord.Name = "Lbl_EndWord"
		Me.Lbl_EndWord.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_EndWord.TabIndex = 31
		Me.Lbl_EndWord.Text = "結語："
		'
		'Lbl_CeremonyDate
		'
		Me.Lbl_CeremonyDate.Location = New System.Drawing.Point(5, 272)
		Me.Lbl_CeremonyDate.Name = "Lbl_CeremonyDate"
		Me.Lbl_CeremonyDate.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_CeremonyDate.TabIndex = 30
		Me.Lbl_CeremonyDate.Text = "法要年月日："
		'
		'Lbl_Add1
		'
		Me.Lbl_Add1.Location = New System.Drawing.Point(5, 331)
		Me.Lbl_Add1.Name = "Lbl_Add1"
		Me.Lbl_Add1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Add1.TabIndex = 29
		Me.Lbl_Add1.Text = "住所１："
		'
		'Lbl_Add2
		'
		Me.Lbl_Add2.Location = New System.Drawing.Point(5, 351)
		Me.Lbl_Add2.Name = "Lbl_Add2"
		Me.Lbl_Add2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Add2.TabIndex = 28
		Me.Lbl_Add2.Text = "住所２："
		'
		'Lbl_HostType
		'
		Me.Lbl_HostType.Location = New System.Drawing.Point(5, 371)
		Me.Lbl_HostType.Name = "Lbl_HostType"
		Me.Lbl_HostType.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostType.TabIndex = 27
		Me.Lbl_HostType.Text = "施主・喪主："
		'
		'Lbl_HostName1
		'
		Me.Lbl_HostName1.Location = New System.Drawing.Point(5, 390)
		Me.Lbl_HostName1.Name = "Lbl_HostName1"
		Me.Lbl_HostName1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName1.TabIndex = 26
		Me.Lbl_HostName1.Text = "喪主名："
		'
		'Lbl_HostName2
		'
		Me.Lbl_HostName2.Location = New System.Drawing.Point(5, 409)
		Me.Lbl_HostName2.Name = "Lbl_HostName2"
		Me.Lbl_HostName2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName2.TabIndex = 25
		Me.Lbl_HostName2.Text = "喪主名２："
		'
		'Lbl_HostName3
		'
		Me.Lbl_HostName3.Location = New System.Drawing.Point(5, 427)
		Me.Lbl_HostName3.Name = "Lbl_HostName3"
		Me.Lbl_HostName3.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_HostName3.TabIndex = 24
		Me.Lbl_HostName3.Text = "喪主名３："
		'
		'Lbl_HostName4
		'
		Me.Lbl_HostName4.Location = New System.Drawing.Point(5, 447)
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
		Me.Lbl_SeasonWord.Location = New System.Drawing.Point(5, 73)
		Me.Lbl_SeasonWord.Name = "Lbl_SeasonWord"
		Me.Lbl_SeasonWord.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_SeasonWord.TabIndex = 21
		Me.Lbl_SeasonWord.Text = "季語："
		'
		'Lbl_Time1
		'
		Me.Lbl_Time1.Location = New System.Drawing.Point(5, 93)
		Me.Lbl_Time1.Name = "Lbl_Time1"
		Me.Lbl_Time1.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Time1.TabIndex = 20
		Me.Lbl_Time1.Text = "時期１："
		'
		'Lbl_Title
		'
		Me.Lbl_Title.Location = New System.Drawing.Point(5, 114)
		Me.Lbl_Title.Name = "Lbl_Title"
		Me.Lbl_Title.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Title.TabIndex = 19
		Me.Lbl_Title.Text = "続柄："
		'
		'Lbl_Name
		'
		Me.Lbl_Name.Location = New System.Drawing.Point(5, 132)
		Me.Lbl_Name.Name = "Lbl_Name"
		Me.Lbl_Name.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Name.TabIndex = 18
		Me.Lbl_Name.Text = "俗名："
		'
		'Lbl_DeathWay
		'
		Me.Lbl_DeathWay.Location = New System.Drawing.Point(5, 152)
		Me.Lbl_DeathWay.Name = "Lbl_DeathWay"
		Me.Lbl_DeathWay.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_DeathWay.TabIndex = 17
		Me.Lbl_DeathWay.Text = "死亡告知："
		'
		'Lbl_Time2
		'
		Me.Lbl_Time2.Location = New System.Drawing.Point(5, 171)
		Me.Lbl_Time2.Name = "Lbl_Time2"
		Me.Lbl_Time2.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Time2.TabIndex = 16
		Me.Lbl_Time2.Text = "時期２："
		'
		'Lbl_DeadName
		'
		Me.Lbl_DeadName.Location = New System.Drawing.Point(5, 191)
		Me.Lbl_DeadName.Name = "Lbl_DeadName"
		Me.Lbl_DeadName.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_DeadName.TabIndex = 15
		Me.Lbl_DeadName.Text = "戒名："
		'
		'Lbl_Donation
		'
		Me.Lbl_Donation.Location = New System.Drawing.Point(5, 211)
		Me.Lbl_Donation.Name = "Lbl_Donation"
		Me.Lbl_Donation.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Donation.TabIndex = 14
		Me.Lbl_Donation.Text = "供え物："
		'
		'Lbl_Imibi
		'
		Me.Lbl_Imibi.Location = New System.Drawing.Point(5, 232)
		Me.Lbl_Imibi.Name = "Lbl_Imibi"
		Me.Lbl_Imibi.Size = New System.Drawing.Size(81, 18)
		Me.Lbl_Imibi.TabIndex = 13
		Me.Lbl_Imibi.Text = "忌日："
		'
		'Pnl_Menu01
		'
		Me.Pnl_Menu01.Controls.Add(Me.Grb_Contents)
		Me.Pnl_Menu01.Location = New System.Drawing.Point(4, 153)
		Me.Pnl_Menu01.Name = "Pnl_Menu01"
		Me.Pnl_Menu01.Size = New System.Drawing.Size(359, 592)
		Me.Pnl_Menu01.TabIndex = 3
		'
		'Pnl_Main
		'
		Me.Pnl_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Pnl_Main.AutoScroll = true
		Me.Pnl_Main.AutoScrollMargin = New System.Drawing.Size(5, 5)
		Me.Pnl_Main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.Pnl_Main.BackColor = System.Drawing.Color.White
		Me.Pnl_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Pnl_Main.Controls.Add(Me.Pnl_PanelAdjuster)
		Me.Pnl_Main.Location = New System.Drawing.Point(369, 10)
		Me.Pnl_Main.Name = "Pnl_Main"
		Me.Pnl_Main.Size = New System.Drawing.Size(766, 685)
		Me.Pnl_Main.TabIndex = 17
		'
		'Pnl_PanelAdjuster
		'
		Me.Pnl_PanelAdjuster.BackColor = System.Drawing.Color.Transparent
		Me.Pnl_PanelAdjuster.Controls.Add(Me.Pic_Main)
		Me.Pnl_PanelAdjuster.Controls.Add(Me.Pnl_Frame)
		Me.Pnl_PanelAdjuster.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_PanelAdjuster.Name = "Pnl_PanelAdjuster"
		Me.Pnl_PanelAdjuster.Size = New System.Drawing.Size(374, 333)
		Me.Pnl_PanelAdjuster.TabIndex = 17
		'
		'Pic_Main
		'
		Me.Pic_Main.BackColor = System.Drawing.Color.Transparent
		Me.Pic_Main.ErrorImage = Nothing
		Me.Pic_Main.InitialImage = Nothing
		Me.Pic_Main.Location = New System.Drawing.Point(0, 0)
		Me.Pic_Main.Name = "Pic_Main"
		Me.Pic_Main.Size = New System.Drawing.Size(296, 254)
		Me.Pic_Main.TabIndex = 16
		Me.Pic_Main.TabStop = false
		Me.Pic_Main.WaitOnLoad = true
		'
		'Pnl_Frame
		'
		Me.Pnl_Frame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Pnl_Frame.Location = New System.Drawing.Point(0, 0)
		Me.Pnl_Frame.Name = "Pnl_Frame"
		Me.Pnl_Frame.Size = New System.Drawing.Size(339, 294)
		Me.Pnl_Frame.TabIndex = 18
		'
		'PrintReport
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1176, 750)
		Me.Controls.Add(Me.Pnl_Main)
		Me.Controls.Add(Me.Pnl_Menu01)
		Me.Controls.Add(Me.Grb_Common)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "PrintReport"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Print"
		AddHandler FormClosed, AddressOf Me.PrintReport_FormClosed
		AddHandler Load, AddressOf Me.Print_Load
		Me.Grb_Common.ResumeLayout(false)
		Me.Grb_Common.PerformLayout
		Me.Grb_Contents.ResumeLayout(false)
		Me.Grb_Contents.PerformLayout
		Me.Pnl_Menu01.ResumeLayout(false)
		Me.Pnl_Main.ResumeLayout(false)
		Me.Pnl_PanelAdjuster.ResumeLayout(false)
		CType(Me.Pic_Main,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private Pnl_Frame As System.Windows.Forms.Panel
	Private Pnl_PanelAdjuster As System.Windows.Forms.Panel
	Friend Txt_Namae As System.Windows.Forms.TextBox
	Friend Cmb_PointHyodai As System.Windows.Forms.ComboBox
	Friend Cmb_PointNamae As System.Windows.Forms.ComboBox
	Private Lbl_Namae As System.Windows.Forms.Label
	Private LblNamae As System.Windows.Forms.Label
	Friend Cmb_Hyodai As System.Windows.Forms.ComboBox
	
	Private Btn_Print As System.Windows.Forms.Button
	Private Pnl_Main As System.Windows.Forms.Panel
	Private Lbl_year As System.Windows.Forms.Label
	Private Lbl_Day As System.Windows.Forms.Label
	Private Lbl_Month As System.Windows.Forms.Label
	Private Btn_Dtp As System.Windows.Forms.Button
	Friend Cmb_Year As System.Windows.Forms.ComboBox
	Friend Cmb_Month As System.Windows.Forms.ComboBox
	Friend Cmb_Day As System.Windows.Forms.ComboBox
	Friend Cmb_PointPS1 As System.Windows.Forms.ComboBox
	Friend Cmb_PointHostName4 As System.Windows.Forms.ComboBox
	Friend Cmb_PointHostName3 As System.Windows.Forms.ComboBox
	Friend Cmb_Title As System.Windows.Forms.ComboBox
	Friend Txt_Name As System.Windows.Forms.TextBox
	Friend Cmb_Time1 As System.Windows.Forms.ComboBox
	Friend Cmb_SeasonWord As System.Windows.Forms.ComboBox
	Friend Cmb_Style As System.Windows.Forms.ComboBox
	Friend Cmb_Time2 As System.Windows.Forms.ComboBox
	Friend Txt_DeadName As System.Windows.Forms.TextBox
	Friend Cmb_Donation As System.Windows.Forms.ComboBox
	Friend Cmb_Imibi As System.Windows.Forms.ComboBox
	Friend Cmb_EndWord As System.Windows.Forms.ComboBox
	Friend Txt_Add2 As System.Windows.Forms.TextBox
	Friend Txt_Add1 As System.Windows.Forms.TextBox
	Friend Cmb_HostType As System.Windows.Forms.ComboBox
	Friend Txt_PS1 As System.Windows.Forms.TextBox
	Friend Cmb_PointTitle As System.Windows.Forms.ComboBox
	Friend Txt_HostName4 As System.Windows.Forms.TextBox
	Friend Txt_HostName3 As System.Windows.Forms.TextBox
	Friend Txt_HostName2 As System.Windows.Forms.TextBox
	Friend Txt_PS4 As System.Windows.Forms.TextBox
	Friend Txt_HostName1 As System.Windows.Forms.TextBox
	Friend Txt_PS5 As System.Windows.Forms.TextBox
	Friend Txt_PS2 As System.Windows.Forms.TextBox
	Friend Txt_PS6 As System.Windows.Forms.TextBox
	Friend Txt_PS3 As System.Windows.Forms.TextBox
	Friend Cmb_PointHostName2 As System.Windows.Forms.ComboBox
	Friend Cmb_PointHostName1 As System.Windows.Forms.ComboBox
	Friend Cmb_PointHostType As System.Windows.Forms.ComboBox
	Friend Cmb_PointAdd1 As System.Windows.Forms.ComboBox
	Friend Cmb_PointCeremonyDate As System.Windows.Forms.ComboBox
	Friend Cmb_PointEndWord As System.Windows.Forms.ComboBox
	Friend Cmb_PointImibi As System.Windows.Forms.ComboBox
	Friend Cmb_PointDeadName As System.Windows.Forms.ComboBox
	Friend Cmb_PointName As System.Windows.Forms.ComboBox
	Private Lbl_Thick As System.Windows.Forms.Label
	Private Lbl_Rate As System.Windows.Forms.Label
	Friend Cmb_DeathWay As System.Windows.Forms.ComboBox
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
	Friend Cmb_Thickness As System.Windows.Forms.ComboBox
	Private Lbl_Size As System.Windows.Forms.Label
	Private Lbl_SizeW As System.Windows.Forms.Label
	Private Lbl_SizeH As System.Windows.Forms.Label
	Private Lbl_PrintDir As System.Windows.Forms.Label
	Private Lbl_Font As System.Windows.Forms.Label
	Private Txt_SizeW As System.Windows.Forms.TextBox
	Private Txt_PrintDir As System.Windows.Forms.TextBox
	Private Txt_SizeY As System.Windows.Forms.TextBox
	Friend Cmb_Magnify As System.Windows.Forms.ComboBox
	Friend Cmb_Size As System.Windows.Forms.ComboBox
	Friend Cmb_Font As System.Windows.Forms.ComboBox
	Private Grb_Contents As System.Windows.Forms.GroupBox
	Private Grb_Common As System.Windows.Forms.GroupBox
	Private Pnl_Menu01 As System.Windows.Forms.Panel
	Private Pic_Main As System.Windows.Forms.PictureBox

	

	

End Class