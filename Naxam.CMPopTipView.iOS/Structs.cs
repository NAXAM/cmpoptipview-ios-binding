using System;
using ObjCRuntime;

namespace CMPopTip
{
    [Native]
public enum PointDirection : long
{
    Any = 0,
    Up,
    Down
}

[Native]
public enum CMPopTipAnimation : long
{
    Slide = 0,
    Pop
}
}
