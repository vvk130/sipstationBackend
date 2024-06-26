            // var data = await _context.Drinks
            // .Select(r => new
            // {
            //     Max = EF.Functions.Max(
            //         r.Price,
            //         EF.Functions.Over()
            //             .OrderBy(r.Id)),
            // }).ToListAsync(cancellationToken);

                        //                     // restaurantSum = EF.Functions.Sum(d.Price, EF.Functions.Over().PartitionBy().OrderBy(d.Price))),
            //                     // sum = EF.Functions.Sum(
            //                     //             d.Price,
            //                     //             EF.Functions.Over()
            //                     //                 .OrderBy(d.Price)),

                        // var drink = await _context.Drinks.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
            // Guard.Against.Null(drink, nameof(drink), "Drink not found");
            // return Ok(drink);
            // var count = _context.Drinks.Count();
            // Console.WriteLine(count);
            // var data = _context.Drinks.Where(x => x.Price > 5).Count();
        //     var number1 = 5;
        //     var number2 = 5;
        //     var number3 = 9;



        // var data = await (from d in _context.Drinks.AsNoTracking()
        //                   where d.Id == id // stationId comes from the incoming request
        //                   join allDrinks in _context.Drinks on 1 equals 1 into allDrinksGroup // Left join with all drinks
        //                   from allDrink in allDrinksGroup.DefaultIfEmpty()
        //                   group allDrink by new { d.Id, d.Name } into g
        //                   select new
        //                   {
        //                       drinkId = g.Key.Id,
        //                       name = g.Key.Name,
        //                       totalNumberOfDrinksPriceOver5 = g.Count(x => x != null && x.Price > number1),
        //                       totalNumberOfDrinksPriceUnder5 = g.Count(x => x != null && x.Price < number2),
        //                       totalNumberOfDrinksPriceOver9 = g.Count(x => x != null && x.Price > number3),
        //                       // Add other calculations if needed
        //                   }).FirstOrDefaultAsync(cancellationToken);

        // return Ok(data);
