using Facebook.Core.FBCommon;
using Facebook.Core.FBPosts;

namespace Facebook.Core.FBUsers;

public class FB_StoryUser : FB_User
{
    public FB_StoryUser(string userName, string userEmail, byte userAge)
        : base(userName, userEmail, userAge)
    { }

    //hereglegchiin storynuud
    public List<FB_StoryPost> UserStories { get; } = new();

    public FB_StoryPost AddStory(string storyContent) //shine story nemeh method, story content avna, shine story object uusgej UserStories listd nemne, uusgesen story-g butsaana
    {
        var story = new FB_StoryPost(this, storyContent);
        UserStories.Add(story);
        return story;
    }

    public List<FB_StoryPost> GetActiveStories() //idevhtei story-g butsaah method, UserStories listd shalgana,
    {
        return UserStories.Where(s => !s.IsExpired).ToList(); //hugatsaa ni duusaagui storynuud
    }

    public int StoryCount => UserStories.Count; //storynuudiin too

    public int ActiveStoryCount => UserStories.Count(s => !s.IsExpired); //idevhtei storynuudiin too
}