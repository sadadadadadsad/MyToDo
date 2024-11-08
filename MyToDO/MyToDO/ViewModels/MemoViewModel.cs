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
    public class MemoViewModel : BindableBase
    {
        public DelegateCommand AddMemoCommand { get; private set; }
        private ObservableCollection<MemoDto> memoDtos;

        public MemoViewModel()
        {
            memoDtos = new ObservableCollection<MemoDto>();
            AddMemoCommand = new DelegateCommand(AddMemo);
            CreateMemoList();
        }

        private void AddMemo()
        {
            IsRightDrawerOpen = true;
        }
        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value;RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        void CreateMemoList()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto()
                {
                    Title = "标题" + i,
                    Content = "测试数据"
                });
            }
        }

    }
}
