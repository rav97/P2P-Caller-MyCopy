using System;
using System.IO;
using System.Windows.Forms;

namespace P2P_Caller
{
    partial class HistoryWindow : Form
    {
        private ListViewItem item;

        public HistoryWindow()
        {
            InitializeComponent();

            listViewHistory.View = View.Details;
            listViewHistory.Columns.Add("User 1", -2, HorizontalAlignment.Left);
            listViewHistory.Columns.Add("", -2, HorizontalAlignment.Left);
            listViewHistory.Columns.Add("User 2", -2, HorizontalAlignment.Left);
            listViewHistory.Columns.Add("Date", -2, HorizontalAlignment.Left);
            listViewHistory.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listViewHistory.Columns.Add("Status", -2, HorizontalAlignment.Left);

            LoadListView();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Global.SaveHistory();
            this.Close();
        }

        private void LoadListView()
        {
            listViewHistory.Items.Clear();
            foreach (HistoryRecord h in Global.History)
            {
                item = new ListViewItem(h.MyInfo);
                item.SubItems.Add(h.Direct);
                item.SubItems.Add(h.CallerInfo);
                item.SubItems.Add(h.Date.ToString());
                item.SubItems.Add(h.Time);
                item.SubItems.Add(h.Status);
                listViewHistory.Items.Add(item);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Global.ClearHistory();
            Global.SaveHistory();
            LoadListView();
        }
    }
}
