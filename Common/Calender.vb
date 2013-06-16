'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 14:40
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Partial Class Calender
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	Private selectedDate As String
	
	Public Property returndDate() As String
		Get
			Return selectedDate
		End Get
		Set(Byval value As String)
			selectedDate = value
		End Set
	End Property
	
	Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs)
		'END: Implement MonthCalendar1_DateSelected
		returndDate = Me.monthCalendar1.SelectionStart.ToString("yyyy/M/d")
		Me.Close()
	End Sub
	
End Class
