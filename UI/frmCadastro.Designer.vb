<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadastro
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnCancelar = New Button()
        btnSalvar = New Button()
        cbStatus = New ComboBox()
        txtDescricao = New TextBox()
        txtValor = New TextBox()
        txtCartao = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        lblAviso = New Label()
        SuspendLayout()
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(248, 177)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(75, 23)
        btnCancelar.TabIndex = 10
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(330, 177)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(75, 23)
        btnSalvar.TabIndex = 9
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' cbStatus
        ' 
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FormattingEnabled = True
        cbStatus.Location = New Point(278, 25)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(127, 23)
        cbStatus.TabIndex = 5
        ' 
        ' txtDescricao
        ' 
        txtDescricao.Location = New Point(10, 84)
        txtDescricao.Multiline = True
        txtDescricao.Name = "txtDescricao"
        txtDescricao.ScrollBars = ScrollBars.Horizontal
        txtDescricao.Size = New Size(395, 53)
        txtDescricao.TabIndex = 7
        ' 
        ' txtValor
        ' 
        txtValor.Location = New Point(145, 25)
        txtValor.Name = "txtValor"
        txtValor.Size = New Size(127, 23)
        txtValor.TabIndex = 3
        txtValor.TextAlign = HorizontalAlignment.Right
        ' 
        ' txtCartao
        ' 
        txtCartao.Font = New Font("Courier New", 9F)
        txtCartao.Location = New Point(12, 27)
        txtCartao.MaxLength = 16
        txtCartao.Name = "txtCartao"
        txtCartao.Size = New Size(127, 21)
        txtCartao.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 15)
        Label1.TabIndex = 0
        Label1.Text = "Número do Cartão :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 6
        Label2.Text = "Descrição :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(148, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 15)
        Label3.TabIndex = 2
        Label3.Text = "Valor (R$) :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(282, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 4
        Label4.Text = "Status :"
        ' 
        ' lblAviso
        ' 
        lblAviso.AutoSize = True
        lblAviso.ForeColor = Color.Red
        lblAviso.Location = New Point(15, 144)
        lblAviso.Name = "lblAviso"
        lblAviso.Size = New Size(0, 15)
        lblAviso.TabIndex = 8
        ' 
        ' frmCadastro
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(418, 211)
        Controls.Add(lblAviso)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtCartao)
        Controls.Add(txtValor)
        Controls.Add(txtDescricao)
        Controls.Add(cbStatus)
        Controls.Add(btnSalvar)
        Controls.Add(btnCancelar)
        Name = "frmCadastro"
        Text = "frmCadastro"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents txtValor As TextBox
    Friend WithEvents txtCartao As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAviso As Label
End Class
