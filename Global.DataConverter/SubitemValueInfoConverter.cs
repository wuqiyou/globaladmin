using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.DataConverter
{
    public sealed class SubitemValueInfoConverter : IDataConverter<SubitemValueInfoData, DucValueDto>
    {
        public object LanguageId { get; set; }

        public SubitemValueInfoConverter()
        {
        }

        public SubitemValueInfoConverter(object languageId)
        {
            LanguageId = languageId;
        }

        public IEnumerable<DucValueDto> Convert(IEnumerable<SubitemValueInfoData> entitys)
        {
            List<DucValueDto> dtoList = new List<DucValueDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public DucValueDto Convert(SubitemValueInfoData entity)
        {
            DucValueDto dto = new DucValueDto();

            dto.Id = entity.Id;
            dto.DucId = entity.SubitemId;
            dto.ValueText = entity.ValueText;
            dto.ValueHtml = entity.ValueHtml;
            dto.ValueInt = entity.ValueInt;
            dto.ValueDate = entity.ValueDate;
            dto.ValueUrl = entity.ValueUrl;

            // Multi-language
            if (LanguageId != null)
            {
                SubitemValueLanguageInfoData item = entity.SubitemValueLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, LanguageId));
                if (item != null)
                {
                    dto.ValueText = item.ValueText;
                    dto.ValueHtml = item.ValueHtml;
                }
            }

            if (entity.AttachedSubjects != null)
            {
                SubjectInfoConverter converter = new SubjectInfoConverter();
                dto.AttachedSubjects = converter.Convert(entity.AttachedSubjects).ToList();
            }

            return dto;
        }

        public static List<SubitemValueData> ConvertToData(Dictionary<object, DucValueDto> values)
        {
            List<SubitemValueData> result = new List<SubitemValueData>();
            foreach (DucValueDto item in values.Values)
            {
                result.Add(SubitemValueInfoConverter.ConvertToData(item));
            }
            return result;
        }

        public static SubitemValueData ConvertToData(DucValueDto entity)
        {
            SubitemValueData dto = new SubitemValueData();
            dto.Id = entity.Id;
            dto.SubitemId = entity.DucId;
            dto.ValueText = entity.ValueText;
            dto.ValueHtml = entity.ValueHtml;
            dto.ValueInt = entity.ValueInt;
            dto.ValueDate = entity.ValueDate;
            dto.ValueUrl = entity.ValueUrl;

            return dto;
        }
    }
}
