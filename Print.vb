'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class Print
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub Print_Load(sender As Object, e As EventArgs)
		Dim f As New SetCombo
		With f
			.SetCombo(Me.Cmb_Size, SetEnvList.envList("002"), "", "", True)
			'.SetCombo(Me.Cmb_Font, SetEnvList.envList(""), "", "", True)
			.SetCombo(Me.Cmb_Style, SetEnvList.envList("001"), "", "", True)
			.SetCombo(Me.Cmb_SeasonWord, SetEnvList.envList("100"), "", "", True)
			.SetCombo(Me.Cmb_Time1, SetEnvList.envList("101"), "", "", True)
			.SetCombo(Me.Cmb_Title, SetEnvList.envList("200"), "", "", True)
			.SetCombo(Me.Cmb_DeathWay, SetEnvList.envList("201"), "", "", True)
			.SetCombo(Me.Cmb_Time2, SetEnvList.envList("105"), "", "", True)
			.SetCombo(Me.Cmb_Donation, SetEnvList.envList("300"), "", "", True)
			.SetCombo(Me.Cmb_Imibi, SetEnvList.envList("102"), "", "", True)
			.SetCombo(Me.Cmb_endWord, SetEnvList.envList("202"), "", "", True)
			.SetCombo(Me.Cmb_HostType, SetEnvList.envList("301"), "", "", True)
		End With

		f = Nothing
		
		Dim g As System.Drawing.Graphics
		With Pic_Main
			.Image = New Bitmap(.Size.Width, Size.Height)
			g = System.Drawing.Graphics.FromImage(.Image)
		End With
		g.DrawString("Hello, World", New Font("Terminal", 34), Brushes.Red, 10, 10)
		g.Dispose()
		
	End Sub
	

	
	Sub Button1_Click(sender As Object, e As EventArgs)
				Dim g As System.Drawing.Graphics
		With Pic_Main
			.Image = New Bitmap(.Size.Width, Size.Height)
			g = System.Drawing.Graphics.FromImage(.Image)
		End With
		g.DrawString("Hello, World", New Font("Terminal", 34), Brushes.Red, 10, 10)
		g.Dispose()
	End Sub
End Class
