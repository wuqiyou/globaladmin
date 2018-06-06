using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class SubjectFieldConverter : IDataConverter<SubjectFieldData, SubjectFieldDto>
    {
        public IEnumerable<SubjectFieldDto> Convert(IEnumerable<SubjectFieldData> entitys)
        {
            List<SubjectFieldDto> dtoList = new List<SubjectFieldDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubjectFieldDto Convert(SubjectFieldData entity)
        {
            SubjectFieldDto dto = new SubjectFieldDto();

            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.FieldLabel;
            dto.FieldKey = entity.FieldKey;
            dto.FieldLabel = entity.FieldLabel;
            dto.HelpText = entity.HelpText;
            dto.FieldDataType = entity.FieldDataType;
            dto.PickupEntityId = entity.PickupEntityId != null ? System.Convert.ToInt32(entity.PickupEntityId) : default(int?);
            dto.LookupSubjectId = entity.LookupSubjectId != null ? System.Convert.ToInt32(entity.LookupSubjectId) : default(int?);
            dto.IsRequired = entity.IsRequired;
            dto.IsLinkInGrid = entity.IsLinkInGrid;
            dto.IsReadonly = entity.IsReadonly;
            dto.IsShowInGrid = entity.IsShowInGrid;
            dto.Sort = entity.Sort;
            dto.RowIndex = entity.RowIndex;
            dto.ColIndex = entity.ColIndex;
            dto.MaxLength = entity.MaxLength;
            dto.NavigateUrlFormatString = entity.NavigateUrlFormatString;

            return dto;
        }
    }
}
