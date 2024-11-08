using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.api.Context;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System.Reflection.Metadata;
namespace MyToDo.api.Service
{
    /// <summary>
    /// 用IUnitOfWork实现接口 待办事项实现
    /// </summary>
    public class MemoService : IMemoService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper Mapper;


        public MemoService(IUnitOfWork work,IMapper mapper)
        {
            this.work = work;
            Mapper = mapper;
        }


        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                var dbToDo =  Mapper.Map<Memo>(model);//将ToDoDto映射为ToDo
                await work.GetRepository<Memo>().InsertAsync(dbToDo);
                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, model);
                }
                return new ApiResponse(false, "添加数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }

        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = work.GetRepository<Memo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id)); //查找id获得数据
                repository.Delete(todo); //删除
                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "");
                }
                return new ApiResponse(false, "删除数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }

        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var repository = work.GetRepository<Memo>();
                var todos = await repository.GetPagedListAsync(predicate: x =>
                string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Equals(parameter.Search),
                pageIndex: parameter.PageIndex,
                pageSize: parameter.PageSize,
                orderBy: source => source.OrderByDescending(t => t.CreatedDate));

                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = work.GetRepository<Memo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id)); //查找id获得数据
                return new ApiResponse(true, todo);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var dbToDo = Mapper.Map<Memo>(model);
                var repository = work.GetRepository<Memo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(dbToDo.Id)); //查找id获得数据
                todo.Title = dbToDo.Title; //更新标题
                todo.Content = dbToDo.Content;//更新内容
                todo.UpdateDate = DateTime.Now;//更新时间

                repository.Update(todo);
                if (await work.SaveChangesAsync() > 0) {

                    return new ApiResponse(true, todo);
                        }
                return new ApiResponse( "更新数据异常！");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
