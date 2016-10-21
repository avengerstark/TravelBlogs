using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;

namespace TravelBlogs.BLL.Services
{
    public class TravelBlogsService : ITravelBlogsService
    {
        private readonly IUnitOfWork _unitOfWork;
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
            get 
            {
                if (_commentService == null)
                    _commentService = new CommentService(_unitOfWork);
                return _commentService;
            }
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
            get
            {
                if (_postService == null)
                    _postService = new PostService(_unitOfWork);
                return _postService;
            }
        }

        public IUserService Users
        {
            get 
            {
                if (_userServica == null)
                    _userServica = new UserService(_unitOfWork);
                return _userServica;
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


        public void SaveChanges()
        {
            _unitOfWork.SaveAsync();
        }
    }
}
