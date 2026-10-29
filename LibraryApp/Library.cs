namespace LibraryApp;

/// <summary>
/// Каталог книг и операции выдачи и возврата.
/// </summary>
public sealed class Library
{
    private readonly List<Book> _books = [];

    /// <summary>
    /// Добавляет книгу в каталог.
    /// </summary>
    /// <param name="book">Книга для добавления.</param>
    /// <exception cref="ArgumentNullException">Параметр <paramref name="book"/> равен <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Книга с таким же <see cref="Book.Id"/> уже есть в каталоге.</exception>
    public void AddBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);

        if (FindBook(book.Id) is not null)
        {
            throw new InvalidOperationException($"Книга с Id = {book.Id} уже есть в каталоге.");
        }

        _books.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" добавлена в каталог.");
    }

    /// <summary>
    /// Ищет книгу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <returns>Найденная книга или <see langword="null"/>, если книги с таким идентификатором нет.</returns>
    public Book? FindBook(int id) => _books.FirstOrDefault(book => book.Id == id);

    /// <summary>
    /// Выдаёт книгу читателю, если она есть в каталоге и ещё не выдана.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    public void BorrowBook(int id)
    {
        Book? book = FindBook(id);
        if (book is null)
        {
            Console.WriteLine($"Ошибка: книга с Id = {id} не найдена в каталоге.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine($"Ошибка: книга \"{book.Title}\" уже выдана читателю.");
            return;
        }

        book.IsAvailable = false;
        Console.WriteLine($"Книга \"{book.Title}\" выдана читателю.");
    }

    /// <summary>
    /// Возвращает книгу в библиотеку, если она была выдана.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    public void ReturnBook(int id)
    {
        Book? book = FindBook(id);
        if (book is null)
        {
            Console.WriteLine($"Ошибка: книга с Id = {id} не найдена в каталоге.");
            return;
        }

        if (book.IsAvailable)
        {
            Console.WriteLine($"Ошибка: книга \"{book.Title}\" не была выдана, возврат невозможен.");
            return;
        }

        book.IsAvailable = true;
        Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
    }

    /// <summary>
    /// Выводит в консоль все книги каталога.
    /// </summary>
    public void PrintCatalog()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("Каталог пуст.");
            return;
        }

        foreach (Book book in _books)
        {
            Console.WriteLine(book);
        }
    }
}
