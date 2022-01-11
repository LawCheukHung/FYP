using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teachBar : MonoBehaviour
{
    public float startPoints;
    public Slider slider;
    public float defaultSpeedOfDecrease;
    float SpeedOfDecrease;
    bool isTeaching = false;

    // Start is called before the first frame update
    void Start()
    {
        SpeedOfDecrease = defaultSpeedOfDecrease;
        slider.value = startPoints;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime * SpeedOfDecrease;
        teaching();
    }

    public void setSpeedOfDecrease(bool isDecrease, float speed)
    {
        if(isDecrease)
            SpeedOfDecrease += speed;
        else
            SpeedOfDecrease -= speed;
    }

    public void teaching()
    {
        float speed = defaultSpeedOfDecrease * 2;
        if (Input.GetMouseButton(1))
        {
            if (!isTeaching)
                SpeedOfDecrease -= speed;
            isTeaching = true;
        }
        else
        {
            if (isTeaching)
                SpeedOfDecrease += speed;
            isTeaching = false;
        }
    }
}
