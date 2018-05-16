using BooksOfMyLife.Controllers;
using BooksOfMyLife.DAL;
using BooksOfMyLife.Managers;
using BooksOfMyLife.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace BooksOfMyLife
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
        
        public static IUnityContainer Container => container.Value;
        #endregion

        
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IdentityDbContext<ApplicationUser>, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, BookContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IBookManager, BookManager>();
            container.RegisterType<IAuthorManager, AuthorManager>();

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>> ();
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}