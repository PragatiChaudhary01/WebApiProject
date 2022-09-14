using StoreList.Models;
using StoreList.Repository;

namespace StoreList.Servies
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public int Create(Store store)
        {
            if (store == null)
            {
                throw new System.ArgumentNullException(nameof(store));
            }
            if (string.IsNullOrWhiteSpace(store.Name))
            {
                throw new System.ArgumentException("Store name is required", nameof(store));
            }
            if (string.IsNullOrWhiteSpace(store.City))
            {
                throw new System.ArgumentException("Store city is required", nameof(store));
            }
            if (string.IsNullOrWhiteSpace(store.State))
            {
                throw new System.ArgumentException("Store state is required", nameof(store));
            }
            return _storeRepository.Create(store);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Store Id is Empty");
            if (_storeRepository.Get(id) == null)
                throw new ArgumentException("Store Id is not found");
            _storeRepository.Delete(id);

        }

        public Store Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Store Id is Empty");
            if (_storeRepository.Get(id) == null)
                throw new ArgumentException("Store Id is not found");
            return _storeRepository.Get(id);
        }

        public List<Store> GetAll()
        {
            return _storeRepository.GetAll();
        }

        public void Update(Store store)
        {
            if (store == null)
                throw new ArgumentNullException("store");
            if (string.IsNullOrEmpty(store.Name))
                throw new ArgumentException("Store Name is Empty");
            if (store.Id <= 0)
                throw new ArgumentException("Store Id is Empty");
            if (_storeRepository.Get(store.Id) == null)
                throw new ArgumentException("Store Id is not found");
            _storeRepository.Update(store);
        }
    }
}
