using School.Service.Core;
using System;

namespace StoreOnline.Service.Core
{
    public class DtoCategoryBase : DtoAudit
    {
        public DateTime? depositDate { get; set; }
    }
}
