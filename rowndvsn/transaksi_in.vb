Imports MySql.Data.MySqlClient
Public Class transaksi_in
    'CLEAR
    Sub bersih()
        TextBox2.Text = ""
        TextBox3.Text = ""
        DataGridView1.Rows.Clear()
    End Sub

    'HITUNG item
    Sub hitungitem()
        Dim golek As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            golek = golek + DataGridView1.Rows(i).Cells(3).Value
            TextBox2.Text = golek
        Next
    End Sub

    'HITUNG tottal
    Sub hitungtotal()
        Dim cari As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cari = cari + DataGridView1.Rows(i).Cells(7).Value
            TextBox3.Text = cari
        Next
    End Sub

    'NOMOR FAKTUR
    Sub nofak()
        Try
            Call bukaDB()
            CMD = New MySqlCommand("select * from tbl_in order by nofak_in DESC",
            Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                TextBox1.Text = "BK" + "0001"
            Else
                TextBox1.Text = Val(Microsoft.VisualBasic.Mid(RD.Item("nofak_in").ToString, 4, 3)) + 1
                If Len(TextBox1.Text) = 1 Then
                    TextBox1.Text = "BK000" & TextBox1.Text & ""
                ElseIf Len(TextBox1.Text) = 2 Then
                    TextBox1.Text = "BK00" & TextBox1.Text & ""
                ElseIf Len(TextBox1.Text) = 3 Then
                    TextBox1.Text = "BK0" & TextBox1.Text & ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi Kesalahan : " & ex.Message, "Pesan Peringatan",
            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'DATAGRIDVIEW SETTING
    Private Sub DataGridView1_CellEndEdit1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 0 Then
            DataGridView1.Rows(e.RowIndex).Cells(0).Value = UCase(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            Call bukaDB()
            CMD = New MySqlCommand("SELECT * FROM tbl_barang where id_barang = '" & DataGridView1.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            RD = CMD.ExecuteReader
            If RD.Read Then
                DataGridView1.Rows(e.RowIndex).Cells(1).Value = RD.Item("nama_barang")
                DataGridView1.Rows(e.RowIndex).Cells(2).Value = 0
                DataGridView1.Rows(e.RowIndex).Cells(3).Value = 0
                DataGridView1.Rows(e.RowIndex).Cells(4).Value = RD.Item("harga_barang")
                DataGridView1.Rows(e.RowIndex).Cells(5).Value = RD.Item("stok")
                DataGridView1.Rows(e.RowIndex).Cells(6).Value = 0
                DataGridView1.Rows(e.RowIndex).Cells(7).Value = 0
            Else
                MsgBox("MAAF,DATA YANG ANDA MAKSUD TIDAK BISA KAMI TEMUKAN", MsgBoxStyle.Exclamation, "PERINATAN")
                DataGridView1.Focus()
            End If
        End If
        If e.ColumnIndex = 3 Then
            DataGridView1.Rows(e.RowIndex).Cells(6).Value = DataGridView1.Rows(e.RowIndex).Cells(5).Value + DataGridView1.Rows(e.RowIndex).Cells(3).Value
            DataGridView1.Rows(e.RowIndex).Cells(7).Value = DataGridView1.Rows(e.RowIndex).Cells(4).Value * DataGridView1.Rows(e.RowIndex).Cells(3).Value
        End If
        Call hitungitem()
        Call hitungtotal()
    End Sub
    Private Sub transaksi_in_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call nofak()
        TextBox4.Text = Format(Now, "yyyy-MM-dd")
    End Sub

    'SIMPAN
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Call bukaDB()
            CMD = New MySqlCommand("SELECT nofak_in from tbl_in where nofak_in='" & TextBox1.Text & "'", Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
            ElseIf TextBox1.Text = "" Then
                MsgBox("Nomor Faktur Belum di isi !! ", MsgBoxStyle.Exclamation,
                "Peringatan")
            Else
                Dim simpan1 As String
                Call bukaDB()
                simpan = "INSERT INTO tbl_in (nofak_in,tgl_in,tottal_item,tottal_bayar) VALUES (@p1,@p2,@p3,@p4)"
                simpan1 = "INSERT INTO tbldetilin (nofak_in,id_barang,ukuran,jumlah) VALUES (@p5,@p6,@p7,@p8) "
                ubah = "UPDATE tbl_barang SET stok=stok+@p9 WHERE id_barang = @p10"
                CMD = Conn.CreateCommand
                With CMD
                    .CommandText = simpan
                    .Connection = Conn
                    .Parameters.Add("p1", MySqlDbType.String, 30).Value = TextBox1.Text
                    .Parameters.Add("p2", MySqlDbType.DateTime).Value = Format(Now.Date,
                    "yyyy-MM-dd HH:mm:ss")
                    .Parameters.Add("p3", MySqlDbType.Int32).Value = TextBox2.Text
                    .Parameters.Add("p4", MySqlDbType.Int32).Value = TextBox3.Text
                    .ExecuteNonQuery()
                End With
                For i As Integer = 0 To DataGridView1.Rows.Count - 2
                    CMD = Conn.CreateCommand
                    With CMD
                        .CommandText = simpan
                        .CommandText = simpan1
                        .Connection = Conn
                        .Parameters.Add("p5", MySqlDbType.String, 30).Value = TextBox1.Text
                        .Parameters.Add("p6", MySqlDbType.String, 30).Value =
                        DataGridView1.Rows(i).Cells(0).Value
                        .Parameters.Add("p7", MySqlDbType.String, 30).Value =
                        DataGridView1.Rows(i).Cells(2).Value
                        .Parameters.Add("p8", MySqlDbType.Int32).Value =
                        DataGridView1.Rows(i).Cells(3).Value
                        .ExecuteNonQuery()
                    End With
                    CMD = Conn.CreateCommand
                    With CMD
                        .CommandText = ubah
                        .Connection = Conn
                        .Parameters.Add("p9", MySqlDbType.UInt32).Value =
                        DataGridView1.Rows(i).Cells(3).Value
                        .Parameters.Add("p10", MySqlDbType.String).Value =
                        DataGridView1.Rows(i).Cells(0).Value
                        .ExecuteNonQuery()
                        Call nofak()
                    End With
                Next
                MsgBox("DATA ANDA BERHASIL KAMI SIMPAN", MsgBoxStyle.Information, "informasi!!!")
            End If
            Conn.Close()
            CMD.Dispose()
            bersih()

        Catch ex As Exception
            MsgBox("TERJADI KESALAHAN SAAT MENGINPUTKAN ATAU MEMBACA DATA", MsgBoxStyle.Exclamation, "PERINGATAN")
        End Try
    End Sub

    'BERSIH
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call bersih()
    End Sub
End Class