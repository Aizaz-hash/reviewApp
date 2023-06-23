using ReviewApp.Data;
using ReviewApp.Models;

namespace ReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.characterOwners.Any())
            {
                var pokemonOwners = new List<CharacterOwner>()
                {
                    new CharacterOwner()
                    {
                        character = new Character()
                        {
                            Name = "Pikachu",
                            DOB = new DateTime(1903,1,1),
                            characterCategories = new List<CharacterCategory>()
                            {
                                new CharacterCategory { Category = new Category() { Name = "Electric"}}
                            },
                            reviews = new List<Reviews>()
                            {
                                new Reviews { Title="Pikachu",text = "Pickahu is the best pokemon, because it is electric", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Teddy", lastName = "Smith" } },
                                new Reviews { Title="Pikachu", text = "Pickachu is the best a killing rocks", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Taylor", lastName = "Jones" } },
                                new Reviews { Title="Pikachu",text = "Pickchu, pickachu, pikachu", rating = 1,
                                reviewer = new Reviewers(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            firstName = "Jack",
                            lastName = "London",
                            Gym = "Brocks Gym",
                            country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new CharacterOwner()
                    {
                        character    = new Character()
                        {
                            Name = "Squirtle",
                            DOB = new DateTime(1903,1,1),
                            characterCategories = new List<CharacterCategory>()
                            {
                                new CharacterCategory { Category = new Category() { Name = "Water"}}
                            },
                            reviews = new List<Reviews>()
                            {
                                new Reviews { Title= "Squirtle", text = "squirtle is the best pokemon, because it is electric", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Teddy", lastName = "Smith" } },
                                new Reviews { Title= "Squirtle",text = "Squirtle is the best a killing rocks", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Taylor", lastName = "Jones" } },
                                new Reviews { Title= "Squirtle", text = "squirtle, squirtle, squirtle", rating = 1,
                                reviewer = new Reviewers(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            firstName = "Harry",
                            lastName = "Potter",
                            Gym = "Mistys Gym",
                            country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new CharacterOwner()
                    {
                        character = new Character()
                        {
                            Name = "Venasuar",
                            DOB = new DateTime(1903,1,1),
                            characterCategories = new List<CharacterCategory>()
                            {
                                new CharacterCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            reviews = new List<Reviews>()
                            {
                                new Reviews { Title="Veasaur",text = "Venasuar is the best pokemon, because it is electric", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Teddy", lastName = "Smith" } },
                                new Reviews { Title="Veasaur",text = "Venasuar is the best a killing rocks", rating = 5,
                                reviewer = new Reviewers(){ firstName = "Taylor", lastName = "Jones" } },
                                new Reviews { Title="Veasaur",text = "Venasuar, Venasuar, Venasuar", rating = 1,
                                reviewer = new Reviewers(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            firstName = "Ash",
                            lastName = "Ketchum",
                            Gym = "Ashs Gym",
                            country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.characterOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
