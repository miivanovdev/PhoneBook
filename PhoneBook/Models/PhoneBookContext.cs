using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new List<Contact>()
                {
                    new Contact() { Id = 1, Name = "Виталий", Surname = "Попов", SecondName = "Марисович", PhoneNumber = "333222", Address = "ул.Домашняя 5, кв 10", Description = "Адмирал" },
                    new Contact() { Id = 2, Name = "Степан", Surname = "Горохов", SecondName = "Юрьевич", PhoneNumber = "111777", Address = "ул.Тульская 17, кв 102", Description = "Сталевар" },
                    new Contact() { Id = 3, Name = "Надежда", Surname = "Ипатьева", SecondName = "Александровна", PhoneNumber = "555666", Address = "пр.Мариинский 32, кв 6", Description = "Балерина" },
                    new Contact() { Id = 4, Name = "Юрий", Surname = "Новиков", SecondName = "Павлович", PhoneNumber = "999345", Address = "ул.Кротовая 17, кв 15", Description = "Землекоп" },
                    new Contact() { Id = 5, Name = "Александр", Surname = "Песьяков", SecondName = "Романович", PhoneNumber = "322228", Address = "пр.Ленина 82, кв 27", Description = "Египтолог" },
                    new Contact() { Id = 6, Name = "Татьяна", Surname = "Шаляпина", SecondName = "Владимировна", PhoneNumber = "901902", Address = "ул.Котовская 4, кв 21", Description = "Повар" },
                    new Contact() { Id = 7, Name = "Борис", Surname = "Кузнецов", SecondName = "Дмитриевич", PhoneNumber = "678876", Address = "ул.Малая Набережная 67, кв 33", Description = "Рыбак" },
                    new Contact() { Id = 8, Name = "Анна", Surname = "Кудряшова", SecondName = "Владимировна", PhoneNumber = "345678", Address = "пр.Советов 77, кв 158", Description = "Судья" },
                    new Contact() { Id = 9, Name = "Александр", Surname = "Петров", SecondName = "Александрович", PhoneNumber = "807451", Address = "пер.Лебяжий 99, кв 12", Description = "Моряк" },
                    new Contact() { Id = 10, Name = "Валерий", Surname = "Арзамасцев", SecondName = "Вячеславович", PhoneNumber = "999050", Address = "ул.Строителей 39, кв 71", Description = "Бухгалтер" }
                });
        }
    }
}
