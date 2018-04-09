using BooksOfMyLife.DAL;
using BooksOfMyLife.Managers;
using System;

using Unity;
using Unity.AspNet.Mvc;

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
            // TODO: Register your type's mappings here.
            container.RegisterType<IBookManager, BookManager>();
        }
    }
}