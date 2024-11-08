using MyToDO.Common.Models;
using MyToDO.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MyToDO.ViewModels
{
    public class MainViewModel : BindableBase
    {

        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; } //导航命令 用于导航



        private readonly IRegionManager regionManager; //实现导航
        private IRegionNavigationJournal journal;  //日志
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();


            CreateMenuBar();


            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);

            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();//实现后退
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();//实现前进

            });
            this.regionManager = regionManager;
        }



        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Namespace)) //obj为空或没有命名空间则不导航
                return;

            regionManager.Regions[PrismManager.MainViewRegionName]/*寻找注册区域ContentControl*/.RequestNavigate(obj.Namespace,/*根据名称空间进行导航*/ back =>
            {
                journal = back.Context.NavigationService.Journal; //回调返回日志

            });
        }




        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars //动态属性集合
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }



        void CreateMenuBar() //创建菜单方法
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", Namespace = "IndexView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办", Namespace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "事项", Namespace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", Namespace = "SettingsView" });
        }
    }
}
