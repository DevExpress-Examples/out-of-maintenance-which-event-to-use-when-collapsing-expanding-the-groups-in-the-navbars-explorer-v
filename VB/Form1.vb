Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraNavBar

Namespace ExpandingGroup
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents navBarControl1 As DevExpress.XtraNavBar.NavBarControl
		Private navBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarGroup2 As DevExpress.XtraNavBar.NavBarGroup
		Private navBarItem1 As DevExpress.XtraNavBar.NavBarItem
		Private navBarItem2 As DevExpress.XtraNavBar.NavBarItem
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
			Me.navBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem1 = New DevExpress.XtraNavBar.NavBarItem()
			Me.navBarGroup2 = New DevExpress.XtraNavBar.NavBarGroup()
			Me.navBarItem2 = New DevExpress.XtraNavBar.NavBarItem()
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' navBarControl1
			' 
			Me.navBarControl1.ActiveGroup = Me.navBarGroup1
			Me.navBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() { Me.navBarGroup1, Me.navBarGroup2})
			Me.navBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() { Me.navBarItem1, Me.navBarItem2})
			Me.navBarControl1.Location = New System.Drawing.Point(16, 8)
			Me.navBarControl1.Name = "navBarControl1"
			Me.navBarControl1.OptionsNavPane.ExpandedWidth = 168
			Me.navBarControl1.Size = New System.Drawing.Size(168, 300)
			Me.navBarControl1.TabIndex = 0
			Me.navBarControl1.Text = "navBarControl1"
'			Me.navBarControl1.MouseUp += New System.Windows.Forms.MouseEventHandler(Me.navBarControl1_MouseUp);
			' 
			' navBarGroup1
			' 
			Me.navBarGroup1.Caption = "navBarGroup1"
			Me.navBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() { New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem1)})
			Me.navBarGroup1.Name = "navBarGroup1"
			' 
			' navBarItem1
			' 
			Me.navBarItem1.Caption = "navBarItem1"
			Me.navBarItem1.Name = "navBarItem1"
			' 
			' navBarGroup2
			' 
			Me.navBarGroup2.Caption = "navBarGroup2"
			Me.navBarGroup2.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() { New DevExpress.XtraNavBar.NavBarItemLink(Me.navBarItem2)})
			Me.navBarGroup2.Name = "navBarGroup2"
			' 
			' navBarItem2
			' 
			Me.navBarItem2.Caption = "navBarItem2"
			Me.navBarItem2.Name = "navBarItem2"
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(312, 322)
			Me.Controls.Add(Me.navBarControl1)
			Me.Name = "Form1"
			Me.Text = "Which event to use when collapsing/expanding the groups in the NavBar's Explorer " & "views?"
			CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub navBarControl1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles navBarControl1.MouseUp
			If e.Button = MouseButtons.Left Then
				Dim info As NavBarHitInfo = (TryCast(sender, NavBarControl)).CalcHitInfo(New Point(e.X, e.Y))
				If info.InGroupButton AndAlso (Not info.Group.Expanded) Then
					If MessageBox.Show("Expand group?", "Confirmation", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
						info.Group.Expanded = True
					Else
						CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
					End If
				End If
			End If
		End Sub
	End Class
End Namespace
