'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/06
' 時刻: 22:36
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class ClearForm
	Private Const defaultFontIndex As Integer = 18
	Private Const defaultThickness As Integer = 8
	'TODO: 全ての用紙を実装する	
''''■ClearForm
''' <summary>Format form</summary>
''' <param name="reportType">Kind of paper sytle</param>
''' <returns>Void</returns>	
    Public Sub ClearForm(size As Integer, Pr As PrintReport)

        Dim currentDt As String()
        currentDt = Today.ToString("yyyy/M/d").Split("/")
        Select Case size
        	Case 0      '奉書挨拶状
                With Pr
                    'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
                    '.Cmb_Size.SelectedValue = 0							'END: Indexで統一？ -> コレクションに直接値を入れているところは
                    .Cmb_Font.SelectedIndex	= defaultFontIndex			'CHK: 拡大率の問題
                    .Cmb_Magnify.SelectedValue = 50
                    .Cmb_Thickness.SelectedIndex = 	defaultThickness
                    
                    '初期設定の値は下の通り
                    'Specific part
                    .Cmb_Style.SelectedValue = 0
                    
                    .Cmb_Hyodai.SelectedValue = "忌明志"						'add 2 lines 2013/9/22
                    .Cmb_Hyodai.Enabled = False
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
                    .Cmb_HostType.SelectedValue = "施主"
                    .Cmb_HostType.Enabled = False
                    .Txt_PS1.Text = "追伸" 
                    .Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"
                    .Txt_PS3.Text = "お届けさせて頂きました"
                    .Txt_PS4.Text = "御受納下さいます様お願い申し上げます"
                    .Txt_PS5.Text = ""
                    .Txt_PS6.Text = ""

                    'Font Size
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
				End with
        	Case 1      '奉書挨拶状
                With Pr
                    'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
                    '.Cmb_Size.SelectedValue = 0							'END: Indexで統一？ -> コレクションに直接値を入れているところは
                    .Cmb_Font.SelectedIndex	= defaultFontIndex			'CHK: 拡大率の問題
                    .Cmb_Magnify.SelectedValue = 50
                    .Cmb_Thickness.SelectedIndex = defaultThickness
                    
                    '初期設定の値は下の通り
                    'Specific part
                    .Cmb_Style.SelectedValue = 0
                    
                    .Cmb_Hyodai.SelectedValue = "忌明志"
                    .Txt_Namae.Text = ""
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
                    .Cmb_Day.SelectedValue = "印刷無し"
                    .Cmb_HostType.SelectedValue = "施主"
                    .Cmb_HostType.Enabled = False
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
			End with
        End Select
       End Sub
	
End Class
