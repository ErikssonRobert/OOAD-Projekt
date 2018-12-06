using System;
using System.Collections.Generic;
using SkiaSharp;

namespace LoGoPrototype.Models
{
    public class Turtle
    {
        public static List<Command> commands = new List<Command>();

        public static SKPaint StrokePaint()
        {

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 2,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
        };
            return paint;
        }
    }
}
