'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Option Strict On
Option Explicit On

Imports System.Diagnostics.Debug

Public Partial Class PrintReport
	'TODO: 発注画面を組み込む
	'TODO: 印刷設定を保持しておく
	'TODO: CSVやEXCELを読み込めるようにする
	'END: PictureBoxの位置を可変に
	
	'END: mainTxtのカプセル化
	'遅延バインディング
	'http://okwave.jp/qa/q4781160.html
	'VB 6（Visual Basic 6.0）でデータ型を明示しないプログラミングを行うときに必須だった機能である。
	'VB6ならVariant型、VB.NETならObject型の変数に何でも入れて、そこに入ったオブジェクトのメソッドなどを呼び出すために使われる。
	
	'Dim Wc As New WordContainer
	Dim Wc As WordContainer
	Private Const zero As Integer = 0
	
	'Public Sub New()
	Public Sub New(wcContainer As WordContainer)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		Wc = wcContainer
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

#Region "フォームロード"

	Private Sub Print_Load(sender As Object, e As EventArgs)
		'ダブルバッファを入れる
		Me.SetStyle(ControlStyles.DoubleBuffer, True)
		Me.SetStyle(ControlStyles.UserPaint, True)
		Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		
'Using g As Graphics = Me.CreateGraphics()
'   Dim scaleX As Single = 1440.0F / g.DpiX
'   Dim scaleY As Single = 1440.0F / g.DpiY
'End Using

		'ハンドラーをキャンセルしておく
		Dim Ch As New ControlHandler()
		Ch.AllTCHandleShifter(False, Me)
		Ch.AllSICHandleShifter(False, Me)
		Ch.ChangeCmb_Size(False, Me)
		Ch.ChangeCmb_Style(False, Me)
		
'		'初期設定の読み込み保存
		Dim SctSql As New SelectSql
		Call SctSql.SetDefaultVal(0, 0, Wc)
		
		'TODO: フォントを追加できるようにする
		'フォント（コンボ）設定
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
		'END: それぞれの用紙に対するコンボの設定をどうするか？
		Dim Scmb As New SetCombo
		Call Scmb.SetComboContent(Wc, Me)
		Scmb = Nothing
		
		'フォームをクリア
		Dim ClrFrm As New ClearForm
		Call ClrFrm.ClearForm(0, Me, Wc)
		ClrFrm = Nothing
		
		'DBより文章データの取り込み
		Wc.mainTxt = SctSql.GetSentence(0, 0)
		SctSql = Nothing

		'描画用Bitmapを準備
		Call ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))

		'DB内の文章を単語に分割する
		Dim Cmn As New Common(Wc)
		Dim word As New ArrayList
		word = Cmn.WordPreparer(Wc.mainTxt)
		'文字を描画していく
		Call Cmn.WordArranger(Wc.mainTxt, word, Me)
		Cmn = Nothing
		
		Call ControlThickness(Me.Pic_Main, _
								CInt(Me.Cmb_Thickness.SelectedValue), _
								CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)) _
							)

		'ハンドラーを付与する
		Ch.AllTCHandleShifter(True, Me)
		Ch.AllSICHandleShifter(True, Me)
		Ch.ChangeCmb_Size(True, Me)
		Ch.ChangeCmb_Style(True, Me)
		
		Ch = Nothing
		
		Me.Pnl_Main.HorizontalScroll.Value = CInt(Me.Pic_Main.Size.Width)

	End Sub
	

	
	#End Region

#Region "イベント"

#Region "用紙サイズ変更"
	'END: 用紙サイズ・文例の変更
	Friend Sub Cmb_SizeIndexChanged(sender As Object, e As EventArgs)
		Wc.CurrentSet("curSize") = CInt(Me.Cmb_Size.SelectedValue)
		Wc.CurrentSet("curStyle") = 0
		Call RefreshPanel(Wc.CurrentSet("curSize"), 0)
	End Sub

#End Region

#Region "文例変更"

	Friend Sub Cmb_Style_SelectedIndexChanged(sender As Object, e As EventArgs)
		Wc.CurrentSet("curStyle") = CInt(Me.Cmb_Style.SelectedValue)
		Call RefreshPanel(Wc.CurrentSet("curSize"), Wc.CurrentSet("curStyle"))
	End Sub

#End Region

#Region "共通関数"

'■RefreshPanel
''' <summary></summary>
''' <param name="sizeId"></param>
''' <param name="styleId"></param>
	Private Sub RefreshPanel(ByVal sizeId As Integer, ByVal styleId As Integer)
		
		Dim ClrFrm As New ClearForm
		Dim SctSql As New SelectSql
		Dim Cmn As New Common(Wc)
		Dim Ch As New ControlHandler
	
		'ハンドラーの無効化
		Ch.AllTCHandleShifter(False, Me)
		Ch.AllSICHandleShifter(False, Me)
		
		'TODO: コンボの変更を入れる
		
		'初期値の読み込み
		Call SctSql.SetDefaultVal(sizeId, styleId, Wc)
		'フォームをクリア
		Call ClrFrm.ClearForm(1, Me, Wc)
		'現在用紙・文例を保存
		Wc.CurrentSet("curSize") = CInt(Me.Cmb_Size.SelectedValue)
		Wc.CurrentSet("curStyle") = CInt(Me.Cmb_Style.SelectedValue)
		'センテンスの読み込み
		Wc.mainTxt = SctSql.GetSentence(CInt(Me.Cmb_Size.SelectedValue), styleId)
		'PicBoxの設定
		Call ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))
		'DB内の文章を単語に分割する
		Dim word As New ArrayList
		word = Cmn.WordPreparer(Wc.mainTxt)
		'文字を描画していく
		Call Cmn.WordArranger(Wc.mainTxt, word, Me)
		'濃度設定
		Call ControlThickness(Me.Pic_Main, _
			CInt(Me.Cmb_Thickness.SelectedValue), _
			CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)) _
			)
		'ハンドラーを再度付与する
		Ch.AllTCHandleShifter(True, Me)
		Ch.AllSICHandleShifter(True, Me)
		
		Clrfrm = Nothing
		SctSql = Nothing

	End Sub

#End Region

#Region "SelectIndexChanged"

	'コンボ変更
	Friend Sub Cmb_SelectedIndexChanged(sender As Object, e As EventArgs)
		'END: 画像サイズの可変設定
		'END: 文字情報新しく置き換える
		'END: 文字の配置を決める
		'END: 文字を描画する
		'END: 文字の長さが先と後で不一致の時どうするか -> 1行全て削除、書き換え
		'END: Function化する
		'END: 間に入る時はどうするのか？ -> 下の通り（書き換え、部分差し替えをしない）
		'END: 現状のデータを保存、不変文字の場所、変化文字の場所を確認、変化部分を削除 -> 1行全て削除、書き換え
		'END: 変更後の列ピッチがおかしい（おおきい）
		
		Dim Cmn As New Common(Wc)
		ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, Cint(Wc.DefSet(2)), Cint(Wc.DefSet(4)))
	
		If sender Is Me.Cmb_Font Then
			Wc.optWord("Cmb_Font") = Me.Cmb_Font.Text											'END: フォント 2013/7/21 mb 
			Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
		End If
		
		Select Case Wc.CurrentSet("curSize")
			Case 0, 1, 2, 3, 4, 5	'用紙サイズ
				Select Case True
						'文字列
						'END: 変数で一気に処理したい
						'END:3つ目の引数を変数に置き換える
					Case sender Is	Me.Cmb_Hyodai												'END: 表題 2013/10/11 mb
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(0)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(0))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())

					Case sender Is	Me.Cmb_SeasonWord											'END: 季語 2013/7/20 mb
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(2)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(2))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Cmb_Time1												'END: 時期1 2013/7/20 mb
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(3)), Me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(3))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call RecreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Cmb_Title												'END: 続柄　2013/7/20 mb
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(4)), Me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(4))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox), )
						Call RecreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Cmb_DeathWay												'END: 死亡告知 2013/7/20 mb
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(6)), Me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(6))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					'Case sender Is	Me.Cmb_Time2												'TODO: 未使用（開発途中のため） 2013/9/16
					'		Wc.optWord("Cmb_Time2") = Me.Cmb_Time2.SelectedValue
					
					'Case sender Is	Me.Cmb_Donation
					'	Wc.optWord("Cmb_Donation") = Me.Cmb_Donation.SelectedValue
						
					Case sender Is	Me.Cmb_Imibi
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(10)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(10))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())		'END: 忌日 2013/7/21 mb
						
					Case sender Is	Me.Cmb_EndWord
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(11)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(11))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),) 		'END: 結語 2013/7/21 mb
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Cmb_Year
						Dim SctSql As New SelectSql
						Wc.optWord("Cmb_Year") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = '" & Me.Cmb_Year.SelectedValue.ToString() & "'")
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(12)), Me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(12))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)			'END: 日付関連 2013/7/21 mb
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						Sctsql = Nothing
						
					Case sender Is	Me.Cmb_Month
						Dim SctSql As New SelectSql
						Wc.optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = '" & Me.Cmb_Month.SelectedValue.ToString() & "'")
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(13)), Me, CInt(Directcast(Wc.mainTxt(CInt(Wc.ComboTextPos(13))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						Sctsql = Nothing
						
					Case sender Is	Me.Cmb_Day
						Dim SctSql As New SelectSql
						Wc.optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = '" & Me.Cmb_Day.SelectedValue.ToString() & "'")
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(14)), Me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(14))), Hashtable)("tbl_txt_ystyle")), CType(sender, ComboBox),)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						SctSql = Nothing
						
					'Case sender Is	Me.Cmb_HostType
					'	Wc.optWord("Cmb_HostType") = Me.Cmb_HostType.SelectedValue				'TODO: 開発途中で未使用のため
					
					'★★フォントサイズ
					'フォントサイズ（数字）
					'TODO:インデックスで取っているので + 1にして通常表示にする
					Case sender Is Me.Cmb_PointHyodai
						Wc.optWord("Cmb_PointHyodai") = Me.Cmb_PointHyodai.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(3, CInt(Wc.ComboTextPos(0)), Cmb_PointHyodai, Me,,1)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointNamae
						Wc.optWord("Cmb_PointNamae") = Me.Cmb_PointNamae.SelectedIndex.ToString()			'2013/11/2 add
						Call Cmn.ChangeFontSize(3, CInt(Wc.ComboTextPos(1)), Cmb_PointNamae, Me,,2)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointTitle
						Wc.optWord("Cmb_PointTitle") = Me.Cmb_PointTitle.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(1, CInt(Wc.ComboTextPos(4)), Cmb_PointTitle, Me, )
						'Call Cmn.ChangeFontSize(1, a, 3, Cmb_PointTitle, Me, )
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointName
						Wc.optWord("Cmb_PointName") = Me.Cmb_PointName.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(1, CInt(Wc.ComboTextPos(5)), Cmb_PointName, Me, )
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					'Case sender Is Me.Cmb_PointDeadName											'TODO: 戒名のフォントサイズの変更（開発途中で未使用のため）
					'	Wc.optWord("Cmb_PointDeadName") = Me.Cmb_PointDeadName.SelectedValue
					'	Call Cmn.ChangeFontSize(0, Wc.curWord,3 , Cmb_PointName, Me, Cmb_Name,)
					'	Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointImibi
						Wc.optWord("Cmb_PointImibi") = Me.Cmb_PointImibi.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(1, CInt(Wc.ComboTextPos(10)), Cmb_PointImibi, Me, )
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointEndWord
						Wc.optWord("Cmb_PointEndWord") = Me.Cmb_PointEndWord.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(11)), Cmb_PointEndWord, Me, )
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointCeremonyDate
						Wc.optWord("Cmb_PointCeremonyDate") = Me.Cmb_PointCeremonyDate.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(12)), Cmb_PointCeremonyDate, Me,)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						'END:行数を制御 2013/10/16
					Case sender Is Me.Cmb_PointAdd1
						Wc.optWord("Cmb_PointAdd1") = Me.Cmb_PointAdd1.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(2, CInt(Wc.ComboTextPos(15)), Cmb_PointAdd1, Me, CInt(Wc.TxtMultiLine(0)))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					'Case sender Is Me.Cmb_PointHostType				
					'	Wc.optWord("Cmb_PointHostType") = Me.Cmb_PointHostType.SelectedIndex.ToString()			'開発途中につき未使用
					'	Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(37)), Cmb_PointHostType, Me, )
					'	Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointHostName1
						Wc.optWord("Cmb_PointHostName1") = Me.Cmb_PointHostName1.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(18)), Cmb_PointHostName1, Me,)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointHostName2
						Wc.optWord("Cmb_PointHostName2") = Me.Cmb_PointHostName2.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(19)), Cmb_PointHostName2, Me,)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointHostName3
						Wc.optWord("Cmb_PointHostName3") = Me.Cmb_PointHostName3.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(20)), Cmb_PointHostName3, Me,)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is Me.Cmb_PointHostName4
						Wc.optWord("Cmb_PointHostName4") = Me.Cmb_PointHostName4.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(0, CInt(Wc.ComboTextPos(21)), Cmb_PointHostName4, Me,)
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						'END:行数を制御 2013/10/16
					Case sender Is Me.Cmb_PointPS1
						Wc.optWord("Cmb_PointPS1") = Me.Cmb_PointPS1.SelectedIndex.ToString()
						Call Cmn.ChangeFontSize(2, CInt(Wc.ComboTextPos(22)), Cmb_PointPS1, Me, CInt(Wc.TxtMultiLine(1)))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
				End Select
			Case Else	
				'TODO: 未設定分の追加
		End Select
		'END: ControlThickness()を入れる(濃淡を維持する為)
		Call ControlThickness(Me.Pic_Main, CInt(Me.Cmb_Thickness.SelectedValue), CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))
	End Sub
	
# End Region
	
#Region "TextChanged"
	'文字変更
	Friend Sub TextBoxChange_TextChanged(sender As Object, e As EventArgs)
		'END: Implement Txt_HostName1_TextChanged
		'END: 最初の描画データを取り込み -> WordContainer.vb内に取り込み
		'END: 保存してある文字データを変更して再度描画
		'END: 画像サイズの可変設定
		'END: 取り込みデータを元に変更画像を作成
'		'END: ピクチャーの破棄・再設定

		ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))

		Dim Cmn As New Common (Wc)
		Select Case Wc.CurrentSet("curSize")
			Case 0, 1, 2, 3, 4, 5
				Select Case True
					Case sender Is Me.Txt_Namae
						Cmn.WordReplacer(CInt(Wc.ComboTextPos(1)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(1))), Hashtable)("tbl_txt_ystyle")), ,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font"))
						
					Case sender Is	Me.Txt_Name												'END:俗名 2013/8/4 mb
						Cmn.WordReplacer(CInt(Wc.ComboTextPos(5)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(5))), Hashtable)("tbl_txt_ystyle")), ,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font"))
						
					Case sender Is	Me.Txt_DeadName
						'TODO: 設定する
						
					Case sender Is	Txt_Add1												'END: dbにフォントサイズ無いとエラーに
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(15)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(15))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_Add2
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(16)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(16))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_HostName1
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(18)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(18))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_HostName2
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(19)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(19))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_HostName3
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(20)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(20))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_HostName4
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(21)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(21))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS1
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(22)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(22))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS2
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(23)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(23))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS3
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(24)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(24))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS4
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(25)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(25))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS5
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(26)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(26))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
					Case sender Is	Me.Txt_PS6
						Call Cmn.WordReplacer(CInt(Wc.ComboTextPos(27)), me, CInt(DirectCast(Wc.mainTxt(CInt(Wc.ComboTextPos(27))), Hashtable)("tbl_txt_ystyle")),,CType(sender, TextBox))
						Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
						
				End Select
			Case Else 'TODO:未設定追加する
		End Select
		'END: ControlThickness()を入れる
		Call ControlThickness(Me.Pic_Main, CInt(Me.Cmb_Thickness.SelectedValue), CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))
		
	End Sub
	
#End Region

#Region "その他のイベント"

	Private Sub PrintReport_FormClosed(sender As Object, e As FormClosedEventArgs)
		'保持内容のクリア
		'2013/10/6クリア方式を変更
		Wc.WordClear(1)			'現在設定の用紙・文例
		Wc.WordClear(2)			'用紙の初期設定値
		Wc.WordClear(3)			'コンボ・テキストの値
		
		Wc.ComboTextPos.Clear()
		Wc.ComboTextStr.Clear()
		Wc.ComboTextPoint.Clear()
		Wc.TxtMultiLine.Clear()
		Wc.CmbTxtPntEnabled.Clear()
		
		Wc.TempCurrentWord.Clear()
		Wc.curWord.Clear()
		Wc.mainTxt.Clear()
		
	End Sub
	
	'印刷フォームを開く
	Private Sub Btn_Print_Click(sender As Object, e As EventArgs)
		'Dim Ps As New PrintSetting(Me.Pic_Main.Image, Wc.DefSet(7), Wc.DefSet(8))
		Dim Ps As New PrintSetting(Wc)
		Ps.ShowDialog()
		Ps.Dispose()
		Ps = Nothing
	End Sub
	
	'カレンダーを開く
	Private Sub Btn_Dtp_Click(sender As Object, e As EventArgs)
		'END: Show Calender for easy entry
		Dim Cal As New Calender(Me, Wc)
		Cal.ShowDialog()
		Cal.Dispose()
		Cal = Nothing
	End Sub	

	'文字の濃淡変更
	Public Sub Cmb_Thickness_SelectedIndexChanged(sender As Object, e As EventArgs)
		Wc.optWord("Cmb_Thickness") = Me.Cmb_Thickness.SelectedValue.ToString()
		Wc.optWord("Cmb_Thickness_Txt") = Me.Cmb_Thickness.Text
		Call ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, Cint(Wc.DefSet(2)), Cint(Wc.DefSet(4)))														'END: 変数に置き換える
		Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())
		Call ControlThickness(Me.Pic_Main, CInt(Me.Cmb_Thickness.SelectedValue), CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))			'END: 変数に置き換える
	End Sub
	
	'画像拡大
	Public Sub Cmb_Magnify_SelectedIndexChanged(sender As Object, e As EventArgs)
		Call ControlViewSize(Wc.curWord)
	End Sub
	
#End Region
	
#End Region
	
#Region "文字描画"
	
'''■ControlViewSize
''' <summary></summary>
''' <param name="storageWord"></param>
	Private Sub ControlViewSize(ByVal storageWord As ArrayList)
		'TODO: フォントの増減レートを考える
		'TODO:　描画位置を考える
		If Me.Cmb_Magnify.SelectedValue.ToString() <> "50" Then
			
			Dim rate As Double = CDbl(Me.Cmb_Magnify.SelectedValue) * 0.02
			
			Call ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, CInt(CDbl(Wc.DefSet(2)) * rate), CInt(CDbl(Wc.DefSet(4)) * rate))
			Call CopyMagnifyData(storageWord, rate)
			Call ReCreateWord(Wc.TempCurrentWord, Wc.optWord("Cmb_Font").ToString())
			
			If CDbl(Me.Cmb_Thickness.SelectedValue) <> 0 Then
				Call ControlThickness(Me.Pic_Main, CInt(Me.Cmb_Thickness.SelectedValue), CInt(CDbl(Wc.DefSet(2)) * rate), CInt(CDbl(Wc.DefSet(4)) * rate))		'END: 変数に置き換える
			End If
		Else
			Call ClearPicture(Me.Pnl_Main, Me.Pnl_PanelAdjuster, Me.Pic_Main, CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))
			Call ReCreateWord(Wc.curWord, Wc.optWord("Cmb_Font").ToString())

			If CDbl(Me.Cmb_Thickness.SelectedValue) <> 0 Then
				Call ControlThickness(Me.Pic_Main, CInt(Me.Cmb_Thickness.SelectedValue), CInt(Wc.DefSet(2)), CInt(Wc.DefSet(4)))		'END: 変数に置き換える
			End If	
		End If
		
	End Sub
	
'''■CopyMagnifyData
''' <summary></summary>
''' <param name="storageWord"></param>
''' <param name="rate"></param>
	Private Sub CopyMagnifyData(ByVal storageWord As ArrayList, ByVal rate As Double)
		
		Wc.TempCurrentWord.Clear()
		
		For Each item As ArrayList In Wc.curWord
			Dim wordInLine As New ArrayList
			For i As Integer = 0 To item.Count - 1 Step 1
				Dim wordDetail(3) As String
				wordDetail(0) = DirectCast(item(i), String())(0)
				wordDetail(1) = (CDbl(DirectCast(item(i), String())(1)) * rate).ToString()
				wordDetail(2) = (CDbl(DirectCast(item(i), String())(2)) * rate).ToString()
				wordDetail(3) = (CDbl(DirectCast(item(i), String())(3)) * rate).ToString()
				wordInLine.Add(wordDetail)
				wordDetail = {"", "", "", ""}
			Next i
				Wc.TempCurrentWord = wordInLine
		Next
		
	End Sub
	
'''■ControlThickness
''' <summary>文字に濃淡をつける</summary>
''' <param name="picBox">PictureBox ピクチャーボックス</param>
''' <param name="whiteRate">Integer 濃淡の割合</param>
''' <param name="picWidth">Integer BitMapの幅</param>
''' <param name="picHeight">Integer BitMapの高さ</param>
''' <returns>Void</returns>
	Private Sub ControlThickness(ByVal picBox As PictureBox, ByVal whiteRate As Integer, _
								 ByVal picWidth As Integer, ByVal picHeight As Integer)
		
		Dim g As System.Drawing.Graphics
		g = System.Drawing.Graphics.FromImage(picBox.Image)

		Dim Br As New SolidBrush(Color.FromArgb(whiteRate, Color.White)) '0-255の範囲
		'四角を描画する
		g.FillRectangle(Br, zero, zero, picWidth, picHeight)

		'Graphicsオブジェクトのリソースを解放する
		g.Dispose()	
		g = Nothing
		Br.Dispose()
		Br = Nothing
		
	End Sub

'''■ClearPicture
''' <summary>PictureBox内のBitMapをクリアーする</summary>
''' <param name="picBox">PictureBox ピクチャーボックス</param>
''' <param name="picWidth">画像の幅</param>
''' <param name="picHeight">画像の高さ</param>
''' <returns>Void</returns>
	Private Sub ClearPicture(ByVal mainPanel As Panel, ByVal panelAdjuster As Panel, ByVal picBox As PictureBox, ByVal picWidth As Integer, ByVal picHeight As Integer)
		'END: メインパネルを広げるパネルの大きさを設定
		'Ex 1900 720
		'END: PictureBox -> 最小枠　印刷 -> 初期位置移動
		'END: Lable -> 枠線用
		'TODO: パネルの初期値より小さい表示の時の調整

		Dim expander As Integer = 200
		Dim frameAdjuster As Integer = 100
		
		Dim paWidth As Integer = picWidth + expander
		Dim paHeight As Integer = picHeight + expander
		
		If mainPanel.Size.Width > paWidth Then
			paWidth = mainPanel.Size.Width
		End If
		
		If mainPanel.Size.Height > paHeight Then
			paHeight = mainPanel.Size.Height
		End If	
		
		panelAdjuster.Size = New Size(paWidth, paHeight)
		mainPanel.Controls.Add(panelAdjuster)
		
		With Me.Pnl_Frame
			.Size = New Size(picWidth + frameAdjuster, picHeight + frameAdjuster)
			
			Dim frameXPos As Integer
			Dim frameYPos As Integer
			
			If  mainPanel.Size.Width = paWidth Then
				frameXPos = CInt((mainPanel.Size.Width - .Size.Width) / 2)
			Else
				frameXPos = CInt((expander - frameAdjuster) / 2)
			End If
			
			If mainPanel.Size.Height = paHeight Then
				frameYPos = CInt((mainPanel.Size.Height - .Size.Height) / 2)
			Else
				frameYPos = CInt((expander - frameAdjuster) / 2)
			End If
			
			.Location = New Point(frameXPos, frameYPos)
		End With

		With picBox
			If Not (.Image Is Nothing) Then
				.Image.Dispose()
				.Image = Nothing
			End if
				.Size = New Size(picWidth, picHeight)
				.image = New Bitmap(picWidth, picHeight)
				
				Dim picXpos As Integer
				Dim picYpos As Integer
				
				If mainPanel.Size.Width = paWidth Then
					picXpos = CInt((mainPanel.Size.Width - picWidth) / 2)
				Else
					picXpos = CInt(expander / 2)
				End If
				
				If mainPanel.Size.Height = paHeight Then
					picYpos = CInt((mainPanel.Size.Height - picHeight ) / 2)
				Else
					picYpos = CInt(expander / 2)
				End If
				
				.Location = New Point(picXpos, picYpos)
		End With

	End Sub

	'''■ReCreateWord
''' <summary>文字を再描画していく(フォントサイズ, y軸位置（絶対位置), x軸位置（絶対位置）がある時用）</summary>
''' <param name="word">ArrayList 文字情報配列（文字, フォントサイズ, y軸位置, x軸位置）</param>
''' <param name="font">String フォント</param>
''' <returns>Void</returns>
Public Sub ReCreateWord(ByVal word As ArrayList, ByVal font As String)
#If Debug then
	Call CheckErrSentence(Wc.curWord, "LOG", False)
#End If
		If Me.Cmb_Magnify.SelectedValue.ToString() <> "50" Then
			For Each item As ArrayList In word
				For i As Integer = 0 To CInt(item.Count) -1 Step 1
					'If DirectCast(item(i), ArrayList)(0) Is Nothing Then  							'空白行はスキップする
					If DirectCast(item(i), String())(0) = "" Then
						Continue For
					End If

					Dim g As System.Drawing.Graphics
					g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
					g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
					'New Font(font, item(i)(1),GraphicsUnit.Pixel), _ 
				
					g.DrawString(DirectCast(item(i), String())(0), _
								New Font(font, CSng(DirectCast(item(i), String())(1))), _ 
								Brushes.Black, _
								CSng(DirectCast(item(i), String())(3)), _ 
								CSng(DirectCast(item(i), String())(2)), _
								New StringFormat(StringFormatFlags.DirectionVertical) _
								)
					g.Dispose()
					g = Nothing
				Next i
			Next
		Else	
			For Each item As ArrayList In word
				For i As Integer = 0 To CInt(item.Count) -1 Step 1
					If DirectCast(item(i), String())(0) = "" Then  							'空白行はスキップする
						Continue For
					End If
					Dim g As System.Drawing.Graphics
					g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
					g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
					'New Font(font, item(i)(1),GraphicsUnit.Pixel), _ 
					
					g.DrawString(DirectCast(item(i), String())(0), _
								New Font(font, CSng(DirectCast(item(i), String())(1))), _ 
								Brushes.Black, _
								CSng(DirectCast(item(i), String())(3)), _ 
								CSng(DirectCast(item(i), String())(2)), _
								New StringFormat(StringFormatFlags.DirectionVertical) _
								)
					g.Dispose()
					g = Nothing
				Next i

			Next	
			
		End If
	End Sub
	
'''■CreateWord
''' <summary>文字を描画して行く（同じフォントサイズ）</summary>
''' <param name="word">ArrayList 文字配列(行単位)</param>
''' <param name="font">String フォント</param>
''' <returns>Void</returns>
	Public Sub CreateWord(ByVal word As ArrayList, ByVal font As String)
		Dim wordDetail(3) As String							'文字詳細情報
		Dim wordInLine As New ArrayList						'文字詳細情報を配列に格納
		'http://paint.syumideget.com/index.php?%E8%A7%A3%E5%83%8F%E5%BA%A6%E3%83%BB%E3%83%94%E3%82%AF%E3%82%BB%E3%83%AB%E3%83%BB%E3%82%A4%E3%83%B3%E3%83%81
		'PageUnitプロパティはページ座標で使用する長さの単位を指定するためのプロパティで、
		'ページ変換（ページ座標からデバイス座標への変換）で使用されます。
		'GDI+の座標系について詳しくは、MSDNの「座標系の種類」をご覧ください。
		
		'PageUnit = Display 表示デバイスの長さの単位を指定します。
		'通常、ビデオ ディスプレイにはピクセル、プリンタには 1/100 インチを指定します。
		'ただし、.NET Framework 1.1以前では、1/75インチを長さの単位に指定します。
		For i As Integer = 0 To word.Count - 1 Step 1
			'空白行はスキップする
			If DirectCast(word(0), String())(0) = "" Then
				wordDetail(0) = DirectCast(word(i), String())(0)						'2013/11/4 空文字の出力位置もここで
				wordDetail(1) = DirectCast(word(i), String())(1)
				wordDetail(2) = DirectCast(word(i), String())(2)
				wordDetail(3) = DirectCast(word(i), String())(3)
				wordInLine.Add(wordDetail)
				Wc.curWord = wordInLine
				wordDetail = {"", "", "", ""}
				Continue For
			End If
			
			Dim g As System.Drawing.Graphics
			g = System.Drawing.Graphics.FromImage(Me.Pic_Main.Image)
			g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
			g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
			'New Font(font, item(i)(1),GraphicsUnit.Pixel), _ 
			
			g.DrawString(Directcast(word(i), String())(0), _
						 New Font(font, CSng(DirectCast(word(i), String())(1))) , _ 
						 Brushes.Black, _ 
						 CSng(DirectCast(word(i), String())(3)), _ 
						 Csng(DirectCast(word(i), String())(2)), _
						 New StringFormat(StringFormatFlags.DirectionVertical) _
						 )
			
			g.Dispose()
			g = Nothing
			
			wordDetail(0) = DirectCast(word(i), String())(0)						'出力位置を格納（絶対値）
			wordDetail(1) = DirectCast(word(i), String())(1)
			wordDetail(2) = DirectCast(word(i), String())(2)
			wordDetail(3) = DirectCast(word(i), String())(3)
			wordInLine.Add(wordDetail)
			
			wordDetail = {"", "", "", ""}
			
		Next i
		If DirectCast(word(0), String())(0) <> "" Then
			Wc.curWord = wordInLine
		End If
	End Sub

#End Region

#Region "文字サイズ計測"
''''■FontSizeCal
''' <summary>文字の縦横高さを測る</summary>
''' <param name="word">String 計測したい文字</param>
''' <param name="font">String フォント</param>
''' <param name="point">Integer ポイント</param>
''' <returns>Single() 文字の 縦 = 0・横 = 1 を返す</returns>
	Public Function FontSizeCal(ByVal word As String, ByVal font As String, ByVal point As Integer) As Single()
		Dim resultAl(1) As Single 
		'Dim stringFont As New Font(font, point, GraphicsUnit.Pixel)
		Dim stringFont As New Font(font, point)
		Dim stringSize As New SizeF
		
		'END:口で文字が無い時の処理をここでする
		If word = "" Then
			word = "口"
		End If
		
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
