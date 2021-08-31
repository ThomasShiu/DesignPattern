using System;
abstract class AbstractClass{
    // 一些抽象行為,放到子類去實現
    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();
    // 模板方法,給出邏輯架構,而邏輯的組成是一些相對應的抽象操作,它們都推遲到子類實現
    public void TemplateMethod(){
        PrimitiveOperation1();
        PrimitiveOperation2();
        Console.WriteLine("");

    }
}