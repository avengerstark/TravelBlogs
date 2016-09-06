using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.BLL.Services
{
    public class TravelBlogsService : ITravelBlogsService
    {
        private IUnitOfWork _unitOfWork;
        private CommentService _commentService;
        private LocationService _locationService;
        private PostService _postService;
        private UserService _userServica;

        public TravelBlogsService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }




        public ICommentService Comments
        {
            get { throw new NotImplementedException(); }
        }

        public ILocationService Locations
        {
            get
            {
                if (_locationService == null)
                    _locationService = new LocationService(_unitOfWork);
                return _locationService;
            }
        }

        public IPostService Posts
        {
            get { throw new NotImplementedException(); }
        }

        public IUserService Users
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
