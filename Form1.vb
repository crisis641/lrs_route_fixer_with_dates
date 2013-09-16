'Imports Oracle.DataAccess.Client
Imports System.Data.OracleClient

Public Class Form1

    Inherits System.Windows.Forms.Form

    'Dim lrsCon As String = "data source=dlrs;User ID=idotlrs;Password=darthvader"
    'Dim lrsCon As String = "data source=pidotlrs;User ID=/"
    'Dim lrsCon As String = "data source=pidotlrs;" + "Integrated Security=Yes;"
    'Dim lrsCon As String = "data source=tidotlrs;" + "Integrated Security=Yes;"
    Dim lrsCon As String = "data source=dlrs;" + "Integrated Security=Yes;"
    Dim cnnLRS As OracleConnection
    Dim effectivedate As String = ""
    Dim ds As DataSet

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
    Friend WithEvents tbRouteID As System.Windows.Forms.TextBox
    Friend WithEvents btGo As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents btclear As System.Windows.Forms.Button
    Friend WithEvents tvRouteDate As System.Windows.Forms.TreeView
    Friend WithEvents btFixRoute As System.Windows.Forms.Button
    Friend WithEvents btWriteFixes As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DG_route_links As System.Windows.Forms.DataGrid
    Friend WithEvents bDelRouteLinks As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btClearDate As System.Windows.Forms.Button
    Friend WithEvents btClearAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.tbRouteID = New System.Windows.Forms.TextBox
        Me.btGo = New System.Windows.Forms.Button
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.TreeView2 = New System.Windows.Forms.TreeView
        Me.btclear = New System.Windows.Forms.Button
        Me.tvRouteDate = New System.Windows.Forms.TreeView
        Me.btFixRoute = New System.Windows.Forms.Button
        Me.btWriteFixes = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DG_route_links = New System.Windows.Forms.DataGrid
        Me.bDelRouteLinks = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btClearDate = New System.Windows.Forms.Button
        Me.btClearAll = New System.Windows.Forms.Button
        CType(Me.DG_route_links, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbRouteID
        '
        Me.tbRouteID.Location = New System.Drawing.Point(120, 8)
        Me.tbRouteID.Name = "tbRouteID"
        Me.tbRouteID.Size = New System.Drawing.Size(72, 20)
        Me.tbRouteID.TabIndex = 0
        Me.tbRouteID.Text = "11"
        '
        'btGo
        '
        Me.btGo.Location = New System.Drawing.Point(200, 8)
        Me.btGo.Name = "btGo"
        Me.btGo.TabIndex = 1
        Me.btGo.Text = "Find Dates"
        '
        'TreeView1
        '
        Me.TreeView1.ImageIndex = -1
        Me.TreeView1.Location = New System.Drawing.Point(8, 280)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = -1
        Me.TreeView1.Size = New System.Drawing.Size(121, 272)
        Me.TreeView1.TabIndex = 2
        '
        'TreeView2
        '
        Me.TreeView2.ImageIndex = -1
        Me.TreeView2.Location = New System.Drawing.Point(144, 280)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.SelectedImageIndex = -1
        Me.TreeView2.Size = New System.Drawing.Size(121, 272)
        Me.TreeView2.TabIndex = 3
        '
        'btclear
        '
        Me.btclear.Location = New System.Drawing.Point(32, 56)
        Me.btclear.Name = "btclear"
        Me.btclear.TabIndex = 4
        Me.btclear.Text = "clear all"
        '
        'tvRouteDate
        '
        Me.tvRouteDate.ImageIndex = -1
        Me.tvRouteDate.Location = New System.Drawing.Point(144, 56)
        Me.tvRouteDate.Name = "tvRouteDate"
        Me.tvRouteDate.SelectedImageIndex = -1
        Me.tvRouteDate.Size = New System.Drawing.Size(121, 160)
        Me.tvRouteDate.TabIndex = 5
        '
        'btFixRoute
        '
        Me.btFixRoute.Enabled = False
        Me.btFixRoute.Location = New System.Drawing.Point(160, 224)
        Me.btFixRoute.Name = "btFixRoute"
        Me.btFixRoute.TabIndex = 6
        Me.btFixRoute.Text = "Fix Route"
        '
        'btWriteFixes
        '
        Me.btWriteFixes.Enabled = False
        Me.btWriteFixes.Location = New System.Drawing.Point(16, 560)
        Me.btWriteFixes.Name = "btWriteFixes"
        Me.btWriteFixes.Size = New System.Drawing.Size(96, 23)
        Me.btWriteFixes.TabIndex = 7
        Me.btWriteFixes.Text = "Write Fix to DB"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Enter LRS Route ID:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Old Route Link Data"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(144, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "New Route Link Data"
        '
        'DG_route_links
        '
        Me.DG_route_links.DataMember = ""
        Me.DG_route_links.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DG_route_links.Location = New System.Drawing.Point(280, 48)
        Me.DG_route_links.Name = "DG_route_links"
        Me.DG_route_links.Size = New System.Drawing.Size(640, 504)
        Me.DG_route_links.TabIndex = 11
        '
        'bDelRouteLinks
        '
        Me.bDelRouteLinks.Enabled = False
        Me.bDelRouteLinks.Location = New System.Drawing.Point(288, 560)
        Me.bDelRouteLinks.Name = "bDelRouteLinks"
        Me.bDelRouteLinks.Size = New System.Drawing.Size(112, 23)
        Me.bDelRouteLinks.TabIndex = 12
        Me.bDelRouteLinks.Text = "Delete Route Links"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(376, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Route Links on Retired Transport Links"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Select Connection"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "PIDOTLRS"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "TIDOTLRS"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "DLRS"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(680, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "connect to:"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(760, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 15
        '
        'btClearDate
        '
        Me.btClearDate.Location = New System.Drawing.Point(160, 560)
        Me.btClearDate.Name = "btClearDate"
        Me.btClearDate.TabIndex = 16
        Me.btClearDate.Text = "clear date"
        '
        'btClearAll
        '
        Me.btClearAll.Location = New System.Drawing.Point(288, 8)
        Me.btClearAll.Name = "btClearAll"
        Me.btClearAll.TabIndex = 17
        Me.btClearAll.Text = "Clear All"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(928, 598)
        Me.Controls.Add(Me.btClearAll)
        Me.Controls.Add(Me.btClearDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bDelRouteLinks)
        Me.Controls.Add(Me.DG_route_links)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btWriteFixes)
        Me.Controls.Add(Me.btFixRoute)
        Me.Controls.Add(Me.tvRouteDate)
        Me.Controls.Add(Me.btclear)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btGo)
        Me.Controls.Add(Me.tbRouteID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "LRS Route Ordinal Fixer"
        CType(Me.DG_route_links, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public gapdialogtransportlinkid As Integer = 0
    Public gapdialogreturn As Boolean = False
    Private Sub btGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGo.Click
        If tbRouteID.Text = "" Then
            GoTo END_SUB
        End If
        get_route_dates(tbRouteID.Text)
        MenuItem1.Enabled = False
        'check_ordinals()
END_SUB:
    End Sub
    Private Function get_route_dates(ByVal route_id As Integer)
        Dim route_dates_query As String = "select  distinct effectivestartdate as e_date from idotlrs.route_link_lt where route_id = " + tbRouteID.Text + " union select  distinct effectiveenddate as e_date from idotlrs.route_link_lt where route_id = " + tbRouteID.Text
        Dim daRouteDate As OracleDataAdapter
        Dim dsRouteDate As DataSet
        Dim routenode As TreeNode
        Dim routedate As TreeNode
        Dim row As DataRow

        cnnLRS = New OracleConnection(lrsCon)

        cnnLRS.Open()
        dsRouteDate = New DataSet
        daRouteDate = New OracleDataAdapter(route_dates_query, cnnLRS)
        daRouteDate.Fill(dsRouteDate, "ROUTE_DATES")
        routenode = New TreeNode
        routenode.Text = tbRouteID.Text
        For Each row In dsRouteDate.Tables("ROUTE_DATES").Rows
           
            routedate = New TreeNode
            routedate.Text = (row("e_date"))
            routenode.Nodes.Add(routedate)

        Next
        'routedate = New TreeNode
        'routedate.Text = "02/11/2010"
        'routenode.Nodes.Add(routedate)


        tvRouteDate.Nodes.Add(routenode)
        tvRouteDate.ExpandAll()


    End Function

    Public Function check_ordinals()


        'Dim sCon As String = "data source=tidotlrs;User ID=idotlrs;Password=landobespin"
        'Dim sCon As String = "data source=pidotlrs;User ID=/"
        'Dim sCon As String = "data source=pidotlrs;User ID=lrsgdo;Password=lrsgdo"
        'Dim query As String = " SELECT  tl.transport_link_id, decode(relative_direction,1,tl.transport_node_id_from, tl.transport_node_id_to) tn_from,  decode(relative_direction, -1, tl.transport_node_id_from, tl.transport_node_id_to) tn_to, rl.ordinal, rl.route_id, rl.relative_direction FROM idotlrs.transport_link tl, idotlrs.route_link rl WHERE(tl.transport_link_id = rl.transport_link_id And route_id = " + tbRouteID.Text + ") ORDER BY route_id, ordinal"
        'Dim seteffectivedatequery As String = " select"
        Dim query As String = " SELECT  rl.route_id, rl.route_link_id, tl.transport_link_id,  tl.transport_node_id_from tn_from,  tl.transport_node_id_to tn_to, rl.ordinal, rl.route_id, rl.relative_direction, rl.effectivestartdate FROM idotlrs.transport_link tl, idotlrs.route_link rl WHERE(tl.transport_link_id = rl.transport_link_id And route_id = " + tbRouteID.Text + ") ORDER BY ordinal"
        Dim query_max As String = "select count(ordinal) as max_ordinal from idotlrs.route_link where route_id = " + tbRouteID.Text + ""
        Dim query_min_ordinal As String = "select min(ordinal) as min_ordinal from idotlrs.route_link where route_id = " + tbRouteID.Text + ""
        Dim query_tl_count As String = "select count(transport_link_id) as num_tl from idotlrs.transport_link where transport_link_id in (select transport_link_id from idotlrs.route_link where route_id = " + tbRouteID.Text + ")"
        Dim query_routes As String = "select route_id from idotlrs.route_error where error like 'ROUTE TOPOLOGY IS INVALID'"
        Dim query_bad_rl As String = "select b.transport_link_id as old_tl, b.route_link_id, b.ordinal,b.effectivestartdate rl_start_date, b.effectiveenddate rl_end_date, a.effectivestartdate tl_start_date, a.effectiveenddate tl_end_date from idotlrs.transport_link a, idotlrs.route_link b where a.transport_link_id(+) = b.transport_link_id and b.route_id = " + tbRouteID.Text + " and a.transport_link_id is null"
        'Dim query_route_dates as String ="select distinct
        Dim daLrs As OracleDataAdapter
        Dim daMax As OracleDataAdapter
        Dim daMin As OracleDataAdapter
        Dim daTL As OracleDataAdapter
        'Dim ds As DataSet
        Dim row As DataRow
        Dim rownode As TreeNode
        Dim rowordinal As TreeNode
        Dim rownodefrom As TreeNode
        Dim rownodeto As TreeNode
        Dim rowindex As TreeNode
        Dim roweffectivestartdate As TreeNode
        Dim rowsqlstatement As TreeNode
        Dim match As Boolean
        Dim cmd As OracleCommand

        cnnLRS = New OracleConnection(lrsCon)

        cnnLRS.Open()
        '''''''''''''''''''''''''''''''''

        'Dim revcmd As OracleCommand
        'revcmd = New OracleCommand("BEGIN GTM.SETACTIVEREVISIONSET('61 S'); END;")
        'revcmd.Connection = cnnLRS
        'Try
        '    revcmd.ExecuteNonQuery()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Dim datecmd As OracleCommand
        datecmd = New OracleCommand("BEGIN EDLSYS.EDL.APPLYEFFECTIVEDATEFILTER(TO_DATE('" + effectivedate + "','MM/DD/YYYY'));END;")

        datecmd.Connection = cnnLRS

        Try
            datecmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        datecmd.Dispose()
        ''''''''''''''''''''''''''''''''''''
        ds = New DataSet
        daMax = New OracleDataAdapter(query_max, cnnLRS)
        daMax.Fill(ds, "MAX")
        daMin = New OracleDataAdapter(query_min_ordinal, cnnLRS)
        daMin.Fill(ds, "MIN")
        daTL = New OracleDataAdapter(query_tl_count, cnnLRS)
        daTL.Fill(ds, "TLCOUNT")
        Dim maxordinal As Integer
        Dim minordinal As Integer
        Dim maxtlcount As Integer

        For Each row In ds.Tables("MAX").Rows
            maxordinal = row("max_ordinal")
        Next

        For Each row In ds.Tables("MIN").Rows
            minordinal = row("min_ordinal")
        Next

        For Each row In ds.Tables("TLCOUNT").Rows
            maxtlcount = row("num_tl")
        Next

        If maxordinal <> maxtlcount Then
            Dim daBadRL As OracleDataAdapter
            daBadRL = New OracleDataAdapter(query_bad_rl, cnnLRS)
            daBadRL.Fill(ds, "BADRL")
            DG_route_links.DataSource = ds.Tables("BADRL")
            bDelRouteLinks.Enabled = True

            'Dim form_bad_route_links As bad_route_links
            'form_bad_route_links = New bad_route_links
            'form_bad_route_links.DG_route_links.DataSource = ds.Tables("BADRL")
            'form_bad_route_links.caller = Me
            'form_bad_route_links.Text = "Route Links on Retired Transport Links " + effectivedate
            'form_bad_route_links.ds = ds
            'form_bad_route_links.ShowDialog()
        Else
BAD_RL_CONT:
            daLrs = New OracleDataAdapter(query, cnnLRS)
            daLrs.Fill(ds, "ROUTE")

            For Each row In ds.Tables("ROUTE").Rows
                rownode = New TreeNode
                rownode.Text = (row("transport_link_id"))
                rowordinal = New TreeNode
                rowordinal.Text = (row("ordinal"))
                rownodefrom = New TreeNode
                rownodefrom.Text = (row("tn_from"))
                rownodeto = New TreeNode
                rownodeto.Text = (row("tn_to"))
                roweffectivestartdate = New TreeNode
                roweffectivestartdate.Text = (row("effectivestartdate"))
                rownode.Nodes.Add(rowordinal)
                rownode.Nodes.Add(rownodefrom)
                rownode.Nodes.Add(rownodeto)
                rownode.Nodes.Add(roweffectivestartdate)
                TreeView1.Nodes.Add(rownode)

            Next
            'Dim maxOrdinal As Integer
            ''maxOrdinal = ds.Tables("MAX").Rows(1).
            'For Each row In ds.Tables("MAX").Rows
            '    maxOrdinal = row("max_ordinal")
            'Next
            Dim routelinks(maxordinal - 1) As routeLink
            Dim counter As Integer
            Dim counter2 As Integer
            counter = 0
            match = False
            For Each row In ds.Tables("ROUTE").Rows
                routelinks(counter).ordinal = row("ordinal")
                routelinks(counter).transportLinkId = row("transport_link_id")
                routelinks(counter).transportNodeFrom = row("tn_from")
                routelinks(counter).transportNodeTo = row("tn_to")
                routelinks(counter).relativeDirection = row("relative_direction")
                routelinks(counter).routelinkid = row("route_link_id")
                routelinks(counter).index = counter
                routelinks(counter).routeId = row("route_id")
                routelinks(counter).effectivestartdate = row("effectivestartdate")
                routelinks(counter).color = Color.White
                counter = counter + 1
            Next
            counter = 0
            counter2 = 0

            Dim routelinks2(maxordinal - 1) As routeLink
            'find first ordinal

            '''the new way
            Do While counter < maxordinal
                If routelinks(counter).ordinal = minordinal Then
                    routelinks2(0) = routelinks(counter)
                    routelinks2(0).index = 1
                    Exit Do
                End If
                counter = counter + 1
            Loop
            ''''the old way
            'Do While counter < maxordinal
            '    If routelinks(counter).ordinal = 1 Then
            '        routelinks2(0) = routelinks(counter)
            '        routelinks2(0).index = 1
            '        Exit Do
            '    End If
            '    counter = counter + 1
            'Loop
            counter = 1
            counter2 = 1

            Do While counter2 < maxordinal
                Do While counter < maxordinal  'change this to counter < routelinks.length
                    If routelinks(counter).transportLinkId <> routelinks2(counter2 - 1).transportLinkId Then
                        If routelinks(counter).transportNodeFrom = routelinks2(counter2 - 1).transportNodeTo Then
                            routelinks2(counter2) = routelinks(counter)
                            routelinks2(counter2).index = counter2 + 1
                            routelinks = removeitem(routelinks, counter)
                            match = True
                            Console.WriteLine("match 1")
                            Exit Do
                        ElseIf routelinks(counter).transportNodeFrom = routelinks2(counter2 - 1).transportNodeFrom Then
                            routelinks2(counter2) = routelinks(counter)
                            routelinks2(counter2).index = counter2 + 1
                            routelinks = removeitem(routelinks, counter)
                            match = True
                            Console.WriteLine("match 2")
                            Exit Do
                        ElseIf routelinks(counter).transportNodeTo = routelinks2(counter2 - 1).transportNodeTo Then
                            routelinks2(counter2) = routelinks(counter)
                            routelinks2(counter2).index = counter2 + 1
                            routelinks = removeitem(routelinks, counter)
                            match = True
                            Console.WriteLine("match 3")
                            Exit Do
                        ElseIf routelinks(counter).transportNodeTo = routelinks2(counter2 - 1).transportNodeFrom Then
                            routelinks2(counter2) = routelinks(counter)
                            routelinks2(counter2).index = counter2 + 1
                            routelinks = removeitem(routelinks, counter)
                            match = True
                            Console.WriteLine("match 4")
                            Exit Do

                        End If
                    End If

                    counter = counter + 1
                Loop 'end of counter loop (inner loop)
                If match = False Then
                    If counter2 = maxordinal Then
                        Exit Do
                    Else
                        'MsgBox("gap in route at ordinal " & counter2)
GAP_DIALOG:
                        Dim gapdialog As New gapdialog
                        gapdialog.Label4.Text = routelinks2(counter2 - 1).transportLinkId
                        gapdialog.Label2.Text = routelinks2(counter2 - 1).ordinal
                        gapdialog.caller = Me
                        gapdialog.ShowDialog()
                        If gapdialogreturn = True Then

                            counter = 1
                            Do While counter < maxordinal
                                If routelinks(counter).transportLinkId = gapdialogtransportlinkid Then
                                    routelinks2(counter2) = routelinks(counter)
                                    routelinks2(counter2).index = counter2 + 1
                                    routelinks = removeitem(routelinks, counter)
                                    Exit Do
                                End If
                                counter = counter + 1
                            Loop
                            gapdialogreturn = False
                        ElseIf MessageBox.Show("You must enter a transport link.  If you wish to stop then click Cancel", "Title", MessageBoxButtons.RetryCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) = DialogResult.Retry Then
                            GoTo GAP_DIALOG
                        Else 'you cancel 
                            MessageBox.Show("You chose to cancel, please clear and try again")
                            Exit Do
                        End If



                    End If
                End If
                match = False
                counter = 1
                counter2 = counter2 + 1
            Loop 'end of big outer loop

            counter = 0
            counter2 = 0
            Dim problembool As Boolean = False
            Do While counter < maxordinal
                rownode = New TreeNode
                rownode.Text = routelinks2(counter).transportLinkId
                rowordinal = New TreeNode
                rowordinal.Text = routelinks2(counter).ordinal
                rownodefrom = New TreeNode
                rownodefrom.Text = routelinks2(counter).transportNodeFrom
                rownodeto = New TreeNode
                rownodeto.Text = routelinks2(counter).transportNodeTo
                rowindex = New TreeNode
                rowindex.Text = routelinks2(counter).index
                roweffectivestartdate = New TreeNode
                roweffectivestartdate.Text = routelinks2(counter).effectivestartdate
                Dim outputsql As String

                rownode.Nodes.Add(rowordinal)
                rownode.Nodes.Add(rownodefrom)
                rownode.Nodes.Add(rownodeto)
                rownode.Nodes.Add(rowindex)
                rownode.Nodes.Add(roweffectivestartdate)
                If rowordinal.Text <> rowindex.Text Then
                    'Dim outputsql As String = "insert into idotlrs.aa_fix_route_topology (route_id, route_link_id, transport_node_id_to, transport_node_id_from, transport_link_id, ordinal, new_ordinal, effectivestartdate) values (" + routelinks2(counter).routeId.ToString + "," + routelinks2(counter).routelinkid.ToString + "," + routelinks2(counter).transportNodeTo.ToString + "," + routelinks2(counter).transportNodeFrom.ToString + "," + routelinks2(counter).transportLinkId.ToString + "," + routelinks2(counter).ordinal.ToString + "," + routelinks2(counter).index.ToString + "," + routelinks2(counter).effectivestartdate + ")"
                    'rownode.BackColor = Color.Yellow
                    'rowsqlstatement = New TreeNode
                    'rowsqlstatement.Text = outputsql
                    'rownode.Nodes.Add(rowsqlstatement)
                    problembool = True
                End If
                If problembool Then
                    outputsql = "insert into idotlrs.aa_fix_route_topology (route_id, route_link_id, transport_node_id_to, transport_node_id_from, transport_link_id, ordinal, new_ordinal, effectivestartdate) values (" + routelinks2(counter).routeId.ToString + "," + routelinks2(counter).routelinkid.ToString + "," + routelinks2(counter).transportNodeTo.ToString + "," + routelinks2(counter).transportNodeFrom.ToString + "," + routelinks2(counter).transportLinkId.ToString + "," + routelinks2(counter).ordinal.ToString + "," + routelinks2(counter).index.ToString + ", to_date('" + effectivedate + "','MM/DD/YYYY'))"
                    rownode.BackColor = Color.Yellow
                    rowsqlstatement = New TreeNode
                    rowsqlstatement.Text = outputsql
                    rownode.Nodes.Add(rowsqlstatement)
                    'cmd = New OracleCommand
                    'cmd.Connection = cnnLRS
                    'cmd.CommandText = outputsql
                    'cmd.CommandType = CommandType.Text
                    'Try
                    '    cmd.ExecuteNonQuery()
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try
                    'cmd.Dispose()
                End If
                TreeView2.Nodes.Add(rownode)
                counter = counter + 1

            Loop

        End If 'end the maxordinal <> maxtlcount 
        btWriteFixes.Enabled = True

    End Function
    Private Function removeitem(ByVal a() As routeLink, ByVal i As Integer) As routeLink()
        Console.WriteLine("remove_transport_link_id " + a(i).transportLinkId.ToString)
        'Console.WriteLine("length going in " + a.Length.ToString)
        Dim returnarray(a.Length - 1) As routeLink
        Dim x As Integer = 0

        If i = 0 Then 'remove first item
            'Console.WriteLine("remove first item " + a(i).transportLinkId.ToString)
            For y As Integer = 0 To (returnarray.Length - 2)
                returnarray(y) = a(x + 1)
                x = x + 1
            Next

        ElseIf i = a.Length Then ' remove last item
            'Console.WriteLine("remove last item " + a(i).transportLinkId.ToString)
            For y As Integer = 0 To (returnarray.Length - 3)
                returnarray(y) = a(x)
                x = x + 1
            Next

        Else ' remove item in the middle somewhere
            'Console.WriteLine("remove in the middle " + a(i).transportLinkId.ToString)
            For y As Integer = 0 To i - 1
                returnarray(y) = a(x)
                x = x + 1
            Next
            x = x + 1
            For y As Integer = i To (returnarray.Length - 2)
                returnarray(y) = a(x)
                x = x + 1
            Next
        End If
        'Console.WriteLine("length going out " + returnarray.Length.ToString)
        Return returnarray
    End Function


    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btclear.Click
        'clear out the trees somehow
        tvRouteDate.Nodes.Clear()
        TreeView1.Nodes.Clear()
        TreeView2.Nodes.Clear()
        btFixRoute.Enabled = False
        btWriteFixes.Enabled = False
        DG_route_links.DataSource = Nothing
        DG_route_links.Refresh()
        bDelRouteLinks.Enabled = False

    End Sub
    Private Sub btClearDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearDate.Click
        'clear out the trees somehow
        'tvRouteDate.Nodes.Clear()
        TreeView1.Nodes.Clear()
        TreeView2.Nodes.Clear()
        btFixRoute.Enabled = False
        btWriteFixes.Enabled = False
        DG_route_links.DataSource = Nothing
        DG_route_links.Refresh()
        bDelRouteLinks.Enabled = False
    End Sub

    Private Sub btClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearAll.Click
        tvRouteDate.Nodes.Clear()
        TreeView1.Nodes.Clear()
        TreeView2.Nodes.Clear()
        btFixRoute.Enabled = False
        btWriteFixes.Enabled = False
        DG_route_links.DataSource = Nothing
        DG_route_links.Refresh()
        bDelRouteLinks.Enabled = False
    End Sub



    Private Sub tvRouteDate_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvRouteDate.AfterSelect

        If e.Node.Text() <> tbRouteID.Text Then
            btFixRoute.Enabled = True
            effectivedate = e.Node.Text
            Dim backcolor As System.Drawing.Color



            clear_tree_background_colors(tvRouteDate)


            e.Node.BackColor = System.Drawing.Color.Aqua

        End If


    End Sub

    Private Sub btFixRoute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFixRoute.Click
        'setdatefilter(effectivedate)
        check_ordinals()

    End Sub
    Public Function clear_tree_background_colors(ByVal e As System.Windows.Forms.TreeView)


        For Each tn As TreeNode In e.Nodes
            For Each n As TreeNode In tn.Nodes
                n.BackColor = System.Drawing.Color.White
            Next

        Next
    End Function

    Private Sub setdatefilter(ByVal s_effectivedate As String)
        Dim datecmd As OracleCommand
        datecmd = New OracleCommand("BEGIN EDLSYS.EDL.APPLYEFFECTIVEDATEFILTER(TO_DATE('" + s_effectivedate + "','MM/DD/YYYY'),'TRUE');END;")

        datecmd.Connection = cnnLRS

        Try
            datecmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        datecmd.Dispose()
    End Sub

    Private Sub btWriteFixes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btWriteFixes.Click
        If is_table_clear() Then
            write_fixes()
            btWriteFixes.Enabled = False
        Else
            MessageBox.Show("oracle table was not cleared. Recheck last route")
            clear_oracle_table()
            write_fixes()
            btWriteFixes.Enabled = False
        End If

    End Sub
    Public Function is_table_clear() As Boolean
        Dim query_empty As String = "SELECT COUNT(*) C FROM IDOTLRS.AA_FIX_ROUTE_TOPOLOGY"
        Dim DA As OracleDataAdapter
        Dim DS As DataSet
        Dim ROW As DataRow
        Dim RECORD_COUNT As Integer

        DA = New OracleDataAdapter(query_empty, cnnLRS)
        DS = New DataSet
        DA.Fill(DS, "COUNT_RECORDS")
        For Each ROW In DS.Tables("COUNT_RECORDS").Rows
            RECORD_COUNT = ROW("C")
        Next
        If RECORD_COUNT = 0 Then
            Return True
        Else
            Return False
        End If


    End Function
    Public Sub clear_oracle_table()
        Dim cmd As OracleCommand
        cmd = New OracleCommand("begin delete from idotlrs.aa_fix_route_topology; end;")
        cmd.Connection = cnnLRS
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cmd.Dispose()
    End Sub
    Public Function write_fixes()
        Dim cmd As OracleCommand
        Dim numtree As Integer
        Dim i As Integer = 0
        numtree = TreeView2.GetNodeCount(False)
        Do While i < numtree
            If TreeView2.Nodes(i).GetNodeCount(False) = 6 Then
                cmd = New OracleCommand
                cmd.Connection = cnnLRS
                cmd.CommandText = TreeView2.Nodes(i).Nodes(5).Text
                cmd.CommandType = CommandType.Text
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                cmd.Dispose()
            End If

            i = i + 1
        Loop
        MessageBox.Show("this will take a few moments")
        Dim fixordinalsproc As OracleCommand
        fixordinalsproc = New OracleCommand
        fixordinalsproc.Connection = cnnLRS
        fixordinalsproc.CommandText = "BEGIN IDOTLRS.AA_FIX_ORDINALS_WITH_VB(); END;"
        fixordinalsproc.CommandType = CommandType.Text
        Try
            fixordinalsproc.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        MessageBox.Show("Done")

    End Function
    Public Function delete_route_links()
        'Public Function delete_route_links(ByVal dsi As DataSet)
        'delete the route links found in the dataset ds.Tables("BADRL")

        'create revision set name
        Dim revsetname As String = "del RL on " + tbRouteID.Text + " " + Replace(effectivedate, "/", "")

        'create revision set
        Dim rcmd As OracleCommand
        rcmd = New OracleCommand
        rcmd.Connection = cnnLRS
        rcmd.CommandText = "BEGIN GDOSYS.GTM.CREATEREVISIONSET ('" + revsetname + "');END;"
        rcmd.CommandType = CommandType.Text
        Try
            rcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        rcmd.Dispose()
        'insert into revision_set_metadata (set default effective date)
        Dim rscmd As OracleCommand
        rscmd = New OracleCommand
        rscmd.Connection = cnnLRS
        rscmd.CommandText = "SELECT REVSET_ID FROM GDOSYS.LTT_REVISION_SETS  WHERE REVSET_NAME = '" + revsetname + "' AND REVSET_STATUS = 'O'"
        rscmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = rscmd.ExecuteReader()
        dr.Read()
        Dim revsetid As Long = dr.Item("REVSET_ID")


        Dim rsmcmd As OracleCommand
        rsmcmd = New OracleCommand
        rsmcmd.Connection = cnnLRS
        rsmcmd.CommandText = "INSERT INTO GDOSYS.LTT_REVISION_SET_METADATA VALUES (" + revsetid.ToString + ",'LRS',1,to_date('" + effectivedate + "','MM/DD/YYYY'))"
        rsmcmd.CommandType = CommandType.Text
        Try
            rsmcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'insert into lrs_metadata
        Dim lmcmd As OracleCommand
        lmcmd = New OracleCommand
        lmcmd.Connection = cnnLRS
        lmcmd.CommandText = "INSERT INTO GDOSYS.LRS_METADATA VALUES (" + revsetid.ToString + ",1,1,'DISABLED')"
        lmcmd.CommandType = CommandType.Text
        Try
            lmcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'activeate revision set
        Dim activerevisionset As OracleCommand
        activerevisionset = New OracleCommand
        activerevisionset.Connection = cnnLRS
        activerevisionset.CommandText = "BEGIN GDOSYS.GTM.SETACTIVEREVISIONSET ('" + revsetname + "'); END;"
        activerevisionset.CommandType = CommandType.Text
        Try
            activerevisionset.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'apply date filter
        Dim datefiltercmd As OracleCommand
        datefiltercmd = New OracleCommand
        datefiltercmd.Connection = cnnLRS
        datefiltercmd.CommandText = "BEGIN EDLSYS.EDL.APPLYEFFECTIVEDATEFILTER (to_date('" + effectivedate + "','MM/DD/YYYY'));END;"
        datefiltercmd.CommandType = CommandType.Text
        Try
            datefiltercmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'loop through the records in ds.Tables("BADRL")
        Dim row As DataRow
        For Each row In ds.Tables("BADRL").Rows
            'MsgBox(row("route_link_id"))
            'delete the records
            Dim delrl As OracleCommand
            delrl = New OracleCommand
            delrl.Connection = cnnLRS
            delrl.CommandText = "DELETE FROM IDOTLRS.ROUTE_LINK WHERE ROUTE_LINK_ID = " + row("route_link_id").ToString
            delrl.CommandType = CommandType.Text
            Try
                delrl.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'commit revision set
        Dim commitrs As OracleCommand
        commitrs = New OracleCommand
        commitrs.Connection = cnnLRS
        commitrs.CommandText = "BEGIN GDOSYS.GTM.COMMITREVISIONSET ('" + revsetname + "'); END;"
        commitrs.CommandType = CommandType.Text
        Try
            commitrs.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        DG_route_links.DataSource = Nothing
        DG_route_links.Refresh()
        bDelRouteLinks.Enabled = False

        'GoTo BAD_RL_CONT()

    End Function

    Private Sub bDelRouteLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDelRouteLinks.Click
        'delete_route_links(ds)
        delete_route_links()
        MessageBox.Show("deleted route links")
        check_ordinals()

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        'pidotlrs
        Console.WriteLine("picked plrs")
        Label6.Text = "plrs"
        lrsCon = "data source=plrs;" + "Integrated Security=Yes;"

        'Dim lrsCon As String = "data source=dlrs;" + "Integrated Security=Yes;"

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        'tidotlrs
        Console.WriteLine("picked tlrs")
        Label6.Text = "tlrs"
        lrsCon = "data source=tlrs;" + "Integrated Security=Yes;"
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        'dlrs
        Console.WriteLine("picked dlrs")
        Label6.Text = "dlrs"
        lrsCon = "data source=dlrs;" + "Integrated Security=Yes;"
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Label6.Text = "plrs"
        lrsCon = "data source=plrs;" + "Integrated Security=Yes;"
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        'btWriteFixes.Left()
        btWriteFixes.Top = Me.Size.Height - 93
        btclear.Top = Me.Size.Height - 93
        bDelRouteLinks.Top = Me.Size.Height - 93
        DG_route_links.Size = New System.Drawing.Size((Me.Size.Width - 296), (Me.Size.Height - 149))

    End Sub



   
End Class
Structure routeLink
    Dim transportLinkId As Integer
    Dim transportNodeFrom As Integer
    Dim transportNodeTo As Integer
    Dim ordinal As Integer
    Dim routeId As Integer
    Dim relativeDirection As Integer
    Dim index As Integer
    Dim routelinkid As Integer
    Dim effectivestartdate As Date
    Dim color As Color
End Structure

