using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] private float gridSize = 10f;
    private TextMesh textMesh;

    private void Update()
    {
        Vector3 snapPosition;

        gridSize = Mathf.RoundToInt(gridSize);
        snapPosition.x = Mathf.RoundToInt(transform.position.x/ gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z/ gridSize) * gridSize;
        transform.position=new Vector3(snapPosition.x,0f,snapPosition.z);
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        gameObject.name ="Cube "+ labelText;
        textMesh.text = labelText;
    }
}
