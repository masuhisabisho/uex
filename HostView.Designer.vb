'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 0:17
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Partial Class HostView
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HostView))
		Me.Dgv_Main = New System.Windows.Forms.DataGridView()
		Me.Btn_Del = New System.Windows.Forms.Button()
		Me.Btn_Detail = New System.Windows.Forms.Button()
		Me.Btn_Close = New System.Windows.Forms.Button()
		CType(Me.Dgv_Main,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'Dgv_Main
		'
		Me.Dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.Dgv_Main.Location = New System.Drawing.Point(12, 12)
		Me.Dgv_Main.Name = "Dgv_Main"
		Me.Dgv_Main.RowTemplate.Height = 21
		Me.Dgv_Main.Size = New System.Drawing.Size(468, 284)
		Me.Dgv_Main.TabIndex = 0
		'
		'Btn_Del
		'
		Me.Btn_Del.Location = New System.Drawing.Point(59, 311)
		Me.Btn_Del.Name = "Btn_Del"
		Me.Btn_Del.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Del.TabIndex = 1
		Me.Btn_Del.Text = "削除"
		Me.Btn_Del.UseVisualStyleBackColor = true
		'
		'Btn_Detail
		'
		Me.Btn_Detail.Location = New System.Drawing.Point(292, 311)
		Me.Btn_Detail.Name = "Btn_Detail"
		Me.Btn_Detail.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Detail.TabIndex = 2
		Me.Btn_Detail.Text = "詳細"
		Me.Btn_Detail.UseVisualStyleBackColor = true
		'
		'Btn_Close
		'
		Me.Btn_Close.Location = New System.Drawing.Point(405, 311)
		Me.Btn_Close.Name = "Btn_Close"
		Me.Btn_Close.Size = New System.Drawing.Size(75, 23)
		Me.Btn_Close.TabIndex = 3
		Me.Btn_Close.Text = "戻る"
		Me.Btn_Close.UseVisualStyleBackColor = true
		'
		'HostView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(492, 346)
		Me.Controls.Add(Me.Btn_Close)
		Me.Controls.Add(Me.Btn_Detail)
		Me.Controls.Add(Me.Btn_Del)
		Me.Controls.Add(Me.Dgv_Main)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "HostView"
		Me.Text = "HostView"
		CType(Me.Dgv_Main,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private Btn_Close As System.Windows.Forms.Button
	Private Btn_Detail As System.Windows.Forms.Button
	Private Btn_Del As System.Windows.Forms.Button
	Private Dgv_Main As System.Windows.Forms.DataGridView
End Class
