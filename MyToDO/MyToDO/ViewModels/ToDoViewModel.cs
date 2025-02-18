using MyToDo.Shared.Dtos;
using MyToDO.Service;
using Prism.Commands;
using Prism.Ioc;
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
   public class ToDoViewModel: NavigationViewModel
    {
        public ToDoViewModel(IToDoService service,IContainerProvider containerProvider)
            :base(containerProvider)
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            AddToDoCommand = new DelegateCommand(AddToDo);
            this.service = service;

        }
        private bool isRightDrawerOpen;
        /// <summary>
        /// 添加待办的右侧窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 添加待办事项的方法
        /// </summary>
        private void AddToDo()
        {
            IsRightDrawerOpen=true;
        }

        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly IToDoService service;

        public DelegateCommand AddToDoCommand { get; private set; }

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
       async void GetDataAsync()
        {
            UpdateLoading(true);
         var todoResult=  await service.GetAllAsync(new MyToDo.Shared.Parameters.QueryParameter() 
            {
                PageIndex = 0,
                PageSize = 100,
            }
            );
            if (todoResult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }
            UpdateLoading(false);

        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataAsync();
        }
    }
}
