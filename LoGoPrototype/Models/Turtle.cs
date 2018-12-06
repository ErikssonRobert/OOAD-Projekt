using System;
using SkiaSharp;

namespace LoGoPrototype.Models
{
    public class Turtle
    {
        public SKPaint StrokePaint()
        {

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 5,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
        };
            return paint;
        }

        public SKPaint StrokePaint20()
        {

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 20,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };
            return paint;
        }
    }
}
