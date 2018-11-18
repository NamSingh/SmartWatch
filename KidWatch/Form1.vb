Public Class Form1

    Private currentpg = 0
    Dim Time As New DateTime
    Dim balance = 6.51
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.TimePanel.Visible = True
        Me.AppPanel.Visible = False
        Me.CallPanel.Visible = False
        Me.Bankpanel.Visible = False
        Me.AppPanel2.Visible = False
        Me.TimeLabel.Text = Now.ToShortTimeString.ToString()
        Timer1.Start()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TimeLabel.Text = Now.ToShortTimeString.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles RightButton.Click
        If currentpg = 0 Then
            currentpg = 1
            Me.TimePanel.Visible = False
            Me.AppPanel.Visible = True
            Me.AppPanel2.Visible = False

        ElseIf currentpg = 1 Then
            currentpg = 2
            Me.TimePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = True

        ElseIf currentpg = 2 Then
            currentpg = 0
            Me.TimePanel.Visible = True
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False
        End If
    End Sub

    Private Sub LeftButton_Click(sender As Object, e As EventArgs) Handles LeftButton.Click
        If currentpg = 0 Then
            currentpg = 2
            Me.TimePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = True

        ElseIf currentpg = 1 Then
            currentpg = 0
            Me.TimePanel.Visible = True
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False

        ElseIf currentpg = 2 Then
            currentpg = 1
            Me.TimePanel.Visible = False
            Me.AppPanel.Visible = True
            Me.AppPanel2.Visible = False
        End If


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.PictureBox5.Visible = False
        Me.PictureBox6.Visible = True
        Me.PictureBox7.Visible = False
        Me.CallPanel.BackColor = Color.Green
        Time = DateTime.Now
        Timer2.Start()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles CallTimeLabel.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Difference As TimeSpan = DateTime.Now.Subtract(Time)
        CallTimeLabel.Text = Difference.Days.ToString & ":" & Difference.Hours.ToString & ":" & Difference.Minutes.ToString & ":" & Difference.Seconds.ToString & "." & Difference.Milliseconds.ToString
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.PictureBox6.Visible = False
        Me.PictureBox5.Visible = False
        Me.PictureBox7.Visible = True
        Me.CallPanel.BackColor = Color.Red
        Me.Label2.Visible = True
        Timer2.Stop()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ' If Me.Label4.Text.Equals("$1.50") Then
        'Me.Label6.Visible = True
        ' Else
        'Me.Label4.Text = "$4.50"
        ' Me.Label6.Visible = True
        ' Me.Label6.ForeColor = Color.Green
        ' Me.Label6.Text = "Purchased Tickets!"
        ' End If


        If balance < 10 Then
            Me.Label6.Visible = True
        Else
            balance = balance - 10
            Me.Label4.Text = "$" + balance.ToString
            Label22.Text = Label4.Text
            Me.Label6.Visible = True
            Me.Label6.ForeColor = Color.Green
            Me.Label6.Text = "Purchased Tickets!"
        End If



    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        clear()
        Me.CallPanel.Visible = True
    End Sub

    Public Sub clear()
        Me.TimePanel.Visible = False
        Me.AppPanel.Visible = False
        Me.CallPanel.Visible = False
        Me.Bankpanel.Visible = False
        Me.AppPanel2.Visible = False
        Me.SettingPanel.Visible = False
        Me.GpsPanel.Visible = False
        Me.SchedulePanel.Visible = False
        Me.SoccerDetails.Visible = False
        Me.StudyDetails.Visible = False
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, PictureBox12.Click, PictureBox14.Click, PictureBox15.Click
        clear()
        Me.TimePanel.Visible = True
        currentpg = 0
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        clear()
        Me.Bankpanel.Visible = True
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ProgressBar1.Value = 100 Then
        Else
            ProgressBar1.Value = ProgressBar1.Value + 10
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ProgressBar1.Value = 0 Then
        Else
            ProgressBar1.Value = ProgressBar1.Value - 10
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ProgressBar2.Value = 100 Then
        Else
            ProgressBar2.Value = ProgressBar2.Value + 10
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ProgressBar2.Value = 0 Then
        Else
            ProgressBar2.Value = ProgressBar2.Value - 10
        End If

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        clear()
        Me.SettingPanel.Visible = True
    End Sub

    Private Sub PhoneFrame_Click(sender As Object, e As EventArgs) Handles PhoneFrame.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        clearphone()
        ReminderPanel.Visible = True
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    '================================================================================

    Private Sub SosButton_Click(sender As Object, e As EventArgs) Handles SosButton.Click
        LocateSosPanel.Visible = True
        Label16.Text = "SOS FROM CHILD"
        LocateSosPanel.BringToFront()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        clear()
        Me.GpsPic1.Visible = True
        Me.GpsPanel.Visible = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Alert.Visible = True
        Alert.BringToFront()
        If TextBox1.Text.Equals("") Then
        Else
            MessageBox.Text = TextBox1.Text
        End If
    End Sub

    Private Sub EndAlertButton_Click(sender As Object, e As EventArgs) Handles EndAlertButton.Click
        Alert.Visible = False
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        clearphone()
        SamsungMain.Visible = True
    End Sub


    Public Sub clearphone()
        ReminderPanel.Visible = False
        SamsungMain.Visible = False
        LocateSosPanel.Visible = False
        FundsPanel.Visible = False
        DailySchedPanel.Visible = False
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        LocateSosPanel.Visible = True
        LocateSosPanel.BringToFront()
    End Sub

    Private Sub LocateChildPicBox_Click(sender As Object, e As EventArgs) Handles LocateChildPicBox.Click
        LocateChildPicBox.Visible = False
        SendLocPic.Visible = True
        Label19.Text = "Send Child to: Esso Gas Station"
    End Sub

    Private Sub SendLoc_Click(sender As Object, e As EventArgs) Handles SendLoc.Click
        GpsPic1.Visible = False
        GpsPic2.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Label4.Text = "$" + (Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(Label4.Text)).ToString
        'Label22.Text = Label4.Text

        balance = (Convert.ToDouble(TextBox2.Text) + balance)

        Label4.Text = "$" + balance.ToString

        Label22.Text = Label4.Text
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Label22.Text = Label4.Text
        FundsPanel.Visible = True
        FundsPanel.BringToFront()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        clear()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dddd, MMMM dd"
        DateTimePicker1.Value = Today
        SchedulePanel.Visible = True

    End Sub

    Private Sub ShowSoccerDetails_Click(sender As Object, e As EventArgs) Handles soccerBall.Click, SoccerPanel.Click, SoccerLabel.Click, SoccerTime.Click
        clear()
        SoccerDetails.Visible = True
    End Sub

    Private Sub ShowStudyDetails_Click(sender As Object, e As EventArgs) Handles StudyPic.Click, StudyPanel.Click, StudyTime.Click, StudyLabel.Click
        clear()
        StudyDetails.Visible = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value = Today Then
            SoccerPanel.Visible = True
            StudyPanel.Visible = True
        Else
            SoccerPanel.Visible = False
            StudyPanel.Visible = False
        End If

    End Sub

    Private Sub SheduleBack_Click(sender As Object, e As EventArgs) Handles SoccerBack.Click, StudyBack.Click
        clear()
        SchedulePanel.Visible = True

    End Sub

    Private Sub ScheduleHome_Click(sender As Object, e As EventArgs) Handles StudyHome.Click, SoccerHome.Click
        clear()
        currentpg = 0
        TimePanel.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SoccerPanel.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        StudyPanel.Visible = True
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        clearphone()
        DailySchedPanel.Visible = True
    End Sub
End Class
