# Pizza Planet (MVC Edition C#)

## Prerequisites
### Download XAMPP
1. If you do not have it installed already, please install XAMPP. You can do so by going to by clicking this link https://www.apachefriends.org/
2. Follow the onscreen directions to install the program.
3. Once it is installed, run the XAMPP application. (It is recommended that you are an administrator)

### Creating the Pizza Planet database
1. Click the "Start" button beside "Apache" and "MySQL".
2. Click the "Admin" button beside "MySQL", it will take you to the phpMyAdmin website.
3. Click the "New" link  on the left sidebar
4. Type "pizzaplanet" (not case-sensitive) in the "Database name" textbox.
5. Click the "Create" button

### Download the source code
1. Either download or clone the git repository to the local machine.

### Additional files
1. You will need to create a file called "SecretConfig.cs" (case-sensitive) in the ShoelessJoeAPI.DataAccess root directory.
2. Copy the following code and place it in the newly created file.
#### SecretConfig.cs
```c#
namespace PizzaPlanet.App
{
    public class SecretConfig
    {
        public static string ConnectionString { get; } = "server={your server};user={your username};password={your password};database=PizzaPlanet";
        public static Version Version { get; } = new Version(8, 0, 31);
    }
}


```
### Updating the database
1. Inside Visual Studio, in the "Package Manager Console"
2. Run the following command
```bash
Update-Database
```

## Usage
1. Press ctrl + F5
