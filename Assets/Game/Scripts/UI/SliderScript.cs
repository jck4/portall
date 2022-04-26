using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;

    public void SetSlider(float sliderCurrent, float sliderMax){
      slider.maxValue = sliderMax;
      slider.value = sliderCurrent;
    }

}
