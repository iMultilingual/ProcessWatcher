# ProcessWatcher
&lt;- Optimized Process Watcher. ->

```csharp
using System;

namespace Example
{
    class Program
    {
        public static ProcessWatcher Watcher { get; } = new("RobloxPlayerBeta") { Interval = 1000 };
        
        static void Main(string[] args)
        {
            Watcher.Created += (Proc) => Console.WriteLine("Process Name: {0}, Process Id: {1}", Proc.ProcessName, Proc.Id);
            Watcher.Init();
            
            Thread.Sleep(-1);
        }
    }
}
```
