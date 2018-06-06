using Framework.Unity;
using Framework.UoW;
using Global.Registry;
using Global.Web.Common;
using Microsoft.Practices.ServiceLocation;
using NLog;
using SubjectEngine.Configuration;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Global.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            InitUnity();
            InitFramework();
            InitWebContext();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void InitUnity()
        {
            IList<IUnityRegistry> registries = new List<IUnityRegistry>();
            registries.Add(new CoreRegistry());
            registries.Add(new SubjectEngineRepositoryRegistry());
            registries.Add(new SubjectEngineServiceRegistry());
            registries.Add(new WrapperServiceRegistry());
            UnityLibrary library = new UnityLibrary(registries);
            library.InitializeServiceLocator();
        }

        private void InitFramework()
        {
            IDataStoreManager storeManager = ServiceLocator.Current.GetInstance<IDataStoreManager>();
            EntityResolver entityResolver = ServiceLocator.Current.GetInstance<EntityResolver>();
            IBusinessObjectFactory factory = ServiceLocator.Current.GetInstance<IBusinessObjectFactory>();
            UnitOfWorkFactory.Instance.Initialize(storeManager, entityResolver, entityResolver, factory);
        }

        private void InitWebContext()
        {
            WebContext.Current.Initilize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            LogExceptionMessage(ex);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        private void LogExceptionMessage(Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.ToString());
        }
    }
}