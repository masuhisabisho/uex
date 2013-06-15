'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:27
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class Print
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Print))
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.Pnl_Main = New System.Windows.Forms.Panel()
		Me.panel1.SuspendLayout
		Me.SuspendLayout
		'
		'groupBox1
		'
		Me.groupBox1.Location = New System.Drawing.Point(13, 12)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(154, 89)
		Me.groupBox1.TabIndex = 1
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "groupBox1"
		'
		'groupBox2
		'
		Me.groupBox2.Location = New System.Drawing.Point(3, 3)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(154, 458)
		Me.groupBox2.TabIndex = 2
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "groupBox2"
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.groupBox2)
		Me.panel1.Location = New System.Drawing.Point(13, 108)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(163, 464)
		Me.panel1.TabIndex = 3
		'
		'Pnl_Main
		'
		Me.Pnl_Main.Location = New System.Drawing.Point(198, 12)
		Me.Pnl_Main.Name = "Pnl_Main"
		Me.Pnl_Main.Size = New System.Drawing.Size(771, 560)
		Me.Pnl_Main.TabIndex = 4
		'
		'Print
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1006, 595)
		Me.Controls.Add(Me.Pnl_Main)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.groupBox1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "Print"
		Me.Text = "Print"
		Me.panel1.ResumeLayout(false)
		Me.ResumeLayout(false)
	End Sub
	Private Pnl_Main As System.Windows.Forms.Panel
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private panel1 As System.Windows.Forms.Panel
End Class
