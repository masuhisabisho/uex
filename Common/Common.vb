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
	
	''''■Magnify
''' <summary>画像を拡大・縮小する。</summary>
''' <param name="Source">対象の画像</param>
''' <param name="Rate">拡大率。以下の値を指定した場合は縮小される。</param>
''' <param name="Quality">画質。省略時は最高画質。</param>
''' <returns>処理後の画像</returns>
''' 'http://homepage1.nifty.com/rucio/main/dotnet/Samples/Sample141ImageMagnify.htm
''' 'PictureBox1.Image = Magnify(PictureBox1.Image, 1.2F)
	Private Function Magnify(ByVal Source As Image, ByVal Rate As Double, _ 
	Optional ByVal Quality As Drawing2D.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic) As Image

    	'▼引数のチェック
    	If IsNothing(Source) Then
        	Throw New NullReferenceException("Sourceに値が設定されていません。")
    	End If
    	If CInt(Source.Size.Width * Rate) <= 0 OrElse CInt(Source.Size.Height * Rate) <= 0 Then
        	Throw New ArgumentException("処理後の画像のサイズが0以下になります。Rateには十分大きな値を指定してください。")
    	End If

    	'▼処理後の大きさの空の画像を作成
    	Dim NewRect As Rectangle

    	NewRect.Width = CInt(Source.Size.Width * Rate)
    	NewRect.Height = CInt(Source.Size.Height * Rate)
    	Dim DestImage As New Bitmap(NewRect.Width, NewRect.Height)

    	'▼拡大・縮小実行
    	Dim g As Graphics = Graphics.FromImage(DestImage)
    	g.InterpolationMode = Quality
    	g.DrawImage(Source, NewRect)

    	Return DestImage

	End Function
	
End Class
