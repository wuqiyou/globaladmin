using System;
using System.Collections.Generic;
using System.Linq;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Microsoft.Practices.ServiceLocation;
using SubjectEngine.Core;

namespace Global.Web.Common
{
    public class WebContext
    {
        // Static Interface
        private static volatile WebContext _instance = new WebContext();
        public static WebContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("The WebContext is not initialized");
                }

                return _instance;
            }
        }

        public ApplicationOption SiteOption { get; set; }
        public IList<LanguageDto> AvailableLanguages { get; set; }
        public Dictionary<object, LanguageDto> LanguageDic { get; set; }
        public Dictionary<string, LanguageDto> LanguageDicByCulture { get; set; }
        public LanguageDto DefaultLanguage { get; set; }

        public Dictionary<string, SubjectDto> SubjectDicByType { get; set; }
        public Dictionary<object, SubjectDto> SubjectDic { get; set; }
        public Dictionary<string, KeywordDto> RecipeKeywords { get; set; }
        public Dictionary<string, CategoryDto> RecipeCategories { get; set; }

        // Instance Interface
        private WebContext()
        {
            LanguageDic = new Dictionary<object, LanguageDto>();
            LanguageDicByCulture = new Dictionary<string, LanguageDto>();
            SubjectDicByType = new Dictionary<string, SubjectDto>();
            SubjectDic = new Dictionary<object, SubjectDto>();
        }

        public void Initilize()
        {
            IGeneralService service = ServiceLocator.Current.GetInstance<IGeneralService>();
            SiteOption = service.GetApplicationOption();
            AvailableLanguages = service.GetLanguages().ToList();

            foreach (LanguageDto language in AvailableLanguages)
            {
                LanguageDic.Add(language.Id, language);
                LanguageDicByCulture.Add(language.Culture, language);
            }

            DefaultLanguage = LanguageDic[SiteOption.DefaultLanguageId];

            SetSubjectList();

            InitRecipeKeywordsAndCategories();
        }

        private void SetSubjectList()
        {
            ISubjectService service = ServiceLocator.Current.GetInstance<ISubjectService>();
            foreach (SubjectDto item in service.GetSubjects())
            {
                SubjectDicByType.Add(item.SubjectType, item);
                SubjectDic.Add(item.Id, item);
            }
            // Populate SubjectField
            foreach (SubjectDto subject in SubjectDic.Values)
            {
                foreach (SubjectFieldDto field in subject.SubjectFields)
                {
                    if (field.FieldDataType == DucTypes.Lookup && field.LookupSubjectId != null)
                    {
                        if (SubjectDic.ContainsKey(field.LookupSubjectId))
                        {
                            field.LookupSubjectType = SubjectDic[field.LookupSubjectId].SubjectType;
                        }
                    }
                }
            }
        }

        private void InitRecipeKeywordsAndCategories()
        {
            RecipeKeywords = new Dictionary<string, KeywordDto>();
            RecipeCategories = new Dictionary<string, CategoryDto>();

            ITemplateService service = ServiceLocator.Current.GetInstance<ITemplateService>();
            TemplateInfoDto template = service.GetTemplate(CmsRegister.RECIPE_TEMPLATE_ID);
            foreach (KeywordDto item in template.Keywords)
            {
                RecipeKeywords.Add(item.Slug, item);
            }
            foreach (CategoryDto item in template.Categorys)
            {
                RecipeCategories.Add(item.Slug, item);
            }
        }
    }
}