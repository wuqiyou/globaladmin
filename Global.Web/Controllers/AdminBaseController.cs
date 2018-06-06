using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Framework.Validation;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Common;
using Global.Web.Common.Helpers;
using Global.Web.Helpers;
using Global.Web.Models;
using Microsoft.Practices.ServiceLocation;
using SubjectEngine.Core;
using SubjectEngine.Data;

namespace Global.Web.Controllers
{
    public abstract class AdminBaseController : Controller
    {
        public const string SubsiteIdStateKey = "subsiteid";
        private const string UserContextSTateKey = "AdminUserContextStateKey";

        public LanguageDto CurrentLanguage { get; set; }
        private FolderType CurrentFolderType { get; set; }
        private FolderTreeViewModel _currentFolderTree;

        public AdminBaseController()
        {
            CurrentFolderType = FolderType.Content;
        }

        public AdminBaseController(FolderType folderType)
        {
            CurrentFolderType = folderType;

            if (CurrentUserContext != null && CurrentUserContext.CurrentLanguage != null)
            {
                CurrentLanguage = CurrentUserContext.CurrentLanguage;
            }
            else
            {
                CurrentLanguage = WebContext.Current.DefaultLanguage;
            }
        }

        private IEnumerable<FolderInfoDto> _folderList;
        private IEnumerable<FolderInfoDto> FolderList
        {
            get
            {
                if (_folderList == null)
                {
                    IFolderService service = ServiceLocator.Current.GetInstance<IFolderService>();
                    if (SubsiteId == 0)
                    {
                        // Get all folders
                        _folderList = service.GetFolders(CurrentFolderType);
                    }
                    else
                    {
                        // Get folders of current subsite
                        _folderList = service.GetFolders(CurrentFolderType);
                        _folderList = _folderList.Where(o => o.ParentId == null || o.FolderId == SubsiteId || o.ParentId == SubsiteId);
                    }
                }

                return _folderList;
            }
        }

        private int? _subsiteId;
        private int SubsiteId
        {
            get
            {
                if (!_subsiteId.HasValue)
                {
                    int folderId;
                    // 1. Try to read data from query string 
                    if (Request.QueryString[SubsiteIdStateKey] != null)
                    {
                        if (int.TryParse(Request.QueryString[SubsiteIdStateKey], out folderId))
                        {
                            _subsiteId = folderId;
                            // save valid value into cookie
                            CookieHelper.WriteCookie(SubsiteIdStateKey, folderId.ToString());
                        }
                        else
                        {
                            _subsiteId = 0;
                        }
                    }
                    // 2. Try to read value from cookie
                    else
                    {
                        string value = CookieHelper.ReadCookie(SubsiteIdStateKey);
                        if (value != null && int.TryParse(value, out folderId))
                        {
                            _subsiteId = folderId;
                        }
                        else
                        {
                            _subsiteId = 0;
                        }
                    }
                }

                return _subsiteId.Value;
            }
        }

        /// <summary>
        /// Get tree view and current selected folder
        /// </summary>
        /// <param name="folderId">The Id of selected folder</param>
        /// <returns>Tree with current selected folder marked</returns>
        public FolderTreeViewModel GetCurrentFolderTree(int? folderId = null)
        {
            if (_currentFolderTree == null)
            {
                _currentFolderTree = new FolderTreeViewModel();
                FolderTreeBuilder treeBuilder = new FolderTreeBuilder(FolderList, folderId);
                _currentFolderTree.TreeRoot = treeBuilder.TreeRoot;
            }
            if (folderId.HasValue)
            {
                _currentFolderTree.CurrentFolder = FolderList.SingleOrDefault(x => object.Equals(x.FolderId, folderId.Value));
            }

            return _currentFolderTree;
        }

        private UserContext _currentUserContext;
        public UserContext CurrentUserContext
        {
            get
            {
                if (_currentUserContext == null)
                {
                    if (System.Web.HttpContext.Current.Session[UserContextSTateKey] != null)
                    {
                        _currentUserContext = (UserContext)System.Web.HttpContext.Current.Session[UserContextSTateKey];
                    }
                    else
                    {
                        _currentUserContext = new UserContext(new UserIdentity());
                        System.Web.HttpContext.Current.Session[UserContextSTateKey] = _currentUserContext;
                    }
                }

                return _currentUserContext;
            }
        }

        protected void ProcUpdateResult(ValidationResult validationResult, Exception exception)
        {
            if (exception != null)
            {
                throw exception;
            }
            else
            {
                foreach (ValidationItem item in validationResult.Items)
                {
                    ModelState.AddModelError(item.Key, item.Message);
                }
            }
        }
    }
}
