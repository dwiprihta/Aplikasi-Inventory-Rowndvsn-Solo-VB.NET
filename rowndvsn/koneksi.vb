Imports MySql.Data.MySqlClient
Module koneksi
    Public Conn As MySqlConnection
    Public RD As MySqlDataReader
    Public DA As MySqlDataAdapter
    Public CMD As MySqlCommand
    Public DS As DataSet
    Public simpan, ubah, hapus As String
    Public Sub bukaDB()
        Dim SQLConn As String
        Try
            SQLConn = "server=localhost;Uid=root;Pwd=;Database=rowndvsn"
            Conn = New MySqlConnection(SQLConn)
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
        Catch ex As Exception
            MsgBox("KONEKSI ANDA KE DATABASE GAGAL SILAHKAN CEK KEMBALI KONEKSI ANDA")
        End Try
    End Sub
End Module
