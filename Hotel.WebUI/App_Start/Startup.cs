﻿using Hotel.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


	[assembly: OwinStartup(typeof(Hotel.WebUI.App_Start.Startup))]
namespace Hotel.WebUI.App_Start
{
    public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                // настраиваем контекст и менеджер

                app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);

                app.CreatePerOwinContext<ApplicationManager>(ApplicationManager.Create);

            // регистрация менеджера ролей

            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
            }
        }
    }

