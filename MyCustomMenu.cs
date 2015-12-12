using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace NavigationDemo.iOS
{
    public sealed class MyCustomMenu : UIView
    {
        public event EventHandler Button1Clicked;
        public event EventHandler Button2Clicked;

        public MyCustomMenu()
        {
            var button1 = new UIButton();
            var button2 = new UIButton();

            BackgroundColor = UIColor.Black;

            button1.SetTitle("Button 1", UIControlState.Normal);
            button1.SetTitleColor(UIColor.White, UIControlState.Normal);
            button1.BackgroundColor = UIColor.Blue;
            button1.TouchUpInside += (sender, args) => { Button1Clicked?.Invoke(this, EventArgs.Empty); };

            button2.SetTitle("Button 2", UIControlState.Normal);
            button2.SetTitleColor(UIColor.White, UIControlState.Normal);
            button2.BackgroundColor = UIColor.Blue;
            button2.TouchUpInside += (sender, args) => { Button2Clicked?.Invoke(this, EventArgs.Empty); };

            AddSubviews(button1, button2);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            this.AddConstraints
                (
                    button1.WithSameCenterY(this), 
                    button1.AtLeftOf(this).Plus(10),
                    button1.Width().EqualTo(80),
                    button1.Height().EqualTo(40), 

                    button2.WithSameTop(button1),
                    button2.ToRightOf(button1).Plus(10),
                    button2.WithSameWidth(button1),
                    button2.WithSameHeight(button1),

                    this.WithSameBottom(button2).Plus(10)
                );
        }
    }
}