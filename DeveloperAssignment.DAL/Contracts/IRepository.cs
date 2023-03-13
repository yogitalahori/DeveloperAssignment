namespace DeveloperAssignment.DAL.Contracts
{
    public interface IRepository<T>
    {
        public void Create(T _object);
        public void Delete(int Id);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);
    }
}
