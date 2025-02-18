
using MyToDo.Shared.Dtos;
using MyToDO.Common.Models;
using MyToDO.Service;
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

        public MemoViewModel(IMemoService service)
        {
            this.service = service;
            memoDtos = new ObservableCollection<MemoDto>();
            AddMemoCommand = new DelegateCommand(AddMemo);
            CreateMemoList();
        }

        private void AddMemo()
        {
            IsRightDrawerOpen = true;
        }
        private bool isRightDrawerOpen;
        private readonly IMemoService service;

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
        async void CreateMemoList()
        {
          var memoResult =await service.GetAllAsync(new MyToDo.Shared.Parameters.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100,
            });
            if(memoResult.Status)
                foreach (var item in memoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
        }

    }
}
