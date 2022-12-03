
using School.Service.Core;
using System;

namespace StoreOnline.Service.Core
{
    public class DtoOrderBase : DtoAudit
    {
        public DateTime? depositDate { get; set; }
    }
}
