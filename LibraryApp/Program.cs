using LibraryApp;

Library library = new Library();

library.AddBook(new Book { Id = 1, Title = "Война и мир", Author = "Л. Н. Толстой" });
library.AddBook(new Book { Id = 2, Title = "Преступление и наказание", Author = "Ф. М. Достоевский" });
library.AddBook(new Book { Id = 3, Title = "Мастер и Маргарита", Author = "М. А. Булгаков" });

Console.WriteLine("Каталог библиотеки:");
library.PrintCatalog();

Console.WriteLine();
Console.WriteLine("Сценарий 1. Выдача книги с Id = 1");
library.BorrowBook(1);

Console.WriteLine();
Console.WriteLine("Сценарий 2. Повторная выдача книги с Id = 1");
library.BorrowBook(1);

Console.WriteLine();
Console.WriteLine("Сценарий 3. Возврат книги с Id = 2, которую не выдавали");
library.ReturnBook(2);

Console.WriteLine();
Console.WriteLine("Сценарий 4. Выдача книги с Id = 99, которой нет в каталоге");
library.BorrowBook(99);

Console.WriteLine();
Console.WriteLine("Каталог после операций:");
library.PrintCatalog();
