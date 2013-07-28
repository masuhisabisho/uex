﻿'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/13
' 時刻: 10:19
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class WordContainer
	
	Private curSize As Integer				'現在の用紙ID
	Private curStyle As Integer				'現在の文例ID
	Private paperSize As String				'現在の用紙IDに対する用紙サイズ
	Private paperDirection As String		'現在の用紙IDに対する用紙設定方向
	
	Public optWord As New Hashtable()
	Public curWord As New ArrayList()

'''■CurSizeStorager
''' <summary>現在表示している内容の用紙IDを保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurSizeStorager() As Integer
		Get
			Return curSize
		End Get
		Set(ByVal val As Integer)
			curSize = val
		End Set
	End Property
	
'''■CurStyleStorager
''' <summary>現在表示している内容の文例IDを保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurStyleStorager() As Integer
		Get
			Return curStyle
		End Get
		Set(ByVal val As Integer)
			curStyle = val
		End Set
	End Property
	
'''■CurPPSizeStorager
''' <summary>現在表示している内容の用紙設定名を保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurPPSizeStorager() As String
		Get
			Return paperSize
		End Get
		Set(ByVal val As String)
			paperSize = val
		End Set
	End Property
	
'''■CurPPDirecStorager
''' <summary>現在表示している内容の印刷方向を保存する</summary>
''' <returns>用紙ID</returns>
	Public Property CurPPDirecStorager() As String
		Get
			Return paperDirection
		End Get
		Set(ByVal val As String)
			paperDirection = val
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
''' <param name="defSetAr">String() 文字</param>
''' <returns>Void</returns>
	Public sub OptionalWord(defsetAr As String(), frm As PrintReport)
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
'			optWord("Cmb_Year") = .Cmb_Year.SelectedIndex
'			optWord("Cmb_Month") = .Cmb_Month.SelectedIndex
'			optWord("Cmb_Day") = .Cmb_Day.SelectedIndex
			'日付
			Dim SctSql As New SelectSql()
'			Dim resultWareki As String = ""
'			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & frm.Cmb_Year.SelectedValue)
'			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & frm.Cmb_Month.SelectedValue)
'			resultWareki &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & frm.Cmb_Day.SelectedValue)
'			optWord("Txt_CeremonyDate") = resultWareki
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
			optWord("Common_Point") = defSetAr(1)									'共通フォントサイズ
			optWord("Common_Font") = .Cmb_Font.text									'CHK: SelectedValue, SelectedIndex, Textの違い
			'フォントサイズ
			optWord("Cmb_PointTitle") = .Cmb_PointTitle.SelectedIndex
			optWord("Cmb_PointName") = .Cmb_PointName.SelectedIndex
			optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.SelectedValue
			optWord("Cmb_PointImibi") = .Cmb_PointImibi.SelectedIndex
			optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.SelectedIndex
			optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.SelectedIndex
			optWord("Cmb_PointAdd1") = .Cmb_PointAdd1.SelectedIndex
			optWord("Cmb_PointHostType") = .Cmb_PointHostType.SelectedValue
			optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.SelectedValue
			optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.SelectedValue	
			optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.SelectedValue
			optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.SelectedValue
			optWord("Cmb_PointPS1") = .Cmb_PointPS1.SelectedIndex
			End With
	End Sub
	
End Class
