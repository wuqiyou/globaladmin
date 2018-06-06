using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class ReviewConverter : IDataConverter<ReviewData, ReviewDto>
    {
        public IEnumerable<ReviewDto> Convert(IEnumerable<ReviewData> entitys)
        {
            List<ReviewDto> dtoList = new List<ReviewDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ReviewDto Convert(ReviewData entity)
        {
            ReviewDto result = new ReviewDto();

            result.Id = entity.Id;
            result.ReferenceId = entity.ReferenceId;
            result.Title = entity.Title;
            result.Content = entity.Content;
            result.IssuedBy = entity.IssuedBy;
            result.IssuedByEmail = entity.IssuedByEmail;
            result.IssuedTime = entity.IssuedTime;
            result.IsPublished = entity.IsPublished;

            return result;
        }

        public static ReviewData ConvertToData(ReviewDto entity)
        {
            ReviewData result = new ReviewData();

            result.Id = entity.Id;
            result.ReferenceId = entity.ReferenceId;
            result.Title = entity.Title;
            result.Content = entity.Content;
            result.IssuedBy = entity.IssuedBy;
            result.IssuedByEmail = entity.IssuedByEmail;
            result.IssuedTime = entity.IssuedTime;
            result.IsPublished = entity.IsPublished;

            return result;
        }
    }
}
