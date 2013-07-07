Imports System.Data
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/15
' 時刻: 20:31
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class SetCombo
''''■SetCombo
''' <summary>Set combo values</summary>
''' <param name="targetCmb">One you want to set</param>
''' <param name="3nvListHt">Datasource</param>
''' <param name="defaultStr">Default value of combo lable</param>
''' <param name="defaultVal">Default value of combo value</param>
''' <param name="isVisibleNull">Set nothing on combo as the first value</param>
''' <returns>Void</returns>
	Public Sub SetCombo(targetCmb As ComboBox, envListHt As ArrayList, defaultStr As String, defaultVal As String, isVisibleNull As Boolean)
		
		Dim setArray As New ArrayList
		
		For Each dicEntry As DictionaryEntry In envListHt
			setArray.Add(dicEntry)
		Next
		'Set nothing according to isVisibleNull flag
		If isVisibleNull = True Then
			setArray.Insert(0, New DictionaryEntry("", ""))
		End If
		
		Dim beforeText As String = targetCmb.Text
		
		targetCmb.BeginUpdate()								'Hold update avoid flicker in screen
		
		Dim dataTable As New DataTable()					'<-- ???
		dataTable.Columns.add("Key", GetType(String))
		dataTable.columns.add("Value", GetType(String))
		

        For Each dicEntry As DictionaryEntry In setArray
            ' targetCmb.Items.Add(dicEntry)
            Dim row As DataRow = dataTable.NewRow()
            row("Key") = CStr(dicEntry.Key)
            row("Value") = CStr(dicEntry.Value)
            dataTable.Rows.Add(row)
        Next

		targetCmb.DataSource = dataTable

        targetCmb.DisplayMember = "Key"
        targetCmb.ValueMember = "Value"
        targetCmb.EndUpdate()								'Start update

        If defaultVal <> "" Then
            targetCmb.SelectedValue = defaultVal
        ElseIf defaultStr <> "" Then
            targetCmb.Text = defaultStr
        Else
            targetCmb.Text = beforeText
        End If

        setArray = Nothing
        
	End Sub
	
''''■SetComboContent
''' <summary>コンボのリストを作成</summary>
''' <param name="frm">PrintReport.vb</param>
''' <returns>Void</returns>
	Public Sub SetComboContent(Frm As PrintReport)
		With Frm
			SetCombo(.Cmb_Size, SetEnvList.envList("002"), "奉書挨拶状", "0", False)
			'SetCombo(.Cmb_Font, SetEnvList.envList(""), "", "", True)		'Pending "FONT"
			SetCombo(.Cmb_Magnify, SetEnvList.envList("400"), "100", "100", False)
			SetCombo(.Cmb_Thickness, SetEnvList.envList("401"), "40", "40", False)
			SetCombo(.Cmb_Style, SetEnvList.envList("001"), "", "", True)
			SetCombo(.Cmb_SeasonWord, SetEnvList.envList("100"), "", "", True)
			SetCombo(.Cmb_Time1, SetEnvList.envList("101"), "", "", True)
			SetCombo(.Cmb_Title, SetEnvList.envList("200"), "", "", True)
			SetCombo(.Cmb_DeathWay, SetEnvList.envList("201"), "", "", True)
			SetCombo(.Cmb_Time2, SetEnvList.envList("106"), "", "", True)
			SetCombo(.Cmb_Donation, SetEnvList.envList("300"), "", "", True)
			SetCombo(.Cmb_Imibi, SetEnvList.envList("102"), "", "", True)
			SetCombo(.Cmb_EndWord, SetEnvList.envList("202"), "", "", True)
			SetCombo(.Cmb_Year, SetEnvList.envList("105"), "", "", True)
			SetCombo(.Cmb_Month, SetEnvList.envList("103"), "", "", True)
			SetCombo(.Cmb_Day, SetEnvList.envList("104"), "", "", True)
			SetCombo(.Cmb_HostType, SetEnvList.envList("301"), "", "", True)
		End With
	End Sub
End Class
