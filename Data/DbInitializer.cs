using AdminPortal.Entities;

namespace AdminPortal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context){
            initUsers(context);
            initAdmins(context);

        }
        public static void initAdmins(UserContext ctx){
            if(ctx.Admins.Any()) return;
            List<AdminDTO> admins = new(){
                new(){
                    UserId = 1
                },
                new(){
                    UserId = 4
                }
            };
            ctx.Admins.AddRange(admins);
            ctx.SaveChanges();
        }
        public static void initUsers(UserContext context){
        if(context.Users.Any()) return;

            List<UserDTO> users = new(){
                new(){
                    FName = "Trenton",
                    LName = "Weir",
                    UserName = "tweir12@ivytech.edu",
                    Email = "tweir12@ivytech.edu",
                    Password = "TotalySecure->&Stuff"
                },
                new(){
                    FName = "Random 1",
                    LName = "ELA",
                    UserName = "rando.1",
                    Email = "something@gmail.com",
                    Password = "Password123"
                },
                new(){
                    FName = "New Guy",
                    LName = "Broski",
                    UserName = "broskiiiii",
                    Email = "broski@acompany.com",
                    Password = "Password123"
                },
                new(){
                    FName = "Hello Senpai",
                    LName = "Ahhh",
                    UserName = "ella",
                    Email = "scream@to-many.com",
                    Password = "Password123"
                },
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }

    
}