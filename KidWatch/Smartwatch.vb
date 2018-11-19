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
            AppPanel3.Visible = False

        ElseIf currentpg = 1 Then
            currentpg = 2
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = True
            AppPanel3.Visible = False

        ElseIf currentpg = 2 Then
            currentpg = 3
            AppPanel3.Visible = True
            AppPanel.Visible = False
            AppPanel2.Visible = False
            HomePagePanel.Visible = False

        ElseIf currentpg = 3 Then
            currentpg = 0
            Me.HomePagePanel.Visible = True
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False
            AppPanel3.Visible = False

        End If
    End Sub

    Private Sub LeftButton_Click(sender As Object, e As EventArgs) Handles LeftButton.Click
        If currentpg = 0 Then
            currentpg = 3
            AppPanel3.Visible = True
            Me.HomePagePanel.Visible = False
            Me.AppPanel.Visible = False
            Me.AppPanel2.Visible = False

        ElseIf currentpg = 3 Then
            currentpg = 2
            AppPanel3.Visible = False
            AppPanel.Visible = False
            AppPanel2.Visible = True
            HomePagePanel.Visible = False

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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Difference As TimeSpan = DateTime.Now.Subtract(Time)
        CallTimeLabel.Text = Difference.Days.ToString & ":" & Difference.Hours.ToString & ":" & Difference.Minutes.ToString & ":" & Difference.Seconds.ToString & "." & Difference.Milliseconds.ToString
    End Sub


    Private Sub PlaceCall(sender As Object, e As EventArgs) Handles CallButton.Click
        CallButton.Visible = False
        EndCallButton.Visible = True
        CallHomeButton.Visible = False
        PhoneAppPanel.BackColor = Color.Orange
        CallTimeLabel.Text = ". . . ."
        CallTimeLabel.Visible = True

        Phone.IncomingCall()
    End Sub

    Public Sub CallAccepted()
        CallTimeLabel.Visible = True
        LowerVolume.Visible = True
        IncreaseVolume.Visible = True
        VolumeBar2.Visible = True
        Time = DateTime.Now
        Timer2.Start()
        PhoneAppPanel.BackColor = Color.Green
    End Sub

    Public Sub CallDeclined()
        PhoneAppPanel.BackColor = Color.Maroon
        EndCallButton.Visible = False
        CallButton.Visible = False
        CallHomeButton.Visible = True
        CallTimeLabel.Text = "Declined"
    End Sub

    Public Sub CallEnded()
        EndCallButton.Visible = False
        CallButton.Visible = False
        CallHomeButton.Visible = True
        PhoneAppPanel.BackColor = Color.Red
        CallEndLabel.Visible = True
        Timer2.Stop()
    End Sub

    Private Sub EndCall(sender As Object, e As EventArgs) Handles EndCallButton.Click
        EndCallButton.Visible = False
        CallButton.Visible = False
        CallHomeButton.Visible = True
        PhoneAppPanel.BackColor = Color.Red
        CallEndLabel.Visible = True
        Timer2.Stop()
        Phone.CallEnded()
    End Sub

    Public Sub IncomingCall()
        IncomingCallPanel.Visible = True
        IncomingCallPanel.BringToFront()
        DisableSwipe()
    End Sub

    Private Sub AcceptCall_Click(sender As Object, e As EventArgs) Handles AcceptCall.Click
        Phone.CallAccepted()
        clear()

        CallButton.Visible = False
        EndCallButton.Visible = True
        CallHomeButton.Visible = False
        PhoneAppPanel.Visible = True
        Me.CallAccepted()
        DisableSwipe()

    End Sub

    Private Sub DeclineCall_Click(sender As Object, e As EventArgs) Handles DeclineCall.Click
        Phone.CallDeclined()
        IncomingCallPanel.Visible = False
        LeftButton.Visible = True
        RightButton.Visible = True
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
        ContactsPanel.Visible = True
    End Sub

    Public Sub clear()
        HomePagePanel.Visible = False
        AppPanel.Visible = False
        PhoneAppPanel.Visible = False
        AllowanceAppPanel.Visible = False
        AppPanel2.Visible = False
        SettingPanel.Visible = False
        GpsAppPanel.Visible = False
        ScheduleAppPanel.Visible = False
        SoccerDetails.Visible = False
        StudyDetails.Visible = False
        IncomingCallPanel.Visible = False
        ContactsPanel.Visible = False
        AppPanel3.Visible = False
        MessageAppPanel.Visible = False
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

    Private Sub MomPic3_Click(sender As Object, e As EventArgs) Handles MomPic3.Click, MomLabel2.Click
        clear()
        PhoneAppPanel.Visible = True
    End Sub

    Private Sub LowerVolume_Click(sender As Object, e As EventArgs) Handles LowerVolume.Click
        If VolumeBar2.Value = 0 Then
        Else
            VolumeBar2.Value = VolumeBar2.Value - 10
        End If
    End Sub

    Private Sub IncreaseVolume_Click(sender As Object, e As EventArgs) Handles IncreaseVolume.Click
        If VolumeBar2.Value = 100 Then
        Else
            VolumeBar2.Value = VolumeBar2.Value + 10
        End If
    End Sub

    Private Sub MessageAppIcon_Click(sender As Object, e As EventArgs) Handles MessageAppIcon.Click
        clear()
        MessageAppPanel.Visible = True
    End Sub

End Class
