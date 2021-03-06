﻿'
' SharpDevelopによって生成
' ユーザ: madman190382
' 日付: 2013/07/14
' 時刻: 16:43
' 
' このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
'
Public Class ControlHandler
	
'''■ChangeCmb_Size
''' <summary></summary>
''' <param name="selector"></param>
''' <param name="Pr"></param>
	Friend Sub ChangeCmb_Size(ByVal selector As Boolean, ByVal Pr As PrintReport)
		Select Case selector
			Case True
				AddHandler Pr.Cmb_Size.SelectedIndexChanged,AddressOf Pr.Cmb_SizeIndexChanged
			Case False
				RemoveHandler Pr.Cmb_Size.SelectedIndexChanged,AddressOf Pr.Cmb_SizeIndexChanged
		End Select
	End Sub
	
'''■ChangeCmb_Style
''' <summary></summary>
''' <param name="selector"></param>
''' <param name="Pr"></param>
	Friend Sub ChangeCmb_Style(ByVal selector As Boolean, ByVal Pr As PrintReport)
		Select Case selector
			Case True
				AddHandler Pr.Cmb_Style.SelectedIndexChanged,AddressOf Pr.Cmb_Style_SelectedIndexChanged
			Case False
				RemoveHandler Pr.Cmb_Style.SelectedIndexChanged,AddressOf Pr.Cmb_Style_SelectedIndexChanged
		End Select
	End Sub
	
'''■AllTCHandleShifter
''' <summary>TextChangedのハンドラーを有効無効にする</summary>
''' <param name="selector">Boolean Add = True  or Remove = False</param>
''' <param name="fmr">Form PrintReport.vb</param>
''' <returns>Void</returns>
	Friend Sub AllTCHandleShifter(ByVal selector As Boolean, ByVal Pr As PrintReport)
		Select Case selector	
			Case True
				AddHandler Pr.Txt_Namae.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_Name.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_DeadName.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_Add1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_Add2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_HostName1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_HostName2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_HostName3.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_HostName4.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS3.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS4.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS5.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				AddHandler Pr.Txt_PS6.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
			Case False
				RemoveHandler Pr.Txt_Namae.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_Name.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_DeadName.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_Add1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_Add2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_HostName1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_HostName2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_HostName3.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_HostName4.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS1.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS2.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS3.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS4.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS5.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				RemoveHandler Pr.Txt_PS6.TextChanged,AddressOf Pr.TextBoxChange_TextChanged
				
		End Select
	End Sub
	
''''■AllSICHandleShifter
''' <summary>SelectIndexChangedのハンドラーを有効・無効にする</summary>
'''<param name="selector">Boolean Add = True, Remove = False</param>
''' <returns>Void</returns>
	Friend Sub AllSICHandleShifter(ByVal selector As Boolean, ByVal Pr As PrintReport)
		Select Case selector
			Case True
				AddHandler Pr.Cmb_Hyodai.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged  '2013/10/11 add
				AddHandler Pr.Cmb_SeasonWord.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Time1.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Title.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_DeathWay.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Time2.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Donation.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Imibi.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_EndWord.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Year.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Month.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_Day.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_HostType.SelectedIndexChanged,	AddressOf Pr.Cmb_SelectedIndexChanged


				AddHandler Pr.Cmb_Font.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_PointHyodai.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointNamae.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointTitle.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_PointName.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointImibi.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointEndWord.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged
				AddHandler Pr.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointHostType.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				AddHandler Pr.Cmb_PointPS1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				
				AddHandler Pr.Cmb_Thickness.SelectedIndexChanged, AddressOf Pr.Cmb_Thickness_SelectedIndexChanged
				
				AddHandler Pr.Cmb_Magnify.SelectedIndexChanged, AddressOf Pr.Cmb_Magnify_SelectedIndexChanged

			Case False
				RemoveHandler Pr.Cmb_Hyodai.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged '2013/10/11 add
				RemoveHandler Pr.Cmb_SeasonWord.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Time1.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Title.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_DeathWay.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Time2.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Donation.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Imibi.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_EndWord.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Year.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Month.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_Day.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_HostType.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged

				RemoveHandler Pr.Cmb_Font.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_PointHyodai.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointNamae.SelectedIndexChanged,AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointTitle.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged
				RemoveHandler Pr.Cmb_PointName.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointDeadName.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointImibi.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointEndWord.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointCeremonyDate.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointAdd1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointHostType.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointHostName1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointHostName2.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointHostName3.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointHostName4.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged 
				RemoveHandler Pr.Cmb_PointPS1.SelectedIndexChanged, AddressOf Pr.Cmb_SelectedIndexChanged
				
				RemoveHandler Pr.Cmb_Thickness.SelectedIndexChanged, AddressOf Pr.Cmb_Thickness_SelectedIndexChanged
				
				RemoveHandler Pr.Cmb_Magnify.SelectedIndexChanged, AddressOf Pr.Cmb_Magnify_SelectedIndexChanged

		End select
	End Sub
	
End Class
