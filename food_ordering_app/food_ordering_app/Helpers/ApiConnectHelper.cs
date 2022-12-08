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
            ENV_HOST = "http://172.30.169.124:3500/";
        }
    }
}
