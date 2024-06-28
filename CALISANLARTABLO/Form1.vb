Imports System.Data.OleDb
Public Class Form1
    Dim baglan As New OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=bilgiler1.mdb")
    Dim sql = "select * from tablo1"
    Sub göster()
        Dim tablo As New DataTable()
        Dim adaptor As New OleDbDataAdapter(sql, baglan)
        adaptor.Fill(tablo)
        DataGridView1.DataSource = tablo
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       


        'burada for each döngüsü ile satırları renklendiriyoruz
        göster()
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = If(row.Index Mod 2 = 0, Color.LightBlue, Color.LightGreen)

        Next

    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
            Dim ad = DataGridView1.Rows(e.RowIndex).Cells("ADI").Value.ToString()
            Dim soyad = DataGridView1.Rows(e.RowIndex).Cells("SOYADI").Value.ToString()
            DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = ad + "   " + soyad
        End If

        'burada ise tooltiptext kullanarak ilgili kaydın üzerine mause getirildiğinde o kayda ait isim ve soy isimin gösterilmesini sağlıyoruz
    End Sub
    Public ad, soyad
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ad = DataGridView1.CurrentRow.Cells("ADI").Value.ToString()
        soyad = DataGridView1.CurrentRow.Cells("SOYADI").Value.ToString()

        Dim FRM2 As New Form2
        FRM2.ShowDialog()
        'burada ilgili kaydın üzerine çift tıklanıldığında kişinin adı ve soyadını form ikide göstermesini sağlıyoruz
    End Sub
End Class
