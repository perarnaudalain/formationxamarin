using System;
using Autofac;
using deezerapp.ServiceLayer.Playlist;

namespace deezerapp.Util
{
    public class ServiceLocator
    {
        public static ServiceLocator instance;

        private IContainer container;

        private static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceLocator();
                return instance;
            }
        }

        private ServiceLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<PlaylistService>().As<PlaylistService>();
            container = builder.Build();
        }

        public static T GetService<T>() {
            return Instance.container.Resolve<T>();
        }
    }
}
