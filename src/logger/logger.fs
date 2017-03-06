module MyLogger

open Serilog

type Shape =
    | Circle of Radius : double
    | Rectangle of Width : double *  Height : double
    | Arc // ...
let shape = Circle 5.

[<EntryPointAttribute>]
let main argv = 

    Log.Logger <- LoggerConfiguration()
        .MinimumLevel.Debug()
        .Destructure.FSharpTypes()
        .WriteTo.ColoredConsole()
        .WriteTo.RollingFile("myapp.txt")
        .CreateLogger()

    Log.Information("------ Beginning Program Run ------")
    Log.Information("Logging the integer = {0}", 5)
    Log.Information("Drawing a {@Shape}", Circle 5.)
    let divide1 x y =
        Log.Debug("Dividing {0} by {1}", x, y)
        try
            Some (x / y)
        with
            | :? System.DivideByZeroException -> Log.Error("Division by zero!"); None

    let result1 = divide1 100 0
    0