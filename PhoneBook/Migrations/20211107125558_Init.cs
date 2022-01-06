using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Description", "Name", "PhoneNumber", "SecondName", "Surname" },
                values: new object[,]
                {
                    { 1, "ул.Домашняя 5, кв 10", "Адмирал", "Виталий", "333222", "Марисович", "Попов" },
                    { 2, "ул.Тульская 17, кв 102", "Сталевар", "Степан", "111777", "Юрьевич", "Горохов" },
                    { 3, "пр.Мариинский 32, кв 6", "Балерина", "Надежда", "555666", "Александровна", "Ипатьева" },
                    { 4, "ул.Кротовая 17, кв 15", "Землекоп", "Юрий", "999345", "Павлович", "Новиков" },
                    { 5, "пр.Ленина 82, кв 27", "Египтолог", "Александр", "322228", "Романович", "Песьяков" },
                    { 6, "ул.Котовская 4, кв 21", "Повар", "Татьяна", "901902", "Владимировна", "Шаляпина" },
                    { 7, "ул.Малая Набережная 67, кв 33", "Рыбак", "Борис", "678876", "Дмитриевич", "Кузнецов" },
                    { 8, "пр.Советов 77, кв 158", "Судья", "Анна", "345678", "Владимировна", "Кудряшова" },
                    { 9, "пер.Лебяжий 99, кв 12", "Моряк", "Александр", "807451", "Александрович", "Петров" },
                    { 10, "ул.Строителей 39, кв 71", "Бухгалтер", "Валерий", "999050", "Вячеславович", "Арзамасцев" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
