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
		Dim sqlText as String = " SELECT "
		Dim mainTxt As New ArrayList
												'インチ = 0.0254m
		sqlText &= "  tbl_txt_txt "				'メインの文章 　
		sqlText &= " ,tbl_txt_defset "			'初期設定							0) 縦 = 0・横 = 1, 1) ポイント 2) x座標（幅）, 3) y座標上,　4) y座標下, 5) 基本の改行ピッチ(コンマで区切る）
		sqlText &= " ,tbl_txt_ypos "			'開始位置の変更（文を下げたりする時）ある時 = 値・無い時 = 9999
		sqlText &= " ,tbl_txt_ystyle "			'列スタイル 						上から並べる = 0・下から並べる  = 1・天地を合わせる = 2
		sqlText &= " ,tbl_txt_ins "				'挿入文字の有無					ある時 = 値(コンマで区切る）無い時 9999, 9999, 9999
		sqlText &= " ,tbl_txt_target0 "			'挿入文字							ターゲットオブジェクト, ポイントオブジェクト
		sqlText &= " ,tbl_txt_target1 "			'挿入文字							ターゲットオブジェクト, ポイントオブジェクト
		sqlText &= " ,tbl_txt_target2"			'挿入文字							ターゲットオブジェクト, ポイントオブジェクト
		sqlText &= " ,tbl_txt_xpos "			'行ピッチの変更					ある時 = 値・ない時 = 9999
		sqlText &= "  FROM tbl_txt "
		sqlText &= "  WHERE "
		sqlText &= "  tbl_txt_grid = 0 " 'パラメーターで選択
		sqlText &= "  ORDER BY "
		sqlText &= "  tbl_txt_order "
	
		mainTxt = s.GetSqlArray(sqlText)

		'Set PictureBox size
		With Pic_Main
			.Size = New Size(1800, 668)			'TODO: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1800,668)
		End With

		'文字描画仕様
		'DB内の文字列を取り出し文字に分割、配列に格納して更に配列に格納	
		'***初期設定(縦か横か, x座標, y座標上,　y座標下, 基本の改行ピッチ）
		'開始位置（y座標）の変更 ->　あるかどうか？
		'（文を下げたりする時）
		'列スタイル -> 1) 上から並べる
		'			  2) 下から並べる
		'			  3) ピッチ整えて天地を合わせる -> ピッチに使える幅 = 最大幅 - フォントサイズ　これをピッチ数（フォント数-1）で割る
		'挿入文字あるかどうか？ -> 1) 場所は？　　挿入される値を持つオブジェクト, それのポイント設定するオブジェクト, フォントサイズの確認
		'						2) 次へ
		'行ピッチ変更（フォント変更） -> 1) あるならば最大のものにあわせる（基本のピッチに足す）
		'			  				 2)　次へ
		'行ピッチの変更（改行） -> 1) 最後の分からのx座標は？
		'（住所等　別の位置に変わる時）
		'http://penguinlab.jp/blog/post/117

		'文章を単語に分割する
		Dim lineCounter As Integer = mainTxt.Count - 1									'メインセンテンスの行数
		Dim wordCounter As Integer = 0 													'メインセンテンスの全ての行の文字数
		Dim wordStorager(lineCounter) As Array									
		
		'メインセンテンスの単語を格納（列ごとに単語に分割した配列に入っている）
		For i As Integer = 0 To lineCounter - 1
			Dim subStorager(CStr(mainTxt(i)("tbl_txt_txt")).Length) As String

			For j As Integer = 0 To CStr(mainTxt(i)("tbl_txt_txt")).Length Step 1
				Dim wordInLine As String = ""
				wordInLine = CStr(mainTxt(i)("tbl_txt_txt"))
	
				If j = 0 Then
					subStorager(0) = wordInLine.Length.ToString()						'ある任意の行の文字数（配列数）を格納
					Continue For
				End If
				subStorager(j) = wordInLine.Substring(j-1, 1)
				wordCounter = wordCounter + 1	
			Next j
			wordStorager(i) = subStorager										'文字配列を配列に格納
			
		Next i
		
		Dim g(wordCounter) As System.Drawing.Graphics						'メインセンテンスの全ての文字数文のオブジェクトを宣言
		
		'TODO: 動的にグラフィックオブジェクトを作成する	現状基本の行数と文字数は取れる	
		'初期設定の取り込み
		Dim defSetStr As String = mainTxt.Item(0)("tbl_txt_defset") '0) 縦 = 0・横 = 1, 1) ポイント 2) x座標（幅）, 3) y座標上,　4) y座標下, 5) 基本の改行ピッチ
		Dim defSetAr() As String = defSetStr.Split(",")
		'文字ピッチの取得
		Dim basicPitch As Integer = PointPitCal(defSetAr(1)
		'TODO: 縦書きの時
		If defSetAr(0) = "0" Then
			Dim xPitch As Integer = 1700
			Dim yPitch As Integer = 40
			For i As Integer = 0  To lineCounter Step 1
				'挿入文字があるか
				Dim txtInsAr() As String = CStr(mainTxt(i)("tbl_txt_ins")).Split(",")
				If txtInsAr(0) = "9999" Then	'挿入文字無し
					'文章スタイルはどれか
					Select Case CInt(mainTxt(i)("tbl_txt_ystyle"))
						Case 0	'上
							Dim str As Integer  = CInt(wordStorager(i).GetValue(0))
							If CInt(wordStorager(i).GetValue(0)) < 25 Then				'文字が範囲以内ならそのまま上から置いていく
								For j As Integer = 0 To CInt(wordStorager(i).GetValue(0)) Step 1
									If j = 0 Then
										Continue For
									End If
									g(j) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
									g(j).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
									g(j).DrawString(wordStorager(i)(j), New Font("MS 明朝", 24), Brushes.Black, xPitch, yPitch, New StringFormat(StringFormatFlags.DirectionVertical))
									yPitch = yPitch + 35							'yピッチ増加
								Next j
								yPitch = 40											'yピッチ初期化
								xPitch = xPitch - 50								'改行（左へ）
							End If						
						Case 1	'下
							'TODO
						Case 2	'天地
							'TODO: 文字のピッチを計算
							g(j) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
									g(j).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
									g(j).DrawString(wordStorager(i)(j), New Font("MS 明朝", 24), Brushes.Black, xPitch, yPitch, New StringFormat(StringFormatFlags.DirectionVertical))
									yPitch = yPitch + 35							'yピッチ増加
					End Select
				Else
				'TODO: 挿入文字があるとき
				
				End If
				
				'TODO: フォントサイズが違う時列ピッチを修正
				

			Next i
			
		Else
			'TODO: 横書きの時
		End If
		
		g(wordCounter).Dispose()
		g(wordCounter) = Nothing
		
		End Sub

'		'Test -> OK
'		Dim g As System.Drawing.Graphics
'		With Pic_Main
'			.Image = New Bitmap(.Size.Width, .Size.Height)
'			g = System.Drawing.Graphics.FromImage(.Image)
'		End With
'		
'		g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
'		g.DrawString("謹啓", New Font("MS 明朝", 35), Brushes.Red, -7, 0, New StringFormat(StringFormatFlags.DirectionVertical))
'		g.Dispose()
		

	
	
'		For i As Integer = 0 To maintxt.Count - 1 Step 1
'			g(i) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
'			g(i).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
'			g(i).DrawString(maintxt(i)("tbl_txt_txt"), New Font("ＭＳ Ｐ明朝", 24), Brushes.Black, cnt, 70, New StringFormat(StringFormatFlags.DirectionVertical))
'			cnt = cnt - 50	
'		Next i

'		g(maintxt.Count - 1).Dispose()
'		For i As Integer = 0 To 14 Step 1
'			g(i) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
'			g(i).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
'			g(i).DrawString("謹", New Font("ＭＳ Ｐ明朝", 32), Brushes.Black, cnt, yPos, New StringFormat(StringFormatFlags.DirectionVertical))
'			
'			yPos = yPos + 38
'		Next i	
#Region "Pitch"

''''■PointPitCal
''' <summary>任意のポイントに対する必要なピッチ</summary>
''' <param name="point">ポイント数</param>
''' <returns>y軸の文字位置を決める定数を返す</returns>
Public Function PointPitCal(point As Integer) As Integer
	Dim resultPit As Integer = 0
	'ポイント　-> ピクセル変換
	Dim wordPix As Integer = CInt(point * (96 / 72))
	resultPit = wordPix + 4
	Return resultPit
	
End Function
	
''''■PitchCal
''' <summary>天地の時のピッチを計算</summary>
''' <param name="topYPos">開始位置</param>
''' <param name="bottomYPos">修了位置</param>
''' <param name="wordAr">単語配列</param>
''' <param name="point">ポイント数</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
Public Function PitchCal(topYPos As Integer, bottomYPos As Integer, wordAr As Array, point As Integer) As Integer
	Dim resultPitch As Integer = 0
	'配列数をカウント
	Dim arCounter As Double = wordAr.Length
	'ポイント　-> ピクセル変換
	Dim wordPix As Double = point * (96 / 72) 
	'文字の長さ
	Dim arLength As  Double = arCounter * wordPix
	'文字収納可能範囲
	Dim wordArea As Double = CDbl(bottomYPos - topYPos)
	'文字の長さと収納可能範囲を検証
	If (wordArea - arlength) > 0 Then	'ピッチを取れる余裕がある時
		resultPitch = CInt((wordPix - arLength) / (arCounter - 1))
		Return resultPitch
	Else								'余裕がない時（ビチビチの時　マイナスの値でピッチ幅を減らす）
		resultPitch = CInt((System.Math.Abs(wordArea - arLength) / (arCounter - 1)) * -1)
		Return resultPitch
	End If
	
End Function
#End Region

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
