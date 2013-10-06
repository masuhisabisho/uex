'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Diagnostics.Debug		'開発用

Public Class Common
	'END: また文字無しにした時にエラーが出るのが再発している
	Private Wc As WordContainer
	Private Const objCnt As Integer = 3		'挿入Objの最大数
	
	Public sub new (wordCont As WordContainer)
		Wc = wordCont
	End Sub
	
	
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
		Dim insWord As Array
		Dim storageWord As New ArrayList
		Dim registerChkFlg As Boolean = False
		'Dim basicPoint As String = fontSize
		
		For i As Integer = 0 To lineCounter Step 1
			Dim insPos() As String = {"", "", ""}									'挿入文字位置パラメータを格納する配列 
			Dim insFlg As Boolean = False											'挿入文字フラグ
			
			If mainTxt(i)("tbl_txt_inspos") <> "" Then							'END: 挿入文字があるか確認する	
				insPos = CStr(mainTxt(i)("tbl_txt_inspos")).Split(","c)				'文字数 = 0、フォントサイズ = 1, 挿入行番号 = 2, 挿入位置 = 3 文字（任意の数）= 4～ を獲得する ↓
				insWord = CheckInsWord(mainTxt(i)("tbl_txt_inspos"), _
										mainTxt(i)("tbl_txt_targetword"), _
										mainTxt(i)("tbl_txt_targetpoint"), _
										i _
										)											'フォントサイズ = 0, 挿入位置 = 1 文字（任意の数）= 2～ を獲得するに変更 2013/8/4 mb
				insFlg = True
			End If
			
			Dim loopCounter As Integer = CInt(CStr(mainTxt(i)("tbl_txt_txt")).Length)

			If insFlg = True Then													'挿入フラグが立っている時、挿入文字分をループカウンターに加算
				For j As Integer = 0 To 2 Step 1
					If insPos(j) <> "9999" Then
						loopCounter = loopCounter + CInt(insWord(j).Length - 2)
					End If
				Next j
			End If
			
			Dim wordInLine As New ArrayList
			Dim fixedWord As String = CStr(mainTxt(i)("tbl_txt_txt"))
			Dim k As Integer = 0													'挿入文字用カウンター（挿入がある時）
			Dim m As Integer = 0													'通常文字用カウンター（挿入がある時）
			Dim wordDetail() As String = {"", "", "", ""}

			For j As Integer = 0 To loopCounter - 1 Step 1
				If insFlg = True  Then												'挿入がある時は挿入文字を差し込んでいく
					If IsArray(insWord(k)) = True AndAlso Val(insWord(k)(1)) = j
						For l As Integer = 2 To CInt(insWord(k).Length -1)
							wordDetail(0) = insWord(k)(l)
							wordDetail(1) = insWord(k)(0)
							wordInLine.Add(wordDetail)
							wordDetail = {"", "", "", ""}
							registerChkFlg  = True

							j = j + 1
						Next l
						j = j -1 													'カウンターを１つ戻す（最後の文字ので余分に増える為）
						k = k + 1
						Continue For
					Else
						wordDetail(0) = fixedWord.Substring(m, 1)					'固定文字を格納
																						
						Dim tempBasipoint As String = BasicPointChecker(mainTxt(i))
						If  tempBasipoint <> "0" Then
							wordDetail(1) = tempBasipoint
						Else
							wordDetail(1) = Wc.DefSet(1)
						End If
						
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}
						registerChkFlg  = True
						
						m = m + 1
					End If
				Else
					wordDetail(0) = fixedWord.Substring(m, 1)
					
					Dim tempBasipoint As String = BasicPointChecker(mainTxt(i))
					If  tempBasipoint <> "0" Then
						wordDetail(1) = tempBasipoint
					Else
						wordDetail(1) = Wc.DefSet(1)
					End If
					
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
					registerChkFlg  = True
					
					m = m + 1
				End If
			Next j
			If registerChkFlg  = False Then
				wordDetail(1) = insWord(0)(0)
				wordInLine.Add(wordDetail)
				wordDetail = {"", "", "", ""}
			End If
			
			storageWord.Add(wordInLine)
			
			registerChkFlg  = False
			insFlg = False
		Next i
		
'#If debug then
'		'2013/8/20 不具合発生。再度確認
'		Dim z As Integer = 0
'		Do Until z = storageWord.Count
'			Dim q As Integer = 0
'			WriteLine(z & "行目")
'			Do Until q = storageWord(z).Count
'				Write(storageWord(z)(q)(0) & "★")
'				Write(storageWord(z)(q)(1) & "★")
'				Write(storageWord(z)(q)(2) & "★")
'				Writeline(storageWord(z)(q)(3))
'				q += 1
'			Loop
'			WriteLine("")
'			z += 1
'		Loop
'#End If
		
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
									storageWord(i)(j)(3) = startXPos
									startYPos = startYPos + (fontSize(0) + properPit)
								Next j
							Else														'文字無し
								Dim fontSize() As Single = Pr.FontSizeCal("口", CStr(Wc.optWord("Cmb_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + FontSize(1))
									
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.curWord = wordInLine
								wordDetail = {"", "", "", ""}
								Continue For
							End If
							
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Cmb_Font"))
						Else	
							'END: ★★フォントサイズが違う時★★ 2013/7/2
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord)
#End If
						End If
					Case 1	'下
						If FontSizeDifChecker(storageWord(i)) = True Then						'★★全て同じフォントサイズの時★★
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXPos <> 0 Then
								startXPos = startXPos + newXPos
							End If
							
							Dim fontSize() As Single
							If storageWord(i)(0)(0) <> "" Then							'文字あり
								fontSize = GetMaxWord(Wc.optWord("Cmb_Font"),storageWord(i), Pr)
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
									storageWord(i)(j)(3) = startXPos
								Next j
							Else														'文字なし
								fontSize = Pr.FontSizeCal("口", CStr(Wc.optWord("Cmb_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + FontSize(1))
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.curWord = wordInLine
								wordDetail = {"", "", "", ""}
								Continue For
							End If 'END: 2013/7/9　下配置修正
							
							startYPos= CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))

							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																storageWord(i), _
																Wc.optWord("Cmb_Font"), _
																0, _
																Pr _
																)
							'2013/9/1 GetMaxWordでy軸も最大値を取るようにしたのでそれを使う
							Dim addHeight As Single = fontSize(0) * CSng(storageWord(i).Count)
							startYPos = CSng(Wc.DefSet(4)) - addHeight
							If storageWord.Count <> 1 Then
								startYPos = startYPos + (properPit * (CSng(storageWord(i).Count) - 1))
							End If
							
							If startYPos <= CSng(Wc.DefSet(3)) Then						'2013/8/25 add 3 lines mb
								startYPos = CSng(Wc.DefSet(3))
							End If
							Call YPosCal(storageWord(i), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Cmb_Font"))
						Else
							'★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord)
#End If
						End If
					Case 2	'天地
						'END: 天地の場合の文字ピッチを計算
						'END: pointDiffCheckerをつける
						If FontSizeDifChecker(storageWord(i)) = True Then							'★★全て同じフォントサイズの時★★
							startYPos= CheckNewYPos(CSng(mainTxt(i)("tbl_txt_newypos")))
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																storageWord(i), _
																Wc.optWord("Cmb_Font"), _
																2, _
																Pr _
																)
						
							Dim newXPos As Single = CheckNewXPos(CSng(mainTxt(i)("tbl_txt_newxpos")))
							If newXPos <> 0 Then  
								startXPos = startXPos + newXPos									'x軸イレギュラースタートの確認
							End If	
							
							If storageWord(i)(0)(0) <> "" Then							'文字あり
								Dim fontSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"),storageWord(i), Pr)
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								For j As Integer = 0 To CInt(storageWord(i).Count) - 1 step 1
									storageWord(i)(j)(2) = startYPos
									storageWord(i)(j)(3) = startXPos
									startYPos = startYPos + (fontSize(0) + properPit)
								Next j
							Else
								Dim fontSize() As Single = Pr.FontSizeCal("口", CStr(Wc.optWord("Cmb_Font")), storageWord(i)(0)(1))
								startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1))
								
								Dim wordDetail(3) As String								'2013/8/19 add 9 lines mb
								Dim wordInLine As New ArrayList
								wordDetail(0) = storageWord(i)(0)(0)
								wordDetail(1) = storageWord(i)(0)(1)
								wordDetail(2) = startYPos
								wordDetail(3) = startXPos
								wordInLine.Add(wordDetail)
								Wc.curWord = wordInLine
								wordDetail = {"", "", "", ""}
								Continue For
							End If
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Cmb_Font"))
						Else															'フォントサイズが異なる
							'TODO: ★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord)
#End If
						End If	
					Case 3		'ツーセンテンス上下
						If FontSizeDifChecker(DirectCast(storageWord(i), ArrayList)) = True Then							'★★全て同じフォントサイズの時★★#If Debug then
#If Debug then
						Try
#End If
							Dim fontSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), storageWord(i), Pr)
							Dim targetObj() As String = CStr(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_targetword")).Split(",")
							Dim totalWordLength As Single = 0
	
							startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(i), Hashtable)("tbl_txt_newypos")))
							startXPos = startXPos - (CSng(Wc.DefSet(5)) + fontSize(1)) + CheckNewXPos(CSng(Directcast(mainTxt(i), Hashtable)("tbl_txt_newxpos")))
							
							Dim properPit As Single = PitchCal(startYPos, _
																CSng(Wc.DefSet(4)), _
																storageWord(i), _
																Wc.optWord("Cmb_Font"), _
																0, _
																Pr _
																)

							For j As Integer = 0 To Cstr(Wc.optWord(targetObj(0))).Length - 1 Step 1
								storageWord(i)(j)(2) = startYPos
								storageWord(i)(j)(3) = startXPos
								startYPos = startYPos + fontSize(0) + properPit
								totalWordLength = totalWordLength + fontSize(0)
							Next j
							
							'TODO: 下の文字位置設定
							If Wc.optWord(targetObj(1)) <> "" Then
								properPit = PitchCal(startYPos, _
														Wc.DefSet(4), _
														DirectCast(storageWord(i), ArrayList), _
														Wc.optWord("Cmb_Font"), _
														1, _
														Pr _
													)
								startYPos = CSng(Wc.DefSet(4)) _
											- (fontSize(0) * CSng(DirectCast(storageWord(i), ArrayList).Count)) _
											+ (properPit * (CSng(DirectCast(storageWord(i), ArrayList).Count)) - 1)
							
								If startYPos <= totalWordLength Then
									startYPos = totalWordLength
									properPit = 0
									properPit = PitchCal(startYPos, _
															Wc.DefSet(4), _
															storageWord(i), _
															Wc.optWord("Cmb_Font"), _
															2, _
															Pr _
														)
								End If
								
								For j As Integer = CStr(Wc.optWord(targetObj(0))).Length To _
									(Cstr(Wc.optWord(targetObj(0))).Length + Cstr(Wc.optWord(targetObj(1))).Length) -1 Step 1
									storageWord(i)(j)(2) = startYPos
									startYPos = startYPos + fontSize(0) + properPit
								Next j
								
							End If
							Call Pr.CreateWord(storageWord(i), Wc.optWord("Cmb_Font"))
#If Debug then
							Catch ex As Exception
							End Try
#End If
						Else															'フォントサイズが異なる
							'TODO: ★★フォントサイズが違う時★★
							'現状使用するパターンがない -> あるとエラーに
#If debug Then
							Call CheckErrSentence(storageWord)
#End If
						End If	
					End Select

					startYPos = 0

				Next i
		Else
		'TODO: 横書きの時
		End If


	End Sub
	
'開発用文字配列出力関数
	Private Sub	CheckErrSentence(storageWord As ArrayList)
		MessageBox.Show("フォントサイズ違い")
		Dim outputStr As String = ""
		Dim z As Integer = 0
		
		Do Until z = storageWord.Count
			Dim q As Integer = 0
			outputStr &= z & "行目" & vbCrLf
			Do Until q = storageWord(z).Count
				outputStr &= storageWord(z)(q)(0) & "★"
				outputStr &= storageWord(z)(q)(1) & "★"
				outputStr &= storageWord(z)(q)(2) & "★"
				outputStr &= storageWord(z)(q)(3) & vbCrLf
				q += 1
			Loop
			outputStr &= vbCrLf
			q = 0
			z += 1
		Loop
		Dim sw As System.IO.StreamWriter = Nothing
		Try
			sw = New System.IO.StreamWriter("C:\Users\madman190382\Desktop\FontSizeDiffLog.txt", _
				False,
				System.Text.Encoding.GetEncoding("UTF8")
				)
			sw.WriteLine(outputStr)
		Catch e As Exception
			MessageBox.Show("フォントサイズ違いログの保存に失敗しました")
		Finally
			If sw IsNot Nothing Then
				sw.Close()
				sw.Dispose()
			End If
		End Try

	End Sub

'データを置き換える
''' ■WordReplacer
''' <summary>コンボ変更に対して文字挿入、y軸位置、x軸位置を決める</summary>
''' <param name="lineNo">Integer 行番号</param>
''' <param name="pr">Frm PrintReport.vb</param>
''' <param name="yStyle">Integer 上、下、天地</param>
''' <param name="newTargetCmb">Optional ComboBox 動かされるコンボ（Optionalどちらかを指定する）</param>
''' <param name="newTargetTxt">Optional Textbox 変更するテキストボックス</param>
''' <returns>Void CurWordの内容を変更する</returns>
	Public Sub WordReplacer(lineNo As Integer, Pr As PrintReport, yStyle As Integer, _
					Optional newTargetCmb As ComboBox = Nothing, _
					Optional newTargetTxt As TextBox = Nothing,)
#If Debug Then
	Try
#End if
'		Dim Ar As New ArrayList(New String() {"Apple", "Banana", "Cat", "Dog"})
'		Ar.Insert(2, "aho")
'		Ar.RemoveRange(2, 2)

		'再描画行の文字データを取得
'		Dim mainTxt As New Hashtable
'		以下３行out 2013/9/29
'		Dim SctSql As New SelectSql()
'		mainTxt = SctSql.GetTbl_TxtRow(Wc.CurrentSet("curSize"), Wc.CurrentSet("curStyle"), lineNo)
'		SctSql = Nothing
		
		'フォントサイズが全て同じかどうか確認する
		Dim fontSizeDif As Boolean
		If DirectCast(DirectCast(Wc.curWord(lineNo), ArrayList)(0), String())(0) <> "" Then
			fontSizeDif = FontSizeDifChecker(DirectCast(Wc.curWord(lineNo), ArrayList))
		Else
			fontSizeDif = True
		End If
			
		If fontSizeDif = True then											'★★全て同じの時★★
			'コンボの値を置き換え
			If newTargetCmb IsNot Nothing Then
				If newTargetCmb IsNot Pr.Cmb_Year And newTargetCmb IsNot Pr.Cmb_Month And newTargetCmb IsNot Pr.Cmb_day Then
					Wc.optWord(newTargetCmb.Name) = newTargetCmb.SelectedValue
				End If
			End If
			'テキストボックスの値を置き換え
			If newTargetTxt IsNot Nothing Then
				Wc.optWord(newTargetTxt.Name) = newTargetTxt.Text
			End if
			'ArrayListの値を移しておく
			Dim tempWord As New Hashtable
			tempWord("fontSize") = Wc.curWord(lineNo)(0)(1)					'フォントサイズ
			tempWord("xPos") = Wc.curWord(lineNo)(0)(3)						'x軸位置
			'curWordの任意の行のデータを削除しておく
			Wc.curWord(lineNo).Clear
			'挿入位置を取得
			Dim insPos() As String
			insPos = CStr(Wc.mainTxt(lineNo)("tbl_txt_inspos")).Split(","c)
			'挿入文字配列を取得
			Dim insWord As array
			insWord = CheckInsWord(Wc.mainTxt(lineNo)("tbl_txt_inspos"), _
    	                           Wc.mainTxt(lineNo)("tbl_txt_targetword"), _
    	                           Wc.mainTxt(lineNo)("tbl_txt_targetpoint"), _
    	                           lineNo _
    	                           )
			
			Dim loopCounter As Integer = CInt(CStr(Wc.mainTxt(lineNo)("tbl_txt_txt")).Length)
			'挿入文字の字数をループカウンター（不変文字数）に加算する
			For i As Integer = 0 To 2 Step 1
				If CInt(insPos(i)) <> 9999 Then
					loopCounter = loopCounter + CInt(insWord(i).Length -2)	
				End If
			Next i 
			'不変文字と挿入文字を一つの配列に格納していく
			Dim wordInLine As New ArrayList()
			Dim wordDetail(3) As String
			Dim k As Integer = 0
			Dim l As Integer = 0
			
			For i As Integer = 0 To loopCounter - 1 Step 1					'END エラーをかわす（insWordに配列が1つしかなく文の先頭にある時など）WordPreparerも
				If IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(1)) = i Then
					For j As Integer = 2 To CInt(insWord(k).Length - 1) Step 1
						wordDetail(0) = insWord(k)(j)
						wordDetail(1) = tempWord("fontSize")
						wordDetail(3) = tempWord("xPos")					'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}						'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				Else
					wordDetail(0) = CStr(Wc.mainTxt(lineNo)("tbl_txt_txt")).Substring(l, 1)
					wordDetail(1) = tempWord("fontSize")
					wordDetail(3) = tempWord("xPos")
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					l = l + 1
				End If
			Next i
			If loopCounter = 0 Then		'文字無し対策　2013/9/8 add 7 lines mb
				wordDetail(0) = ""
				wordDetail(1) = tempWord("fontSize")
				wordDetail(3) = tempWord("xPos")					'フォントサイズが同じ為、文字が増えてもx軸位置は不変 -> そのまま使用する
				wordInLine.Add(wordDetail)
				wordDetail = {"", "", "", ""}						'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
			End If
				'END: y軸位置は後で決める
				'END: 適正なピッチを取る
				'END: 適正なピッチを使ってy軸位置を決めていく
				'END: 上・下・天地
			Dim properPit As Single
			Dim startYPos As Single = 0
			Dim maxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), wordInLine, Pr)

			Select Case yStyle
				Case 0, 2
					startYPos = CheckNewYPos(CSng(Wc.mainTxt(lineNo)("tbl_txt_newypos")))
					properPit = PitchCal(startYPos, _
										Wc.DefSet(4), _
										wordInLine, _
										Wc.optWord("Cmb_Font"), _
										yStyle, _
										Pr _
										)
				Case 1
			 		properPit = PitchCal(startYPos, _
										Wc.DefSet(4), _
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
												Wc.DefSet(4), _
												wordInLine, _
												Wc.optWord("Cmb_Font"), _
												yStyle, _
												Pr _
												)
					End If
				Case 3 '2013/9/29 追加　ツーセンテンス上下 (フォントサイズ同じ場合）
					'END: ツーセンテンス上下処理の実装
					'END: 上の文字位置
					startYPos = CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))
					Dim targetObj() As string = DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword").ToString().Split(","c)
					
					If Wc.optWord(targetObj(0)) <> "" Then
						For i As Integer = 0 To Cstr(Wc.optWord(targetObj(0))).Length - 1 Step 1
							wordInLine(i)(2) = startYPos
							startYPos = startYPos + maxWord(0) + Csng(Wc.DefSet(6))								'上文字はピッチ調整をしない
						Next i
					End If
					'END: 下の文字位置設定
					If Wc.optWord(targetObj(1)) <> "" Then
						'下文字のみのArrayListを判定用に作る
						Dim tempWordDetal(1) As String
						Dim tempWordInLine As New ArrayList
						For i As Integer = 0 To Wc.optWord(targetObj(1)).Length - 1 Step 1
							tempWordDetal(0) = Wc.optWord(targetObj(1)).Substring(i, 1)
							tempWordDetal(1) = tempWord("fontSize")
							tempWordInLine.Add(tempWordDetal)
							tempWordDetal = {"", ""}
						Next i
						properPit = PitchCal(startYPos, _
												Wc.DefSet(4), _
												tempWordInLine, _
												Wc.optWord("Cmb_Font"), _
												1, _
												Pr _
												)
						Dim wordLength = CSng(Wc.DefSet(4)) - ((maxWord(0) * CSng(CStr(Wc.optWord(targetObj(1))).Length)))
						If CStr(Wc.optWord(targetObj(1))).Length > 1 Then
							wordLength = wordLength - (properPit * (CSng(CStr(Wc.optWord(targetObj(1))).Length)) - 1)
						End If
						
						If wordLength <= startYPos Then
							properPit = 0
							properPit = PitchCal(startYPos, _
													Wc.DefSet(4), _
													tempwordInLine, _
													Wc.optWord("Cmb_Font"), _
													2, _
													Pr _
													)
							tempWordInLine = Nothing
							For i As Integer = CStr(Wc.optWord(targetObj(0))).Length To (CStr(Wc.optWord(targetObj(0))).Length + CStr(Wc.optWord(targetObj(1))).Length) -1 Step 1
								wordInLine(i)(2) = startYPos
								startYPos = startYPos + maxWord(0) + properPit
							Next i

						Else
							startYPos = Wc.DefSet(4) - maxWord(0)
							For i As Integer = (CStr(Wc.optWord(targetObj(0))).Length + CStr(Wc.optWord(targetObj(1))).Length) -1 To CStr(Wc.optWord(targetObj(0))).Length Step -1
								wordInLine(i)(2) = startYPos
								startYPos = startYPos - (maxWord(0) + properPit)
							Next i
						End If
					End If
					
					Wc.curWord(lineNo) = wordInLine
					Exit Sub
			End Select
			
			For i As Integer = 0 To loopCounter - 1 Step 1
				wordInLine(i)(2) = startYPos
				startYPos = startYPos + maxWord(0) + properPit
			Next i
			
			Wc.curWord(lineNo) = wordInLine								'2017/7/21 curWord(0) -> curWord(lineNo)へ mb

		Else																	'★★フォントサイズが違う時★★
			'過去の文字を使って現在保持している配列内の位置を獲得して削除の後、挿入する
			'変更文字のフォントサイズを取得
			Dim firstPos As Integer
			Dim posCheckFlg As Integer = 0	
			Dim pastWord As String
			
			'コンボの値を置き換え
			If newTargetCmb IsNot Nothing Then
				If newTargetCmb IsNot Pr.Cmb_Year And newTargetCmb IsNot Pr.Cmb_Month And newTargetCmb IsNot Pr.Cmb_day Then
					pastWord = Wc.optWord(newTargetCmb.Name)
					Wc.optWord(newTargetCmb.Name) = newTargetCmb.SelectedValue
				End If
			End If
			'テキストボックスの値を置き換え
			If newTargetTxt IsNot Nothing Then
				pastWord = Wc.optWord(newTargetTxt.Name)
				Wc.optWord(newTargetTxt.Name) = newTargetTxt.Text
			End if
			
			'END: 文字数０から文字有りに変化する時を考える(場所をどのように判断するのか？フォントサイズは？)
			'CheckInsWordで全ての処理が可能でした2013/9/15
			'END: イレギュラーサイズにした時移行の行でイレギュラーがあるとx軸位置がおかしくなる
			
			'ArrayListを削除
			Wc.curWord(lineNo).Clear
			'挿入位置を取得
			Dim insPos() As String
			insPos = CStr(Wc.mainTxt(lineNo)("tbl_txt_inspos")).Split(","c)
			'挿入文字配列を取得
			Dim insWord As array
			insWord = CheckInsWord(Wc.mainTxt(lineNo)("tbl_txt_inspos"), _
    	                           Wc.mainTxt(lineNo)("tbl_txt_targetword"), _
    	                           Wc.mainTxt(lineNo)("tbl_txt_targetpoint"), _
    	                           lineNo _
    	                           )
			
			Dim loopCounter As Integer = CInt(CStr(Wc.mainTxt(lineNo)("tbl_txt_txt")).Length)
			'挿入文字の字数をループカウンター（不変文字数）に加算する
			For i As Integer = 0 To 2 Step 1
				If CInt(insPos(i)) <> 9999 Then
					loopCounter = loopCounter + CInt(insWord(i).Length -2)	
				End If
			Next i 
			'不変文字と挿入文字を一つの配列に格納していく
			Dim wordInLine As New ArrayList()
			Dim wordDetail(3) As String
			Dim k As Integer = 0
			Dim l As Integer = 0
			
			For i As Integer = 0 To loopCounter - 1 Step 1					'END エラーをかわす（insWordに配列が1つしかなく文の先頭にある時など）WordPreparerも
				If IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(1)) = i Then
					For j As Integer = 2 To CInt(insWord(k).Length - 1) Step 1
						wordDetail(0) = insWord(k)(j)
						wordDetail(1) = insWord(k)(0)
						wordInLine.Add(wordDetail)
						wordDetail = {"", "", "", ""}						'宣言を移動（スコープを増やす）・フォーマット（他４箇所同じ）
						i = i + 1
					Next j
					i = i - 1
					k = k + 1
				Else
					wordDetail(0) = CStr(Wc.mainTxt(lineNo)("tbl_txt_txt")).Substring(l, 1)
					wordDetail(1) = Wc.DefSet(1)
					wordInLine.add(wordDetail)
					wordDetail = {"", "", "", ""}
					l = l + 1
				End If
			Next i

			Wc.curWord(lineNo) = wordInLine

			Dim startYPos As Single = CheckNewYPos(Wc.mainTxt(lineNo)("tbl_txt_newypos"))
				
			Dim lastWordXPos As Single
				
			If lineNo <> 0 Then
				Dim wordNum As Integer
				Dim tempLastMaxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(lineNo - 1), Pr, wordNum)
				lastWordXPos = Wc.curWord(lineNo - 1)(wordNum)(3)
			Else
				lastWordXPos = 0
			End If
			'TODO:ツーセンテンス上下の時を考える
			Dim maxWord As Single = SetIrregXYPos(lineNo, _
													yStyle, _
													Wc.curWord(lineNo), _
													Wc.optWord("Cmb_Font"), _
													startYPos,
													lastWordXPos, _
													Pr)
			Call ShiftXPos(lineNo, maxWord, Pr)
			
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
	Public Function CheckInsWord(insPos As String, targetWord As String, _
								targetPoint As String, insCol As Integer _
								) As Array
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
        
        For i As Integer = 0 To objCnt Step 1											'現状1行に3挿入までにする
        	If splitInsPos(i) <> "9999" Then
        		Dim storageWord As String = Wc.optWord(splitTargetWord(i))
        		Dim wordPoint As String = Wc.optWord(splitTargetPoint(i))
        		Dim wordLength As Integer = CInt(storageWord.Length)  						'文字数をフォントサイズを格納する分が２つ
        		Dim resultAr(wordLength + 1) As String
        		Dim k As Integer = 0
        		
        		For j As Integer = 0 To wordLength + 1 Step 1
        			If j = 0 Then
        				resultAr(j) = wordPoint										'フォントサイズ = 1 -> 0 に
        			ElseIf j = 1 Then
        				If i = 0 Then
        					resultAr(j) = splitInsPos(i)							'挿入位置 = 1
        					newInsPos = CInt(splitInsPos(i)) + wordLength
        				Else
        					resultAr(j) =  newInsPos + CInt(splitInsPos(i)) 		'2番目以降の挿入の相対位置を絶対位置に確定する
        					newInsPos = CInt(resultAr(j)) + wordLength
        				End If
        			Else
        				resultAr(j) = storageWord.Substring(k, 1)
        				k = k + 1
        			End If
        		Next j
        		
        		returnAr(i) = resultAr
        		
        	End If
        Next i
        
        Return returnAr

	End Function
	
'フォントサイズを変更する
'''■ChangeFontSize
''' <summary>フォントサイズを変更して新しい位置を求める</summary>
''' <param name="changeType">Integer 0 = 全体変更　1 = 部分変更 2 = 複数行同時全体変更</param>
''' <param name="lineNo">Integer 変更する行番号</param>
''' <param name="targetPointCmb">Combo 変更するフォントサイズコンボ</param>
''' <param name="Pr">PrintReport</param>
''' <param name="multiNum">Optional Integer 複数行変更の際の行数</param>
''' <returns>Void 文字配列を参照して変更する</returns>
Public Sub ChangeFontSize(changeType As Integer, lineNo As Integer, _
							  targetPointCmb As ComboBox, Pr As PrintReport, _
							  Optional MultiNum As Integer = 0)
		'END: 全体変更するのか、部分変更するのかを確認する -> パラメーターで制御
		'END: 文字が無い時の対応が必要
		
		Dim startYPos As Single
		'END: y軸位置がイレギュラーでないか？
		Dim SctSql As New SelectSql
'		Dim txtRow As New Hashtable 
'		txtRow = SctSql.GetTbl_TxtRow(Wc.CurrentSet("curSize"), Wc.CurrentSet("curStyle"), lineNo)
				
		Select Case changeType								'★★全体変更
			Case 0
				'END: 一つ前の行のx位置(文字列中最大）を獲得する -> 基本列ピッチ + 新しいフォントサイズのx軸位置 = 新しいx軸位置
				Dim lastWordXPos As Single

				If lineNo <> 0 Then
					Dim wordNum As Integer
					Dim tempLastWordXPos() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), DirectCast(Wc.curWord(lineNo - 1), ArrayList), Pr, wordNum)  'Wc.curWord(lineNo - 1)(0)(3)
					lastWordXPos = CSng(DirectCast(Directcast(Wc.curWord(lineNo - 1),ArrayList)(wordNum), String())(3))
				Else
					lastWordXPos = 0
				End If
				'新しいフォントサイズを突っ込む
				For i As Integer = 0 To Wc.curWord(lineNo).Count - 1 Step 1
					Wc.curWord(lineNo)(i)(1) = targetPointCmb.SelectedIndex.ToString()
				Next i
				'行内の文字の最大幅をとる
				'END: 文字が無い時ダミーで文字サイズを計測する
				Dim maxWordSize() As Single
				If Wc.curWord(lineNo)(0)(0) <> "" Then
					maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(lineNo), Pr)
				Else
					Dim tempWordDetail() As String = {"口", Wc.curWord(lineNo)(0)(1), "", ""}
					Dim tempWordInLine As New ArrayList
					tempWordInLine.Add(tempWordDetail)
					Dim tempCurWord As New ArrayList
					tempCurWord.Add(tempWordInLine)
				
					maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), tempCurWord(0), Pr)
				
					tempWordDetail = Nothing
					tempWordInLine = Nothing
					tempCurWord = Nothing
				End If
				
				'END: 新しいx軸位置の確定
				Dim startNewXPos As Single
				startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
				'END: 配列にx軸位置を突っ込む
				For i As Integer = 0 To Wc.curWord(lineNo).Count - 1 Step 1
					Wc.curWord(lineNo)(i)(3) = startNewXPos
				Next i
			
				startYPos = CheckNewYPos(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos"))
				
				Dim properPit As Single = PitchCal(startYPos, _
													CSng(Wc.DefSet(4)), _
													Wc.curWord(lineNo), _
													Wc.optWord("Cmb_Font"), _
													CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
													Pr _
													)
				'END: y軸位置を決めていく
				Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")
					Case "0", "2"
						Call YPosCal(Wc.curWord(lineNo), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
					Case "1"
						Dim addHeight  As Single = maxWordSize(0) * Wc.curWord(lineNo).Count
						If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
							startYPos = CSng(Wc.DefSet(3))
						Else
							startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (Wc.curWord(lineNo).Count -1)))　
						End If
						Call YPosCal(Wc.curWord(lineNo), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
				End Select
				'END: 以降の列のx軸位置を変更して行く
				Call ShiftXPos(lineNo, startNewXPos, Pr)
			Case 1												'★★部分変更
				'挿入位置を取得
				Dim insPos() As String
				insPos = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos")).Split(","c)
				'挿入文字配列を取得
				Dim insWord As array
				insWord = CheckInsWord(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_inspos"), _
    	        	                   DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetword"), _
    	        	                   DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_targetpoint"), _
    	        	                   lineNo _
    	        	                   )
			
				Dim loopCounter As Integer = CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt").Length)
				'挿入文字の字数をループカウンター（不変文字数）に加算する
				For i As Integer = 0 To 2 Step 1
					If CInt(insPos(i)) <> 9999 Then
						loopCounter = loopCounter + CInt(insWord(i).Length -2)	
					End If
				Next i 
				'不変文字と挿入文字を一つの配列に格納していく
				Dim wordInLine As New ArrayList()
				Dim wordDetail(3) As String
				Dim k As Integer = 0
				Dim l As Integer = 0
				
				For i As Integer = 0 To loopCounter - 1 Step 1	
					If IsArray(insWord(k)) = True AndAlso CInt(insWord(k)(1)) = i Then
						For j As Integer = 2 To CInt(insWord(k).Length - 1) Step 1
							wordDetail(0) = insWord(k)(j)
							wordDetail(1) = insWord(k)(0)
							wordInLine.Add(wordDetail)
							wordDetail = {"", "", "", ""}	
							i = i + 1
						Next j
						i = i - 1
						k = k + 1
					Else
						wordDetail(0) = CStr(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_txt")).Substring(l, 1)
						wordDetail(1) = Wc.DefSet(1)
						wordInLine.add(wordDetail)
						wordDetail = {"", "", "", ""}
						l = l + 1
					End If
				Next i
				If loopCounter = 0 Then		'文字無し対策　2013/9/8 add 7 lines mb
					wordDetail(0) = ""
					wordDetail(1) = Wc.DefSet(1)
					wordInLine.Add(wordDetail)
					wordDetail = {"", "", "", ""}
				End If
				
				'Wc.curWord(lineNo).clear
				'Wc.curWord(lineNo) = wordInLine
				Wc.curWord(lineNo).clear
				Wc.curWord(lineNo) = wordInLine
				
				'CHK: イレギュラー位置の決定
				startYPos = CheckNewYPos(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos"))
				
				Dim lastWordXPos As Single
				
				If lineNo <> 0 Then
					Dim wordNum As Integer
					Dim tempLastMaxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(lineNo - 1), Pr, wordNum)
					lastWordXPos = Wc.curWord(lineNo - 1)(wordNum)(3)
				Else
					lastWordXPos = 0
				End If
				'END: イレギュラーでない処理
				If FontSizeDifChecker(Wc.curWord(lineNo)) = True Then
					Dim maxWordSize() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(lineNo), Pr)
					Dim startNewXPos As Single = lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					'x軸位置を突っ込む
					For i As Integer = 0 To Wc.curWord(lineNo).Count - 1 Step 1
						Wc.curWord(lineNo)(i)(3) = startNewXPos
					Next i
					
					'startYPos= CheckNewYPos(CSng(txtRow("tbl_txt_newypos")))
					
					Dim properPit As Single = PitchCal(startYPos, _
														CSng(Wc.DefSet(4)), _
														Wc.curWord(lineNo), _
														Wc.optWord("Cmb_Font"), _
														CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
														Pr _
														)
					'y軸位置を決めていく
					Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")
						Case "0", "2"
							Call YPosCal(Wc.curWord(lineNo), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
						Case "1"
							Dim addHeight As Single = CheckLineLength(Wc.curWord(lineNo), Wc.optWord("Cmb_Font"), Pr）
							If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
								startYPos = addHeight
							Else
								startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (Wc.curWord(lineNo).Count -1)))　
							End If
							'Call YPosCal(curWord(lineNo), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
					End Select
					Call ShiftXPos(lineNo,  startNewXPos, Pr)
				Else
					Dim maxWord As Single = SetIrregXYPos(lineNo, _
															DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle"), _
															Wc.curWord(lineNo), _
															Wc.optWord("Cmb_Font"), _ 
															startYPos, _
															lastWordXPos, _
															Pr)
					Call ShiftXPos(lineNo,  maxWord, Pr)
				End If
			Case 2											'★★マルチ変更
				'END lastWordXPos 要再考
				Dim lastWordXPos As Single
				Dim startNewXPos As Single
				
				If lineNo <> 0 Then
					lastWordXPos = Wc.curWord(lineNo - 1)(0)(3)
				Else
					lastWordXPos = 0
				End If

				For i As Integer = lineNo To　(lineNo + MultiNum) - 1 Step 1
					'新しいフォントサイズを突っ込む
					For j As Integer = 0 To Wc.curWord(i).Count -1 Step 1		'GetMaxWordを使うため
						Wc.curWord(i)(j)(1) = targetPointCmb.SelectedIndex.ToString()
					Next j
					
					Dim maxWordSize() As Single
					If Wc.curWord(i)(0)(0) <> "" Then
						maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(i), Pr)
					Else
						Dim tempWordDetail() As String = {"口", Wc.curWord(i)(0)(1), "", ""}
							Dim tempWordInLine As New ArrayList
							tempWordInLine.Add(tempWordDetail)
							Dim tempCurWord As New ArrayList
							tempCurWord.Add(tempWordInLine)
				
							maxWordSize = GetMaxWord(Wc.optWord("Cmb_Font"), tempCurWord(0), Pr)
				
							tempWordDetail = Nothing
							tempWordInLine = Nothing
							tempCurWord = Nothing
					End If
					'Dim txtRow2 As New Hashtable 
					'txtRow2 = SctSql.GetTbl_TxtRow(Wc.CurrentSet("curSize"), Wc.CurrentSet("curStyle"), i)
					If i = lineNo Then
						startNewXPos =lastWordXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					Else
						startNewXPos = startNewXPos - (maxWordSize(1) + Csng(Wc.DefSet(5))) + CheckNewXPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newxpos")))
					End If
					'x軸位置を突っ込む
					For j As Integer = 0 To Wc.curWord(i).Count - 1 Step 1
						Wc.curWord(i)(j)(3) = startNewXPos
					Next j
				
					startYPos= CheckNewYPos(CSng(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_newypos")))

					Dim properPit As Single = PitchCal(startYPos, _
														CSng(Wc.DefSet(4)), _
														Wc.curWord(i), _
														Wc.optWord("Cmb_Font"), _
														CInt(DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")), _
														Pr _
														)
					'y軸位置を決めていく
					Select Case DirectCast(Wc.mainTxt(lineNo), Hashtable)("tbl_txt_ystyle")
						Case "0", "2"
							Call YPosCal(Wc.curWord(i), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
						Case "1"
							Dim addHeight As Single = CheckLineLength(Wc.curWord(i), Wc.optWord("Cmb_Font"), Pr）
							If addHeight <= startYPos Then			'y軸の最大値を超えないようにする
								startYPos = addHeight
							Else
								startYPos = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (Wc.curWord(i).Count -1)))　
							End If
							Call YPosCal(Wc.curWord(i), Wc.optWord("Cmb_Font"), startYPos, properPit, Pr)
					End Select
				Next i
				'END: 以降の列のx軸位置を変更していく
				If (lineNo + MultiNum) - 1 <> Wc.curWord.Count - 1 Then
					Call ShiftXPos((lineNo + MultiNum) - 1, startNewXPos, Pr)
				End If
		End Select
		
		SctSql = Nothing
		'txtRow = Nothing

	End Sub
	
#End Region

#Region "Position"


'''■ShiftXpos
''' <summary>フォントサイズを変更した時の残りの行のx軸位置を増えた分だけずらす</summary>
''' <param name="lineNo">Integer 変更のあった行</param>
''' <param name="startNewXPos">Single x軸位置の再開始位置</param>
''' <param name="Pr">PrintReport</param>
''' <returns>Void Wc.curWordに計算値を当て込んでいく</returns>
	Public Sub ShiftXPos(ByVal lineNo As Integer, ByVal startNewXPos As Single, Pr As PrintReport)
		Dim MaxWidth() As Single
'		Dim SctSql As New SelectSql
'		Dim txtRow As New ArrayList 
'		txtRow = SctSql.GetSentence(Wc.CurrentSet("curSize"), Wc.CurrentSet("curStyle"))
'		SctSql = Nothing
		
		For i As Integer = lineNo + 1 To Wc.curWord.Count - 1 Step 1
			If Wc.curWord(i)(0)(0) <> "" Then						'END: イレギュラー行に対応する
				If FontSizeDifChecker(Wc.curWord(i)) = False Then
					
					Dim maxWord As Single = SetIrregXYPos(i, _
															Wc.mainTxt(i)("tbl_txt_ystyle"), _
															Wc.curWord(i), _
															Wc.optWord("Cmb_Font"), _ 
															CheckNewYPos(CSng((Wc.mainTxt(i)("tbl_txt_newypos")))), _
															startNewXPos, _
															Pr
														 )
					startNewXPos = maxWord + CheckNewXPos(CSng(Wc.mainTxt(i)("tbl_txt_newxpos")))
				Else
					MaxWidth = GetMaxWord(Wc.optWord("Cmb_Font"), Wc.curWord(i), Pr)
					startNewXPos = startNewXPos - (MaxWidth(1) + Wc.DefSet(5)) + CheckNewXPos(CSng(Wc.mainTxt(i)("tbl_txt_newxpos")))
			
					For j As Integer = 0 To Wc.curWord(i).Count - 1 Step 1
						Wc.curWord(i)(j)(3) = startNewXPos
					Next j
				End If
			Else'空白行の時ダミーデータを差し込む
				Dim tempWordDetail() As String = {"口", Wc.curWord(i)(0)(1), "", ""}
				Dim tempWordInLine As New ArrayList
				tempWordInLine.Add(tempWordDetail)
				Dim tempCurWord As New ArrayList
				tempCurWord.Add(tempWordInLine)
				
				MaxWidth = GetMaxWord(Wc.optWord("Cmb_Font"), tempCurWord(0), Pr)
				
				tempWordDetail = Nothing
				tempWordInLine = Nothing
				tempCurWord = Nothing
				startNewXPos = startNewXPos - (MaxWidth(1) + Wc.DefSet(5)) + CheckNewXPos(CSng(Wc.mainTxt(i)("tbl_txt_newxpos")))
				Wc.curWord(i)(0)(3) = startNewXPos
				
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
	Public Sub YPosCal(ByRef storageWord As ArrayList, font As String, topYPos As Single, pitch As Single, pr As PrintReport)
		
		Dim loopCounter As Integer = CInt(storageWord.Count)
		'2013/9/1 GetMaxWordでy軸も最大値を取るようにしたのでそれを使う
		Dim maxWord() As Single = GetMaxWord(Wc.optWord("Cmb_Font"), storageWord, pr)
		For i As Integer = 1 To loopCounter Step 1
			If i = 1 Then
				storageWord(i - 1)(2) = topYPos
			Else
				storageWord(i - 1)(2) = storageWord(i - 2)(2) + maxWord(0) + pitch				
			End If
		Next i

	End Sub
	
'END: 最後に確認する（引数変更の影響が非常に大きい）
'END: それぞれの文字のフォントサイズを考慮する
'END: フォントサイズの変更に伴いx軸の調整をする
'END: 大きさによってそれぞれの文字のX座標が変わる
'END: ピッチがビチビチの時も考慮

'''■SetIrregXYPos
''' <summary>フォントサイズが違う文字が混じった列の
''' 		1) それぞれのyPosを計算する
''' 		2) それぞれのxPosを計算する</summary>
''' <param name="lineNo">行番号</param>
''' <param name="yStyle">上・下・天地</param>
''' <param name="storageWord">文字配列</param>
''' <param name="font">フォント</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="pr">PrintReport.vb</param>
''' <returns>次の行のx軸スタート座標</returns>
	Public Function SetIrregXYPos(lineNo As Integer, yStyle As Integer, _
							ByRef storageWord As ArrayList, font As String, _
							topYpos As Single, lastXPos As Single, _
							Pr As PrintReport) As Single
'END: 文字が小さくなった時のx軸位置がおかしい -> フォーマットを忘れていたため 2013/9/7 mb
#If Debug then
Try
#End If
		'y軸開始位置の設定
		'dim startYPos = CheckNewYPos(topYpos)

		Dim properPit As Single = PitchCal(topYpos, _
											CSng(Wc.DefSet(4)), _
											storageWord, _
											Wc.optWord("Cmb_Font"), _
											yStyle, _
											Pr _
											)
				
		'下の時のみ、スタート位置計算
		If yStyle = "1" Then
			Dim addHeight As Single = CheckLineLength(storageWord, Wc.optWord("Cmb_Font"), Pr）
			addHeight = CSng(Wc.DefSet(4)) - (addHeight + (properPit * (storageWord.Count -1)))
			If addHeight <= topYpos Then														'y軸の最大値を超えないようにする
				topYpos = addHeight
			Else
				topYpos = Wc.DefSet(3)
			End If
		End If
		
		Dim eachXYSize(storageWord.Count - 1) As single
		Dim xySizeList As New ArrayList		
		Dim tempMaxWord() As Single = Pr.FontSizeCal(storageWord(0)(0), font, storageWord(0)(1))
		Dim lastTempMaxWord As Single
		Dim loopPos As Integer = 0
		Dim maxWord() As Single = {0, 0}
		'Dim aftFirstLp As Boolean = False
		
		'フォントサイズ毎にx軸の最大幅を取る・y軸位置を決定して行く
		For i As Integer = 0 To CInt(storageWord.Count - 1) Step 1
			eachXYSize = Pr.FontSizeCal(storageWord(i)(0), font, storageWord(i)(1))
		
			If maxWord(1) < eachXYSize(1)  Then														'行内文字の最大サイズを取得
				maxWord(1) = eachXYSize(1)
			End If
			
			xySizeList.Add(eachXYSize)
			
			If i > 0 AndAlso (storageWord(i - 1)(1) = storageWord(i)(1)　And tempMaxWord(0) < eachXYSize(0)) Then
				tempMaxWord(0) =eachXYsize(0)
			End If
			
			If i > 0 AndAlso (storageWord(i - 1)(1) = storageWord(i)(1)　And tempMaxWord(1) < eachXYSize(1)) Then
				tempMaxWord(1) =eachXYsize(1)
			End If
			
			If i > 0 AndAlso storageWord(i - 1)(1) <> storageWord(i)(1) Then
				For j As Integer = loopPos To i -1 Step 1
					'y軸位置を決めていく
					'If j = loopPos Then
					If j = 0 And loopPos = 0 Then
						storageWord(j)(2) = topYpos
						'aftFirstLp = True
					ElseIf j = loopPos Then
						'一つ前の文字のポジション + 文字の大きさ + ピッチ
						storageWord(j)(2) = CSng(storageWord(j - 1)(2)) + lastTempMaxWord + properPit
					Else
						storageWord(j)(2) = CSng(storageWord(j - 1)(2)) + tempMaxWord(0) + properPit
					End If
					xySizeList(j)(1) = tempMaxWord(1)
'					#If Debug Then
'						Writeline(storageWord(j)(2))
'					#End If
				Next j
				lastTempMaxWord = tempMaxWord(0)
				tempMaxWord = {0, 0}
				loopPos = i
			End If
			'最終グループ
			If i = CInt(storageWord.Count - 1) Then
				For j As Integer = loopPos To i Step 1
					'y軸位置を決めていく	
					If j = loopPos Then
						storageWord(j)(2) = CSng(storageWord(j - 1)(2)) + lastTempMaxWord + properPit
					Else
						storageWord(j)(2) = CSng(storageWord(j - 1)(2)) + tempMaxWord(0) + properPit
					End If
					If i = loopPos Then																	'最終グループが1文字の時tempMaxWordがとれないのでGetMaxWordで対応する
						tempMaxWord = Pr.FontSizeCal(storageWord(i)(0), font, storageWord(i)(1))
					End If
					xySizeList(j)(1) = tempMaxWord(1)
				Next j
			End If
		Next i
		
'		Dim k As Integer = 0
'		Do until k = xySizeList.Count
'			Write("★" & xySizeList(k)(0))
'			writeline("★" & xySizeList(k)(1))
'			k = k + 1
'		loop

		
		'x軸位置の設定
		For i As Integer = 0 To CInt(storageWord.Count -1) Step 1								'END: x軸は右から左へマイナス
			If xySizeList(i)(1) < maxWord(1) Then
				storageWord(i)(3) = (lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))) + ((maxWord(1) - xySizeList(i)(1)) / 2)
'				WriteLine(storageWord(i)(3))
			Else
				storageWord(i)(3) = lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))
'				WriteLine(storageWord(i)(3))
			End If
		Next i
		
'#If Debug Then
'writeline("最後のx軸位置:" & lastXPos)
'WriteLine("文字の最大幅:" & maxWord(1))
'Dim k As Integer = 0
'While k < xySizeList.Count
'	Write("高さ: " & xySizeList(k)(0))
'	Write("★横幅: " & xySizeList(k)(1))
'	Write("★縦位置: " & storageWord(k)(2))
'	writeline("★横位置: " & storageWord(k)(3))
'	k = k + 1
'End While
'#End if		

		Dim result As Single = lastXPos - (CSng(Wc.DefSet(5)) + maxWord(1))
		Return result

#If Debug then
Catch ex As Exception
	
End Try
#End If

	End Function
	
#End Region 

#Region "Pitch"

''' ■CheckLineLength
''' <summary>1行の文字を並べた時の長さを測る(文字間のスペースは除く）</summary>
''' <param name="storageWord">ArrayList 文字配列</param>
''' <param name="font">String フォント</param>
''' <param name="Pr">PrintReport</param>
''' <returns>文字の長さを返す</returns>
Public Function CheckLineLength(storageWord As ArrayList, font As String, Pr As PrintReport) As Single
		
		Dim addHeight As Single = 0
		For i As Integer = 0 To storageWord.Count - 1 Step 1
			Dim tempHeight() As Single = Pr.FontSizeCal(storageWord(i)(0), Wc.optWord("Cmb_Font"), storageWord(i)(1))
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
	Public Function CheckNewXPos(newXpos As Single) As Single
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
''' <param name="newXPos">ニューポジションが格納された変数</param>
''' <returns>新しい開始位置（無いときは0を返す）</returns>
''' <remarks>列が変わった時に次の列のy軸スタート位置が違うかどうかの判定に使用</remarks>
	Public Function CheckNewYPos(newYpos As Single) As Single
		Dim resultPos As Single = 0
		If newYpos <> 9999 Then
			resultPos = CSng(Wc.DefSet(3)) + newYpos
			Return resultPos
		End If
			Return Wc.DefSet(3)
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
	Public Function PitchCal(topYPos As Single, bottomYPos As Single, _
							storageWord As ArrayList, font As String, _
							yStyle As Integer, pr As PrintReport) As Single
							
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
			    	firstWord = pr.FontSizeCal(CStr(storageWord(i)(0)), font, CInt(storageWord(i)(1)))
			    	firstWord(0) = firstWord(0)
			    Case CInt(arCounter) - 1
			    	lastWord = pr.FontSizeCal(CStr(storageWord(i)(0)), font, CInt(storageWord(i)(1)))
			    Case Else
			    	wordLength = pr.FontSizeCal(CStr(storageWord(i)(0)), font, CInt(storageWord(i)(1)))
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
					Return Wc.DefSet(6)
				Case 1
					'Return Wc.DefSet(5)
					Return Wc.DefSet(6)
				Case 2
					resultPitch = (wordArea - wordHeight) / (arCounter - 1)
					Return resultPitch
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
''' <param name="storageWord">ArrayList 文字情報配列</param>
''' <param name= "Pr">PrintReport.vb</param>
''' <param name="wordNum">Optional ByRef Integer 最大幅の字がある文字番号</param>			'2013/9/1 add mb
''' <returns>1行内にある文字の最大幅を返す y = 0 x = 1</returns> 
	Public function GetMaxWord(font As String, storageWord As arraylist, Pr As PrintReport, Optional ByRef wordNum As Integer = 0) As Single()
		'y軸の最大値は今のところ必要ないので未実装 2013/7/27 mb -> 2013/9/1 y軸も使いたいのでテストする
		Dim wordSize() As Single = {0s, 0s}	
		If storageWord(0)(0) = "" Then						'空文字対策
			wordSize(1) = storageword(0)(3)
			Return wordSize
			Exit Function
		End If
		
		For i As Integer = 0 To storageWord.Count - 1 Step 1
			Dim tempWordSize() As Single = Pr.FontSizeCal(storageWord(i)(0), font, Val(storageWord(i)(1)))
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
	Public Function BasicPointChecker(mainTxt As Hashtable) As String
		Dim resultStr As String
		If mainTxt("tbl_txt_newpoint") <> "9999" Then
			resultStr = mainTxt("tbl_txt_newpoint")
			Return resultStr
		End If
		
		Return "0"
		
	End Function
	
'''■FontSizeDifChecker
''' <summary>異なったフォントサイズがあるか確かめる</summary>
''' <param name="storageWord">ArrayList 文字+フォント配列のArrayList</param>
''' <returns>True = 全て同じ False = 異なるものあり</returns>
	Public Function FontSizeDifChecker(storageWord As ArrayList) As Boolean
		Dim tempFontSize As String = storageWord(0)(1)
		For i As Integer = 0 To storageWord.Count -1 Step 1
			If tempFontSize <> storageWord(i)(1) Then
				Return False
			End If
		Next i
	
		Return True
	
	End Function

#End Region

End Class

