
namespace Hashing
{
    partial class FrmHash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHash));
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsBotoes = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.imlBotoes = new System.Windows.Forms.ImageList(this.components);
            this.gbHashing = new System.Windows.Forms.GroupBox();
            this.rbDuplo = new System.Windows.Forms.RadioButton();
            this.rbQuadratica = new System.Windows.Forms.RadioButton();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.lsbColisoes = new System.Windows.Forms.ListBox();
            this.colunaIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaChave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            this.tsBotoes.SuspendLayout();
            this.gbHashing.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTabela
            // 
            this.dgvTabela.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaIndice,
            this.colunaChave,
            this.colunaNome});
            this.dgvTabela.Location = new System.Drawing.Point(12, 125);
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.RowHeadersWidth = 51;
            this.dgvTabela.RowTemplate.Height = 24;
            this.dgvTabela.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvTabela.Size = new System.Drawing.Size(310, 264);
            this.dgvTabela.TabIndex = 19;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(69, 88);
            this.txtNome.MaxLength = 15;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(241, 20);
            this.txtNome.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome:";
            // 
            // txtChave
            // 
            this.txtChave.Location = new System.Drawing.Point(69, 62);
            this.txtChave.MaxLength = 15;
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(241, 20);
            this.txtChave.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chave:";
            // 
            // tsBotoes
            // 
            this.tsBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tsBotoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsBotoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscar,
            this.btnNovo,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator4,
            this.btnSair});
            this.tsBotoes.Location = new System.Drawing.Point(0, 0);
            this.tsBotoes.Name = "tsBotoes";
            this.tsBotoes.Size = new System.Drawing.Size(679, 42);
            this.tsBotoes.TabIndex = 20;
            this.tsBotoes.Text = "toolStrip1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 39);
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.ToolTipText = "Busca registro pelo código";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(44, 39);
            this.btnNovo.Text = "&Incluir";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovo.ToolTipText = "Iniciar a inclusão de novo registro";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(41, 39);
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(46, 39);
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluir.ToolTipText = "Exclui o registro apresentado na tela";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(30, 39);
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.ToolTipText = "Termina a execução do programa e salva no disco todos os dados";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // imlBotoes
            // 
            this.imlBotoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotoes.ImageStream")));
            this.imlBotoes.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBotoes.Images.SetKeyName(0, "Oeil2.bmp");
            this.imlBotoes.Images.SetKeyName(1, "Add.bmp");
            this.imlBotoes.Images.SetKeyName(2, "COPY.BMP");
            this.imlBotoes.Images.SetKeyName(3, "Minus.bmp");
            this.imlBotoes.Images.SetKeyName(4, "CLOSE1.BMP");
            this.imlBotoes.Images.SetKeyName(5, "about.bmp");
            this.imlBotoes.Images.SetKeyName(6, "PRINTER5.BMP");
            this.imlBotoes.Images.SetKeyName(7, "REDO.BMP");
            this.imlBotoes.Images.SetKeyName(8, "WINNEXT.BMP");
            this.imlBotoes.Images.SetKeyName(9, "WINPREV.BMP");
            this.imlBotoes.Images.SetKeyName(10, "abort.bmp");
            // 
            // gbHashing
            // 
            this.gbHashing.Controls.Add(this.rbDuplo);
            this.gbHashing.Controls.Add(this.rbQuadratica);
            this.gbHashing.Controls.Add(this.rbLinear);
            this.gbHashing.Location = new System.Drawing.Point(322, 62);
            this.gbHashing.Name = "gbHashing";
            this.gbHashing.Size = new System.Drawing.Size(211, 46);
            this.gbHashing.TabIndex = 21;
            this.gbHashing.TabStop = false;
            this.gbHashing.Text = "Opções de Hashing:";
            // 
            // rbDuplo
            // 
            this.rbDuplo.AutoSize = true;
            this.rbDuplo.Location = new System.Drawing.Point(152, 19);
            this.rbDuplo.Name = "rbDuplo";
            this.rbDuplo.Size = new System.Drawing.Size(53, 17);
            this.rbDuplo.TabIndex = 2;
            this.rbDuplo.TabStop = true;
            this.rbDuplo.Text = "Duplo";
            this.rbDuplo.UseVisualStyleBackColor = true;
            this.rbDuplo.Click += new System.EventHandler(this.rbDuplo_Click_1);
            // 
            // rbQuadratica
            // 
            this.rbQuadratica.AutoSize = true;
            this.rbQuadratica.Location = new System.Drawing.Point(66, 19);
            this.rbQuadratica.Name = "rbQuadratica";
            this.rbQuadratica.Size = new System.Drawing.Size(77, 17);
            this.rbQuadratica.TabIndex = 1;
            this.rbQuadratica.TabStop = true;
            this.rbQuadratica.Text = "Quadratica";
            this.rbQuadratica.UseVisualStyleBackColor = true;
            this.rbQuadratica.Click += new System.EventHandler(this.rbQuadratica_Click_1);
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(6, 19);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(54, 17);
            this.rbLinear.TabIndex = 0;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.Click += new System.EventHandler(this.rbLinear_Click_1);
            // 
            // lsbColisoes
            // 
            this.lsbColisoes.Enabled = false;
            this.lsbColisoes.FormattingEnabled = true;
            this.lsbColisoes.Location = new System.Drawing.Point(328, 125);
            this.lsbColisoes.Name = "lsbColisoes";
            this.lsbColisoes.ScrollAlwaysVisible = true;
            this.lsbColisoes.Size = new System.Drawing.Size(339, 264);
            this.lsbColisoes.TabIndex = 22;
            // 
            // colunaIndice
            // 
            this.colunaIndice.Frozen = true;
            this.colunaIndice.HeaderText = "ID";
            this.colunaIndice.MinimumWidth = 6;
            this.colunaIndice.Name = "colunaIndice";
            this.colunaIndice.Width = 43;
            // 
            // colunaChave
            // 
            this.colunaChave.HeaderText = "Chave";
            this.colunaChave.Name = "colunaChave";
            this.colunaChave.Width = 63;
            // 
            // colunaNome
            // 
            this.colunaNome.HeaderText = "Nome";
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.Width = 60;
            // 
            // FrmHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 423);
            this.Controls.Add(this.lsbColisoes);
            this.Controls.Add(this.gbHashing);
            this.Controls.Add(this.tsBotoes);
            this.Controls.Add(this.dgvTabela);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChave);
            this.Controls.Add(this.label1);
            this.Name = "FrmHash";
            this.Text = "Tipos de sondagem para HashCode";
            this.Load += new System.EventHandler(this.FrmHashLinear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            this.tsBotoes.ResumeLayout(false);
            this.tsBotoes.PerformLayout();
            this.gbHashing.ResumeLayout(false);
            this.gbHashing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tsBotoes;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.ImageList imlBotoes;
        private System.Windows.Forms.GroupBox gbHashing;
        private System.Windows.Forms.RadioButton rbDuplo;
        private System.Windows.Forms.RadioButton rbQuadratica;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.ListBox lsbColisoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaChave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
    }
}