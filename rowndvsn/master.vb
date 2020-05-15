Imports MySql.Data.MySqlClient
Public Class master
    'SIMPAN JENIS
    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Call bukaDB()
        CMD = New MySqlCommand("SELECT  nama_jenis from tbl_jenis where nama_jenis='" & TextBox1.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf TextBox1.Text = "" Then
            MsgBox("DLENGKAPI DATA ANDA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Call bukaDB()
            Try
                simpan = "INSERT INTO tbl_jenis(id_jenis,nama_jenis)VALUES('','" & TextBox1.Text & "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("DATA JENIS BARU BERHASIL DISIMPAN", MsgBoxStyle.Information, "INFORMASI")
                TextBox1.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "KONEKSI KE DATABASE BERMASALAH")
            End Try
        End If
    End Sub
    'SIMPAN TIPE
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bukaDB()
        CMD = New MySqlCommand("SELECT tipe from tbl_tipe where tipe='" & TextBox2.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf TextBox2.Text = "" Then
            MsgBox("DLENGKAPI DATA ANDA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Call bukaDB()
            Try
                simpan = "INSERT INTO tbl_tipe(id_tipe,tipe)VALUES('','" & TextBox2.Text & "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("DATA TIPE BARU BERHASIL DISIMPAN", MsgBoxStyle.Information, "INFORMASI")
                TextBox2.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "KONEKSI KE DATABASE BERMASALAH")
            End Try
        End If
    End Sub
    'SIMPAN WARNA
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call bukaDB()
        CMD = New MySqlCommand("SELECT warna from tbl_warna where warna='" & TextBox3.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf TextBox3.Text = "" Then
            MsgBox("LENGKAPI DATA ANDA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Call bukaDB()
            Try
                simpan = "INSERT INTO tbl_warna(id_warna,warna)VALUES('','" & TextBox3.Text & "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("DATA WARNA BARU BERHASIL DISIMPAN", MsgBoxStyle.Information, "INFORMASI")
                TextBox3.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "KONEKSI KE DATABASE BERMASALAH")
            End Try
        End If
    End Sub
End Class