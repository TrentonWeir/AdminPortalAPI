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
                    UserId = 2
                },
                new(){
                    UserId = 3
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
                    UserName = "tweir12",
                    Email = "tweir12@ivytech.edu",
                    Password = "TotalySecure->&Stuff"
                },
                new(){
                    FName = "Macey",
                    LName = "Panaro",
                    UserName = "mpanaro",
                    Email = "mpanaro@ivytech.edu",
                    Password = "Password123"
                },
                new(){
                    FName = "Ella",
                    LName = "Sepetjian",
                    UserName = "eseptjian",
                    Email = "eseptjian@ivytech.edu",
                    Password = "Password123"
                },
                new(){
                    FName = "Bradley",
                    LName = "Harrison",
                    UserName = "bharrison",
                    Email = "bharrison@ivytech.edu",
                    Password = "Password123"
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
                    FName = "Senpai",
                    LName = "Ahhh",
                    UserName = "scream",
                    Email = "scream@to-many.com",
                    Password = "Password123"
                },
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }

    
}