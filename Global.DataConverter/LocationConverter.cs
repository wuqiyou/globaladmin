using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public class LocationConverter : IDataConverter<LocationData, LocationDto>
    {
        public IEnumerable<LocationDto> Convert(IEnumerable<LocationData> entitys)
        {
            List<LocationDto> dtoList = new List<LocationDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public LocationDto Convert(LocationData entity)
        {
            LocationDto dto = new LocationDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.LocationSlug = entity.Name.ToSlug();
            dto.IsPublished = entity.IsPublished;

            if (entity.LocationLanguages != null)
            {
                dto.LocationLanguagesDic = new Dictionary<object, LocationLanguageDto>();
                foreach (LocationLanguageData item in entity.LocationLanguages)
                {
                    LocationLanguageDto newItem = new LocationLanguageDto
                    {
                        LanguageId = item.LanguageId,
                        Name = item.Name
                    };
                    dto.LocationLanguagesDic.Add(newItem.LanguageId, newItem);
                }
            }

            return dto;
        }
    }
}
