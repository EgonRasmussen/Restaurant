## 4. AutoMapper

Install�r NuGet-pakken ```AutoMapper.Extensions.Microsoft.DependencyInjection``` i **ServiceLayer** projektet.

Tilf�j f�lgende linje til ```Configuration()``` i ```Startup.cs```:
```c#
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```
Denne linje betyder at AutoMapper scanner hele solution for at finde Profiles og at de derfor kan 
placeres i de Services, hvor de h�rer hjemme.

Opret en folder kaldet **Profiles** i BlogService folderen. Opret en klasse kaldet **BlogsProfile.cs** med f�lgende indhold:
```c#
public class BlogsProfile : Profile
{
    public BlogsProfile()
    {
        CreateMap<Blog, BlogListDto>()
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner.Name))
            .ForMember(dest => dest.NumberOfPosts, opt => opt.MapFrom(src => src.Posts.Count()));
        ;
    }
}
```
---
### G�r brug af AutoMapper servicen
AutoMapper injectes som enhver anden service i constructoren p� den klasse, den skal bruges i. Her ses eksemplet fra
```ListBlogService``` klassen. Bem�rk hvordan ```ProjectTo()``` metoden fra AutoMapper
benyttes som en Extension metode og erstatter ```MapBlogToDto()```:
```c#
public class ListBlogService : IListBlogService
{
    private readonly BloggingContext _context;
    private readonly IMapper _mapper;

    public ListBlogService(BloggingContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _context.Database.EnsureCreated();      // Triggers the seeding of the database
    }

    public IQueryable<BlogListDto> SortFilterPage(SortFilterPageOptions options)
    {
        var blogsQuery = _context.Blogs
            .AsNoTracking()
            //.MapBlogToDto()
            .ProjectTo<BlogListDto>(_mapper.ConfigurationProvider)
            .OrderBlogsBy(options.OrderByOptions)
            .FilterBlogsBy(options.FilterBy, options.FilterValue);
            
            options.SetupRestOfDto(blogsQuery);                            
            return blogsQuery.Page(options.PageNum - 1, options.PageSize); 
    }
}
```
