<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransacoes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransacoes))
        tsMenu = New ToolStrip()
        btnCadastrar = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        btnEditar = New ToolStripButton()
        btnExcluir = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnExportar = New ToolStripButton()
        GroupBox1 = New GroupBox()
        btnFiltrar = New Button()
        Label4 = New Label()
        cbFiltroStatus = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        dtpFim = New DateTimePicker()
        dtpInicio = New DateTimePicker()
        txtFiltroCartao = New TextBox()
        Label1 = New Label()
        dgvTransacoes = New DataGridView()
        Panel1 = New Panel()
        lblPagina = New Label()
        btnProximaPagina = New Button()
        btnPaginaAnterior = New Button()
        tsMenu.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' tsMenu
        ' 
        tsMenu.AutoSize = False
        tsMenu.Items.AddRange(New ToolStripItem() {btnCadastrar, ToolStripSeparator1, btnEditar, btnExcluir, ToolStripSeparator2, btnExportar})
        tsMenu.Location = New Point(0, 0)
        tsMenu.Name = "tsMenu"
        tsMenu.Size = New Size(800, 50)
        tsMenu.TabIndex = 0
        tsMenu.Text = "Menu"
        ' 
        ' btnCadastrar
        ' 
        btnCadastrar.AutoSize = False
        btnCadastrar.Image = CType(resources.GetObject("btnCadastrar.Image"), Image)
        btnCadastrar.ImageTransparentColor = Color.Magenta
        btnCadastrar.Name = "btnCadastrar"
        btnCadastrar.RightToLeft = RightToLeft.No
        btnCadastrar.Size = New Size(40, 40)
        btnCadastrar.Text = "Nova"
        btnCadastrar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 50)
        ' 
        ' btnEditar
        ' 
        btnEditar.AutoSize = False
        btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), Image)
        btnEditar.ImageTransparentColor = Color.Magenta
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(40, 40)
        btnEditar.Text = "Editar"
        btnEditar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' btnExcluir
        ' 
        btnExcluir.AutoSize = False
        btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), Image)
        btnExcluir.ImageTransparentColor = Color.Magenta
        btnExcluir.Name = "btnExcluir"
        btnExcluir.Size = New Size(40, 40)
        btnExcluir.Text = "Excluir"
        btnExcluir.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 50)
        ' 
        ' btnExportar
        ' 
        btnExportar.AutoSize = False
        btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), Image)
        btnExportar.ImageTransparentColor = Color.Magenta
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(60, 40)
        btnExportar.Text = "Exportar"
        btnExportar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnFiltrar)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(cbFiltroStatus)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(dtpFim)
        GroupBox1.Controls.Add(dtpInicio)
        GroupBox1.Controls.Add(txtFiltroCartao)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Location = New Point(0, 50)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(800, 70)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        ' 
        ' btnFiltrar
        ' 
        btnFiltrar.Location = New Point(454, 37)
        btnFiltrar.Name = "btnFiltrar"
        btnFiltrar.Size = New Size(75, 23)
        btnFiltrar.TabIndex = 8
        btnFiltrar.Text = "Filtrar"
        btnFiltrar.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(331, 19)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 6
        Label4.Text = "Status :"
        ' 
        ' cbFiltroStatus
        ' 
        cbFiltroStatus.FormattingEnabled = True
        cbFiltroStatus.Location = New Point(331, 37)
        cbFiltroStatus.Name = "cbFiltroStatus"
        cbFiltroStatus.Size = New Size(108, 23)
        cbFiltroStatus.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(237, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(60, 15)
        Label3.TabIndex = 4
        Label3.Text = "Data Fim :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(140, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 15)
        Label2.TabIndex = 2
        Label2.Text = "Data Início :"
        ' 
        ' dtpFim
        ' 
        dtpFim.Format = DateTimePickerFormat.Short
        dtpFim.Location = New Point(237, 37)
        dtpFim.Name = "dtpFim"
        dtpFim.Size = New Size(83, 23)
        dtpFim.TabIndex = 5
        ' 
        ' dtpInicio
        ' 
        dtpInicio.Format = DateTimePickerFormat.Short
        dtpInicio.Location = New Point(140, 37)
        dtpInicio.Name = "dtpInicio"
        dtpInicio.Size = New Size(83, 23)
        dtpInicio.TabIndex = 3
        ' 
        ' txtFiltroCartao
        ' 
        txtFiltroCartao.Location = New Point(12, 37)
        txtFiltroCartao.MaxLength = 16
        txtFiltroCartao.Name = "txtFiltroCartao"
        txtFiltroCartao.Size = New Size(116, 23)
        txtFiltroCartao.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 15)
        Label1.TabIndex = 0
        Label1.Text = "Número do Cartão :"
        ' 
        ' dgvTransacoes
        ' 
        dgvTransacoes.AllowUserToAddRows = False
        dgvTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransacoes.Dock = DockStyle.Fill
        dgvTransacoes.Location = New Point(0, 120)
        dgvTransacoes.Name = "dgvTransacoes"
        dgvTransacoes.ReadOnly = True
        dgvTransacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTransacoes.Size = New Size(800, 330)
        dgvTransacoes.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPagina)
        Panel1.Controls.Add(btnProximaPagina)
        Panel1.Controls.Add(btnPaginaAnterior)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 409)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 41)
        Panel1.TabIndex = 3
        ' 
        ' lblPagina
        ' 
        lblPagina.AutoSize = True
        lblPagina.Location = New Point(113, 14)
        lblPagina.Name = "lblPagina"
        lblPagina.Size = New Size(64, 15)
        lblPagina.TabIndex = 1
        lblPagina.Text = "Página 100"
        ' 
        ' btnProximaPagina
        ' 
        btnProximaPagina.Location = New Point(185, 10)
        btnProximaPagina.Name = "btnProximaPagina"
        btnProximaPagina.Size = New Size(94, 23)
        btnProximaPagina.TabIndex = 0
        btnProximaPagina.Text = "Proxmo >>"
        btnProximaPagina.UseVisualStyleBackColor = False
        ' 
        ' btnPaginaAnterior
        ' 
        btnPaginaAnterior.Location = New Point(9, 10)
        btnPaginaAnterior.Name = "btnPaginaAnterior"
        btnPaginaAnterior.Size = New Size(94, 23)
        btnPaginaAnterior.TabIndex = 2
        btnPaginaAnterior.Text = "<< Anterior"
        btnPaginaAnterior.UseVisualStyleBackColor = False
        ' 
        ' frmTransacoes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel1)
        Controls.Add(dgvTransacoes)
        Controls.Add(GroupBox1)
        Controls.Add(tsMenu)
        Name = "frmTransacoes"
        Text = "Gerenciador de Cartões de Crédito"
        tsMenu.ResumeLayout(False)
        tsMenu.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnCadastrar As ToolStripButton
    Friend WithEvents btnEditar As ToolStripButton
    Friend WithEvents btnExcluir As ToolStripButton
    Friend WithEvents btnExportar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cbFiltroStatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFim As DateTimePicker
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents txtFiltroCartao As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvTransacoes As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnPaginaAnterior As Button
    Friend WithEvents lblPagina As Label
    Friend WithEvents btnProximaPagina As Button

End Class
