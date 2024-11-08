using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos
{
    public class BaseDto : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// 实现通知更新
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string properName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properName));     //调用通知绑定方法
        }
    }

}
