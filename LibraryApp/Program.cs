using LibraryApp;

Library library = new();

library.AddBook(new Book { Id = 1, Title = "Война и мир", Author = "Л. Н. Толстой" });
library.AddBook(new Book { Id = 2, Title = "Преступление и наказание", Author = "Ф. М. Достоевский" });
library.AddBook(new Book { Id = 3, Title = "Мастер и Маргарита", Author = "М. А. Булгаков" });

Console.WriteLine();
Console.WriteLine("Каталог библиотеки:");
library.PrintCatalog();
Console.WriteLine();

RunScenario("Сценарий 1. Выдача книги с Id = 1", () => library.BorrowBook(1));
RunScenario("Сценарий 2. Повторная выдача книги с Id = 1", () => library.BorrowBook(1));
RunScenario("Сценарий 3. Возврат книги с Id = 2, которую не выдавали", () => library.ReturnBook(2));
RunScenario("Сценарий 4. Выдача книги с Id = 99, которой нет в каталоге", () => library.BorrowBook(99));
RunScenario("Сценарий 5. Возврат книги с Id = 1", () => library.ReturnBook(1));
RunScenario("Сценарий 6. Повторный возврат книги с Id = 1", () => library.ReturnBook(1));

Console.WriteLine("Каталог после операций:");
library.PrintCatalog();

static void RunScenario(string title, Action scenario)
{
    Console.WriteLine($"--- {title} ---");
    scenario();
    Console.WriteLine();
}
