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
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.SelectedGenreId))
                //.ForMember(dest => dest.Comments,  opt => 
                //opt.MapFrom(src => Mapper.Map<BookModel, Comment>(src)))
                ;

                //model to entity mappings
                cfg.CreateMap<Book, BookModel>()
                .ForMember(dest => dest.SelectedGenreId, opt => opt.MapFrom(src => src.GenreId));
            });
        }
    }
}