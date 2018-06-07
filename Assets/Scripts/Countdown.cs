using System;
using UnityEngine;

public class Countdown
{
    private Action action;
    private float tickRate;
    private float currentTime;

    private bool activated;

    public Countdown(Action action, float tickRate)
    {
        this.action = action;
        this.tickRate = tickRate;
        this.currentTime = tickRate;
        this.activated = false;
    }

    public void Update(float deltaTime)
    {
        if (activated)
            return;
        
        if ((this.currentTime - deltaTime) <= 0)
        {
            this.currentTime = this.tickRate;
            Tick();
        }

        this.currentTime -= deltaTime;
    }
    private void Tick()
    {
        action();
        activated = true;
    }
}
