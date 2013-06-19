'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class PrintReport
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub Print_Load(sender As Object, e As EventArgs)
		'Set font
		'TODO: Choose several fonts for set up
		Dim installedFont As New System.Drawing.Text.InstalledFontCollection
		Dim fontFamilies As FontFamily() = installedFont.Families
		
		For Each j As FontFamily In fontFamilies
			Me.Cmb_Font.Items.Add(j.Name)
		Next j
		'Set values on each combo
		Dim f As New SetCombo
		With f
			.SetCombo(Me.Cmb_Size, SetEnvList.envList("002"), "奉書挨拶状", "0", False)
			'.SetCombo(Me.Cmb_Font, SetEnvList.envList(""), "", "", True)		'Pending "FONT"
			.SetCombo(Me.Cmb_Magnify, SetEnvList.envList("400"), "100", "100", False)
			.SetCombo(Me.Cmb_Thickness, SetEnvList.envList("401"), "40", "40", False)
			.SetCombo(Me.Cmb_Style, SetEnvList.envList("001"), "", "", True)
			.SetCombo(Me.Cmb_SeasonWord, SetEnvList.envList("100"), "", "", True)
			.SetCombo(Me.Cmb_Time1, SetEnvList.envList("101"), "", "", True)
			.SetCombo(Me.Cmb_Title, SetEnvList.envList("200"), "", "", True)
			.SetCombo(Me.Cmb_DeathWay, SetEnvList.envList("201"), "", "", True)
			.SetCombo(Me.Cmb_Time2, SetEnvList.envList("106"), "", "", True)
			.SetCombo(Me.Cmb_Donation, SetEnvList.envList("300"), "", "", True)
			.SetCombo(Me.Cmb_Imibi, SetEnvList.envList("102"), "", "", True)
			.SetCombo(Me.Cmb_EndWord, SetEnvList.envList("202"), "", "", True)
			.SetCombo(Me.Cmb_Year, SetEnvList.envList("105"), "", "", True)
			.SetCombo(Me.Cmb_Month, SetEnvList.envList("103"), "", "", True)
			.SetCombo(Me.Cmb_Day, SetEnvList.envList("104"), "", "", True)
			.SetCombo(Me.Cmb_HostType, SetEnvList.envList("301"), "", "", True)
		End With
		
		f = Nothing
		'Format form
		Call ClearForm(0)
		
		'Aquire basic txts
		Dim s As New SelectSql
		Dim mainTxt As New ArrayList
		mainTxt = s.GetSqlArray(" SELECT tbl_txt_txt FROM tbl_txt WHERE tbl_txt_grid = 0 ORDER BY tbl_txt_order ")

		Dim g(27) As System.Drawing.Graphics
		Dim cnt As Integer = 1400
		
		With Pic_Main
			.Size = New Size(1500, 668)			'TODO: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1500,668)
		End With
'		For i As Integer = 0 To maintxt.Count - 1 Step 1
'			g(i) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
'			g(i).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
'			g(i).DrawString(maintxt(i)("tbl_txt_txt"), New Font("ＭＳ Ｐ明朝", 24), Brushes.Black, cnt, 70, New StringFormat(StringFormatFlags.DirectionVertical))
'			cnt = cnt - 50	
'		Next i
'		g(maintxt.Count - 1).Dispose()

		'案
		'たてか横か
		'DB内の文字列を取り出し文字に分割、配列に格納して更に配列に格納	
		'***開始位置 -> ソース内に持っておくものとする
		'***列ピッチ -> メインの文章のピッチ（基本のピッチ）はソース内に持っておくものとする
		'挿入文字が通常より大きいときは列ピッチも合わせて変更する
		'選択文字の挿入があるかまた位置はどこか
		'挿入される値を持つオブジェクト
		'行ピッチ -> 1) 上から並べるだけ
		'			2) ピッチ整えて天地を合わせる -> ピッチ計算必要　ピッチに使える幅 = 最大幅 - フォントサイズ　これをピッチ数（フォント数-1）で割る
		'列ピッチの変更 -> 住所等　別の位置に変わる時
		'開始位置の変更 ->　文を下げたりする時

		'Split txts into words
		Dim arrayCount As Integer = mainTxt.Count - 1
		Dim wordStorager(arrayCount) As Array
		For i As Integer = 0 To arrayCount - 1
			Dim wordCounter As String = CStr(mainTxt(i)("tbl_txt_txt"))
			Dim subStorager(CInt(wordCounter.Length) - 1) As String
			For j As Integer = 0 To wordCounter.Length - 1　　
				subStorager(j) = wordCounter.Substring(j, 1)
			Next j
			wordStorager(i) = subStorager
		Next i
		
		'Check word pitch
		For i As Integer = 0 To arrayCount Step 1
			Dim pitchSpace As Integer = 0
			pitchSpace = 525 - (30 * wordStorager(i).Length)
			pitchSpace = 
		Next i
			
			'天地均等の場合、場所に指定がある場合　フラグ？
			'上から並べていく、
		

		Dim yPos As Integer = 70

		For i As Integer = 0 To 14 Step 1
			g(i) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
			g(i).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g(i).DrawString("謹", New Font("ＭＳ Ｐ明朝", 32), Brushes.Black, cnt, yPos, New StringFormat(StringFormatFlags.DirectionVertical))
			
			yPos = yPos + 38
		Next i




'		'Test -> OK
'		Dim g As System.Drawing.Graphics
'		With Pic_Main
'			.Image = New Bitmap(.Size.Width, .Size.Height)
'			g = System.Drawing.Graphics.FromImage(.Image)
'		End With
'		
'		g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
'		g.DrawString("Hello, World", New Font("Terminal", 35), Brushes.Red, 720, 20, New StringFormat(StringFormatFlags.DirectionVertical))
'		g.Dispose()
		
	End Sub

#Region	"ClearForm"
''''■ClearForm
''' <summary>Format form</summary>
''' <param name="reportType">Kind of paper sytle</param>
''' <returns>Void</returns>	
Public Sub ClearForm(reportType As Integer)
	Dim currentDt As String()
	currentDt = Today.ToString("yyyy/M/d").Split("/")
		Select Case reportType
			Case 0		'奉書挨拶状
				With Me
					'Common part
					.Cmb_Size.SelectedValue = 0								'TODO: Indexで統一？
					.Cmb_Font.SelectedIndex = 70
					.Cmb_Magnify.SelectedValue = 100
					.Cmb_Thickness.SelectedValue = 40
					.Txt_Copy.Text = "1"
					'Specific part
					.Cmb_Style.SelectedValue = 0
					.Cmb_SeasonWord.SelectedValue = " 厳寒の候"				'TODO: Get along with season
					.Cmb_Time1.SelectedValue = "先般"
					.Cmb_Title.SelectedValue = "亡父"
					.Txt_Name.Text = "儀"
					.Cmb_DeathWay.SelectedValue = "死去"
					.Cmb_Time2.SelectedValue = "本日"
					.Cmb_Time2.Enabled = False
					.Txt_DeadName.Text = ""
					.Txt_DeadName.Enabled = False
					.Cmb_Donation.SelectedValue = 0
					.Cmb_Imibi.SelectedValue = "忌明の法要"
					.Cmb_EndWord.SelectedValue = "敬具"
					.Cmb_Year.SelectedValue = currentDt(0)
					.Cmb_Month.SelectedValue = currentDt(1)
					.Cmb_Day.SelectedValue = currentDt(2)
					.Cmb_HostType.SelectedValue = "施主"
					.Cmb_HostType.Enabled = False
					.Txt_PS1.Text = "追伸"									'TODO: From SQL
					.Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を" 	'TODO: From SQL
					.Txt_PS3.Text = "お届けさせて頂きました" 					'TODO: From SQL
					.Txt_PS4.Text = "御受納下さいます様お願い申し上げます" 		'TODO: From SQL
					'Font
					.Cmb_PointTitle.SelectedIndex = 34
					.Cmb_PointName.SelectedIndex	 = 34
					.Cmb_PointDeadName.SelectedIndex = 0
					.Cmb_PointDeadName.Enabled = False
					.Cmb_PointImibi.SelectedIndex = 34
					.Cmb_PointEndWord.SelectedIndex= 34
					.Cmb_PointCeremonyDate.SelectedIndex = 22
					.Cmb_PointAdd1.SelectedIndex = 19
					.Cmb_PointHostType.SelectedValue = 0
					.Cmb_PointHostType.Enabled = False
					.Cmb_PointHostName1.SelectedIndex = 34
					.Cmb_PointHostName2.SelectedIndex = 34
					.Cmb_PointHostName3.SelectedIndex = 34
					.Cmb_PointHostName4.SelectedIndex = 34
					.Cmb_PointPS1.SelectedIndex = 17
				End With
		    Case 1
				
		End Select
		
	End Sub
#End Region	

	Private Sub Btn_Dtp_Click(sender As Object, e As EventArgs)
		'END: Show Calender for easy entry
		Dim resultDate As String()
		Dim f As New Calender
		f.ShowDialog(Me)
		If f.returndDate <> "" Then
			resultDate =  f.returndDate.Split("/")
			
			Me.Cmb_Year.SelectedValue = resultDate(0)
			Me.Cmb_Month.SelectedValue = resultDate(1)
			Me.Cmb_Day.Selectedvalue = resultDate(2)
		
			f.Dispose()
			f = Nothing
		End If
	End Sub	
	
End Class
