'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class PrintReport
	
	Dim wc As New WordContainer()
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		'TODO : Add constructor code after InitializeComponents
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

#Region "Form load"
	Private Sub Print_Load(sender As Object, e As EventArgs)
		'ハンドラーをキャンセルしておく
		Dim ch As New ControlHandler()
		ch.AllTCHandleRemover(Me)
		ch.AllSICHandleRemover(Me)
		
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
	
		mainTxt = SctSql.GetSentence(0, 0)
		defSetAr = SctSql.GetDefaultVal(0)
		
		'現在の用紙サイズID及び文例IDを保管
		wc.CurSizeStorager = 0
		wc.CurStyleStorager = 0
		
		SctSql = Nothing

		'コンボの値を保存
		wc.OptionalWord(defSetAr, Me)
	
		'描画用Bitmapを準備
		With Pic_Main
			.Size = New Size(CInt(defSeTAr(2)), CInt(defSetAr(4)))					'CHK: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1800,668)											'TODO: 可変にする　
		End With
		
		'DB内の文章を単語に分割する
		Dim Cmn As New Common(defSetAr(6))
		Dim wordStorager As Array
		wordStorager = Cmn.WordPreparer(defSetAr, mainTxt, wc.optWord)

		'文字を描画していく
		Call Cmn.WordArranger(defSetAr, mainTxt, wordStorager, wc.optWord, "ＭＳ Ｐ明朝",Me, wc)

		'ハンドラーを付与する
		ch.AllTCHandleSetter(Me)
		ch.ALLSICHandleSetter(Me)
		
		ch = Nothing
		
	End Sub
	
#End Region
	
#Region "イベント"
	Private Sub Btn_Dtp_Click(sender As Object, e As EventArgs)
		'END: Show Calender for easy entry
		Dim resultDate As String()
		Dim Cal As New Calender
		Cal.ShowDialog(Me)
		If Cal.returndDate <> "" Then
			resultDate =  Cal.returndDate.Split("/"c)
			
			Me.Cmb_Year.SelectedValue = resultDate(0)
			Me.Cmb_Month.SelectedValue = resultDate(1)
			Me.Cmb_Day.Selectedvalue = resultDate(2)
		
			Cal.Dispose()
			Cal = Nothing
		End If
	End Sub	
	
	Public Sub TextBoxChange_TextChanged(sender As Object, e As EventArgs)
		'END: Implement Txt_HostName1_TextChanged
		'END: 最初の描画データを取り込み -> WordContainer.vb内に取り込み
		'TODO: 画像サイズの可変設定
		'TODO: 取り込みデータを元に変更画像を作成
'		'ピクチャーの破棄・再設定
		With Pic_Main
			If Not (.Image Is Nothing) Then
				.Image.Dispose()
				.Image = Nothing
				
				.Size = New Size(1800, 668)
 				.image = New Bitmap(1800,668)
			End If
		End With
		
		Dim SctSql As New SelectSql()
		Dim defSetAr() As String = SctSql.GetDefaultVal(0)
		Dim Cmn As New Common(CSng(defSetAr(6)))

		Select Case True
			Case sender Is	Me.Cmb_SeasonWord
				Dim loopCounter As Integer = 0
				loopCounter = CInt(wc.curWord(0).Count) - CInt(wc.optWord("Cmb_SeasonWord").Length) 
				wc.optWord("Cmb_SeasonWord") = Me.Cmb_SeasonWord.SelectedValue
				loopCounter = loopCounter + CInt(wc.optWord("Cmb_SeasonWord").Length)
				wc.curWord(0).RemoveRange(2, CInt(wc.curWord(0).Count) - 2)		'スタートのキー　+ 取り除くキー数（最後のキー番号ではない）
				
				'1) 変更のあるコンボ名、現在のデータが保存された配列
				
				'END: 文字情報新しく置き換える
				'END: 文字の配置を決める
				'END: 文字を描画する
				'END: 文字の長さが先と後で不一致の時どうするか
				'TODO: Function化する
				'パターン１ = 文字数, 縦配置が変わるのみ


				'選択された文字に置き換え
				For i As Integer = 2 To loopCounter - 1 Step 1
					Dim wordDetail() As string = {CStr(wc.optWord("Cmb_SeasonWord")).Substring(i - 2, 1), wc.curWord(0)(0)(1), "", wc.curWord(0)(0)(3)}
					wc.curWord(0).add(wordDetail)
				Next i
				'文字のy軸位置を再計算
				Cmn.YPosCal(wc.curWord(0), "ＭＳ Ｐ明朝", wc.curWord(0)(0)(2) ,Me)
				'文字を再描画
				Call ReCreateWord(wc.curWord, "ＭＳ Ｐ明朝")
				
			Case sender Is	Me.Cmb_Time1
				wc.optWord("Cmb_Time1") = Me.Cmb_Time1.SelectedValue
			Case sender Is	Me.Cmb_Title
				wc.optWord("Cmb_Title") = Me.Cmb_Title.SelectedValue
			Case sender Is	Me.Txt_Name
				wc.optWord("Txt_Name") = Me.Txt_Name.Text
			Case sender Is	Me.Cmb_DeathWay
				wc.optWord("Cmb_DeathWay") = Me.Cmb_DeathWay.SelectedValue
			Case sender Is	Me.Cmb_Time2
				wc.optWord("Cmb_Time2") = Me.Cmb_Time2.SelectedValue
			Case sender Is	Me.Txt_DeadName
				wc.optWord("Txt_DeadName") = Me.Txt_DeadName.Text 
			Case sender Is	Cmb_Donation
				wc.optWord("Cmb_Donation") = Me.Cmb_Donation.SelectedValue
			Case sender Is	Me.Cmb_Imibi
				wc.optWord("Cmb_Imibi") = Me.Cmb_Imibi.SelectedValue
			Case sender Is	Me.Cmb_EndWord
				wc.optWord("Cmb_EndWord") = Me.Cmb_EndWord.SelectedValue
			Case sender Is	Me.Cmb_Year
				wc.optWord("Cmb_Year") = Me.Cmb_Year.SelectedValue
			Case sender Is	Me.Cmb_Month
				wc.optWord("Cmb_Month") = Me.Cmb_Month.SelectedValue
			Case sender Is	Me.Cmb_Day
				wc.optWord("Cmb_Day") = Me.Cmb_Day.SelectedValue
			Case sender Is	Txt_Add1
				wc.optWord("Txt_Add1") = Me.Txt_Add1.Text 
			Case sender Is	Me.Txt_Add2
				wc.optWord("Txt_Add2") = Me.Txt_Add2.Text 
			Case sender Is	Me.Cmb_HostType
				wc.optWord("Cmb_HostType") = Me.Cmb_HostType.SelectedValue
			Case sender Is	Me.Txt_HostName1
				wc.optWord("Txt_PS1") = Me.Txt_PS1.Text
			Case sender Is	Me.Txt_HostName2
				wc.optWord("Txt_PS1") = Me.Txt_PS2.Text
			Case sender Is	Me.Txt_HostName3
				wc.optWord("Txt_PS1") = Me.Txt_PS3.Text
			Case sender Is	Me.Txt_HostName4
				wc.optWord("Txt_PS1") = Me.Txt_PS4.Text
			Case sender Is	Me.Txt_PS1
				wc.optWord("Txt_PS1") = Me.Txt_PS1.Text
			Case sender Is	Txt_PS2
				wc.optWord("Txt_PS2") = Me.Txt_PS2.Text
			Case sender Is	Me.Txt_PS3
				wc.optWord("Txt_PS3") = Me.Txt_PS3.Text
			Case sender Is	Me.Txt_PS4
				wc.optWord("Txt_PS4") = Me.Txt_PS4.Text
			Case sender Is	Me.Txt_PS5
				wc.optWord("Txt_PS5") = Me.Txt_PS5.Text
			Case sender Is	Me.Txt_PS6
				wc.optWord("Txt_PS6") = Me.Txt_PS6.Text 
	End Select	
	'TODO: 保存してある文字データを変更して再度描画
	
'		Dim SctSql As New SelectSql
'		Dim mainTxt As New ArrayList
'		Dim defSetAr() As String
'		'ピクチャーの破棄・再設定
'		With Pic_Main
'			If Not (.Image Is Nothing) Then
'				.Image.Dispose()
'				.Image = Nothing
'
'				.Size = New Size(1800, 668)
' 				.image = New Bitmap(1800,668)
'			End If
'		End With
'		Select Case True
'			Case sender Is Txt_HostName1
'
'
'    			'変更データ格納
'    			wc.optWord("Txt_HostName1") = Me.Txt_HostName1.Text
'				'DBより文章データの取り込み
'				mainTxt = SctSql.GetSentence(Me.Cmb_Size.SelectedValue)
'				defSetAr = SctSql.GetDefaultVal(Me.Cmb_Style.SelectedValue)
'				
'				Dim wordStorager As Array
'				wordStorager = WordArranger(defSetAr, mainTxt, wc.optWord)
'				Call WordPreparer(defSetAr, mainTxt, wordStorager, wc.optWord)
'				
'			Case sender Is Txt_HostName2
'				'MessageBox.Show("ok2")
'		End Select
		
	End Sub
	
	Public Sub Cmb_SelectedIndexChanged(sender As Object, e As EventArgs)
		'TODO: Implement Cmb_Thickness_SelectedIndexChanged
		'TODO: 画像サイズの可変設定

		With Pic_Main
			If Not (.Image Is Nothing) Then
				.Image.Dispose()
				.Image = Nothing

				.Size = New Size(1800, 668)
 				.image = New Bitmap(1800,668)
			End If
		End With
		
		Dim lineNo As Integer = 0
		
		Select Case True
			Case sender Is Me.Cmb_PointTitle
				wc.optWord("Cmb_PointTitle") = Me.Cmb_PointTitle.SelectedItem
				lineNo = 3
			Case sender Is Me.Cmb_PointName
				wc.optWord("Cmb_PointName") = Me.Cmb_PointName.SelectedValue
			Case sender Is Me.Cmb_PointDeadName
				wc.optWord("Cmb_PointDeadName") = Me.Cmb_PointDeadName.SelectedValue
			Case sender Is Me.Cmb_PointImibi
				wc.optWord("Cmb_PointImibi") = Me.Cmb_PointImibi.SelectedIndex
			Case sender Is Me.Cmb_PointEndWord
				wc.optWord("Cmb_PointEndWord") = Me.Cmb_PointImibi.SelectedIndex
			Case sender Is Me.Cmb_PointCeremonyDate
				wc.optWord("Cmb_PointEndWord") = Me.Cmb_PointEndWord.SelectedValue
			Case sender Is Me.Cmb_PointAdd1
				wc.optWord("Cmb_PointAdd1") = Me.Cmb_PointAdd1
			Case sender Is Me.Cmb_PointHostType
				wc.optWord("Cmb_PointHostType") = Me.Cmb_PointHostType
			Case sender Is Me.Cmb_PointHostName1
				wc.optWord("Cmb_PointHostName1") = Me.Cmb_PointHostName1.SelectedValue
			Case sender Is Me.Cmb_PointHostName2
				wc.optWord("Cmb_PointHostName2") = Me.Cmb_PointHostName2.SelectedValue    
			Case sender Is Me.Cmb_PointHostName3
				wc.optWord("Cmb_PointHostName3") = Me.Cmb_PointHostName2.SelectedValue
			Case sender Is Me.Cmb_PointHostName4
	 			wc.optWord("Cmb_PointHostName4") = Me.Cmb_PointHostName4.SelectedValue
			Case sender Is Me.Cmb_PointPS1
	 			wc.optWord("Cmb_PointPS1") = Me.Cmb_PointPS1.SelectedValue 
	End Select

	End Sub

#End Region
	
#Region "文字描画"

'''■ReCreateWord
''' <summary>文字を再描画していく(フォントサイズ, y軸位置（絶対位置), x軸位置（絶対位置）がある時用）</summary>
''' <param name="word">ArrayList 文字情報配列（文字, フォントサイズ, y軸位置, x軸位置）</param>
''' <param name="font">String フォント</param>
''' <returns>Void</returns>
	Public Sub ReCreateWord(word As ArrayList, font As String)
		For Each item As ArrayList In word
			For i As Integer = 0 To CInt(item.Count) -1 Step 1
				If item(i)(0) = "" Then  							'空白行はスキップする
					Continue For
				End If
'				#If Debug Then
'				System.Diagnostics.Debug.WriteLine(item(i)(0))
'				System.Diagnostics.Debug.WriteLine(item(i)(1))
'				System.Diagnostics.Debug.WriteLine(item(i)(2))
'				System.Diagnostics.Debug.WriteLine(item(i)(3))
'				System.Diagnostics.Debug.WriteLine(vbCrLf)
'				#End if
				Dim g As System.Drawing.Graphics
				g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
				g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
				g.DrawString(item(i)(0), _
							New Font(font, item(i)(1), GraphicsUnit.Pixel), _ 
							Brushes.Black, _ 
							item(i)(3), _ 
							item(i)(2), _
							New StringFormat(StringFormatFlags.DirectionVertical) _
							)
		
				g.Dispose()
				g = Nothing
			Next i
		Next 

	End Sub
	
'''■CreateWord
''' <summary>文字を描画して行く（同じフォントサイズ）</summary>
''' <param name="word">文字配列</param>
''' <param name="font">フォント</param>
''' <param name="point">String フォントサイズ</param>  <- word内に格納されているフォントサイズを利用するため廃止		point As Integer, 
''' <param name="xpos">x軸初期値</param>
''' <param name="ypos">y軸初期値</param>
''' <param name="properPit">文字ピッチ</param>
''' <param name="g">グラフィックオブジェクト</param>  <- 廃止
''' <returns>Void</returns>
	Public Sub CreateWord(word As Array, font As String, xPos As Single, yPos As Single, properPit As Single)
		Dim wordDetail(3) As String							'文字詳細情報
		Dim wordInLine As New ArrayList			'文字詳細情報を配列に格納
		
		Dim splitPointAr() As String
		splitPointAr = CStr(word(1)).Split(","c)
			
		For i As Integer = 2 To CInt(word.Length) - 1 Step 1
			Dim fontSize() As Single = FontSizeCal(word(i), font, CInt(splitPointAr(i - 2)))
			Dim g As System.Drawing.Graphics
			
			g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
			g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g.DrawString(word(i), _
						New Font(font, CInt(splitPointAr(i - 2)), GraphicsUnit.Pixel), _ 
						Brushes.Black, _ 
						xPos, _ 
						yPos, _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			
			g.Dispose()
			g = Nothing
			
			wordDetail(0) = word(i)							'出力位置を格納（絶対値）
			wordDetail(1) = splitPointAr(i - 2)
			wordDetail(2) = yPos
			wordDetail(3) = xPos
			wordInLine.Add(wordDetail)
			
			yPos = yPos + (fontSize(0) + properPit)			'yピッチ増加

'			#If Debug Then
'				System.Diagnostics.Debug.Write(wordDetail(0))
'				System.Diagnostics.Debug.Write("<>")
'				System.Diagnostics.Debug.Write(wordDetail(1))
'				System.Diagnostics.Debug.Write("<>")
'				System.Diagnostics.Debug.Write(wordDetail(2))
'				System.Diagnostics.Debug.Write("<>")
'				System.Diagnostics.Debug.Write(wordDetail(3))
'				System.Diagnostics.Debug.Write(",")
'				System.Diagnostics.Debug.WriteLine(vbCrLf)
'			#End if	
			
			wordDetail = {"", "", "", ""}
			
		Next i
		wc.CurrentWord(wordInLine)

			
	End Sub

'''■CreateWordDiff
''' <summary>文字を描画して行く（異なったフォントサイズ）</summary>
''' <param name="word">文字配列,フォントサイズ（配列）</param>
''' <param name="font">フォント</param>
''' <param name="xypos">xy軸位置（配列）</param>
''' <returns>Void</returns>
	Public Sub  CreateWordDiff(word As Array, font As String, xyPos As Array)
		
		Dim wordDetail(3) As String							'文字詳細情報
		Dim wordInLine As New ArrayList				'行ごとの文字詳細情報を格納
		
		Dim fontSize As String = CStr(word(1))
		Dim splitPointAr() As String = fontSize.Split(","c)
	
		For i As Integer = 2 To CInt(word.Length - 1) Step 1
			Dim g As System.Drawing.Graphics
			
			wordDetail(0) = word(i)
			wordDetail(1) = splitPointAr(i - 2)
			wordDetail(2) = xyPos(1, i - 2)
			wordDetail(3) = xyPos(0, i - 2)
			wordInLine.Add(wordDetail)
			wordDetail = {"", "", "", ""}

			g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
			g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g.DrawString(word(i), _
						New Font(font, CSng(splitPointAr(i - 2)), GraphicsUnit.Pixel), _
						Brushes.Black, _ 
						xyPos(1, i - 2), _ 
						xyPos(0, i - 2), _
						New StringFormat(StringFormatFlags.DirectionVertical) _
						)
			g.Dispose()
			g = Nothing
		Next i
		
'		#If Debug Then
'			System.Diagnostics.Debug.WriteLine("Irr")
'			System.Diagnostics.Debug.Write(wordDetail(0))
'			System.Diagnostics.Debug.Write("<>")
'			System.Diagnostics.Debug.Write(wordDetail(1))
'			System.Diagnostics.Debug.Write("<>")
'			System.Diagnostics.Debug.Write(wordDetail(2))
'			System.Diagnostics.Debug.Write("<>")
'			System.Diagnostics.Debug.Write(wordDetail(3))
'			System.Diagnostics.Debug.Write(",")
'			System.Diagnostics.Debug.WriteLine(vbCrLf)
'		#End If
			
		wc.CurrentWord(wordInLine)

	End Sub
	
#End Region

#Region "文字サイズ計測"
''''■FontSizeCal
''' <summary>文字の縦横高さを測る</summary>
''' <param name="word">String 計測したい文字</param>
''' <param name="font">String フォント</param>
''' <param name="point">Integer ポイント</param>
''' <returns>Single() 文字の 縦 = 0・横 = 1 を返す</returns>
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
	
#End Region

End Class