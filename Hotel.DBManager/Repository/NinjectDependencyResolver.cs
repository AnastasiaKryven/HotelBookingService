using Hotel.Domain.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotel.DBManager.Repository
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
            kernel.Bind<IBookingRepository>().To<BookingRepository>();
            kernel.Bind<IRoomRepository>().To<RoomRepository>();
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();                       
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
