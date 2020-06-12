using UnityEngine;

public class DefaultInteraction : Interaction
{
    private bool go = false;

    void Start()
    {
        Invoke("Go", 2f);
        Debug.Log(go);

    }

    void Go()
    {
        go = true;
        Debug.Log(go);
    }

    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        return go;
    }
}
