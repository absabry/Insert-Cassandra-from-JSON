

namespace insert_data
{
    class Reuters_Item
    {
        public string date;
        public string places;
        public string companies;
        public string topics;
        public string exchanges;
        public int _id;
        public string orgs;
        public Text_att text;
        public string people;

        public override string ToString()
        {
            return
                "date:" + date + "\n"
                + "places:" + places + "\n"
                + "companies:" + companies + "\n"
                + "topics:" + topics + "\n"
                + "exchanges:" + exchanges + "\n"
                + "_id:" + _id + "\n"
                + "orgs:" + orgs + "\n"
                + "text:" + text.ToString() + "\n"
                + "people:" + people + "\n\n\n";
        }
    }
}
