using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;

namespace TinTucCTSV.Data.Core
{
    public class DbContextSeed
    {   
        public static void Seed(IServiceProvider builder)
        {
            var context = builder.GetRequiredService<ApplicationDbContext>();

            if (!context.Forums.Any())
            {
                context.Forums.AddRange(forums.Select(c => c.Value));
            }
            if (!context.ApplicationUsers.Any())
            {
                context.ApplicationUsers.AddRange(users.Select(c => c.Value));
            }
            if (!context.Posts.Any())
            {
                context.AddRange
                (
                    new Post
                    {
                        Title = "Cập nhật thông tin cá nhân",
                        Content = "Yêu cầu các sinh viên cập nhật thông tin của mình",
                        Created = DateTime.Now,
                        NumberRead = 0,
                        Status = false,
                        Forum = forums["Thông báo cho sinh viên"],
                        User = users["cuong.infor@gmail.com"]
                    },
                    new Post
                    {
                        Title = "Không có thông báo mới",
                        Content = "Yêu cầu các sinh viên cập nhật thông tin của mình",
                        Created = DateTime.Now,
                        NumberRead = 0,
                        Status = false,
                        Forum = forums["Thông báo cho tân sinh viên"],
                        User = users["nguyencuong.infor@gmail.com"]
                    }
                );
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Forum> listForum;

        public static Dictionary<string, Forum> forums
        {
            get
            {
                if (listForum == null)
                {
                    var forumArray = new Forum[]
                    {
                        new Forum {Title = "Thông báo cho sinh viên",Description = "Chứa các thông báo chủ đề sinh viên",ImageUrl =@"\updated/images/mien-giam.png"},
                        new Forum {Title = "Thông báo cho tân sinh viên",Description = "Chứa các thông báo chủ đề sinh viên",ImageUrl =@"\updated/images/mien-giam.png"}
                    };

                    listForum = new Dictionary<string, Forum>();

                    foreach (Forum forum in forumArray)
                    {
                        listForum.Add(forum.Title, forum);
                    }
                }

                return listForum;
            }
        }

        private static Dictionary<string, ApplicationUser> listUsers;

        public static Dictionary<string, ApplicationUser> users
        {
            get
            {
                if (listUsers == null)
                {
                    var userArray = new ApplicationUser[]
                    {
                        new ApplicationUser
                        {
                            UserName = "nguyencuong.infor@gmail.com",
                            Email ="nguyencuong.infor@gmail.com",
                            FirstName = "Cường",
                            LastName = "Nguyễn",
                            EmailConfirmed = true,
                            IsActive = true,
                            Rating = 0 ,
                            MemberSince = DateTime.Now,
                            PhoneNumber = "0353599096",
                            ProfileImageUrl = "default.jpg",
                            SecurityStamp = Guid.NewGuid().ToString(),
                            PasswordHash = "08221997Ad@"
                },
                        new ApplicationUser
                        {
                            UserName = "cuong.infor@gmail.com",
                            Email = "cuong.infor@gmail.com",
                            FirstName = "Nam",
                            LastName = "Nguyễn",
                            EmailConfirmed = true,
                            IsActive = true,
                            Rating = 0 ,
                            MemberSince = DateTime.Now,
                            PhoneNumber = "0353599096",
                            ProfileImageUrl = "default.jpg",
                            SecurityStamp = Guid.NewGuid().ToString(),
                            PasswordHash = "08221997Ad@"
                        }
                    };

                    listUsers = new Dictionary<string, ApplicationUser>();

                    foreach (ApplicationUser user in userArray)
                    {
                        listUsers.Add(user.UserName, user);
                    }
                }

                return listUsers;
            }
        }
    }
}
