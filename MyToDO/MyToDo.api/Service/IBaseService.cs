using MyToDo.Shared.Parameters;

namespace MyToDo.api.Service
{ 
    /// <summary>
    /// 封装的接口具有增删改查功能
    /// </summary>
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameter query);

        Task<ApiResponse> GetSingleAsync(int id);
        Task<ApiResponse> AddAsync(T model);
        Task<ApiResponse> UpdateAsync(T model); //实体
        Task<ApiResponse> DeleteAsync(int id);
    }
}
