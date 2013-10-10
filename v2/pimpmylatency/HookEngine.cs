using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pimpmylatency
{
    public enum HOOK_TYPE
    {
        WINSOCK2_CONNECT,
        WINSOCK2_SEND          
    }

    public static class HookEngine
    {
        public static List<Hook> hooks;
        private static object manager = null;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public static void init(string _process_name)
        {
            logger.Trace("HookEngine init()..");
            hooks=new List<Hook>();
            hooks.Add(new Hook("firefox.exe", HOOK_TYPE.WINSOCK2_CONNECT));
            hooks.Add(new Hook("firefox.exe", HOOK_TYPE.WINSOCK2_SEND));

            manager = new DeviareWrapper();
        }
    }

    public class Hook
    {
        public HOOK_TYPE type;
        public bool injected = false;
        public string process_name;
        public string module_name;
        public string function_name;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public Hook(string _process,HOOK_TYPE _type)
        {
            process_name = _process;
            type = _type;       
            switch (type)
            {
                case HOOK_TYPE.WINSOCK2_CONNECT:
                    module_name = "ws2_32.dll";
                    function_name = "connect";
                    break;
                case HOOK_TYPE.WINSOCK2_SEND:
                    module_name = "ws2_32.dll";
                    function_name = "send";
                    break;
                default:
                    break;
            }
            logger.Info("New hook (" + module_name + "," + function_name + ") defined for " + process_name);   
        }

        public void deviare_fire(DeviareTools.IProcess proc, DeviareParams.ICallInfo callinfo, Deviare.IRemoteCall r_call)
        {
            List<object> parameters = new List<object>();            

            DeviareParams.IParams pms = callinfo.Params;
            DeviareParams.IEnumParams enumurator = pms.Enumerator;
            DeviareParams.IParam parameter = enumurator.First;
                       
            while (parameter != null)
            {
                parameters.Add(parameter);                     
                if ((parameter = enumurator.Next) == null)
                    break;
            }

            if (parameters.Count > 0)
                Router.route(this, parameters);
        }
    }
}
