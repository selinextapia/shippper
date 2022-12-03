using Microsoft.EntityFrameworkCore;
using StoreOnline.DAL.Context;

namespace StoreOnline.DAL.Core
{
    public interface IDbFactory
    {
        DbContext GetDbContext { get; }
    }
}
