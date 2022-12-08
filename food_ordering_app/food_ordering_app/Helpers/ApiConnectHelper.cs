using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Helpers
{
    public class ApiConnectHelper
    {
        public string ENV_HOST ;

        public ApiConnectHelper()
        {
            ENV_HOST = "http://192.168.2.91:3500/";
        }
    }
}
