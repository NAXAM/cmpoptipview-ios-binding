using System;
using System.Collections.Generic;
using System.Linq;
using CMPopTip;
using CoreGraphics;
using Foundation;
using UIKit;



namespace CMPopTipViewQS
{
    using ColorScheme = Tuple<UIColor, UIColor>;
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        List<CMPopTipView> _VisiblePopTipViews = new List<CMPopTipView>();
        NSObject _CurrentPopTipViewTarget;
        NSDictionary _Contents;
        ColorScheme[] _ColorSchemes;
        NSDictionary<NSNumber, NSString> _Titles;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var dict = new Dictionary<int, NSObject>()
            {
                {
                    11, (NSString) "A CMPopTipView will automatically position itself within the container view."
                },
                {
                    12, (NSString) "A CMPopTipView will automatically orient itself above or below the target view based on the available space."
                },
                {
                    13, (NSString) "A CMPopTipView always tries to point at the center of the target view. A CMPopTipView will automatically size itself to fit the text message."
                },
                {
                    14, (NSString) "A CMPopTipView can point to any UIView subclass."
                },
                {
                    15, new UIImageView(UIImage.FromFile("appicon57.png"))
                },
                {
                    21, (NSString) "This CMPopTipView is pointing at a leftBarButtonItem of a navigationItem."
                },
                {
                    22, (NSString) "Two popup animations are provided: slide and pop. Tap other buttons to see them both."
                },
                {
                    31, (NSString) "CMPopTipView will automatically point at buttons either above or below the containing view."
                },
                {
                    32, (NSString) "The arrow is automatically positioned to point to the center of the target button."
                },
                {
                    33, (NSString) "CMPopTipView knows how to point automatically to UIBarButtonItems in both nav bars and tool bars."
                }
            };
            _Contents = NSDictionary.FromObjectsAndKeys(
                dict.Values.ToArray(),
                dict.Keys.Select((arg) => NSNumber.FromInt32(arg)).ToArray()
            );

            _Titles = NSDictionary<NSNumber, NSString>.FromObjectsAndKeys(
                new NSString[] {
                (NSString) "Title",
                (NSString) "Auto Orientation"
            },
                new NSNumber[] {
                NSNumber.FromInt32(14),
                NSNumber.FromInt32(12)
            }
            );

            var schemes = new(UIColor, UIColor)[] {
                (UIColor.Clear, UIColor.DarkTextColor),
                (UIColor.FromRGB(134/255, 74/255, 110/255), UIColor.White),
                (UIColor.DarkGray, UIColor.White),
                (UIColor.LightGray, UIColor.DarkTextColor),
                (UIColor.Orange, UIColor.Blue),
                (UIColor.FromRGB(220 / 255, 0.0f, 0.0f), UIColor.Yellow)
            };
            _ColorSchemes = schemes.Select( (arg) => new ColorScheme(arg.Item1, arg.Item2)).ToArray();
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void DismissAllPopTipViews()
        {
            while (_VisiblePopTipViews.Count != 0)
            {
                var popTipView = _VisiblePopTipViews[0];
                popTipView.DismissAnimated(true);
                _VisiblePopTipViews.Remove(popTipView);
            }
        }

        partial void DidTapOnButton(Foundation.NSObject sender)
        {
            DismissAllPopTipViews();

            if (sender == _CurrentPopTipViewTarget)
            {
                // Dismiss the popTipView and that is all
                _CurrentPopTipViewTarget = null;
            }
            else
            {
      

                NSString contentMessage = null;
                UIView contentView = null;
                NSNumber key = null;
                if (sender is UIView view) {
                    key = NSNumber.FromNInt(view.Tag);
                }
                else if (sender is UIBarButtonItem item) {
                    key = NSNumber.FromNInt(item.Tag);
                }
                else {
                    return;
                }
                var content = _Contents[key];
                if (content is UIView cview) {
                    contentView = cview;
                }
                else if (content is NSString str) {
                    contentMessage = str;
                }
                else {
                    contentMessage = (NSString) "A CMPopTipView can automatically point to any view or bar button item.";
                }
                var rand = new Random();
                var scheme = _ColorSchemes[rand.Next(0, _ColorSchemes.Length)];
                var title = _Titles[key];

                CMPopTipView popTipView = null;
                if (contentView != null) {
                    popTipView = new CMPopTipView(contentView);
                }
                else if (title != null) {
                    popTipView = new CMPopTipView(title, contentMessage);
                }
                else {
                    popTipView = new CMPopTipView(contentMessage);
                }

                popTipView.WeakDelegate = this;

                //         */
                //        //popTipView.shouldEnforceCustomViewPadding = YES;
                //        //popTipView.disableTapToDismiss = YES;
                //        //popTipView.preferredPointDirection = PointDirectionUp;
                //        //popTipView.hasGradientBackground = NO;
                //        //popTipView.cornerRadius = 2.0;
                //        //popTipView.sidePadding = 30.0f;
                //        //popTipView.topMargin = 20.0f;
                //        //popTipView.pointerSize = 50.0f;
                //        //popTipView.hasShadow = NO;

                popTipView.BackgroundColor = scheme.Item1;
                popTipView.TextColor = scheme.Item2;

                popTipView.Animation = (CMPopTipAnimation)rand.Next(0, 2);
          
                System.Diagnostics.Debug.WriteLine(popTipView.Animation);
                popTipView.Has3DStyle = rand.Next(0, 2) == 0 ? false : true;
                popTipView.HasGradientBackground = rand.Next(0, 2) == 0 ? false : true;

                popTipView.DismissTapAnywhere = true;
                popTipView.AutoDismissAnimated(true, 3.0);
                //popTipView.Layer.BackgroundColor = UIColor.Red.CGColor;

                if (sender is UIButton button) {
                        popTipView.PresentPointingAtView(button, View, true);

                }
                else if (sender is UIBarButtonItem item) {

                    popTipView.PresentPointingAtBarButtonItem(item, true);
                }

                _VisiblePopTipViews.Add(popTipView);
                _CurrentPopTipViewTarget = sender;
			}
        }

		[Export("popTipViewWasDismissedByUser:")]
        void PopTipViewWasDismissedByUser(CMPopTipView popTipView) {
            _VisiblePopTipViews.Remove(popTipView);
            _CurrentPopTipViewTarget = null;
        }

        public override void WillTransitionToTraitCollection(UITraitCollection traitCollection, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.WillTransitionToTraitCollection(traitCollection, coordinator);
			foreach (CMPopTipView popTipView in _VisiblePopTipViews) {
			    var targetObject = popTipView.TargetObject;
			    popTipView.DismissAnimated(false);
			    if (targetObject is UIButton button) {
			        popTipView.PresentPointingAtView(button, View, false);
			    }
			    else if (targetObject is UIBarButtonItem item) {
			        popTipView.PresentPointingAtBarButtonItem(item, false);
			    }
			}
		}

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);
			foreach (CMPopTipView popTipView in _VisiblePopTipViews)
			{
				var targetObject = popTipView.TargetObject;
				popTipView.DismissAnimated(false);
				if (targetObject is UIButton button)
				{
					popTipView.PresentPointingAtView(button, View, false);
				}
				else if (targetObject is UIBarButtonItem item)
				{
					popTipView.PresentPointingAtBarButtonItem(item, false);
				}
			}
        }
    }
}
