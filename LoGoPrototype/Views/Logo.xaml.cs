using System;
using System.Collections.Generic;
using LoGoPrototype.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;
using Command = LoGoPrototype.Models.Command;

namespace LoGoPrototype.Views
{
    public partial class Logo : ContentPage
    {
        const string forward = "fd";
        const string backward = "bd";
        const string right = "rt";
        const string left = "lt";

        public Logo()
        {
            InitializeComponent();
        }

        private void Draw_Surface(object sender,  SKPaintSurfaceEventArgs e)
        {

            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Translate(e.Info.Width / 2, e.Info.Height / 2);
            canvas.RotateDegrees(-90);
            canvas.Clear(SKColors.Gray);
            Execute(Turtle.commands);

            void Forward(int amt)
            {
                canvas.DrawLine(0, 0, amt, 0, Turtle.StrokePaint());
                canvas.Translate(amt, 0);
            }

            void Rotate(int angle)
            {
                canvas.RotateDegrees(angle);
            }

            void Execute(List<Command> cmds)
            {
                foreach (Command cmd in cmds)
                {
                    if (cmd.Action.Equals("repeat"))
                    {
                        for (int i = 0; i < int.Parse(cmd.Amount); i++)
                        {
                            Execute(cmd.Commands);
                        }
                    } else
                    {
                        switch (cmd.Action)
                        {
                            case forward:
                                Forward(int.Parse(cmd.Amount));
                                break;
                            case backward:
                                Forward(-int.Parse(cmd.Amount));
                                break;
                            case right:
                                Rotate(int.Parse(cmd.Amount));
                                break;
                            case left:
                                Rotate(-int.Parse(cmd.Amount));
                                break;
                        }
                    }

                }
            }

        }

    }
     
}
