Imports MySql.Data.MySqlClient
Public Class data_barang
    'ACTIVATE FORM
    Sub aktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
    End Sub
    'CLEAR
    Sub clear()
        TextBox1.Focus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        'TextBox6.Text = ""
        ComboBox4.Text = ""
    End Sub
    'LOAD
    Private Sub data_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call clear()
        Call tampil_barang()
        Call opencombo1()
        Call opencombo2()
        Call opencombo3()
        Call combos()
    End Sub
    'ACTIVE FROM
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call aktif()
        Call clear()
    End Sub
    'LIHAT DATA
    Sub tampil_barang()
        koneksi.bukaDB()
        DA = New MySqlDataAdapter("SELECT * FROM v_barang", Conn)
        DS = New DataSet
        DA.Fill(DS, "v_barang")
        DataGridView1.DataSource = DS.Tables("v_barang")
        DataGridView1.ReadOnly = True
        With DataGridView1
            .Columns(0).HeaderText = "KODE BARANG"
            .Columns(1).HeaderText = "NAMA BARANG"
            .Columns(2).HeaderText = "JENIS BARANG"
            .Columns(3).HeaderText = "TIPE BARANG"
            .Columns(4).HeaderText = "SEX"
            .Columns(5).HeaderText = "WARNA"
            .Columns(6).HeaderText = "UKURAN"
            ' .Columns(6).HeaderText = "UKURAN"
            ' .Columns(6).HeaderText = "UKURAN"
            ' .Columns(6).HeaderText = "UKURAN"
            .Columns(7).HeaderText = "STOK"
            .Columns(8).HeaderText = "HARGA BARANG"
            .Columns(9).HeaderText = "TANGGAL INPUT"
            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 200
            .Columns(3).Width = 100
        End With
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow
    End Sub

    'PINADAH DATA DARI DATAGRID KE TEXTBOX
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value
        ComboBox2.Text = DataGridView1.CurrentRow.Cells(3).Value
        TextBox6.Text = DataGridView1.CurrentRow.Cells(4).Value
        ComboBox4.Text = DataGridView1.CurrentRow.Cells(5).Value
        ComboBox3.Text = DataGridView1.CurrentRow.Cells(6).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(7).Value
        TextBox5.Text = DataGridView1.CurrentRow.Cells(8).Value
        DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(9).Value
        TextBox1.Enabled = False
        TextBox2.Enabled = True

        TextBox4.Enabled = True
        TextBox2.Focus()
    End Sub

    'COMBOBOX
    Sub opencombo1()
        Call bukadb()
        DA = New MySqlDataAdapter("select id_jenis,nama_jenis from tbl_jenis", Conn)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.ValueMember = "id_jenis"
            ComboBox1.DisplayMember = "nama_jenis"
        Catch ex As Exception
            MsgBox("DATA KATEGORI ANDA GAGAL KAMI TAMPIL", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        End Try
    End Sub

    Sub opencombo2()
        Call bukaDB()
        DA = New MySqlDataAdapter("select id_tipe,tipe from tbl_tipe", Conn)
        Dim dt As New DataTable
        Try
            DA.Fill(dt)
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "id_tipe"
            ComboBox2.DisplayMember = "tipe"
        Catch ex As Exception
            MsgBox("DATA KATEGORI ANDA GAGAL KAMI TAMPIL", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        End Try
    End Sub

    Sub opencombo3()
        Call bukaDB()
        DA = New MySqlDataAdapter("select id_warna,warna from tbl_warna", Conn)
        Dim dt As New DataTable
        Try
            DA.Fill(dt)
            ComboBox4.DataSource = dt
            ComboBox4.ValueMember = "id_warna"
            ComboBox4.DisplayMember = "warna"
        Catch ex As Exception
            MsgBox("DATA KATEGORI ANDA GAGAL KAMI TAMPIL", MsgBoxStyle.Exclamation, "PERINGATAN!!!")
        End Try
    End Sub

    Sub combos()
        ComboBox3.Items.Add("S")
        ComboBox3.Items.Add("M")
        ComboBox3.Items.Add("L")
        ComboBox3.Items.Add("XL")
        ComboBox3.Items.Add("XXL")
        ComboBox3.Items.Add("UNISEX")
    End Sub


    'SIMPAN BARANG
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call bukaDB()
        CMD = New MySqlCommand("SELECT  id_barang from tbl_barang where id_barang='" & TextBox1.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            MsgBox("DATA YANG ANDA MASUKAN MUNGKIN SUDAH ADA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        ElseIf TextBox1.Text = "" Then
            MsgBox("DLENGKAPI DATA ANDA !!!", MsgBoxStyle.Exclamation, "PERINGATAN")
        Else
            Call bukaDB()
            Try
                simpan = "INSERT INTO tbl_barang(id_barang,nama_barang,id_jenis,id_tipe,sex,id_warna,ukuran,stok,harga_barang,tgl_input)VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & TextBox6.Text & "','" & ComboBox4.SelectedValue & "','" & ComboBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
                CMD = New MySqlCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("DATA ANDA BERHASIL KAMI SIMPAN!", MsgBoxStyle.Information, "INPUT DATA SUKSES")
                Call tampil_barang()
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
                If MsgBox("APAKAH ANDA YAKIN MENGUBAH DATA INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
                    ubah = "update tbl_barang set nama_barang='" & TextBox2.Text & "',id_jenis='" & ComboBox1.SelectedValue & "',id_tipe='" & ComboBox2.SelectedValue & "',sex='" & TextBox6.Text & "',id_warna='" & ComboBox4.SelectedValue & "', ukuran='" & ComboBox3.Text & "',stok='" & TextBox4.Text & "',harga_barang='" & TextBox5.Text & "' where id_barang='" & TextBox1.Text & "'"
                    CMD = New MySqlCommand(ubah, Conn)
                    CMD.ExecuteNonQuery()
                    Call clear()
                    Call tampil_barang()
                End If
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
                If MsgBox("APAKAH ANDA YAKIN MENGHAPUS DATA INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
                    Call bukaDB()
                    hapus = "DELETE FROM tbl_barang WHERE id_barang='" & TextBox1.Text & "'"
                    CMD = New MySqlCommand(hapus, Conn)
                    CMD.ExecuteNonQuery()
                    Call clear()
                    Call tampil_barang()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "TERJADI KESALAHAN")
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        DA = New MySqlDataAdapter("select * from v_barang where id_barang like '%" & TextBox3.Text & "%' OR nama_barang like '%" & TextBox3.Text & "%'", Conn)
        DS = New DataSet
        DA.Fill(DS, "KETEMU")
        DataGridView1.DataSource = DS.Tables("KETEMU")
        DataGridView1.ReadOnly = True
    End Sub
End Class