using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDO.Common.Events
{
    public class UpdateModel
    {
        public bool IsOpen { get; set; }

        internal class UpdateLoadingEvent : PubSubEvent<UpdateModel>
        {
        }
    }
}

