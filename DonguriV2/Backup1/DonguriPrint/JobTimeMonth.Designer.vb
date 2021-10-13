<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobTimeMonth
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobTimeMonth))
        Me.btnCreate = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.cmbSort = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnCreate.Location = New System.Drawing.Point(192, 45)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(114, 37)
        Me.btnCreate.TabIndex = 40
        Me.btnCreate.Text = "作成"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(312, 45)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(114, 37)
        Me.btnQuit.TabIndex = 35
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'dtpMonth
        '
        Me.dtpMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpMonth.CustomFormat = "yyyy 年 MM 月"
        Me.dtpMonth.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(12, 12)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(174, 26)
        Me.dtpMonth.TabIndex = 36
        '
        'cmbSort
        '
        Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSort.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.cmbSort.FormattingEnabled = True
        Me.cmbSort.Location = New System.Drawing.Point(192, 12)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.Size = New System.Drawing.Size(234, 27)
        Me.cmbSort.TabIndex = 41
        '
        'JobTimeMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 89)
        Me.Controls.Add(Me.cmbSort)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.dtpMonth)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "JobTimeMonth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ヘルパー稼働実績表"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSort As System.Windows.Forms.ComboBox
End Class
