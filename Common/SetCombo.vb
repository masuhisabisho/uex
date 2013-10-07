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
''' <param name="targetCmb">ComboBox One you want to set</param>
''' <param name="3nvListHt">ArrayList Datasource</param>
''' <param name="defaultStr">String Default value of combo lable</param>
''' <param name="defaultVal">String Default value of combo value</param>
''' <param name="isVisibleNull">Set nothing on combo as the first value</param>
''' <returns>Void</returns>
	'Public Sub SetCombo(targetCmb As ComboBox, envListHt As ArrayList, defaultStr As String, defaultVal As String, isVisibleNull As Boolean)
	
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
	
	'TODO: 選択用パラメータを実装する
''''■SetComboContent
''' <summary>コンボのリストを作成</summary>
''' <param name="Pr">PrintReport.vb</param>
''' <returns>Void</returns>
	Public Sub SetComboContent(Wc As WordContainer, Pr As PrintReport)
		With Pr			'2013/9/29 WordContainerへカプセル化
			SetCombo(.Cmb_Size, Wc.SetEnvList("002"), "奉書挨拶状", "0", False)
			SetCombo(.Cmb_Magnify, Wc.SetEnvList("400"), "100", "100", False)
			SetCombo(.Cmb_Thickness, Wc.SetEnvList("401"), "100", "0", False)
			SetCombo(.Cmb_Style, Wc.SetEnvList("010"), "", "", False)
			SetCombo(.Cmb_Hyodai, Wc.SetEnvList("203"), "", "", False)
			SetCombo(.Cmb_SeasonWord, Wc.SetEnvList("100"), "", "", False)
			SetCombo(.Cmb_Time1, Wc.SetEnvList("101"), "", "", False)
			SetCombo(.Cmb_Title, Wc.SetEnvList("200"), "", "", False)
			SetCombo(.Cmb_DeathWay, Wc.SetEnvList("201"), "", "", False)
			SetCombo(.Cmb_Time2, Wc.SetEnvList("106"), "", "", False)
			SetCombo(.Cmb_Donation, Wc.SetEnvList("300"), "", "", False)
			SetCombo(.Cmb_Imibi, Wc.SetEnvList("102"), "", "", False)
			SetCombo(.Cmb_EndWord, Wc.SetEnvList("202"), "", "", False)
			SetCombo(.Cmb_Year, Wc.SetEnvList("105"), "", "", False)
			SetCombo(.Cmb_Month, Wc.SetEnvList("103"), "", "", False)
			SetCombo(.Cmb_Day, Wc.SetEnvList("104"), "", "", True)
			SetCombo(.Cmb_HostType, Wc.SetEnvList("301"), "", "", True)
			'TODO: 新しいコンボの値を記述
		End With
	End Sub

	
End Class
