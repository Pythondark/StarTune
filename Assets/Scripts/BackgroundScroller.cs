using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float backgroundScrollSpeed = 0.1f;
    Material myMaterial;
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        offSet = new Vector2(0f, backgroundScrollSpeed);
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    public void SetBackgroundScrollSpeed(float speed)
    {
        backgroundScrollSpeed = speed;
    }
}
