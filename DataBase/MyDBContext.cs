using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ToDoXamarin.Models;

namespace ToDoXamarin.DataBase
{
    public class MyDBContext : DbContext
    {
        public DbSet<TarefaModel> Tarefas { get; set; } 

        //private string BasePath { get; set; }

        public MyDBContext() 
        {
            
        }

        //public MyDBContext(string pBasePath) {
        //    this.BasePath = pBasePath;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Filename={PathDB()}");

        /// <summary>
        /// https://devblogs.microsoft.com/xamarin/building-android-apps-entity-framework/
        /// </summary>
        public async void CreateDataBaseEF() => await Database.EnsureCreatedAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaModel>()
                .Property(b => b.Id)
                .HasColumnType("TEXT")
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<TarefaModel>()
                .Property(b => b.Descricao)
                .HasColumnType("TEXT");
            modelBuilder.Entity<TarefaModel>()
                .Property(b => b.Concluida)
                .HasColumnType("INTEGER");

            base.OnModelCreating(modelBuilder);
        }


        private string PathDB()
        {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "teste.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            Console.WriteLine(dbFullPath);
            return dbFullPath;
        }


    }
}
