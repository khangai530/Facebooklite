using Facebook.Core.FBCommon;
using Facebook.Core.FBUsers;

namespace Facebook.Core.FBComments;

public class FB_Comment : FB_Entity, FB_ILikeable //FB_Entity-gees udamshij baina
{
    private readonly List<string> _likedBy = new(); //like darsan useruudiin IDg hadgalna

    public FB_Comment(FB_User commentAuthor, string commentText) //comment bichih uyd hen ymar text bichseniig ugnu
    {
        CommentAuthor = commentAuthor;
        CommentText = commentText;
    }

    public FB_User CommentAuthor { get; } //comment buchsen hunii id uurchlugduhgui
    public string CommentText { get; } //comment bichsenii daraa text uurchlugduhgui

    public int LikeCount => _likedBy.Count; //like darsan hunii too butsaana

    public void AddLike(string userId) //like ugn
    {
        if (!_likedBy.Contains(userId)) //umnu ni like daraagui bol
        {
            _likedBy.Add(userId); //listd nemne
            Console.WriteLine($"{CommentAuthor.UserName}-ийн комментод like дарлаа");
        }
    }
}