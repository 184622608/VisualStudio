﻿using System.Collections.Generic;
using System.Windows.Media;
using GitHub.UI;
using GitHub.VisualStudio.UI;

namespace GitHub.VisualStudio
{
    public static class SharedResources
    {
        static readonly Dictionary<string, DrawingBrush> drawingBrushes = new Dictionary<string, DrawingBrush>();

        public static DrawingBrush GetDrawingForIcon(Octicon icon, Brush color)
        {
            string name = icon.ToString();
            if (drawingBrushes.ContainsKey(name))
                return drawingBrushes[name];

            var brush = new DrawingBrush()
            {
                Drawing = new GeometryDrawing()
                {
                    Brush = color,
                    Pen = new Pen(color, 1.0).FreezeThis(),
                    Geometry = OcticonPath.GetGeometryForIcon(icon).FreezeThis()
                }
                .FreezeThis(),
                Stretch = Stretch.Uniform
            }
            .FreezeThis();
            drawingBrushes.Add(name, brush);
            return brush;
        }
    }
}