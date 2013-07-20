'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class Common
	
	Dim  basicPitch As single = 0
	
	Public Sub New(newPitch As Single)
		'END: コンストラクタ。ここにbasicPitchの定数を入れる basicXPitch basicYPitch DBより
		basicPitch = newPitch
	End Sub
	
	Public Readonly Property SetBasicPitch() As Single
		Get
			Return basicPitch
		End Get
	End Property
	
#Region "汎用関数"

''''■Magnify
''' <summary>画像を拡大・縮小する。</summary>
''' <param name="Source">対象の画像</param>
''' <param name="Rate">拡大率。以下の値を指定した場合は縮小される。</param>
''' <param name="Quality">画質。省略時は最高画質。</param>
''' <returns>処理後の画像</returns>
''' 'http://homepage1.nifty.com/rucio/main/dotnet/Samples/Sample141ImageMagnify.htm
''' 'PictureBox1.Image = Magnify(PictureBox1.Image, 1.2F)
	Public Function Magnify(ByVal Source As Image, ByVal Rate As Double, _ 
	Optional ByVal Quality As Drawing2D.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic) As Image

    	'▼引数のチェック
    	If IsNothing(Source) Then
        	Throw New NullReferenceException("Sourceに値が設定されていません。")
    	End If
    	If CInt(Source.Size.Width * Rate) <= 0 OrElse CInt(Source.Size.Height * Rate) <= 0 Then
        	Throw New ArgumentException("処理後の画像のサイズが0以下になります。Rateには十分大きな値を指定してください。")
    	End If

    	'▼処理後の大きさの空の画像を作成
    	Dim NewRect As Rectangle

    	NewRect.Width = CInt(Source.Size.Width * Rate)
    	NewRect.Height = CInt(Source.Size.Height * Rate)
    	Dim DestImage As New Bitmap(NewRect.Width, NewRect.Height)

    	'▼拡大・縮小実行
    	Dim g As Graphics = Graphics.FromImage(DestImage)
    	g.InterpolationMode = Quality
    	g.DrawImage(Source, NewRect)

    	Return DestImage

	End Function
	
#End Region

#Region "Word"
''''■WordPreparer
''' <summary>DB内のセンテンスを獲得し、単語に分割、フォントサイズと一緒に格納</summary>
''' <param name="defSetAr">String() 初期設定値</param>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="optWord">Hashtable コンボの値</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>	
	Public Function WordPreparer (defSetAr As String(), mainTxt As ArrayList, optWord As Hashtable) As Array
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim wordStorager(lineCounter) As Array
		Dim insWord As Array
		Dim basicPoint As String = defSetAr(1)
		
		For i As Integer = 0 To lineCounter Step 1
			
			Dim insPos() As String = {"", "", ""}									'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") IsNot "" Then							'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(","c)				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する
				insWord = CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
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
			Dim pointStorager As String = ""
			
			For j As Integer = 0 To loopCounter + 1 Step 1
				If j = 0 Then
					subStorager(0) = loopCounter.ToString()							'列の文字数（配列数）= 0 を格納
					Continue For
				End If
				
				If j = 1 Then
					Continue For 													'フォントサイズを格納の為
				End If
				
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If  IsArray(insWord(k)) = True AndAlso Val(insWord(k)(3)) + 2 =  j Then '絶対位置を確認
						For l As Integer = 4 To Val(insWord(k)(0)) + 3				'2013/7/20 空配列対策(IsArray)
							subStorager(j) = insWord(k)(l)
							Call PointCollector(insWord(k)(1), pointStorager)
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（Nextで一つ増える為）
						k = k + 1
						Continue For
					Else
						subStorager(j) = wordInLine.Substring(m, 1)
						
						Dim tempBasipoint As String = BasicPointChanger(mainTxt(i))
						If  tempBasipoint <> "0" Then
							basicPoint = tempBasipoint
						End If
						Call PointCollector(basicPoint, pointStorager)
						
						m = m + 1
					End If
				Else
					subStorager(j) = wordInLine.Substring(j-2, 1)	'★ -1
					
					Dim tempBasipoint As String = BasicPointChanger(mainTxt(i))
					If  tempBasipoint <> "0" Then
						basicPoint = tempBasipoint
					End If
					Call PointCollector(basicPoint, pointStorager)
				End If
			Next j
			
			If pointStorager = "" Then												'初期値に何も無い時はポイントをDB上にあてがっておく
				pointStorager = BasicPointChanger(mainTxt(i))
			End If
			
			subStorager(1) = pointStorager											'フォントサイズを格納（コンマ文字列）

			wordStorager(i) = subStorager											'文字１つ１つを配列に格納
			insFlg = False
		Next i
		
		Return wordStorager
		
	End Function
	
''''■WordArranger
''' <summary>単語とフォントサイズの配列を適切に描画できるよう
''' 		設定を行って描画する
''' </summary>
''' <param name="defSetAr">String() 初期設定値</param>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="wordStrager">Array 単語とそれぞれのフォントサイズ</param>
''' <param name="optWord">Hashtable コンボの値</param>
''' <param name="font">フォント</param>
''' <param name="Frm">PrintReport.vb</param>
''' <param name="Wc">WordContainer.vb</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>
''' 'TODO: 文字が無い時改行だけするようにする
Public Sub WordArranger(defSetAr As String(), mainTxt As ArrayList, _
						wordStorager As Array, optWord As Hashtable, 
						font As String, Frm As PrintReport, _
						Wc As WordContainer)
	
		Dim lineCounter As Integer = mainTxt.Count - 1
		
		If defSetAr(0) = "0" Then
			Dim startXPos As Single = CSng(defSetAr(2))	
			Dim startYPos As Single = CSng(defSetAr(3))
			Dim newStartYPos As Single = 0
			Dim insColCnt As Integer = 0
			
			For i As Integer = 0  To lineCounter Step 1
				Dim selector As Integer = CInt(mainTxt(i)("tbl_txt_ystyle"))
				Select Case selector
					Case 0	'上															'END: 上の場合の文字ピッチを計算
						If PointDiffChecker(wordStorager(i)(1)) = True Then			'全て同じフォントサイズの時
							Dim newXpitch As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXpitch <> 0 Then
								startXPos = startXPos - newXpitch						'x軸イレギュラースタート
							Else
								If CInt(wordStorager(i)(0)) <> 0 Then
									Dim pickPoint As Integer = OnePointPicker(wordStorager(i)(1), 0)
									Dim fontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), pickPoint) '★
									startXPos = startXPos - CSng(defsetAr(5)) - fontSize(1)	'END: 文字サイズ＋ピッチへ 2013/7/2
								Else														'END: 文字無しの時のエスケープ（改行だけする）
									Dim FontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSetAr(1)))
									startXPos = startXPos - CSng(defsetAr(5)) - FontSize(1)
									
										Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
										Dim wordInLine As New ArrayList 
										wordInLine.Add(wordDetail)
										Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
										wordDetail = {"", "", "", ""}
										Continue For
								End If
							End If
								
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos"))) 
							If newStartYPos <> 0 Then
								startYPos = newStartYPos									'y軸イレギュラースタート
							End If
							
							Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
							
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(defSetAr(4)), _
																wordStorager(i), _
																Wc.optWord("Common_Font"), _
																splitPoint, _
																0, _
																Frm _
																)
							Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)
						Else															'END: フォントサイズが違う時の文字位置と改列ピッチを求める 2013/7/2
							Dim maxWidth As Single										'END: イレギュラーサイズ時の描画方法を考える
							Dim irrXYPos As Array										'END: y軸位置の変更を組み込む
							
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If
							
							irrXYPos =  SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													Wc.optWord("Common_Font"), _
													startYPos, _
													CSng(defSetAr(4)), _
													CSng(defSetAr(5)), _
													startXPos, _
													maxWidth, _
													Frm
													)
							Call Frm.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							startXPos = startXPos - maxWidth
							
						End If
					Case 1, 3	'下
						If PointDiffChecker(wordStorager(i)(1)) = True Then
								Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
								If newXPos <> 0 Then
									startXPos = startXPos - newXPos
								Else
									If CInt(wordStorager(i)(0)) <> 0 Then
										Dim pickPoint As Integer = OnePointPicker(wordStorager(i)(1), 0)
										Dim fontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), pickPoint)
										startXPos = startXPos - CSng(defsetAr(5)) - fontSize(1)
									Else	
										Dim fontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSetAr(1)))
										startXPos = startXPos - CSng(defsetAr(5)) - fontSize(1)
										
										Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
										Dim wordInLine As New ArrayList 
										wordInLine.Add(wordDetail)
										Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
										wordDetail = {"", "", "", ""}
										Continue For
									End If 'END: 2013/7/9　下配置修正
								End If
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If

							Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
						
							Dim properPit As Single = PitchCal(startYPos, _
																  CSng(defSetAr(4)), _
																wordStorager(i), _
																Wc.optWord("Common_Font"), _
																splitPoint, _
																1, _
																Frm _
																)
							'END: ピッチがマイナスでも強制的に下からスタートさせる(ピッチを小さくしたい時) -> OrElseを追加 2013/7/13 mb
							If properPit > 0 OrElse selector = 3
								Dim addHeight As Single = 0
								Dim totalHeight As single = 0
								For j As Integer = 2 To CInt(wordStorager(i)(0)) + 1 Step 1
									Dim tempHeight() As Single = Frm.FontSizeCal(wordStorager(i)(j), Wc.optWord("Common_Font"), CInt(splitPoint(j - 2)))
									addHeight = addHeight + tempHeight(0)	
								Next j
								totalHeight = Csng(defSetAr(4)) - ( addHeight + (properPit * (CSng(wordStorager(i)(0)) - 1)))
								Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, totalHeight, properPit)
							Else
								Call Frm.CreateWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)　'CHK★一時的に変更
							End If
						Else															'フォントサイズが異なる
							Dim maxWidth As Single	
							Dim irrXYPos As Array
							
							newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							If newStartYPos <> 0 Then
								startYPos = newStartYPos
							End If
							
							irrXYPos =  SetIrregXYPos(CInt(mainTxt(i)("tbl_txt_ystyle")), _
													wordStorager(i), _
													Wc.optWord("Common_Font"), _
													startYPos, _
													CSng(defSetAr(4)), _
													CSng(defSetAr(5)), _
													startXPos, _
													maxWidth, _
													Frm
													)
							Call Frm.CreateWordDiff(wordStorager(i), Wc.optWord("Common_Font"), irrXYPos)
							
							startXPos = startXPos - maxWidth
						End If	
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						'TODO: pointDiffCheckerをつける
						Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
						If newXPos <> 0 Then
							startXPos = startXPos - newXPos									'イレギュラー改行
						Else
							If Cint(wordStorager(i)(0)) <> 0 Then				'END: この辺に文字無しの時のエスケープを考える
								Dim tempFontSize() As Single = Frm.FontSizeCal(wordStorager(i)(2), Wc.optWord("Common_Font"), CInt(defSetAr(1)))
								startXPos = startXPos - CSng(defsetAr(5))	- tempFontSize(1)
							Else	
								Dim tempFontSize() As Single = Frm.FontSizeCal("口", Wc.optWord("Common_Font"), CInt(defSetAr(1)))
								startXPos = startXPos - CSng(defsetAr(5))	- tempFontSize(1)

								Dim wordDetail() As String = {"", CStr(wordStorager(i)(1)), startYPos.ToString(), startXPos.ToString()}
								Dim wordInLine As New ArrayList 
								wordInLine.Add(wordDetail)
								Wc.CurrentWord(wordInLine)								'描画文字データを格納（他はCreateWordで格納される）
								wordDetail = {"", "", "", ""}
								Continue For
							End If
						End If
						
						newStartYPos = CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
						If newStartYPos <> 0 Then
							startYPos = newStartYPos
						End If
							
						Dim splitPoint() As String = wordStorager(i)(1).Split(","c)
						Dim properPit As Single = PitchCal(startYPos, _
															CSng(defSetAr(4)), _
															wordStorager(i), _
															Wc.optWord("Common_Font"), _
															splitPoint, _
															2, _
															Frm _
															)'						'TODO フォント
						Call Frm.createWord(wordStorager(i), Wc.optWord("Common_Font"), startXPos, startYPos, properPit)
					End Select
			Next i
			
		Else
		'TODO: 横書きの時
		End If
	End Sub

'''■CheckInsWord
''' <summary>挿入文字を取り出し</summary>
''' <param name="insPos">String 挿入があるかどうか</param>
''' <param name="targetWord">String 挿入文字の値の入ったのHashTableのキー名</param>
''' <param name="targetPoint">String ポイントの値の入ったのHashTableのキー名</param>
''' <param name="insCol">Integer 挿入があった列番号</param>		<- 追加	2013/6/30
''' <param name="optWord">Hashtable オプションのセンテンス</param>		<- 追加	2013/7/
''' <returns>文字数 = 0, フォントサイズ = 1, 挿入列番号 = 2, 挿入位置 = 3 , 文字（任意の数）= 4～</returns>
	Public Function CheckInsWord(insPos As String, targetWord As String, _
								targetPoint As String, insCol As Integer, _
								optWord As Hashtable) As Array
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

#End Region

#Region "Pitch"	
'END: それぞれの文字のフォントサイズを考慮する
'END: フォントサイズの変更に伴いx軸の調整をする
'END: 大きさによってそれぞれの文字のX座標が変わる
'END: ピッチがビチビチの時も考慮
'''■SetIrregXYPos
''' <summary>フォントサイズが違う文字が混じった列の
''' 		1) それぞれのyPosを計算する
''' 		2) それぞれのxPosを計算する
''' </summary>
''' <param name="yStyle">上・下・天地</param>
''' <param name="wordStrager">文字配列(0 = 文字数, 1 = それぞれのフォントサイズ）</param>
''' <param name="font">フォント</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="bottomYPos">y軸最下位置</param>
''' <param name="curXPitch">x軸の改列ピッチ</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="maxWidth">最大のフォント幅（参照）</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>配列にてyPos = 0, xPos = 1を返す</returns>
Public Function SetIrregXYPos(yStyle As Integer, wordStrager As Array, font As String, _
								topYPos As Single, bottomYPos As Single, _
								curXPitch As Single, lastXPos As Single, _
								ByRef maxWidth As Single, _
								pr As PrintReport _
							) As Single(,)
		
		Dim eachPos(1, wordStrager(0) - 1) As Single										'y軸(0)/x軸(1)の文字位置データ
		Dim tempMaxWidth As Single = 0
		Dim eachXYSize(CInt(wordStrager(0)) - 1) As Array

		Dim splitPoint() As String = wordStrager(1).Split(",")
		Dim freeSpace As Single = bottomYPos - topYPos
		Dim onePitch As Single = 0
		
		For i As Integer = 2 To CInt(wordStrager(0)) + 1 Step 1
			eachXYSize(i - 2) = pr.FontSizeCal(wordStrager(i), font, CInt(splitPoint(i - 2)))	'それぞれの文字サイズを獲得する
			If (i - 2) = 0 Then
				tempMaxWidth = eachXYSize(i - 2)(1)
			End If
			If (i - 2) <> 0 Then
				If tempMaxWidth < eachXYSize(i -2)(1) Then
					tempMaxWidth = eachXYSize(i - 2)(1)
				End If
			End If
			freeSpace = freeSpace - Csng(eachXYSize(i -2)(0))								'ピッチに取れるスペースを獲得する
		Next i

		maxWidth = tempMaxWidth																'***END: 文字幅の最大値を渡す
		
		Select Case yStyle																'***文字ピッチを獲得する
			Case 0	'END: 上
				If freeSpace > 3 * (CInt(wordStrager(0) - 1))  Then							'ピッチ * ピッチスペース数
					onePitch = basicPitch
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End If
			Case 1	'END: 下
				If freeSpace > 3 * (CInt(wordStrager(0) - 1))  Then
					onePitch = basicPitch
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End If
			Case 2	'END: 天地
				If freeSpace > 0  Then
					onePitch = freeSpace / CSng(CInt(wordStrager(0) - 1))
				Else
					onePitch = (Math.Abs(freeSpace) / CSng(CInt(wordStrager(0) - 1))) * -1 
				End if
		End Select

		For i As Integer = 0 To CInt(wordStrager(0)) + 1 Step 1								'***END: y軸上の文字位置を決めていく
			If i = 0 Or i = 1　Then
				Continue For
			End If
			'スペースが有る時
			If freeSpace > 3 * (CInt(wordStrager(0) - 1)) Then
				If yStyle = 1 Then
					If i = 2 Then
						For j As Integer = 0 To eachPos.GetLength(0) Step 1
							eachPos(0, 0) = eachPos(0, 0) + CSng(eachPos(0, j))
						Next j
					Else
						eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch 'フォントサイズ
					End If
				Else
					If i = 2 Then
						eachPos(0, 0) = topYPos
					Else
						eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch
					End If
				End If
			'スペースが無い時	
			Else
				If i = 2 Then
					eachPos(0, 0) = topYPos
				Else	
					eachPos(0, i - 2) = eachPos(0, i - 3) + eachXYSize(i - 3)(0) + onePitch
				End if
			End If
		Next i
		
		Dim lastWordPoint As Single = splitPoint(0)
																							'***END: 一番大きいフォントの位置よりそれぞれのｘ軸位置を決める
		For i As Integer = 0 To CInt(wordStrager(0)) -1 Step 1								'END: x軸は右から左へマイナス
			If eachXYSize(i)(1) < tempMaxWidth Then											'END: 位置微調整が必要　-> 連続して同じサイズの時は同じx位置に 2013/7/13
				If lastWordPoint = splitPoint(i) And i <> 0 Then							'     ひらがなが微妙
					eachPos(1, i) = eachPos(1, i -1)
				Else
					eachPos(1, i) = (lastXPos - curXPitch - tempMaxWidth) + ((tempMaxWidth - CSng(eachXYSize(i)(1))) / 2)
					lastWordPoint = splitPoint(i)
				End If
			Else
				eachPos(1, i) = lastXPos - curXPitch - tempMaxWidth
			End If
		Next i
		
		Return eachPos
		
	End Function

''''■CheckNewXPos
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
	
''''■CheckNewYPos
''' <summary>Y軸の開始位置の変更があるかどうか確認</summary>
''' <param name="newPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
'END:　改行ピッチ関数 
	Public Function CheckNewYPos(newXpos As Single) As Single
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
''' <param name="topYPos">Single 開始位置</param>
''' <param name="bottomYPos">Single 修了位置</param>
''' <param name="wordAr">Array 単語配列</param>
''' <param name="font">String フォント</param>		<- 追加　2013/06/23
''' <param name="point">Array ポイント数</param>	<- Arrayに変更 2013/7/4
''' <param name="pattern">Integer 上・下・天地揃え</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
	Public Function PitchCal(topYPos As Single, bottomYPos As Single, _
							wordAr As Array, font As String, point As Array, _
							pattern As Integer, pr As PrintReport) _
							As Single
	
		Dim resultPitch As Single = 0
		Dim arCounter As Single = CSng(wordAr(0))									'文字数を取得
		Dim firstWord(1) As Single
		Dim lastWord(1) As Single
	
	'文字の長さの取得(最初と最後は決まっている為）
'	#If Debug Then
'	Dim z As Integer = 0
'	While z < wordAr.Length
'		System.Diagnostics.Debug.WriteLine(wordAr(z))
'		z += 1
'	End While
'	#End IF
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
			    	firstWord = pr.FontSizeCal(CStr(wordAr(i)), font, point(j))
			    Case CInt(arCounter) + 1
			    	lastWord = pr.FontSizeCal(CStr(wordAr(i)), font, point(j))
			    Case Else
			    	wordLength = pr.FontSizeCal(CStr(wordAr(i)), font, point(j))
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

''' ■YPosCal
''' <summary>y軸方向の文字ピッチを再設定する（フォントサイズが全て同じ時）</summary>
''' <param name="word">ByRef Array 文字配列（文字、フォントサイズ、文字の高さ、文字の幅）</param>
''' <param name="topYPos">Single y軸の開始位置</param>
''' <param name="pr">Form PrintReport</param>
''' <returns>Void, wordを参照する</returns>
	Public Sub YPosCal(ByRef word As ArrayList, font As String, topYPos As Single, pr As PrintReport)  'basicPitch
		
		Dim loopCounter As Integer = CInt(word.Count)
	
		For i As Integer = 1 To loopCounter -1 Step 1
				Dim fontSize() As Single = pr.FontSizeCal(word(i)(0), font, CInt(word(i)(1)))
				If i = 1 Then
					word(i)(2) = fontSize(0) + basicPitch
				Else
					word(i)(2) = word(i - 1)(2) + fontSize(0) + basicPitch
				End If
				
				System.Diagnostics.Debug.WriteLine(word(i)(2))
		Next i

	End Sub
	
#End Region

#Region "FontSize"
'''■BasicPointChanger
''' <summary>列単位のフォントサイズの変更を確認</summary>
''' <param name="mainTxt">ArrayList DB内の登録データ</param>
''' <returns>変更が無い時は0を返す、ある時は登録されたフォントサイズを返す</returns>
	Public Function BasicPointChanger(mainTxt As Hashtable) As Integer
		Dim resultInt As Integer
		If mainTxt("tbl_txt_newpoint") <> "9999" Then
			resultInt = mainTxt("tbl_txt_newpoint")
			Return resultInt
		End If
		
		Return 0
		
	End Function

'''■PointDiffChecker
''' <summary>コンマ区切りフォントサイズをバラして異なったフォントサイズがあるか確かめる</summary>
''' <param name="pointStrager">コンマ区切りフォントサイズ文字列</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function PointDiffChecker(pointStrager As String) As Boolean
		Dim splitPoint() As String = pointStrager.Split(",")
		Dim tempSplitPoint As String = splitPoint(0)
	
		For i As Integer = 0 To splitPoint.Length - 1 Step 1
			If tempSplitPoint <> splitPoint(i) Then
				Return False
			Else
				tempSplitPoint = splitPoint(i)
			End If
		Next i
	
		Return True
	
	End Function

'''■PointCollector
''' <summary>フォントサイズを変数にコンマ区切りでまとめる</summary>
''' <param name="point">String 格納したいフォントサイズ</param>
''' <param name="storager">String ByRef フォントを格納する変数</param>
''' <returns>Void</returns>
	Public Sub PointCollector(ByVal point As String, ByRef storager As String)
		If storager = "" Then 
			storager = point
		Else
			storager &= ","  & point
		End If

	End Sub
	
'''■OnePointPicker
''' <summary>フォントサイズをコンマ区切り文字列から１つ取り出す</summary>
''' <param name="pointStrager">String コンマ区切りフォントサイズ</param>
''' <param name="pickUpNo">Integer 取り出したいフォントサイズの位置</param>
''' <returns>フォントサイズ</returns>
	Public Function OnePointPicker(pointStrager As String, pickUpNo As Integer) As Integer
		Dim resultPoint As Integer
		Dim pointStr() As String = pointStrager.Split(",")
		
		resultPoint = pointStr(pickUpNo)
		Return resultPoint
		
	End Function
	
#End Region

End Class
