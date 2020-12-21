using Microsoft.Extensions.Caching.Memory;
using SEProject.MyBlogProject.Business.Utilities.LogTool;

namespace SEProject.MyBlogProject.Business.Utilities.FacadeTools
{
    public class Facade : IFacade
    {
        public IMemoryCache MemoryCache { get; set; }
        public ICustomLogger CustomLogger { get; set; }

        public Facade(IMemoryCache memoryCache, ICustomLogger customLogger)
        {
            MemoryCache = memoryCache;
            CustomLogger = customLogger;
        }
    }
}