using StoreList.Models;

namespace StoreList.Repository
{
    public interface IStoreRepository
    {
        public int Create( Store store );
        public void Update(Store store);
        public void Delete(int id);
        public Store Get(int id);
        public List<Store> GetAll();

    }
}
