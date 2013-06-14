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
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.SuspendLayout
		'
		'panel1
		'
		Me.panel1.BackColor = System.Drawing.Color.White
		Me.panel1.Location = New System.Drawing.Point(173, 12)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(409, 312)
		Me.panel1.TabIndex = 0
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
		Me.groupBox2.Location = New System.Drawing.Point(13, 128)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(154, 89)
		Me.groupBox2.TabIndex = 2
		Me.groupBox2.TabStop = false
		Me.groupBox2.Text = "groupBox2"
		'
		'Print
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(594, 336)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.panel1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "Print"
		Me.Text = "Print"
		Me.ResumeLayout(false)
	End Sub
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private panel1 As System.Windows.Forms.Panel
End Class
