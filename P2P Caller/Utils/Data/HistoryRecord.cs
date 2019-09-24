using System;

class HistoryRecord
    {
        public string MyInfo;
        public string Direct;
        public string CallerInfo;
        public DateTime Date;
        public string Time;
        public string Status;

        public HistoryRecord(string myinf, string dir, string calinf, DateTime dt, string ts, string st)
        {
            this.MyInfo = myinf;
            this.Direct = dir;
            this.CallerInfo = calinf;
            this.Date = dt;
            this.Time = ts;
            this.Status = st;
        }

    public override string ToString()
    {
        return (this.MyInfo + " " + this.Direct + " " + this.CallerInfo + " " + this.Date);
    }

}

