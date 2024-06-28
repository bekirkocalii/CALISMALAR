Imports System.Data.OleDb
Public Class Form1
    Dim baglan As New OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=bilgiler1.mdb")
    Dim sql = "select * from notlar"

    Sub göster()
        Dim tablo As New DataTable()
        Dim adaptor As New OleDbDataAdapter(sql, baglan)
        adaptor.Fill(tablo)
        DataGridView1.DataSource = tablo
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        göster()
    End Sub
    Dim vize, final, ortalama, harf, durum

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        vize = TextBox3.Text
        final = TextBox4.Text
        ortalama = (vize * 0.4) + (final * 0.6)

        If ortalama > 60 Then
            durum = "GEÇTİ"
        Else
            durum = "KALDI"
        End If

        If ortalama < 60 Then
            harf = "FF"
        ElseIf ortalama > 60 And ortalama < 80 Then
            harf = "BB"
        ElseIf ortalama > 80 And ortalama <= 100 Then
            harf = "AA"
        End If

        Dim ekle As New OleDbCommand("insert into notlar (AD,SOYAD,DERS,VIZE,FINAL,ORTALAMA,HARF_NOTU,DURUM) VALUES(@ad,@soyad,@ders,@vize,@final,@ort,@harf,@durum) ", baglan)
        ekle.Parameters.AddWithValue("@ad", TextBox1.Text)
        ekle.Parameters.AddWithValue("@soyad", TextBox2.Text)
        ekle.Parameters.AddWithValue("@ders", ComboBox1.Text)
        ekle.Parameters.AddWithValue("@vize", vize)
        ekle.Parameters.AddWithValue("@final", final)
        ekle.Parameters.AddWithValue("@ort", ortalama)
        ekle.Parameters.AddWithValue("@harf", harf)
        ekle.Parameters.AddWithValue("@durum", durum)
        baglan.Open()
        ekle.ExecuteNonQuery()
        baglan.Close()
        göster()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim sil As New OleDbCommand("delete from notlar where AD=@ad and SOYAD=@soyad", baglan)
        sil.Parameters.AddWithValue("@ad", TextBox5.Text)
        sil.Parameters.AddWithValue("@soyad", TextBox6.Text)
        baglan.Open()
        sil.ExecuteNonQuery()
        baglan.Close()
        göster()
    End Sub
    Dim kimlik
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub
End Class
