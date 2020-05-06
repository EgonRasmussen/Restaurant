# 4.EditingData
Der oprettes en mulighed for at redigere data for restauranterne:

-- Her inds�ttes billede af Edit-viewet

## ServiceLayer
RestaurantService udvides med en Edit metode:


## WebApp
Her tilf�jes...

#### SELECT
Her er benyttet den simple m�de at binde en enum til en Select, hvor det alene foreg�r i View'et. Her benyttes metoden: ```Html.GetEnumSelectList<T>()```:
```xml
<div class="form-group">
    <label asp-for="Restaurant.Cuisine" />
    <select asp-for="Restaurant.Cuisine"
            asp-items="Html.GetEnumSelectList<DataLayer.Entities.CuisineType>()"
            class="form-control"></select>
    <span class="text-danger" asp-validation-for="Restaurant.Cuisine"></span>
</div>
```
#### Alternativ binding til SELECT
En anden m�de er at injecte `IHtmlHelper` servicen ind i ViewModel-klassens constructor (kr�ver import af namespacet: `Microsoft.AspNetCore.Mvc.Rendering`):
```csharp
public IEnumerable<SelectListItem> Cuisines { get; set; }

private IHtmlHelper _htmlHelper;

public EditModel(IRestaurantService restaurantService, IHtmlHelper htmlHelper)
{
    _restaurantService = restaurantService;
    _htmlHelper = htmlHelper;
}
```
I OnGet hentes data ind p� f�lgende m�de:
```csharp
Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
```

Og i View'et bindes SELECT kontrollen til Cuisines property:
```xml
asp-items="Model.Cuisines"
```


---
## Post-Redirect-Get Pattern
Beskrivelse