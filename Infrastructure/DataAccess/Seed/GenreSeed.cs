using Domain.Entities;

namespace Infrastructure.DataAccess.Seed
{
    public static class GenreSeed
    {
        public static async Task SeedAsync(BookContext context)
        {
            if (context.Genres.Any())
                return;
            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Trinh thám",
                    Description = "Thể loại trinh thám"
                },
                new Genre
                {
                    Name = "Cổ tích",
                    Description = "Thể loại cổ tích"
                },
                new Genre
                {
                    Name = "Hài hước",
                    Description = "Thể loại hài hước"
                }
            };
            context.Genres.AddRange(genres);
            await context.SaveChangesAsync();
        }
    }
}
