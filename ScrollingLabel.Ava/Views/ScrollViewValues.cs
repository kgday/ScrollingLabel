using Avalonia.Controls;

using System;
using System.Collections.Generic;

namespace ScrollingLabel.Views
{
    public class ScrollViewValues
    {
        public ScrollViewValues(double scrollVerticalOffset, double viewPortHeight, IControl referenceParent)
        {
            ScrollVerticalOffset = scrollVerticalOffset;
            ViewPortHeight = viewPortHeight;
            ReferenceParent = referenceParent;
        }

        public double ScrollVerticalOffset { get; }
        public double ViewPortHeight { get; }
        public IControl ReferenceParent { get; }
    }
}