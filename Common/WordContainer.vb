'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/13
' 時刻: 10:19
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Diagnostics.Debug
Public Class WordContainer
	
	Private Const colRate As Single = 255
	Private Const defFontIndex As Integer = 18
	Private Const defThickness As Integer = 8
	
	Private envList As New Hashtable
	Private curSetting As New Hashtable
	Private defKeyWord As New Hashtable
	private optionalWord As New Hashtable
	
	Private tempCurWord As New arraylist
	Private currentWord As New ArrayList
	Private mainSentence As New ArrayList
	Private cmbTxtPos As New ArrayList
	Private cmbTxtStr As New ArrayList
	Private cmbTxtPoint As New ArrayList
	Private ctpEnabled As New ArrayList
	
'''■ColorRate	
''' <summary></summary>
	Public Readonly Property ColorRate() As Single
		Get
			Return colRate
		End Get
	End Property
	
'''■DefaultFontIndex
''' <summary></summary>
	Public ReadOnly Property DefaultFontIndex() As Integer
		Get
			Return defFontIndex
		End Get
	End Property
	
'''■DefaultThickness
''' <summary></summary>
	Public ReadOnly Property DefaultThickness() As Integer
		Get
			Return defThickness
		End Get
	End Property
	
'''■EnviromentList
''' <summary></summary>
	Public property SetEnvList(hashKey As String) As ArrayList
		Get
			Return DirectCast(envList(hashKey), ArrayList)
		End Get
		
		Set(value As ArrayList)
			envList.Add(hashKey, value)
		End Set
	End Property
		
'''■mainTxt
''' <summary></summary>
	Public Property mainTxt() As ArrayList
		Get
			Return mainSentence
		End get
		
		Set(value As ArrayList)
			For i As Integer = 0 To value.Count -1 Step 1
				mainSentence.Add(value(i))
			Next i
		End Set
	End Property
	
'END:　この辺りまとまらないか？
'''■DefSet (移行テスト中 -> OK 2013/8/3 mb）
''' <summary>現在表示している内容の初期値を保存・出力する（指定する。１項目のみ）</summary>
''' <param name="curWriteWay">selector = 0 縦( = 0)・横( = 0)書き</param>
''' <param name="curFontSize">selector = 1 一般のフォントサイズ</param>
''' <param name="curTopXPos">selector = 2 最大のx座標</param>
''' <param name="curTopYPos">selector = 3 天のy座標</param>
''' <param name="curBottomYPos">selector = 4 地のy座標</param>
''' <param name="curBasicPitch">selector = 5 基本の改列ピッチ</param>
''' <param name="curWordPitch">selector = 6 基本の文字ピッチ</param>
''' <param name="paperSize">selector = 7 現在の用紙IDに対する用紙サイズ　</param>
''' <param name="paperDirection">selector = 8 現在の用紙IDに対する用紙設定方向</param>
	Public Property DefSet (selector As Integer) As String
		Get
			Select Case selector
				Case 0
					Return defKeyWord("curWriteWay").ToString()
				Case 1
					Return defKeyWord("curFontSize").ToString()
			    Case 2
			    	Return defKeyWord("curTopXPos").ToString()
			    Case 3
			    	Return defKeyWord("curTopYPos").ToString()
			    Case 4
			    	Return defKeyWord("curBottomYPos").ToString()
			    Case 5
			    	Return defKeyWord("curBasicPitch").ToString()
			    Case 6
			    	Return defKeyWord("curWordPitch").ToString()
			    Case 7
			    	Return defKeyWord("paperSize").ToString()
			    Case 8
			    	Return defKeyWord("paperDirection").ToString()
			    Case Else
			    	Return Nothing
			End Select
		End Get
		
		Set(ByVal value As String)
			Select Case selector
				Case 0
					defKeyWord("curWriteWay") = value
				Case 1
					defKeyWord("curFontSize") = value	
			    Case 2
			    	defKeyWord("curTopXPos") = value
			    Case 3
			    	defKeyWord("curTopYPos") = value
			    Case 4
			    	defKeyWord("curBottomYPos") = value
			    Case 5
			    	defKeyWord("curBasicPitch") = value
			    Case 6
			    	defKeyWord("curWordPitch") = value
			    Case 7
			    	defKeyWord("paperSize") = value
			    Case 8
			    	defKeyWord("paperDirection") = value
			End Select
		End Set	
	
	End Property
	
'''■CurrentSet
''' <summary>現在表示している内容の用紙ID・文例IDを保存出力する</summary>
''' <param name="curSize">現在の用紙ID</param>
''' <param name="curStyle">現在の文例ID</param>
	Public Property CurrentSet(hashKey As String) As Integer
		Get
			Return CInt(curSetting(hashKey))
		End Get
		
		Set(ByVal value As Integer)
			curSetting(hashKey) = value
		End Set
	End Property
	
'''■ComboTextPos
''' <summary></summary>
	Public Property ComboTextPos() As ArrayList
		Get
			Return cmbTxtPos
		End Get
		
		Set(ByVal value As ArrayList)
			cmbTxtPos = value
		End Set
	End Property
	
'''■ComboTextStr
''' <summary></summary>
	Public Property ComboTextStr() As ArrayList
		Get
			Return cmbTxtStr
		End Get
		
		Set(ByVal value As ArrayList)
			cmbTxtStr = value
		End Set
	End Property
	
'''■ComboTextPoint
''' <summary></summary>
	Public Property ComboTextPoint() As ArrayList
		Get
			Return cmbTxtPoint
		End Get
		
		Set(ByVal value As ArrayList)
			cmbTxtPoint = value
		End Set
	End Property
	
'''■CmbTxtPntEnabled
''' <summary></summary>
	Public Property CmbTxtPntEnabled() As ArrayList
		Get
			Return ctpEnabled
		End Get
		
		Set(ByVal value As ArrayList)
			ctpEnabled = value
		End Set
	End Property
	
'''■curWord
''' <summary>描画した文字情報を保管しておく
''' 1) 行
''' 2) 文字（それぞれの文字の情報を格納した配列を格納する配列）
''' 3) 文字の詳細 0 = 文字, 1 = フォントサイズ, 2 = y軸位置, 3 = x軸位置
''' </summary>
''' <param name="wordInLine">ArrayList 文字情報</param>
''' <returns>文字配列を返す</returns>
	Public Property curWord() As ArrayList
		Get
			Return currentWord
		End Get
		
		Set(ByVal value As ArrayList)
			currentWord.Add(value)
		End Set
	End Property
	
'''■TempCurrentWord	
''' <summary>拡大用のデータを一時的に保持する</summary>
''' <param name="selector">Optional Integer 0 = 追加 1 = クリア</param>
''' <returns>拡大用文字配列を格納、出力する</returns>
	Public Property TempCurrentWord() As arraylist
		Get
			return tempCurWord
		End Get
		
		Set(ByVal value As arraylist)
			tempCurWord.Add(value)
		End Set
	End Property
	
'''■optWord
''' <summary>挿入文字を保管しておく</summary>
''' <param name="hashKey">ハッシュテーブルのキー</param>
''' <returns>Void</returns>
	Public Property optWord(hashKey As String) As String
		Get
			Return optionalWord(hashKey).ToString()
		End Get
		
		Set (Value As String)
			optionalWord(hashKey) = value
		End Set
	End Property
	
'■WordClear
''' <summary></summary>
''' <param name="selector"></param>
	Public Sub WordClear(selector As Integer)
		Select Case selector
			Case 0
				envList.Clear()
			Case 1
				curSetting.Clear()
			Case 2
				defKeyWord.Clear
			Case 3
				optionalWord.Clear()
			Case Else
				MessageBox.Show("該当クリアがありません")
				Exit Sub
		End Select
		
	End Sub
		
	End Class
