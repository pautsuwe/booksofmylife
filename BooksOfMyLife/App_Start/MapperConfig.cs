using AutoMapper;
using BooksOfMyLife.Entities;
using BooksOfMyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BooksOfMyLife.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //entity to model mappings
                cfg.CreateMap<BookModel, Book>()
                //.ForMember(dest => dest.Author, opt =>
                //opt.MapFrom(src => Mapper.Map<BookModel, Author>(src)))
            //    .ForMember(dest => dest.BookGenres,
            //               opt => opt.MapFrom(
            //                   src => new List<BookGenre>() {
            //                       src. r.Comments.Select(c => c.UserId ?? 0)));
            //src => new BookGenre
            //                    {
            //                        BookId = src.Id,
            //                        GenreId = src.Genres
            //                    }));
                //.ForMember(dest => dest.Comments,  opt => 
                //opt.MapFrom(src => Mapper.Map<BookModel, Comment>(src)))
                ;

                cfg.CreateMap<AuthorModel, Author>();


                //model to entity mappings
                cfg.CreateMap<Book, BookModel>();
                //.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres));
                cfg.CreateMap<Book, BookSimpleModel>();
                cfg.CreateMap<Author, AuthorModel>();
            });
        }
    }
}