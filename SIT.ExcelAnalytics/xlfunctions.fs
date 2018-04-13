﻿namespace SIT.Analytics
open System
open ExcelDna.Integration
open System.ComponentModel
    
type xlStatisticFunctions =   

    [<ExcelFunction(Name="GeoMeanReturn", Description="Geometric average of a return series", Category="Analytics", IsThreadSafe=true, IsVolatile=true)>]
    static member GeoMeanReturn([<ExcelArgument(Name="ReturnSeries", Description="Return series")>] retData) =      
       let retStats = ReturnStatistics(retData)
       retStats.GeoMeanReturn

    [<ExcelFunction(Name="AnnualReturn", Description="Annualized return based on input return series", Category="Analytics", IsThreadSafe=true, IsVolatile=true)>]
    static member AnnualReturn([<ExcelArgument(Name="ReturnSeries", Description="Return series")>] retData,
                                [<ExcelArgument(Name="[PeriodsPerYear]", Description="Number of periods per year. Optional - Default value is 12 ")>] ?nPerYear) =
        let n = defaultArg nPerYear 12.                           
        let retStats = ReturnStatistics(retData)
        retStats.AnnualReturn n
