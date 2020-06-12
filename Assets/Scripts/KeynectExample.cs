using UnityEngine;

public class KeynectExample : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PictosPositionsManager.Instance.ShowPicto("VolerEnsemble");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PictosPositionsManager.Instance.HidePicto();
        }
    }
}
