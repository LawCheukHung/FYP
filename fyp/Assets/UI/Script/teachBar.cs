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
    enum mouseState{};

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
        
        if (Input.GetMouseButtonDown(1))
            setSpeedOfDecrease(false,defaultSpeedOfDecrease*2);
    }
}
