'
' Created by SharpDevelop.
' User: madman190382
' Date: 2013/06/14
' Time: 23:08
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.Btn_HostRegister = New System.Windows.Forms.Button()
		Me.Btn_HostView = New System.Windows.Forms.Button()
		Me.Btn_HostPrint = New System.Windows.Forms.Button()
		Me.Btn_HostList = New System.Windows.Forms.Button()
		Me.Btn_Print = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'Btn_HostRegister
		'
		Me.Btn_HostRegister.BackgroundImage = CType(resources.GetObject("Btn_HostRegister.BackgroundImage"),System.Drawing.Image)
		Me.Btn_HostRegister.Location = New System.Drawing.Point(210, 34)
		Me.Btn_HostRegister.Name = "Btn_HostRegister"
		Me.Btn_HostRegister.Size = New System.Drawing.Size(170, 30)
		Me.Btn_HostRegister.TabIndex = 0
		Me.Btn_HostRegister.UseVisualStyleBackColor = true
		'
		'Btn_HostView
		'
		Me.Btn_HostView.BackgroundImage = CType(resources.GetObject("Btn_HostView.BackgroundImage"),System.Drawing.Image)
		Me.Btn_HostView.Location = New System.Drawing.Point(210, 95)
		Me.Btn_HostView.Name = "Btn_HostView"
		Me.Btn_HostView.Size = New System.Drawing.Size(170, 30)
		Me.Btn_HostView.TabIndex = 1
		Me.Btn_HostView.UseVisualStyleBackColor = true
		'
		'Btn_HostPrint
		'
		Me.Btn_HostPrint.BackgroundImage = CType(resources.GetObject("Btn_HostPrint.BackgroundImage"),System.Drawing.Image)
		Me.Btn_HostPrint.Location = New System.Drawing.Point(210, 152)
		Me.Btn_HostPrint.Name = "Btn_HostPrint"
		Me.Btn_HostPrint.Size = New System.Drawing.Size(170, 30)
		Me.Btn_HostPrint.TabIndex = 2
		Me.Btn_HostPrint.UseVisualStyleBackColor = true
		'
		'Btn_HostList
		'
		Me.Btn_HostList.BackgroundImage = CType(resources.GetObject("Btn_HostList.BackgroundImage"),System.Drawing.Image)
		Me.Btn_HostList.Location = New System.Drawing.Point(210, 209)
		Me.Btn_HostList.Name = "Btn_HostList"
		Me.Btn_HostList.Size = New System.Drawing.Size(170, 30)
		Me.Btn_HostList.TabIndex = 3
		Me.Btn_HostList.UseVisualStyleBackColor = true
		'
		'Btn_Print
		'
		Me.Btn_Print.BackgroundImage = CType(resources.GetObject("Btn_Print.BackgroundImage"),System.Drawing.Image)
		Me.Btn_Print.Location = New System.Drawing.Point(12, 34)
		Me.Btn_Print.Name = "Btn_Print"
		Me.Btn_Print.Size = New System.Drawing.Size(170, 30)
		Me.Btn_Print.TabIndex = 4
		Me.Btn_Print.UseVisualStyleBackColor = true
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
		Me.ClientSize = New System.Drawing.Size(392, 293)
		Me.Controls.Add(Me.Btn_Print)
		Me.Controls.Add(Me.Btn_HostList)
		Me.Controls.Add(Me.Btn_HostPrint)
		Me.Controls.Add(Me.Btn_HostView)
		Me.Controls.Add(Me.Btn_HostRegister)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "MainForm"
		Me.Text = "uex"
		Me.ResumeLayout(False)
		
			End Sub
	Private Btn_HostRegister As System.Windows.Forms.Button
	Private Btn_HostView As System.Windows.Forms.Button
	Private Btn_HostPrint As System.Windows.Forms.Button
	Private Btn_HostList As System.Windows.Forms.Button
	Private Btn_Print As System.Windows.Forms.Button
	
	
End Class

