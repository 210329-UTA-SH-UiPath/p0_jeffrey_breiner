﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PizzaBox.Storing.Entities.EntityModels
{
  /// <summary>
  /// Enum containing all possible premade pizzas. Also contains custom pizza.
  /// </summary>
  public enum PIZZAS
  {
    CUSTOM,
    HAWAIIAN,
    MEAT,
    VEGAN
  }

  /// <summary>
  /// Pizza entity model. Contains:
  /// ID
  /// PIZZA (Enum instance)
  /// DBCrust
  /// DBSize
  /// DBToppings (list)
  /// Price
  /// </summary>
  public class DBPizza
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public PIZZAS PIZZA { get; set; }
    [Required]
    public DBCrust DBCrust { get; set; }
    [Required]
    public DBSize DBSize { get; set; }
    [Required]
    public List<DBTopping> DBToppings { get; set; }
    [Required]
    public decimal? Price { get; set; }
  }
}