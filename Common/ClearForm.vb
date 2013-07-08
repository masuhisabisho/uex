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
    Public Sub ClearForm(reportType As Integer, frm As PrintReport)

        Dim currentDt As String()
        currentDt = Today.ToString("yyyy/M/d").Split("/")
        Select Case reportType
        	Case 0      '奉書挨拶状
                With frm
                    'CHK: 配列に基本設定を入れておく -> それをセレクトで選択して読む
                    .Cmb_Size.SelectedValue = 0         'TODO: Indexで統一？
                    .Cmb_Font.SelectedIndex = 70        'CHK: 拡大率の問題

                    '下記３つ現画面で廃止予定
                    .Cmb_Magnify.SelectedValue = 100
                    .Cmb_Thickness.SelectedValue = 40
                    .Txt_Copy.Text = "1"
                    
                    '初期設定の値は下の通り
                    'Specific part
                    .Cmb_Style.SelectedValue = 0                            'TODO: basicSetから読む
                    '.Cmb_SeasonWord.SelectedValue = "厳寒の候"             	'TODO: 月によって読む値を考える
                    .Cmb_SeasonWord.SelectedIndex = 1
                    .Cmb_Time1.SelectedValue = "先般"
                    .Cmb_Title.SelectedIndex = 1
                    .Txt_Name.Text = "儀"
                    .Cmb_DeathWay.SelectedValue = "死去"
                    .Cmb_Time2.SelectedValue = "本日"
                    .Cmb_Time2.Enabled = False
                    .Txt_DeadName.Text = ""
                    .Txt_DeadName.Enabled = False
                    .Cmb_Donation.SelectedValue = 0
                    .Cmb_Imibi.SelectedValue = "忌明の法要"
                    .Cmb_EndWord.SelectedValue = "敬具"
                    .Cmb_Year.SelectedValue = currentDt(0)
                    .Cmb_Month.SelectedValue = currentDt(1)
                    .Cmb_Day.SelectedValue = currentDt(2)
                    .Cmb_HostType.SelectedValue = "施主"
                    .Cmb_HostType.Enabled = False
                    .Txt_PS1.Text = "追伸"                                      'TODO: From SQL
                    .Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"  'TODO: From SQL
                    .Txt_PS3.Text = "お届けさせて頂きました"                    'TODO: From SQL
                    .Txt_PS4.Text = "御受納下さいます様お願い申し上げます"      'TODO: From SQL

                    'Font Size
                    .Cmb_PointTitle.SelectedIndex = 12						'★
                    .Cmb_PointName.SelectedIndex = 34
                    .Cmb_PointDeadName.SelectedIndex = 0
                    .Cmb_PointDeadName.Enabled = False
                    .Cmb_PointImibi.SelectedIndex = 35
                    .Cmb_PointEndWord.SelectedIndex = 34
                    .Cmb_PointCeremonyDate.SelectedIndex = 22
                    .Cmb_PointAdd1.SelectedIndex = 19
                    .Cmb_PointHostType.SelectedValue = 0
                    .Cmb_PointHostType.Enabled = False
                    .Cmb_PointHostName1.SelectedIndex = 34
                    .Cmb_PointHostName2.SelectedIndex = 34
                    .Cmb_PointHostName3.SelectedIndex = 34
                    .Cmb_PointHostName4.SelectedIndex = 34
                    .Cmb_PointPS1.SelectedIndex = 17
			End with
           		
        End Select
       End Sub
	
End Class
