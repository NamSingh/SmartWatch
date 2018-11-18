Public Class Phone
    Private Sub DailySchedPanel_Paint(sender As Object, e As PaintEventArgs) Handles DailySchedPanel.Paint

    End Sub

    Public Sub clearphone()
        ReminderPanel.Visible = False
        SamsungMain.Visible = False
        LocateSosPanel.Visible = False
        FundsPanel.Visible = False
        DailySchedPanel.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form1.SoccerPanel.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form1.StudyPanel.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Label4.Text = "$" + (Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(Label4.Text)).ToString
        'Label22.Text = Label4.Text

        Form1.balance = (Convert.ToDouble(TextBox2.Text) + Form1.balance)

        Form1.AllowanceLabel2.Text = "$" + Form1.balance.ToString

        Label22.Text = Form1.AllowanceLabel2.Text
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        clearphone()
        ReminderPanel.Visible = True
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        LocateSosPanel.Visible = True
        LocateSosPanel.BringToFront()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Label22.Text = Form1.AllowanceLabel2.Text
        FundsPanel.Visible = True
        FundsPanel.BringToFront()

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        clearphone()
        DailySchedPanel.Visible = True
    End Sub

    Private Sub SendLoc_Click(sender As Object, e As EventArgs) Handles SendLoc.Click
        Form1.GpsPic1.Visible = False
        Form1.GpsPic2.Visible = True
    End Sub

    Private Sub LocateChildPicBox_Click(sender As Object, e As EventArgs) Handles LocateChildPicBox.Click
        LocateChildPicBox.Visible = False
        SendLocPic.Visible = True
        Label19.Text = "Send Child to: Esso Gas Station"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.ReminderAppPanel.Visible = True
        Form1.ReminderAppPanel.BringToFront()
        If TextBox1.Text.Equals("") Then
        Else
            Form1.ReminderText.Text = TextBox1.Text
        End If
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        clearphone()
        SamsungMain.Visible = True
    End Sub

End Class