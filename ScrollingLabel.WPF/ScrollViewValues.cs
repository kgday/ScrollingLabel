using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScrollingLabel.Views
{
    public class ScrollViewValues
    {
        public ScrollViewValues(double scrollVerticalOffset, double viewPortHeight, Control referenceParent)
        {
            ScrollVerticalOffset = scrollVerticalOffset;
            ViewPortHeight = viewPortHeight;
            ReferenceParent = referenceParent;
        }

        public double ScrollVerticalOffset { get; }
        public double ViewPortHeight { get; }
        public Control ReferenceParent { get; }
    }
}