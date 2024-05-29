using UnityEngine;

public class ChangeSliderValueAction : ActionBase
{
    public System.Action<float> _lossEnergyValue;
    public override void Execute(object data = null)
    {
        if (data is EnegrySliderController.SliderControllerData _sliderData) 
        {
            var lossValue = _sliderData._lossEnegryPerSec;
            _sliderData._energySlider.value -= lossValue;
            _lossEnergyValue?.Invoke(lossValue);
        }
    }
}
