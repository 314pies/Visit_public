using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysBeLastSibling : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.GetSiblingIndex() != (transform.parent.childCount - 1))
        {
            transform.SetAsLastSibling();
        }
    }
}
