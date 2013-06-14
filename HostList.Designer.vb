'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:22
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class HostList
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HostList))
		Me.Dgv_Host = New System.Windows.Forms.DataGridView()
		Me.Btn_Print = New System.Windows.Forms.Button()
		Me.Btn_Close = New System.Windows.Forms.Button()
		CType(Me.Dgv_Host,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Dgv_Host
		'
		Me.Dgv_Host.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Dgv_Host.Location = New System.Drawing.Point(13, 13)
		Me.Dgv_Host.Name = "Dgv_Host"
		Me.Dgv_Host.RowTemplate.Height = 21
		Me.Dgv_Host.Size = New System.Drawing.Size(449, 247)
		Me.Dgv_Host.TabIndex = 0
		'
		'Btn_Print
		'
		Me.Btn_Print.Location = New System.Drawing.Point(297, 278)
		Me.Btn_Print.Name = "Btn_Print"
		Me.Btn_Print.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Print.TabIndex = 1
		Me.Btn_Print.Text = "印刷"
		Me.Btn_Print.UseVisualStyleBackColor = true
		'
		'Btn_Close
		'
		Me.Btn_Close.Location = New System.Drawing.Point(387, 278)
		Me.Btn_Close.Name = "Btn_Close"
		Me.Btn_Close.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Close.TabIndex = 2
		Me.Btn_Close.Text = "戻る"
		Me.Btn_Close.UseVisualStyleBackColor = true
		'
		'HostList
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(474, 313)
		Me.Controls.Add(Me.Btn_Close)
		Me.Controls.Add(Me.Btn_Print)
		Me.Controls.Add(Me.Dgv_Host)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "HostList"
		Me.Text = "HostList"
		CType(Me.Dgv_Host,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private Btn_Close As System.Windows.Forms.Button
	Private Btn_Print As System.Windows.Forms.Button
	Private Dgv_Host As System.Windows.Forms.DataGridView
End Class
