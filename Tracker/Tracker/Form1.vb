Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim daEvents As New SqlDataAdapter
    Dim dsEvents As New DataSet
    Dim daAttend As New SqlDataAdapter
    Dim dsAttend As New DataSet
    Dim daTeam As New SqlDataAdapter
    Dim dsTeam As New DataSet
    Dim sqlconn As New SqlConnection

    Private Sub form1_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlconn.ConnectionString = "Data Source=localhost\sqlexpress;Initial Catalog=Tracker;Integrated Security=True"
        Dim SQLEvents As String = "select * from event order by eventid"
        sqlconn.Open()
        daEvents = New SqlDataAdapter(SQLEvents, sqlconn)
        sqlconn.Close()
        daEvents.Fill(dsEvents, "dsEvents")
        DataGridView1.DataSource = dsEvents.Tables(0)
    End Sub

#Region "FormClickEvents"
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox4.Text = WeekdayName(Weekday(DateTimePicker1.Value, 0), 0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        Dim newEventRow As DataRow = dsEvents.Tables("dsEvents").NewRow()
        newEventRow("eventid") = Me.TextBox1.Text
        newEventRow("eventname") = Me.TextBox2.Text
        newEventRow("date") = Me.DateTimePicker1.Value
        newEventRow("day") = Me.TextBox4.Text
        DataGridView1.DataSource = Nothing
        dsEvents.Tables("dsEvents").Rows.Add(newEventRow)
        DataGridView1.DataSource = dsEvents.Tables(0)
        btnAddRecord.Enabled = False
    End Sub

    Private Sub btnNewEvent_Click(sender As Object, e As EventArgs) Handles btnNewEvent.Click
        Dim iLastEventID As Integer = dsEvents.Tables(0).Compute("Max(Eventid)", Nothing)
        TextBox1.Text = iLastEventID + 1
        btnAddRecord.Enabled = True
    End Sub
#End Region

#Region "GridClickEvents"

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        DataGridView2.DataSource = Nothing
        dsAttend.Clear()
        TextBox1.Text = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        TextBox2.Text = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
        DateTimePicker1.Value = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
        TextBox4.Text = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value
        Dim vareventid As Integer = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        Dim SQLAttendance As String = "select name, present from vAttendEvent where eventid = " + Convert.ToString(vareventid)
        sqlconn.Open()
        daAttend = New SqlDataAdapter(SQLAttendance, sqlconn)
        sqlconn.Close()
        daAttend.Fill(dsAttend, "dsAttend")
        DataGridView2.DataSource = dsAttend.Tables(0)

        'Dim ChkBox As New DataGridViewCheckBoxColumn
        'ChkBox.FlatStyle = FlatStyle.Standard
        'DataGridView2.Columns.Insert(2, ChkBox)
        'DataGridView2.ReadOnly = True
        DataGridView2.Columns(0).ReadOnly = True

    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        DataGridView3.DataSource = Nothing
        dsTeam.Clear()
        Dim strName As String = DataGridView2.Item(0, DataGridView2.CurrentRow.Index).Value
        Dim SQLTeam As String = "select name, role, offrole from team where name = '" + strName + "'"
        sqlconn.Open()
        daTeam = New SqlDataAdapter(SQLTeam, sqlconn)
        sqlconn.Close()
        daTeam.Fill(dsTeam, "dsTeam")
        DataGridView3.DataSource = dsTeam.Tables(0)
        TabControl1.SelectedTab = TabPage2
    End Sub
#End Region
End Class