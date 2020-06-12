using UnityEngine;

public class DefaultInteraction : Interaction
{
    private bool go = false;

    void Start()
    {
        Invoke("Go", 2f);

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
