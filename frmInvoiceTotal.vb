Public Class frmInvoiceTotal

    Dim arrayInvoiceTotals(4) As Decimal
    Dim index As Integer
    Dim listInvoiceTotals As New List(Of Decimal)

    Private Sub btnCalculate_Click(sender As Object,
            e As EventArgs) Handles btnCalculate.Click
        Dim subtotal As Decimal = CDec(txtSubtotal.Text)
        Dim discountPercent As Decimal

        If txtCustomerType.Text = "R" Then
            If subtotal < 100 Then
                discountPercent = 0
            ElseIf subtotal >= 100 AndAlso subtotal < 250 Then
                discountPercent = 0.1D
            ElseIf subtotal >= 250 Then
                discountPercent = 0.25D
            End If
        ElseIf txtCustomerType.Text = "C" Then
            If subtotal < 250 Then
                discountPercent = 0.2D
            Else
                discountPercent = 0.3D
            End If
        Else
            discountPercent = 0.4D
        End If

        Dim discountAmount As Decimal = subtotal * discountPercent
        Dim invoiceTotal As Decimal = subtotal - discountAmount

        txtDiscountPercent.Text = FormatPercent(discountPercent, 1)
        txtDiscountAmount.Text = FormatCurrency(discountAmount)
        txtTotal.Text = FormatCurrency(invoiceTotal)

        If sender Is btnCalculate() Then
            arrayInvoiceTotals(index) = invoiceTotal
            listInvoiceTotals.Add(invoiceTotal)
            index += 1
        End If

        txtCustomerType.Select()
    End Sub

    Private Sub btnExit_Click(sender As Object,
            e As EventArgs) Handles btnExit.Click

        Array.Sort(arrayInvoiceTotals)
        listInvoiceTotals.Sort()

        ' Invoice Totals using an Array
        Dim totalString As String = ""
        For x As Integer = 0 To arrayInvoiceTotals.Length - 1
            If arrayInvoiceTotals(x) <> 0 Then
                totalString &= "$" & arrayInvoiceTotals(x) & vbCrLf
            End If
        Next
        MessageBox.Show(totalString, "Array - Invoice Total")

        ' Invoice Totals using a List
        Dim listTotalString As String = ""
        For Each total As Decimal In listInvoiceTotals
            listTotalString &= "$" & total.ToString & vbCrLf
        Next
        MessageBox.Show(listTotalString, "List - Invoice Total")

        Me.Close()
    End Sub

    Private Sub frmInvoiceTotal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class