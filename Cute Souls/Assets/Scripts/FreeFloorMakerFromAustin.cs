using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FreeFloorMakerFromAustin : MonoBehaviour {

    public int m_FloorsToMake = 1;
    public GameObject m_FloorTemplate;
    public Vector3 m_FloorOffset = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 m_FloorOrigin = Vector3.zero;

    public bool m_DeleteChildren = false;
    public bool m_NeedsRebuild = false;

    private void RebuildFloors()
    {
        for (int i = 0; i < m_FloorsToMake; i++)
        {
            GameObject floorLeft = Instantiate(m_FloorTemplate, transform);
            floorLeft.transform.localPosition = m_FloorOrigin + i * m_FloorOffset;

            if (i != 0)
            {
                GameObject floorRight = Instantiate(m_FloorTemplate, transform);
                floorRight.transform.localPosition = m_FloorOrigin - i * m_FloorOffset;
            }
        }
    }
	
	// Update is called once per frame
	void Update()
    {
        if (m_DeleteChildren)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
            m_DeleteChildren = false;
        }

        if (m_NeedsRebuild)
        {
            RebuildFloors();
            m_NeedsRebuild = false;
        }
	}
}
