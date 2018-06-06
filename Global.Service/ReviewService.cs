using Framework.Component;
using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.Service
{
    public class ReviewService : BaseService, IReviewService
    {
        public IEnumerable<ReviewDto> GetReviews(int refId, bool isPublished = true)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReviewFacade facade = new ReviewFacade(uow);
                List<ReviewDto> result = facade.RetrieveReviewsByReference(refId, new ReviewConverter());
                return result.OrderByDescending(o => o.Id);
            }
        }

        public IFacadeUpdateResult<ReviewData> SaveReview(ReviewDto instance, int refId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReviewFacade facade = new ReviewFacade(uow);
                IFacadeUpdateResult<ReviewData> result = facade.SaveReview(ReviewConverter.ConvertToData(instance), refId);
                return result;
            }
        }
    }
}
