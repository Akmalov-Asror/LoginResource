namespace Login.Extensions;

public static class BuilderServices
{
    public static void AddCorsPolicy(this IServiceCollection collection)
    {
        collection.AddCors(c =>
        {
            c.AddDefaultPolicy(cors =>
            {
                cors.WithOrigins("https://localhost:1005", "https://localhost:2005")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

        });
    }
}