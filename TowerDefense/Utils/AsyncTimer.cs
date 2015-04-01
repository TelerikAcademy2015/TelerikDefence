namespace TowerDefense.Utils
{
    using System;
    using System.Timers;


    public delegate void AsyncTimerDelegate();
    public class AsyncTimer
    {
        public static void DelayedCall(int miliseconds, AsyncTimerDelegate callback)
        {
            AsyncTimer timer = null;
            timer = new AsyncTimer(miliseconds, () =>
            {
                callback();
                timer.Stop();
            });
            timer.Start();
        }

        private Timer timer;

        public AsyncTimer(int miliseconds, AsyncTimerDelegate callback)
        {
            this.timer = new Timer(miliseconds);
            this.timer.Elapsed += (Object source, ElapsedEventArgs e) =>
                {
                    callback();
                };
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }
    }
}
