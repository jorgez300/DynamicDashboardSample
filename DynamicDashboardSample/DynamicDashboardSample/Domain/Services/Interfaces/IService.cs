namespace DynamicDashboardSample.Domain.Services.Interfaces
{
    public interface IService<T>
    {
        public List<T> GetList();
        public T GetValue(T input);
        public void Update(T input);
        public void Insert(T input);
        public void Delete(T input);
    }
}
