using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToNearestWholeNumber : MonoBehaviour {
    public bool snap;

    private void OnValidate()
    {
        Vector3 gridSize = new Vector3(2, 2, 2);
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
            Mathf.Round(currentPos.y),
            Mathf.Round(currentPos.z));

    }
}
