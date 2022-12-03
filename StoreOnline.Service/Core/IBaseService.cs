namespace StoreOnline.Service.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
    }
}
