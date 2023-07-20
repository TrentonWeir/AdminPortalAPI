using AdminPortal.Entities;

namespace AdminPortal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context){
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