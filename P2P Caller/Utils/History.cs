using System;
using System.Collections.Generic;
using System.Linq;

class History
    {
        public List<HistoryRecord> history;

        public History()
        {
            this.history = new List<HistoryRecord>();
        }
        public History(IList<HistoryRecord> his)
        {
            this.history = his.ToList<HistoryRecord>();
        }
        public void AddRecord(HistoryRecord c)
        {
            this.history.Add(c);
        }
        public void DeleteContact(HistoryRecord c)
        {
            this.history.Remove(c);
        }
        public void PrintAllContacts()
        {
            foreach (HistoryRecord c in this.history)
            {
                Console.WriteLine("{0} {1} {2}\t{3}\t{4}\t{5}", c.MyInfo, c.Direct, c.CallerInfo, c.Date, c.Time, c.Status);
            }
        }
        public void LoadAllRecords(System.Windows.Forms.ListBox listBox) 
        {
        foreach (HistoryRecord c in this.history)
        {
            listBox.Items.Add(c.ToString());
        }
        }

}

