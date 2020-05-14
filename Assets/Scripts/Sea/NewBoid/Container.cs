using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public enum GizmoType { Never, SelectedOnly, Always }
    public GizmoType showContainer;

    private void OnDrawGizmos () {
        if (showContainer == GizmoType.Always) {
            DrawGizmos ();
        }
    }

    void OnDrawGizmosSelected () {
        if (showContainer == GizmoType.SelectedOnly) {
            DrawGizmos ();
        }
    }

    void DrawGizmos () {
        Gizmos.color = new Color (1.0f, 1.0f, 1.0f, 0.3f);
        Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
        Gizmos.DrawCube (position, transform.localScale * 2);
    }
}