Public Class INDEX

    Private Sub DATABARANGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATABARANGToolStripMenuItem.Click
        data_barang.MdiParent = Me
        data_barang.Show()
    End Sub

    Private Sub DATAWARNAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAWARNAToolStripMenuItem.Click
        master.MdiParent = Me
        master.Show()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        If MsgBox("APAKAH ANDA YAKIN AKAN KELUAR DARI APLIKASI INI", MsgBoxStyle.YesNoCancel, "PERINGATAN") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub USERToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles USERToolStripMenuItem1.Click
        user.MdiParent = Me
        user.Show()
    End Sub

    Private Sub INToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem.Click
        transaksi_in.MdiParent = Me
        transaksi_in.Show()
    End Sub

    Private Sub OUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OUTToolStripMenuItem.Click
        transaksi_out.MdiParent = Me
        transaksi_out.Show()
    End Sub

    Private Sub DATABARANGToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DATABARANGToolStripMenuItem1.Click
        r_barang.Show()
    End Sub

    Private Sub INToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem1.Click
        r_in.Show()
    End Sub

    Private Sub OUTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OUTToolStripMenuItem1.Click
        r_out.Show()
    End Sub

    Private Sub DATABARANGToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DATABARANGToolStripMenuItem2.Click
        data_barang.MdiParent = Me
        data_barang.Show()
    End Sub

    Private Sub MASTERCOMBOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MASTERCOMBOToolStripMenuItem.Click
        master.MdiParent = Me
        master.Show()
    End Sub

    Private Sub INToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles INToolStripMenuItem2.Click
        transaksi_in.MdiParent = Me
        transaksi_in.Show()
    End Sub

    Private Sub OUTToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OUTToolStripMenuItem2.Click
        transaksi_out.MdiParent = Me
        transaksi_out.Show()
    End Sub

    Private Sub DATABARANGToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DATABARANGToolStripMenuItem3.Click
        r_barang.Show()
    End Sub

    Private Sub REPORTINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REPORTINToolStripMenuItem.Click
        r_in.Show()
    End Sub

    Private Sub REPORTOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REPORTOUTToolStripMenuItem.Click
        r_out.Show()
    End Sub
End Class
