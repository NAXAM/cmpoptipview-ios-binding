CMPopTipView - Xamarin iOS Binding Library
============

An iOS UIView subclass that displays a rounded rect "bubble", containing
a text message, pointing at a specified button or view.

A CMPopTipView will automatically position itself within the view so that
it is pointing at the specified button or view, positioning the "pointer"
as necessary.

A CMPopTipView can be pointed at any UIView within the containing view.
It can also be pointed at a UIBarButtonItem within either a UINavigationBar
or a UIToolbar and it will automatically position itself to point at the
target.

The background and text colors can be customised if the defaults are not
suitable.

Two animation options are available for when a CMPopTipView is presented:
"slide" and "pop".

A CMPopTipView can be dismissed by the user tapping on it.  It can also
be dismissed programatically.

CMPopTipView is rendered entirely by Core Graphics.

Screenshots
-----------

![](http://farm5.static.flickr.com/4005/5191641030_2b93a4a559.jpg)
![](http://farm5.static.flickr.com/4112/5191046667_109a98dfc7.jpg)
![](http://farm6.static.flickr.com/5170/5266199718_4720c56384.jpg)


Videos
------

http://www.youtube.com/watch?v=nul9VA_QsGI


Usage
-----

Example 1 - point at a UIBarButtonItem in a nav bar:

```objc
// Present a CMPopTipView pointing at a UIBarButtonItem in the nav bar
CMPopTipView *navBarLeftButtonPopTipView = [[CMPopTipView alloc] initWithMessage:@"A Message"];
navBarLeftButtonPopTipView.delegate = self;
[navBarLeftButtonPopTipView presentPointingAtBarButtonItem:self.navigationItem.leftBarButtonItem animated:YES];

// Dismiss a CMPopTipView
[navBarLeftButtonPopTipView dismissAnimated:YES];

// CMPopTipViewDelegate method
- (void)popTipViewWasDismissedByUser:(CMPopTipView *)popTipView {
    // any code
}
```


Example 2 - pointing at a UIButton, with custom color scheme::

```objc
- (IBAction)buttonAction:(id)sender {
    // Toggle popTipView when a standard UIButton is pressed
    if (nil == self.roundRectButtonPopTipView) {
        self.roundRectButtonPopTipView = [[CMPopTipView alloc] initWithMessage:@"My message"];
        self.roundRectButtonPopTipView.delegate = self;
        self.roundRectButtonPopTipView.backgroundColor = [UIColor lightGrayColor];
        self.roundRectButtonPopTipView.textColor = [UIColor darkTextColor];

        UIButton *button = (UIButton *)sender;
        [self.roundRectButtonPopTipView presentPointingAtView:button inView:self.view animated:YES];
    }
    else {
        // Dismiss
        [self.roundRectButtonPopTipView dismissAnimated:YES];
        self.roundRectButtonPopTipView = nil;
    }
}

#pragma mark CMPopTipViewDelegate methods
- (void)popTipViewWasDismissedByUser:(CMPopTipView *)popTipView {
    // User can tap CMPopTipView to dismiss it
    self.roundRectButtonPopTipView = nil;
}
```

Available Options
-----

* **id < CMPopTipViewDelegate >**	delegate
* **UIColor** 					*backgroundColor
* **BOOL** 						disableTapToDismiss
* **BOOL** 						dismissTapAnywhere
* **NSString**					*title
* **NSString**					*message
* **UIView**	                *customView
* **id**							targetObject
* **UIColor**					*titleColor
* **UIFont**						*titleFont
* **UIColor**					*textColor
* **UIFont**						*textFont
* **NSTextAlignment**			titleAlignment
* **NSTextAlignment**			textAlignment
* **BOOL**                    has3DStyle
* **UIColor**					*borderColor
* **CGFloat**                cornerRadius
* **CGFloat**					borderWidth
* **BOOL**                    hasShadow
* **CMPopTipAnimation**       animation
* **CGFloat**                 maxWidth
* **PointDirection**          preferredPointDirection
* **BOOL**                    hasGradientBackground
* **CGFloat**                 sidePadding
* **CGFloat**                 topMargin
* **CGFloat**                 pointerSize
* **CGFloat**                 bubblePaddingX
* **CGFloat**                 bubblePaddingY
* **BOOL**        	          dismissAlongWithUserInteraction
