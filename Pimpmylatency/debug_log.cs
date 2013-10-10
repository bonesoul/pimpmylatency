using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace pimpmylatency
{
    public enum log_type
    {
        GENERAL,
        WARNING,
        PROXIFY,
        PROXIFY_ERROR
    }

    public class log_item
    {
        public log_type type;
        public string message;
        public DateTime time;
    }

    public static class debug_log
    {
        public static ArrayList logs;
        public static frmDebug debug_window = null;

        public static void init()
        {
            logs=new ArrayList();
        }

        public static void add_log(log_type t, string msg)
        {
            log_item i = new log_item();
            i.type = t;
            i.time = DateTime.Now;
            i.message = msg;
            logs.Add(i);
            if (debug_window != null)
                debug_window.add_log_item(i);
        }
    }
}
