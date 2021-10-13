<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btnRestore = New System.Windows.Forms.Button
        Me.btnBackup = New System.Windows.Forms.Button
        Me.btnErrcheck = New System.Windows.Forms.Button
        Me.btnSchedule = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnPay = New System.Windows.Forms.Button
        Me.btnCalendar = New System.Windows.Forms.Button
        Me.btnHelper = New System.Windows.Forms.Button
        Me.btnUser = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnRstJobTimeHM = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRstJobTimeUM = New System.Windows.Forms.Button
        Me.btnSchJobTimeUM = New System.Windows.Forms.Button
        Me.btnSchJobTimeHM = New System.Windows.Forms.Button
        Me.btnHelperBaseM = New System.Windows.Forms.Button
        Me.btnUserBaseM = New System.Windows.Forms.Button
        Me.btnHelperBaseD = New System.Windows.Forms.Button
        Me.btnUserBaseD = New System.Windows.Forms.Button
        Me.fbDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.ofDlg = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnRestore)
        Me.GroupBox5.Controls.Add(Me.btnBackup)
        Me.GroupBox5.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.LimeGreen
        Me.GroupBox5.Location = New System.Drawing.Point(12, 587)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(827, 96)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "外部連携"
        '
        'btnRestore
        '
        Me.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestore.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRestore.ForeColor = System.Drawing.Color.Blue
        Me.btnRestore.Location = New System.Drawing.Point(416, 26)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(400, 59)
        Me.btnRestore.TabIndex = 3
        Me.btnRestore.Text = "バックアップ復元"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        Me.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackup.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackup.ForeColor = System.Drawing.Color.Blue
        Me.btnBackup.Location = New System.Drawing.Point(8, 26)
        Me.btnBackup.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(400, 59)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "バックアップ"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnErrcheck
        '
        Me.btnErrcheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnErrcheck.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnErrcheck.ForeColor = System.Drawing.Color.Blue
        Me.btnErrcheck.Location = New System.Drawing.Point(415, 26)
        Me.btnErrcheck.Margin = New System.Windows.Forms.Padding(4)
        Me.btnErrcheck.Name = "btnErrcheck"
        Me.btnErrcheck.Size = New System.Drawing.Size(400, 59)
        Me.btnErrcheck.TabIndex = 1
        Me.btnErrcheck.Text = "登録確認"
        Me.btnErrcheck.UseVisualStyleBackColor = True
        '
        'btnSchedule
        '
        Me.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSchedule.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSchedule.ForeColor = System.Drawing.Color.Blue
        Me.btnSchedule.Location = New System.Drawing.Point(7, 26)
        Me.btnSchedule.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSchedule.Name = "btnSchedule"
        Me.btnSchedule.Size = New System.Drawing.Size(400, 59)
        Me.btnSchedule.TabIndex = 0
        Me.btnSchedule.Text = "スケジュール管理"
        Me.btnSchedule.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnErrcheck)
        Me.GroupBox4.Controls.Add(Me.btnSchedule)
        Me.GroupBox4.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.LimeGreen
        Me.GroupBox4.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(827, 96)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "スケジュール管理"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPay)
        Me.GroupBox1.Controls.Add(Me.btnCalendar)
        Me.GroupBox1.Controls.Add(Me.btnHelper)
        Me.GroupBox1.Controls.Add(Me.btnUser)
        Me.GroupBox1.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.LimeGreen
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(827, 163)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "基本設定"
        '
        'btnPay
        '
        Me.btnPay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPay.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.Blue
        Me.btnPay.Location = New System.Drawing.Point(415, 93)
        Me.btnPay.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(400, 59)
        Me.btnPay.TabIndex = 3
        Me.btnPay.Text = "単価設定"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'btnCalendar
        '
        Me.btnCalendar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalendar.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCalendar.ForeColor = System.Drawing.Color.Blue
        Me.btnCalendar.Location = New System.Drawing.Point(8, 93)
        Me.btnCalendar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCalendar.Name = "btnCalendar"
        Me.btnCalendar.Size = New System.Drawing.Size(400, 59)
        Me.btnCalendar.TabIndex = 2
        Me.btnCalendar.Text = "カレンダー設定"
        Me.btnCalendar.UseVisualStyleBackColor = True
        '
        'btnHelper
        '
        Me.btnHelper.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelper.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelper.ForeColor = System.Drawing.Color.Blue
        Me.btnHelper.Location = New System.Drawing.Point(415, 26)
        Me.btnHelper.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHelper.Name = "btnHelper"
        Me.btnHelper.Size = New System.Drawing.Size(400, 59)
        Me.btnHelper.TabIndex = 1
        Me.btnHelper.Text = "ヘルパー設定"
        Me.btnHelper.UseVisualStyleBackColor = True
        '
        'btnUser
        '
        Me.btnUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUser.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUser.ForeColor = System.Drawing.Color.Blue
        Me.btnUser.Location = New System.Drawing.Point(8, 26)
        Me.btnUser.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(400, 59)
        Me.btnUser.TabIndex = 0
        Me.btnUser.Text = "利用者設定"
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnQuit.ForeColor = System.Drawing.Color.Blue
        Me.btnQuit.Location = New System.Drawing.Point(658, 690)
        Me.btnQuit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(181, 36)
        Me.btnQuit.TabIndex = 0
        Me.btnQuit.Text = "終了"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnRstJobTimeHM
        '
        Me.btnRstJobTimeHM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRstJobTimeHM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRstJobTimeHM.ForeColor = System.Drawing.Color.Blue
        Me.btnRstJobTimeHM.Location = New System.Drawing.Point(416, 227)
        Me.btnRstJobTimeHM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRstJobTimeHM.Name = "btnRstJobTimeHM"
        Me.btnRstJobTimeHM.Size = New System.Drawing.Size(400, 59)
        Me.btnRstJobTimeHM.TabIndex = 5
        Me.btnRstJobTimeHM.Text = "ヘルパー稼働実績表(月次)"
        Me.btnRstJobTimeHM.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRstJobTimeUM)
        Me.GroupBox2.Controls.Add(Me.btnSchJobTimeUM)
        Me.GroupBox2.Controls.Add(Me.btnSchJobTimeHM)
        Me.GroupBox2.Controls.Add(Me.btnHelperBaseM)
        Me.GroupBox2.Controls.Add(Me.btnUserBaseM)
        Me.GroupBox2.Controls.Add(Me.btnHelperBaseD)
        Me.GroupBox2.Controls.Add(Me.btnRstJobTimeHM)
        Me.GroupBox2.Controls.Add(Me.btnUserBaseD)
        Me.GroupBox2.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.LimeGreen
        Me.GroupBox2.Location = New System.Drawing.Point(12, 283)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(827, 296)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "スケジュール表"
        '
        'btnRstJobTimeUM
        '
        Me.btnRstJobTimeUM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRstJobTimeUM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRstJobTimeUM.ForeColor = System.Drawing.Color.Blue
        Me.btnRstJobTimeUM.Location = New System.Drawing.Point(415, 93)
        Me.btnRstJobTimeUM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRstJobTimeUM.Name = "btnRstJobTimeUM"
        Me.btnRstJobTimeUM.Size = New System.Drawing.Size(400, 59)
        Me.btnRstJobTimeUM.TabIndex = 7
        Me.btnRstJobTimeUM.Text = "利用者稼働実績表(月次)"
        Me.btnRstJobTimeUM.UseVisualStyleBackColor = True
        '
        'btnSchJobTimeUM
        '
        Me.btnSchJobTimeUM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSchJobTimeUM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSchJobTimeUM.ForeColor = System.Drawing.Color.Blue
        Me.btnSchJobTimeUM.Location = New System.Drawing.Point(8, 93)
        Me.btnSchJobTimeUM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSchJobTimeUM.Name = "btnSchJobTimeUM"
        Me.btnSchJobTimeUM.Size = New System.Drawing.Size(400, 59)
        Me.btnSchJobTimeUM.TabIndex = 6
        Me.btnSchJobTimeUM.Text = "利用者稼働予定表(月次)"
        Me.btnSchJobTimeUM.UseVisualStyleBackColor = True
        '
        'btnSchJobTimeHM
        '
        Me.btnSchJobTimeHM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSchJobTimeHM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSchJobTimeHM.ForeColor = System.Drawing.Color.Blue
        Me.btnSchJobTimeHM.Location = New System.Drawing.Point(8, 227)
        Me.btnSchJobTimeHM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSchJobTimeHM.Name = "btnSchJobTimeHM"
        Me.btnSchJobTimeHM.Size = New System.Drawing.Size(400, 59)
        Me.btnSchJobTimeHM.TabIndex = 4
        Me.btnSchJobTimeHM.Text = "ヘルパー稼働予定表(月次)"
        Me.btnSchJobTimeHM.UseVisualStyleBackColor = True
        '
        'btnHelperBaseM
        '
        Me.btnHelperBaseM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelperBaseM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelperBaseM.ForeColor = System.Drawing.Color.Blue
        Me.btnHelperBaseM.Location = New System.Drawing.Point(415, 160)
        Me.btnHelperBaseM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHelperBaseM.Name = "btnHelperBaseM"
        Me.btnHelperBaseM.Size = New System.Drawing.Size(400, 59)
        Me.btnHelperBaseM.TabIndex = 3
        Me.btnHelperBaseM.Text = "ヘルパー基準予定表 (月次)"
        Me.btnHelperBaseM.UseVisualStyleBackColor = True
        '
        'btnUserBaseM
        '
        Me.btnUserBaseM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUserBaseM.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUserBaseM.ForeColor = System.Drawing.Color.Blue
        Me.btnUserBaseM.Location = New System.Drawing.Point(415, 26)
        Me.btnUserBaseM.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUserBaseM.Name = "btnUserBaseM"
        Me.btnUserBaseM.Size = New System.Drawing.Size(400, 59)
        Me.btnUserBaseM.TabIndex = 1
        Me.btnUserBaseM.Text = "利用者基準予定表 (月次)"
        Me.btnUserBaseM.UseVisualStyleBackColor = True
        '
        'btnHelperBaseD
        '
        Me.btnHelperBaseD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelperBaseD.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHelperBaseD.ForeColor = System.Drawing.Color.Blue
        Me.btnHelperBaseD.Location = New System.Drawing.Point(8, 160)
        Me.btnHelperBaseD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHelperBaseD.Name = "btnHelperBaseD"
        Me.btnHelperBaseD.Size = New System.Drawing.Size(400, 59)
        Me.btnHelperBaseD.TabIndex = 2
        Me.btnHelperBaseD.Text = "ヘルパー基準予定表（日次）"
        Me.btnHelperBaseD.UseVisualStyleBackColor = True
        '
        'btnUserBaseD
        '
        Me.btnUserBaseD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUserBaseD.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUserBaseD.ForeColor = System.Drawing.Color.Blue
        Me.btnUserBaseD.Location = New System.Drawing.Point(7, 26)
        Me.btnUserBaseD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUserBaseD.Name = "btnUserBaseD"
        Me.btnUserBaseD.Size = New System.Drawing.Size(400, 59)
        Me.btnUserBaseD.TabIndex = 0
        Me.btnUserBaseD.Text = "利用者基準予定表（日次）"
        Me.btnUserBaseD.UseVisualStyleBackColor = True
        '
        'fbDlg
        '
        Me.fbDlg.Description = "フォルダを指定してください。"
        Me.fbDlg.ShowNewFolderButton = False
        '
        'ofDlg
        '
        Me.ofDlg.Filter = "バックアップファイル(*.bak)|*.bak|スケジュールファイル(*.csv)|*.csv"
        Me.ofDlg.InitialDirectory = "D:\"
        Me.ofDlg.RestoreDirectory = True
        Me.ofDlg.Title = "バックアップファイルを選択してください"
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 731)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "どんぐり Ver2.00"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents btnErrcheck As System.Windows.Forms.Button
    Friend WithEvents btnSchedule As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents btnCalendar As System.Windows.Forms.Button
    Friend WithEvents btnHelper As System.Windows.Forms.Button
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnRstJobTimeHM As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHelperBaseM As System.Windows.Forms.Button
    Friend WithEvents btnUserBaseM As System.Windows.Forms.Button
    Friend WithEvents btnHelperBaseD As System.Windows.Forms.Button
    Friend WithEvents btnUserBaseD As System.Windows.Forms.Button
    Friend WithEvents fbDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnSchJobTimeHM As System.Windows.Forms.Button
    Friend WithEvents btnRstJobTimeUM As System.Windows.Forms.Button
    Friend WithEvents btnSchJobTimeUM As System.Windows.Forms.Button
    Friend WithEvents ofDlg As System.Windows.Forms.OpenFileDialog

End Class
