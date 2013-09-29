'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/13
' 時刻: 10:19
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Diagnostics.Debug
Public Class WordContainer
	
	Private Const colRate As Single = 255
	Private Const defFontIndex As Integer = 18
	Private Const defThickness As Integer = 8
	
	Private curSetting As New Hashtable
	Private defKeyWord As New Hashtable
	private optionalWord As New Hashtable
	Private tempCurWord As New arraylist
	Private currentWord As New ArrayList
	Private mainSentence As New ArrayList
	Private envList As New Hashtable
	
'''■ColorRate	
''' <summary></summary>
	Public Readonly Property ColorRate() As Single
		Get
			Return colRate
		End Get
	End Property
	
'''■DefaultFontIndex
''' <summary></summary>
	Public ReadOnly Property DefaultFontIndex() As Integer
		Get
			Return defFontIndex
		End Get
	End Property
	
'''■DefaultThickness
''' <summary></summary>
	Public ReadOnly Property DefaultThickness() As Integer
		Get
			Return defThickness
		End Get
	End Property
	
'''■EnviromentList
''' <summary></summary>
	Public ReadOnly Property ReadEnvList(hashKey As String) As ArrayList
		Get
			Return DirectCast(envList(hashKey), ArrayList)
		End Get
	End Property

	Public Writeonly Property SetEnvList(hashKey As String) As ArrayList
		Set(value As ArrayList)
			envList.Add(hashKey, value)
		End Set
	End Property
		
'''■mainTxt
''' <summary></summary>
	Public Property mainTxt() As ArrayList
		Get
			Return mainSentence
		End get
		
		Set(value As ArrayList)
			For i As Integer = 0 To value.Count -1 Step 1
				mainSentence.Add(value(i))
			Next i
		End Set
	End Property
	
'END:　この辺りまとまらないか？
'''■DefSet (移行テスト中 -> OK 2013/8/3 mb）
''' <summary>現在表示している内容の初期値を保存・出力する（指定する。１項目のみ）</summary>
''' <param name="curWriteWay">selector = 0 縦( = 0)・横( = 0)書き</param>
''' <param name="curFontSize">selector = 1 一般のフォントサイズ</param>
''' <param name="curTopXPos">selector = 2 最大のx座標</param>
''' <param name="curTopYPos">selector = 3 天のy座標</param>
''' <param name="curBottomYPos">selector = 4 地のy座標</param>
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
			    	Return defKeyWord("curBottomYPos").ToString()
			    Case 5
			    	Return defKeyWord("curBasicPitch").ToString()
			    Case 6
			    	Return defKeyWord("curWordPitch").ToString()
			    Case 7
			    	Return defKeyWord("paperSize").ToString()
			    Case 8
			    	Return defKeyWord("paperDirection").ToString()
			    Case Else
			    	Return Nothing
			End Select
		End Get
		
		Set(ByVal value As String)
			Select Case selector
				Case 0
					defKeyWord("curWriteWay") = value
				Case 1
					defKeyWord("curFontSize") = value	
			    Case 2
			    	defKeyWord("curTopXPos") = value
			    Case 3
			    	defKeyWord("curTopYPos") = value
			    Case 4
			    	defKeyWord("curBottomYPos") = value
			    Case 5
			    	defKeyWord("curBasicPitch") = value
			    Case 6
			    	defKeyWord("curWordPitch") = value
			    Case 7
			    	defKeyWord("paperSize") = value
			    Case 8
			    	defKeyWord("paperDirection") = value
			End Select
		End Set	
	
	End Property
	
'''■CurrentSet
''' <summary>現在表示している内容の用紙ID・文例IDを保存出力する</summary>
''' <param name="curSize">selector = 0 現在の用紙ID</param>
''' <param name="curStyle">selector = 1 現在の文例ID</param>
	Public Property CurrentSet(hashKey As String) As Integer
		Get
			Return CInt(curSetting(hashKey))
		End Get
		
		Set(ByVal value As Integer)
			curSetting(hashKey) = value
		End Set
		
	End Property
	
'''■curWord
''' <summary>描画した文字情報を保管しておく
''' 1) 行
''' 2) 文字（それぞれの文字の情報を格納した配列を格納する配列）
''' 3) 文字の詳細 0 = 文字, 1 = フォントサイズ, 2 = y軸位置, 3 = x軸位置
''' </summary>
''' <param name="wordInLine">ArrayList 文字情報</param>
''' <returns>文字配列を返す</returns>
	Public Property curWord() As ArrayList
		Get
			Return currentWord
		End Get
		
		Set(ByVal value As ArrayList)
			currentWord.Add(value)
		End Set
	End Property
	
'''■TempCurrentWord	
''' <summary>拡大用のデータを一時的に保持する</summary>
''' <param name="selector">Optional Integer 0 = 追加 1 = クリア</param>
''' <returns>拡大用文字配列を格納、出力する</returns>
	Public Property TempCurrentWord(Optional selector As integer = 0) As arraylist
		Get
			return tempCurWord
		End Get
		
		Set(ByVal value As arraylist)
			Select Case selector
				Case 0
					tempCurWord.Add(value)
				Case 1
					tempCurWord.Clear()
			End Select
		End Set
	End Property
	
'''■optWord
''' <summary>挿入文字を保管しておく</summary>
''' <param name="hashKey">ハッシュテーブルのキー</param>
''' <returns>Void</returns>
	Public Property optWord(hashKey As String) As String
		Get
			Return optionalWord(hashKey).ToString()
		End Get
		
		Set (Value As String)
			optionalWord(hashKey) = value
		End Set
	End Property
	
	End Class

# Region "Comment Out"

'	Public sub SetOptionalWord(selector As Integer, Pr As PrintReport)
'		Select Case selector
'			Case 0
'				Dim SctSql As New SelectSql
'				With Pr
'					'挿入等に使う
'					'Specific Part（HashTableに格納）
'					optWord("Cmb_Hyodai") = .Cmb_Hyodai.SelectedValue.ToString()		'add 1 lines 2013/9/24
'					optWord("Txt_Namae") = .Txt_Namae.Text
'					optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue.ToString()
'					optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue.ToString()
'					optWord("Cmb_Title") = .Cmb_Title.SelectedValue.ToString()
'					optWord("Txt_Name") = .Txt_Name.Text
'					optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue.ToString()
'					optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue.ToString()
'					optWord("Txt_DeadName") = .Txt_DeadName.Text
'					optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue.ToString()
'					optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue.ToString()
'					optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue.ToString()
'					'日付
'					optWord("Cmb_Year") = SctSql.GetOneSql("SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = '" & .Cmb_Year.SelectedValue.ToString() & "'")
'					optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = '" & .Cmb_Month.SelectedValue.ToString() & "'")
'					optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = '" & .Cmb_Day.SelectedValue.ToString() & "'")
'					SctSql = Nothing
''					'テキスト
'					optWord("Txt_Add1") = .Txt_Add1.Text
'					optWord("Txt_Add2") = .Txt_Add2.Text
'					optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue.ToString()
'					optWord("Txt_HostName1") = .Txt_HostName1.Text
'					optWord("Txt_HostName2") = .Txt_HostName2.Text
'					optWord("Txt_HostName3") = .Txt_HostName3.Text
'					optWord("Txt_HostName4") = .Txt_HostName4.Text
'					optWord("Txt_PS1") = .Txt_PS1.Text
'					optWord("Txt_PS2") = .Txt_PS2.Text
'					optWord("Txt_PS3") = .Txt_PS3.Text
'					optWord("Txt_PS4") = .Txt_PS4.Text
'					optWord("Txt_PS5") = .Txt_PS5.Text
'					optWord("Txt_PS6") = .Txt_PS6.Text
'					'一般
'					optWord("Common_Point") = DefSet(1)
'					optWord("Cmb_Font") = .Cmb_Font.text										'END: SelectedValue, SelectedIndex = コレクションで設定した時 = Text
'					optWord("Cmb_Magnify") = .Cmb_Magnify.SelectedValue.ToString()
'					optWord("Cmb_Thickness") = .Cmb_Thickness.SelectedValue.ToString()
'					optWord("Cmb_Thickness_Txt") = .Cmb_Thickness.Text							'印刷用
'					'フォントサイズ
'					optWord("Cmb_PointHyodai") = .Cmb_PointHyodai.Text							'add 2 lines 2013/9/24 
'					optWord("Cmb_PointNamae") = .Cmb_PointNamae.Text
'					
'					optWord("Cmb_PointTitle") = .Cmb_PointTitle.Text
'					optWord("Cmb_PointName") = .Cmb_PointName.Text
'					optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.Text
'					optWord("Cmb_PointImibi") = .Cmb_PointImibi.Text
'					optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.Text
'					optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.Text
'					optWord("Cmb_PointAdd1") = .Cmb_PointAdd1.Text
'					optWord("Cmb_PointHostType") = .Cmb_PointHostType.Text
'					optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.Text
'					optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.Text	
'					optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.Text
'					optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.Text
'					optWord("Cmb_PointPS1") = .Cmb_PointPS1.Text
'					
'					'2013/8/20 出力内容再度確認
'					'For Each item As DictionaryEntry In optWord
'					'	System.Diagnostics.Debug.WriteLine(item.Key & "  = " & item.Value)
'					'Next
'					
'				End With
'			Case Else
'				Exit Sub 'ダミー
'		End Select
'	End Sub
	

'Public curWord As New ArrayList

'''■CurrentWord
''' <summary>描画した文字情報を保管しておく
''' 1) 行
''' 2) 文字（それぞれの文字の情報を格納した配列を格納する配列）
''' 3) 文字の詳細 0 = 文字, 1 = フォントサイズ, 2 = y軸位置, 3 = x軸位置
''' </summary>
''' <param name="wordInLine">Array 文字情報</param>
''' <returns>Void</returns>
	'Public Sub CurrentWord(wordInLine As ArrayList)
	'	curWord.Add(wordInLine)
	'End Sub

''''■DefSetAll（移行テスト中 -> OK 2013/8/3 mb）
'''' <summary>現在表示している内容の初期値を保存・出力する（すべての項目）</summary>
'	Public Readonly Property DefSetAll() As Hashtable
'		Get
'			Return defKeyWord
'		End Get
'	End Property


'	Public sub OptionalWord(DefKeyWord As Hashtable, frm As PrintReport)
'	Public sub OptionalWord(Pr As PrintReport)
'		With Pr
'		'挿入等に使う
'		'Specific Part（HashTableに格納）
'			optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue
'			optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue
'			optWord("Cmb_Title") = .Cmb_Title.SelectedValue
'			optWord("Txt_Name") = .Txt_Name.Text
'			optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue
'			optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue
'			optWord("Txt_DeadName") = .Txt_DeadName.Text
'			optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue
'			optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue
'			optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue
'			'日付
'			Dim SctSql As New SelectSql()
'			optWord("Cmb_Year") = SctSql.GetOneSql("SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = '" & Pr.Cmb_Year.SelectedValue & "'")
'			optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = '" & Pr.Cmb_Month.SelectedValue & "'")
'			optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = '" & Pr.Cmb_Day.SelectedValue & "'")
'			SctSql = Nothing
'			'テキスト
'			optWord("Txt_Add1") = .Txt_Add1.Text
'			optWord("Txt_Add2") = .Txt_Add2.Text
'			optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue
'			optWord("Txt_HostName1") = .Txt_HostName1.Text
'			optWord("Txt_HostName2") = .Txt_HostName2.Text
'			optWord("Txt_HostName3") = .Txt_HostName3.Text
'			optWord("Txt_HostName4") = .Txt_HostName4.Text
'			optWord("Txt_PS1") = .Txt_PS1.Text
'			optWord("Txt_PS2") = .Txt_PS2.Text
'			optWord("Txt_PS3") = .Txt_PS3.Text
'			optWord("Txt_PS4") = .Txt_PS4.Text
'			optWord("Txt_PS5") = .Txt_PS5.Text
'			optWord("Txt_PS6") = .Txt_PS6.Text
'			'一般
'			optWord("Common_Point") = DefSet(1)
'			optWord("Cmb_Font") = .Cmb_Font.text									'END: SelectedValue, SelectedIndex = コレクションで設定した時 = Text
'			optWord("Cmb_Magnify") = .Cmb_Magnify.SelectedValue
'			optWord("Cmb_Thickness") = .Cmb_Thickness.SelectedValue
'			optWord("Cmb_Thickness_Txt") = .Cmb_Thickness.Text							'印刷用
'			'フォントサイズ
'			optWord("Cmb_PointTitle") = .Cmb_PointTitle.Text
'			optWord("Cmb_PointName") = .Cmb_PointName.Text
'			optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.Text
'			optWord("Cmb_PointImibi") = .Cmb_PointImibi.Text
'			optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.Text
'			optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.Text
'			optWord("Cmb_PointAdd1") = .Cmb_PointAdd1.Text
'			optWord("Cmb_PointHostType") = .Cmb_PointHostType.Text
'			optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.Text
'			optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.Text	
'			optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.Text
'			optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.Text
'			optWord("Cmb_PointPS1") = .Cmb_PointPS1.Text
'			
''			2013/8/20 出力内容再度確認
''			For Each item As DictionaryEntry In optWord
''				System.Diagnostics.Debug.WriteLine(item.Key & "  = " & item.Value)
''			Next
'
'			End With
'	End Sub
#End region