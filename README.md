# 6. PartialPageUpdate
Dette er en branch-out fra 6.PartialView, som demonstrerer hvordan et Partial View kaldet *_Summary.cshtml* hentes vha. jQuery

Ref: [Partial Page Update with AJAX in Razor Pages](https://www.learnrazorpages.com/razor-pages/ajax/partial-update)


Eksemplet viser hvordan man kan vælge Detail for en bestemt restaurant, men Detail-pagen viser kun navnet. 
Vil man hente alle data om restauranten skal man trykke på *Hent Restaurant* knappen, som laver et AJAX kald til en Named Handler Metode i Detail PageModel.

Der benyttes det samme Partial View, *_Summary.cshtml*, som også benyttes i List-pagen.
I Detail PageModel er der lavet en Named Handler Metode, der returnerer et Partial View med den akuttel restaurant:

```c#
 public PartialViewResult OnGetRestaurantPartial(int restaurantId)
        {
            Restaurant = _restaurantService.GetRestaurantById(restaurantId);
            return Partial("_Summary", Restaurant);
        }
```


Denne handler bliver kaldt fra View'et, når der trykkes på knappen. Her ses koden med jQuery:

```js
<p><button class="btn btn-primary" id="load">Hent Restaurant</button></p>
<div id="grid"></div>
@section scripts{
    <script>
        $(function () {
            $('#load').on('click', function () {
                $('#grid').load(@Model.Restaurant.Id + '/restaurantpartial' );
            });
        });
    </script>
}
```

I Detail-View'et er der lavet Templated Routing for at undgå QueryStrings:

```c#
@page "{restaurantId:int}/{handler?}"
```