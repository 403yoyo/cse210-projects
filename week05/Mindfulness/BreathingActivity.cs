using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public override void RunActivity()
    {
        StartActivity();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            Console.Write("Now, breathe out... ");
            ShowCountdown(6);
        }
        EndActivity();
    }
}
