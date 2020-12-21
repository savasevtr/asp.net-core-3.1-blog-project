using Microsoft.Extensions.Caching.Memory;
using SEProject.MyBlogProject.Business.Utilities.LogTool;

namespace SEProject.MyBlogProject.Business.Utilities.FacadeTools
{
    public interface IFacade
    {
        public IMemoryCache MemoryCache { get; set; }
        public ICustomLogger CustomLogger { get; set; }
    }
}