'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class PrintReport
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
		
	End Sub
	
	Sub Print_Load(sender As Object, e As EventArgs)
		'Set font
		Dim installedFont As New System.Drawing.Text.InstalledFontCollection
		Dim fontFamilies As FontFamily() = installedFont.Families
		
		For Each j As FontFamily In fontFamilies
			Me.Cmb_Font.Items.Add(j.Name)
		Next j
		
		'Set values on each combo
		Dim f As New SetCombo
		With f
			.SetCombo(Me.Cmb_Size, SetEnvList.envList("002"), "奉書挨拶状", "0", False)
			'.SetCombo(Me.Cmb_Font, SetEnvList.envList(""), "", "", True)		'Pending "FONT"
			.SetCombo(Me.Cmb_Magnify, SetEnvList.envList("400"), "100", "100", False)
			.SetCombo(Me.Cmb_Thickness, SetEnvList.envList("401"), "40", "40", False)
			.SetCombo(Me.Cmb_Style, SetEnvList.envList("001"), "", "", True)
			.SetCombo(Me.Cmb_SeasonWord, SetEnvList.envList("100"), "", "", True)
			.SetCombo(Me.Cmb_Time1, SetEnvList.envList("101"), "", "", True)
			.SetCombo(Me.Cmb_Title, SetEnvList.envList("200"), "", "", True)
			.SetCombo(Me.Cmb_DeathWay, SetEnvList.envList("201"), "", "", True)
			.SetCombo(Me.Cmb_Time2, SetEnvList.envList("106"), "", "", True)
			.SetCombo(Me.Cmb_Donation, SetEnvList.envList("300"), "", "", True)
			.SetCombo(Me.Cmb_Imibi, SetEnvList.envList("102"), "", "", True)
			.SetCombo(Me.Cmb_EndWord, SetEnvList.envList("202"), "", "", True)
			.SetCombo(Me.Cmb_Year, SetEnvList.envList("105"), "", "", True)
			.SetCombo(Me.Cmb_Month, SetEnvList.envList("103"), "", "", True)
			.SetCombo(Me.Cmb_Day, SetEnvList.envList("104"), "", "", True)
			.SetCombo(Me.Cmb_HostType, SetEnvList.envList("301"), "", "", True)
		End With
		
		f = Nothing
		
		'Test
		Dim g As System.Drawing.Graphics
		With Pic_Main
			.Image = New Bitmap(.Size.Width, Size.Height)
			g = System.Drawing.Graphics.FromImage(.Image)
		End With
		g.DrawString("Hello, World", New Font("Terminal", 34), Brushes.Red, 10, 10)
		g.Dispose()
		
	End Sub
	

''''■Magnify
''' <summary>画像を拡大・縮小する。</summary>
''' <param name="Source">対象の画像</param>
''' <param name="Rate">拡大率。以下の値を指定した場合は縮小される。</param>
''' <param name="Quality">画質。省略時は最高画質。</param>
''' <returns>処理後の画像</returns>
	Private Function Magnify(ByVal Source As Image, ByVal Rate As Double, _ 
	Optional ByVal Quality As Drawing2D.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic) As Image

    	'▼引数のチェック
    	If IsNothing(Source) Then
        	Throw New NullReferenceException("Sourceに値が設定されていません。")
    	End If
    	If CInt(Source.Size.Width * Rate) <= 0 OrElse CInt(Source.Size.Height * Rate) <= 0 Then
        	Throw New ArgumentException("処理後の画像のサイズが0以下になります。Rateには十分大きな値を指定してください。")
    	End If

    	'▼処理後の大きさの空の画像を作成
    	Dim NewRect As Rectangle

    	NewRect.Width = CInt(Source.Size.Width * Rate)
    	NewRect.Height = CInt(Source.Size.Height * Rate)
    	Dim DestImage As New Bitmap(NewRect.Width, NewRect.Height)

    	'▼拡大・縮小実行
    	Dim g As Graphics = Graphics.FromImage(DestImage)
    	g.InterpolationMode = Quality
    	g.DrawImage(Source, NewRect)

    	Return DestImage

	End Function
	
	Sub Btn_Dtp_Click(sender As Object, e As EventArgs)
		' TODO: Show Calender for easy entry
		Dim resultDate As String()
		Dim f As New Calender
		f.ShowDialog(Me)
		If f.returndDate <> "" Then
			resultDate =  f.returndDate.Split("/")
			
			Me.Cmb_Year.SelectedValue = resultDate(0)
			Me.Cmb_Month.SelectedValue = resultDate(1)
			Me.Cmb_Day.Selectedvalue = resultDate(2)
		
			f.Dispose()
			f = Nothing
		End If
	End Sub
	
''''■ClearForm
''' <summary>Format form</summary>
''' <param name="reportType">Kind of paper sytle</param>
''' <returns>Void</returns>	
	Public Sub ClearForm(reportType As Integer, Frm As PrintReport)
		Select Case reportType
			Case 0		'奉書挨拶状
				With Me
					.Cmb_Size.SelectedValue = 0
					.Cmb_Font.SelectedValue = 0
					.Cmb_Magnify.SelectedValue = 100
					.Cmb_Thickness.SelectedValue = 40
					'.Txt_Copy.value = "1"
					
					.Cmb_Style.SelectedValue = 0
					.Cmb_SeasonWord.SelectedValue = 0		'TODO: Get along with season
					.Cmb_Time1.SelectedValue = 0
					.Cmb_Title.SelectedValue = 0
					.Txt_Name.Text = "儀"
					.Cmb_DeathWay.SelectedValue = 0
					.Cmb_Time2.SelectedValue = 0
					
					.Txt_DeadName.Text = ""
					.Cmb_Time2.Enabled = False
					.Cmb_Donation.SelectedValue = 0
					.Cmb_Imibi.SelectedValue = 0
					.Cmb_EndWord.SelectedValue = 0
					.Cmb_Year.SelectedValue = 1
					.Cmb_Month.SelectedValue = 1
					.Cmb_Day.SelectedValue = 0
					.Cmb_HostType.SelectedValue = 1
					.Cmb_HostType.Enabled = False
					.Txt_PS1.Text = "追伸"
					.Txt_PS2.Text = "ｘｘｘｘｘｘｘｘｘｘｘのお印までに粗品を"
					.Txt_PS3.Text = "お届けさせて頂きました"
					.Txt_PS4.Text = "御受納下さいます様お願い申し上げます”
					
					
					
					
				End With
		    Case 1
				
		End Select
		
	End Sub
	
	
End Class
