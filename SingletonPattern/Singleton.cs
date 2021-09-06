using System;
/// <summary>
/// 單例模式 (Singleton Pattern) 的類別設計展示
/// </summary>
public class Singleton
{
    /// <summary>
    /// 這個欄位為私有，用來持有唯一的執行實例(Instance)
    /// </summary>
    private static Singleton instance;

    public DateTime GenerateTime { get; set; }

    /// <summary>
    /// 建構式，可以在這裡做是到的實例物件的初始化動作
    /// 不過，這樣預設建構式的存取修飾詞為 private，也就是，讓何人都無法使用 new 運算子產生這個類別的物件，只有他自己本身可以
    /// </summary>
    private Singleton()
    {
        GenerateTime = DateTime.Now;
    }

    /// <summary>
    /// 取得這個類別的單例物件 (Singleton Instance)的屬性設計說明
    /// 這個屬性是唯讀，也就是只有讀取功能，無法做任何設定(因為沒有 set 屬性存取子)
    /// 當然，您也可以使用一個靜態方法，取得這個類別的單例物件
    /// </summary>
    public static Singleton Instance
    {
        get
        {
            // 若 instance 並沒有持有一個單例物件，則需要在這個時候，進行產生出來
            // ?? 若這個 單例物件 需要能夠在多執行緒環境下正確執行，又該如何設計呢？
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}