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
		
		'TODO: NEW フォントはやはりメインセンテンスの分はDBにおいておいたほうがよい。仕様を変更する
		'http://penguinlab.jp/blog/post/117
#End Region

	Dim optWord As New Hashtable
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
		'Format form
		Call ClearForm(0)
		
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
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		'Dim wordCounter As Integer = 0 											'メインセンテンスの全ての行の文字数を格納する out 2013/6/29 mb
		Dim wordStorager(lineCounter) As Array
		Dim insWord As Array
		
		For i As Integer = 0 To lineCounter Step 1
			Dim insPos() As String													'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") <> "" Then								'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(",")				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する
				insWord = CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
										mainTxt(i)("tbl_txt_targetword"), _
										mainTxt(i)("tbl_txt_targetpoint"), _
										i _
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
							Call PointCollector(insWord(k)(1), pointStrager)
							'wordCounter = wordCounter + 1							'END: 不要に out 2013/6/29
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（Nextで一つ増える為）
						k = k + 1
						Continue For
					Else
						subStorager(j) = wordInLine.Substring(m, 1)
						Call PointCollector(defSetAr(1), pointStrager)
						'wordCounter = wordCounter + 1								'out 2013/6/29 mb
						m = m + 1
					End If
				Else
					subStorager(j) = wordInLine.Substring(j-2, 1)	'★ -1
					'wordCounter = wordCounter + 1									'out 2013/6/29 mb
					Call PointCollector(defSetAr(1), pointStrager)
				End If
			Next j
			subStorager(1) = pointStrager											'フォントサイズを格納（コンマ文字列）
			wordStorager(i) = subStorager											'文字１つ１つを配列に格納
			insFlg = False
		Next i
		
'****************************************************************************************************
'
'		'文字を描画していく
'		wordStrager = 配列に文字が１つづつ格納　 pointStrager =　フォントサイズがコンマ区切りで格納
'
'****************************************************************************************************
		'文字ピッチの取得(y軸文字位置用定数）
		Dim basicPitch As Integer = PointPitCal(defSetAr(1))							'CHK: おそらく見直しになる -> OKかな？ 2013/6/29 mb
		'TODO: 縦書きの時
		If defSetAr(0) = "0" Then
			Dim xPitch As Single = CSng(defSetAr(2))	
			Dim yPitch As Single = CSng(defSetAr(3))
			Dim insColCnt As Integer = 0
			For i As Integer = 0  To lineCounter Step 1
				Select Case CInt(mainTxt(i)("tbl_txt_ystyle"))
					Case 0	'上
																					 'END: 上の場合の文字ピッチを計算
						If PointDiffChecker(wordStorager(i)(1)) = True Then				'全て同じの時
							Dim splitPoint() As String = wordStorager(i)(1).Split(",") 'END: 上の場合の文字ピッチを計算
							Dim properPit As Single = PitchCal(CSng(defSetAr(3)), _
															  CSng(defSetAr(4)), _
															wordStorager(i), _
															"ＭＳ Ｐ明朝", _
															splitPoint, _
															0 _
															)
							'コメントアウト/移動 No. 0		
							Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
'						
							yPitch = CSng(defSetAr(3))									'yピッチ初期化
																						'TODO: y軸位置の変更を組み込む
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i + 1)("tbl_txt_newxpos")))
							
							If newXPos <> 0 Then
								xPitch = newXPos										'イレギュラー改行
							Else														'END: 文字サイズ＋ピッチへ 2013/7/2
								'xPitch = xPitch - CSng(defSetAr(5))					'通常改行（左へ）
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
								xPitch = xPitch - CSng(defsetAr(5))	- tempFontSize(1) 
							End If
						Else															'END: フォントサイズが違う時の文字位置と、
																						'	  改列ピッチを求める 2013/7/2
																						'TODO: イレギュラーサイズ時の描画方法を考える
							Dim maxWidth As Single
							Dim irrXYPos As Array
							irrXYPos =  SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													"ＭＳ Ｐ明朝", _
													defSetAr(3), _
													defSetAr(4), _
													4, _
													xPitch, _
													maxWidth _
													)
							Call CreateWordDiff(wordStorager(i), "ＭＳ Ｐ明朝", irrXYPos)
							
							xPitch = xPitch + maxWidth
							
						End If
						
					Case 1	'下
						'CHK: 下の場合の文字ピッチを計算
						Dim splitPoint() As String = wordStorager(i)(1).Split(",")
						Dim properPit As Single = PitchCal(CSng(defSetAr(3)), _
															CSng(defSetAr(4)), _
															wordStorager(i), _
															"ＭＳ Ｐ明朝", _
															splitPoint, _
															0 _
															)	'TODO: フォント
						If properPit = 0 Then										'1) 文字ピッチ用スペースがある時
							Dim fontPx() As Single = FontSizeCal(wordStorager(i)(1), "ＭＳ Ｐ明朝", defSetAr(1))
							Dim bottomPos As Single  = CSng(defSetAr(4)) - fontPx(0)'一番したの文字位置を取得
							
							For j As Integer = 0 To CInt(wordStorager(i).GetValue(0)) + 1 Step 1
								If j = 0 Or j = 1 Then 								'★END Nothing
									Continue For
								End If

 								Dim g As System.Drawing.Graphics
								g = System.Drawing.Graphics.FromImage(Pic_Main.Image)
								g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias	'TODO: フォント選択実装（全てのフォントがあたるところ）
								g.DrawString(wordStorager(i)(j), _
											New Font("ＭＳ Ｐ明朝", CInt(defSetAr(1)), FontStyle.Regular), _
											Brushes.Black, _
											xPitch, _
											yPitch, _
											New StringFormat(StringFormatFlags.DirectionVertical) _
											)	
								'CHK: 開放
								g.Dispose()
								g = Nothing
									
								yPitch = yPitch - basicPitch						'yピッチ増加　CHK: 位置取得方法見直しの可能性大
									
								Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i + 1)("tbl_txt_newxpos")))
								If newXPos <> 0 Then 
									xPitch = newXPos								'イレギュラー改行
								Else
									xPitch = xPitch - CSng(defSetAr(5))				'通常改行（左へ）
								End If
							Next j
						Else														'2) 文字ピッチ用スペースがある時
							Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
							
							yPitch = CSng(defSetAr(3))								'yピッチ初期化
								
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i + 1)("tbl_txt_newxpos")))
							If newXPos <> 0 Then 
								xPitch = newXPos									'イレギュラー改行
							Else
								xPitch = xPitch - CSng(defSetAr(5))					'通常改行（左へ）
							End If 
						End If
						
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
							Dim splitPoint() As String = wordStorager(i)(1).Split(",")
							Dim properPit As Single = PitchCal(CSng(defSetAr(3)), _
															  CSng(defSetAr(4)), _
															wordStorager(i), _
															"ＭＳ Ｐ明朝", _
															splitPoint, _
															0 _
															)'						'TODO フォント
'コメントアウト/移動 No. 1
						Call createWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
						yPitch = CSng(defSetAr(3))									'yピッチ初期化
							
						Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i + 1)("tbl_txt_newxpos")))
							If newXPos <> 0 Then 
								xPitch = newXPos									'イレギュラー改行
							Else
								'xPitch = xPitch - CSng(defSetAr(5))					'通常改行（左へ）
								Dim tempFontSize() As Single = FontSizeCal(wordStorager(i)(2), "ＭＳ Ｐ明朝", defSetAr(1))
								xPitch = xPitch - CSng(defsetAr(5)) - tempFontSize(1)
							End If
					End Select
					
			Next i
			
		Else
			'TODO: 横書きの時
		End If



    End Sub
'****************************************************************************************************
'
'		'関数群
'
'****************************************************************************************************

#Region "Word"
'''■PointDiffChecker
''' <summary>コンマ区切りフォントサイズをバラして異なったフォントサイズがあるか確かめる</summary>
''' <param name="pointStrager">コンマ区切りフォントサイズ文字列</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function PointDiffChecker(pointStrager As String) As Boolean
		Dim splitPoint() As String = pointStrager.Split(",")
		Dim tempSplitPoint As String = splitPoint(0)
	
		For i As Integer = 1 To splitPoint.Length - 1 Step 1
			If tempSplitPoint <> splitPoint(i) Then
				Return False
			Else
				tempSplitPoint = splitPoint(i)
			End If
		Next i
	
		Return True
	
	End Function

'''■PointCollector
''' <summary>フォントを変数にコンマ区切りでまとめる</summary>
''' <param name="point">格納したいフォントサイズ</param>
''' <param name="storager">フォントを格納する変数</param>
''' <returns>Void</returns>
	Public Sub PointCollector(ByVal point As String, ByRef storager As String)
		If storager = "" Then 
			storager = point
		Else
			storager &= ","  & point
		End If

	End Sub

'''■CheckInsWord
''' <summary>挿入文字を取り出し</summary>
''' <param name="insPos">挿入があるかどうか</param>
''' <param name="targetWord">挿入文字の値の入ったのHashTableのキー名</param>
''' <param name="targetPoint">ポイントの値の入ったのHashTableのキー名</param>
''' <param name="insCol">挿入があった列番号</param>		<- 追加	2013/6/30
''' <returns>文字数 = 0, フォントサイズ = 1, 挿入列番号 = 2, 挿入位置 = 3 を獲得する, 文字（任意の数）= 3～</returns>
    Public Function CheckInsWord(insPos As String, targetWord As String, targetPoint As String, insCol As Integer) As Array
    	'END: 文字数, フォント, フォントサイズを獲得する
    	'END: 挿入位置も格納しておく 2013/6/29
    	'END: 挿入列も格納しておく   2013/6/30
        Dim returnAr(2) As Array

        Dim splitInsPos() As String
        Dim splitTargetWord() As String
        Dim splitTargetPoint() As String
        Dim newInsPos As Integer 
        splitInsPos = insPos.Split(",")												'挿入位置。2番目は1番の後から2番目までの間の不変文字の数（以降同じ）
        splitTargetWord = targetWord.Split(",")										'分割された挿入文字
        splitTargetPoint = targetPoint.Split(",")									'それぞれのフォントサイズ
        
        For i As Integer = 0 To 2 Step 1											'現状1行に3挿入までにする
        	If splitInsPos(i) <> "9999" Then
        		Dim word As String = optWord(splitTargetWord(i))
        		Dim wordPoint As String = optWord(splitTargetPoint(i))
        		Dim wordLength As Integer = CInt(word.Length)  						'文字数をフォントサイズを格納する分が２つ
        		Dim resultAr(wordLength + 3) As String			'■ 2
        		Dim k As Integer = 0
        		
        		For j As Integer = 0 To wordLength + 3 Step 1
        			If j = 0 Then
        				resultAr(j) = wordLength									'文字数 = 0
        			ElseIf j = 1 Then
        				resultAr(j) = wordPoint										'フォントサイズ = 1
        			ElseIf j = 2 Then
        				resultAr(j) = insCol										'挿入があった列番号
        			ElseIf j = 3 Then
        				If i = 0 Then
        					resultAr(j) = splitInsPos(i)							'挿入位置 = 3
        					newInsPos = CInt(splitInsPos(i)) + wordLength
        				Else
        					resultAr(j) =  newInsPos + CInt(splitInsPos(i)) 		'2番目以降の挿入の相対位置を絶対位置に確定する
        					newInsPos = CInt(resultAr(j)) + wordLength
        				End If
        			Else
        				resultAr(j) = word.Substring(k, 1)
        				k = k + 1
        			End If
        		Next j
        		
        		returnAr(i) = resultAr
        		
        	End If
        Next i
        
        Return returnAr

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
						New Font(font, point, FontStyle.Regular), _ 
						Brushes.Black, _ 
						xPos, _ 
						yPos, _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			
			g.Dispose()
			g = Nothing
			
			yPos = yPos + (fontPx(0) + properPit)		'yピッチ増加

		Next i

	End Sub

'''■CreateWordDiff
''' <summary>文字を描画して行く（異なったフォントサイズ）</summary>
''' <param name="word">文字配列</param>
''' <param name="font">フォント</param>
''' <param name="point">フォントサイズ（配列）</param>
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
						New Font(font, CSng(splitPointAr(j)), FontStyle.Regular), _
						Brushes.Black, _ 
						xyPos(1, j), _ 
						xyPos(0, j), _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			
			g.Dispose()
			g = Nothing
			j = j + 1

		Next i

	End Sub
''''■FontSizeCal
''' <summary>文字の縦横高さを測る</summary>
''' <param name="word">計測したい文字</param>
''' <param name="font">フォント</param>
''' <param name="point">ポイント</param>
''' <returns>文字の 縦 = 0・横 = 1 を返す</returns>
	Public Function FontSizeCal(word As String, font As String, point As Integer) As Array
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
	
#End Region

#Region "Pitch"	
'END: それぞれの文字のフォントサイズを考慮する
'END: フォントサイズの変更に伴いx軸の調整をする
'END: 大きさによってそれぞれの文字のX座標が変わる
'END: ピッチがビチビチの時も考慮
'''■SetIrregXYPos
''' <summary>フォントサイズが違う文字が混じった列の
''' 		1) それぞれのyPosを計算する
''' 		2) xPosを計算する
''' </summary>
''' <param name="startPos">上・下・天地</param>
''' <param name="word">文字配列(0 = 文字数, 1 = それぞれのフォントサイズ）</param>
''' <param name="font">フォント（フォントサイズ含む）</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="bottomYPos">y軸最下位置</param>
''' <param name="curXPitch">x軸の改行ピッチ</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="maxWidth">最大のフォント幅（参照）</param>
''' <returns>配列にてyPos = 0, xPos = 1を返す</returns>
Public Function SetIrregXYPos(startPos As Integer, word As Array, font As String, _
								topYPos As Single, bottomYPos As Single, _
								curXPitch As Single, lastXPos As Single, _
								ByRef maxWidth As Single _
							) As Single(,)
		
		Dim eachPos(1, word(0) - 1) As Single										'y軸(0)/x軸(1)の文字位置データ
		Dim tempMaxWidth As Single = 0
		Dim eachXYSize(CInt(word(0)) - 1) As Array
		
		Dim splitPoint() As String = word(1).Split(",")
		Dim freeSpace As Single = bottomYPos - topYPos
		'Dim onePitch As Single = 0
		
		Dim j As Integer = 0
		For i As Integer = 2 To CInt(word(0)) + 1 Step 1							'それぞれの文字サイズを獲得する
			eachXYSize(j) = FontSizeCal(word(i), font, CInt(splitPoint(j)))
			If j = 0 Then
				tempMaxWidth = eachXYSize(j)(1)
			End If
			If j <> 0 Then
				If tempMaxWidth < eachXYSize(j)(1) Then
					tempMaxWidth = eachXYSize(j)(1)
				End If
			End If
			
			freeSpace = freeSpace - Csng(eachXYSize(j)(0))							'ピッチに取れるスペースを獲得する
			j = j + 1
		Next i

		maxWidth = tempMaxWidth														'***END: 文字幅の最大値を渡す
		
'		If freeSpace > 0  Then
'			onePitch = freeSpace / CSng(CInt(word(0) - 1))							'y軸の文字ピッチに使えるスペース END: マイナス時の計算
'		Else
'			onePitch = (Math.Abs(freeSpace) / CSng(CInt(word(0) - 1))) * -1 
'		End If

		Dim properPit As Single = PitchCal(topYPos, bottomYPos, word, "ＭＳ Ｐ明朝", splitPoint, 1)
		
		Dim k As Integer = 0
		For i As Integer = 0 To CInt(word(0)) -1 Step 1								'***END: y軸上の文字位置を決めていく
			If i = 0  Then
				eachPos(0, i) = topYPos
			Else
				eachPos(0, i) = eachPos(0, i - 1) + eachXYSize(k)(0) + properPit		'TODO: 上・下・天地のパターンで対応（フリースペースがある時ない時）
			End If
		Next i
																					'***END: 一番大きいフォントの位置よりそれぞれのｘ軸位置を決める
		For i As Integer = 0 To CInt(word(0)) -1 Step 1								'END: x軸は右から左へマイナス
			If eachXYSize(i)(1) < tempMaxWidth Then
				eachPos(1, i) = (lastXPos - curXPitch - tempMaxWidth) + ((tempMaxWidth - CSng(eachPos(1, i))) / 2)
			Else
				eachPos(1, i) = lastXPos - curXPitch - tempMaxWidth
			End If
		Next i
		
		Return eachPos
		
	End Function

''''■CheckNewYPos
''' <summary>改行ピッチの変更があるかどうか確認</summary>
''' <param name="newPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
'END:　改行ピッチ関数 
	Public Function CheckNewXPos(newXpos As Single) As Single
		Dim resultPos As Single = 0
		If newXpos <> 9999 Then
			resultPos = newXpos
			Return resultPos
		End If
			Return 0
	End Function
	
''''■PointPitCal
''' <summary>任意のポイントに対する必要なピッチ</summary>
''' <param name="point">ポイント数</param>
''' <returns>y軸の文字位置を決める定数を返す(任意のポイントの高さ+文字ピッチ。現在-3）</returns>
	Public Function PointPitCal(point As Integer) As Integer
		Dim resultPit As Integer = 0

		Dim wordPix As Integer = CInt(point * (96 / 72))							'ポイント　-> ピクセル変換(任意のポイントの高さ）
		resultPit = wordPix - 3														'文字間隔は4pxに（暫定）
		Return resultPit
	End Function
	
''''■PitchCal
''' <summary>天地の時のピッチを計算
''' 		（0, 1の列の設定データはかわしています）
''' </summary>
''' <param name="topYPos">開始位置</param>
''' <param name="bottomYPos">修了位置</param>
''' <param name="wordAr">単語配列</param>
''' <param name="font">フォント</param>		<- 追加　2013/06/23
''' <param name="point">ポイント数</param>	<- Arrayに変更 2013/7/4
''' <param name="pattern">上・下・天地揃え</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
	Public Function PitchCal(topYPos As Single, bottomYPos As Single, wordAr As Array, font as String, point As Array, pattern As Integer) As Single
		Dim resultPitch As Single = 0
		Dim arCounter As Single = CSng(wordAr(0))									'文字数を取得
		Dim firstWord(1) As Single
		Dim lastWord(1) As Single
	
		'文字の長さの取得(最初と最後は決まっている為）
		Dim wordLength() As Single = {0, 0}
		Dim wordHeight As Single = 0
		Dim j As Integer = 0
		For i As Integer = 0 To CInt(arCounter) + 1				'★END Nothing
			Select Case i
			    Case 0
			    	Continue For
			    Case 1
			    	Continue For
			    Case 2
			    	firstWord = FontSizeCal(CStr(wordAr(i)), font, point(j))
			    Case CInt(arCounter)
			    	lastWord = FontSizeCal(CStr(wordAr(i)), font, point(j))
			    Case Else
			    	wordLength = FontSizeCal(CStr(wordAr(i)), font, point(j))
					wordHeight = wordHeight + wordLength(0) 
			End Select
			j = j + 1
		Next i
	
		'最後の文字の位置を決める
		Dim lastWordPos As Single = bottomYPos - lastWord(0)

		'文字の長さの取得(最初と最後は決まっている為）										2013/06/23 out mb	
		'Dim arLength As  Single = (arCounter - 2) * wordPixSize

		'文字収納範囲
		Dim wordArea As Single = lastWordPos - firstWord(0)
		'文字の長さと収納範囲を検証
		If (wordArea - (wordHeight)) > 0 Then										'ピッチを取れる余裕がある時
			resultPitch = (wordArea - wordHeight) / (arCounter - 1)
			Select Case pattern
				Case 0
					Return basicPitch
				Case 1
					Return basicPitch
				Case 2
					Return resultPitch
			End Select
		Else																		'余裕がない時（ビチビチの時　マイナスの値でピッチ幅を減らす）
			resultPitch = (System.Math.Abs(wordArea - wordHeight) / (arCounter - 1)) * -1
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
        	Case 0      '奉書挨拶状
                With Me
                    'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
                    'Common part
                    .Cmb_Size.SelectedValue = 0         'TODO: Indexで統一？
                    .Cmb_Font.SelectedIndex = 70        'CHK: 拡大率の問題

                    '下記３つ現画面で廃止予定
                    .Cmb_Magnify.SelectedValue = 100
                    .Cmb_Thickness.SelectedValue = 40
                    .Txt_Copy.Text = "1"
                    
                    '初期設定の値は下の通り
                    'Specific part
                    .Cmb_Style.SelectedValue = 0                            'TODO: basicSetから読む
                    '.Cmb_SeasonWord.SelectedValue = "厳寒の候"             	'TODO: 月によって読む値を考える
                    .Cmb_SeasonWord.SelectedIndex = 1
                    .Cmb_Time1.SelectedValue = "先般"
                    .Cmb_Title.SelectedIndex = 1
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
                    .Txt_PS1.Text = "追伸"                                      'TODO: From SQL
                    .Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"  'TODO: From SQL
                    .Txt_PS3.Text = "お届けさせて頂きました"                    'TODO: From SQL
                    .Txt_PS4.Text = "御受納下さいます様お願い申し上げます"      'TODO: From SQL

                    'Font Size
                    .Cmb_PointTitle.SelectedIndex = 10						'★
                    .Cmb_PointName.SelectedIndex = 34
                    .Cmb_PointDeadName.SelectedIndex = 0
                    .Cmb_PointDeadName.Enabled = False
                    .Cmb_PointImibi.SelectedIndex = 34
                    .Cmb_PointEndWord.SelectedIndex = 34
                    .Cmb_PointCeremonyDate.SelectedIndex = 22
                    .Cmb_PointAdd1.SelectedIndex = 19
                    .Cmb_PointHostType.SelectedValue = 0
                    .Cmb_PointHostType.Enabled = False
                    .Cmb_PointHostName1.SelectedIndex = 34
                    .Cmb_PointHostName2.SelectedIndex = 34
                    .Cmb_PointHostName3.SelectedIndex = 34
                    .Cmb_PointHostName4.SelectedIndex = 34
                    .Cmb_PointPS1.SelectedIndex = 17

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

#Region "コメントアウト/移動"
'No. 0					2013/6/29 out mb
'						If properPit = 0 Then										'1) 文字ピッチ用スペースがある時
'							For j As Integer = 0 To CInt(wordStorager(i).GetValue(0)) + 1 Step 1		'★END Nothing
'								If j = 0 Or j = 1 Then
'									Continue For
'								End If
'								
'								Dim g As System.Drawing.Graphics
'								g = System.Drawing.Graphics.FromImage(Pic_Main.Image)
'								g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias	'TODO: フォント選択実装（全てのフォントがあたるところ）
'								g.DrawString(wordStorager(i)(j), _
'											New Font("ＭＳ Ｐ明朝", CInt(defSetAr(1)), FontStyle.Regular), _
'											Brushes.Black, _
'											xPitch, _
'											yPitch, _
'											New StringFormat(StringFormatFlags.DirectionVertical) _
'											)
'									
'								g.Dispose()											'CHK: 開放
''								Font.Dispose()
'								g = Nothing
'								Font = Nothing
'								
'								yPitch = yPitch + basicPitch						'yピッチ増加 CHK: 位置取得方法見直しの可能性大
'							Next j
''							Call CreateWord(wordStorager(i), "ＭＳ Ｐ明朝", CInt(defSetAr(1)), xPitch, yPitch, properPit)
'							yPitch = CSng(defSetAr(3))								'yピッチ初期化
'																					'x軸のイレギュラー改行を確認する
'							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i + 1)("tbl_txt_newxpos")))
'							If newXPos <> 0 Then 
'								xPitch = newXPos
'							Else
'								xPitch = xPitch - CSng(defSetAr(5))					'通常改行（左へ）
'							End If 
'							
'						Else														'2) 文字ピッチ用スペースがない時
'
'						End if

'No. 1
'						Functionに置き換え
'						For j As Integer = 0 To CInt(wordStorager(i).GetValue(0)) Step 1
'							If j = 0 Then
'								Continue For
'							End If
'							Dim fontPx() As Single = FontSizeCal(wordStorager(i)(j), "ＭＳ Ｐ明朝", CInt(defSetAr(1)))
'							g(j) = System.Drawing.Graphics.FromImage(Pic_Main.Image)
'							g(j).SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 
'							g(j).DrawString(wordStorager(i)(j), New Font("ＭＳ Ｐ明朝", CInt(defSetAr(1)), FontStyle.Regular), 
'							Brushes.Black, xPitch, yPitch, New StringFormat(StringFormatFlags.DirectionVertical))
'							yPitch = yPitch + (fontPx(0) + properPit)			'yピッチ増加
'						Next j
#End Region
End Class
