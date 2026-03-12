using Facebook.Core.FBCommon;

namespace Facebook.Core.FBUsers;

public abstract class FB_User : FB_Entity
{
    private readonly byte _userAge; //nas hadgalj baina

    protected FB_User(string userName, string userEmail, byte userAge)
    {
        UserName = userName; //user uuseh uyd onoono
        UserEmail = userEmail;
        _userAge = userAge;
    }

    public string UserName { get; } //user uussenii daraa ner uurchlugduhgui
    public string UserEmail { get; }
    public byte UserAge => _userAge; //private fieldiig gadagc=sh unshih bolomj olgoj baina
    public string UserId //id userid hoyr neg ym butsaana
    {
        get { return Id; }
    }
    public bool IsActive { get; set; } = true;  //user idevhtei esehiig hadgalna 
}