using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBComments;

public interface FB_ICommentActions : FB_ILikeable //FB_ILikeableg uvlunu 
{ //comment ni like darj boldog object
    FB_User CommentAuthor { get; } //zuvhun unshih bolomjtoi comment hen bichseniig ni medej baih ystoi
    string CommentText { get; } //comment ymar textteig medej baih ystoi
}