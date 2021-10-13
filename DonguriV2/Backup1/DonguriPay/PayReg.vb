Public Class PayReg

    Private Sub PayReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As Date
        If Date.TryParse(Me.Tag, dt) Then
            dtpFromDate.Value = dt
            dtpFromDate.Enabled = False
            Call GetPayTable(dt)
        Else
            dtpFromDate.Value = Now
            dtpFromDate.Enabled = True
            Call IniPayTable()
        End If
    End Sub

    Private Sub IniPayTable()
        txtSa005.Text = 0 : txtSa010.Text = 0 : txtSa015.Text = 0 : txtSa020.Text = 0 : txtSa025.Text = 0 : txtSa030.Text = 0
        txtSa035.Text = 0 : txtSa040.Text = 0 : txtSa045.Text = 0 : txtSa050.Text = 0 : txtSa055.Text = 0 : txtSa060.Text = 0
        txtSa065.Text = 0 : txtSa070.Text = 0 : txtSa075.Text = 0 : txtSa080.Text = 0 : txtSa085.Text = 0 : txtSa090.Text = 0
        txtSa095.Text = 0 : txtSa100.Text = 0
        txtSb005.Text = 0 : txtSb010.Text = 0 : txtSb015.Text = 0 : txtSb020.Text = 0 : txtSb025.Text = 0 : txtSb030.Text = 0
        txtSb035.Text = 0 : txtSb040.Text = 0
        txtSc005.Text = 0 : txtSc010.Text = 0 : txtSc015.Text = 0 : txtSc020.Text = 0 : txtSc025.Text = 0 : txtSc030.Text = 0
        txtSc035.Text = 0 : txtSc040.Text = 0 : txtSc045.Text = 0 : txtSc050.Text = 0 : txtSc055.Text = 0 : txtSc060.Text = 0
        txtSc065.Text = 0 : txtSc070.Text = 0 : txtSc075.Text = 0 : txtSc080.Text = 0
        txtKa005.Text = 0 : txtKa010.Text = 0 : txtKa015.Text = 0 : txtKa020.Text = 0 : txtKa025.Text = 0 : txtKa030.Text = 0
        txtKa035.Text = 0 : txtKa040.Text = 0 : txtKa045.Text = 0 : txtKa050.Text = 0 : txtKa055.Text = 0 : txtKa060.Text = 0
        txtKa065.Text = 0 : txtKa070.Text = 0 : txtKa075.Text = 0 : txtKa080.Text = 0 : txtKa085.Text = 0 : txtKa090.Text = 0
        txtKa095.Text = 0 : txtKa100.Text = 0
        txtKb005.Text = 0 : txtKb010.Text = 0 : txtKb015.Text = 0 : txtKb020.Text = 0 : txtKb025.Text = 0 : txtKb030.Text = 0
        txtKb035.Text = 0 : txtKb040.Text = 0
        txtKc005.Text = 0 : txtKc010.Text = 0 : txtKc015.Text = 0 : txtKc020.Text = 0 : txtKc025.Text = 0 : txtKc030.Text = 0
        txtKc035.Text = 0 : txtKc040.Text = 0 : txtKc045.Text = 0 : txtKc050.Text = 0 : txtKc055.Text = 0 : txtKc060.Text = 0
        txtKc065.Text = 0 : txtKc070.Text = 0 : txtKc075.Text = 0 : txtKc080.Text = 0
        txtIa005.Text = 0 : txtIa010.Text = 0 : txtIa015.Text = 0 : txtIa020.Text = 0 : txtIa025.Text = 0 : txtIa030.Text = 0
        txtIa035.Text = 0 : txtIa040.Text = 0 : txtIa045.Text = 0 : txtIa050.Text = 0 : txtIa055.Text = 0 : txtIa060.Text = 0
        txtIa065.Text = 0 : txtIa070.Text = 0 : txtIa075.Text = 0 : txtIa080.Text = 0 : txtIa085.Text = 0 : txtIa090.Text = 0
        txtIa095.Text = 0 : txtIa100.Text = 0
        txtIb005.Text = 0 : txtIb010.Text = 0 : txtIb015.Text = 0 : txtIb020.Text = 0 : txtIb025.Text = 0 : txtIb030.Text = 0
        txtIb035.Text = 0 : txtIb040.Text = 0
        txtIc005.Text = 0 : txtIc010.Text = 0 : txtIc015.Text = 0 : txtIc020.Text = 0 : txtIc025.Text = 0 : txtIc030.Text = 0
        txtIc035.Text = 0 : txtIc040.Text = 0 : txtIc045.Text = 0 : txtIc050.Text = 0 : txtIc055.Text = 0 : txtIc060.Text = 0
        txtIc065.Text = 0 : txtIc070.Text = 0 : txtIc075.Text = 0 : txtIc080.Text = 0
    End Sub

    Private Sub GetPayTable(ByVal FromDate As Date)
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_PAYTABLE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim db As New DonguriLib.LibClass.T_PayTable
                dr.Read()
                db.SetReader(dr)
                txtSa005.Text = db.ToSa005.ToString("#,##0") : txtSa010.Text = db.ToSa010.ToString("#,##0") : txtSa015.Text = db.ToSa015.ToString("#,##0")
                txtSa020.Text = db.ToSa020.ToString("#,##0") : txtSa025.Text = db.ToSa025.ToString("#,##0") : txtSa030.Text = db.ToSa030.ToString("#,##0")
                txtSa035.Text = db.ToSa035.ToString("#,##0") : txtSa040.Text = db.ToSa040.ToString("#,##0") : txtSa045.Text = db.ToSa045.ToString("#,##0")
                txtSa050.Text = db.ToSa050.ToString("#,##0") : txtSa055.Text = db.ToSa055.ToString("#,##0") : txtSa060.Text = db.ToSa060.ToString("#,##0")
                txtSa065.Text = db.ToSa065.ToString("#,##0") : txtSa070.Text = db.ToSa070.ToString("#,##0") : txtSa075.Text = db.ToSa075.ToString("#,##0")
                txtSa080.Text = db.ToSa080.ToString("#,##0") : txtSa085.Text = db.ToSa085.ToString("#,##0") : txtSa090.Text = db.ToSa090.ToString("#,##0")
                txtSa095.Text = db.ToSa095.ToString("#,##0") : txtSa100.Text = db.ToSa100.ToString("#,##0")
                txtSb005.Text = db.Tosb005.ToString("#,##0") : txtSb010.Text = db.Tosb010.ToString("#,##0") : txtSb015.Text = db.Tosb015.ToString("#,##0")
                txtSb020.Text = db.Tosb020.ToString("#,##0") : txtSb025.Text = db.Tosb025.ToString("#,##0") : txtSb030.Text = db.Tosb030.ToString("#,##0")
                txtSb035.Text = db.Tosb035.ToString("#,##0") : txtSb040.Text = db.Tosb040.ToString("#,##0")
                txtSc005.Text = db.Tosc005.ToString("#,##0") : txtSc010.Text = db.Tosc010.ToString("#,##0") : txtSc015.Text = db.Tosc015.ToString("#,##0")
                txtSc020.Text = db.Tosc020.ToString("#,##0") : txtSc025.Text = db.Tosc025.ToString("#,##0") : txtSc030.Text = db.Tosc030.ToString("#,##0")
                txtSc035.Text = db.Tosc035.ToString("#,##0") : txtSc040.Text = db.Tosc040.ToString("#,##0") : txtSc045.Text = db.Tosc045.ToString("#,##0")
                txtSc050.Text = db.Tosc050.ToString("#,##0") : txtSc055.Text = db.Tosc055.ToString("#,##0") : txtSc060.Text = db.Tosc060.ToString("#,##0")
                txtSc065.Text = db.Tosc065.ToString("#,##0") : txtSc070.Text = db.Tosc070.ToString("#,##0") : txtSc075.Text = db.Tosc075.ToString("#,##0")
                txtSc080.Text = db.Tosc080.ToString("#,##0")
                txtKa005.Text = db.ToKa005.ToString("#,##0") : txtKa010.Text = db.ToKa010.ToString("#,##0") : txtKa015.Text = db.ToKa015.ToString("#,##0")
                txtKa020.Text = db.ToKa020.ToString("#,##0") : txtKa025.Text = db.ToKa025.ToString("#,##0") : txtKa030.Text = db.ToKa030.ToString("#,##0")
                txtKa035.Text = db.ToKa035.ToString("#,##0") : txtKa040.Text = db.ToKa040.ToString("#,##0") : txtKa045.Text = db.ToKa045.ToString("#,##0")
                txtKa050.Text = db.ToKa050.ToString("#,##0") : txtKa055.Text = db.ToKa055.ToString("#,##0") : txtKa060.Text = db.ToKa060.ToString("#,##0")
                txtKa065.Text = db.ToKa065.ToString("#,##0") : txtKa070.Text = db.ToKa070.ToString("#,##0") : txtKa075.Text = db.ToKa075.ToString("#,##0")
                txtKa080.Text = db.ToKa080.ToString("#,##0") : txtKa085.Text = db.ToKa085.ToString("#,##0") : txtKa090.Text = db.ToKa090.ToString("#,##0")
                txtKa095.Text = db.ToKa095.ToString("#,##0") : txtKa100.Text = db.ToKa100.ToString("#,##0")
                txtKb005.Text = db.ToKb005.ToString("#,##0") : txtKb010.Text = db.ToKb010.ToString("#,##0") : txtKb015.Text = db.ToKb015.ToString("#,##0")
                txtKb020.Text = db.ToKb020.ToString("#,##0") : txtKb025.Text = db.ToKb025.ToString("#,##0") : txtKb030.Text = db.ToKb030.ToString("#,##0")
                txtKb035.Text = db.ToKb035.ToString("#,##0") : txtKb040.Text = db.ToKb040.ToString("#,##0")
                txtKc005.Text = db.ToKc005.ToString("#,##0") : txtKc010.Text = db.ToKc010.ToString("#,##0") : txtKc015.Text = db.ToKc015.ToString("#,##0")
                txtKc020.Text = db.ToKc020.ToString("#,##0") : txtKc025.Text = db.ToKc025.ToString("#,##0") : txtKc030.Text = db.ToKc030.ToString("#,##0")
                txtKc035.Text = db.ToKc035.ToString("#,##0") : txtKc040.Text = db.ToKc040.ToString("#,##0") : txtKc045.Text = db.ToKc045.ToString("#,##0")
                txtKc050.Text = db.ToKc050.ToString("#,##0") : txtKc055.Text = db.ToKc055.ToString("#,##0") : txtKc060.Text = db.ToKc060.ToString("#,##0")
                txtKc065.Text = db.ToKc065.ToString("#,##0") : txtKc070.Text = db.ToKc070.ToString("#,##0") : txtKc075.Text = db.ToKc075.ToString("#,##0")
                txtKc080.Text = db.ToKc080.ToString("#,##0")
                txtIa005.Text = db.ToIa005.ToString("#,##0") : txtIa010.Text = db.ToIa010.ToString("#,##0") : txtIa015.Text = db.ToIa015.ToString("#,##0")
                txtIa020.Text = db.ToIa020.ToString("#,##0") : txtIa025.Text = db.ToIa025.ToString("#,##0") : txtIa030.Text = db.ToIa030.ToString("#,##0")
                txtIa035.Text = db.ToIa035.ToString("#,##0") : txtIa040.Text = db.ToIa040.ToString("#,##0") : txtIa045.Text = db.ToIa045.ToString("#,##0")
                txtIa050.Text = db.ToIa050.ToString("#,##0") : txtIa055.Text = db.ToIa055.ToString("#,##0") : txtIa060.Text = db.ToIa060.ToString("#,##0")
                txtIa065.Text = db.ToIa065.ToString("#,##0") : txtIa070.Text = db.ToIa070.ToString("#,##0") : txtIa075.Text = db.ToIa075.ToString("#,##0")
                txtIa080.Text = db.ToIa080.ToString("#,##0") : txtIa085.Text = db.ToIa085.ToString("#,##0") : txtIa090.Text = db.ToIa090.ToString("#,##0")
                txtIa095.Text = db.ToIa095.ToString("#,##0") : txtIa100.Text = db.ToIa100.ToString("#,##0")
                txtIb005.Text = db.ToIb005.ToString("#,##0") : txtIb010.Text = db.ToIb010.ToString("#,##0") : txtIb015.Text = db.ToIb015.ToString("#,##0")
                txtIb020.Text = db.ToIb020.ToString("#,##0") : txtIb025.Text = db.ToIb025.ToString("#,##0") : txtIb030.Text = db.ToIb030.ToString("#,##0")
                txtIb035.Text = db.ToIb035.ToString("#,##0") : txtIb040.Text = db.ToIb040.ToString("#,##0")
                txtIc005.Text = db.ToIc005.ToString("#,##0") : txtIc010.Text = db.ToIc010.ToString("#,##0") : txtIc015.Text = db.ToIc015.ToString("#,##0")
                txtIc020.Text = db.ToIc020.ToString("#,##0") : txtIc025.Text = db.ToIc025.ToString("#,##0") : txtIc030.Text = db.ToIc030.ToString("#,##0")
                txtIc035.Text = db.ToIc035.ToString("#,##0") : txtIc040.Text = db.ToIc040.ToString("#,##0") : txtIc045.Text = db.ToIc045.ToString("#,##0")
                txtIc050.Text = db.ToIc050.ToString("#,##0") : txtIc055.Text = db.ToIc055.ToString("#,##0") : txtIc060.Text = db.ToIc060.ToString("#,##0")
                txtIc065.Text = db.ToIc065.ToString("#,##0") : txtIc070.Text = db.ToIc070.ToString("#,##0") : txtIc075.Text = db.ToIc075.ToString("#,##0")
                txtIc080.Text = db.ToIc080.ToString("#,##0")
                dr.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub UpdPayTable(ByVal FromDate As Date)
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_UPD_PAYTABLE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate
                cmd.Parameters.Add("@SA005", SqlDbType.Int).Value = CInt(txtSa005.Text)
                cmd.Parameters.Add("@SA010", SqlDbType.Int).Value = CInt(txtSa010.Text)
                cmd.Parameters.Add("@SA015", SqlDbType.Int).Value = CInt(txtSa015.Text)
                cmd.Parameters.Add("@SA020", SqlDbType.Int).Value = CInt(txtSa020.Text)
                cmd.Parameters.Add("@SA025", SqlDbType.Int).Value = CInt(txtSa025.Text)
                cmd.Parameters.Add("@SA030", SqlDbType.Int).Value = CInt(txtSa030.Text)
                cmd.Parameters.Add("@SA035", SqlDbType.Int).Value = CInt(txtSa035.Text)
                cmd.Parameters.Add("@SA040", SqlDbType.Int).Value = CInt(txtSa040.Text)
                cmd.Parameters.Add("@SA045", SqlDbType.Int).Value = CInt(txtSa045.Text)
                cmd.Parameters.Add("@SA050", SqlDbType.Int).Value = CInt(txtSa050.Text)
                cmd.Parameters.Add("@SA055", SqlDbType.Int).Value = CInt(txtSa055.Text)
                cmd.Parameters.Add("@SA060", SqlDbType.Int).Value = CInt(txtSa060.Text)
                cmd.Parameters.Add("@SA065", SqlDbType.Int).Value = CInt(txtSa065.Text)
                cmd.Parameters.Add("@SA070", SqlDbType.Int).Value = CInt(txtSa070.Text)
                cmd.Parameters.Add("@SA075", SqlDbType.Int).Value = CInt(txtSa075.Text)
                cmd.Parameters.Add("@SA080", SqlDbType.Int).Value = CInt(txtSa080.Text)
                cmd.Parameters.Add("@SA085", SqlDbType.Int).Value = CInt(txtSa085.Text)
                cmd.Parameters.Add("@SA090", SqlDbType.Int).Value = CInt(txtSa090.Text)
                cmd.Parameters.Add("@SA095", SqlDbType.Int).Value = CInt(txtSa095.Text)
                cmd.Parameters.Add("@SA100", SqlDbType.Int).Value = CInt(txtSa100.Text)
                cmd.Parameters.Add("@SB005", SqlDbType.Int).Value = CInt(txtSb005.Text)
                cmd.Parameters.Add("@SB010", SqlDbType.Int).Value = CInt(txtSb010.Text)
                cmd.Parameters.Add("@SB015", SqlDbType.Int).Value = CInt(txtSb015.Text)
                cmd.Parameters.Add("@SB020", SqlDbType.Int).Value = CInt(txtSb020.Text)
                cmd.Parameters.Add("@SB025", SqlDbType.Int).Value = CInt(txtSb025.Text)
                cmd.Parameters.Add("@SB030", SqlDbType.Int).Value = CInt(txtSb030.Text)
                cmd.Parameters.Add("@SB035", SqlDbType.Int).Value = CInt(txtSb035.Text)
                cmd.Parameters.Add("@SB040", SqlDbType.Int).Value = CInt(txtSb040.Text)
                cmd.Parameters.Add("@SC005", SqlDbType.Int).Value = CInt(txtSc005.Text)
                cmd.Parameters.Add("@SC010", SqlDbType.Int).Value = CInt(txtSc010.Text)
                cmd.Parameters.Add("@SC015", SqlDbType.Int).Value = CInt(txtSc015.Text)
                cmd.Parameters.Add("@SC020", SqlDbType.Int).Value = CInt(txtSc020.Text)
                cmd.Parameters.Add("@SC025", SqlDbType.Int).Value = CInt(txtSc025.Text)
                cmd.Parameters.Add("@SC030", SqlDbType.Int).Value = CInt(txtSc030.Text)
                cmd.Parameters.Add("@SC035", SqlDbType.Int).Value = CInt(txtSc035.Text)
                cmd.Parameters.Add("@SC040", SqlDbType.Int).Value = CInt(txtSc040.Text)
                cmd.Parameters.Add("@SC045", SqlDbType.Int).Value = CInt(txtSc045.Text)
                cmd.Parameters.Add("@SC050", SqlDbType.Int).Value = CInt(txtSc050.Text)
                cmd.Parameters.Add("@SC055", SqlDbType.Int).Value = CInt(txtSc055.Text)
                cmd.Parameters.Add("@SC060", SqlDbType.Int).Value = CInt(txtSc060.Text)
                cmd.Parameters.Add("@SC065", SqlDbType.Int).Value = CInt(txtSc065.Text)
                cmd.Parameters.Add("@SC070", SqlDbType.Int).Value = CInt(txtSc070.Text)
                cmd.Parameters.Add("@SC075", SqlDbType.Int).Value = CInt(txtSc075.Text)
                cmd.Parameters.Add("@SC080", SqlDbType.Int).Value = CInt(txtSc080.Text)
                cmd.Parameters.Add("@KA005", SqlDbType.Int).Value = CInt(txtKa005.Text)
                cmd.Parameters.Add("@KA010", SqlDbType.Int).Value = CInt(txtKa010.Text)
                cmd.Parameters.Add("@KA015", SqlDbType.Int).Value = CInt(txtKa015.Text)
                cmd.Parameters.Add("@KA020", SqlDbType.Int).Value = CInt(txtKa020.Text)
                cmd.Parameters.Add("@KA025", SqlDbType.Int).Value = CInt(txtKa025.Text)
                cmd.Parameters.Add("@KA030", SqlDbType.Int).Value = CInt(txtKa030.Text)
                cmd.Parameters.Add("@KA035", SqlDbType.Int).Value = CInt(txtKa035.Text)
                cmd.Parameters.Add("@KA040", SqlDbType.Int).Value = CInt(txtKa040.Text)
                cmd.Parameters.Add("@KA045", SqlDbType.Int).Value = CInt(txtKa045.Text)
                cmd.Parameters.Add("@KA050", SqlDbType.Int).Value = CInt(txtKa050.Text)
                cmd.Parameters.Add("@KA055", SqlDbType.Int).Value = CInt(txtKa055.Text)
                cmd.Parameters.Add("@KA060", SqlDbType.Int).Value = CInt(txtKa060.Text)
                cmd.Parameters.Add("@KA065", SqlDbType.Int).Value = CInt(txtKa065.Text)
                cmd.Parameters.Add("@KA070", SqlDbType.Int).Value = CInt(txtKa070.Text)
                cmd.Parameters.Add("@KA075", SqlDbType.Int).Value = CInt(txtKa075.Text)
                cmd.Parameters.Add("@KA080", SqlDbType.Int).Value = CInt(txtKa080.Text)
                cmd.Parameters.Add("@KA085", SqlDbType.Int).Value = CInt(txtKa085.Text)
                cmd.Parameters.Add("@KA090", SqlDbType.Int).Value = CInt(txtKa090.Text)
                cmd.Parameters.Add("@KA095", SqlDbType.Int).Value = CInt(txtKa095.Text)
                cmd.Parameters.Add("@KA100", SqlDbType.Int).Value = CInt(txtKa100.Text)
                cmd.Parameters.Add("@KB005", SqlDbType.Int).Value = CInt(txtKb005.Text)
                cmd.Parameters.Add("@KB010", SqlDbType.Int).Value = CInt(txtKb010.Text)
                cmd.Parameters.Add("@KB015", SqlDbType.Int).Value = CInt(txtKb015.Text)
                cmd.Parameters.Add("@KB020", SqlDbType.Int).Value = CInt(txtKb020.Text)
                cmd.Parameters.Add("@KB025", SqlDbType.Int).Value = CInt(txtKb025.Text)
                cmd.Parameters.Add("@KB030", SqlDbType.Int).Value = CInt(txtKb030.Text)
                cmd.Parameters.Add("@KB035", SqlDbType.Int).Value = CInt(txtKb035.Text)
                cmd.Parameters.Add("@KB040", SqlDbType.Int).Value = CInt(txtKb040.Text)
                cmd.Parameters.Add("@KC005", SqlDbType.Int).Value = CInt(txtKc005.Text)
                cmd.Parameters.Add("@KC010", SqlDbType.Int).Value = CInt(txtKc010.Text)
                cmd.Parameters.Add("@KC015", SqlDbType.Int).Value = CInt(txtKc015.Text)
                cmd.Parameters.Add("@KC020", SqlDbType.Int).Value = CInt(txtKc020.Text)
                cmd.Parameters.Add("@KC025", SqlDbType.Int).Value = CInt(txtKc025.Text)
                cmd.Parameters.Add("@KC030", SqlDbType.Int).Value = CInt(txtKc030.Text)
                cmd.Parameters.Add("@KC035", SqlDbType.Int).Value = CInt(txtKc035.Text)
                cmd.Parameters.Add("@KC040", SqlDbType.Int).Value = CInt(txtKc040.Text)
                cmd.Parameters.Add("@KC045", SqlDbType.Int).Value = CInt(txtKc045.Text)
                cmd.Parameters.Add("@KC050", SqlDbType.Int).Value = CInt(txtKc050.Text)
                cmd.Parameters.Add("@KC055", SqlDbType.Int).Value = CInt(txtKc055.Text)
                cmd.Parameters.Add("@KC060", SqlDbType.Int).Value = CInt(txtKc060.Text)
                cmd.Parameters.Add("@KC065", SqlDbType.Int).Value = CInt(txtKc065.Text)
                cmd.Parameters.Add("@KC070", SqlDbType.Int).Value = CInt(txtKc070.Text)
                cmd.Parameters.Add("@KC075", SqlDbType.Int).Value = CInt(txtKc075.Text)
                cmd.Parameters.Add("@KC080", SqlDbType.Int).Value = CInt(txtKc080.Text)
                cmd.Parameters.Add("@IA005", SqlDbType.Int).Value = CInt(txtIa005.Text)
                cmd.Parameters.Add("@IA010", SqlDbType.Int).Value = CInt(txtIa010.Text)
                cmd.Parameters.Add("@IA015", SqlDbType.Int).Value = CInt(txtIa015.Text)
                cmd.Parameters.Add("@IA020", SqlDbType.Int).Value = CInt(txtIa020.Text)
                cmd.Parameters.Add("@IA025", SqlDbType.Int).Value = CInt(txtIa025.Text)
                cmd.Parameters.Add("@IA030", SqlDbType.Int).Value = CInt(txtIa030.Text)
                cmd.Parameters.Add("@IA035", SqlDbType.Int).Value = CInt(txtIa035.Text)
                cmd.Parameters.Add("@IA040", SqlDbType.Int).Value = CInt(txtIa040.Text)
                cmd.Parameters.Add("@IA045", SqlDbType.Int).Value = CInt(txtIa045.Text)
                cmd.Parameters.Add("@IA050", SqlDbType.Int).Value = CInt(txtIa050.Text)
                cmd.Parameters.Add("@IA055", SqlDbType.Int).Value = CInt(txtIa055.Text)
                cmd.Parameters.Add("@IA060", SqlDbType.Int).Value = CInt(txtIa060.Text)
                cmd.Parameters.Add("@IA065", SqlDbType.Int).Value = CInt(txtIa065.Text)
                cmd.Parameters.Add("@IA070", SqlDbType.Int).Value = CInt(txtIa070.Text)
                cmd.Parameters.Add("@IA075", SqlDbType.Int).Value = CInt(txtIa075.Text)
                cmd.Parameters.Add("@IA080", SqlDbType.Int).Value = CInt(txtIa080.Text)
                cmd.Parameters.Add("@IA085", SqlDbType.Int).Value = CInt(txtIa085.Text)
                cmd.Parameters.Add("@IA090", SqlDbType.Int).Value = CInt(txtIa090.Text)
                cmd.Parameters.Add("@IA095", SqlDbType.Int).Value = CInt(txtIa095.Text)
                cmd.Parameters.Add("@IA100", SqlDbType.Int).Value = CInt(txtIa100.Text)
                cmd.Parameters.Add("@IB005", SqlDbType.Int).Value = CInt(txtIb005.Text)
                cmd.Parameters.Add("@IB010", SqlDbType.Int).Value = CInt(txtIb010.Text)
                cmd.Parameters.Add("@IB015", SqlDbType.Int).Value = CInt(txtIb015.Text)
                cmd.Parameters.Add("@IB020", SqlDbType.Int).Value = CInt(txtIb020.Text)
                cmd.Parameters.Add("@IB025", SqlDbType.Int).Value = CInt(txtIb025.Text)
                cmd.Parameters.Add("@IB030", SqlDbType.Int).Value = CInt(txtIb030.Text)
                cmd.Parameters.Add("@IB035", SqlDbType.Int).Value = CInt(txtIb035.Text)
                cmd.Parameters.Add("@IB040", SqlDbType.Int).Value = CInt(txtIb040.Text)
                cmd.Parameters.Add("@IC005", SqlDbType.Int).Value = CInt(txtIc005.Text)
                cmd.Parameters.Add("@IC010", SqlDbType.Int).Value = CInt(txtIc010.Text)
                cmd.Parameters.Add("@IC015", SqlDbType.Int).Value = CInt(txtIc015.Text)
                cmd.Parameters.Add("@IC020", SqlDbType.Int).Value = CInt(txtIc020.Text)
                cmd.Parameters.Add("@IC025", SqlDbType.Int).Value = CInt(txtIc025.Text)
                cmd.Parameters.Add("@IC030", SqlDbType.Int).Value = CInt(txtIc030.Text)
                cmd.Parameters.Add("@IC035", SqlDbType.Int).Value = CInt(txtIc035.Text)
                cmd.Parameters.Add("@IC040", SqlDbType.Int).Value = CInt(txtIc040.Text)
                cmd.Parameters.Add("@IC045", SqlDbType.Int).Value = CInt(txtIc045.Text)
                cmd.Parameters.Add("@IC050", SqlDbType.Int).Value = CInt(txtIc050.Text)
                cmd.Parameters.Add("@IC055", SqlDbType.Int).Value = CInt(txtIc055.Text)
                cmd.Parameters.Add("@IC060", SqlDbType.Int).Value = CInt(txtIc060.Text)
                cmd.Parameters.Add("@IC065", SqlDbType.Int).Value = CInt(txtIc065.Text)
                cmd.Parameters.Add("@IC070", SqlDbType.Int).Value = CInt(txtIc070.Text)
                cmd.Parameters.Add("@IC075", SqlDbType.Int).Value = CInt(txtIc075.Text)
                cmd.Parameters.Add("@IC080", SqlDbType.Int).Value = CInt(txtIc080.Text)
                cmd.ExecuteNonQuery()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub DelPayTable(ByVal FromDate As Date)
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_DEL_PAYTABLE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate
                cmd.ExecuteNonQuery()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtSa005.KeyPress, txtSa010.KeyPress, txtSa015.KeyPress, txtSa020.KeyPress, txtSa025.KeyPress, txtSa030.KeyPress, txtSa035.KeyPress, txtSa040.KeyPress, _
                txtSa045.KeyPress, txtSa050.KeyPress, txtSa055.KeyPress, txtSa060.KeyPress, txtSa065.KeyPress, txtSa070.KeyPress, txtSa075.KeyPress, txtSa080.KeyPress, _
                txtSa085.KeyPress, txtSa090.KeyPress, txtSa095.KeyPress, txtSa100.KeyPress, _
                txtSb005.KeyPress, txtSb010.KeyPress, txtSb015.KeyPress, txtSb020.KeyPress, txtSb025.KeyPress, txtSb030.KeyPress, txtSb035.KeyPress, txtSb040.KeyPress, _
                txtSc005.KeyPress, txtSc010.KeyPress, txtSc015.KeyPress, txtSc020.KeyPress, txtSc025.KeyPress, txtSc030.KeyPress, txtSc035.KeyPress, txtSc040.KeyPress, _
                txtSc045.KeyPress, txtSc050.KeyPress, txtSc055.KeyPress, txtSc060.KeyPress, txtSc065.KeyPress, txtSc070.KeyPress, txtSc075.KeyPress, txtSc080.KeyPress, _
                txtKa005.KeyPress, txtKa010.KeyPress, txtKa015.KeyPress, txtKa020.KeyPress, txtKa025.KeyPress, txtKa030.KeyPress, txtKa035.KeyPress, txtKa040.KeyPress, _
                txtKa045.KeyPress, txtKa050.KeyPress, txtKa055.KeyPress, txtKa060.KeyPress, txtKa065.KeyPress, txtKa070.KeyPress, txtKa075.KeyPress, txtKa080.KeyPress, _
                txtKa085.KeyPress, txtKa090.KeyPress, txtKa095.KeyPress, txtKa100.KeyPress, _
                txtKb005.KeyPress, txtKb010.KeyPress, txtKb015.KeyPress, txtKb020.KeyPress, txtKb025.KeyPress, txtKb030.KeyPress, txtKb035.KeyPress, txtKb040.KeyPress, _
                txtKc005.KeyPress, txtKc010.KeyPress, txtKc015.KeyPress, txtKc020.KeyPress, txtKc025.KeyPress, txtKc030.KeyPress, txtKc035.KeyPress, txtKc040.KeyPress, _
                txtKc045.KeyPress, txtKc050.KeyPress, txtKc055.KeyPress, txtKc060.KeyPress, txtKc065.KeyPress, txtKc070.KeyPress, txtKc075.KeyPress, txtKc080.KeyPress, _
                txtIa005.KeyPress, txtIa010.KeyPress, txtIa015.KeyPress, txtIa020.KeyPress, txtIa025.KeyPress, txtIa030.KeyPress, txtIa035.KeyPress, txtIa040.KeyPress, _
                txtIa045.KeyPress, txtIa050.KeyPress, txtIa055.KeyPress, txtIa060.KeyPress, txtIa065.KeyPress, txtIa070.KeyPress, txtIa075.KeyPress, txtIa080.KeyPress, _
                txtIa085.KeyPress, txtIa090.KeyPress, txtIa095.KeyPress, txtIa100.KeyPress, _
                txtIb005.KeyPress, txtIb010.KeyPress, txtIb015.KeyPress, txtIb020.KeyPress, txtIb025.KeyPress, txtIb030.KeyPress, txtIb035.KeyPress, txtIb040.KeyPress, _
                txtIc005.KeyPress, txtIc010.KeyPress, txtIc015.KeyPress, txtIc020.KeyPress, txtIc025.KeyPress, txtIc030.KeyPress, txtIc035.KeyPress, txtIc040.KeyPress, _
                txtIc045.KeyPress, txtIc050.KeyPress, txtIc055.KeyPress, txtIc060.KeyPress, txtIc065.KeyPress, txtIc070.KeyPress, txtIc075.KeyPress, txtIc080.KeyPress
        With DirectCast(sender, System.Windows.Forms.TextBox)
            Select Case e.KeyChar
                '数値のみ入力可能
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D0) To Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D9)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Delete) 'なぜか "."
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Back)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                    SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
                Case Else
                    e.Handled = True
            End Select
        End With
    End Sub

    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtSa005.Leave, txtSa010.Leave, txtSa015.Leave, txtSa020.Leave, txtSa025.Leave, txtSa030.Leave, txtSa035.Leave, txtSa040.Leave, _
                txtSa045.Leave, txtSa050.Leave, txtSa055.Leave, txtSa060.Leave, txtSa065.Leave, txtSa070.Leave, txtSa075.Leave, txtSa080.Leave, _
                txtSa085.Leave, txtSa090.Leave, txtSa095.Leave, txtSa100.Leave, _
                txtSb005.Leave, txtSb010.Leave, txtSb015.Leave, txtSb020.Leave, txtSb025.Leave, txtSb030.Leave, txtSb035.Leave, txtSb040.Leave, _
                txtSc005.Leave, txtSc010.Leave, txtSc015.Leave, txtSc020.Leave, txtSc025.Leave, txtSc030.Leave, txtSc035.Leave, txtSc040.Leave, _
                txtSc045.Leave, txtSc050.Leave, txtSc055.Leave, txtSc060.Leave, txtSc065.Leave, txtSc070.Leave, txtSc075.Leave, txtSc080.Leave, _
                txtKa005.Leave, txtKa010.Leave, txtKa015.Leave, txtKa020.Leave, txtKa025.Leave, txtKa030.Leave, txtKa035.Leave, txtKa040.Leave, _
                txtKa045.Leave, txtKa050.Leave, txtKa055.Leave, txtKa060.Leave, txtKa065.Leave, txtKa070.Leave, txtKa075.Leave, txtKa080.Leave, _
                txtKa085.Leave, txtKa090.Leave, txtKa095.Leave, txtKa100.Leave, _
                txtKb005.Leave, txtKb010.Leave, txtKb015.Leave, txtKb020.Leave, txtKb025.Leave, txtKb030.Leave, txtKb035.Leave, txtKb040.Leave, _
                txtKc005.Leave, txtKc010.Leave, txtKc015.Leave, txtKc020.Leave, txtKc025.Leave, txtKc030.Leave, txtKc035.Leave, txtKc040.Leave, _
                txtKc045.Leave, txtKc050.Leave, txtKc055.Leave, txtKc060.Leave, txtKc065.Leave, txtKc070.Leave, txtKc075.Leave, txtKc080.Leave, _
                txtIa005.Leave, txtIa010.Leave, txtIa015.Leave, txtIa020.Leave, txtIa025.Leave, txtIa030.Leave, txtIa035.Leave, txtIa040.Leave, _
                txtIa045.Leave, txtIa050.Leave, txtIa055.Leave, txtIa060.Leave, txtIa065.Leave, txtIa070.Leave, txtIa075.Leave, txtIa080.Leave, _
                txtIa085.Leave, txtIa090.Leave, txtIa095.Leave, txtIa100.Leave, _
                txtIb005.Leave, txtIb010.Leave, txtIb015.Leave, txtIb020.Leave, txtIb025.Leave, txtIb030.Leave, txtIb035.Leave, txtIb040.Leave, _
                txtIc005.Leave, txtIc010.Leave, txtIc015.Leave, txtIc020.Leave, txtIc025.Leave, txtIc030.Leave, txtIc035.Leave, txtIc040.Leave, _
                txtIc045.Leave, txtIc050.Leave, txtIc055.Leave, txtIc060.Leave, txtIc065.Leave, txtIc070.Leave, txtIc075.Leave, txtIc080.Leave
        Dim vl As Integer
        Dim st As String = sender.text
        st = st.Replace(",", "")
        If st = "" Then st = 0
        If Integer.TryParse(st, vl) Then
            sender.text = vl.ToString("#,##0")
        Else
            MsgBox("数値を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "不正入力")
            sender.focus()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim st As String = "指定された内容で開始日=[" & dtpFromDate.Value.ToString("yyyy/MM/dd") & "] として" & vbCrLf
        st &= "登録します。既存情報で同一開始日が存在する場合、" & vbCrLf
        st &= "上書きされます。よろしいですか？"
        Dim rslt As Integer = MsgBox(st, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "登録確認")
        If rslt = MsgBoxResult.Yes Then
            Call UpdPayTable(dtpFromDate.Value)
            MsgBox("登録しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
            Me.Close()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim st As String = "指定された開始日=[" & dtpFromDate.Value.ToString("yyyy/MM/dd") & "] 情報を" & vbCrLf
        st &= "削除します。既存情報で同一開始日が存在する場合、" & vbCrLf
        st &= "削除されます。よろしいですか？"
        Dim rslt As Integer = MsgBox(st, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "登録確認")
        If rslt = MsgBoxResult.Yes Then
            Call DelPayTable(dtpFromDate.Value)
            MsgBox("削除しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
            Me.Close()
        End If
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub txtSc070_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSc070.TextChanged

    End Sub
End Class