using System;
using System.Diagnostics;
using System.Timers;

namespace Github
{
    public class ProcessWatcher : IDisposable
    {
        public delegate void CreatedDelegate();
        public event CreatedDelegate Created;

        private Timer Timer { get; } = new();
        private string ProcessName;
        private Process Process;

        private bool IsDisposed = false;
        public double Interval { get; set; }

        public ProcessWatcher(string ProcessName) => this.ProcessName = ProcessName;

        public void Init()
        {
            this.Timer.Interval = Interval;
            this.Timer.Elapsed += Timer_Elapsed;
            this.Timer.Start();
        }

        protected virtual void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName(this.ProcessName);

            if (Processes.Length == 1)
            {
                this.OnProcessCreated(Processes[0]);

                Created?.Invoke();
            }
        }

        protected virtual void OnProcessCreated(Process Process)
        {
            this.Timer.Stop();
            this.Process = Process;
            this.Process.EnableRaisingEvents = true;

            this.Process.Exited += (sender, args) => this.Timer.Start();
        }

        protected virtual void Dispose()
        {
            if (IsDisposed) return;
            
            Timer.Dispose();
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }

        public void Dispose() => this.Dispose();
    }
}
