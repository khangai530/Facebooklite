using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;
using Facebook.Core.FBCommon;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBPosts;

public class FB_StoryPost : FB_Post //FB_Post-oos udamshij baina
{
    public FB_StoryPost(FB_User postAuthor, string postContent)
        : base(postAuthor, postContent) //2 parameter avna, base classaas constructoriig duudaj initialize hiij baina
    {
        ExpiresAt = CreatedAt.AddHours(24); //story expiration time 24 tsag baigaa, CreatedAt ni FB_Entity classaas uvlunu
    }

    public DateTime ExpiresAt { get; } //readonly story hezee duusahig hadgalna

    public bool IsExpired => DateTime.UtcNow > ExpiresAt; //story duussan esehiig shalgah property, current time ExpiresAt-aas ih bolson esehiig butsaana

    public override string ToString() //base classiin tostring-g override hiij baina
    {
        string status = IsExpired ? "❌ Дууссан" : $"⏳ Дуусах: {ExpiresAt:HH:mm}";
        return $"📱 Story - {PostAuthor.UserName}: {PostContent} {status}";
    }
}