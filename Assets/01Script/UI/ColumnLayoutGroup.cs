using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnLayoutGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = gameObject.GetComponent<RectTransform>().rect.width;
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        Vector2 buttonSize = new Vector2(width / gridLayout.constraintCount, gridLayout.cellSize.y);
        gridLayout.cellSize = buttonSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
