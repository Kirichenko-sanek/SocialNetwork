using System;
using SocialNetwork.Core;
using AutoMapper;
using SocialNetwork.WEB.ViewModels;

namespace SocialNetwork.WEB.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.CreateMap<User, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, User>();
            Mapper.CreateMap<User, MyPageViewModel>().AfterMap((p, m) =>
            {
                m.Name = p.first_name + " " + p.last_name;
                m.Photo = p.Photo.name;
                m.IdUserInSystem = p.Id;
            });

            Mapper.CreateMap<Post, PostViewModel>().AfterMap((p, m) =>
            {
                
                m.PhotoPost = p.Photo.name;
                m.DescriptionPost = p.description;
                m.DatePost = Convert.ToString(p.date);
                m.NameUser = p.User.first_name + " " + p.User.last_name;
            });
            Mapper.CreateMap<AddPostViewModel, Post>();

            Mapper.CreateMap<Post, EditPostViewModel>().AfterMap((p, m) =>
            {
                m.ID = p.Id;
                m.Description = p.description;
            });
            Mapper.CreateMap<User, EditProfileViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.Id;
                m.FirstName = p.first_name;
                m.LastName = p.last_name;
                m.Email = p.email;
            });
            Mapper.CreateMap<EditProfileViewModel, User>().AfterMap((p, m) =>
            {
                m.first_name = p.FirstName;
                m.last_name = p.LastName;
                m.email = p.Email;
            });
            Mapper.CreateMap<User, PageFriendViewModel>();
            Mapper.CreateMap<User, FriendViewModel>().AfterMap((p, m) =>
            {
                m.Id = p.Id;
                m.Name = p.first_name + " " + p.last_name;
                m.Photo = p.Photo.name;
            });
        }
    }
}