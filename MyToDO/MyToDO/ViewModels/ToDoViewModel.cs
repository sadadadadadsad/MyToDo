using MyToDO.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDO.ViewModels
{
   public class ToDoViewModel:BindableBase
    {
        public ToDoViewModel()
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            CreateToDoList();
            AddToDoCommand = new DelegateCommand(AddToDo);
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
        public DelegateCommand AddToDoCommand { get; private set; }

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }
        void CreateToDoList()
        {
            for (int i = 0; i < 20; i++)
            {
                ToDoDtos.Add(new ToDoDto()
                {
                    Title="标题"+i,
                    Content="测试数据"
                });
            }
        }
    }
}
