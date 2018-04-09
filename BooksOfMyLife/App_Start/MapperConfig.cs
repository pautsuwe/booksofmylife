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
                cfg.CreateMap<BookModel, Book>()
                //.ForMember(dest => dest.Author, opt =>
                //opt.MapFrom(src => Mapper.Map<BookModel, Author>(src)))
                //.ForMember(dest => dest.Genre, opt =>
                //opt.MapFrom(src => Mapper.Map<BookModel, Genre>(src)))
                //.ForMember(dest => dest.Comments,  opt => 
                //opt.MapFrom(src => Mapper.Map<BookModel, Comment>(src)))
                ;
            });
        }
    }
}