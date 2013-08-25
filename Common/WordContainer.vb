'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/13
' 時刻: 10:19
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class WordContainer
	
	Private curSetting As New Hashtable
	Private defKeyWord As New Hashtable
	Public curWord As New ArrayList()

	Public optWord As New Hashtable()
	
	'END:　この辺りまとまらないか？
'''■DefSet (移行テスト中 -> OK 2013/8/3 mb）
''' <summary>現在表示している内容の初期値を保存・出力する（指定する。１項目のみ）</summary>
''' <param name="curWriteWay">selector = 0 縦( = 0)・横( = 0)書き</param>
''' <param name="curFontSize">selector = 1 一般のフォントサイズ</param>
''' <param name="curTopXPos">selector = 2 最大のx座標</param>
''' <param name="curTopYPos">selector = 3 天のy座標</param>
''' <param name="curBotoomYPos">selector = 4 地のy座標</param>
''' <param name="curBasicPitch">selector = 5 基本の改列ピッチ</param>
''' <param name="curWordPitch">selector = 6 基本の文字ピッチ</param>
''' <param name="paperSize">selector = 7 現在の用紙IDに対する用紙サイズ　</param>
''' <param name="paperDirection">selector = 8 現在の用紙IDに対する用紙設定方向</param>
	Public Property DefSet (selector As Integer) As String
		Get
			Select Case selector
				Case 0
					Return defKeyWord("curWriteWay").ToString()
				Case 1
					Return defKeyWord("curFontSize").ToString()
			    Case 2
			    	Return defKeyWord("curTopXPos").ToString()
			    Case 3
			    	Return defKeyWord("curTopYPos").ToString()
			    Case 4
			    	Return defKeyWord("curBotoomYPos").ToString()
			    Case 5
			    	Return defKeyWord("curBasicPitch").ToString()
			    Case 6
			    	Return defKeyWord("curWordPitch").ToString()
			    Case 7
			    	Return defKeyWord("paperSize").ToString()
			    Case 8
			    	Return defKeyWord("paperDirection").ToString()
			End Select
		End Get
		Set(ByVal val As String)
			Select Case selector
				Case 0
					defKeyWord("curWriteWay") = Val
				Case 1
					defKeyWord("curFontSize") = Val	
			    Case 2
			    	defKeyWord("curTopXPos") = Val
			    Case 3
			    	defKeyWord("curTopYPos") = Val
			    Case 4
			    	defKeyWord("curBotoomYPos") = Val
			    Case 5
			    	defKeyWord("curBasicPitch") = Val
			    Case 6
			    	defKeyWord("curWordPitch") = Val
			    Case 7
			    	defKeyWord("paperSize") = Val
			    Case 8
			    	defKeyWord("paperDirection") = Val
			End Select
		End Set	
	End Property
	
'''■DefSetAll（移行テスト中 -> OK 2013/8/3 mb）
''' <summary>現在表示している内容の初期値を保存・出力する（すべての項目）</summary>
	Public Readonly Property DefSetAll() As Hashtable
		Get
			Return defKeyWord
		End Get
	End Property

'''■CurrentSet
''' <summary>現在表示している内容の用紙ID・文例IDを保存出力する</summary>
''' <param name="curSize">selector = 0 現在の用紙ID</param>
''' <param name="curStyle">selector = 1 現在の文例ID</param>
	Public Property CurrentSet(selector As Integer) As Integer
		Get
			Select Case selector
			    Case 0
					Return CInt(curSetting("curSize"))
			    Case 1
					Return CInt(curSetting("curStyle"))
			End Select
		End Get
		Set(ByVal val As Integer)
			Select Case selector
			    Case 0
					curSetting("curSize") = Val
			    Case 1
					curSetting("curStyle") = Val
			End Select
		End Set
	End Property

''''■CurrentWord
''' <summary>描画した文字情報を保管しておく
''' 1) 行
''' 2) 文字（それぞれの文字の情報を格納した配列を格納する配列）
''' 3) 文字の詳細 0 = 文字, 1 = フォントサイズ, 2 = y軸位置, 3 = x軸位置
''' </summary>
''' <param name="wordInLine">Array 文字情報</param>
''' <returns>Void</returns>
	Public Sub CurrentWord(wordInLine As ArrayList)
		curWord.Add(wordInLine)
	End Sub
	
''''■OptionaWord
''' <summary>挿入文字を保管しておく</summary>
''' <param name="DefKeyWord">Hashtable 文字</param>
''' <returns>Void</returns>
	Public sub OptionalWord(DefKeyWord As Hashtable, frm As PrintReport)
		With frm
		'挿入等に使う
		'Specific Part（HashTableに格納）
			optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue
			optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue
			optWord("Cmb_Title") = .Cmb_Title.SelectedValue
			optWord("Txt_Name") = .Txt_Name.Text
			optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue
			optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue
			optWord("Txt_DeadName") = .Txt_DeadName.Text
			optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue
			optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue
			optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue
			'日付
			Dim SctSql As New SelectSql()
			optWord("Cmb_Year") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & frm.Cmb_Year.SelectedValue)
			optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & frm.Cmb_Month.SelectedValue)
			optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & frm.Cmb_Day.SelectedValue)
			SctSql = Nothing
			'テキスト
			optWord("Txt_Add1") = .Txt_Add1.Text
			optWord("Txt_Add2") = .Txt_Add2.Text
			optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue
			optWord("Txt_HostName1") = .Txt_HostName1.Text
			optWord("Txt_HostName2") = .Txt_HostName2.Text
			optWord("Txt_HostName3") = .Txt_HostName3.Text
			optWord("Txt_HostName4") = .Txt_HostName4.Text
			optWord("Txt_PS1") = .Txt_PS1.Text
			optWord("Txt_PS2") = .Txt_PS2.Text
			optWord("Txt_PS3") = .Txt_PS3.Text
			optWord("Txt_PS4") = .Txt_PS4.Text
			optWord("Txt_PS5") = .Txt_PS5.Text
			optWord("Txt_PS6") = .Txt_PS6.Text
			'一般
			optWord("Common_Point") = DefKeyWord("curFontSize")
			optWord("Common_Font") = .Cmb_Font.text									'END: SelectedValue, SelectedIndex, Textの違い
			'フォントサイズ
			optWord("Cmb_PointTitle") = .Cmb_PointTitle.Text
			optWord("Cmb_PointName") = .Cmb_PointName.Text
			optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.Text
			optWord("Cmb_PointImibi") = .Cmb_PointImibi.Text
			optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.Text
			optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.Text
			optWord("Cmb_PointAdd1") = .Cmb_PointAdd1.Text
			optWord("Cmb_PointHostType") = .Cmb_PointHostType.Text
			optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.Text
			optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.Text	
			optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.Text
			optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.Text
			optWord("Cmb_PointPS1") = .Cmb_PointPS1.Text
			
'			2013/8/20 出力内容再度確認
'			For Each item As DictionaryEntry In optWord
'				System.Diagnostics.Debug.WriteLine(item.Key & "  = " & item.Value)
'			Next

			End With
	End Sub
	
End Class
