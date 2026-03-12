
using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;

namespace Facebook.Core.FBPosts;

public class FB_PhotoPost : FB_Post //FB_Post-oos udamshij baina
{
    public FB_PhotoPost(FB_User postAuthor, string postContent, string photoUrl) //hen bichsen text zurgiin url 3n parameter avna 
        : base(postAuthor, postContent) //base class FB_Postiin constructoriig duudaj baina
    {
        PhotoUrl = photoUrl; //photopostd nemegdsen shine propertyg initialize hiij baina
    }

    public string PhotoUrl { get; } //zurgiin link hadgalna

    public override string ToString() //objectiig string bolgoh method
    {
        return $"📷 {PostAuthor.UserName}: {PostContent} [Зураг: {PhotoUrl}] (Likes: {LikeCount})"; //base classaas uvlusun zuilsiig ashiglaj baina
    }
}