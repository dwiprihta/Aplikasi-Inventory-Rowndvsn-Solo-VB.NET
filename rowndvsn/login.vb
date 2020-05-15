Imports MySql.Data.MySqlClient
Public Class login

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("LENGKAPI DAHULU USERNAME ATAU PASSWORD ANDA", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        Else
            Call bukaDB()
            CMD = New MySqlCommand("select * from tbl_user where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                INDEX.Show()
            Else
                MsgBox("USERNAME/PASSWORD ANDA SALAH", MsgBoxStyle.Exclamation, "Silahkan Cek Kembali Username Atau Passwor anda")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class