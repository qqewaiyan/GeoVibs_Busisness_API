using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class ApiRoutes
    {
        public const string BaseUrl = "api";

        public const string Venue = BaseUrl + "/venue";
        public const string Room = BaseUrl + "/room";
        public const string Movie = BaseUrl + "/movie";
        public const string Item = BaseUrl + "/item";
        public const string Session = BaseUrl + "/session";
        public const string SessionDetail = BaseUrl + "/sessiondetail";
        public const string User = BaseUrl + "/user";
        public const string UserLevel = BaseUrl + "/userlevel";
        public const string Auth = BaseUrl + "/auth";
        public const string Register = BaseUrl + "/auth/register";
        public const string Login = BaseUrl + "/auth/login";
    }
}
