using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public static class Extensions
    {
        public static IEnumerable<FluentLayout> WithSameEverything(this UIView targetView, UIView sourceView)
        {
            yield return targetView.WithSameTop(sourceView);
            yield return targetView.WithSameLeft(sourceView);
            yield return targetView.WithSameRight(sourceView);
            yield return targetView.WithSameBottom(sourceView);
        } 
    }
}