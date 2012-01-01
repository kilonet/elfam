using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using elfam.web.Models;

namespace elfam.web.Dao
{
    public class NHibernateSessionPerRequest: IHttpModule
    {
        private static readonly ISessionFactory sessionFactory;

        static NHibernateSessionPerRequest()
        {
            sessionFactory = CreateSessionFactory();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        public static ISession GetCurrentSession()
        {
            return sessionFactory.GetCurrentSession();
        }

        public void Dispose() { }

        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = sessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }



        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(sessionFactory);
            if (session == null) return;
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }

        }



        private static ISessionFactory CreateSessionFactory()
        {
            string connString = "elfam_connection_string";
            FluentConfiguration configuration = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(
                    x => x.FromConnectionStringWithKey(connString)))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m =>
                              {
                                  m.FluentMappings.AddFromAssemblyOf<User>();
                                  m.HbmMappings.AddFromAssemblyOf<User>();
                              }
                );
            
            return configuration.BuildSessionFactory();

        } 
    }
}
