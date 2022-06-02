using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI counterSmallText;
    public TextMeshProUGUI counterBigText;

    public int bigCount = 0;
    public int smallCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        counterSmallText.text = "Small Ball Count : 0";
        counterBigText.text = "Big Ball Count : 0";
    }

    // Update is called once per frame
    void Update()
    {
        counterSmallText.text = "Small Ball Count : " + smallCount;
        counterBigText.text = "Big Ball Count : " + bigCount;
    }
}
