'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/06
' 時刻: 22:36
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class ClearForm

	'TODO: 全ての用紙を実装する	
''''■ClearForm
''' <summary>コントロールをフォーマット</summary>
''' <param name="sizeID">用紙サイズ</param>
''' <param name="Pr">PrintReport.vb</param>
''' <returns>Void</returns>	
''' 
Public Sub ClearForm(sizeID As Integer, Pr As PrintReport, Wc As WordContainer)
#If Not Debug Then
Try
#End If
    	Dim SctSql As New SelectSql
    	Dim currentDt As String()
    	currentDt = Today.ToString("yyyy/M/d").Split("/"c)
    	
    	Select Case sizeID
    		Case 0, 1, 2, 3, 4, 5      '奉書挨拶状
    			With Pr
    				'END: 配列に基本設定を入れておく -> それをセレクトで選択して読む
    				'.Cmb_Size.SelectedValue = 0							'END: Indexで統一？ -> コレクションに直接値を入れているところは
    				.Cmb_Font.SelectedIndex	= Wc.DefaultFontIndex			'END: 拡大率の問題
    				.Cmb_Magnify.SelectedValue = 50
    				.Cmb_Thickness.SelectedIndex = 	Wc.DefaultThickness
    				'END: 1)初期値, Enabled -> 変数に置き換える
    				'.Cmb_Style.SelectedValue = 0
    				'初期設定
    				.Cmb_Hyodai.SelectedValue = Wc.ComboTextStr(0) '"忌明志"						'add 2 lines 2013/9/22
    				.Txt_Namae.Text = Wc.ComboTextStr(1) '""
    				.Cmb_SeasonWord.SelectedValue = Wc.ComboTextStr(2) '"厳寒の候"
    				.Cmb_Time1.SelectedValue = Wc.ComboTextStr(3) '"先般"
    				.Cmb_Title.SelectedValue = Wc.ComboTextStr(4) '" 亡父 "
    				.Txt_Name.Text = Wc.ComboTextStr(5) '"儀"
    				.Cmb_DeathWay.SelectedValue = Wc.ComboTextStr(6) '"死去"
    				.Cmb_Time2.SelectedValue = Wc.ComboTextStr(7) '"本日"
    				.Txt_DeadName.Text = Wc.ComboTextStr(8) '""
    				.Cmb_Donation.SelectedValue = Wc.ComboTextStr(9) '"御花料"
    				.Cmb_Imibi.SelectedValue = Wc.ComboTextStr(10) '"忌明の法要"
    				.Cmb_EndWord.SelectedValue = Wc.ComboTextStr(11) '"敬具"
    				.Cmb_Year.SelectedValue = currentDt(0)
    				.Cmb_Month.SelectedValue = currentDt(1)
    				.Cmb_Day.SelectedValue = ""
    				.Txt_Add1.Text = Wc.ComboTextStr(15) '""
    				.Txt_Add2.Text = Wc.ComboTextStr(16) '""
    				.Cmb_HostType.SelectedValue = Wc.ComboTextStr(17) '"施主"
    				.Txt_HostName1.Text = Wc.ComboTextStr(18) '""
    				.txt_HostName2.Text = Wc.ComboTextStr(19) '""
    				.Txt_HostName3.Text = Wc.ComboTextStr(20) '""
    				.Txt_HostName4.Text = Wc.ComboTextStr(21) '""
    				.Txt_PS1.Text = Wc.ComboTextStr(22) '"追伸" 
    				.Txt_PS2.Text = Wc.ComboTextStr(23) '"ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"
    				.Txt_PS3.Text = Wc.ComboTextStr(24) '"お届けさせて頂きました"
    				.Txt_PS4.Text = Wc.ComboTextStr(25) '"御受納下さいます様お願い申し上げます"
    				.Txt_PS5.Text = Wc.ComboTextStr(26) '""
    				.Txt_PS6.Text = Wc.ComboTextStr(27) '""
    				'フォントサイズ
    				.Cmb_PointHyodai.SelectedIndex = Wc.ComboTextPoint(0) '0
    				.Cmb_PointNamae.SelectedIndex = Wc.ComboTextPoint(1) '0
    				.Cmb_PointTitle.SelectedIndex = Wc.ComboTextPoint(2) '34
    				.Cmb_PointName.SelectedIndex = Wc.ComboTextPoint(3) '34
    				.Cmb_PointDeadName.SelectedIndex = Wc.ComboTextPoint(4) '0
    				.Cmb_PointImibi.SelectedIndex = Wc.ComboTextPoint(5) '34
    				.Cmb_PointEndWord.SelectedIndex = Wc.ComboTextPoint(6) '34
    				.Cmb_PointCeremonyDate.SelectedIndex = Wc.ComboTextPoint(7) '22
    				.Cmb_PointAdd1.SelectedIndex = Wc.ComboTextPoint(8) '19
    				.Cmb_PointHostType.SelectedIndex = Wc.ComboTextPoint(9) '0
    				.Cmb_PointHostName1.SelectedIndex = Wc.ComboTextPoint(10) '34
    				.Cmb_PointHostName2.SelectedIndex = Wc.ComboTextPoint(11) '34
    				.Cmb_PointHostName3.SelectedIndex = Wc.ComboTextPoint(12) '34
    				.Cmb_PointHostName4.SelectedIndex = Wc.ComboTextPoint(13) '34
    				.Cmb_PointPS1.SelectedIndex = Wc.ComboTextPoint(14) '17
    				'使用可・不可設定
    				.Cmb_Hyodai.Enabled = CBool(Wc.CmbTxtPntEnabled(0))
    				.Txt_Namae.Enabled = CBool(Wc.CmbTxtPntEnabled(1))
    				.Cmb_SeasonWord.Enabled = CBool(Wc.CmbTxtPntEnabled(2))
    				.Cmb_Time1.Enabled = CBool(Wc.CmbTxtPntEnabled(3))
    				.Cmb_Title.Enabled = CBool(Wc.CmbTxtPntEnabled(4))
    				.Txt_Name.Enabled = CBool(Wc.CmbTxtPntEnabled(5))
    				.Cmb_DeathWay.Enabled = CBool(Wc.CmbTxtPntEnabled(6))
    				.Cmb_Time2.Enabled = CBool(Wc.CmbTxtPntEnabled(7))
    				.Txt_DeadName.Enabled = CBool(Wc.CmbTxtPntEnabled(8))
    				.Cmb_Donation.Enabled = CBool(Wc.CmbTxtPntEnabled(9))
    				.Cmb_Imibi.Enabled = CBool(Wc.CmbTxtPntEnabled(10))
    				.Cmb_EndWord.Enabled = CBool(Wc.CmbTxtPntEnabled(11))
    				.Cmb_Year.Enabled = CBool(Wc.CmbTxtPntEnabled(12))
    				.Cmb_Month.Enabled = CBool(Wc.CmbTxtPntEnabled(13))
    				.Cmb_Day.Enabled = CBool(Wc.CmbTxtPntEnabled(14))
    				.Txt_Add1.Enabled = CBool(Wc.CmbTxtPntEnabled(15))
    				.Txt_Add2.Enabled = CBool(Wc.CmbTxtPntEnabled(16))
    				.Cmb_HostType.Enabled = CBool(Wc.CmbTxtPntEnabled(17))
    				.Txt_HostName1.Enabled = CBool(Wc.CmbTxtPntEnabled(18))
    				.txt_HostName2.Enabled = CBool(Wc.CmbTxtPntEnabled(19))
    				.Txt_HostName3.Enabled = CBool(Wc.CmbTxtPntEnabled(20))
    				.Txt_HostName4.Enabled = CBool(Wc.CmbTxtPntEnabled(21))
    				.Txt_PS1.Enabled = CBool(Wc.CmbTxtPntEnabled(22)) 
    				.Txt_PS2.Enabled = CBool(Wc.CmbTxtPntEnabled(23))
    				.Txt_PS3.Enabled = CBool(Wc.CmbTxtPntEnabled(24))
    				.Txt_PS4.Enabled = CBool(Wc.CmbTxtPntEnabled(25))
    				.Txt_PS5.Enabled = CBool(Wc.CmbTxtPntEnabled(26))
    				.Txt_PS6.Enabled = CBool(Wc.CmbTxtPntEnabled(27))	

    				.Cmb_PointHyodai.Enabled = CBool(Wc.CmbTxtPntEnabled(28))
    				.Cmb_PointNamae.Enabled = CBool(Wc.CmbTxtPntEnabled(29))
    				.Cmb_PointTitle.Enabled = CBool(Wc.CmbTxtPntEnabled(30))
    				.Cmb_PointName.Enabled = CBool(Wc.CmbTxtPntEnabled(31))
    				.Cmb_PointDeadName.Enabled = CBool(Wc.CmbTxtPntEnabled(32))
    				.Cmb_PointImibi.Enabled = CBool(Wc.CmbTxtPntEnabled(33))
    				.Cmb_PointEndWord.Enabled = CBool(Wc.CmbTxtPntEnabled(34))
    				.Cmb_PointCeremonyDate.Enabled = CBool(Wc.CmbTxtPntEnabled(35))
    				.Cmb_PointAdd1.Enabled = CBool(Wc.CmbTxtPntEnabled(36))
    				.Cmb_PointHostType.Enabled = CBool(Wc.CmbTxtPntEnabled(37))
    				.Cmb_PointHostName1.Enabled = CBool(Wc.CmbTxtPntEnabled(38))
    				.Cmb_PointHostName2.Enabled = CBool(Wc.CmbTxtPntEnabled(39))
    				.Cmb_PointHostName3.Enabled = CBool(Wc.CmbTxtPntEnabled(40))
    				.Cmb_PointHostName4.Enabled = CBool(Wc.CmbTxtPntEnabled(41))
    				.Cmb_PointPS1.Enabled = CBool(Wc.CmbTxtPntEnabled(42))
    				'挿入文字
    				Wc.optWord("Cmb_Hyodai") = .Cmb_Hyodai.SelectedValue.ToString()		'add 1 lines 2013/9/24
    				Wc.optWord("Txt_Namae") = .Txt_Namae.Text
    				Wc.optWord("Cmb_SeasonWord")= .Cmb_SeasonWord.SelectedValue.ToString()
    				Wc.optWord("Cmb_Time1") = .Cmb_Time1.SelectedValue.ToString()
    				Wc.optWord("Cmb_Title") = .Cmb_Title.SelectedValue.ToString()
    				Wc.optWord("Txt_Name") = .Txt_Name.Text
    				Wc.optWord("Cmb_DeathWay") = .Cmb_DeathWay.SelectedValue.ToString()
    				Wc.optWord("Cmb_Time2") = .Cmb_Time2.SelectedValue.ToString()
    				Wc.optWord("Txt_DeadName") = .Txt_DeadName.Text
    				Wc.optWord("Cmb_Donation") = .Cmb_Donation.SelectedValue.ToString()
    				Wc.optWord("Cmb_Imibi") = .Cmb_Imibi.SelectedValue.ToString()
    				Wc.optWord("Cmb_EndWord") = .Cmb_EndWord.SelectedValue.ToString()
    				'日付
    				Wc.optWord("Cmb_Year") = SctSql.GetOneSql("SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = '" & .Cmb_Year.SelectedValue.ToString() & "'")
    				Wc.optWord("Cmb_Month") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = '" & .Cmb_Month.SelectedValue.ToString() & "'")
    				Wc.optWord("Cmb_Day") = SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = '" & .Cmb_Day.SelectedValue.ToString() & "'")
    				SctSql = Nothing
    				Wc.optWord("Txt_Add1") = .Txt_Add1.Text
    				Wc.optWord("Txt_Add2") = .Txt_Add2.Text
    				Wc.optWord("Cmb_HostType") = .Cmb_HostType.SelectedValue.ToString()
    				Wc.optWord("Txt_HostName1") = .Txt_HostName1.Text
    				Wc.optWord("Txt_HostName2") = .Txt_HostName2.Text
    				Wc.optWord("Txt_HostName3") = .Txt_HostName3.Text
    				Wc.optWord("Txt_HostName4") = .Txt_HostName4.Text
    				Wc.optWord("Txt_PS1") = .Txt_PS1.Text
    				Wc.optWord("Txt_PS2") = .Txt_PS2.Text
    				Wc.optWord("Txt_PS3") = .Txt_PS3.Text
    				Wc.optWord("Txt_PS4") = .Txt_PS4.Text
    				Wc.optWord("Txt_PS5") = .Txt_PS5.Text
    				Wc.optWord("Txt_PS6") = .Txt_PS6.Text
    				'一般
    				Wc.optWord("Common_Point") = Wc.DefSet(1)
    				Wc.optWord("Cmb_Font") = .Cmb_Font.text										'END: SelectedValue, SelectedIndex = コレクションで設定した時 = Text
    				Wc.optWord("Cmb_Magnify") = .Cmb_Magnify.SelectedValue.ToString()
    				Wc.optWord("Cmb_Thickness") = .Cmb_Thickness.SelectedValue.ToString()
    				Wc.optWord("Cmb_Thickness_Txt") = .Cmb_Thickness.Text							'印刷用
    				'フォントサイズ
    				Wc.optWord("Cmb_PointHyodai") = .Cmb_PointHyodai.Text							'add 2 lines 2013/9/24 
    				Wc.optWord("Cmb_PointNamae") = .Cmb_PointNamae.Text
    				Wc.optWord("Cmb_PointTitle") = .Cmb_PointTitle.Text
    				Wc.optWord("Cmb_PointName") = .Cmb_PointName.Text
    				Wc.optWord("Cmb_PointDeadName") = .Cmb_PointDeadName.Text
    				Wc.optWord("Cmb_PointImibi") = .Cmb_PointImibi.Text
    				Wc.optWord("Cmb_PointEndWord") = .Cmb_PointEndWord.Text
    				Wc.optWord("Cmb_PointCeremonyDate") = .Cmb_PointCeremonyDate.Text
    				Wc.optWord("Cmb_PointAdd1") = .Cmb_PointAdd1.Text
    				Wc.optWord("Cmb_PointHostType") = .Cmb_PointHostType.Text
    				Wc.optWord("Cmb_PointHostName1") = .Cmb_PointHostName1.Text
    				Wc.optWord("Cmb_PointHostName2") = .Cmb_PointHostName2.Text	
    				Wc.optWord("Cmb_PointHostName3") = .Cmb_PointHostName3.Text
    				Wc.optWord("Cmb_PointHostName4") = .Cmb_PointHostName4.Text
    				Wc.optWord("Cmb_PointPS1") = .Cmb_PointPS1.Text
    			End With
    		Case Else
    			'TODO: 追加する
    	End Select
#If Not Debug Then
Catch ex As Exception
	
End Try	
#End If
	End Sub
	
End Class
