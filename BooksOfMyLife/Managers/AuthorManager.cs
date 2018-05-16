using AutoMapper;
using BooksOfMyLife.DAL;
using BooksOfMyLife.Entities;
using BooksOfMyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksOfMyLife.Managers
{
    public interface IAuthorManager
    {
        int AddNewAuthor(AuthorModel model);
        void UpdateAuthor(AuthorModel model);
        AuthorModel GetAuthor(int id);
        List<AuthorModel> GetAllAuthors();
    }

    public class AuthorManager : IAuthorManager
    {
        private BookContext _bookContext { get; set; }
        public AuthorManager()
        {
            _bookContext = new BookContext();
        }

        public int AddNewAuthor(AuthorModel model)
        {
            var authorEntity = Mapper.Map<AuthorModel, Author>(model);
            var addedEntity = _bookContext.Authors.Add(authorEntity);
            _bookContext.SaveChanges();

            return addedEntity.Id;
        }

        public void UpdateAuthor(AuthorModel model)
        {
            var authorEntity = Mapper.Map<AuthorModel, Author>(model);
            var updatable = _bookContext.Authors.Find(model.Id);
            _bookContext.Entry(updatable).CurrentValues.SetValues(authorEntity);
            _bookContext.SaveChanges();            
        }

        public AuthorModel GetAuthor(int id)
        {
            var authorEntity = _bookContext.Authors.Find(id);
            var model = Mapper.Map<Author, AuthorModel>(authorEntity);
            return model;
        }

        public List<AuthorModel> GetAllAuthors()
        {
            List<AuthorModel> models = new List<AuthorModel>();
            foreach (var author in _bookContext.Authors)
            {
                var model = Mapper.Map<Author, AuthorModel>(author);
                models.Add(model);
            }
            return models;
        }
    }
}