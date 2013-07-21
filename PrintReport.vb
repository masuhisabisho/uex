'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class PrintReport
	
	Dim Wc As New WordContainer()
	
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
		Dim Ch As New ControlHandler()
		Ch.AllTCHandleShifter(False, Me)
		Ch.AllSICHandleShifter(False, Me)

		'初期設定の読み込み
		Dim SctSql As New SelectSql
		Dim defSetAr() As String
		defSetAr = SctSql.GetDefaultVal(0)
		
		'フォント設定
		Dim fontList As New ArrayList
		Dim installedFont As New System.Drawing.Text.InstalledFontCollection
		Dim fontFamilies As FontFamily() = installedFont.Families
		
		fontList = SctSql.GetSqlList(" SELECT tbl_font_name FROM tbl_font ", "tbl_font_name")
		
		For Each item As FontFamily In fontFamilies
			For i As Integer = 0 To fontList.Count - 1 Step 1
				If fontList(i).Equals(item.Name) = True Then
					Me.Cmb_Font.Items.Add(item.Name)
					Exit For
				End If
			Next i
		Next item
		
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
		
		'コンボの値を保存
		Wc.OptionalWord(defSetAr, Me)
		
		'現在の用紙サイズID及び文例IDを保管
		Wc.CurSizeStorager = 0
		Wc.CurStyleStorager = 0
		
		'DBより文章データの取り込み
		Dim mainTxt As New ArrayList
		mainTxt = SctSql.GetSentence(0, 0)
		
		SctSql = Nothing

		'描画用Bitmapを準備
		With Pic_Main
			.Size = New Size(CInt(defSeTAr(2)), CInt(defSetAr(4)))					'CHK: New sizeはわかった、Bitmapの値はなんなのか？要確認
			.Image = New Bitmap(1800,668)											'TODO: 可変にする　
		End With
		
		'DB内の文章を単語に分割する
		Dim Cmn As New Common(defSetAr(6))
		Dim wordStorager As Array
		wordStorager = Cmn.WordPreparer(defSetAr, mainTxt, Wc.optWord)

		'文字を描画していく
		Call Cmn.WordArranger(defSetAr, mainTxt, wordStorager, Wc.optWord, Wc.optWord("Common_Font"),Me, Wc)

		'ハンドラーを付与する
		Ch.AllTCHandleShifter(True, Me)
		Ch.AllSICHandleShifter(True, Me)
		
		Ch = Nothing
	End Sub
#End Region
	
#Region "イベント"
	
	Private Sub Btn_Dtp_Click(sender As Object, e As EventArgs)
		'END: Show Calender for easy entry
		Dim Cal As New Calender(Me, Wc)
		Cal.ShowDialog()
		Cal.Dispose()
		Cal = Nothing
	End Sub	
	
	Public Sub TextBoxChange_TextChanged(sender As Object, e As EventArgs)
		'END: Implement Txt_HostName1_TextChanged
		'END: 最初の描画データを取り込み -> WordContainer.vb内に取り込み
		'END: 保存してある文字データを変更して再度描画
		'TODO: 画像サイズの可変設定
		'TODO: 用紙サイズ・文例の変更
		'END: 取り込みデータを元に変更画像を作成
'		'END: ピクチャーの破棄・再設定
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
			Case sender Is	Me.Txt_Name
'				Cmn.WordReplacer(0, me, wc, 0, ,CType(sender, TextBox))
'				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Txt_DeadName

			Case sender Is	Txt_Add1

			Case sender Is	Me.Txt_Add2
				Cmn.WordReplacerTxt(17, CType(sender, TextBox), me, wc, 1)
'				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Txt_HostName1
				Wc.optWord("Txt_PS1") = Me.Txt_PS1.Text
			Case sender Is	Me.Txt_HostName2
				Wc.optWord("Txt_PS1") = Me.Txt_PS2.Text
			Case sender Is	Me.Txt_HostName3
				Wc.optWord("Txt_PS1") = Me.Txt_PS3.Text
			Case sender Is	Me.Txt_HostName4
				Wc.optWord("Txt_PS1") = Me.Txt_PS4.Text
			Case sender Is	Me.Txt_PS1
				Wc.optWord("Txt_PS1") = Me.Txt_PS1.Text
			Case sender Is	Txt_PS2
				Wc.optWord("Txt_PS2") = Me.Txt_PS2.Text
			Case sender Is	Me.Txt_PS3
				Wc.optWord("Txt_PS3") = Me.Txt_PS3.Text
			Case sender Is	Me.Txt_PS4
				Wc.optWord("Txt_PS4") = Me.Txt_PS4.Text
			Case sender Is	Me.Txt_PS5
				Wc.optWord("Txt_PS5") = Me.Txt_PS5.Text
			Case sender Is	Me.Txt_PS6
				Wc.optWord("Txt_PS6") = Me.Txt_PS6.Text 
		End Select	
	End Sub
	
	Public Sub Cmb_SelectedIndexChanged(sender As Object, e As EventArgs)
		'TODO: 画像サイズの可変設定
		'END: 文字情報新しく置き換える
		'END: 文字の配置を決める
		'END: 文字を描画する
		'END: 文字の長さが先と後で不一致の時どうするか -> 1行全て削除、書き換え
		'END: Function化する
		'END: 間に入る時はどうするのか？ -> 下の通り（書き換え、部分差し替えをしない）
		'END: 現状のデータを保存、不変文字の場所、変化文字の場所を確認、変化部分を削除 -> 1行全て削除、書き換え
		'END: 変更後の列ピッチがおかしい（おおきい）
		Dim SctSql As New SelectSql()
		Dim currentSize As Integer = Wc.CurSizeStorager
		Dim defSetAr() As String = SctSql.GetDefaultVal(currentSize)
		Dim Cmn As New Common(CSng(defSetAr(6)))
		With Pic_Main
			If Not (.Image Is Nothing) Then
				.Image.Dispose()
				.Image = Nothing

				.Size = New Size(1800, 668)
 				.image = New Bitmap(1800,668)
			End If
		End With
		
		Select Case True
			'文字列
			Case sender Is Me.Cmb_Font
				Wc.optWord("Common_Font") = Me.Cmb_Font.Text				'END: フォントサイズ 2013/7/21 mb 
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_SeasonWord								'END: 季語 2013/7/20 mb
				Cmn.WordReplacer(0, CType(sender, ComboBox),  me, wc, 0)
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_Time1									'END: 時期1 2013/7/20 mb
				Cmn.WordReplacer(3, CType(sender, ComboBox), Me, Wc, 0)	
				Call RecreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_Title									'END: 続柄　2013/7/20 mb
				Cmn.WordReplacer(3, CType(sender, ComboBox), Me, Wc, 0)
				Call RecreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_DeathWay									'END: 死亡告知 2013/7/20 mb
				Cmn.WordReplacer(4, CType(sender, ComboBox), Me, Wc, 2)
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
'			Case sender Is	Me.Cmb_Time2
'				Wc.optWord("Cmb_Time2") = Me.Cmb_Time2.SelectedValue
'			Case sender Is	Me.Cmb_Donation
'				Wc.optWord("Cmb_Donation") = Me.Cmb_Donation.SelectedValue
			Case sender Is	Me.Cmb_Imibi
				Cmn.WordReplacer(8, CType(sender, ComboBox), me, wc, 2)
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))	'END: 忌日 2013/7/21 mb
			Case sender Is	Me.Cmb_EndWord
				Cmn.WordReplacer(14, CType(sender, ComboBox), me, wc, 1) 	'END: 結語 2013/7/21 mb
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_Year
				Wc.optWord("Cmb_Year") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & Cmb_Year.SelectedValue)
				Cmn.WordReplacer(15, CType(sender, ComboBox), Me, Wc, 0)	'END: 日付関連 2013/7/21 mb
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_Month
				Wc.optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & Cmb_Month.SelectedValue)
				Cmn.WordReplacer(15, CType(sender, ComboBox), Me, Wc, 0)
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
			Case sender Is	Me.Cmb_Day
				If Cmb_Day.SelectedValue = "" Then							'文字が無い時のSQLエラー回避
					Wc.optWord("Cmb_Day") = ""
				Else
					Wc.optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & Cmb_Day.SelectedValue)
				End If
				Cmn.WordReplacer(15, CType(sender, ComboBox), Me, Wc, 0)
				Call ReCreateWord(Wc.curWord, Wc.optWord("Common_Font"))
				
'			Case sender Is	Me.Cmb_HostType
'				Wc.optWord("Cmb_HostType") = Me.Cmb_HostType.SelectedValue
				
			'フォントサイズ
			Case sender Is Me.Cmb_PointTitle
				Wc.optWord("Cmb_PointTitle") = Me.Cmb_PointTitle.SelectedItem
			Case sender Is Me.Cmb_PointName
				Wc.optWord("Cmb_PointName") = Me.Cmb_PointName.SelectedValue
			Case sender Is Me.Cmb_PointDeadName
				Wc.optWord("Cmb_PointDeadName") = Me.Cmb_PointDeadName.SelectedValue
			Case sender Is Me.Cmb_PointImibi
				Wc.optWord("Cmb_PointImibi") = Me.Cmb_PointImibi.SelectedIndex
			Case sender Is Me.Cmb_PointEndWord
				Wc.optWord("Cmb_PointEndWord") = Me.Cmb_PointImibi.SelectedIndex
			Case sender Is Me.Cmb_PointCeremonyDate
				Wc.optWord("Cmb_PointEndWord") = Me.Cmb_PointEndWord.SelectedValue
			Case sender Is Me.Cmb_PointAdd1
				Wc.optWord("Cmb_PointAdd1") = Me.Cmb_PointAdd1
			Case sender Is Me.Cmb_PointHostType
				Wc.optWord("Cmb_PointHostType") = Me.Cmb_PointHostType
			Case sender Is Me.Cmb_PointHostName1
				Wc.optWord("Cmb_PointHostName1") = Me.Cmb_PointHostName1.SelectedValue
			Case sender Is Me.Cmb_PointHostName2
				Wc.optWord("Cmb_PointHostName2") = Me.Cmb_PointHostName2.SelectedValue    
			Case sender Is Me.Cmb_PointHostName3
				Wc.optWord("Cmb_PointHostName3") = Me.Cmb_PointHostName2.SelectedValue
			Case sender Is Me.Cmb_PointHostName4
	 			Wc.optWord("Cmb_PointHostName4") = Me.Cmb_PointHostName4.SelectedValue
			Case sender Is Me.Cmb_PointPS1
	 			Wc.optWord("Cmb_PointPS1") = Me.Cmb_PointPS1.SelectedValue 
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
		Wc.CurrentWord(wordInLine)

			
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
			
		Wc.CurrentWord(wordInLine)

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