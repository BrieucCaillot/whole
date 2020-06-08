using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private int index = 0;

    public Interaction[] interactions;

    public static GameObject boidsTarget;

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int newIndex)
    {
        index = newIndex;
        interactions[index].Enable();
    }

    void Start()
    {
        interactions[index].Enable();
    }

    void Update()
    {
        if (interactions[index].Listen() && interactions[index].IsEnabled()) 
        {
            InteractionHandler(interactions[index], index);
        }
    }

    void InteractionHandler(Interaction interaction, int index)
    {   
        interaction.Disable();
        GameManager.Instance.InteractionHandler(interaction);
    }
}
