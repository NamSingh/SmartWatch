Public Class Phone

    Public SentSoccer As Boolean = False
    Public SentStudy As Boolean = False

    Public Sub clearphone()
        ReminderPanel.Visible = False
        HomePage.Visible = False
        LocateSosPanel.Visible = False
        FundsPanel.Visible = False
        DailySchedPanel.Visible = False
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
End Class