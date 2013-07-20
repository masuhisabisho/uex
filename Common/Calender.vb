'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 14:40
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class Calender
	Dim Pr As PrintReport
	Dim Wc As WordContainer
	
	Public Sub New(ConsPr As Form, ConsWc As WordContainer)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		'
		' END : Add constructor code after InitializeComponents
		'		Receive form from paretanal from
		Pr = ConsPr
		Wc = ConsWc
	End Sub
	
'	Private selectedDate As String
'	
'	Public Property returndDate() As String
'		Get
'			Return selectedDate
'		End Get
'		Set(Byval value As String)
'			selectedDate = value
'		End Set
'	End Property
	
	Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs)
		'END: Implement MonthCalendar1_DateSelected
		
		Dim separateDt() As String = Me.monthCalendar1.SelectionStart.ToString("yyyy/M/d").Split("/"c)
		If CInt(separateDt(0)) < 1989 Then
			MessageBox.Show("1990年以前は使用できません")
			Exit Sub
		End If

		Pr.Cmb_Year.SelectedValue = separateDt(0)
		Pr.Cmb_Month.SelectedValue = separateDt(1)
		Pr.Cmb_Day.Selectedvalue = separateDt(2)
		
		Dim result As String =""
		Dim SctSql As New SelectSql()
		result &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & CInt(separateDt(0)))
		result &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & CInt(separateDt(1)))
		result &= SctSql.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & CInt(separateDt(2)))
		Wc.optWord("Txt_CeremonyDate") = result
		'returndDate = Me.monthCalendar1.SelectionStart.ToString("yyyy/M/d")
		
		SctSql = Nothing
		Me.Close()
		
	End Sub
	
End Class
