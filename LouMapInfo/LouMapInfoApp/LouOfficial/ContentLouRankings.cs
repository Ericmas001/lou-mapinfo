using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LouMapInfo.Entities;
using LouMapInfo.Reports.core;
using LouMapInfo.Reports;
using System.Threading;

namespace LouMapInfoApp.LouOfficial
{
    public partial class ContentLouRankings : UserControl, ILouContent
    {
        //Links
        DataGridViewLinkColumn colPlayer = new DataGridViewLinkColumn();
        DataGridViewLinkColumn colAlliance = new DataGridViewLinkColumn();

        //N0
        DataGridViewTextBoxColumn colRank = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colRankOverall = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colScore = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colScoreAvg = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colNbCities = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colRes = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colResWood = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colResStone = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colResIron = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colResFood = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colResGold = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colTSMax = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colTS = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colTSDefeated = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colRecSpeed = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colMembers = new DataGridViewTextBoxColumn();

        //N0 (N0%)
        DataGridViewTextBoxColumn colVTotal = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVCompassion = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVHonesty = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVHonor = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVHumility = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVJustice = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVSacrifice = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVSpirituality = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn colVValor = new DataGridViewTextBoxColumn();

        /*
         * this.dgvPlayersName = new System.Windows.Forms.DataGridViewLinkColumn();
                this.dgvPlayersAlliance = new System.Windows.Forms.DataGridViewLinkColumn();
                this.dgvPlayersScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.dgvPlayersRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.dgvPlayersCities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            
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
                this.dgvPlayers.Location = new System.Drawing.Point(0, 50);
                this.dgvPlayers.Name = "dgvPlayers";
                this.dgvPlayers.ReadOnly = true;
                this.dgvPlayers.RowHeadersVisible = false;
                this.dgvPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                this.dgvPlayers.Size = new System.Drawing.Size(740, 197);
                this.dgvPlayers.TabIndex = 26;
         * 
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
                this.dgvPlayersAlliance.LinkColor = System.Drawing.Color.Black;
                this.dgvPlayersAlliance.VisitedLinkColor = System.Drawing.Color.Black;
                this.dgvPlayersAlliance.HeaderText = "Alliance";
                this.dgvPlayersAlliance.Name = "dgvPlayersAlliance";
                this.dgvPlayersAlliance.ReadOnly = true;
                this.dgvPlayersAlliance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                this.dgvPlayersAlliance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
         * */
        private ContentLoUOfficial m_Frame;
        ToolStripButton oldBtn;
        public SessionInfo Session
        {
            get { return m_Frame.MainForm.Session; }
        }
        public ContentLoUOfficial Frame
        {
            get { return m_Frame; }
            set
            {
                m_Frame = value;
                FillRanking(btnPRanking, RankingType.PRanking,
                colRank,
                colPlayer,
                colScore,
                colAlliance,
                colNbCities);
            }
        }
        public ContentLouRankings()
        {
            InitializeComponent();
            InitColumns();
            oldBtn = btnPRanking;
            dgvPlayers.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvPlayers_CellFormatting);
            dgvPlayers.CellContentClick += new DataGridViewCellEventHandler(dgvPlayers_CellContentClick);
        }

        void dgvPlayers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == colRank.Index || 
                e.ColumnIndex == colScore.Index || 
                e.ColumnIndex == colNbCities.Index)
            {
                e.Value = ((int)e.Value).ToString("N0");
            }
        }

        private void InitColumns()
        {
            colPlayer.HeaderText = "Player";
            colPlayer.ReadOnly = true;
            colPlayer.ActiveLinkColor = System.Drawing.Color.Black;
            colPlayer.LinkColor = System.Drawing.Color.Black;
            colPlayer.VisitedLinkColor = System.Drawing.Color.Black;
            colPlayer.Resizable = DataGridViewTriState.True;
            colPlayer.SortMode = DataGridViewColumnSortMode.Automatic;

            colAlliance.HeaderText = "Alliance";
            colAlliance.ReadOnly = true;
            colAlliance.ActiveLinkColor = System.Drawing.Color.Black;
            colAlliance.LinkColor = System.Drawing.Color.Black;
            colAlliance.VisitedLinkColor = System.Drawing.Color.Black;
            colAlliance.Resizable = DataGridViewTriState.True;
            colAlliance.SortMode = DataGridViewColumnSortMode.Automatic;

            colRank.HeaderText = "Rank";
            colRank.ReadOnly = true;

            colRankOverall.HeaderText = "Overall Rank";
            colRankOverall.ReadOnly = true;

            colScore.HeaderText = "Score";
            colScore.ReadOnly = true;

            colScoreAvg.HeaderText = "Avg. Score";
            colScoreAvg.ReadOnly = true;

            colNbCities.HeaderText = "Cities";
            colNbCities.ReadOnly = true;

            colRes.HeaderText = "Resources";
            colRes.ReadOnly = true;

            colResWood.HeaderText = "Wood";
            colResWood.ReadOnly = true;

            colResStone.HeaderText = "Stone";
            colResStone.ReadOnly = true;

            colResIron.HeaderText = "Iron";
            colResIron.ReadOnly = true;

            colResFood.HeaderText = "Food";
            colResFood.ReadOnly = true;

            colResGold.HeaderText = "Gold";
            colResGold.ReadOnly = true;

            colTSMax.HeaderText = "Max TS";
            colTSMax.ReadOnly = true;

            colTS.HeaderText = "TS";
            colTS.ReadOnly = true;

            colTSDefeated.HeaderText = "Defeated TS";
            colTSDefeated.ReadOnly = true;

            colRecSpeed.HeaderText = "Recruitment Speed";
            colRecSpeed.ReadOnly = true;

            colMembers.HeaderText = "Members";
            colMembers.ReadOnly = true;

            colVTotal.HeaderText = "Total";
            colVTotal.ReadOnly = true;

            colVCompassion.HeaderText = "Compassion";
            colVCompassion.ReadOnly = true;

            colVHonesty.HeaderText = "Honesty";
            colVHonesty.ReadOnly = true;

            colVHonor.HeaderText = "Honor";
            colVHonor.ReadOnly = true;

            colVHumility.HeaderText = "Humility";
            colVHumility.ReadOnly = true;

            colVJustice.HeaderText = "Justice";
            colVJustice.ReadOnly = true;

            colVSacrifice.HeaderText = "Sacrifice";
            colVSacrifice.ReadOnly = true;

            colVSpirituality.HeaderText = "Spirituality";
            colVSpirituality.ReadOnly = true;

            colVValor.HeaderText = "Valor";
            colVValor.ReadOnly = true;

        }

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPlayers.Columns.Contains(colPlayer) && e.ColumnIndex == colPlayer.Index)
                    OpenPlayerReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());

                if (dgvPlayers.Columns.Contains(colAlliance) && e.ColumnIndex == colAlliance.Index)
                    OpenAllianceReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
        }

        private void OpenPlayerReport(object p)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenPlayerReportAsync)).Start(p);
        }

        private void OpenPlayerReportAsync(object o)
        {
            PlayerInfo p = null;
            if (o is int)
                p = Session.World.Player((int)o);
            else if (o is string)
                p = Session.World.Player((string)o);

            if (p == null)
                ContentEnabling(true);
            else
            {
                PlayerOverviewReport rep = new PlayerOverviewReport(p);
                rep.LoadIfNeeded();
                OpenReport(rep, Properties.Settings.Default.detailLevel);
                ContentEnabling(true);
            }
        }

        private void OpenAllianceReport(object a)
        {
            ContentEnabling(false);
            new Thread(new ParameterizedThreadStart(OpenAllianceReportAsync)).Start(a);
        }

        private void OpenAllianceReportAsync(object o)
        {
            AllianceInfo a = null;
            if (o is int)
                a = Session.World.Alliance((int)o);
            else if (o is string)
                a = Session.World.Alliance((string)o);

            if (a == null)
                ContentEnabling(true);
            else
            {
                AllianceOverviewReport rep = new AllianceOverviewReport(a);
                rep.LoadIfNeeded();
                OpenReport(rep, Properties.Settings.Default.detailLevel);
                ContentEnabling(true);
            }
        }
        delegate void BoolHandler(bool isConnected);
        public void ContentEnabling(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new BoolHandler(ContentEnabling), value);
                return;
            }
            dgvPlayers.Enabled = value;
            if (value)
                Frame.StopWaiting();
            else
            {
                Frame.StartWaiting();
            }
        }
        public delegate void ReportHandler(ReportInfo r, int lvl);
        public void OpenReport(ReportInfo r, int lvl)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportHandler(OpenReport), r, lvl);
                return;
            }
            new ReportForm(r, lvl).Show();
            //ContentReport content = new ContentReport(r, lvl);
            //pnlContent.Controls.Add(content);
            //content.Dock = DockStyle.Fill;
        }

        private void FillRanking(ToolStripButton btn, RankingType type, params DataGridViewColumn[] cols)
        {
            if (oldBtn != btn)
            {
                oldBtn.BackColor = Color.White;
                oldBtn = btn;
                btn.BackColor = SystemColors.Highlight;
            }
            dgvPlayers.Columns.Clear();
            for (int i = cols.Length - 1; i >= 0; --i)
                cols[i].DisplayIndex = i;
            dgvPlayers.Columns.AddRange(cols);
            dgvPlayers.Rows.Clear();
            foreach (object[] line in Session.World.Ranking(type))
            {
                dgvPlayers.Rows.Add(line);
            }
        }


        private void btnPRanking_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PRanking,
                colRank,
                colPlayer,
                colScore,
                colAlliance,
                colNbCities);
        }

        private void btnPResources_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PResources,
                colRank,
                colPlayer,
                colScore,
                colResWood,
                colResStone,
                colResIron,
                colResFood,
                colResGold);
        }

        private void btnPMilitary_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PMilitary,
                colRank,
                colPlayer,
                colScore,
                colTSMax,
                colRecSpeed);
        }

        private void btnPOffense_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.POffense,
                colRank,
                colPlayer,
                colTS);
        }

        private void btnPDefense_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PDefense,
                colRank,
                colPlayer,
                colTS);
        }

        private void btnPUnits_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PUnits,
                colRank,
                colPlayer,
                colTSDefeated,
                colAlliance,
                colRankOverall);
        }

        private void btnPPlunder_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PPlunder,
                colRank,
                colPlayer,
                colRes,
                colAlliance,
                colRankOverall);
        }

        private void btnPFaith_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.PFaith,
                colRank,
                colPlayer,
                colAlliance,
                colVTotal,
                colVCompassion,
                colVHonesty,
                colVHonor,
                colVHumility,
                colVJustice,
                colVSacrifice,
                colVSpirituality,
                colVValor);
        }

        private void btnARanking_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.ARanking,
                colRank,
                colAlliance,
                colScore,
                colMembers,
                colScoreAvg,
                colNbCities);
        }

        private void btnAUnits_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.AUnits,
                colRank,
                colAlliance,
                colTSDefeated);
        }

        private void btnAFaith_Click(object sender, EventArgs e)
        {
            FillRanking((ToolStripButton)sender, RankingType.AFaith,
                colRank,
                colAlliance,
                colVTotal,
                colVCompassion,
                colVHonesty,
                colVHonor,
                colVHumility,
                colVJustice,
                colVSacrifice,
                colVSpirituality,
                colVValor);
        }
    }
}
