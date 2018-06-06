using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public class DocumentConverter : IDataConverter<DocumentData, DocumentDto>
    {
        public IEnumerable<DocumentDto> Convert(IEnumerable<DocumentData> entitys)
        {
            List<DocumentDto> dtoList = new List<DocumentDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public DocumentDto Convert(DocumentData entity)
        {
            DocumentDto dto = new DocumentDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Title;
            dto.Title = entity.Title;
            dto.OriginFile = entity.FileName;
            dto.ContentUri = entity.ContentUri;
            dto.DocTypeId = entity.DocTypeId;
            dto.IssuedById = entity.IssuedById;
            dto.IssuedDate = entity.IssuedDate;
            dto.Extension = entity.Extension;
            dto.ContentType = entity.ContentType;
            dto.ContentLength = entity.ContentLength;

            return dto;
        }

        public static DocumentData ConvertToData(DocumentDto entity)
        {
            DocumentData dto = new DocumentData();
            dto.Id = entity.Id;
            dto.Title = entity.Title;
            dto.FileName = entity.OriginFile;
            dto.ContentUri = entity.ContentUri;
            dto.DocTypeId = entity.DocTypeId;
            dto.IssuedById = entity.IssuedById;
            dto.IssuedDate = entity.IssuedDate;
            dto.Extension = entity.Extension;
            dto.ContentType = entity.ContentType;
            dto.ContentLength = entity.ContentLength;

            return dto;
        }
    }
}
