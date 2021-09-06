using System;
using System.Collections.Generic;

public sealed class SimpleThreadSafetySingleton
{
    private static readonly object padlock = new object();

    private static SimpleThreadSafetySingleton _instance = null;
    public DateTime GenerateTime { get; set; }
    private SimpleThreadSafetySingleton()
    {
        GenerateTime = DateTime.Now;
    }

    public static SimpleThreadSafetySingleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new SimpleThreadSafetySingleton();
                }
                return _instance;
            }
        }
    }
}
