using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenMouseOver : MonoBehaviour
{
    private void OnMouseOver()
    {
        Debug.Log(transform.parent.gameObject.name);
    }
}
