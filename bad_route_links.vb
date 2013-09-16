Public Class bad_route_links
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
    Friend WithEvents DG_route_links As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DG_route_links = New System.Windows.Forms.DataGrid
        CType(Me.DG_route_links, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DG_route_links
        '
        Me.DG_route_links.DataMember = ""
        Me.DG_route_links.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DG_route_links.Location = New System.Drawing.Point(16, 32)
        Me.DG_route_links.Name = "DG_route_links"
        Me.DG_route_links.Size = New System.Drawing.Size(688, 304)
        Me.DG_route_links.TabIndex = 0
        '
        'bad_route_links
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 398)
        Me.Controls.Add(Me.DG_route_links)
        Me.Name = "bad_route_links"
        CType(Me.DG_route_links, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public caller As Form1
    Public ds As DataSet



    Private Sub bad_route_links_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Console.WriteLine(e)
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        caller.Close()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        caller.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'caller.delete_route_links(ds)
        MessageBox.Show("deleted route links please restart the program")
        Me.Close()

    End Sub
End Class
