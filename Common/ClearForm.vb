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
''' <summary>Format form</summary>
''' <param name="reportType">Kind of paper sytle</param>
''' <returns>Void</returns>	
''' 
    Public Sub ClearForm(size As Integer, Pr As PrintReport, Wc As WordContainer)
    	Dim SctSql As New SelectSql
    	Dim currentDt As String()
    	currentDt = Today.ToString("yyyy/M/d").Split("/")
    	
    	Select Case size
    		Case 0      '奉書挨拶状
    			With Pr
    				'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
    				'.Cmb_Size.SelectedValue = 0							'END: Indexで統一？ -> コレクションに直接値を入れているところは
    				.Cmb_Font.SelectedIndex	= Wc.DefaultFontIndex			'CHK: 拡大率の問題
    				.Cmb_Magnify.SelectedValue = 50
    				.Cmb_Thickness.SelectedIndex = 	Wc.DefaultThickness
    				
    				'初期設定の値は下の通り
    				'Specific part
    				.Cmb_Style.SelectedValue = 0
    				
    				.Cmb_Hyodai.SelectedValue = "忌明志"						'add 2 lines 2013/9/22
    				.Cmb_Hyodai.Enabled = False
    				.Txt_Namae.Text = ""
    				.Txt_Namae.Enabled = False
    				.Cmb_SeasonWord.SelectedValue = "厳寒の候"
    				.Cmb_Time1.SelectedValue = "先般"
    				.Cmb_Title.SelectedValue = " 亡父 "
    				.Txt_Name.Text = "儀"
    				.Cmb_DeathWay.SelectedValue = "死去"
    				.Cmb_Time2.SelectedValue = "本日"
    				.Cmb_Time2.Enabled = False
    				.Txt_DeadName.Text = ""
    				.Txt_DeadName.Enabled = False
    				.Cmb_Donation.SelectedValue = "御花料"
    				.Cmb_Donation.Enabled = False
    				.Cmb_Imibi.SelectedValue = "忌明の法要"
    				.Cmb_EndWord.SelectedValue = "敬具"
    				.Cmb_Year.SelectedValue = currentDt(0)
    				.Cmb_Month.SelectedValue = currentDt(1)
    				.Cmb_Day.SelectedValue = ""
    				.Txt_Add1.Text = ""
    				.Txt_Add2.Text = ""
    				.Cmb_HostType.SelectedValue = "施主"
    				.Cmb_HostType.Enabled = False
    				.Txt_HostName1.Text = ""
    				.txt_HostName2.Text = ""
    				.Txt_HostName3.Text = ""
    				.Txt_HostName4.Text = ""
    				.Txt_PS1.Text = "追伸" 
    				.Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"
    				.Txt_PS3.Text = "お届けさせて頂きました"
    				.Txt_PS4.Text = "御受納下さいます様お願い申し上げます"
    				.Txt_PS5.Text = ""
    				.Txt_PS6.Text = ""
    				
    				'Font Size
    				.Cmb_PointHyodai.SelectedIndex = 0
    				.Cmb_PointHyodai.Enabled = False
    				.Cmb_PointNamae.SelectedIndex = 0
    				.Cmb_PointNamae.Enabled = False
    				.Cmb_PointTitle.SelectedIndex = 34
    				.Cmb_PointName.SelectedIndex = 34
    				.Cmb_PointDeadName.SelectedIndex = 0
    				.Cmb_PointDeadName.Enabled = False
    				.Cmb_PointImibi.SelectedIndex = 34
    				.Cmb_PointEndWord.SelectedIndex = 34
    				.Cmb_PointCeremonyDate.SelectedIndex = 22
    				.Cmb_PointAdd1.SelectedIndex = 19
    				.Cmb_PointHostType.SelectedIndex = 0
    				.Cmb_PointHostType.Enabled = False
    				.Cmb_PointHostName1.SelectedIndex = 34
    				.Cmb_PointHostName2.SelectedIndex = 34
    				.Cmb_PointHostName3.SelectedIndex = 34
    				.Cmb_PointHostName4.SelectedIndex = 34
    				.Cmb_PointPS1.SelectedIndex = 17
    				
    				'挿入等に使う
    				'Specific Part（HashTableに格納）
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
    				'					'テキスト
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
    			End with
    		Case 1      '奉書挨拶状
    			With Pr
    				'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
    				'.Cmb_Size.SelectedValue = 0							'END: Indexで統一？ -> コレクションに直接値を入れているところは
    				.Cmb_Font.SelectedIndex	= Wc.DefaultFontIndex			'CHK: 拡大率の問題
    				.Cmb_Magnify.SelectedValue = 50
    				.Cmb_Thickness.SelectedIndex = Wc.DefaultThickness
    				
    				'初期設定の値は下の通り
    				'Specific part
    				.Cmb_Style.SelectedValue = 0
    				.Cmb_Hyodai.SelectedValue = "忌明志"
    				.Cmb_Hyodai.Enabled = True
    				.Txt_Namae.Text = ""
    				.Txt_Namae.Enabled = True 
    				.Cmb_SeasonWord.SelectedValue = "厳寒の候"
    				.Cmb_Time1.SelectedValue = "先般"
    				.Cmb_Title.SelectedValue = " 亡父 "
    				.Txt_Name.Text = "儀"
    				.Cmb_DeathWay.SelectedValue = "死去"
    				.Cmb_Time2.SelectedValue = "本日"
    				.Cmb_Time2.Enabled = False
    				.Txt_DeadName.Text = ""
    				.Txt_DeadName.Enabled = False
    				.Cmb_Donation.SelectedValue = "御花料"
    				.Cmb_Donation.Enabled = False
    				.Cmb_Imibi.SelectedValue = "忌明の法要"
    				.Cmb_EndWord.SelectedValue = "敬具"
    				.Cmb_Year.SelectedValue = currentDt(0)
    				.Cmb_Month.SelectedValue = currentDt(1)
    				.Cmb_Day.SelectedValue = ""
    				.Txt_Add1.Text = ""
    				.Txt_Add2.Text = ""
    				.Cmb_HostType.SelectedValue = "施主"
    				.Cmb_HostType.Enabled = False
    				.Txt_HostName1.Text = ""
    				.txt_HostName2.Text = ""
    				.Txt_HostName3.Text = ""
    				.Txt_HostName4.Text = ""
    				.Txt_PS1.Text = "追伸" 
    				.Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"
    				.Txt_PS3.Text = "お届けさせて頂きました"
    				.Txt_PS4.Text = "御受納下さいます様お願い申し上げます"
    				
    				'Font Size
    				.Cmb_PointHyodai.SelectedIndex = 40
    				.Cmb_PointNamae.SelectedIndex = 40
    				.Cmb_PointTitle.SelectedIndex = 15
    				.Cmb_PointName.SelectedIndex = 15
    				.Cmb_PointDeadName.SelectedIndex = 0
    				.Cmb_PointDeadName.Enabled = False
    				.Cmb_PointImibi.SelectedIndex = 15
    				.Cmb_PointEndWord.SelectedIndex = 15
    				.Cmb_PointCeremonyDate.SelectedIndex = 13
    				.Cmb_PointAdd1.SelectedIndex = 12
    				.Cmb_PointHostType.SelectedIndex = 0
    				.Cmb_PointHostType.Enabled = False
    				.Cmb_PointHostName1.SelectedIndex = 27
    				.Cmb_PointHostName2.SelectedIndex = 27
    				.Cmb_PointHostName3.SelectedIndex = 27
    				.Cmb_PointHostName4.SelectedIndex = 27
    				.Cmb_PointPS1.SelectedIndex = 13
    				
    				'挿入等に使う
    				'Specific Part（HashTableに格納）
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
    				'					'テキスト
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
    	End Select
	End Sub
	
End Class
