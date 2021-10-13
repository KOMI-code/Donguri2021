<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelperSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelperSelect))
        Me.cmbHelperSelect = New System.Windows.Forms.ComboBox
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmbHelperSelect
        '
        Me.cmbHelperSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbHelperSelect.DisplayMember = "Name"
        Me.cmbHelperSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHelperSelect.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.cmbHelperSelect.FormattingEnabled = True
        Me.cmbHelperSelect.Location = New System.Drawing.Point(12, 12)
        Me.cmbHelperSelect.Name = "cmbHelperSelect"
        Me.cmbHelperSelect.Size = New System.Drawing.Size(254, 27)
        Me.cmbHelperSelect.TabIndex = 3
        Me.cmbHelperSelect.ValueMember = "Id"
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(158, 45)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(108, 32)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnView.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnView.Location = New System.Drawing.Point(44, 45)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(108, 32)
        Me.btnView.TabIndex = 4
        Me.btnView.Text = "表示"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'HelperSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 85)
        Me.Controls.Add(Me.cmbHelperSelect)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnView)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "HelperSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ヘルパー選択"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbHelperSelect As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
End Class
