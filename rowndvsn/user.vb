Imports MySql.Data.MySqlClient
Public Class user
    'ACTIVATE FORM
    Sub aktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
    End Sub
    'CLEAR
    Sub clear()
        TextBox1.Focus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    'LIHAT DATA
    Sub tampil_admin()
        koneksi.bukaDB()
        DA = New MySqlDataAdapter("SELECT * FROM tbl_user", Conn)
        DS = New DataSet
        DA.Fill(DS, "tbl_user")
        DataGridView1.DataSource = DS.Tables("tbl_user")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "ID USER"
            .Columns(1).HeaderText = "NAMA USER"
            .Columns(2).HeaderText = "USERNAME"
            .Columns(3).HeaderText = "PASSWORD"
            .Columns(0).Width = 150
            .Columns(1).Width = 250
            .Columns(2).Width = 200
            .Columns(3).Width = 200
        End With
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow
    End Sub
    'PINADAH DATA DARI DATAGRID KE TEXTBOX
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value
    End Sub
    'LOAD
    Private Sub user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call clear()
        Call tampil_admin()
    End Sub
    'TAMBAH
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call aktif()
        Call clear()
    End Sub
    'SIMPAN BARANG
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call bukaDB()
        CMD = New MySqlCommand("SELECT  id_user from tbl_user where id_user='" & TextBox1.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf TextBox1.Text = "" Then
            MsgBox("LENGKAPI DATA ANDA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Call bukaDB()
            Try
                simpan = "INSERT INTO tbl_user(id_user,nama_user,username,password)VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                Call tampil_admin()
                Call clear()
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "KONEKSI KE DATABASE BERMASALAH")
            End Try
        End If
    End Sub
    'UBAH
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA DARI DATABASE UNTUK EDIT", MsgBoxStyle.Information, "PERHATIAN !!!")
        Else
            Call bukaDB()
            Try
                ubah = "update tbl_user set nama_user='" & TextBox2.Text & "',username='" & TextBox3.Text & "',password='" & TextBox4.Text & "' where id_user='" & TextBox1.Text & "'"
                CMD = New MySqlCommand(ubah, Conn)
                CMD.ExecuteNonQuery()
                Call clear()
                Call tampil_admin()
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub
    'HAPUS
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("PILIH DAHULU DATA YANG AKAN DIHAPUS", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Try
                Call bukaDB()
                hapus = "DELETE FROM tbl_user WHERE id_user='" & TextBox1.Text & "'"
                CMD = New MySqlCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                Call clear()
                Call tampil_admin()
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "TERJADI KESALAHAN")
            End Try
        End If
    End Sub
End Class