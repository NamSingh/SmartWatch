Public Class Smartwatch

    Private currentpg = 0
    Dim Time As New DateTime
    Public balance = 6.51
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.HomePagePanel.Visible = True
        Me.AppPanel.Visible = False
        Me.PhoneAppPanel.Visible = False
        Me.AllowanceAppPanel.Visible = False
        Me.AppPanel2.Visible = False
        Me.HomeTimeLabel.Text = Now.ToShortTimeString.ToString()
        Timer1.Start()

        ' Add any initialization after the InitializeComponent() call.
        Phone.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.HomeTimeLabel.Text = Now.ToShortTimeString.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles RightButton.Click
        If currentpg = 0 Then
            currentpg = 1
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = True
            Me.AppPanel2.Visible = False

        ElseIf currentpg = 1 Then
            currentpg = 2
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = True

        ElseIf currentpg = 2 Then
            currentpg = 0
            Me.HomePagePanel.Visible = True
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False
        End If
    End Sub

    Private Sub LeftButton_Click(sender As Object, e As EventArgs) Handles LeftButton.Click
        If currentpg = 0 Then
            currentpg = 2
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = True

        ElseIf currentpg = 1 Then
            currentpg = 0
            Me.HomePagePanel.Visible = True
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False

        ElseIf currentpg = 2 Then
            currentpg = 1
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = True
            Me.AppPanel2.Visible = False
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles CallButton.Click
        Me.CallButton.Visible = False
        Me.EndCallButton.Visible = True
        Me.CallHomeButton.Visible = False
        Me.PhoneAppPanel.BackColor = Color.Green
        Time = DateTime.Now
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Difference As TimeSpan = DateTime.Now.Subtract(Time)
        CallTimeLabel.Text = Difference.Days.ToString & ":" & Difference.Hours.ToString & ":" & Difference.Minutes.ToString & ":" & Difference.Seconds.ToString & "." & Difference.Milliseconds.ToString
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles EndCallButton.Click
        Me.EndCallButton.Visible = False
        Me.CallButton.Visible = False
        Me.CallHomeButton.Visible = True
        Me.PhoneAppPanel.BackColor = Color.Red
        Me.CallEndLabel.Visible = True
        Timer2.Stop()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HomeDateLabel.Text = Today.ToString("dddd, MMMM dd")

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles PayButton.Click

        If balance < 10 Then
            Me.AllowanceLabel3.Visible = True
        Else
            balance = balance - 10
            Me.AllowanceLabel2.Text = "$" + balance.ToString
            Phone.Label22.Text = AllowanceLabel2.Text
            Me.AllowanceLabel3.Visible = True
            Me.AllowanceLabel3.ForeColor = Color.Green
            Me.AllowanceLabel3.Text = "Purchased Tickets!"
        End If



    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PhoneAppIcon.Click
        clear()
        DisableSwipe()
        Me.PhoneAppPanel.Visible = True
    End Sub

    Public Sub clear()
        Me.HomePagePanel.Visible = False
        Me.AppPanel.Visible = False
        Me.PhoneAppPanel.Visible = False
        Me.AllowanceAppPanel.Visible = False
        Me.AppPanel2.Visible = False
        Me.SettingPanel.Visible = False
        Me.GpsAppPanel.Visible = False
        Me.ScheduleAppPanel.Visible = False
        Me.SoccerDetails.Visible = False
        Me.StudyDetails.Visible = False
        IncomingCallPanel.Visible = False
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles CallHomeButton.Click, AllowanceHome.Click, SettingsHome.Click, GPSHomeButton.Click, StudyHome.Click, SoccerHome.Click, ScheduleHome.Click
        clear()
        Me.HomePagePanel.Visible = True
        currentpg = 0
        LeftButton.Visible = True
        RightButton.Visible = True
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles AllowanceAppIcon.Click
        clear()
        DisableSwipe()
        Me.AllowanceAppPanel.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles HigherBright.Click
        If BrightnessBar.Value = 100 Then
        Else
            BrightnessBar.Value = BrightnessBar.Value + 10
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles LowerBright.Click
        If BrightnessBar.Value = 0 Then
        Else
            BrightnessBar.Value = BrightnessBar.Value - 10
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles HigherVol.Click
        If VolumeBar.Value = 100 Then
        Else
            VolumeBar.Value = VolumeBar.Value + 10
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles LowerVol.Click
        If VolumeBar.Value = 0 Then
        Else
            VolumeBar.Value = VolumeBar.Value - 10
        End If

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles SettingAppIcon.Click
        clear()
        DisableSwipe()
        Me.SettingPanel.Visible = True
    End Sub

    Private Sub SosButton_Click(sender As Object, e As EventArgs) Handles SosButton.Click
        Phone.LocateSosPanel.Visible = True
        Phone.Label16.Text = "SOS FROM CHILD"
        Phone.LocateSosPanel.BringToFront()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles GPSAppIcon.Click
        clear()
        DisableSwipe()
        Me.GpsPic1.Visible = True
        Me.GpsAppPanel.Visible = True
    End Sub


    Private Sub EndAlertButton_Click(sender As Object, e As EventArgs) Handles EndAlertButton.Click
        ReminderAppPanel.Visible = False
    End Sub


    Private Sub SendLoc_Click(sender As Object, e As EventArgs)
        GpsPic1.Visible = False
        GpsPic2.Visible = True
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles ScheduleAppIcon.Click
        clear()
        DisableSwipe()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dddd, MMMM dd"
        DateTimePicker1.Value = Today
        ScheduleAppPanel.Visible = True

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
            If Phone.SentSoccer Then
                SoccerPanel.Visible = True
            End If
            If Phone.SentStudy Then
                StudyPanel.Visible = True
            End If

        Else
            SoccerPanel.Visible = False
            StudyPanel.Visible = False
        End If

    End Sub

    Private Sub SheduleBack_Click(sender As Object, e As EventArgs) Handles SoccerBack.Click, StudyBack.Click
        clear()
        ScheduleAppPanel.Visible = True
    End Sub

    Private Sub DisableSwipe()
        LeftButton.Visible = False
        RightButton.Visible = False
    End Sub

End Class
