namespace LibraryApp;

/// <summary>
/// Описывает книгу библиотечного каталога.
/// </summary>
public sealed class Book
{
    /// <summary>
    /// Уникальный идентификатор книги.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Название книги.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Автор книги.
    /// </summary>
    public required string Author { get; init; }

    /// <summary>
    /// Признак того, что книга доступна для выдачи.
    /// Изменять состояние может только класс <see cref="Library"/>.
    /// </summary>
    public bool IsAvailable { get; internal set; } = true;

    /// <inheritdoc />
    public override string ToString()
    {
        string state = IsAvailable ? "доступна" : "выдана";
        return $"Id: {Id}, \"{Title}\", {Author}, {state}";
    }
}
