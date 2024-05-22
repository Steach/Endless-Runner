using UnityEngine;

public class ChangeSliderValueAction : ActionBase
{
    public override void Execute(object data = null)
    {
        if (data is EnegrySliderController.SliderControllerData _sliderData) 
        {
            var lossValue = _sliderData._lossEnegryPerSec;
            _sliderData._energySlider.value -= lossValue;
        }
    }
}
