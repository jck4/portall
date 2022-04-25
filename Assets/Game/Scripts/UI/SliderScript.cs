using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;

    public void SetSlider(int sliderCurrent, int sliderMax){
      slider.maxValue = sliderMax;
      slider.value = sliderCurrent;
    }

}
