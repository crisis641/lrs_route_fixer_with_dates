Public Class gapdialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbNextLink As System.Windows.Forms.TextBox
    Friend WithEvents btOkay As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbNextLink = New System.Windows.Forms.TextBox
        Me.btOkay = New System.Windows.Forms.Button
        Me.btCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "there is a gap at ordinal"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(136, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "transport link id"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(128, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "please enter next transport link id"
        '
        'tbNextLink
        '
        Me.tbNextLink.Location = New System.Drawing.Point(168, 192)
        Me.tbNextLink.Name = "tbNextLink"
        Me.tbNextLink.TabIndex = 5
        Me.tbNextLink.Text = ""
        '
        'btOkay
        '
        Me.btOkay.Location = New System.Drawing.Point(80, 224)
        Me.btOkay.Name = "btOkay"
        Me.btOkay.TabIndex = 6
        Me.btOkay.Text = "OK"
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(168, 224)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.TabIndex = 7
        Me.btCancel.Text = "Cancel"
        '
        'gapdialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btOkay)
        Me.Controls.Add(Me.tbNextLink)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "gapdialog"
        Me.Text = "gapdialog"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public transportlinkid As String
    Public ordinal As String
    Public nexttransportlinkid As Integer
    Public caller As Form1

    Private Sub btOkay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOkay.Click
        If tbNextLink.Text = "" Then
            MessageBox.Show("please enter a transport link id")

        Else
            caller.gapdialogtransportlinkid = tbNextLink.Text
            caller.gapdialogreturn = True
            'GoTo END_SUB
        End If

        Me.Close()
END_SUB:
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        caller.gapdialogreturn = False
        Me.Close()

    End Sub
End Class
