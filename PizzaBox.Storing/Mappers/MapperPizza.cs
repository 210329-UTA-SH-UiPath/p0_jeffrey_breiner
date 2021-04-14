using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
  public class MapperPizza : IMapper<APizza, DBPizza>
  {
    private MapperCrust mapperCrust = new MapperCrust();
    private MapperSize mapperSize = new MapperSize();
    private MapperTopping mapperTopping = new MapperTopping();

    /// <summary>
    /// Map DBPizza => APizza
    /// Uses enum to determine which crust class to return.
    /// Note: premade pizza classes have constructors to set all variables properly.
    /// Therefore, they do not need any data tobe passed innto them.
    /// Custom pizza however only has 1 constructor that requires crust, size, and toppings 
    /// to be passed into them.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public APizza Map(DBPizza entity)
    {
      APizza pizza;

      switch (entity.PIZZA)
      {
        case Entities.EntityModels.PIZZAS.CUSTOM:
          Crust crust = mapperCrust.Map(entity.DBCrust);
          Size size = mapperSize.Map(entity.DBSize);
          List<Topping> toppings = new List<Topping>();
          entity.DBToppings.ForEach(Topping => toppings.Add(mapperTopping.Map(Topping)));

          pizza = new CustomPizza(crust, size, toppings);
          break;
        case Entities.EntityModels.PIZZAS.HAWAIIAN:
          pizza = new HawaiianPizza();
          break;
        case Entities.EntityModels.PIZZAS.MEAT:
          pizza = new MeatPizza();
          break;
        case Entities.EntityModels.PIZZAS.VEGAN:
          pizza = new VeganPizza();
          break;
        default:
          throw new ArgumentException("Size not recognized. Size could not be mapped properly");
      }

      return pizza;
    }

    /// <summary>
    /// Map DBPizza => DBPizza
    /// Sets enum bassed off what pizza class was passed into it.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public DBPizza Map(APizza model)
    {
      DBPizza dBPizza = new DBPizza();
      PIZZAS PIZZA;

      switch (model)
      {
        case CustomPizza:
          PIZZA = PIZZAS.CUSTOM;
          break;
        case HawaiianPizza:
          PIZZA = PIZZAS.HAWAIIAN;
          break;
        case MeatPizza:
          PIZZA = PIZZAS.MEAT;
          break;
        case VeganPizza:
          PIZZA = PIZZAS.VEGAN;
          break;
        default:
          throw new ArgumentException("Size not recognized. Size could not be mapped properly");
      }

      dBPizza.PIZZA = PIZZA;
      dBPizza.DBCrust = mapperCrust.Map(model.Crust);
      dBPizza.DBSize = mapperSize.Map(model.Size);
      List<DBTopping> toppings = new List<DBTopping>();
      model.Toppings.ForEach(Topping => toppings.Add(mapperTopping.Map(Topping)));
      dBPizza.DBToppings = toppings;
      dBPizza.Price = model.price;

      return dBPizza;
    }
  }
}