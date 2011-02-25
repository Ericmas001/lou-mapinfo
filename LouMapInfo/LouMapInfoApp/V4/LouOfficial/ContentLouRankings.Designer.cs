namespace LouMapInfoApp.V4.LouOfficial
{
    partial class ContentLouRankings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.dgvPlayersName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvPlayersAlliance = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvPlayersScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlayersRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlayersCities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToOrderColumns = true;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPlayersName,
            this.dgvPlayersAlliance,
            this.dgvPlayersScore,
            this.dgvPlayersRank,
            this.dgvPlayersCities});
            this.dgvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayers.Location = new System.Drawing.Point(0, 0);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPlayers.Size = new System.Drawing.Size(325, 247);
            this.dgvPlayers.TabIndex = 22;
            // 
            // dgvPlayersName
            // 
            this.dgvPlayersName.ActiveLinkColor = System.Drawing.Color.Black;
            this.dgvPlayersName.HeaderText = "Name";
            this.dgvPlayersName.LinkColor = System.Drawing.Color.Black;
            this.dgvPlayersName.Name = "dgvPlayersName";
            this.dgvPlayersName.ReadOnly = true;
            this.dgvPlayersName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayersName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvPlayersName.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // dgvPlayersAlliance
            // 
            this.dgvPlayersAlliance.ActiveLinkColor = System.Drawing.Color.Black;
            this.dgvPlayersAlliance.HeaderText = "Alliance";
            this.dgvPlayersAlliance.LinkColor = System.Drawing.Color.Black;
            this.dgvPlayersAlliance.Name = "dgvPlayersAlliance";
            this.dgvPlayersAlliance.ReadOnly = true;
            this.dgvPlayersAlliance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlayersAlliance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvPlayersAlliance.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // dgvPlayersScore
            // 
            this.dgvPlayersScore.HeaderText = "Score";
            this.dgvPlayersScore.Name = "dgvPlayersScore";
            this.dgvPlayersScore.ReadOnly = true;
            // 
            // dgvPlayersRank
            // 
            this.dgvPlayersRank.HeaderText = "Rank";
            this.dgvPlayersRank.Name = "dgvPlayersRank";
            this.dgvPlayersRank.ReadOnly = true;
            // 
            // dgvPlayersCities
            // 
            this.dgvPlayersCities.HeaderText = "Cities";
            this.dgvPlayersCities.Name = "dgvPlayersCities";
            this.dgvPlayersCities.ReadOnly = true;
            // 
            // ContentLouRankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LouMapInfoApp.Properties.Resources.LordOfUltima;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.dgvPlayers);
            this.DoubleBuffered = true;
            this.Name = "ContentLouRankings";
            this.Size = new System.Drawing.Size(325, 247);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.DataGridViewLinkColumn dgvPlayersName;
        private System.Windows.Forms.DataGridViewLinkColumn dgvPlayersAlliance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlayersCities;

    }
}
