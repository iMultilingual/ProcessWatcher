# ProcessWatcher
&lt;- Optimized Process Watcher. ->

```csharp
using System;

namespace Example
{
    class Program
    {
        public static ProcessWatcher Watcher { get; } = new("RobloxPlayerBeta")
        {
            Interval = 1000,
        };
        
        static void Main(string[] args)
        {
            Watcher.Created += (Sender, Handler) => Console.WriteLine("RobloxPlayerBeta is running.");
            
            Watcher.Init() //To initialize EventHandler.
        }
    }
}
```
