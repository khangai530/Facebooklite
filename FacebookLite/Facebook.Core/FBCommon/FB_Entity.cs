using Facebook.Core.FBCommon; 

namespace Facebook.Core.FBCommon;

public abstract class FB_Entity
{
    protected FB_Entity() //zuvhun udamshsan class dotroos duudagdana
    {
        Id = Guid.NewGuid().ToString(); //davtagdashgui id uusgene
        CreatedAt = DateTime.UtcNow; //entity uuseh uyd timestamp avna
    }

    public string Id { get; } //zuvhun constructor deeer utga avna
    public DateTime CreatedAt { get; } //uussen ognoo
    public DateTime? UpdatedAt { get; protected set; } //entity uusgesnees hoish uurchlugduh bolomjtoi, gehdee zuvhun udamshsan class dotroos uurchlugduh bolomjtoi
}