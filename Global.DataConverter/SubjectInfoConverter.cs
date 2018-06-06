using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Linq;

namespace Global.DataConverter
{
    public sealed class SubjectInfoConverter : IDataConverter<SubjectInfoData, SubjectInfoDto>
    {
        public SubjectInfoConverter()
        {
        }

        public IEnumerable<SubjectInfoDto> Convert(IEnumerable<SubjectInfoData> entitys)
        {
            List<SubjectInfoDto> dtoList = new List<SubjectInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubjectInfoDto Convert(SubjectInfoData entity)
        {
            SubjectInfoDto dto = new SubjectInfoDto();

            dto.ReferenceId = System.Convert.ToInt32(entity.Id);
            dto.UrlAlias = entity.UrlAlias;
            dto.Title = entity.Title;
            dto.Description = entity.Description;
            dto.ImageUrl = entity.ImageUrl;
            dto.MasterSubjectId = System.Convert.ToInt32(entity.MasterSubjectId);
            dto.MasterSubjectTitle = entity.MasterSubjectTitle;
            dto.MasterSubjectUrlAlias = entity.MasterSubjectUrlAlias;
            dto.TotalCount = entity.TotalCount;

            return dto;
        }
    }
}
