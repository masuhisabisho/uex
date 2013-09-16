'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/14
' 時刻: 16:43
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class ControlHandler
	
''''■AllTCHandleShifter
''' <summary>TextChangedのハンドラーを有効無効にする</summary>
''' <param name="selector">Boolean Add = True  or Remove = False</param>
''' <param name="fmr">Form PrintReport.vb</param>
''' <returns>Void</returns>
	Friend Sub AllTCHandleShifter(selector As Boolean, Frm As PrintReport)
		Select Case selector	
			Case True
				AddHandler Frm.Txt_Name.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				AddHandler Frm.Txt_DeadName.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				AddHandler Frm.Txt_Add1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				AddHandler Frm.Txt_Add2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
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
		Case False	
				RemoveHandler Frm.Txt_Name.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				RemoveHandler Frm.Txt_DeadName.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				RemoveHandler Frm.Txt_Add1.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
				RemoveHandler Frm.Txt_Add2.TextChanged,AddressOf Frm.TextBoxChange_TextChanged
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
				
		End Select
	End Sub
	
''''■AllSICHandleShifter
''' <summary>SelectIndexChangedのハンドラーを有効・無効にする</summary>
'''<param name="selector">Boolean Add = True, Remove = False</param>
''' <returns>Void</returns>
	Friend Sub AllSICHandleShifter(selector As Boolean, Frm As PrintReport)
		Select Case selector
			Case True
				AddHandler Frm.Cmb_SeasonWord.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Time1.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Title.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_DeathWay.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Time2.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Donation.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Imibi.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_EndWord.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Year.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Month.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_Day.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_HostType.SelectedIndexChanged,	AddressOf Frm.Cmb_SelectedIndexChanged

				AddHandler Frm.Cmb_Font.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_PointTitle.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_PointName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointImibi.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointEndWord.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged
				AddHandler Frm.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointHostType.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				AddHandler Frm.Cmb_PointPS1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				
				AddHandler Frm.Cmb_Thickness.SelectedIndexChanged, AddressOf Frm.Cmb_Thickness_SelectedIndexChanged
				
				AddHandler Frm.Cmb_Magnify.SelectedIndexChanged, AddressOf Frm.Cmb_Magnify_SelectedIndexChanged

			Case False
				RemoveHandler Frm.Cmb_SeasonWord.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Time1.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Title.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_DeathWay.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Time2.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Donation.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Imibi.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_EndWord.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Year.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Month.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_Day.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_HostType.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged

				RemoveHandler Frm.Cmb_Font.SelectedIndexChanged,AddressOf Frm.Cmb_SelectedIndexChanged
				RemoveHandler Frm.Cmb_PointTitle.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointImibi.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointEndWord.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointHostType.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged 
				RemoveHandler Frm.Cmb_PointPS1.SelectedIndexChanged, AddressOf Frm.Cmb_SelectedIndexChanged
				
				RemoveHandler Frm.Cmb_Thickness.SelectedIndexChanged, AddressOf Frm.Cmb_Thickness_SelectedIndexChanged
				
				RemoveHandler Frm.Cmb_Magnify.SelectedIndexChanged, AddressOf Frm.Cmb_Magnify_SelectedIndexChanged

		End select
	End Sub
	
End Class
