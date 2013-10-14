'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/10/14
' 時刻: 13:11
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Imports System.Windows.Forms

Public Class PanelCus
    Inherits Panel
    
    ''' <summary>
    ''' スクロール時、音符のPictureBoxの残像が残るのを防止する
    ''' </summary>
    ''' <remarks></remarks>

    Private Const WS_EX_COMPOSITED As Int32 = &H2000000
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim p As CreateParams = MyBase.CreateParams
            p.ExStyle = p.ExStyle Or WS_EX_COMPOSITED
            Return p
        End Get
    End Property

End Class

