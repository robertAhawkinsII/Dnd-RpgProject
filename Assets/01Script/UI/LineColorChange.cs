using UnityEngine;

public class LineColorChange : MonoBehaviour
{
    [SerializeField]
    private Color[] colorPool;

    [SerializeField]
    [Range(0f, 1f)] float changeTime;

    int Num;
    float t = 0f;

    LineRenderer thisLine;
    int len;

    // Start is called before the first frame update
    void Start()
    {
        thisLine = GetComponent<LineRenderer>();
        len = colorPool.Length;
    }

    // Update is called once per frame
    void Update()
    {
        thisLine.material.color = Color.Lerp(thisLine.material.color, colorPool[Num], changeTime * Time.deltaTime);
        thisLine.endColor = Color.Lerp(thisLine.endColor, colorPool[Num], changeTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, changeTime * Time.deltaTime);
        if(t > .9f)
        {
            t = 0f;
            Num++;
            Num = (Num >= len) ? 0 : Num;
        }
    }
}
