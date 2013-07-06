﻿'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class Common
	Const basicPitch As Single = -3

''''■GetWareki
''' <summary>Get wareki in Kanji</summary>
''' <param name="requestDt">Date</param>
''' <returns>Wareki in Kanji by String</returns>	
	Public Function GetWareki(requestDt As Date) As String
		Dim separateDt As String() = requestDt.ToString("yyyy/MM/dd").Split("/")
		If CInt(separateDt(0)) < 1989 Then
			MessageBox.Show("1990年以前は使用できません")
			Exit Function
		End If
		
		Dim result As String =""
		
		Dim f As New SelectSql
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & CInt(separateDt(0)))
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & CInt(separateDt(1)))
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & CInt(separateDt(2)))
		
		f = Nothing
		
		Return result
		
	End Function	
	
	''''■Magnify
''' <summary>画像を拡大・縮小する。</summary>
''' <param name="Source">対象の画像</param>
''' <param name="Rate">拡大率。以下の値を指定した場合は縮小される。</param>
''' <param name="Quality">画質。省略時は最高画質。</param>
''' <returns>処理後の画像</returns>
''' 'http://homepage1.nifty.com/rucio/main/dotnet/Samples/Sample141ImageMagnify.htm
''' 'PictureBox1.Image = Magnify(PictureBox1.Image, 1.2F)
	Private Function Magnify(ByVal Source As Image, ByVal Rate As Double, _ 
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
#Region "Word"

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
''' <param name="optWord">オプションのセンテンス</param>		<- 追加	2013/7/
''' <returns>文字数 = 0, フォントサイズ = 1, 挿入列番号 = 2, 挿入位置 = 3 を獲得する, 文字（任意の数）= 3～</returns>
    Public Function CheckInsWord(insPos As String, targetWord As String, targetPoint As String, insCol As Integer, optWord As Hashtable) As Array
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
''' 		2) xPosを計算する
''' </summary>
''' <param name="yStyle">上・下・天地</param>
''' <param name="wordStrager">文字配列(0 = 文字数, 1 = それぞれのフォントサイズ）</param>
''' <param name="font">フォント（フォントサイズ含む）</param>
''' <param name="topYPos">y軸最上位置</param>
''' <param name="bottomYPos">y軸最下位置</param>
''' <param name="curXPitch">x軸の改列ピッチ</param>
''' <param name="lastXPos">最後のx軸位置</param>
''' <param name="maxWidth">最大のフォント幅（参照）</param>
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
																							'***END: 一番大きいフォントの位置よりそれぞれのｘ軸位置を決める
		For i As Integer = 0 To CInt(wordStrager(0)) -1 Step 1								'END: x軸は右から左へマイナス
			If eachXYSize(i)(1) < tempMaxWidth Then
				eachPos(1, i) = (lastXPos - curXPitch - tempMaxWidth) + ((tempMaxWidth - CSng(eachXYSize(i)(1))) / 2) 'TODO: 位置微調整が必要
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
''' <param name="topYPos">開始位置</param>
''' <param name="bottomYPos">修了位置</param>
''' <param name="wordAr">単語配列</param>
''' <param name="font">フォント</param>		<- 追加　2013/06/23
''' <param name="point">ポイント数</param>	<- Arrayに変更 2013/7/4
''' <param name="pattern">上・下・天地揃え</param>
''' <returns>ピッチ数を返す（ピッチが取れない時はマイナス）</returns>
Public Function PitchCal(topYPos As Single, bottomYPos As Single, wordAr As Array, font As String, point As Array, pattern As Integer, pr As PrintReport) As Single
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
			    	firstWord = pr.FontSizeCal(CStr(wordAr(i)), font, point(j))
			    Case CInt(arCounter)
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
#End Region
End Class
