using System;
using System.Collections.Generic;
using LoGoPrototype.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;

namespace LoGoPrototype.Views
{
    public partial class Logo : ContentPage
    {
        const string forward = "fd";
        const string backward = "bd";
        const string right = "rt";
        const string left = "lt";

        SKPoint x;
        SKPoint y;
        Turtle turtle = new Turtle();

        List<string> list = new List<string>();

        public void Contructor(SKPoint x, SKPoint y)
        {
            this.x = x;
            this.y = y;
        }

        public Logo()
        {
            //Draw stuff
            InitializeComponent();
            list.Add(forward);
            list.Add(right);
            list.Add(forward);
            list.Add(right);
            list.Add(forward);
            list.Add(right);
            list.Add(forward);

            list.Add(left);
            list.Add(forward);

            list.Add(forward);
            list.Add(left);
            list.Add(forward);
            list.Add(left);
            list.Add(forward);
            list.Add(left);
            list.Add(forward);
        }

        private void Draw_Surface(object sender,  SKPaintSurfaceEventArgs e)
        {

            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Translate(e.Info.Width / 2, e.Info.Height / 2);
            canvas.Clear(SKColors.Red);

            float dist = 100;

            void Forward(float distance, SKPaint paint)
            {
                canvas.DrawLine(0, 0, distance, 0, paint);
                canvas.Translate(distance, 0);
            }

            void Rotate(float angle)
            {
                canvas.RotateDegrees(angle);
            }

            foreach (string input in list)
            {
                switch(input)
                {
                    case forward:
                        Forward(dist, turtle.StrokePaint());
                        break;
                    case backward:
                        Forward(-dist, turtle.StrokePaint());
                        break;
                    case right:
                        Rotate(90f);
                        break;
                    case left:
                        Rotate(-90f);
                        break;
                }
            }
        }

    }
}
