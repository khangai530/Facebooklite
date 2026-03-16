using Facebook.Core.FBUsers;
using Facebook.Core.FBPosts;
using Facebook.Core.FBComments;
using Facebook.Core.FBRepos;
using Facebook.Core.FBServices;

namespace Facebook.ConsoleApp; //san uusgej baina 

class Program //console appiin undsen class
{
    static void Main(string[] args)
    {
        Console.WriteLine("FACEBOOK LITE");
         
        var postRepo = new FB_MemoryRepo<FB_Post>(); //postuudiig hadgalah dan uusgej baina tur sanah oid ugugdul hadgaldag repository
        var postService = new FB_PostService(postRepo);

        var bold = new FB_StoryUser("Bold", "bold@facebook.com", 25);
        var tuya = new FB_StoryUser("Tuya", "tuya@facebook.com", 24);
        var bat = new FB_StoryUser("Bat", "bat@facebook.com", 30);

        var users = new List<FB_StoryUser> { bold, tuya, bat };

        Console.WriteLine("Users: Bold, Tuya, Bat");
        Console.WriteLine("Commands:");
        Console.WriteLine("addpost username \"text\"");
        Console.WriteLine("like postId username");
        Console.WriteLine("comment postId username \"text\"");
        Console.WriteLine("show");
        Console.WriteLine("exit");

        while (true) //user exit bichih hurtel ajillana 
        {
            Console.Write("\n> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            if (input.ToLower() == "exit")
                break;

            var parts = input.Split(' '); //user input zadlana

            try
            {
                switch (parts[0].ToLower())
                {
                    case "addpost":
                        {
                            var username = parts[1];
                            var text = input.Substring(input.IndexOf('"') + 1);
                            text = text.Substring(0, text.LastIndexOf('"'));

                            var user = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                            if (user == null)
                            {
                                Console.WriteLine("User not found.");
                                break;
                            }

                            var post = postService.CreatePost(user, text);
                            Console.WriteLine($"Post created. ID: {post.Id}");
                            break;
                        }

                    case "like":
                        {
                            var postId = parts[1];
                            var username = parts[2];

                            var user = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                            if (user == null)
                            {
                                Console.WriteLine("User not found.");
                                break;
                            }

                            postService.LikePost(postId, user.UserId);
                            Console.WriteLine("Post liked.");
                            break;
                        }

                    case "comment":
                        {
                            var postId = parts[1];
                            var username = parts[2];

                            var text = input.Substring(input.IndexOf('"') + 1);
                            text = text.Substring(0, text.LastIndexOf('"'));

                            var user = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                            if (user == null)
                            {
                                Console.WriteLine("User not found.");
                                break;
                            }

                            var comment = new FB_Comment(user, text);
                            postService.AddComment(postId, comment);
                            Console.WriteLine("Comment added.");
                            break;
                        }

                    case "show":
                        {
                            postService.ShowAllPosts();
                            break;
                        }

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid command format.");
            }
        }

        Console.WriteLine("Program ended.");
    }
}
