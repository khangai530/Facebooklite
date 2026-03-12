using Facebook.Core.FBCommon;  

namespace Facebook.Core.FBCommon;

public interface FB_ILikeable
{
    void AddLike(string userId); //like nemeh
    int LikeCount { get; } //like toog gargah
}