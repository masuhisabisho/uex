'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Option Strict On
Option Explicit On

Imports System.Diagnostics.Debug		'開発用

Public Class Common
	'END: また文字無しにした時にエラーが出るのが再発している
	Private Wc As WordContainer
	Private Const objCnt As Integer = 3		'挿入Objの最大数
	
	Public sub new (wordCont As WordContainer)
		Wc = wordCont
	End Sub
	'END:再現せず　追伸のところフォントサイズ変えてから文字を入れると位置がおかしい、他の行文字変更　追伸　→　ずれる
#Region "Word"
'2013/8/4　に　文字・フォント・y軸位置・x軸位置 スタイルに変更
''''■WordPreparer
''' <summary>DB内のセンテンスを獲得し、単語に分割、フォントサイズと一緒に格納</summary>
''' <param name="mainText">ArrayList メインテキスト</param>
''' <param name="fontSize">String フォントサイズ</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>	
	'Public function WordPreparer(mainTxt As ArrayList, fontSize As String) As ArrayList
	Public function WordPreparer(mainTxt As ArrayList) As ArrayList
		Dim lineCounter As Integer = mainTxt.Count - 1								'メインセンテンスの行数
		Dim insWord As New ArrayList 'Array
		Dim storageWord As New ArrayList
		'Dim registerChkFlg As Boolean = False
		'Dim basicPoint As String = fontSize
		
		For i As Integer = 0 To lineCounter Step 1
			Dim insPos() As String = {"", "", ""}									'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If DirectCast(mainTxt(i), Hashtable)("tbl_txt_inspos").ToString() <> "" Then							'END: 挿入文字があるか確認する	
				insPos = DirectCast(mainTxt(i), Hashtable)("tbl_txt_inspos").ToString().Split(","c)				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する ↓
				insWord = CheckInsWord(DirectCast(mainTxt(i), Hashtable)("tbl_txt_inspos").ToString(), _
										DirectCast(mainTxt(i), Hashtable)("tbl_txt_targetword").ToString(), _
										DirectCast(mainTxt(i), Hashtable)("tbl_txt_targetpoint").ToString(), _
										i _
										)													'フォントサイズ = 0, 挿入位置 = 1 文字（任意の数）= 2～ を獲得するに変更 2013/8/4 mb
				insFlg = True
			End If

			Dim loopCounter As Integer = CInt(DirectCast(mainTxt(i), Hashtable)("tbl_txt_txt").ToString().Length)
			
			If insFlg = True Then													'挿入フラグが立っている時、挿入文字分をループカウンターに加算
				For j As Integer = 0 To insPos.Length -1 Step 1
					'If insPos(j) <> "9999" Then
					'END: コンボ、テキストボックスが空のときフォントと位置情報のみ入れておく 2013/11/2
					If insPos(j) <> "9999" And CInt(DirectCast(insWord(j), String()).Length) > 2 Then
						loopCounter = loopCounter + CInt(DirectCast(insWord(j), String()).Length - 2)
					ElseIf insPos(j) <> "9999" And CInt(DirectCast(insWord(j), String()).Length) = 2 Then
						LoopCounter = loopCounter + 1
					End If
				Next j
			End If
			
			Dim wordInLine As New ArrayList
			Dim fixedWord As String = DirectCast(mainTxt(i), Hashtable)("tbl_txt_txt").ToString()
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim wordDetail() As String = {"", "", "", ""}
			For j As Integer = 0 To loopCounter - 1 Step 1
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If DirectCast(insWord(k), String()).Length > 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = j
						For l As Integer = 2 To CInt(DirectCast(insWord(k), String()).Length -1)
							wordDetail(0) = DirectCast(insWord(k), String())(l)
							wordDetail(1) = DirectCast(insWord(k), String())(0)
							wordInLine.Add(wordDetail)
							wordDetail = {"", "", "", ""}
							'registerChkFlg  = True
							
							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（最後の文字ので余分に増える為）
						k = k + 1
						Continue For
					ElseIf DirectCast(insWord(k), String()).Length = 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = j
						wordDetail(1) = DirectCast(insWord(0), String())(0)
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
					Else
						wordDetail(0) = fixedWord.Substring(m, 1)					'固定文字を格納
						
						Dim tempBasipoint As String = BasicPointChecker(DirectCast(mainTxt(i), Hashtable))
						If  tempBasipoint <> "0" Then
							wordDetail(1) = tempBasipoint
						Else
							wordDetail(1) = Wc.DefSet(1)
						End If
						
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						'registerChkFlg  = True
						
						m = m + 1
					End If
				Else
					wordDetail(0) = fixedWord.Substring(m, 1)
					
					Dim tempBasipoint As String = BasicPointChecker(DirectCast(mainTxt(i), Hashtable))
					If  tempBasipoint <> "0" Then
						wordDetail(1) = tempBasipoint
					Else
						wordDetail(1) = Wc.DefSet(1)
					End If
					
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
					'registerChkFlg  = True
					
					m = m + 1
				End If
			Next j
'			If registerChkFlg  = False Then
'				wordDetail(1) = DirectCast(insWord(0), String())(0)
'				wordInLine.Add(wordDetail)
'				wordDetail = {"", "", "", ""}
'			End If
			
			storageWord.Add(wordInLine)
			
			'registerChkFlg  = False
			insFlg = False
		Next i

		Return storageWord
		
	End Function

''''■WordArranger
''' <summary>文字のx軸位置、y軸位置を情報に基づき設定</summary>
''' <param name="mainText">ArrayList 文字の位置情報・フォントサイズ</param>
''' <param name ="storageWord">ArrayList 取得した文字・フォントサイズ</param>
''' <param name="Frm">PrintReport.vb</param>
''' <returns>単語・フォントサイズを格納した配列を返す</returns>
	Public Sub WordArranger(mainTxt As ArrayList, storageWord As ArrayList, Pr As PrintReport)
		'END: 文字が無い時改行だけするようにする

		Dim lineCounter As Integer = mainTxt.Count - 1
		
		If Wc.DefSet(0) = "0" Then
			Dim startXPos As Single = CSng(Wc.DefSet(2))	
			Dim startYPos As Single = CSng(Wc.DefSet(3))
			Dim newStartYPos As Single = 0
			Dim insColCnt As Integer = 0
			
			For i As Integer = 0  To lineCounter Step 1
				Dim selector As Integer = CInt(Directcast(mainTxt(i), Hashtable)("tbl_txt_ystyle"))
				Select Case selector
					Case 0	'上																'END: 上の場合の文字ピッチを計算
						If FontSizeDifChecker(DirectCast(storageWord(i), ArrayList)) = True Then					'★★全て同じフォントサイズの時★★
							startYPos= CheckNewYPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newypos")))
																							'文字ピッチの取得
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																DirectCast(storageWord(i), ArrayList), _
																Wc.optWord("Cmb_Font"), _
																0, _
																Pr _
																)
							
							Dim newXPos As Single = CheckNewXPos(CSng(Directcast(mainTxt(i), Hashtable)("tbl_txt_newxpos")))
							If newXPos <> 0 Then
								startXPos = startXPos + newXPos
							End If
							If DirectCast(DirectCast(storageWord(i),ArrayList)(0), String())(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(storageWord(i), ArrayList), Pr)
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))	'END: 文字サイズ＋ピッチへ 2013/7/2

								For j As Integer = 0 To CInt(DirectCast(storageWord(i), ArrayList).Count) - 1 step 1
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(2) = startYPos.ToString()
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(3) = startXPos.ToString()
									startYPos = startYPos + (fontSize(0) + properPit)
								Next j
							Else														'文字無し口
								Dim fontSize() As Single = Pr.FontSizeCal("", CStr(Wc.optWord("Cmb_Font")), CInt(DirectCast(DirectCast(storageWord(i) ,ArrayList)(0), String())(1)))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + FontSize(1))
									
'								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
'								Dim wordInLine As New ArrayList
'								wordDetail(0) = ""
'								wordDetail(1) = DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(1)
'								wordDetail(2) = startYPos.ToString()
'								wordDetail(3) = startXPos.ToString()
'								wordInLine.Add(wordDetail)
'								Wc.curWord = wordInLine
'								wordDetail = {"", "", "", ""}
'								Continue For
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(2) = startYPos.ToString()
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(3) = startXPos.ToString()
							End If
							
							Call Pr.CreateWord(DirectCast(storageWord(i), ArrayList), Wc.optWord("Cmb_Font"))
						Else	
							'END: ★★フォントサイズが違う時★★ 2013/7/2
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord, "WA0_SENTENCELOG", True)
#End If
						End If
					Case 1	'下
						If FontSizeDifChecker(DirectCast(storageWord(i), ArrayList)) = True Then					'★★全て同じフォントサイズの時★★
							Dim newXPos As Single = CheckNewXPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newxpos")))
							If newXPos <> 0 Then
								startXPos = startXPos + newXPos
							End If
							
							Dim fontSize() As Single
							If DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(0) <> "" Then							'文字あり
								fontSize = GetMaxWord(Wc.optWord("Cmb_Font"),DirectCast(storageWord(i), ArrayList), Pr)
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								For j As Integer = 0 To CInt(DirectCast(storageWord(i), ArrayList).Count) - 1 step 1
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(3) = startXPos.ToString()
								Next j
							Else														'文字なし口
								fontSize = Pr.FontSizeCal("", CStr(Wc.optWord("Cmb_Font")), CInt(DirectCast(DirectCast(storageWord(i),ArrayList)(0), String())(1)))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + FontSize(1))
'								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
'								Dim wordInLine As New ArrayList
'								'wordDetail(0) = storageWord(i)(0)(0)
'								wordDetail(0) = ""
'								wordDetail(1) = DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(1)
'								wordDetail(2) = startYPos.ToString()
'								wordDetail(3) = startXPos.ToString()
'								wordInLine.Add(wordDetail)
'								Wc.curWord = wordInLine
'								wordDetail = {"", "", "", ""}
								'Continue For
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(2) = startYPos.ToString()
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(3) = startXPos.ToString()
							End If 'END: 2013/7/9　下配置修正
							
							startYPos= CheckNewYPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newypos")))

							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																DirectCast(storageWord(i), ArrayList), _
																Wc.optWord("Cmb_Font"), _
																0, _
																Pr _
																)
							'2013/9/1 GetMaxWordでy軸も最大値を取るようにしたのでそれを使う
							Dim addHeight As Single = fontSize(0) * CSng(DirectCast(storageWord(i), ArrayList).Count)
							startYPos = CSng(Wc.DefSet(4)) - addHeight
							If storageWord.Count <> 1 Then
								startYPos = startYPos + (properPit * (CSng(DirectCast(storageWord(i), ArrayList).Count) - 1))
							End If
							
							If startYPos <= CSng(Wc.DefSet(3)) Then						'2013/8/25 add 3 lines mb
								startYPos = CSng(Wc.DefSet(3))
							End If
							Call YPosCal(DirectCast(storageWord(i), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
							Call Pr.CreateWord(DirectCast(storageWord(i), ArrayList), Wc.optWord("Cmb_Font"))
						Else
							'★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord, "WA1_SENTENCELOG", True)
#End If
						End If
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						'END: pointDiffCheckerをつける
						If FontSizeDifChecker(DirectCast(storageWord(i), ArrayList)) = True Then					'★★全て同じフォントサイズの時★★
							startYPos= CheckNewYPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newypos")))
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																DirectCast(storageWord(i), ArrayList), _
																Wc.optWord("Cmb_Font"), _
																2, _
																Pr _
																)
						
							Dim newXPos As Single = CheckNewXPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newxpos")))
							If newXPos <> 0 Then  
								startXPos = startXPos + newXPos									'x軸イレギュラースタートの確認
							End If	
							
							If DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"),DirectCast(storageWord(i), ArrayList), Pr)
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								For j As Integer = 0 To CInt(DirectCast(storageWord(i), ArrayList).Count) - 1 step 1
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(2) = startYPos.ToString()
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(3) = startXPos.ToString()
									startYPos = startYPos + (fontSize(0) + properPit)
								Next j
							Else											'文字無し
								Dim fontSize() As Single = Pr.FontSizeCal("", CStr(Wc.optWord("Cmb_Font")), CInt(DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(1)))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								'Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								'Dim wordInLine As New ArrayList
								'END:wordDetailの0は必要なのか？
								'wordDetail(0) = DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(0), String())(0)  'storageWord(i)(0)(0)
								'CreateWordで一括して保存する方法に変更 2013/11/4
								'wordDetail(0) = ""
'								wordDetail(1) = DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(0), String())(1)  'storageWord(i)(0)(1)
'								wordDetail(2) = startYPos.ToString()
'								wordDetail(3) = startXPos.ToString()
'								wordInLine.Add(wordDetail)
'								Wc.curWord = wordInLine
'								wordDetail = {"", "", "", ""}
								'Continue For
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(2) = startYPos.ToString()
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(3) = startXPos.ToString()
							End If
							Call Pr.CreateWord(DirectCast(storageWord(i), ArrayList), Wc.optWord("Cmb_Font"))
						Else															'フォントサイズが異なる
							'END: ★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord, "WA2_SENTENCELOG", True)
#End If
						End If	
					Case 3	'ツーセンテンス上下
						If FontSizeDifChecker(DirectCast(storageWord(i), ArrayList)) = True Then					'★★全て同じフォントサイズの時★★
							Dim fontSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(storageWord(i), ArrayList), Pr)
							Dim targetObj() As String = CStr(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_targetword")).Split(","c)
							Dim targetObjPos() As String = CStr(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_inspos")).Split(","c)
							Dim tempStorageWord As New ArrayList
							Dim cnt As Integer = 0
							Dim totalWordLength As Single = 0
							Dim properPit As Single
							
							'CHK:どちらも挿入か、不可変　＋　挿入の組み合わせか？
							'WordPreparerで片方取り込む(不可変・挿入どちらも同じ過程) -> Waでもうひとつを取り込み位置を設定
							Dim firstStr As String = ""										'2013/10/17 add 2 lines
							Dim secondStr As String = ""
							
							'文字位置の選定																			'可 = 可変文字 不 = 不可変文字
							If targetObjPos(1) <> "9999" Then 														'可・可の場合
								firstStr = Wc.optWord(targetObj(0))
								secondStr = Wc.optWord(targetObj(1))
							ElseIf CDbl(targetObjPos(0)) <> 0 And targetObjPos(1) = "9999"							'不・可の場合
								firstStr = DirectCast(DirectCast(Wc.mainTxt, ArrayList)(i), Hashtable)("tbl_txt_txt").ToString()
								SecondStr = Wc.optWord(targetObj(0))
							ElseIf targetObjPos(0) = "0" And targetObjPos(1) = "9999"								'可・不の場合
								firstStr = Wc.optWord(targetObj(0))
								secondStr = DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_txt").ToString()
							End If
							
							'開始位置確認
							startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newypos")))
							startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1)) + CheckNewXPos(CSng(DirectCast(mainTxt(i), Hashtable)("tbl_txt_newxpos")))
							
							'上文字
							If firstStr.Length <> 0 Then															'END:文字列が無い時は処理しない -> 空文字対策が必要（フォントサイズ変更に必要）
								Do Until cnt = firstStr.Length
									tempStorageWord.Add(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(cnt))
								cnt += 1
								Loop
								
								properPit = PitchCal(startYPos, _
													 CSng(Wc.DefSet(4)), _
													 tempStorageWord, _
													 Wc.optWord("Cmb_Font"), _
													 0, _
													 Pr _
													)
								
								For j As Integer = 0 To firstStr.Length - 1 Step 1
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(2) = startYPos.ToString()
									DirectCast(DirectCast(storageWord(i), ArrayList)(j), String())(3) = startXPos.ToString()
									startYPos = startYPos + fontSize(0) + properPit
								Next j
							Else																					'add 空文字情報 2013/11/3
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(2) = startYPos.ToString()
								DirectCast(DirectCast(storageWord(i), ArrayList)(0), String())(3) = startXPos.ToString()
								startYPos = startYPos + fontSize(0) + properPit
							End If
							
							totalWordLength = CSng(DirectCast(tempStorageWord(cnt - 1),String())(2)) + fontSize(0)	'一番下の文字の底位置
							
							'下文字
							If secondStr.Length <> 0 Then
								tempStorageWord.Clear()
								cnt = firstStr.Length
								Do Until cnt = firstStr.Length + secondStr.Length
									tempStorageWord.Add(DirectCast(storageWord(i), ArrayList)(cnt))
									cnt += 1
								Loop
								
								properPit = PitchCal(startYPos, _
													 CSng(Wc.DefSet(4)), _
													 tempStorageWord, _
													 Wc.optWord("Cmb_Font"), _
													 1, _
													 Pr _
													)
								
								startYPos = CSng(Wc.DefSet(4)) _
												 - (fontSize(0) * secondStr.Length _
												 + (properPit * (secondStr.Length - 1)) _
												)
								
								If startYPos <= totalWordLength Then												'下文字が上文字の位置と重複する時
									startYPos = totalWordLength
									properPit = PitchCal(startYPos, _
														 CSng(Wc.DefSet(4)), _
														 tempStorageWord, _
														 Wc.optWord("Cmb_Font"), _
														 2, _
														 Pr _
														)
								End If
								
								For j As Integer = firstStr.Length To (firstStr.Length + secondStr.Length) -1 Step 1
									DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(j), String())(2) = startYPos.ToString()
									DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(j), String())(3) = startXPos.ToString()
									startYPos = startYPos + fontSize(0) + properPit
								Next j
							Else																					'add 空文字情報 2013/11/3
								startYPos = CSng(Wc.DefSet(4)) - fontSize(0)
								DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(firstStr.Length), String())(2) = startYPos.ToString()
								DirectCast(DirectCast(DirectCast(storageWord, ArrayList)(i), ArrayList)(firstStr.Length), String())(3) = startXPos.ToString()
							End If

							Call Pr.CreateWord(DirectCast(storageWord(i), ArrayList), Wc.optWord("Cmb_Font"))
							
						Else															'フォントサイズが異なる
							'END: ★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord, "WA3_SENTENCELOG", True)
#End If
						End If	
					End Select

					startYPos = 0

				Next i
		Else
		'TODO: 横書きの時
		End If

	End Sub
	
'データを置き換える
''' ■WordReplacer
''' <summary>コンボ変更に対して文字挿入、y軸位置、x軸位置を決める</summary>
''' <param name="lineNo">Integer 行番号</param>
''' <param name="pr">Frm PrintReport.vb</param>
''' <param name="yStyle">Integer 上、下、天地</param>
''' <param name="newTargetCmb">Optional ComboBox 動かされるコンボ（Optionalどちらかを指定する）</param>
''' <param name="newTargetTxt">Optional Textbox 変更するテキストボックス</param>
''' <param name="twoSentencePos">Optional Integer Case 3　の上下の判断パラメータ</param>
''' <returns>Void CurWordの内容を変更する</returns>
	Public Sub WordReplacer(ByVal lineNo As Integer, _
							ByVal Pr As PrintReport, _
							ByVal yStyle As Integer, _
							Optional ByVal newTargetCmb As ComboBox = Nothing, _
							Optional ByVal newTargetTxt As TextBox = Nothing)
							'Optional ByVal twoSentencePos As Integer = 0
							
#If Debug Then
	Try
#End If
		'y軸開始位置の確認
		Dim startYPos As Single = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
		
		'フォントサイズが全て同じかどうか確認する
		Dim fontSizeDif As Boolean
		If DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(0) <> "" Then
			fontSizeDif = FontSizeDifChecker(DirectCast(Wc.curWord(lineNo), ArrayList))
		Else
			fontSizeDif = True
		End If
		
		'コンボの値を置き換え
		If newTargetCmb IsNot Nothing Then
			If newTargetCmb IsNot Pr.Cmb_Year And newTargetCmb IsNot Pr.Cmb_Month And newTargetCmb IsNot Pr.Cmb_day Then
				Wc.optWord(newTargetCmb.Name) = newTargetCmb.SelectedValue.ToString()
			End If
		End If
		'テキストボックスの値を置き換え
		If newTargetTxt IsNot Nothing Then
			Wc.optWord(newTargetTxt.Name) = newTargetTxt.Text
		End If
		'★★全て同じの時★★
		If fontSizeDif = True then
			'END: y軸位置は後で決める
			'END: 適正なピッチを取る
			'END: 適正なピッチを使ってy軸位置を決めていく
			'END: 上・下・天地
			
			'ArrayList無いのフォントサイズとx軸位置の値を移しておく
			Dim tempWord As New Hashtable
			tempWord("fontSize") = DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(1)					'フォントサイズ
			tempWord("xPos") = DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(3)					'x軸位置
			
			'CHK: ツーセンテンス上下ケースを考える（上あり、下なしの時、下はなしなってしまう）
'			For i As Integer = 0 To DirectCast(Wc.curWord(lineNo), ArrayList).Count - 1 Step 1
'				tempWord("xPos") = DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(3)					'x軸位置
'				If tempWord("xPos").ToString() <> "" Then
'					Exit For
'				End If
'			Next i
			
			'curWordの任意の行のデータを削除しておく
			DirectCast(Wc.curWord(lineNo), ArrayList).Clear
			'挿入位置を取得
			Dim insPos() As String
			insPos = DirectCast(Wc.mainTxt(lineNo),Hashtable)("tbl_txt_inspos").ToString().Split(","c)
			'挿入文字配列を取得
			Dim insWord As New ArrayList 'array
			insWord = CheckInsWord(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos").ToString(), _
    	                           DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword").ToString(), _
    	                           DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint").ToString(), _
    	                           lineNo _
    	                           )
			
			Dim loopCounter As Integer = CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString().Length)
			'挿入文字の字数をループカウンター（不変文字数）に加算する
			For i As Integer = 0 To insWord.Count - 1 Step 1
				If CInt(insPos(i)) <> 9999 Then
					If CInt(DirectCast(insWord(i), String()).Length) > 2 Then
						loopCounter = loopCounter + CInt(DirectCast(insWord(i), String()).Length -2)
					Else 'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
						loopCounter = loopCounter + 1
					End If
				End If
			Next i 
			'不変文字と挿入文字を一つの配列に格納していく
			Dim wordInLine As New ArrayList()
			Dim wordDetail(3) As String
			Dim k As Integer = 0
			Dim l As Integer = 0

			For i As Integer = 0 To loopCounter - 1 Step 1	
				If DirectCast(insWord(k), String()).Length > 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = i Then
					For j As Integer = 2 To CInt(DirectCast(insWord(k), String()).Length - 1) Step 1
						wordDetail(0) = DirectCast(insWord(k), String())(j)
						wordDetail(1) = tempWord("fontSize").ToString()
						wordDetail(3) = tempWord("xPos").ToString()					'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}								'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
				'	 挿入文字が無い且つフォントサイズがある場合 = 文字 = 無し フォントサイズ =　そのまま	
				ElseIf DirectCast(insWord(k), String()).Length = 2 'AndAlso　CInt(DirectCast(insWord(k), String())(1)) = i　Then 2013/11/4 comment out
						wordDetail(0) = ""
						wordDetail(1) = tempWord("fontSize").ToString()
						wordDetail(3) = tempWord("xPos").ToString()
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						k = k + 1
				Else
					wordDetail(0) = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString().Substring(l, 1)
					wordDetail(1) = tempWord("fontSize").ToString()
					wordDetail(3) = tempWord("xPos").ToString()
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					l = l + 1
				End If
			Next i
			If loopCounter = 0 Then		'文字無し対策　2013/9/8 add 7 lines mb
				wordDetail(0) = ""
				wordDetail(1) = tempWord("fontSize").ToString()
				wordDetail(3) = tempWord("xPos").ToString()			'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
				wordInLine.Add(wordDetail)
				wordDetail = {"", "", "", ""}						'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）

			End If
			
			Wc.curWord(lineNo) = wordInLine
			
			
			'x軸位置の代入
			For i As Integer = 0 To DirectCast(Wc.curWord(lineNo), ArrayList).Count - 1 Step 1
				Directcast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(3) = tempWord("xPos").ToString()
			Next i
			
			'y軸位置の代入
			Dim properPit As Single
			'Dim startYPos As Single = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
			Dim maxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), wordInLine, Pr)
			
			Select Case yStyle
				Case 0, 2
					'startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
					properPit = PitchCal(startYPos, _
										CSng(Wc.DefSet(4)), _
										wordInLine, _
										Wc.optWord("Cmb_Font"), _
										yStyle, _
										Pr _
										)
				Case 1
			 		properPit = PitchCal(startYPos, _
										CSng(Wc.DefSet(4)), _
										wordInLine, _
										Wc.optWord("Cmb_Font"), _
										yStyle, _
										Pr _
										)
					startYPos = CSng(Wc.DefSet(4)) - ((maxWord(0) * CSng(wordInLine.Count)) + (properPit * (CSng(wordInLine.Count) - 1)))
					
					If startYPos <= CSng(Wc.DefSet(3)) Then
						startYPos = CSng(Wc.DefSet(3))
						properPit = 0
						properPit = PitchCal(startYPos, _
												CSng(Wc.DefSet(4)), _
												wordInLine, _
												Wc.optWord("Cmb_Font"), _
												yStyle, _
												Pr _
												)
					End If
					'y軸位置の挿入(ystle 0 ,1, 2)
					For i As Integer = 0 To loopCounter - 1 Step 1
						'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
						'    文字がある時は新しいy軸位置を無ければ前のを変更せず入れる
						If DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(0) <> "" Then
							DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(2) = startYPos.ToString()
							startYPos = startYPos + maxWord(0) + properPit
						Else
							DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(2) = startYPos.ToString()
						End If
						
					Next i
					
				Case 3 '2013/9/29 追加　ツーセンテンス上下 (フォントサイズ同じ場合)
					'TODO:『御挨拶』は固定しないといけない
					'END: ツーセンテンス上下処理の実装
					'END: 上の文字位置
					Dim targetObj() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword")).Split(","c)
					Dim targetPoint() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint")).Split(","c)
					Dim targetObjPos() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos")).Split(","c)
					
					Dim firstStr As String = ""
					Dim secondStr As String = ""
					Dim firstPoint As String = ""
					Dim secondPoint As String = ""
					
					
					'上下文字・フォントの取り出し（長さ判定に必要）									'可 = 可変文字 不 = 不可変文字
					If targetObjPos(1) <> "9999" Then 											'可・可の場合
						firstStr = Wc.optWord(targetObj(0))
						secondStr = Wc.optWord(targetObj(1))
						firstPoint = Wc.optWord(targetPoint(0))
						secondPoint = Wc.optWord(targetPoint(1))					
					ElseIf targetObjPos(0) = "9999" And targetObjPos(1) <> "9999"				'不・可の場合
						firstStr = DirectCast(DirectCast(Wc.mainTxt, ArrayList)(lineNo), Hashtable)("tbl_txt_txt").ToString()
						SecondStr = Wc.optWord(targetObj(0))
						firstPoint = Wc.DefSet(2)
						secondPoint = Wc.optWord(targetPoint(1))
					ElseIf targetObjPos(0) = "0" And targetObjPos(1) = "9999"					'可・不の場合
						firstStr = Wc.optWord(targetObj(0))
						secondStr = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString()
						firstPoint = Wc.optWord(targetPoint(0))
						secondPoint = Wc.defset(2)
					End If
					
					Dim lastWordXPos As Single
					
					If lineNo <> 0 Then
						Dim wordNum As Integer
						Dim tempLastWordXPos() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)  'Wc.curWord(lineNo - 1)(0)(3)
						lastWordXPos = CSng(DirectCast(Directcast(Wc.curWord(lineNo - 1),ArrayList)(wordNum), String())(3))
					Else
						lastWordXPos = CSng(Wc.DefSet(2))
					End If
					
					Dim nextXPos As Single = SetIrrXYPos(lineNo, _
														DirectCast(Wc.curWord(lineNo), ArrayList), _
														Wc.optWord("Cmb_Font"), _
														startYPos, _
														lastWordXPos, _
														Pr, _
														firstStr, _
														secondStr _	
														)
					Call ShiftXPos(lineNo, nextXPos, Pr)
			End Select

		'★★フォントサイズが違う時★★
		Else
			'ArrayListを削除
			DirectCast(Wc.curWord(lineNo), ArrayList).Clear
			'挿入位置を取得
			Dim insPos() As String
			insPos = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos").ToString().Split(","c)
			'挿入文字配列を取得
			Dim insWord As New ArrayList'array
			insWord = CheckInsWord(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos").ToString(), _
    	                           DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword").ToString(), _
    	                           DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint").ToString(), _
    	                           lineNo _
    	                           )

			Dim loopCounter As Integer = CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString().Length)
			'挿入文字の字数をループカウンター（不変文字数）に加算する
			For i As Integer = 0 To insWord.Count - 1 Step 1	'END:配列から取る
				If CInt(insPos(i)) <> 9999 Then			
					If DirectCast(insWord(i), String())(0) <> "" And CInt(DirectCast(insWord(i), String()).Length) = ２ Then
						loopCounter = loopCounter + 1	'CHK: NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる　フォントサイズある且つ長さが２以下（挿入文字がない）
					End If
					loopCounter = loopCounter + CInt(DirectCast(insWord(i), String()).Length -2)	
				End If
			Next i
			'不変文字と挿入文字を一つの配列に格納していく
			Dim wordInLine As New ArrayList()
			Dim wordDetail(3) As String
			Dim k As Integer = 0
			Dim l As Integer = 0
			
			For i As Integer = 0 To loopCounter - 1 Step 1
				If DirectCast(insWord(k), String()).Length > 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = i Then	
					For j As Integer = 2 To CInt(DirectCast(insWord(k), String()).Length - 1) Step 1
						wordDetail(0) = DirectCast(insWord(k), String())(j)
						wordDetail(1) = DirectCast(insWord(k), String())(0)
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる（変更文字が空白でもフォントサイズは保有する）
				Elseif DirectCast(insWord(k), String()).Length = 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = i Then
					wordDetail(1) = DirectCast(insWord(k), String())(0)			'フォントサイズのみ格納
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
					k = k + 1
				Else
					wordDetail(0) = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString().Substring(l, 1)
					wordDetail(1) = Wc.DefSet(1)
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					l = l + 1
				End If
			Next i
			
			Wc.curWord(lineNo) = wordInLine
			
			'x軸位置
			Dim lastWordXPos As Single
			
			If lineNo <> 0 Then
				Dim wordNum As Integer
				Dim tempLastWordXPos() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)  'Wc.curWord(lineNo - 1)(0)(3)
				lastWordXPos = CSng(DirectCast(Directcast(Wc.curWord(lineNo - 1),ArrayList)(wordNum), String())(3))
			Else
				lastWordXPos = CSng(Wc.DefSet(2))
			End If
			
			Select Case yStyle
				Case 0, 1, 2
					Dim maxWord As Single = SetIrrXYPos(lineNo, _
														DirectCast(Wc.curWord(lineNo), ArrayList), _
														Wc.optWord("Cmb_Font"), _ 
														startYPos, _
														lastWordXPos, _
														Pr _
														)

					Call ShiftXPos(lineNo,  maxWord, Pr)
				Case 3
					Dim targetObj() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword")).Split(","c)
					Dim targetObjPos() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos")).Split(","c)

					Dim firstStr As String = ""
					Dim secondStr As String = ""
						
					'文字位置の選定														'可 = 可変文字 不 = 不可変文字
					If targetObjPos(1) <> "9999" Then 									'可・可の場合
						firstStr = Wc.optWord(targetObj(0))
						secondStr = Wc.optWord(targetObj(1))
					ElseIf CDbl(targetObjPos(0)) <> 0 And targetObjPos(1) = "9999"		'不・可の場合
						firstStr = DirectCast(DirectCast(Wc.mainTxt, ArrayList)(lineNo), Hashtable)("tbl_txt_txt").ToString()
						SecondStr = Wc.optWord(targetObj(0))
					ElseIf targetObjPos(0) = "0" And targetObjPos(1) = "9999"			'可・不の場合
						firstStr = Wc.optWord(targetObj(0))
						secondStr = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString()
					End If
					
					Dim maxWord As Single = SetIrrXYPos(lineNo, _
														 DirectCast(Wc.curWord(lineNo), ArrayList), _
														 Wc.optWord("Cmb_Font"), _ 
														 startYPos, _
														 lastWordXPos, _
														 Pr, _
														 firstStr, _
														 secondStr _
														 )

					Call ShiftXPos(lineNo,  maxWord, Pr)
			End Select
			
		End If

#If Debug Then
		Catch ex As Exception
	End Try
#End If
End sub

'''■CheckInsWord
''' <summary>挿入文字を取り出し</summary>
''' <param name="insPos">String 挿入があるかどうか</param>
''' <param name="targetWord">String 挿入文字の値の入ったのHashTableのキー名</param>
''' <param name="targetPoint">String ポイントの値の入ったのHashTableのキー名</param>
''' <param name="insCol">Integer 挿入があった列番号</param>		<- 追加	2013/6/30
''' <returns>フォントサイズ = 0, 挿入位置 = 1, 文字（任意の数）= 2～</returns>
	Public Function CheckInsWord(ByVal insPos As String, ByVal targetWord As String, _
								 ByVal targetPoint As String, ByVal insCol As Integer _
								) As ArrayList
		'As Array
    	'END: 文字数, フォント, フォントサイズを獲得する
    	'END: 挿入位置も格納しておく 2013/6/29
    	'END: 挿入列も格納しておく   2013/6/30
        'Dim returnAr(3) As Array
        Dim returnAr As New ArrayList
        Dim splitInsPos() As String
        Dim splitTargetWord() As String
        Dim splitTargetPoint() As String
        Dim newInsPos As Integer
        
        splitInsPos = insPos.Split(","c)															'挿入位置。2番目は1番の後から2番目までの間の不変文字の数（以降同じ）
        splitTargetWord = targetWord.Split(","c)													'分割された挿入文字
        splitTargetPoint = targetPoint.Split(","c)													'それぞれのフォントサイズ
        
        For i As Integer = 0 To objCnt Step 1														'現状1行に3挿入までにする
        	If splitInsPos(i) <> "9999" Then
        		Dim word As String = Wc.optWord(splitTargetWord(i))
        		Dim wordPoint As String = Wc.optWord(splitTargetPoint(i))
        		Dim wordLength As Integer = CInt(word.Length)  										'文字数をフォントサイズを格納する分が２つ
        		Dim resultAr(wordLength + 1) As String
        		Dim k As Integer = 0
        		
        		For j As Integer = 0 To wordLength + 1 Step 1
        			If j = 0 Then
        				resultAr(j) = wordPoint														'フォントサイズ = 1 -> 0 に
        			ElseIf j = 1 Then
        				If i = 0 Then
        					resultAr(j) = splitInsPos(i)											'挿入位置 = 1
        					If wordLength <> 0 Then        											'CHK:文字なしの時の処理 2013/11/4
        						newInsPos = CInt(splitInsPos(i)) + wordLength
        					Else
        						newInsPos = CInt(splitInsPos(i)) + 1
        					End If
        				Else
        					If wordLength <> 0 Then
        						resultAr(j) = (newInsPos + CInt(splitInsPos(i))).ToString() 		'2番目以降の挿入の相対位置を絶対位置に確定する
        						newInsPos = CInt(resultAr(j)) + wordLength
        					Else																	'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
        						resultAr(j) = newInsPos.ToString()
        						newInsPos = CInt(resultAr(j)) + 1
        					End If
        				End If
        			Else
        				resultAr(j) = word.Substring(k, 1)
        				k = k + 1
        			End If
        		Next j
        		'returnAr(i) = resultAr
        		returnAr.add(resultAr)
        	Else
        		Dim emptyAr() As String = {""}
        		returnAr.Add(emptyAr)
        	End If
        Next i
        
        Return returnAr
        
	End Function
	
'フォントサイズを変更する
'''■ChangeFontSize
''' <summary>フォントサイズを変更して新しい位置を求める</summary>
''' <param name="changeType">Integer 0 = 全体変更　1 = 部分変更 2 = 複数行同時全体変更 3 = ツーセンテンス上下</param>
''' <param name="lineNo">Integer 変更する行番号</param>
''' <param name="targetPointCmb">Combo 変更するフォントサイズコンボ</param>
''' <param name="Pr">PrintReport</param>
''' <param name="multiNum">Optional Integer 複数行変更の際の行数</param>
''' <param name="strPos">Optional Integer ツーセンテンス上下の判別用 上 = 1 下 = 2</param>
''' <returns>Void 文字配列を変更する</returns>
	Public Sub ChangeFontSize(ByVal changeType As Integer, ByVal lineNo As Integer, _
							  ByVal targetPointCmb As ComboBox, ByVal Pr As PrintReport, _
							  Optional ByVal MultiNum As Integer = 0, _
							  Optional ByVal twoSentencePos As Integer = 0)
		'END: 全体変更するのか、部分変更するのかを確認する -> パラメーターで制御
		'END: 文字が無い時の対応が必要
#If debug Then
try
#End If
		Dim startYPos As Single = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
		'END: y軸位置がイレギュラーでないか？
		Dim lastWordXPos As Single
		
		If lineNo <> 0 Then
			Dim wordNum As Integer
			Dim tempLastMaxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)
			lastWordXPos = CSng(DirectCast(DirectCast(Wc.curWord(lineNo - 1), ArrayList)(wordNum), String())(3))
		Else
			lastWordXPos = CSng(Wc.DefSet(2))
		End If
		
		Select Case changeType								'★★全体変更
			Case 0
				'END: 一つ前の行のx位置(文字列中最大）を獲得する -> 基本列ピッチ + 新しいフォントサイズのx軸位置 = 新しいx軸位置
'				Dim lastWordXPos As Single
'								If lineNo <> 0 Then
'					Dim wordNum As Integer
'					Dim tempLastWordXPos() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)  'Wc.curWord(lineNo - 1)(0)(3)
'					lastWordXPos = CSng(DirectCast(Directcast(Wc.curWord(lineNo - 1),ArrayList)(wordNum), String())(3))
'				Else
'					lastWordXPos = CSng(Wc.DefSet(2))
'				End If
				'新しいフォントサイズを突っ込む
				For i As Integer = 0 To DirectCast(Wc.curWord(lineNo), ArrayList).Count - 1 Step 1
					DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(1) = targetPointCmb.SelectedIndex.ToString()
				Next i
				'行内の文字の最大幅をとる
				'END: 文字が無い時ダミーで文字サイズを計測する
				Dim maxWordSize() As Single
				If DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(0) <> "" Then
					maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo), ArrayList), Pr)
				Else
					maxWordSize = Pr.FontSizeCal("", Wc.optWord("Cmb_Font").ToString(), CInt(DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(1)))
				End If
				
				'END: 新しいx軸位置の確定
				Dim startNewXPos As Single
				startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
				'END: 配列にx軸位置を突っ込む
				For i As Integer = 0 To DirectCast(Wc.curWord(lineNo), ArrayList).Count - 1 Step 1
					DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(3) = startNewXPos.ToString()
				Next i
				
				'startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
				
				Dim properPit As Single = PitchCal(startYPos, _
													CSng(Wc.DefSet(4)), _
													DirectCast(Wc.curWord(lineNo), ArrayList), _
													Wc.optWord("Cmb_Font"), _
													CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
													Pr _
												 )
				'END: y軸位置を決めていく
				Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle").ToString()
					Case "0", "2"
						Call YPosCal(DirectCast(Wc.curWord(lineNo), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
					Case "1"
						Dim addHeight As Single = maxWordSize(0) * CSng(DirectCast(Wc.curWord(lineNo), ArrayList).Count)
						If (CSng(Wc.DefSet(4)) - addHeight) <= startYPos Then			'y軸の最大値を超えないようにする
							startYPos = CSng(Wc.DefSet(3))
						Else
							startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(DirectCast(Wc.curWord(lineNo), ArrayList).Count) -1)))　
						End If
						Call YPosCal(DirectCast(Wc.curWord(lineNo), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
				End Select
				'END: 以降の列のx軸位置を変更して行く
				Call ShiftXPos(lineNo, startNewXPos, Pr)
			Case 1												'★★部分変更
				'挿入位置を取得
				Dim insPos() As String
				insPos = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos")).Split(","c)
				'挿入文字配列を取得
				Dim insWord As new ArrayList 'As array
				insWord = CheckInsWord(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos").ToString(), _
										DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword").ToString(), _
										DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint").ToString(), _
										lineNo _
									  )
				
				Dim loopCounter As Integer = CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString().Length)
				'挿入文字の字数をループカウンター（不変文字数）に加算する
				For i As Integer = 0 To insWord.Count - 1 Step 1
					If CInt(insPos(i)) <> 9999 Then
						'loopCounter = loopCounter + CInt(DirectCast(insWord(i), String()).Length -2)
						If CInt(DirectCast(insWord(i), String()).Length) > 2 Then
							loopCounter = loopCounter + CInt(DirectCast(insWord(i), String()).Length -2)
						Else 'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
							loopCounter = loopCounter + 1
						End If
					End If
				Next i 
				'不変文字と挿入文字を一つの配列に格納していく
				Dim wordInLine As New ArrayList()
				Dim wordDetail(3) As String
				Dim k As Integer = 0
				Dim l As Integer = 0
				
				For i As Integer = 0 To loopCounter - 1 Step 1	
					'If IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(1)) = i Then			'CheckInsWordの値をArrayListに変更
					If DirectCast(insWord(k), String()).Length > 2 AndAlso CInt(DirectCast(insWord(k), String())(1)) = i Then
						For j As Integer = 2 To CInt(DirectCast(insWord(k), String()).Length - 1) Step 1
							wordDetail(0) = DirectCast(insWord(k), String())(j)
							wordDetail(1) = DirectCast(insWord(k), String())(0)
							wordInLine.Add(wordDetail)
							wordDetail = {"", "", "", ""}	
							i = i + 1
						Next j
						i = i - 1
						k = k + 1
					'CHK:NO.1 文字がないがフォントサイズを変更したらその分の計算をするようにさせる
					'	 挿入文字が無い且つフォントサイズがある場合 = 文字 = 無し フォントサイズ =　そのまま	
					ElseIf DirectCast(insWord(k), String()).Length < 3 AndAlso　CInt(DirectCast(insWord(k), String())(1)) = i　Then
						wordDetail(0) = ""
						wordDetail(1) = DirectCast(insWord(k), String())(0)
						wordDetail(3) = "0"
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						k = k + 1
					Else
						wordDetail(0) = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt")).Substring(l, 1)
						wordDetail(1) = Wc.DefSet(1)
						wordInLine.add(wordDetail)
						wordDetail = {"", "", "", ""}
						l = l + 1
					End If
				Next i
				If loopCounter = 0 Then				'文字無し対策　2013/9/8 add 7 lines mb
					wordDetail(0) = ""				'END: フォントサイズ変えるのに文字格納が必要か？
					wordDetail(1) = Wc.DefSet(1)
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
				End If
				
				DirectCast(Wc.curWord(lineNo), ArrayList).clear
				Wc.curWord(lineNo) = wordInLine
				
				'END: イレギュラー位置の決定
				'startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
				
'				Dim lastWordXPos As Single
'				
'				If lineNo <> 0 Then
'					Dim wordNum As Integer
'					Dim tempLastMaxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)
'					lastWordXPos = CSng(DirectCast(DirectCast(Wc.curWord(lineNo - 1), ArrayList)(wordNum), String())(3))
'				Else
'					lastWordXPos = CSng(Wc.DefSet(2))
'				End If
				'END: イレギュラーでない処理（再び全て揃った時）

				'x軸位置の設定
				If FontSizeDifChecker(DirectCast(Wc.curWord(lineNo), ArrayList)) = True Then
					Dim maxWordSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo), ArrayList), Pr)
					Dim startNewXPos As Single = lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					'x軸位置を突っ込む
					For i As Integer = 0 To CInt(DirectCast(Wc.curWord(lineNo), ArrayList).Count) - 1 Step 1
						DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(3) = startNewXPos.ToString()
					Next i
					
					Dim properPit As Single = PitchCal(startYPos, _
														CSng(Wc.DefSet(4)), _
														Directcast(Wc.curWord(lineNo), ArrayList), _
														Wc.optWord("Cmb_Font"), _
														CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
														Pr _
													)
					'y軸位置の設定
					Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle").ToString()
						Case "0", "2"
							Call YPosCal(DirectCast(Wc.curWord(lineNo), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
						Case "1"
							Dim addHeight As Single = CheckLineLength(DirectCast(Wc.curWord(lineNo), ArrayList), Wc.optWord("Cmb_Font").ToString(), Pr）
							If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
								startYPos = addHeight
							Else
								startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(DirectCast(Wc.curWord(lineNo), ArrayList).Count -1))))　
							End If
					End Select
					Call ShiftXPos(lineNo,  startNewXPos, Pr)
				Else	'フォントサイズがイレギュラーになった時
					Dim maxWord As Single = SetIrrXYPos(lineNo, _
														DirectCast(Wc.curWord(lineNo), ArrayList), _
														Wc.optWord("Cmb_Font"), _ 
														startYPos, _
														lastWordXPos, _
														Pr _
														)

					Call ShiftXPos(lineNo,  maxWord, Pr)
				End If
			Case 2											'★★マルチ変更
				'END lastWordXPos 要再考
'				Dim lastWordXPos As Single
				Dim startNewXPos As Single
				
'				If lineNo <> 0 Then
'					Dim wordNum As Integer
'					Dim tempLastWordXPos() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)  'Wc.curWord(lineNo - 1)(0)(3)
'					lastWordXPos = CSng(DirectCast(Directcast(Wc.curWord(lineNo - 1),ArrayList)(wordNum), String())(3))
'				Else
'					lastWordXPos = CSng(Wc.DefSet(2))
'				End If
				
				For i As Integer = lineNo To　(lineNo + MultiNum) - 1 Step 1
					'新しいフォントサイズを突っ込む
					For j As Integer = 0 To CInt(DirectCast(Wc.curWord(i), ArrayList).Count) -1 Step 1		'GetMaxWordを使うため
						DirectCast(DirectCast(Wc.curWord(i), ArrayList)(j), String())(1) = targetPointCmb.SelectedIndex.ToString()
					Next j
					
					Dim maxWordSize() As Single
					If DirectCast(DirectCast(Wc.curWord(i), ArrayList)(0), String())(0) <> "" Then
						maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(i), ArrayList), Pr)
					Else
						'END:関数内で処理する -> fontSizeCalでいいのでは？
						maxWordSize = Pr.FontSizeCal("", Wc.optWord("Cmb_Font").ToString(), CInt(DirectCast(DirectCast(Wc.curWord(i), ArrayList)(0), String())(1)))
					End If
					If i = lineNo Then
						startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					Else
						startNewXPos = startNewXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					End If
					'x軸位置を突っ込む
					For j As Integer = 0 To DirectCast(Wc.curWord(i), ArrayList).Count - 1 Step 1
						DirectCast(DirectCast(Wc.curWord(i), ArrayList)(j), String())(3) = startNewXPos.ToString()
					Next j
					
					'startYPos= CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
					
					Dim properPit As Single = PitchCal(startYPos, _
														CSng(Wc.DefSet(4)), _
														DirectCast(Wc.curWord(i), ArrayList), _
														Wc.optWord("Cmb_Font"), _
														CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
														Pr _
													  )
					'y軸位置を決めていく
					Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle").ToString()
						Case "0", "2"
							Call YPosCal(DirectCast(Wc.curWord(i), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
						Case "1"
							Dim addHeight As Single = CheckLineLength(DirectCast(Wc.curWord(i), ArrayList), Wc.optWord("Cmb_Font"), Pr）
							If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
								startYPos = addHeight
							Else
								startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (CSng(DirectCast(Wc.curWord(i), ArrayList).Count) -1)))　
							End If
							Call YPosCal(DirectCast(Wc.curWord(i), ArrayList), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
					End Select
				Next i
				'END: 以降の列のx軸位置を変更していく
				If (lineNo + MultiNum) - 1 <> Wc.curWord.Count - 1 Then
					Call ShiftXPos((lineNo + MultiNum) - 1, startNewXPos, Pr)
				End If
			Case 3	'TODO:ツーセンテンス上下
				
				Dim targetObj() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword")).Split(","c)
				Dim targetPoint() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint")).Split(","c)
				Dim targetObjPos() As String = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos")).Split(","c)
				
				Dim firstStr As String = ""
				Dim secondStr As String = ""
				Dim firstStrLen As Integer = 0
				Dim secondStrLen As Integer = 0
				Dim firstPoint As String = ""
				Dim secondPoint As String = ""
				
				Dim nextXPos As Single
				
				'上下文字・フォントの取り出し（長さ判定に必要）									'可 = 可変文字 不 = 不可変文字
				If targetObjPos(1) <> "9999" Then 											'可・可の場合
					firstStr = Wc.optWord(targetObj(0)).ToString()
					secondStr = Wc.optWord(targetObj(1)).ToString()
					firstStrLen = firstStr.Length
					secondStrLen = secondStr.Length
					firstPoint = Wc.optWord(targetPoint(0))
					secondPoint = Wc.optWord(targetPoint(1))
				ElseIf targetObjPos(0) = "9999" And targetObjPos(1) <> "9999"				'不・可の場合
					firstStr = DirectCast(DirectCast(Wc.mainTxt, ArrayList)(lineNo), Hashtable)("tbl_txt_txt").ToString
					secondStr = Wc.optWord(targetObj(1)).ToString()
					firstStrLen = firstStr.Length
					secondStrLen = secondStr.Length
					firstPoint = Wc.DefSet(2)
					secondPoint = Wc.optWord(targetPoint(1))
				ElseIf targetObjPos(0) = "0" And targetObjPos(1) = "9999"					'可・不の場合
					firstStr = Wc.optWord(targetObj(0)).ToString()
					secondStr = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").ToString()
					firstStrLen = firstStr.Length
					secondStrLen = secondStr.Length
					firstPoint = Wc.optWord(targetPoint(0))
					secondPoint = Wc.defset(2)
				End If
				
				'上文字フォントの挿入
				If firstStrLen <> 0 Then
					For i As Integer = 0 To firstStrLen - 1 Step 1
						DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(1) = firstPoint
					Next i
				Else
					DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(1) = firstPoint
					firstStrLen = 1	
				End If
				
				'下文字・フォントの挿入
				If secondStrLen <> 0 Then
					For i As Integer = firstStrLen To firstStrLen + secondStrLen - 1 Step 1
						DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(i), String())(1) = secondPoint
					Next i
				Else
					DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(firstStrLen), String())(1) = secondPoint
				End If
				
				'xyの位置を決める
				nextXPos = SetIrrXYPos(lineNo, _
										DirectCast(Wc.curWord(lineNo), ArrayList), _
										Wc.optWord("Cmb_Font"), _
										startYPos, _
										lastWordXPos, _
										Pr, _
										firstStr, _
										secondStr _	
									  )
				Call ShiftXPos(lineNo, nextXPos,Pr)
		End Select

#If debug Then
Catch ex As Exception
End Try
#End If 

	End Sub

#End Region

#Region "Position"

'''■ShiftXpos
''' <summary>フォントサイズを変更した時の残りの行のx軸位置を増えた分だけずらす</summary>
''' <param name="lineNo">Integer 変更のあった行</param>
''' <param name="startNewXPos">Single x軸位置の再開始位置</param>
''' <param name="Pr">PrintReport</param>
''' <returns>Void Wc.curWordに計算値を当て込んでいく</returns>
	Public Sub ShiftXPos(ByVal lineNo As Integer, ByVal startNewXPos As Single, ByVal Pr As PrintReport)
		Dim MaxWidth() As Single
		
		For i As Integer = lineNo + 1 To Wc.curWord.Count - 1 Step 1
			If DirectCast(DirectCast(Wc.curWord(i), ArrayList)(0), String())(0) <> "" Then						'END: イレギュラー行に対応する
				If FontSizeDifChecker(DirectCast(Wc.curWord(i), ArrayList)) = False Then
					
					Dim maxWord As Single = SetIrrXYPos(i, _
														DirectCast(Wc.curWord(i), ArrayList), _
														Wc.optWord("Cmb_Font"), _ 
														CheckNewYPos(CSng((DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newypos")))), _
														startNewXPos, _
														Pr
														)
					startNewXPos = maxWord + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newxpos")))
				Else
					MaxWidth = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(i), ArrayList), Pr)
					startNewXPos = startNewXPos - (MaxWidth(1) + CSng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newxpos")))
			
					For j As Integer = 0 To DirectCast(Wc.curWord(i), ArrayList).Count - 1 Step 1
						DirectCast(DirectCast(Wc.curWord(i), ArrayList)(j), String())(3) = startNewXPos.ToString()
					Next j
				End If
			Else'空白行の時ダミーデータを差し込む
				MaxWidth = Pr.FontSizeCal("", Wc.optWord("Cmb_Font").ToString(), CInt(DirectCast(DirectCast(Wc.curWord(i), ArrayList)(0), String())(1)))
				startNewXPos = startNewXPos - (MaxWidth(1) + CSng(Wc.DefSet(5)) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newxpos"))))
				DirectCast(DirectCast(Wc.curWord(i), ArrayList)(0), String())(3) = startNewXPos.ToString()
				
			End If
		Next i

	End Sub
	
'END: y軸の文字ピッチを文字の大小にかかわらず一定化させる
''' ■YPosCal
''' <summary>y軸方向の文字ピッチを再設定する（フォントサイズが全て同じ時）</summary>
'<param name="selector">Integer 0 = 全て文字が同じ、</param>
''' <param name="storageWord">ByRef ArrayList 文字配列（文字、フォントサイズ、文字の高さ、文字の幅）</param>
''' <param name="font">String フォント</param>
''' <param name="topYPos">Single y軸の開始位置</param>
''' <param name="pitch">Single 文字ピッチ</param>
''' <param name="pr">Form PrintReport</param>
''' <returns>Void, wordを参照する</returns>
Public Sub YPosCal(ByRef storageWord As ArrayList, ByVal font As String, _
				   ByVal topYPos As Single, ByVal pitch As Single, _
				   ByVal pr As PrintReport)
		
		Dim loopCounter As Integer = CInt(storageWord.Count)
		'2013/9/1 GetMaxWordでy軸も最大値を取るようにしたのでそれを使う
		Dim maxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), storageWord, pr)
		For i As Integer = 1 To loopCounter Step 1
			If i = 1 Then
				DirectCast(storageWord(i - 1), String())(2) = topYPos.ToString()
			Else
				DirectCast(storageWord(i - 1), String())(2) = CStr(CSng(DirectCast(storageWord(i - 2), String())(2)) + maxWord(0) + pitch)
			End If
		Next i

	End Sub
	
'END: 最後に確認する（引数変更の影響が非常に大きい）
'END: それぞれの文字のフォントサイズを考慮する
'END: フォントサイズの変更に伴いx軸の調整をする
'END: 大きさによってそれぞれの文字のX座標が変わる
'END: ピッチがビチビチの時も考慮
'''■SetIrrXYPos
''' <summary>フォントサイズが違う文字が混じった列の
''' 		1) それぞれのyPosを計算する
''' 		2) それぞれのxPosを計算する</summary>
''' <param name="lineNo">行番号</param>
''' <param name="word">文字配列</param>
''' <param name="font">フォント</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="pr">PrintReport.vb</param>
''' <param name="firstStr">Optional String Case 3用</param>
''' <param name="secondStr">Optional String Case 3用</param>
''' <returns>次の行のx軸スタート座標</returns>
	Public Function SetIrrXYPos(ByVal lineNo As Integer, _
								ByRef word As ArrayList, _
								ByVal font As String, _
								ByVal topYpos As Single, 
								ByVal lastXPos As Single, _
								ByVal Pr As PrintReport, _
								Optional ByVal firstStr As String = "", _
								Optional ByVal secondStr as string = "" _	
								) As Single
		'END: 文字が小さくなった時のx軸位置がおかしい -> フォーマットを忘れていたため 2013/9/7 mb
#If Debug then
Try
#End If
		Dim result As Single
		Dim yStyle As Integer = CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle"))
		'下の時のみ、スタート位置計算
		Select Case yStyle
			Case 0, 1, 2
				Dim properPit As Single = PitchCal(topYpos, _
													CSng(Wc.DefSet(4)), _
													word, _
													Wc.optWord("Cmb_Font"), _
													yStyle, _
													Pr _
												  )
				If yStyle = 1 Then
					Dim addHeight As Single = CheckLineLength(word, Wc.optWord("Cmb_Font"), Pr）
					addHeight = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (word.Count -1)))
					If addHeight <= topYpos Then														'y軸の最大値を超えないようにする
						topYpos = addHeight
					Else
						topYpos = CSng(Wc.DefSet(3))
					End If
				End If
				
				Dim eachXYSize(word.Count - 1) As single
				Dim xySizeList As New ArrayList		
				Dim tempMaxWord() As Single = Pr.FontSizeCal(DirectCast(word(0), String())(0), font, CInt(DirectCast(word(0), String())(1)))
				Dim lastTempMaxWord As Single
				Dim loopPos As Integer = 0
				Dim maxWord() As Single = {0, 0}
				
				'フォントサイズ毎にx軸の最大幅を取る・y軸位置を決定していく
				For i As Integer = 0 To CInt(word.Count - 1) Step 1
					eachXYSize = Pr.FontSizeCal(DirectCast(word(i), String())(0), font, CInt(DirectCast(word(i), String())(1)))
					
					If maxWord(1) < eachXYSize(1)  Then														'行内文字の最大サイズを取得
						maxWord(1) = eachXYSize(1)
					End If
					
					xySizeList.Add(eachXYSize)
					'同じフォントサイズグループ内で最大のフォントサイズを取っている（前後で比較）
					If i > 0 AndAlso (DirectCast(word(i - 1), String())(1) = DirectCast(word(i), String())(1)　And tempMaxWord(0) < eachXYSize(0)) Then
						tempMaxWord(0) =eachXYsize(0)
					End If
					
					If i > 0 AndAlso (DirectCast(word(i - 1), String())(1) = DirectCast(word(i), String())(1)　And tempMaxWord(1) < eachXYSize(1)) Then
						tempMaxWord(1) =eachXYsize(1)
					End If
					
					If i > 0 AndAlso DirectCast(word(i - 1), String())(1) <> DirectCast(word(i), String())(1) Then
						'y軸位置を決めていく
						For j As Integer = loopPos To i -1 Step 1
							If DirectCast(word(j), String())(0) = "" Then 	'CHK:NO.1 空の文字のときはy軸位置は0にして抜ける 2013/10/27 -> 修正 0ではダメ
								If j = 0
									'DirectCast(word(j), String())(2) = "0" 'END:TopYposに置き換え
									DirectCast(word(j), String())(2) = topYpos.ToString()
									Exit For
								Else												'CHK:NO.1 空の文字のときは前の文字の（修正）y軸位置の一番下の位置＋ピッチを入れておく
									'DirectCast(word(j), String())(2) = DirectCast(word(j - 1), String())(2)
									Dim tempEachXYsize() As Single = Pr.FontSizeCal(DirectCast(word(j - 1), String())(0), font, CInt(DirectCast(word(j - 1), String())(1)))
									DirectCast(word(j), String())(2) = CStr(tempEachXYsize(0) + CSng(DirectCast(word(j - 1), String())(2)) + properPit)
									Exit For
								End If
							Else
								If j = 0 Then
									DirectCast(word(j), String())(2) = topYpos.ToString()
								ElseIf j = loopPos Then
									'一つ前の文字のポジション + 文字の大きさ + ピッチ
									DirectCast(word(j), String())(2) = CStr(CSng(DirectCast(word(j - 1), String())(2)) + lastTempMaxWord + properPit)
									
									If  j  = (i - 1) Then	'一文字しかない時
										tempMaxWord = Pr.FontSizeCal(DirectCast(word(j), String())(0), font, CInt(DirectCast(word(j), String())(1)))  'add 2013/11/2
									End If
								Else
									DirectCast(word(j), String())(2) = CStr(CSng(DirectCast(word(j - 1), String())(2)) + tempMaxWord(0) + properPit)
								End If
								'x軸位置に入れる値を保存する
								DirectCast(xySizeList(j), Single())(1) = tempMaxWord(1)
							End If
						Next j
						lastTempMaxWord = tempMaxWord(0)
						
						tempMaxWord = {0, 0}
						loopPos = i
					End If
					'最終グループ
					If i = CInt(word.Count - 1) Then
						'前のグループが１文字しかない時 For i ループを回らずにここに入って終わるため
						If tempMaxWord(0) = 0 And tempMaxWord(1) = 0 Then
							tempMaxWord = Pr.FontSizeCal(DirectCast(word(i), String())(0), font, CInt(DirectCast(word(i), String())(1)))
						End If
						
						For j As Integer = loopPos To i Step 1
							'y軸位置を決めていく
							If DirectCast(word(j), String())(0) = "" Then 	'CHK:NO.1 空の文字のときはy軸位置は0にして抜ける 2013/10/27-> 修正 0ではダメ
								If j = 0
									'DirectCast(word(j), String())(2) = "0"　　'END:TopYposに置き換え
									DirectCast(word(j), String())(2) = topYpos.ToString()
									Exit For
								Else												'CHK:NO.1 空の文字のときは前の文字の（修正）y軸位置の一番下の位置＋ピッチを入れておく
									'DirectCast(word(j), String())(2) = DirectCast(word(j - 1), String())(2)
									Dim tempEachXYsize() As Single = Pr.FontSizeCal(DirectCast(word(j - 1), String())(0), font, CInt(DirectCast(word(j - 1), String())(1)))
									DirectCast(word(j), String())(2) = CStr(tempEachXYsize(0) + CSng(DirectCast(word(j - 1), String())(2)) + properPit)
								End If
							else
								If j = loopPos Then
									'END: 最後 = ３連のところ 儀大きく　故父消す　故父フォント増やすおかしい
									'END: 最後 = ３連のところ 儀大きく　故父消す　故父フォント増やす ->　一文字選択　おかしい
									'END:エラー発生 = 文字を変えない　→　フォントサイズを変える →　文字を消す
									DirectCast(word(j), String())(2) = CStr(CSng(DirectCast(word(j - 1), String())(2)) + lastTempMaxWord + properPit)
								Else
									DirectCast(word(j), String())(2) = CStr(CSng(DirectCast(word(j - 1), String())(2)) + tempMaxWord(0) + properPit)
								End If
							End If
							
							DirectCast(xySizeList(j), Single())(1) = tempMaxWord(1)
							
						Next j
					End If
				Next i
				
				'x軸位置の設定
				Call SetIrrXPos(lineNo, word, xySizeList, maxWord, lastXPos)
				
				result = lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))
				Return result
			Case 3
				'CHK: ツーセンテンス上下（フォントサイズ違い）を入れる
				Dim properPit As Single
				Dim maxWord() As Single = {0, 0}
				Dim xSizeDetail(1) As Single
				Dim xSizeList As New ArrayList
				Dim firstStrEndPos As Single
				Dim tempXsize As New ArrayList
				'★y軸設定
				If firstStr <> "" Then
					maxWord = GetMaxWord(Wc.optWord("Cmb_Font"), word, Pr, ,1, firstStr.Length)
					
					For i As Integer = 0 To firstStr.Length - 1 Step 1
						DirectCast(word(i), String())(2) = topYpos.ToString()
						topYpos = topYpos + maxWord(0) + CSng(Wc.DefSet(6))									'上文字はピッチ調整をしない
						
						xSizeDetail(1) = maxWord(1)
						xSizeList.Add(xSizeDetail)
						xSizeDetail = {0, 0}
					Next i
					
					firstStrEndPos = topYpos + maxWord(0)													'上文字の一番下の位置（下文字との境界）
					
					'END: 下の文字位置を代入
					If secondStr <> "" Then																	'1) 上下ともあり
						'下文字のみのArrayListを判定用に作る
						Dim tempWordDetal(1) As String
						Dim tempWordInLine As New ArrayList
						Dim j As Integer = 0
						For i As Integer = firstStr.Length To (firstStr.Length + secondStr.Length) -1  Step 1	
							tempWordDetal(0) = secondStr.Substring(j, 1)
							tempWordDetal(1) = DirectCast(word(i), String())(1)
							tempWordInLine.Add(tempWordDetal)
							tempWordDetal = {"", ""}
							j = j + 1
						Next i
						properPit = PitchCal(topYpos, _
											 CSng(Wc.DefSet(4)), _
											 tempWordInLine, _
											 Wc.optWord("Cmb_Font"), _
											 1, _
											 Pr _
											)
						'下文字の長さを計算
						maxWord = GetMaxWord(Wc.optWord("Cmb_Font"), tempWordInLine, Pr)
						Dim secondStrPos = CSng(Wc.DefSet(4)) - (maxWord(0) * CSng(secondStr.Length))
						If secondStr.Length > 1 Then
							secondStrPos = secondStrPos - (properPit * (CSng(secondStr.Length) - 1))
						End If
						'上の文字列サイズを超えていたらピッチの取り直し
						If secondStrPos <= topYpos Then
							properPit = 0
							properPit = PitchCal(topYpos, _
												 CSng(Wc.DefSet(4)), _
												 tempwordInLine, _
												 Wc.optWord("Cmb_Font"), _
												 2, _
												 Pr _
												)
							tempWordInLine = Nothing
							For i As Integer = firstStr.Length To (firstStr.Length + secondStr.Length) - 1 Step 1
								DirectCast(word(i), String())(2) = topYpos.ToString()
								xSizeDetail(1) = maxWord(1)
								xSizeList.Add(xSizeDetail)
								xSizeDetail = {0, 0}
								topYpos = topYpos + maxWord(0) + properPit
							Next i
						Else　　'OK、取り直し無し
							topYpos = secondStrPos
							For i As Integer = firstStr.Length To (firstStr.Length + secondStr.Length) - 1 Step 1
								DirectCast(word(i), String())(2) = topYpos.ToString()
								xSizeDetail(1) = maxWord(1)
								xSizeList.Add(xSizeDetail)
								xSizeDetail = {0, 0}
								topYpos = topYpos + (maxWord(0) + properPit)
							Next i
						End If
					Else																					'CHK: 2) 上あり、下なし
						maxWord = Pr.FontSizeCal(DirectCast(word(firstStr.Length), String())(0).ToString(), Wc.optWord("Cmb_Font"), CInt(DirectCast(word(firstStr.Length), String())(1)))
						DirectCast(word(firstStr.Length), String())(2) = CStr(CSng(Wc.DefSet(4)) - maxWord(0))
						xSizeList.Add(maxWord)
					End If
				Else　																						'CHK: 3) 上なし、下あり
					If secondStr <> "" Then
						'上のサイズ
						DirectCast(word(0), String())(2) = topYpos.ToString()
						maxWord = Pr.FontSizeCal("", Wc.optWord("Cmb_Font"), CInt(DirectCast(word(0), String())(1)))
						xSizeDetail(1) = maxWord(1)
						xSizeList.Add(xSizeDetail)
						maxWord = {0, 0}
						xSizeDetail = {0, 0}
						
						'下のサイズ
						maxWord = GetMaxWord(Wc.optWord("Cmb_Font"), word, Pr, , 2, 1 + secondStr.Length)
						
						Dim secondStrPos = CSng(Wc.DefSet(4)) - ((maxWord(0) * CSng(secondStr.Length)))
						If secondStr.Length > 1 Then
							secondStrPos = secondStrPos - (properPit * (CSng(secondStr.Length)) - 1)
						End If
						
						If secondStrPos < topYpos Then
							secondStrPos = topYpos
						End If
						
						Dim tempWordDetal(1) As String
						Dim tempWordInLine As New ArrayList
						'For i As Integer = 1 To secondStr.Length - 1 Step 1	
						For i As Integer = 0 To secondStr.Length - 1 Step 1
							tempWordDetal(0) = secondStr.Substring(i, 1)
							tempWordDetal(1) = DirectCast(word(i), String())(1)
							tempWordInLine.Add(tempWordDetal)
							tempWordDetal = {"", ""}
						Next i
						properPit = PitchCal(secondStrPos, _
											CSng(Wc.DefSet(4)), _
											tempWordInLine, _
											Wc.optWord("Cmb_Font"), _
											1, _
											Pr _
											)
						For i As Integer = 1 To secondStr.Length Step 1
							DirectCast(word(i), String())(2) = secondStrPos.ToString()
							xSizeDetail(1) = maxWord(1)
							xSizeList.Add(xSizeDetail)
							xSizeDetail = {0, 0}
							maxWord = {0, 0}
							secondStrPos = secondStrPos + maxWord(0) + properPit
						Next i
					Else																					'CHK: 4) 上なし、下なし
						maxWord = Pr.FontSizeCal("", Wc.optWord("Cmb_Font"), CInt(DirectCast(word(0), String())(1)))
						DirectCast(word(0), String())(2) = CStr(topYpos + maxWord(0))
						xSizeDetail(1) = maxWord(1)
						xSizeList.Add(xSizeDetail)
						xSizeDetail = {0, 0}

						Dim tempMaxWord() As Single
						tempMaxWord = Pr.FontSizeCal("", Wc.optWord("Cmb_Font"), CInt(DirectCast(word(1), String())(1)))
						DirectCast(word(1), String())(2) = CStr(CSng(Wc.DefSet(4)) - maxWord(0))
						xSizeDetail(1) = maxWord(1)
						xSizeList.Add(xSizeDetail)
						
						maxWord(1) = Math.Max(maxWord(1), tempMaxWord(1))
'						
'						Call SetIrrXPos(lineNo, word, xSizeList, maxWord, lastXPos)
'						result = lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))
'						
'						Exit Sub
					End If
				End If
				'x軸設定
				If firstStr <> "" Or secondStr <> "" Then
					maxWord = GetMaxWord(Wc.optWord("Cmb_Font"), word, Pr)
				End If
				
				Call SetIrrXPos(lineNo, word, xSizeList, maxWord, lastXPos)
				result = lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))
				
				Return result
				
		End Select
#If Debug then
Catch ex As Exception
		Return Nothing	
End Try
#End If
		Return Nothing

	End Function
	
	'TODO: 要修正 手順 亡父FontSize -> 追伸空のところ入れる 位置がおかしい　追伸が空の状態で他のフォントサイズをいじるとおかしくなる
	
'''■SetIrrXPos
''' <summary>SetIrrXYPosの補助関数</summary>
''' <param name="lineNo">Integer 行番号</param>
''' <param name="word"></param>
''' <param name="xySizeList"></param>
''' <param name="maxWord"></param>
''' <param name="lastXpos"></param>
	Private Sub SetIrrXPos(ByVal lineNo As Integer, ByRef word As ArrayList, ByVal xySizeList As ArrayList, ByVal maxWord() As Single, ByVal lastXpos As Single)
		
#If Debug then
Try
#End If

		For i As Integer = 0 To CInt(word.Count -1) Step 1								'END: x軸は右から左へマイナス
			If lineNo <> 0 Then
				If DirectCast(xySizeList(i), Single())(1) < maxWord(1) Then
					DirectCast(word(i), String())(3) = CStr((lastXpos - (CSng(Wc.DefSet(5)) + maxWord(1))) _
															 + ((maxWord(1) - DirectCast(xySizeList(i), Single())(1)) / 2))
				Else
					DirectCast(word(i), String())(3) = CStr(lastXpos - (CSng(Wc.DefSet(5)) + maxWord(1)))
				End If
			Else
				If DirectCast(xySizeList(i), Single())(1) < maxWord(1) Then
					DirectCast(word(i), String())(3) = CStr((lastXpos -  maxWord(1)) _
															 + ((maxWord(1) - DirectCast(xySizeList(i), Single())(1)) / 2))
				Else
					DirectCast(word(i), String())(3) = CStr(lastXpos - maxWord(1))
				End If
			End If
		Next i	
		
#If Debug then
Catch ex As Exception
End Try
#End If
		
	End Sub
	
#End Region 

#Region "Pitch"

''' ■CheckLineLength
''' <summary>1行の文字を並べた時の長さを測る(文字間のスペースは除く）</summary>
''' <param name="storageWord">ArrayList 文字配列</param>
''' <param name="font">String フォント</param>
''' <param name="Pr">PrintReport</param>
''' <returns>文字の長さを返す</returns>
Public Function CheckLineLength(ByVal storageWord As ArrayList, ByVal font As String, ByVal Pr As PrintReport) As Single
		
		Dim addHeight As Single = 0
		For i As Integer = 0 To storageWord.Count - 1 Step 1
			Dim tempHeight() As Single = Pr.FontSizeCal(DirectCast(storageWord(i), String())(0), Wc.optWord("Cmb_Font"), CInt(DirectCast(storageWord(i), String())(1)))
				addHeight = addHeight + tempHeight(0)
		Next i
		Return addHeight
	
	End Function

'END:　改行ピッチ関数 
''''■CheckNewXPos
''' <summary>改行ピッチの変更があるかどうか確認</summary>
''' <param name="newPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列の改行ピッチが違うかどうかの判定に使用</remarks>
	Public Function CheckNewXPos(ByVal newXpos As Single) As Single
		Dim resultPos As Single = 0
		If newXpos <> 9999 Then
			resultPos = newXpos
			Return resultPos
		End If
			Return 0
	End Function
	
'END:　改行ピッチ関数
''''■CheckNewYPos
''' <summary>Y軸の開始位置の変更があるかどうか確認</summary>
''' <param name="newXPos"> Single ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列のy軸スタート位置が違うかどうかの判定に使用</remarks>
	Public Function CheckNewYPos(ByVal newYpos As Single) As Single
		Dim resultPos As Single = 0
		If newYpos <> 9999 Then
			resultPos = CSng(Wc.DefSet(3)) + newYpos
			Return resultPos
		End If
			Return CSng(Wc.DefSet(3))
	End Function	
	
''''■PitchCal
''' <summary>ピッチを計算</summary>
''' <param name="topYPos">Single 開始位置（位置変更される時があるので必要）</param>
''' <param name="bottomYPos">Single 修了位置</param>
''' <param name="storageWord">ArrayList 単語・フォントサイズ・x・y軸位置の配列</param>
''' <param name="font">String フォント</param>		<- 追加　2013/06/23
''' <param name="yStyle">Integer 上・下・天地揃え</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
	Public Function PitchCal(ByVal topYPos As Single, ByVal bottomYPos As Single, _
							 ByVal storageWord As ArrayList, ByVal font As String, _
							 ByVal yStyle As Integer, ByVal pr As PrintReport) As Single
		'TODO:計算範囲を可変にする
		Dim resultPitch As Single = 0
		Dim arCounter As Single = storageWord.Count
		Dim firstWord(1) As Single
		Dim lastWord(1) As Single
	
		'文字の長さの取得(最初と最後は決まっている為）
		Dim wordLength() As Single = {0, 0}
		Dim wordHeight As Single = 0
		Dim j As Integer = 0
		For i As Integer = 0 To CInt(arCounter) - 1 Step 1
			Select Case i
			    Case 0
			    	firstWord = pr.FontSizeCal(DirectCast(storageWord(i), String())(0), font, CInt(DirectCast(storageWord(i), String())(1)))
			    	firstWord(0) = firstWord(0)
			    Case CInt(arCounter) - 1
			    	lastWord = pr.FontSizeCal(DirectCast(storageWord(i), String())(0), font, CInt(DirectCast(storageWord(i), String())(1)))
			    Case Else
			    	wordLength = pr.FontSizeCal(DirectCast(storageWord(i), String())(0), font, CInt(DirectCast(storageWord(i), String())(1)))
			    	wordHeight = wordHeight + wordLength(0)
			End Select
			
			j = j + 1
			
		Next i
		'最後の文字の位置を決める
		Dim lastWordPos As Single = bottomYPos - lastWord(0)

		'文字収納範囲
		'Dim wordArea As Single = lastWordPos - firstWord(0)						'2013/8/24 rep mb
		Dim wordArea As Single = lastWordPos  - (topYPos + firstWord(0))
		'文字の長さと収納範囲を検証
		If (wordArea - (wordHeight)) > 0 Then										'ピッチを取れる余裕がある時
			Select Case yStyle
				Case 0
					'Return Wc.DefSet(5)
					Return CSng(Wc.DefSet(6))
				Case 1
					'Return Wc.DefSet(5)
					Return CSng(Wc.DefSet(6))
				Case 2
					resultPitch = (wordArea - wordHeight) / (arCounter - 1)
					Return resultPitch
				Case Else
					Return CSng(Wc.DefSet(6))
			End Select
		Else																		'余裕がない時（ビチビチの時　マイナスの値でピッチ幅を減らす）
			resultPitch = (System.Math.Abs(wordArea - wordHeight) / (arCounter - 1)) * -1
			Return resultPitch
		End If

	End Function

#End Region

#Region "FontSize"

'END: 文字と文字サイズがばらばらの時を考える（入れ物）
''' ■GetMaxWord
''' <summary>1行内にある文字の最大幅を返す</summary>
''' <param name="font">String フォント</param>
''' <param name="word">ArrayList 文字情報配列</param>
''' <param name= "Pr">PrintReport.vb</param>
''' <param name="wordNum">Optional ByRef Integer 最大幅の字がある文字番号</param>			'2013/9/1 add mb
''' <param name="startPos">Optional Integer 文字開始位置　デフォルト 1</param>				'2013/11/3 add
'''<param name="end Pos">Optional Integer 文字修了位置　デフォルト word.Count</param>		'2013/11/3 add
''' <returns>1行内にある文字の最大幅を返す y = 0 x = 1</returns> 
	Public Function GetMaxWord(ByVal font As String, _
							   ByVal word As arraylist, _
							   ByVal Pr As PrintReport, _
							   Optional ByRef wordNum As Integer = 0, _
							   Optional ByVal startPos As Integer = 1, _
							   Optional ByVal endPos As Integer = 0 _
							   ) As Single()
		'END:y軸の最大値は今のところ必要ないので未実装 2013/7/27 mb -> 2013/9/1 y軸も使いたいのでテストする
		Dim wordSize() As Single = {0s, 0s}	
		
		If endPos = 0 Then
			endPos = word.Count
		End If
				
		For i As Integer = startPos - 1 To endPos - 1 Step 1
			Dim tempWordSize() As Single = Pr.FontSizeCal(DirectCast(word(i), String())(0), font, CInt(DirectCast(word(i), String())(1)))
			If wordSize(1) < tempWordSize(1) Then
				wordSize(1) = tempWordSize(1)
				wordNum = i
			End If
		
			If wordSize(0) < tempWordSize(0) Then
				wordSize(0) = tempWordSize(0)
			End If
		Next i
	
		Return wordSize
	
	End Function

'''■BasicPointChecker
''' <summary>列単位のフォントサイズの変更を確認</summary>
''' <param name="mainTxt">ArrayList DB内の登録データ</param>
''' <returns>変更が無い時は0を返す、ある時は登録されたフォントサイズを返す</returns>
''' <remarks>列が変わった時に次の列内のフォントサイズが違うかどうかの判定に使用</remarks>
	Public Function BasicPointChecker(ByVal mainTxt As Hashtable) As String
		Dim resultStr As String
		If mainTxt("tbl_txt_newpoint").ToString() <> "9999" Then
			resultStr = mainTxt("tbl_txt_newpoint").ToString()
			Return resultStr
		End If
		
		Return "0"
		
	End Function
	
'''■FontSizeDifChecker
''' <summary>異なったフォントサイズがあるか確かめる</summary>
''' <param name="word">ArrayList 文字+フォント配列のArrayList</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function FontSizeDifChecker(ByVal word As ArrayList) As Boolean
		Dim tempFontSize As String = DirectCast(word(0), String())(1)
		For i As Integer = 0 To word.Count -1 Step 1
			If tempFontSize <> DirectCast(word(i), String())(1) Then
				Return False
			End If
		Next i
	
		Return True
	
	End Function

#End Region

End Class

