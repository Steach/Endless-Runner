using UnityEngine;

public class ChangeColorLerpAction : ActionBase
{
    public override void Execute(object data = null)
    {
        if (data is EnegrySliderController.SliderControllerData _sliderData)
        {
            var startColor = _sliderData._startColor;
            var endColor = _sliderData._endColor;
            var value = (_sliderData._energySlider.value) * 0.01;
            var image = _sliderData._sliderImage;

            image.color = Color.Lerp(endColor, startColor, (float)value);
        }
    }
}
