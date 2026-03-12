using Facebook.Core.FBCommon;
using Facebook.Core.FBComments;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBPosts;

public abstract class FB_Post : FB_Entity, FB_IPostActions
{
    public string Content { get; set; }
    private readonly List<FB_Comment> _comments = new(); //post deerh buh comment hadgalna
    private readonly List<string> _likedBy = new();  //like darsan hereglegchiiin ID

    protected FB_Post(FB_User postAuthor, string postContent) //zuvhun udamahsan class duudaj chadna
    {
        PostAuthor = postAuthor; //hen bichsen
        PostContent = postContent; //ymar post
    }

    public FB_User PostAuthor { get; } //post uussenii daraa author uurchlugduhgui
    public string PostContent { get; } //content uurchlugduhgui

    // FB_ILikeable
    public int LikeCount => _likedBy.Count; //likeiin toog butsaana
    public void AddLike(string userId) //like nemeh method
    {
        if (!_likedBy.Contains(userId)) //duplicate like hamgaalalt
        {
            _likedBy.Add(userId); //like nemlee
            Console.WriteLine($"👍 {PostAuthor.UserName}-ийн постод like дарлаа");
        }
    }

    // FB_IPostActions
    public IReadOnlyList<FB_Comment> PostComments => _comments.AsReadOnly(); //encapsulation

    public void AddComment(FB_Comment comment) //comment nemeh method
    {
        _comments.Add(comment); //comment listd nemne
        UpdatedAt = DateTime.UtcNow; //entity update bolson tul timestamp shinechilj baina
        Console.WriteLine($"💬 {comment.CommentAuthor.UserName} коммент үлдээв: {comment.CommentText}");
    }

    public int ShareCount { get; private set; } //shareiin too

    public void SharePost(string userId) //post share hiih method
    {
        ShareCount++; //share toolno
        Console.WriteLine($"🔄 {userId} постыг түгээв");
    }
}