using RecipeBook.Repository;
using RecipeBook.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IDifficultyService, DifficultyService>();
builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();

builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();

builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

builder.Services.AddScoped<IIngredientLineService, IngredientLineService>();
builder.Services.AddScoped<IIngredientLineRepository, IngredientLineRepository>();

builder.Services.AddScoped<IMeasureService, MeasureService>();
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();

builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ILogInRepository, LogInRepository>();
builder.Services.AddScoped<ILogInService, LogInService>();

builder.Services.AddScoped<ISearchRepository, SearchRespository>();
builder.Services.AddScoped<ISearchService, SearchService>();


builder.Services.AddSession(options =>
{
    options.Cookie.Name = "LOGIN";
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
