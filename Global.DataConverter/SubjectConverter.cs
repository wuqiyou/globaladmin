using System.Collections.Generic;
using System.Linq;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class SubjectConverter : IDataConverter<SubjectData, SubjectDto>
    {
        public IEnumerable<SubjectDto> Convert(IEnumerable<SubjectData> entitys)
        {
            List<SubjectDto> dtoList = new List<SubjectDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubjectDto Convert(SubjectData entity)
        {
            SubjectDto dto = new SubjectDto();

            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.SubjectType = entity.SubjectType;
            dto.SubjectLabel = string.IsNullOrEmpty(entity.SubjectLabel) ? entity.SubjectType : entity.SubjectLabel;
            dto.SubjectIdField = entity.SubjectIdField;
            dto.MasterSubjectIdField = entity.MasterSubjectIdField;
            dto.ManageUrl = entity.ManageUrl;
            dto.EditUrl = entity.EditUrl;
            dto.ListUrl = entity.ListUrl;
            dto.ImportUrl = entity.ImportUrl;
            dto.AllowListImport = entity.AllowListImport;
            dto.AllowListFiltering = entity.AllowListFiltering;
            dto.AllowListAdd = entity.AllowListAdd;
            dto.AllowListEdit = entity.AllowListEdit;
            dto.AllowListDelete = entity.AllowListDelete;
            dto.IsAddInGrid = entity.IsAddInGrid;
            dto.IsGridInFormEdit = entity.IsGridInFormEdit;

            dto.SubjectFields = new SubjectFieldConverter().Convert(entity.SubjectFieldsData.OrderBy(o => o.Sort));

            return dto;
        }

        public static SubjectData ConvertToData(SubjectDto entity)
        {
            SubjectData result = new SubjectData();

            result.Id = entity.Id;

            return result;
        }
    }
}
