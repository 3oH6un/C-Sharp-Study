namespace StartC_Sharp10.page_4;

public class Program
{
    public void _Main(string[] args)
    {
        Book bananaMan = new Book(
            "바나나맨의 모험",
            1234123412341m,
            "바나나맨은 모험을 떠났다.",
            "바나나맨",
            1
        );

        bananaMan.Open();
        bananaMan.Close();
        Console.WriteLine(bananaMan.Close2());

        Console.WriteLine(bananaMan.Title);
        Console.WriteLine(bananaMan.ISBN13);
        Console.WriteLine(bananaMan.Contents);
        Console.WriteLine(bananaMan.Author);

        Book gulliver = new Book(
            "걸리버 여행기",
            97889838920775m,
            "...",
            "Jonathan Swift",
            384
        );
    }
}

public class Book
{
    public string Title { get; set; }
    public decimal ISBN13 { get; set; }
    public string Contents { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }

    public void Open()
    {
        Console.WriteLine(this.Title + " 책을 펼쳤습니다.");
    }

    public void Close()
    {
        Console.WriteLine(this.Title + "책을 닫았습니다.");
        return;
    }

    public void Close(string qwer)
    {
        Console.WriteLine(this.Title + "책을 닫았습니다.");
        return;
    }

    public string Close2()
    {
        return this.Title + "책을 닫았습니다.";
    }

    public Book(string title, decimal isbn13, string contents, string author, int pageCount)
    {
        ISBN13 = isbn13;
        PageCount = pageCount;
        Author = author;
        Contents = contents;
        Title = title;
    }
}