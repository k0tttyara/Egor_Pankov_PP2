namespace LibraryApp
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book FindBook(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void BorrowBook(int id)
        {
            Book book = FindBook(id);
            book.IsAvailable = false;
            Console.WriteLine($"Книга \"{book.Title}\" выдана читателю.");
        }

        public void ReturnBook(int id)
        {
            Book book = FindBook(id);
            book.IsAvailable = true;
            Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
        }

        public void PrintCatalog()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
