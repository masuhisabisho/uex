'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 14:40
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class Calender
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calender))
		Me.monthCalendar1 = New System.Windows.Forms.MonthCalendar()
		Me.SuspendLayout
		'
		'monthCalendar1
		'
		Me.monthCalendar1.Location = New System.Drawing.Point(0, 0)
		Me.monthCalendar1.Name = "monthCalendar1"
		Me.monthCalendar1.TabIndex = 0
		AddHandler Me.monthCalendar1.DateSelected, AddressOf Me.MonthCalendar1_DateSelected
		'
		'Calender
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(219, 156)
		Me.Controls.Add(Me.monthCalendar1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "Calender"
		Me.Text = "カレンダー"
		Me.ResumeLayout(false)
	End Sub
	Private monthCalendar1 As System.Windows.Forms.MonthCalendar
End Class
