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
#Region "文字描画仕様"
		'文字描画仕様
		'END: DB内の文字列を取り出し文字に分割、配列に格納して更に配列に格納
		'END: 初期設定(縦か横か, x座標, y座標上,　y座標下, 基本の改行ピッチ）
		
		'開始位置（y座標）の変更 ->　あるかどうか？
		'（文を下げたりする時）
		'END: 列スタイル -> 1) 上から並べる	
		'			       2) 下から並べる
		'			       3) ピッチ整えて天地を合わせる -> ピッチに使える幅 = 最大幅 - フォントサイズ　これをピッチ数（フォント数-1）で割る
		
		'END: 挿入文字あるかどうか？ -> 1) 場所は？　　挿入される値を持つオブジェクト, それのポイント設定するオブジェクト, フォントサイズの確認
		'						2) 次へ
		'メインテキストを読み込む時に実装する
		'行ピッチ変更（フォント変更） -> 1) あるならば最大のものにあわせる（基本のピッチに足す）
		'			  				 2)　次へ
		'END: 行ピッチの変更（改行） -> 1) 最後の分からのx座標は？
		'（住所等　別の位置に変わる時）
		
		'END: NEW フォントはやはりメインセンテンスの分はDBにおいておいたほうがよい。仕様を変更する
		'http://penguinlab.jp/blog/post/117
		#End Region
		
	Const basicPitch As Integer = 3
	
	Public Sub Print_Load(sender As Object, e As EventArgs)
'****************************************************************************************************
'
'		'フォントの設定を行う
'
'****************************************************************************************************
		'TODO: Choose several fonts for set up
		Dim installedFont As New System.Drawing.Text.InstalledFontCollection
		Dim fontFamilies As FontFamily() = installedFont.Families
		
		For Each j As FontFamily In fontFamilies
			Me.Cmb_Font.Items.Add(j.Name)
		Next j
		
		installedFont.Dispose()
		installedFont = Nothing
		
'****************************************************************************************************
'
'		'コンボ設定を行う
'
'****************************************************************************************************
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

'****************************************************************************************************
'
'		'コンボの値を保存
'
'****************************************************************************************************
	Dim optWord As New Hashtable
	'Format form
	Dim ClrFrm As New ClearForm
	Call ClrFrm.ClearForm(0, Me)
	
	ClrFrm = Nothing
	
	With me
	'挿入等に使う
	'Specific Part（HashTableに格納）
		optWord("Cmb_Style") = .Cmb_Style.SelectedValue
		optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue
		optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue
		optWord("Cmb_Title") = .Cmb_Title.SelectedValue
		optWord("Txt_Name") = .Txt_Name.Text
		optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue
		optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue
		optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue
		optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue
		optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue
		optWord("Cmb_Year") = .Cmb_Year.SelectedValue
		optWord("Cmb_Month") = .Cmb_Month.SelectedValue
		optWord("Cmb_Day") = .Cmb_Day.SelectedValue
		optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue
		optWord("Txt_PS1") = .Txt_PS1.Text
		optWord("Txt_PS1") = .Txt_PS2.Text
		optWord("Txt_PS1") = .Txt_PS3.Text
		optWord("Txt_PS1") = .Txt_PS4.Text

		'Font Size（HashTableに格納）
		optWord("Cmb_PointTitle") = .Cmb_PointTitle.SelectedItem  '★
		optWord("Cmb_PointName") = .Cmb_PointName.SelectedValue
		optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.SelectedValue
		optWord("Cmb_PointImibi") = .Cmb_PointImibi.SelectedValue
		optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.SelectedValue
		optWord("Cmb_PointDeremonyDate") = .Cmb_PointCeremonyDate.SelectedIndex
		optWord("Cmb_PointAdd1") = .Cmb_PointAdd1
		optWord("Cmb_PointHostType") = .Cmb_PointHostType
		optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.SelectedValue
		optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.SelectedValue
		optWord("Cmb_PointHostName3") = .Cmb_PointHostName2.SelectedValue
		optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.SelectedValue
		optWord("Cmb_PointPS1") = .Cmb_PointPS1.SelectedValue
	End With
'****************************************************************************************************
'
'		'DBより文章データの取り込み
'
'****************************************************************************************************
		Dim s As New SelectSql
		Dim sqlText as String = " SELECT "
		Dim mainTxt As New ArrayList　'CHK: 開放
																					'**参考　インチ = 0.0254m
		sqlText &= "  tbl_txt_txt "													'メインの文章 　
		sqlText &= " ,tbl_txt_newypos "												'開始位置の変更		ある時 = 値・無い時 = 9999
		sqlText &= " ,tbl_txt_ystyle "												'列スタイル 			上から並べる = 0・下から並べる  = 1・天地を合わせる = 2
		sqlText &= " ,tbl_txt_inspos "												'挿入文字の有無		ある時 = 値(コンマで区切る）無い時 9999, 9999, 9999
		sqlText &= " ,tbl_txt_targetword "											'挿入文字				文字コンボの値を格納したHashTableのキー名
		sqlText &= " ,tbl_txt_targetpoint "											'挿入文字				フォントサイズの値を格納したHashTableのキー名
		sqlText &= " ,tbl_txt_newxpos "												'新行ピッチ			ある時 = 値・ない時 = 9999
		sqlText &= " ,tbl_txt_newpoint "											'新フォントサイズ	
		sqlText &= "  FROM tbl_txt "
		sqlText &= "  WHERE "
		sqlText &= "  tbl_txt_grid = 0 " 											'TODO: パラメーターで選択 = Cmbで
		sqlText &= "  ORDER BY "
		sqlText &= "  tbl_txt_order "
	
		mainTxt = s.GetSqlArray(sqlText)

		Dim defset As String = ""
		Dim defSetAr() As String
		
		sqlText =  " SELECT "														'初期設定
		sqlText &= " tbl_defset"													'(0) 縦 = 0・横 = 1, (1) ポイント (2) x座標（幅), 
		sqlText &= " FROM tbl_defset"												'(3) y座標上,　(4) y座標下, (5) 基本の改行ピッチ
		sqlText &= " WHERE tbl_defset_id = 0"										'TODO: tbl_defset_idは上と連動させる
		
		defset = s.GetOneSql(sqlText)
		defsetAr = defSet.Split(",")
		
		s = nothing
		
		'Set PictureBox size
		With Pic_Main
			.Size = New Size(1800, 668)												'CHK: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1800,668)											'TODO: 可変に
		End With
		
'****************************************************************************************************
'
'		'DB内の文章を単語に分割する
'
'****************************************************************************************************
		Dim c As New Common
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim wordStorager(lineCounter) As Array
		Dim insWord As Array
		
		For i As Integer = 0 To lineCounter Step 1
			Dim insPos() As String													'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") <> "" Then								'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(",")				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する
				insWord = c.CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
										mainTxt(i)("tbl_txt_targetword"), _
										mainTxt(i)("tbl_txt_targetpoint"), _
										i, _
										optWord _
										)
				insFlg = True
			End If
			
			Dim loopCounter As Integer = CInt(CStr(mainTxt(i)("tbl_txt_txt")).Length)

			If insFlg = True Then													'挿入フラグが立っている時、挿入文字分をループカウンターに加算
				For j As Integer = 0 To 2 Step 1
					If Val(insPos(j)) <> CDbl(9999) Then
						loopCounter = loopCounter + insWord(j)(0)
					End If
				Next j
			End If
						
			Dim subStorager(loopCounter + 1) As String		'★END Nothing			'分割した単語（行単位）を一時保存する配列
			Dim wordInLine As String = CStr(mainTxt(i)("tbl_txt_txt")) 				'メインセンテンス
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim pointStrager As String = ""
			
			For j As Integer = 0 To loopCounter + 1 Step 1 '★END Nothing
				If j = 0 Then
					subStorager(0) = loopCounter.ToString()							'列の文字数（配列数）= 0 を格納
					Continue For
				End If
				
				If j = 1 Then
					Continue For 													'フォントサイズを格納の為
				End If
				
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If Val(insWord(k)(3)) + 2 =  j Then				'★END	2		'絶対位置を確認
						For l As Integer = 4 To Val(insWord(k)(0)) + 3
							subStorager(j) = insWord(k)(l)
							Call c.PointCollector(insWord(k)(1), pointStrager)
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（Nextで一つ増える為）
						k = k + 1
						Continue For
					Else
						subStorager(j) = wordInLine.Substring(m, 1)
						Call c.PointCollector(defSetAr(1), pointStrager)
						m = m + 1
					End If
				Else
					subStorager(j) = wordInLine.Substring(j-2, 1)	'★ -1
					Call c.PointCollector(defSetAr(1), pointStrager)
				End If
			Next j
			subStorager(1) = pointStrager											'フォントサイズを格納（コンマ文字列）
			wordStorager(i) = subStorager											'文字１つ１つを配列に格納
			insFlg = False
		Next i
		
'****************************************************************************************************
'
'		'文字を描画していく
'
'****************************************************************************************************
		'文字ピッチの取得(y軸文字位置用定数）
		Dim basicPitch As Integer = c.PointPitCal(CInt(defSetAr(1)))							'CHK: おそらく見直しになる -> OKかな？ 2013/6/29 mb
		'TODO: 縦書きの時
		If defSetAr(0) = "0" Then
			Dim xPitch As Single = CSng(defSetAr(2))	
			Dim yPitch As Single = CSng(defSetAr(3))
			Dim newYPitch As Single = 0
			Dim insColCnt As Integer = 0
			For i As Integer = 0  To lineCounter Step 1
				Select Case CInt(mainTxt(i)("tbl_txt_ystyle"))
					Case 0	'上															'END: 上の場合の文字ピッチを計算
						If c.PointDiffChecker(wordStorager(i)(1)) = True Then			'全て同じの時
							If i = 0 Then
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt((defSetAr(1))))
								xPitch = tempFontSize(1)
							Else
								Dim newXPos As Single = c.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									xPitch = xPitch - newXPos							'イレギュラー改行
								Else													'END: 文字サイズ＋ピッチへ 2013/7/2
									Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
									xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1) 
								End If
							End If
							
							newYPitch = c.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If
							
							Dim splitPoint() As String = wordStorager(i)(1).Split(",")
							
							Dim properPit As Single = c.PitchCal(yPitch, _
																CSng(defSetAr(4)), _
																wordStorager(i), _
																"ＭＳ Ｐ明朝", _
																splitPoint, _
																0, _
																Me _
																)
							Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
																						'END: y軸位置の変更を組み込む
						Else															'END: フォントサイズが違う時の文字位置と改列ピッチを求める 2013/7/2
							Dim maxWidth As Single										'END: イレギュラーサイズ時の描画方法を考える
							Dim irrXYPos As Array
							
							newYPitch = c.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If
							
							irrXYPos =  c.SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													"ＭＳ Ｐ明朝", _
													yPitch, _
													CSng(defSetAr(4)), _
													CSng(defSetAr(5)), _
													xPitch, _
													maxWidth, _
													Me
													)
							Call CreateWordDiff(wordStorager(i), "ＭＳ Ｐ明朝", irrXYPos)
							xPitch = xPitch - maxWidth
							
						End If
					Case 1	'下
						If c.PointDiffChecker(wordStorager(i)(1)) = True Then
							If i = 0 Then
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
								xPitch = tempFontSize(1)
							Else
								Dim newXPos As Single = c.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									xPitch = xPitch - newXPos
								Else
									Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
									xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1) 
								End If
							End If
							
							newYPitch = c.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If

							Dim splitPoint() As String = wordStorager(i)(1).Split(",")
						
							Dim properPit As Single = c.PitchCal(yPitch, _
																  CSng(defSetAr(4)), _
																wordStorager(i), _
																"ＭＳ Ｐ明朝", _
																splitPoint, _
																1, _
																Me _
																)
							If properPit > 0 
								Dim totalHeight As Single
								For j As Integer = 2 To CInt(wordStorager(i)(0)) + 1 Step 1
									Dim tempHeight() As Single = FontSizeCal(wordStorager(i)(j), "ＭＳ Ｐ明朝", CInt(splitPoint(j - 2)))
									totalHeight = totalHeight + properPit + tempHeight(0)	
								Next j
								totalHeight = Csng(defSetAr(4)) - (yPitch + totalHeight)
								Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, totalHeight, properPit)
							Else
								Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
							End If
						Else
							Dim maxWidth As Single	
							Dim irrXYPos As Array	
							
							irrXYPos =  c.SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													"ＭＳ Ｐ明朝", _
													yPitch, _
													CSng(defSetAr(4)), _
													CSng(defSetAr(5)), _
													xPitch, _
													maxWidth, _
													Me
													)
							Call CreateWordDiff(wordStorager(i), "ＭＳ Ｐ明朝", irrXYPos)
							
							xPitch = xPitch - maxWidth
						End If	
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						Dim newXPos As Single = c.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))

						If newXPos <> 0 Then
							xPitch = xPitch - newXPos									'イレギュラー改行
						else
							Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
							xPitch = xPitch - CSng(defsetAr(5)) - tempFontSize(1)
						End If
						
						newYPitch = c.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
						If newYPitch <> 0 Then
							yPitch = newYPitch
						End If
							
						Dim splitPoint() As String = wordStorager(i)(1).Split(",")
						Dim properPit As Single = c.PitchCal(yPitch, _
															CSng(defSetAr(4)), _
															wordStorager(i), _
															"ＭＳ Ｐ明朝", _
															splitPoint, _
															2, _
															Me _
															)'						'TODO フォント
						Call createWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
					End Select
			Next i
			
		Else
			'TODO: 横書きの時
		End If



    End Sub
'****************************************************************************************************
'
'		'描画用関数
'
'****************************************************************************************************
''''■FontSizeCal
''' <summary>文字の縦横高さを測る</summary>
''' <param name="word">計測したい文字</param>
''' <param name="font">フォント</param>
''' <param name="point">ポイント</param>
''' <returns>文字の 縦 = 0・横 = 1 を返す</returns>
	Public Function FontSizeCal(word As String, font As String, point As Integer) As Single()
		Dim resultAl(1) As Single 
		Dim stringFont As New Font(font, point, GraphicsUnit.Pixel)
		Dim stringSize As New SizeF
	
		Dim gr As Graphics = CreateGraphics()
		stringSize = gr.MeasureString(word, stringFont)
		resultAl(0) = stringSize.Height
		resultAl(1) = stringSize.Width

		gr.Dispose()
		stringFont.Dispose()
	
		gr = Nothing
		stringFont = Nothing
		stringSize = Nothing
	
		Return resultAl
	
	End Function

'''■CreateWord
''' <summary>文字を描画して行く</summary>
''' <param name="word">文字配列</param>
''' <param name="font">フォント</param>
''' <param name="point">フォントサイズ</param>
''' <param name="xpos">x軸初期値</param>
''' <param name="ypos">y軸初期値</param>
''' <param name="properPit">文字ピッチ</param>
''' <param name="g">グラフィックオブジェクト</param>  <- 廃止
''' <returns>Void</returns>
	Public Sub  CreateWord(word As Array, font As String, point As Integer, xPos As Single, yPos As Single, properPit As Single)
		Dim c1 As New Common
		For i As Integer = 0 To CInt(word.Length - 1) Step 1
			If i = 0 Or i = 1 Then						'★END No i = 0
				Continue For
			End If
			Dim fontPx() As Single = FontSizeCal(word(i), font, point)
			'Dim g(CInt(word.Length - 1)) As System.Drawing.Graphics
			Dim g As System.Drawing.Graphics
			g = System.Drawing.Graphics.FromImage(Pic_Main.Image)
			g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g.DrawString(word(i), _
						New Font(font, point, GraphicsUnit.Pixel), _ 
						Brushes.Black, _ 
						xPos, _ 
						yPos, _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			
			g.Dispose()
			g = Nothing
			
			yPos = yPos + (fontPx(0) + properPit)		'yピッチ増加

		Next i

		c1 = Nothing
	End Sub

'''■CreateWordDiff
''' <summary>文字を描画して行く（異なったフォントサイズ）</summary>
''' <param name="word">文字配列,フォントサイズ（配列）</param>
''' <param name="font">フォント</param>
''' <param name="xypos">xy軸位置（配列）</param>
''' <returns>Void</returns>
	Public Sub  CreateWordDiff(word As Array, font As String, xyPos As Array)
		Dim fontSize As String = CStr(word(1))
		Dim splitPointAr() As String = fontSize.Split(",")
		Dim j As Integer = 0
	
		For i As Integer = 0 To CInt(word.Length - 1) Step 1
			If i = 0 Or i = 1 Then	
				Continue For
			End If
			
			Dim g As System.Drawing.Graphics
			g = System.Drawing.Graphics.FromImage(Pic_Main.Image)
			g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g.DrawString(word(i), _
						New Font(font, CSng(splitPointAr(j)), GraphicsUnit.Pixel), _
						Brushes.Black, _ 
						xyPos(1, j), _ 
						xyPos(0, j), _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			'						New Font(font, CSng(splitPointAr(j)), FontStyle.Regular), _
			g.Dispose()
			g = Nothing
			j = j + 1

		Next i

	End Sub

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

#Region "Comment Original"
'''■
''' <summary></summary>
''' <param name=""></param>
''' <param name=""></param>
''' <param name=""></param>
''' <param name=""></param>
''' <param name=""></param>
''' <param name=""></param>
''' <param name=""></param>
''' <returns></returns>
#End Region

#Region "Test"
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
#End Region

End Class
