using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SocialNetwork.Interfases.Repository;
using SocialNetwork.Interfases.Manager;
using SocialNetwork.Interfases.Validator;
using SocialNetwork.Data.Repository;
using SocialNetwork.Core;
using SocialNetwork.BisinesLogic.Validators;
using SocialNetwork.BisinesLogic.Manager;




namespace SocialNetworc.CastleWindsor.Installers
{
    public class AdminInstaller : IWindsorInstaller
    {
        private const string WebAssemblyName = "SocialNetwork.WEB";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.Name)));

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<WindsorControllerFactory>());

            container.Register(Component.For<DataContext>().LifestyleSingleton());
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(ICommentsRepository<>)).ImplementedBy(typeof(CommentsRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IFriendsRepository<>)).ImplementedBy(typeof(FriendsRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IPhotoRepository<>)).ImplementedBy(typeof(PhotoRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IPostRepository<>)).ImplementedBy(typeof(PostRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IRolesRepository<>)).ImplementedBy(typeof(RolesRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IUserInRolesRepository<>)).ImplementedBy(typeof(UserInRolesRepository<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IUserRepository<>)).ImplementedBy(typeof(UserRepository<>)).LifestyleTransient());

            container.Register(Component.For(typeof(IValidator<Comments>)).ImplementedBy(typeof(CommentsValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<Friends>)).ImplementedBy(typeof(FriendsValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<Photo>)).ImplementedBy(typeof(PhotoValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<Post>)).ImplementedBy(typeof(PostValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<Roles>)).ImplementedBy(typeof(RolesValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<UserInRoles>)).ImplementedBy(typeof(UserInRolesValidator)).LifestyleTransient());
            container.Register(Component.For(typeof(IValidator<User>)).ImplementedBy(typeof(UserValidator)).LifestyleTransient());

            container.Register(Component.For(typeof(IManager<>)).ImplementedBy(typeof(Manager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(ICommentsManager<>)).ImplementedBy(typeof(CommentsManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IFriendsManager<>)).ImplementedBy(typeof(FriendsManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IPhotoManager<>)).ImplementedBy(typeof(PhotoManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IPostManager<>)).ImplementedBy(typeof(PostManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IRolesManager<>)).ImplementedBy(typeof(RolesManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IUserInRolesManager<>)).ImplementedBy(typeof(UserInRolesManager<>)).LifestyleTransient());
            container.Register(Component.For(typeof(IUserManager<>)).ImplementedBy(typeof(UserManager<>)).LifestyleTransient());


            
            /*container.Register(Component.For<DataContext>().LifestyleSingleton());
            
            container.Register(Component.For(typeof(IManager<>)).ImplementedBy(typeof(Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Core.Pharmacy>))
                    .ImplementedBy(typeof(PharmacyValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Medcine>))
                    .ImplementedBy(typeof(MedcineValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<MedcinePriceHistory>))
                    .ImplementedBy(typeof(MedcinePriceHistoryValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Order>))
                    .ImplementedBy(typeof(OrderValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<OrderDetails>))
                    .ImplementedBy(typeof(OrderDetailsValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Storage>))
                    .ImplementedBy(typeof(StorageValidator))
                    .LifestylePerWebRequest());

            container.Register(
                Component.For(typeof(StorageViewModelCreator))
                .LifestyleTransient());

            container.Register(
                Component.For(typeof(OrderViewModelCreator))
                .LifestyleTransient());

            container.Register(
                Component.For(typeof(OrderDetailsViewModelCreator))
                .LifestyleTransient());*/

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
