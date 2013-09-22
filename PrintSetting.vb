'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/27
' 時刻: 20:23
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Drawing.Printing
Imports System.Data

Public Partial Class PrintSetting
	
	'Private img As Image = Nothing
	Private Const inchUnit As Single = 0.254
	
	Private selectedPaper As String = ""
	Private selectedDirec As String = ""
	Private Wc As WordContainer
	
	'Public Sub New(imgData As Image, paperSize As String, printDirection As String)  'out 2013/9/22
	Public sub new(wordCont As WordContainer)
	'	The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		Wc = wordCont  'add 2013/9/22
		'イメージの取り込み
		'img = imgData  out 2013/9/22
		'用紙情報
'		selectedPaper = paperSize
'		selectedDirec = printDirection
		selectedPaper = Wc.DefSet(7)
		selectedDirec = Wc.DefSet(8)


	End Sub
	
	Private Sub PrintSetting_Load(sender As Object, e As EventArgs)
		'プリンターコンボの設定
		Dim dataTable As New DataTable()
		dataTable.Columns.Add("Label", GetType(String))
		dataTable.Columns.Add("Name", GetType(String))
		
		For Each p As String In Printing.PrinterSettings.InstalledPrinters
			Dim row As DataRow = dataTable.NewRow()
			row("Label") = p
			row("Name") = p
			dataTable.rows.Add(row)
		Next
		
		Me.Cmb_SelectPrinter.Items.Clear()
		Me.Cmb_SelectPrinter.DataSource = dataTable
		Me.Cmb_SelectPrinter.DisplayMember = "Name"
		Me.Cmb_SelectPrinter.ValueMember = "Label"
		
		Dim Pd As New PrintDocument
		Dim defaultPrName As String = Pd.PrinterSettings.PrinterName		'通常のプリンターをデフォルト値に
		Me.Cmb_SelectPrinter.SelectedValue = defaultPrName

		Pd.Dispose()
		Pd = Nothing
		'用紙コンボの設定
		Dim Sc As New SetCombo
		Sc.SetCombo(me.Cmb_PaperSize, SetEnvList.envList("402"), "", "", False)
		Me.Cmb_PaperSize.SelectedValue = selectedPaper
		'用紙設定方向ラベル
		Me.Lbl_SelectedDirection.Text = selectedDirec

	End Sub
	
#Region "イベント"
	
	'キャンセル
	Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub
	
	'PrintDocument Object
	Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
		'e.Graphics.DrawImage(img, e.MarginBounds)
		e.Graphics.DrawString("薔",New Font("ＭＳ Ｐ明朝", 36), New SolidBrush(Color.FromArgb(127, 127, 127)) 	, 0, 0)
		'e.Graphics.DrawString("薇",New Font("ＭＳ Ｐ明朝", 100), New SolidBrush(Color.FromArgb(127, 127, 127)) 	, 100, 300)
		'e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(80, Color.white)), 0, 0, 1800, 500)
		
		'END: 文字印刷はDrawImageでは無くDrawStringで（画像では汚いので）
		'END: 濃淡は変数に置き換える
		'TODO: 印刷不可能領域は10mmづつとる

		Dim rgbRate As Integer = CInt(Math.Round(Wc.ColorRate * (CDbl(Wc.optWord("Thickness_Txt")) / 100)))
		Dim addXPos As Single = 0
		Dim addYPos As Single = 0
		
		'位置調整
		If Me.Nud_Ypos.Value <> 0 Then
			addYPos = CSng(Me.Nud_Ypos.Value) / inchUnit
		End If
		
		If Me.Nud_Xpos.value <> 0 Then
			addXPos = CSng(Me.Nud_Xpos.value) / inchUnit
		End If
		
		
		For i As Integer = 0 To Wc.curWord.Count -1 Step 1
			If Wc.curWord(i)(0)(0) = "" Then
				Continue For
			End If
			
			For j As Integer = 0 To Wc.curWord(i).count -1 Step 1
				e.Graphics.DrawString(Wc.curWord(i)(j)(0), _
										New Font(Wc.optWord("Common_Font").ToString(), CInt(Wc.curWord(i)(j)(1))), _
										New SolidBrush(Color.FromArgb(rgbRate, rgbRate, rgbRate)), _
										CSng(Wc.curWord(i)(j)(3)) + addXPos, _
										CSng(Wc.curWord(i)(j)(2)) + addYPos, _
										New StringFormat(StringFormatFlags.DirectionVertical) _
									)
			Next j
		Next i
		e.HasMorePages = False
		Me.Close
	End Sub
	
	'印刷
	Private Sub Btn_Print_Click(sender As Object, e As EventArgs)
		'印刷する用紙設定があるかどうか確認
		Select Case selectedPaper
			Case "B5"								'B5
				If SetPaperSize(PaperKind.B5) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "JapanesePostcard"					'日本はがき
				If SetPaperSize(PaperKind.JapanesePostcard) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "JapaneseDoublePostcard"			'日本往復はがき
				If SetPaperSize(PaperKind.JapaneseDoublePostcard) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "JapaneseEnvelopeChouNumber4"		'日本長形4号封筒
				If SetPaperSize(PaperKind.JapaneseEnvelopeChouNumber4) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "C6Envelope"						'洋形2号封筒
				If SetPaperSize(PaperKind.C6Envelope) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "MonarchEnvelope"					'洋形6号封筒
				If SetPaperSize(PaperKind.MonarchEnvelope) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "A4"								'A4
				If SetPaperSize(PaperKind.A4) = False Then
					Call ErrorMsgBox()
					Exit Sub
				End If
			Case "奉書挨拶状"							'以下その他の特殊サイズ
				Dim irrSize As New Printing.PaperSize("奉書挨拶状",195 / inchUnit, 530 / inchUnit)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "単カード"
				Dim irrSize As New Printing.PaperSize("単カード", 1030, 1520)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "二つ折りカード"
				Dim irrSize As New Printing.PaperSize("二つ折りカード", 2050, 1520)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "横長単カード"
				Dim irrSize As New Printing.PaperSize("横長単カード", 1700, 1000)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "横長二つ折りカード"
				Dim irrSize As New Printing.PaperSize("横長二つ折りカード", 3340, 1000)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "戒名札"
				Dim irrSize As New Printing.PaperSize("戒名札", 750, 2650)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
			Case "のし紙"
				Dim irrSize As New Printing.PaperSize("のし紙", 950, 1800)
				PrintDocument1.DefaultPageSettings.PaperSize = irrSize
		End Select
		'TODO: 印刷の向きは可変にする必要あり
		With Me.printDocument1
			.DefaultPageSettings.Landscape = True												'横。縦はFalse
			.PrinterSettings.Copies = CShort(Me.Nud_Num.Value)									'枚数
			.PrinterSettings.PrinterName = Me.Cmb_SelectPrinter.SelectedValue.ToString()		'選択されたプリンター
			.Print()																			'印刷
		End With
		
	End Sub
	
#End Region

#Region "関数類"
	
	Private Sub ErrorMsgBox()
		MessageBox.Show("必要な用紙サイズがプリンター設定内に無いので" & vbCrLf & "選択された用紙での印刷ができないません", _
						"確認", _
						MessageBoxButtons.OK, _
						MessageBoxIcon.Exclamation, _
						MessageBoxDefaultButton.Button1 _
						)
	End Sub

'''■SetPaperSize
''' <summary>設定プリンターに指定の用紙があるかどうか確認 </summary>
''' <param name="ppKind">PaperKind 紙の種類</param>
''' <returns>あれば設定の上、True を返す</returns>
	Private Function SetPaperSize(ppKind As PaperKind) As Boolean
		Dim ppSize As System.Drawing.Printing.PaperSize

		For Each ppSize In PrintDocument1.PrinterSettings.PaperSizes
			If ppSize.Kind = ppKind Then											'指定の用紙サイズがサポートされているか
				PrintDocument1.DefaultPageSettings.PaperSize = ppSize				'指定の用紙サイズが見つかったら用紙サイズを設定する
				Return True
				Exit For
			End If
		Next
		
		Return False
		
	End Function
	
#End Region
	
End Class
