using Microsoft.EntityFrameworkCore;

namespace MyToDo.api.Context
{
    public class MyToDoContext:DbContext
    {
        public MyToDoContext( DbContextOptions<MyToDoContext> options):base(options) //可在StartUp生成迁移文件进行外部构造
        {
            
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Memo> Memo { get; set; }
    } 
}
