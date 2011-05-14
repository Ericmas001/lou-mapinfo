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
                btnARanking_Click(btnARanking, new EventArgs());
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

        bool currentCol(DataGridViewCellFormattingEventArgs e, DataGridViewColumn c)
        {
            return (e.ColumnIndex == c.DisplayIndex && c.DataGridView != null);
        }

        bool currentCol(DataGridViewCellEventArgs e, DataGridViewColumn c)
        {
            return (e.ColumnIndex == c.DisplayIndex && c.DataGridView != null);
        }

        void dgvPlayers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (currentCol(e, colRank) ||
                currentCol(e, colScore) ||
                currentCol(e, colResFood) ||
                currentCol(e, colResGold) ||
                currentCol(e, colResIron) ||
                currentCol(e, colResStone) ||
                currentCol(e, colResWood) ||
                currentCol(e, colNbCities) ||
                currentCol(e, colTS) ||
                currentCol(e, colTSMax) ||
                currentCol(e, colRankOverall) ||
                currentCol(e, colScoreAvg) ||
                currentCol(e, colMembers) ||
                currentCol(e, colRecSpeed))
            {
                e.Value = ((int)e.Value).ToString("N0");
            }
            if (currentCol(e, colTSDefeated) ||
                currentCol(e, colRes))
            {
                e.Value = ((long)e.Value).ToString("N0");
            }

            if (currentCol(e, colVCompassion) ||
                currentCol(e, colVHonesty) ||
                currentCol(e, colVHonor) ||
                currentCol(e, colVHumility) ||
                currentCol(e, colVJustice) ||
                currentCol(e, colVSacrifice) ||
                currentCol(e, colVSpirituality) ||
                currentCol(e, colVValor) ||
                currentCol(e, colVTotal))
            {
                String[] p = ((string)e.Value).Split('_');
                e.Value = int.Parse(p[1]) + " (" + int.Parse(p[0]) + "%)";
            }

            if (currentCol(e,colPlayer) && (string)e.Value == "$")
            {
                e.Value = "";
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
                if (dgvPlayers.Columns.Contains(colPlayer) && currentCol(e,colPlayer))
                    OpenPlayerReport(dgvPlayers[e.ColumnIndex, e.RowIndex].Value.ToString());

                if (dgvPlayers.Columns.Contains(colAlliance) && currentCol(e,colAlliance))
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
                OpenReport(rep);
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
                OpenReport(rep);
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
        public delegate void ReportHandler(ReportInfo r);
        public void OpenReport(ReportInfo r)
        {
            if (InvokeRequired)
            {
                Invoke(new ReportHandler(OpenReport), r);
                return;
            }
            new ReportForm(r).Show();
        }

        private void FillRanking(ToolStripButton btn, RankingType type, params DataGridViewColumn[] cols)
        {
            if (oldBtn != btn)
            {
                oldBtn.BackColor = Color.White;
                oldBtn = btn;
                btn.BackColor = SystemColors.Highlight;
            }
            dgvPlayers.SuspendLayout();
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPlayers.Columns.Clear();
            for (int i = cols.Length - 1; i >= 0; --i)
                cols[i].DisplayIndex = i;
            dgvPlayers.Columns.AddRange(cols);
            dgvPlayers.Rows.Clear();
            List<object[]> objs = Session.World.Ranking(type);
            dgvPlayers.Rows.Add(objs.Count);
            String search1 = Session.MyPlayer.Name;
            String search2 = Session.World.Alliance(Session.AllianceID).Name;
            int row = -1;
            for( int i = 0; i < objs.Count; ++i)
            {
                dgvPlayers.Rows[i].SetValues(objs[i]);
                foreach (object s in objs[i])
                    if (s.ToString() == search1 || (row == -1 && s.ToString() == search2))
                        row = i;
            }
            if (row == -1)
                row = 0;
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.ResumeLayout();
            int selectRow = Math.Min(row + 10, dgvPlayers.Rows.Count - 1);
            dgvPlayers.CurrentCell = dgvPlayers.Rows[selectRow].Cells[0];
            dgvPlayers.CurrentCell = dgvPlayers.Rows[row].Cells[0];
            //dgvPlayers.Rows[row].Selected = true;
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
