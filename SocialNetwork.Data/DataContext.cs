using System;
using System.Collections.Generic;
using System.Data.Entity;
using SocialNetwork.Core;
using SocialNetwork.Data.Mapping;
using SocialNetwork.PasswordHashing;
using System.Text;

namespace SocialNetwork.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Comments> Commentses { get; set; }
        public DbSet<Friends> Friendses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Roles> Roleses { get; set; }
        public DbSet<User> Useres { get; set; }
        public DbSet<UserInRoles> UserInRoleses { get; set; }

        public DataContext() : base("SocialNetworkConnectionString")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new SocialNetworkInitializer());
        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentsMap());
            modelBuilder.Configurations.Add(new FriendsMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new RolesMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserInRolesMap());
        }

        private class SocialNetworkInitializer : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                var roles = new List<Roles>
                {
                    new Roles()
                    {
                        name = "Admin"
                    },
                    new Roles()
                    {
                        name = "User"
                    }
                };
                foreach (var role in roles) context.Roleses.Add(role);
                context.SaveChanges();

                var photos = new List<Photo>
                {
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_373959066.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374391155.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374391198.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374514532.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374631823.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374639016.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-51175007_374639053.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373720989.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373820075.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373927036.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373935359.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373938789.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40836944_373952453.jpg"
                    },
                    new Photo()
                    {
                        name = "~/images/Posts/-40931437_374535488.jpg"
                    }
                    
                };
                foreach (var photo in photos) context.Photos.Add(photo);
                context.SaveChanges();

                
                var salt = PasswordHashing.PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.PasswordHashing.HashPassword("123456", salt); 
                var useres = new List<User>
                {
                    new User()
                    {
                        first_name = "Kirichenko",
                        last_name = "Alexandr",
                        email = "kirichenko-sanek@mail.ru",
                        password = pass,
                        is_activated = true,
                        password_salt = salt,
                        Photo = new Photo { name = "~/images/UploadImages/-83285336_371954164.jpg"},
                        Useres = new List<UserInRoles>(){new UserInRoles(){id_roles = 1, id_user = 1}}
                    },
                    new User()
                    {
                        first_name = "Сергей",
                        last_name = "Серков",
                        email = "serkov@trty.ru",
                        password = pass,
                        is_activated = true,
                        password_salt = salt,
                        Photo = new Photo { name = "~/images/UploadImages/-46411836_373475505.jpg"},
                        Useres = new List<UserInRoles>(){new UserInRoles(){id_roles = 2, id_user = 2}}
                    },
                    new User()
                    {
                        first_name = "Дарья",
                        last_name = "Спивак",
                        email = "spivak@trty.ru",
                        password = pass,
                        is_activated = true,
                        password_salt = salt,
                        Photo = new Photo { name = "~/images/UploadImages/-83285336_371849654.jpg"},
                        Useres = new List<UserInRoles>(){new UserInRoles(){id_roles = 2, id_user = 3}}
                    },
                    new User()
                    {
                        first_name = "Дмитрий",
                        last_name = "Земляк",
                        email = "zemlyk@trty.ru",
                        password = pass,
                        is_activated = true,
                        password_salt = salt,
                        Photo = new Photo { name = "~/images/UploadImages/-46411836_373243946.jpg"},
                        Useres = new List<UserInRoles>(){new UserInRoles(){id_roles = 2, id_user = 4}}
                    }
                };
                foreach (var user in useres) context.Useres.Add(user);
                context.SaveChanges();

                var posts = new List<Post>
                {
                    new Post()
                    {
                        id_user = 1,
                        id_photo = 1,
                        description = "Post 1",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 1,
                        id_photo = 2,
                        description = "Post 2",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 1,
                        id_photo = 3,
                        description = "Post 3",
                        date = DateTime.Now
                    },

                    new Post()
                    {
                        id_user = 2,
                        id_photo = 4,
                        description = "Post 1",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 2,
                        id_photo = 5,
                        description = "Post 2",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 2,
                        id_photo = 6,
                        description = "Post 3",
                        date = DateTime.Now
                    },

                    new Post()
                    {
                        id_user = 3,
                        id_photo = 7,
                        description = "Post 1",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 3,
                        id_photo = 8,
                        description = "Post 2",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 3,
                        id_photo = 9,
                        description = "Post 3",
                        date = DateTime.Now
                    },

                    new Post()
                    {
                        id_user = 4,
                        id_photo = 10,
                        description = "Post 1",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 4,
                        id_photo = 11,
                        description = "Post 2",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 4,
                        id_photo = 12,
                        description = "Post 3",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 4,
                        id_photo = 13,
                        description = "Post 4",
                        date = DateTime.Now
                    },
                    new Post()
                    {
                        id_user = 4,
                        id_photo = 14,
                        description = "Post 5",
                        date = DateTime.Now
                    }
                };
                foreach (var post in posts) context.Posts.Add(post);
                context.SaveChanges();

                var friends = new List<Friends>
                {
                    new Friends() {id_user = 1, id_friend = 2},
                    new Friends() {id_user = 1, id_friend = 3},
                    new Friends() {id_user = 1, id_friend = 4},
                    new Friends() {id_user = 2, id_friend = 1},
                    new Friends() {id_user = 2, id_friend = 3},
                    new Friends() {id_user = 2, id_friend = 4},
                    new Friends() {id_user = 3, id_friend = 1},
                    new Friends() {id_user = 3, id_friend = 2},
                    new Friends() {id_user = 3, id_friend = 4},
                    new Friends() {id_user = 4, id_friend = 1},
                    new Friends() {id_user = 4, id_friend = 2},
                    new Friends() {id_user = 4, id_friend = 3}
                };
                foreach (var friend in friends) context.Friendses.Add(friend);
                context.SaveChanges();

                base.Seed(context);
            }

        }
    }
}
