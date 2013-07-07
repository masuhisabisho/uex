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
		
	Dim optWord As New Hashtable	
	Dim cmn As New Common

	Public Sub Print_Load(sender As Object, e As EventArgs)

		'フォントの設定を行う
		'TODO: 必要な分だけにする（英語不要）
		Dim installedFont As New System.Drawing.Text.InstalledFontCollection		
		Dim fontFamilies As FontFamily() = installedFont.Families
	
		For Each j As FontFamily In fontFamilies
			Me.Cmb_Font.Items.Add(j.Name)
		Next j
		
		installedFont.Dispose()
		installedFont = Nothing

		'コンボの値を設定
		'TODO: それぞれの用紙に対するコンボの設定をどうするか？
		Dim SetCmb As New SetCombo
		Call SetCmb.SetComboContent(Me)
		SetCmb = Nothing
	
		'フォームをクリア
		Dim ClrFrm As New ClearForm
		Call ClrFrm.ClearForm(0, Me)
		ClrFrm = Nothing
		
		'DBより文章データの取り込み
		Dim SctSql As New SelectSql
		Dim mainTxt As New ArrayList
		Dim defSetAr() As String
		
		mainTxt = SctSql.GetSentence(0)
		defSetAr = SctSql.GetDefaultVal(0)
		
		SctSql = Nothing

		'コンボの値を保存
		With me
		'挿入等に使う
			'Specific Part（HashTableに格納）
			'optWord("Cmb_Style") = .Cmb_Style.SelectedValue
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
			optWord("Txt_HostName1")= .Txt_HostName1.Text

			'Font Size（HashTableに格納）
			optWord("Common_Point") = defSetAr(5)									'共通フォントサイズ
			optWord("Cmb_PointTitle") = .Cmb_PointTitle.SelectedItem
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

		'描画用Bitmapを準備
		With Pic_Main
			.Size = New Size(1800, 668)												'CHK: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1800,668)											'TODO: 可変にする　
		End With
		
		'DB内の文章を単語に分割する
		Dim wordStorager As Array
		wordStorager = WordArranger(defSetAr, mainTxt, optWord)


		'文字を描画していく
		Call WordPreparer(defSetAr, mainTxt, wordStorager, optWord)

	End Sub
	
'****************************************************************************************************
'
'		'描画用関数
'
'****************************************************************************************************
''''■WordPreparer
''' <summary>単語とフォントサイズの配列を適切に描画できるよう
''' 		設定を行って描画する
''' </summary>
''' <param name="defSetAr">String() 初期設定値</param>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="wordStrager">Array 単語とそれぞれのフォントサイズ</param>
''' <param name="optWord">Hashtable コンボの値</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>
''' 'TODO: 文字が無い時改行だけするようにする
	Public Sub	WordPreparer(defSetAr As String(), mainTxt As ArrayList, wordStorager As Array, optWord As Hashtable)
		Dim lineCounter As Integer = mainTxt.Count - 1
		
		If defSetAr(0) = "0" Then
			Dim xPitch As Single = CSng(defSetAr(2))	
			Dim yPitch As Single = CSng(defSetAr(3))
			Dim newYPitch As Single = 0
			Dim insColCnt As Integer = 0
			
			For i As Integer = 0  To lineCounter Step 1
				Select Case CInt(mainTxt(i)("tbl_txt_ystyle"))
					Case 0	'上															'END: 上の場合の文字ピッチを計算
						If Cmn.PointDiffChecker(wordStorager(i)(1)) = True Then			'全て同じフォントサイズの時
							If i = 0 Then
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt((defSetAr(1))))
								xPitch = tempFontSize(1)
							Else
								Dim newXPos As Single = Cmn.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									xPitch = xPitch - newXPos							'イレギュラー改行
								Else													'END: 文字サイズ＋ピッチへ 2013/7/2
									If Cint(wordStorager(i)(0)) <> 0 Then				'END: この辺に文字無しの時のエスケープを考える（改行だけする）
										Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
									Else	
										Dim tempFontSize() As Single = FontSizeCal("あ", "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
										Continue For
									End If
								End If
							End If
							
							newYPitch = Cmn.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If
							
							Dim splitPoint() As String = wordStorager(i)(1).Split(",")
							
							Dim properPit As Single = Cmn.PitchCal(yPitch, _
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
							
							newYPitch = Cmn.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If
							
							irrXYPos =  Cmn.SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
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
						If Cmn.PointDiffChecker(wordStorager(i)(1)) = True Then
							If i = 0 Then
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
								xPitch = tempFontSize(1)
							Else
								Dim newXPos As Single = Cmn.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									xPitch = xPitch - newXPos
								Else
'	（仮）							If Cint(wordStorager(i)(0)) <> 0 Then				'END: この辺に文字無しの時のエスケープを考える
'										Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
'										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
'									Else	
'										Dim tempFontSize() As Single = FontSizeCal("あ", "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
'										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
'										Continue For
'									End If
									Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
									xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1) 
								End If
							End If
							
							newYPitch = Cmn.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newYPitch <> 0 Then
								yPitch = newYPitch
							End If

							Dim splitPoint() As String = wordStorager(i)(1).Split(",")
						
							Dim properPit As Single = Cmn.PitchCal(yPitch, _
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
							
							irrXYPos =  Cmn.SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
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
						Dim newXPos As Single = Cmn.CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))

						If newXPos <> 0 Then
							xPitch = xPitch - newXPos									'イレギュラー改行
						else
							Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
							xPitch = xPitch - CSng(defsetAr(5)) - tempFontSize(1)
'	（仮）							If Cint(wordStorager(i)(0)) <> 0 Then				'END: この辺に文字無しの時のエスケープを考える
'										Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
'										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
'									Else	
'										Dim tempFontSize() As Single = FontSizeCal("あ", "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
'										xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1)
'										Continue For
'									End If
						End If
						
						newYPitch = Cmn.CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
						If newYPitch <> 0 Then
							yPitch = newYPitch
						End If
							
						Dim splitPoint() As String = wordStorager(i)(1).Split(",")
						Dim properPit As Single = Cmn.PitchCal(yPitch, _
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

''''■WordArranger
''' <summary>DB無いのセンテンスを獲得し、単語に分割、フォントサイズと一緒に格納</summary>
''' <param name="defSetAr">String() 初期設定値</param>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="optWord">Hashtable コンボの値</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>	
	Public Function WordArranger (defSetAr As String(), mainTxt As ArrayList, optWord As Hashtable) As Array
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim wordStorager(lineCounter) As Array
		Dim insWord As Array
		
		For i As Integer = 0 To lineCounter Step 1
			
			Dim insPos() As String = {"", "", ""}													'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			Dim str As String = mainTxt(i)("tbl_txt_inspos")
			Dim str1 As String = mainTxt(i)("tbl_txt_txt")
			
			If mainTxt(i)("tbl_txt_inspos") IsNot "" Then							'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(",")				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する
				insWord = Cmn.CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
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
						loopCounter = loopCounter + CInt(insWord(j)(0))
					End If
				Next j
			End If
			
			Dim subStorager(loopCounter + 1) As String								'分割した単語（行単位）を一時保存する配列
			Dim wordInLine As String = CStr(mainTxt(i)("tbl_txt_txt")) 				'メインセンテンス
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim pointStrager As String = ""
			
			For j As Integer = 0 To loopCounter + 1 Step 1
				If j = 0 Then
					subStorager(0) = loopCounter.ToString()							'列の文字数（配列数）= 0 を格納
					Continue For
				End If
				
				If j = 1 Then
					Continue For 													'フォントサイズを格納の為
				End If
				
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If Val(insWord(k)(3)) + 2 =  j Then								'絶対位置を確認
						For l As Integer = 4 To Val(insWord(k)(0)) + 3
							subStorager(j) = insWord(k)(l)
							Call Cmn.PointCollector(insWord(k)(1), pointStrager)
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（Nextで一つ増える為）
						k = k + 1
						Continue For
					Else
						subStorager(j) = wordInLine.Substring(m, 1)
						Call Cmn.PointCollector(defSetAr(1), pointStrager)
						m = m + 1
					End If
				Else
					subStorager(j) = wordInLine.Substring(j-2, 1)	'★ -1
					Call Cmn.PointCollector(defSetAr(1), pointStrager)
				End If
			Next j
			subStorager(1) = pointStrager											'フォントサイズを格納（コンマ文字列）
			wordStorager(i) = subStorager											'文字１つ１つを配列に格納
			insFlg = False
		Next i
		
		Return wordStorager
		
	End Function

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
	
	Private Sub TextBoxChange_TextChanged(sender As Object, e As EventArgs)
		' TODO: Implement Txt_HostName1_TextChanged
		Dim SctSql As New SelectSql
		Dim mainTxt As New ArrayList
		Dim defSetAr() As String
		
		Select Case True
			Case sender Is Txt_HostName1
				'ピクチャーの破棄・再設定
				With Pic_Main
					If Not (.Image Is Nothing) Then
            			.Image.Dispose()
            			.Image = Nothing
            			
            			.Size = New Size(1800, 668)
            			.image = New Bitmap(1800,668)
        			End If
    			End With
    			'変更データ格納
    			optWord("Txt_HostName1") = Me.Txt_HostName1.Text
				'DBより文章データの取り込み
				mainTxt = SctSql.GetSentence(Me.Cmb_Size.SelectedValue)
				defSetAr = SctSql.GetDefaultVal(Me.Cmb_Style.SelectedValue)
				
				Dim wordStorager As Array
				wordStorager = WordArranger(defSetAr, mainTxt, optWord)
				Call WordPreparer(defSetAr, mainTxt, wordStorager, optWord)
				
			Case sender Is Txt_HostName2
				'MessageBox.Show("ok2")
		End Select
		
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

	

End Class
