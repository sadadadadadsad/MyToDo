using DryIoc;
using MyToDO.Service;
using MyToDO.ViewModels;
using MyToDO.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace MyToDO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {   //依赖容器注入

            containerRegistry.GetContainer()
                .Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUri")); //httprestclient设置默认值
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:36724/", serviceKey: "webUri");
            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();

            containerRegistry.RegisterForNavigation<IndexView,IndexViewModel>();
            containerRegistry.RegisterForNavigation<SkinView,SkinViewModel>();
            containerRegistry.RegisterForNavigation<MemoView,MemoViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView,ToDoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView,SettingsViewModel>();
            containerRegistry.RegisterForNavigation<AboutView>();
        }
    }
}
