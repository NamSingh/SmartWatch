Public Class Phone

    Public SentSoccer As Boolean = False
    Public SentStudy As Boolean = False
    Dim Time As New DateTime

    Public Sub clearphone()
        ReminderPanel.Visible = False
        HomePage.Visible = False
        LocateSosPanel.Visible = False
        FundsPanel.Visible = False
        DailySchedPanel.Visible = False
        UpcomingFeaturesPanel.Visible = False
        IncomingCallPanel.Visible = False
        CallChildPanel.Visible = False
        ContactsPanel.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles AddSoccerPractice.Click
        SentSoccer = True
        Smartwatch.SoccerPanel.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles AddStudyTime.Click
        SentStudy = True
        Smartwatch.StudyPanel.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles AddFundButton.Click

        Smartwatch.balance = (Convert.ToDouble(AddFundsBox.Text) + Smartwatch.balance)

        Smartwatch.AllowanceLabel2.Text = "$" + Smartwatch.balance.ToString

        Label22.Text = Smartwatch.AllowanceLabel2.Text
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles SendReminderBut.Click
        clearphone()
        ReminderPanel.Visible = True
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles FindChildButton.Click
        clearphone()
        LocateSosPanel.Visible = True
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles SendMoneyButton.Click
        clearphone()
        Label22.Text = Smartwatch.AllowanceLabel2.Text
        FundsPanel.Visible = True
        FundsPanel.BringToFront()

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles EditScheduleButton.Click
        clearphone()
        DailySchedPanel.Visible = True
    End Sub

    Private Sub SendLoc_Click(sender As Object, e As EventArgs) Handles SendLocButton.Click
        Smartwatch.GpsPic1.Visible = False
        Smartwatch.GpsPic2.Visible = True
    End Sub

    Private Sub LocateChildPicBox_Click(sender As Object, e As EventArgs) Handles LocateChildPicBox.Click
        LocateChildPicBox.Visible = False
        LocateChildPic.Visible = True
        Label19.Text = "Send Child to: Esso Gas Station"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles SendReminderButton.Click
        Smartwatch.ReminderAppPanel.Visible = True
        Smartwatch.ReminderAppPanel.BringToFront()
        If ReminderText.Text.Equals("") Then
        Else
            Smartwatch.ReminderText.Text = ReminderText.Text
        End If
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        clearphone()
        HomePage.Visible = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles CallChildLabel.Click

    End Sub

    Private Sub UpcomingFeaturesButton_Click(sender As Object, e As EventArgs) Handles UpcomingFeaturesButton.Click
        clearphone()
        UpcomingFeaturesPanel.Visible = True
    End Sub

    Private Sub CallChildButton_Click(sender As Object, e As EventArgs) Handles MakeCall.Click
        clearphone()
        ContactsPanel.Visible = True
    End Sub

    Private Sub ChildPic3_Click(sender As Object, e As EventArgs) Handles ChildPic3.Click, ChildLabel2.Click
        clearphone()
        CallChildPanel.Visible = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Difference As TimeSpan = DateTime.Now.Subtract(Time)
        CallTimeLabel.Text = Difference.Days.ToString & ":" & Difference.Hours.ToString & ":" & Difference.Minutes.ToString & ":" & Difference.Seconds.ToString & "." & Difference.Milliseconds.ToString
    End Sub

    Private Sub PlaceCall(sender As Object, e As EventArgs) Handles CallPic.Click
        CallPic.Visible = False
        EndCallPic.Visible = True
        BackButton.Visible = False
        CallTimeLabel.Visible = True
        CallTimeLabel.Text = ". . . ."
        CallChildPanel.BackColor = Color.Orange

        Smartwatch.IncomingCall()
    End Sub

    Public Sub CallAccepted()
        CallChildPanel.BackColor = Color.Green
        CallTimeLabel.Visible = True
        Time = DateTime.Now
        Timer1.Start()
    End Sub

    Public Sub CallDeclined()
        CallChildPanel.BackColor = Color.Maroon
        EndCallPic.Visible = False
        CallPic.Visible = False
        BackButton.Visible = True
        CallTimeLabel.Text = "Declined"
    End Sub

    Public Sub CallEnded()
        EndCallPic.Visible = False
        CallPic.Visible = False
        BackButton.Visible = True
        CallChildPanel.BackColor = Color.Red
        CallEndLabel.Visible = True
        Timer1.Stop()
    End Sub

    Private Sub EndCall(sender As Object, e As EventArgs) Handles EndCallPic.Click
        EndCallPic.Visible = False
        CallPic.Visible = False
        BackButton.Visible = True
        CallChildPanel.BackColor = Color.Red
        CallEndLabel.Visible = True
        Timer1.Stop()
        Smartwatch.CallEnded()
    End Sub

    Public Sub IncomingCall()
        IncomingCallPanel.Visible = True
        IncomingCallPanel.BringToFront()
        BackButton.Visible = False
    End Sub

    Private Sub AcceptCallPic_Click(sender As Object, e As EventArgs) Handles AcceptCallPic.Click
        clearphone()
        Smartwatch.CallAccepted()

        CallPic.Visible = False
        EndCallPic.Visible = True
        BackButton.Visible = False
        CallChildPanel.Visible = True
        Me.CallAccepted()
    End Sub

    Private Sub DeclineCallPic_Click(sender As Object, e As EventArgs) Handles DeclineCallPic.Click
        Smartwatch.CallDeclined()
        BackButton.Visible = True
        IncomingCallPanel.Visible = False
    End Sub
End Class