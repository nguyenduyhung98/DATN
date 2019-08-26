using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Data.Core
{
    public class DataStatic
    {
        private const string default_password_admin = "08221997Ad@";
        private const string default_password_manager = "08221997Ad@";
        private const string default_password_student = "08221997Ad@";

        private const string name_admin = "cuong";
        private const string name_manager = "hung";
        private const string name_student = "minh";

        private const string forum_student = "Thông báo cho sinh viên";
        private const string forum_newstudent = "Thông báo cho tân sinh viên";
        private const string forum_images = "images/mien-giam.png";

        private const string post_title_one = "What is Lorem Ipsum?";
        private const string post_title_two = "Where does it come from?";

        private const string post_content_one = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string post_content_two = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum(The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.";

        private const string comment_content_one = "Where can I get some?";
        private const string comment_content_two = "Where can I get some?";

        static readonly CultureInfo culture = CultureInfo.InvariantCulture;

        public static IEnumerable<ApplicationUser> AdminData(ApplicationDbContext context)
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser{UserName = name_admin,Email = "admin@gmail.com",PhoneNumber ="0353599096",SecurityStamp= Guid.NewGuid().ToString(),
                    EmailConfirmed = true, IsActive = true,Rating =0, MemberSince = DateTime.ParseExact("10/06/1998", "dd/MM/yyyy", culture),
                    ProfileImageUrl = "https://pickaface.net/gallery/avatar/unr_preson_170219_0852_z1izj.png"},

                new ApplicationUser{UserName = name_manager,Email = "manager@gmail.com",PhoneNumber ="0353599096",SecurityStamp= Guid.NewGuid().ToString(),
                    EmailConfirmed = true, IsActive = true,Rating =0, MemberSince = DateTime.ParseExact("10/06/1998", "dd/MM/yyyy", culture),
                    ProfileImageUrl = "https://pickaface.net/gallery/avatar/unr_preson_170219_0852_z1izj.png"},

                new ApplicationUser{UserName = name_student,Email = "student@gmail.com",PhoneNumber ="0353599096",SecurityStamp= Guid.NewGuid().ToString(),
                    EmailConfirmed = true, IsActive = true,Rating =0, MemberSince = DateTime.ParseExact("10/06/1998", "dd/MM/yyyy", culture),
                    ProfileImageUrl = "https://pickaface.net/gallery/avatar/unr_preson_170219_0852_z1izj.png"}
            };
        }
        public static IEnumerable<Forum> ForumData(ApplicationDbContext context)
        {
            return new List<Forum>()
            {
                new Forum
                {
                    Title = forum_student, Description = forum_student ,ImageUrl = forum_images
                },
                new Forum
                {
                    Title = forum_newstudent, Description = forum_newstudent ,ImageUrl = forum_images
                }
            };
        }

        public static IEnumerable<Post> PostData(ApplicationDbContext context)
        {
            return new List<Post>()
            {
                new Post
                {
                    Title = post_title_one, Content = post_content_one, Created = DateTime.Now, NumberRead = 0
                },
                new Post
                {
                    Title = post_content_two, Content = post_content_two, Created = DateTime.Now, NumberRead = 0
                }
            };
        }

        public static IEnumerable<PostReply> PostRepliesData(ApplicationDbContext context)
        {
            return new List<PostReply>()
            {
                new PostReply
                {
                    Content = comment_content_one
                },
                 new PostReply
                {
                    Content = comment_content_two
                }
            };
        }
    }
}
