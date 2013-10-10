using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deviare;
using DeviareTools;
using DeviareCommonLib;
using DeviareParams;

namespace pimpmylatency
{
    public class DeviareWrapper
    {
        private Deviare.SpyMgr manager = null;
        private Deviare.HookEventsProxy hook_proxy = null;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public DeviareWrapper()
        {
            logger.Trace("HookWrapper init()..");
            manager = new SpyMgr();
            hook_proxy = manager.CreateHookEventsProxy() as Deviare.HookEventsProxy;
            foreach (Hook h in HookEngine.hooks)
            {
                this.inject_hook(h);
            }
        }

        private void inject_hook(Hook hook)
        {
            if (hook.injected) // if we're already injected 
                eject_hook(hook); // let's first eject

            IProcesses procs = manager.get_Processes(0);
            IProcess process = procs.get_Item(hook.process_name);
            if (process != null) // if we catched the process
            {
                IPEModuleInfo module = process.Modules.get_ModuleByName(hook.module_name);
                if (module != null) // if we catched the module
                {
                    IExportedFunction func = module.Functions.get_ItemByName(hook.function_name);
                    Deviare.Hook dhook = manager.CreateHook(func);
                    dhook.Attach(process);
                    hook_proxy.OnStateChanged += new Deviare.DHookEvents_OnStateChangedEventHandler(state);
                    hook_proxy.OnFunctionCalled += new Deviare.DHookEvents_OnFunctionCalledEventHandler(hook.deviare_fire);
                    hook_proxy.Attach(dhook);
                    dhook.Properties = (int)NktHookFlags._call_before;
                    dhook.Hook();
                    hook.injected = true;
                }
            }
        }

        private void eject_hook(Hook hook)
        {
            hook.injected = false;
        }

        public void state(IProcess proc, HookState new_state,HookState old_state)
        {       
          
        }
    }
}
