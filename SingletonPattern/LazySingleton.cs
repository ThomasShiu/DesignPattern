using System;

public sealed class LazySingleton
{
    public DateTime GenerateTime { get; set; }
    private LazySingleton()
    {
         GenerateTime = DateTime.Now;
    }

    public static LazySingleton Instance
    {
        get
        {
            return InnerClass.Instance;
        }
    }

    private class InnerClass
    {
        internal static readonly LazySingleton Instance = new LazySingleton();

        static InnerClass()
        {
        }
    }
}