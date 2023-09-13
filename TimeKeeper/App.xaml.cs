using Microsoft.EntityFrameworkCore.Infrastructure;
using Prism.Ioc;
using System.Windows;
using TimeKeeper.DataContext;
using TimeKeeper.Services;
using TimeKeeper.Views;

namespace TimeKeeper
{

    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Login>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatabaseFacade facade = new DatabaseFacade(new AppDbContext());
            facade.EnsureCreated();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<DataServices>();
/*            containerRegistry.Register<IWindowService, WindowService>();*/
        }
    }
}
