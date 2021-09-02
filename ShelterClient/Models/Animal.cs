using System;

namespace ShelterClient.Models
{
  public abstract class Animal
  {
    public string Name { get; set; }
    public double WeightKilo { get; set; }
    public bool IsFemale { get; set; }
    public DateTime Birthday { get; set; }
    public string Coloring { get; set; }
    public string Description { get; set; }
  }
}