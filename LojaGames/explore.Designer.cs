namespace LojaGames
{
    partial class explore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(explore));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnEntrar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnExplorar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(723, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pictureBox1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnEntrar
            // 
            this.btnEntrar.AllowAnimations = true;
            this.btnEntrar.AllowMouseEffects = true;
            this.btnEntrar.AllowToggling = false;
            this.btnEntrar.AnimationSpeed = 200;
            this.btnEntrar.AutoGenerateColors = false;
            this.btnEntrar.AutoRoundBorders = false;
            this.btnEntrar.AutoSizeLeftIcon = true;
            this.btnEntrar.AutoSizeRightIcon = true;
            this.btnEntrar.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEntrar.BackgroundImage")));
            this.btnEntrar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEntrar.ButtonText = "Entrar";
            this.btnEntrar.ButtonTextMarginLeft = 0;
            this.btnEntrar.ColorContrastOnClick = 45;
            this.btnEntrar.ColorContrastOnHover = 45;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnEntrar.CustomizableEdges = borderEdges2;
            this.btnEntrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEntrar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEntrar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnEntrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEntrar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEntrar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnEntrar.IconMarginLeft = 11;
            this.btnEntrar.IconPadding = 10;
            this.btnEntrar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntrar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEntrar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEntrar.IconSize = 25;
            this.btnEntrar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.IdleBorderRadius = 15;
            this.btnEntrar.IdleBorderThickness = 1;
            this.btnEntrar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.IdleIconLeftImage = null;
            this.btnEntrar.IdleIconRightImage = null;
            this.btnEntrar.IndicateFocus = false;
            this.btnEntrar.Location = new System.Drawing.Point(465, 193);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnDisabledState.BorderRadius = 15;
            this.btnEntrar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEntrar.OnDisabledState.BorderThickness = 1;
            this.btnEntrar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEntrar.OnDisabledState.IconLeftImage = null;
            this.btnEntrar.OnDisabledState.IconRightImage = null;
            this.btnEntrar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.onHoverState.BorderRadius = 15;
            this.btnEntrar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEntrar.onHoverState.BorderThickness = 1;
            this.btnEntrar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.onHoverState.IconLeftImage = null;
            this.btnEntrar.onHoverState.IconRightImage = null;
            this.btnEntrar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnIdleState.BorderRadius = 15;
            this.btnEntrar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEntrar.OnIdleState.BorderThickness = 1;
            this.btnEntrar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEntrar.OnIdleState.IconLeftImage = null;
            this.btnEntrar.OnIdleState.IconRightImage = null;
            this.btnEntrar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnPressedState.BorderRadius = 15;
            this.btnEntrar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnEntrar.OnPressedState.BorderThickness = 1;
            this.btnEntrar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnEntrar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.OnPressedState.IconLeftImage = null;
            this.btnEntrar.OnPressedState.IconRightImage = null;
            this.btnEntrar.Size = new System.Drawing.Size(193, 40);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEntrar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEntrar.TextMarginLeft = 0;
            this.btnEntrar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnEntrar.UseDefaultRadiusAndThickness = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnExplorar
            // 
            this.btnExplorar.AllowAnimations = true;
            this.btnExplorar.AllowMouseEffects = true;
            this.btnExplorar.AllowToggling = false;
            this.btnExplorar.AnimationSpeed = 200;
            this.btnExplorar.AutoGenerateColors = false;
            this.btnExplorar.AutoRoundBorders = false;
            this.btnExplorar.AutoSizeLeftIcon = true;
            this.btnExplorar.AutoSizeRightIcon = true;
            this.btnExplorar.BackColor = System.Drawing.Color.Transparent;
            this.btnExplorar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExplorar.BackgroundImage")));
            this.btnExplorar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExplorar.ButtonText = "Explorar";
            this.btnExplorar.ButtonTextMarginLeft = 0;
            this.btnExplorar.ColorContrastOnClick = 45;
            this.btnExplorar.ColorContrastOnHover = 45;
            this.btnExplorar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnExplorar.CustomizableEdges = borderEdges1;
            this.btnExplorar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExplorar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExplorar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnExplorar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplorar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExplorar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplorar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnExplorar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnExplorar.IconMarginLeft = 11;
            this.btnExplorar.IconPadding = 10;
            this.btnExplorar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplorar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnExplorar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnExplorar.IconSize = 25;
            this.btnExplorar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.IdleBorderRadius = 15;
            this.btnExplorar.IdleBorderThickness = 1;
            this.btnExplorar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.IdleIconLeftImage = null;
            this.btnExplorar.IdleIconRightImage = null;
            this.btnExplorar.IndicateFocus = false;
            this.btnExplorar.Location = new System.Drawing.Point(79, 193);
            this.btnExplorar.Name = "btnExplorar";
            this.btnExplorar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnDisabledState.BorderRadius = 15;
            this.btnExplorar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExplorar.OnDisabledState.BorderThickness = 1;
            this.btnExplorar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnExplorar.OnDisabledState.IconLeftImage = null;
            this.btnExplorar.OnDisabledState.IconRightImage = null;
            this.btnExplorar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.onHoverState.BorderRadius = 15;
            this.btnExplorar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExplorar.onHoverState.BorderThickness = 1;
            this.btnExplorar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnExplorar.onHoverState.IconLeftImage = null;
            this.btnExplorar.onHoverState.IconRightImage = null;
            this.btnExplorar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnIdleState.BorderRadius = 15;
            this.btnExplorar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExplorar.OnIdleState.BorderThickness = 1;
            this.btnExplorar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExplorar.OnIdleState.IconLeftImage = null;
            this.btnExplorar.OnIdleState.IconRightImage = null;
            this.btnExplorar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnPressedState.BorderRadius = 15;
            this.btnExplorar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnExplorar.OnPressedState.BorderThickness = 1;
            this.btnExplorar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(93)))), ((int)(((byte)(195)))));
            this.btnExplorar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnExplorar.OnPressedState.IconLeftImage = null;
            this.btnExplorar.OnPressedState.IconRightImage = null;
            this.btnExplorar.Size = new System.Drawing.Size(193, 40);
            this.btnExplorar.TabIndex = 4;
            this.btnExplorar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExplorar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExplorar.TextMarginLeft = 0;
            this.btnExplorar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnExplorar.UseDefaultRadiusAndThickness = true;
            // 
            // explore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 426);
            this.ControlBox = false;
            this.Controls.Add(this.btnExplorar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "explore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "explore";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnEntrar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnExplorar;
    }
}