namespace Tips_Machine
{
    public class Book //huvudklass för Bok
    {
        public string Title { get; set; } //initierar egenskaper
        public string Author { get; set; } 
        public string Type { get; set; }
        public string Exists { get; set; }

        public Book(string title, string author, string type, string exists) //konstruktor
        {
            Title = title;
            Author = author;
            Type = type;
            Exists = exists;
        }
    }
}
