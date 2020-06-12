using UnityEngine;

public class DefaultInteraction : Interaction
{
    public float defaultDelay = 2f;
    private bool go = false;

    void Start()
    {
        Invoke("Go", defaultDelay);

    }

    void Go()
    {
        go = true;
    }

    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        return go;
    }
}
