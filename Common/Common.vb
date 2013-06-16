'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/06/16
' 時刻: 9:03
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class Common
	
''''■GetWareki
''' <summary>Get wareki in Kanji</summary>
''' <param name="requestDt">Date</param>
''' <returns>Wareki in Kanji by String</returns>	
	Public Function GetWareki(requestDt As Date) As String
		Dim separateDt As String() = requestDt.ToString("yyyy/MM/dd").Split("/")
		If CInt(separateDt(0)) < 1989 Then
			MessageBox.Show("1990年以前は使用できません")
			Exit Function
		End If
		
		Dim result As String =""
		
		Dim f As New SelectSql
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS y FROM tbl_wareki WHERE tbl_wareki_grid = 0 AND tbl_wareki_compatible = " & CInt(separateDt(0)))
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS m FROM tbl_wareki WHERE tbl_wareki_grid = 1 AND tbl_wareki_compatible = " & CInt(separateDt(1)))
		result &= f.GetOneSql(" SELECT tbl_wareki_value AS d FROM tbl_wareki WHERE tbl_wareki_grid = 2 AND tbl_wareki_compatible = " & CInt(separateDt(2)))
		
		f = Nothing
		
		Return result
		
	End Function	
	
End Class
