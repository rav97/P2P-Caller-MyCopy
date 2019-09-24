public class Contact
    {
        public string contactName;
        public string IPAddress;

        public Contact(string name, string IP)
        {
            this.contactName = name;
            this.IPAddress = IP;
        }

        public void ChangeName(string newName)
        {
            this.contactName = newName;
        }
        public void ChangeIP(string newIP)
        {
            this.IPAddress = newIP;
        }
    public override string ToString()
    {
        return this.contactName + "(" + this.IPAddress + ")";
    }
}
