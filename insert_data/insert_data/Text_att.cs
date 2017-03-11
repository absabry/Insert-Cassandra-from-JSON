
namespace insert_data
{
    class Text_att
    {
        public string dateline;
        public string title;
        public string body;

        public override string ToString()
        {
            return "\tdateline:" + dateline + "\n" +
                   "\ttitle:" + title + "\n" +
                   "\tbody:" + body + "\n";
        }
    }
}
