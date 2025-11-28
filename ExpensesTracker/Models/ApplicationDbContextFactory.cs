using ExpensesTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // 1. Define the project directory name
        const string projectDirName = "ExpensesTracker";

        // 2. Start from the current directory
        string basePath = Directory.GetCurrentDirectory();

        // 3. Search up the directory tree until we find the folder matching the project name
        // This handles cases where the command is run from the solution root or the bin/Debug folder.
        while (!basePath.EndsWith(projectDirName) && Directory.GetParent(basePath) != null)
        {
            basePath = Directory.GetParent(basePath).FullName;
        }

        // 4. Fallback in case the search failed or was unnecessary
        if (basePath.EndsWith("bin\\Debug\\net7.0") || basePath.EndsWith("bin\\Debug\\net6.0"))
        {
            basePath = Path.Combine(basePath, "..", "..", "..", "..");
        }

        Console.WriteLine($"Factory Base Path: {basePath}");

        // 5. Build the Configuration using the found path
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // 6. Get the Connection String (using the corrected name "DefaultConnection")
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Please check appsettings.json and the path log above.");
        }

        // 7. Build and return the DbContext
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseSqlServer(connectionString);

        return new ApplicationDbContext(builder.Options);
    }
}