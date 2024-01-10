using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Contracts
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
       //هون اذا بدنا نرجعها مع ال gategory
        Task<IReadOnlyList<Post>> GetAllPostAsync(bool includeCategory);
        Task<Post> GetPostByIdAsync(Guid postId, bool includeCategory);
    }
}
