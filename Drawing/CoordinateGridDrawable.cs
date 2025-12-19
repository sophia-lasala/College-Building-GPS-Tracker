using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using GPSTrackerNYIT.Views;

namespace GPSTrackerNYIT.Drawing
{
    public class CoordinateGridDrawable : IDrawable
    {
        public static readonly CoordinateGridDrawable Instance = new();

     
        public List<Node> CurrentPath { get; set; } = new List<Node>();

        //bounds
        private const double MinX = 0;
        private const double MaxX = 9;
        private const double MinY = -1.5;
        private const double MaxY = 1.5;

        //based off image of floorplan to line up
        private const float ImageMinX = 96;
        private const float ImageMaxX = 881;
        private const float ImageMinY = 121;
        private const float ImageMaxY = 379;

        private const float FloorplanOriginalWidth = 960f;
        private const float FloorplanOriginalHeight = 540f;

        
        private PointF ToPixel(double x, double y, float viewWidth, float viewHeight)
        {
            //world coordinate
            double nx = (x - MinX) / (MaxX - MinX);
            double ny = (y - MinY) / (MaxY - MinY);

            //pixel bounds
            double px = ImageMinX + nx * (ImageMaxX - ImageMinX);

            //graph to screen
            double py = ImageMaxY - ny * (ImageMaxY - ImageMinY);

            //scaling
            double scaleX = viewWidth / FloorplanOriginalWidth;
            double scaleY = viewHeight / FloorplanOriginalHeight;

            return new PointF(
                (float)(px * scaleX),
                (float)(py * scaleY)
            );
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float width = dirtyRect.Width;
            float height = dirtyRect.Height;

            canvas.FillColor = Colors.Transparent;
            canvas.FillRectangle(dirtyRect);

     
            DrawGrid(canvas, width, height);

            if (CurrentPath.Count > 1)
                DrawPath(canvas, width, height);

            if (CurrentPath.Count > 0)
                DrawEndpoints(canvas, width, height);
        }

        //grid
        private void DrawGrid(ICanvas canvas, float width, float height)
        {
            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = 1;

            for (int x = 0; x <= 9; x++)
            {
                var p1 = ToPixel(x, -1.5, width, height);
                var p2 = ToPixel(x, 1.5, width, height);
                canvas.DrawLine(p1, p2);
            }

            for (double y = -1.5; y <= 1.5; y += 0.5)
            {
                var p1 = ToPixel(0, y, width, height);
                var p2 = ToPixel(9, y, width, height);
                canvas.DrawLine(p1, p2);
            }
        }

        //dijkstra
        private void DrawPath(ICanvas canvas, float width, float height)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;

            for (int i = 0; i < CurrentPath.Count - 1; i++)
            {
                var a = CurrentPath[i];
                var b = CurrentPath[i + 1];

                var p1 = ToPixel(a.Position.X, a.Position.Y, width, height);
                var p2 = ToPixel(b.Position.X, b.Position.Y, width, height);

                canvas.DrawLine(p1, p2);
            }
        }

        //start end markers
        private void DrawEndpoints(ICanvas canvas, float width, float height)
        {
            float radius = 10;

            var start = CurrentPath[0];
            var pStart = ToPixel(start.Position.X, start.Position.Y, width, height);
            canvas.FillColor = Colors.Green;
            canvas.FillCircle(pStart.X, pStart.Y, radius);

            var end = CurrentPath[CurrentPath.Count - 1];
            var pEnd = ToPixel(end.Position.X, end.Position.Y, width, height);
            canvas.FillColor = Colors.Blue;
            canvas.FillCircle(pEnd.X, pEnd.Y, radius);
        }
    }
}
