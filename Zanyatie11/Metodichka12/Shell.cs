using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka12
{
    class Shell<Book>
    {
        private Book[] books;
        private int size;
        public int Size { get => size; }
        public Shell()
        {
            books = new Book[] { };
            size = 0;
        }

        public Shell(params Book[] data)
        {
            this.books = data;
            size += data.Length;
        }
        public void Add(Book book)
        {
            Book[] newData = new Book[Size + 1];
            books.CopyTo(newData, 0);
            newData[size] = book;
            size++;
            books = new Book[size];
            newData.CopyTo(books, 0);
        }
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < Size)
                {
                    return books[index];
                }
                else
                {
                    throw new Exception("No such index");
                }
            }
            set
            {
                if (index >= 0 && index < Size && value is Book)
                {
                    books[index] = value;
                }
                else
                {
                    throw new Exception("No such index");
                }
            }
        }
        public delegate void SortingType();

        public static SortingType byName = SortingByName;
        public static SortingType byAuthor = SortingByAuthor;
        public static SortingType byPublisher = SortingByPiblisher;
        private static void SortingByName()
        {
            Console.WriteLine("Сортировка по имени");
        }

        private static void SortingByAuthor()
        {
            Console.WriteLine("Сортировка по автору");
        }

        private static void SortingByPiblisher()
        {
            Console.WriteLine("Сортировка по издательству");
        }
        public void Sort(SortingType sort)
        {
            sort();
        }

    }
}
