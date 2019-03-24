## 1.Architecture
Opret f�lgende projekter
* WebApp (Razor Pages Web App)
* ServiceLayer (.NET Standard class library)
* DataLayer (.NET Standard class library)

Opret projekt referencerne:
* WebApp -> DataLayer og ServiceLayer
* ServiceLayer -> DataLayer


Install�r f�lgende NuGet-pakker vha. PMC:
```powershell
Install-Package Microsoft.VisualStudio.Web.BrowserLink -ProjectName WebApp
Install-Package Microsoft.EntityFrameworkCore.SqlServer -ProjectName DataLayer
Install-Package Microsoft.EntityFrameworkCore.Tools -ProjectName DataLayer
```

## 2. WebApp
Tilf�j til StartUp.cs:
```c#
app.UseBrowserLink();
```

For InMemory database tilf�jes til service:
```c#
services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
```

## 3. DataLayer
Opret AppDbContext.cs med f�lgende indhold:

```C#
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
```

Opret folder kaldet *Entities*.

### 4. ServiceLayer
Tomt
