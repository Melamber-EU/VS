Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim daEvents As New SqlDataAdapter
    Dim dsEvents As New DataSet
    Dim daAttend As New SqlDataAdapter
    Dim dsAttend As New DataSet
    '...4

    Dim sqlconn As New SqlConnection

    Private Sub form1_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        'sqlconn.ConnectionString = "Data Source=localhost\sqlexpress;Initial Catalog=Tracker;Integrated Security=True"
        Dim SQLEvents As String = "select * from event order by eventid"
        sqlconn.Open()
        daEvents = New SqlDataAdapter(SQLEvents, sqlconn)
        sqlconn.Close()
        daEvents.Fill(dsEvents, "dsEvents")
        DataGridView1.DataSource = dsEvents.Tables(0)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        Dim newEventRow As DataRow = dsEvents.Tables("dsEvents").NewRow()

        newEventRow("eventid") = Me.TextBox1.Text
        newEventRow("eventname") = Me.TextBox2.Text
        newEventRow("date") = Me.DateTimePicker1.Value
        newEventRow("day") = Me.TextBox4.Text

        Me.DataGridView1.DataSource = Nothing
        dsEvents.Tables("dsEvents").Rows.Add(newEventRow)
        DataGridView1.DataSource = dsEvents.Tables(0)

        Me.btnAddRecord.Enabled = False
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.DataGridView2.DataSource = Nothing
        dsAttend.Clear()

        Me.TextBox1.Text = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        Me.TextBox2.Text = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
        Me.DateTimePicker1.Value = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
        Me.TextBox4.Text = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value

        Dim vareventid As Integer = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value

        Dim SQLAttendance As String = "select name, present from vAttendEvent where eventid = " + Convert.ToString(vareventid)

        sqlconn.Open()
        daAttend = New SqlDataAdapter(SQLAttendance, sqlconn)
        sqlconn.Close()

        daAttend.Fill(dsAttend, "dsAttend")

        DataGridView2.DataSource = dsAttend.Tables(0)

    End Sub

    Private Sub btnNewEvent_Click(sender As Object, e As EventArgs) Handles btnNewEvent.Click
        Dim iLastEventID As Integer = dsEvents.Tables(0).Compute("Max(Eventid)", Nothing)
        Me.TextBox1.Text = iLastEventID + 1
        Me.btnAddRecord.Enabled = True


    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Me.TextBox4.Text = WeekdayName(Weekday(DateTimePicker1.Value, 0), 0, 0)

    End Sub
End Class
