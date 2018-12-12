using System;
using System.Collections.Generic;
using SkiaSharp;

namespace LoGoPrototype.Models
{
    public class Turtle
    {
        public static List<Command> commands = new List<Command>();
        public static SKPaint SPaint { get; set; } = new SKPaint();

        public static SKPaint StrokePaint(SKColor color)
        {
            SPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = color,
                StrokeWidth = 2,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };

            return SPaint;
        }
    }
}
