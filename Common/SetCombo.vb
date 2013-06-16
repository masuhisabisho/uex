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
		
		targetCmb.BeginUpdate()
		
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
        targetCmb.EndUpdate()

        If defaultVal <> "" Then
            targetCmb.SelectedValue = defaultVal
        ElseIf defaultStr <> "" Then
            targetCmb.Text = defaultStr
        Else
            targetCmb.Text = beforeText
        End If

        setArray = Nothing

	End Sub
	
End Class
