using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    public float scrollSpeed;

    private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * scrollSpeed;
        rend.material.mainTextureOffset -= new Vector2(0, -offset);
    }
}
