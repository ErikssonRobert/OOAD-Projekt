using System;
using System.Collections.Generic;
using SkiaSharp;

namespace LoGoPrototype.Models
{
    public class Turtle
    {
        public static List<Command> commands = new List<Command>();

        public static SKPaint SPaint = DefaultPaint();

        public static void StrokePaint(SKColor color)
        {
            SPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = color,
                StrokeWidth = 2,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };
        }

        private static SKPaint DefaultPaint()
        {
            SPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 2,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };

            return SPaint;
        }
    }
}
