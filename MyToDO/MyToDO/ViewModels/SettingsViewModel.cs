using MyToDO.Common.Models;
using MyToDO.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDO.ViewModels
{
   public class SettingsViewModel:BindableBase
    {

        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars=new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            CreateMenuBar();

        }
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        private readonly IRegionManager regionManager;
        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars //动态属性集合
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Namespace)) //obj为空或没有命名空间则不导航
                return;

            regionManager.Regions[PrismManager.SettingsViewRegionName]/*寻找注册区域ContentControl*/.RequestNavigate(obj.Namespace);/*根据名称空间进行导航*/
        }



        void CreateMenuBar() //创建菜单方法
        {
            MenuBars.Add(new MenuBar() { Icon = "Palette", Title = "个性化", Namespace = "SkinView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "系统设置", Namespace = "" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "关于更多", Namespace = "AboutView" });
        }
    }
}
