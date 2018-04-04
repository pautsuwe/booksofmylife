using BooksOfMyLife.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookContext")
        {
        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ReadingActivity> ReadingActivities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<CommentReaction> CommentReactions{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<BooksOfMyLife.Models.BookModel> BookModels { get; set; }
    }
}