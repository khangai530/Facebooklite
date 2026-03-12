using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBPosts;

public interface FB_IPostActions : FB_ILikeable
{
	void AddComment(FB_Comment comment); //post deer comment nemeh method
	void SharePost(string userId); //postiig share hiih method
	IReadOnlyList<FB_Comment> PostComments { get; } //commentuudiig gadagsh unshih bolomjtoi bolgono
	int ShareCount { get; } //share-iin too
}