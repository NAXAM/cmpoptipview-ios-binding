using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace CMPopTip
{
	[BaseType(typeof(UIView))]
	interface CMPopTipView
	{
		//// @property (nonatomic, strong) UIColor * backgroundColor;
		//[Export("backgroundColor", ArgumentSemantic.Strong)]
		//UIColor BackgroundColor { get; set; }

		[Wrap("WeakDelegate")]
		CMPopTipViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<CMPopTipViewDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL disableTapToDismiss;
		[Export("disableTapToDismiss")]
		bool DisableTapToDismiss { get; set; }

		// @property (assign, nonatomic) BOOL dismissTapAnywhere;
		[Export("dismissTapAnywhere")]
		bool DismissTapAnywhere { get; set; }

		// @property (nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * message;
		[Export("message", ArgumentSemantic.Strong)]
		string Message { get; set; }

		// @property (nonatomic, strong) UIView * customView;
		[Export("customView", ArgumentSemantic.Strong)]
		UIView CustomView { get; set; }

		// @property (readonly, nonatomic, strong) id targetObject;
		[Export("targetObject", ArgumentSemantic.Strong)]
		NSObject TargetObject { get; }

		// @property (nonatomic, strong) UIColor * titleColor;
		[Export("titleColor", ArgumentSemantic.Strong)]
		UIColor TitleColor { get; set; }

		// @property (nonatomic, strong) UIFont * titleFont;
		[Export("titleFont", ArgumentSemantic.Strong)]
		UIFont TitleFont { get; set; }

		// @property (nonatomic, strong) UIColor * textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) UIFont * textFont;
		[Export("textFont", ArgumentSemantic.Strong)]
		UIFont TextFont { get; set; }

		// @property (assign, nonatomic) UITextAlignment titleAlignment;
		[Export("titleAlignment", ArgumentSemantic.Assign)]
		UITextAlignment TitleAlignment { get; set; }

		// @property (assign, nonatomic) UITextAlignment textAlignment;
		[Export("textAlignment", ArgumentSemantic.Assign)]
		UITextAlignment TextAlignment { get; set; }

		// @property (assign, nonatomic) BOOL has3DStyle;
		[Export("has3DStyle")]
		bool Has3DStyle { get; set; }

		// @property (nonatomic, strong) UIColor * borderColor;
		[Export("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat cornerRadius;
		[Export("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (assign, nonatomic) CGFloat borderWidth;
		[Export("borderWidth")]
		nfloat BorderWidth { get; set; }

		// @property (assign, nonatomic) BOOL hasShadow;
		[Export("hasShadow")]
		bool HasShadow { get; set; }

		// @property (assign, nonatomic) CMPopTipAnimation animation;
		[Export("animation", ArgumentSemantic.Assign)]
		CMPopTipAnimation Animation { get; set; }

		// @property (assign, nonatomic) CGFloat maxWidth;
		[Export("maxWidth")]
		nfloat MaxWidth { get; set; }

		// @property (assign, nonatomic) PointDirection preferredPointDirection;
		[Export("preferredPointDirection", ArgumentSemantic.Assign)]
		PointDirection PreferredPointDirection { get; set; }

		// @property (assign, nonatomic) BOOL hasGradientBackground;
		[Export("hasGradientBackground")]
		bool HasGradientBackground { get; set; }

		// @property (assign, nonatomic) CGFloat sidePadding;
		[Export("sidePadding")]
		nfloat SidePadding { get; set; }

		// @property (assign, nonatomic) CGFloat topMargin;
		[Export("topMargin")]
		nfloat TopMargin { get; set; }

		// @property (assign, nonatomic) CGFloat pointerSize;
		[Export("pointerSize")]
		nfloat PointerSize { get; set; }

		// @property (assign, nonatomic) CGFloat bubblePaddingX;
		[Export("bubblePaddingX")]
		nfloat BubblePaddingX { get; set; }

		// @property (assign, nonatomic) CGFloat bubblePaddingY;
		[Export("bubblePaddingY")]
		nfloat BubblePaddingY { get; set; }

		// @property (assign, nonatomic) BOOL dismissAlongWithUserInteraction;
		[Export("dismissAlongWithUserInteraction")]
		bool DismissAlongWithUserInteraction { get; set; }

		// -(id)initWithTitle:(NSString *)titleToShow message:(NSString *)messageToShow;
		[Export("initWithTitle:message:")]
		IntPtr Constructor(string titleToShow, string messageToShow);

		// -(id)initWithMessage:(NSString *)messageToShow;
		[Export("initWithMessage:")]
		IntPtr Constructor(string messageToShow);

		// -(id)initWithCustomView:(UIView *)aView;
		[Export("initWithCustomView:")]
		IntPtr Constructor(UIView aView);

		// -(void)presentPointingAtView:(UIView *)targetView inView:(UIView *)containerView animated:(BOOL)animated;
		[Export("presentPointingAtView:inView:animated:")]
		void PresentPointingAtView(UIView targetView, UIView containerView, bool animated);

		// -(void)presentPointingAtBarButtonItem:(UIBarButtonItem *)barButtonItem animated:(BOOL)animated;
		[Export("presentPointingAtBarButtonItem:animated:")]
		void PresentPointingAtBarButtonItem(UIBarButtonItem barButtonItem, bool animated);

		// -(void)dismissAnimated:(BOOL)animated;
		[Export("dismissAnimated:")]
		void DismissAnimated(bool animated);

		// -(void)autoDismissAnimated:(BOOL)animated atTimeInterval:(NSTimeInterval)timeInterval;
		[Export("autoDismissAnimated:atTimeInterval:")]
		void AutoDismissAnimated(bool animated, double timeInterval);

		// -(PointDirection)getPointDirection;
		[Export("getPointDirection")]
		//[Verify(MethodToProperty)]
		PointDirection PointDirection { get; }
	}



	// @protocol CMPopTipViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface CMPopTipViewDelegate
	{
		// @required -(void)popTipViewWasDismissedByUser:(CMPopTipView *)popTipView;
		[Abstract]
		[Export("popTipViewWasDismissedByUser:")]
		void PopTipViewWasDismissedByUser(CMPopTipView popTipView);
	}

	//[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	//partial interface Constants
	//{
	//	// extern double CMPopTipViewVersionNumber;
	//	[Field("CMPopTipViewVersionNumber", "__Internal")]
	//	double CMPopTipViewVersionNumber { get; }

	//	// extern const unsigned char [] CMPopTipViewVersionString;
	//	[Field("CMPopTipViewVersionString", "__Internal")]
	//	byte[] CMPopTipViewVersionString { get; }
	//}
}
