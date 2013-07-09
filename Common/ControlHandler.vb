'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/14
' 時刻: 16:43
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class ControlHandler
	
''''■AllHandleRemover
''' <summary>TextChangedのハンドラーを無効にする</summary>
''' <returns>Void</returns>
	Friend Sub AllTCHandleRemover(Frm As PrintReport)
		RemoveHandler Frm.Cmb_SeasonWord.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Time1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Title.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_Name.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_DeathWay.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Time2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_DeadName.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Donation.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Imibi.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_EndWord.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Year.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Month.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_Day.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_Add1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_Add2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Cmb_HostType.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_HostName1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_HostName2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_HostName3.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_HostName4.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS3.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS4.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS5.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		RemoveHandler Frm.Txt_PS6.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
	End Sub
	
''''■AllTCHandleSetter
''' <summary>TextChangedのハンドラーを有効にする</summary>
''' <returns>Void</returns>
	Friend Sub AllTCHandleSetter(Frm As PrintReport)
		AddHandler Frm.Cmb_SeasonWord.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Time1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Title.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_Name.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_DeathWay.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Time2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_DeadName.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Donation.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Imibi.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_EndWord.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Year.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Month.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_Day.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_Add1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_Add2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Cmb_HostType.TextChanged,	AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_HostName1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_HostName2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_HostName3.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_HostName4.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS3.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS4.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS5.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
		AddHandler Frm.Txt_PS6.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
	End Sub
	
''''■AllSICHandleRemover
''' <summary>SelectIndexChangedのハンドラーを無効にする</summary>
''' <returns>Void</returns>
	Friend Sub AllSICHandleRemover(Frm As PrintReport)
		RemoveHandler Frm.Cmb_PointTitle.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointImibi.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointHostType.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		RemoveHandler Frm.Cmb_PointPS1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
	End Sub
	
''''■ALLSICHandleSetter
''' <summary>SelectIndexChangedのハンドラーを有効にする</summary>
''' <returns>Void</returns>
	Friend Sub ALLSICHandleSetter(Frm As PrintReport)
		AddHandler Frm.Cmb_PointTitle.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointImibi.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointHostType.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
		AddHandler Frm.Cmb_PointPS1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
	End Sub
	
End Class
