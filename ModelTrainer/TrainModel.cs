using Microsoft.ML;
using HousingAPI.Models;

var mlContext = new MLContext();

// load data as csv
var data = mlContext.Data.LoadFromTextFile<ModelInput>(
    path: "../data/ml_data.csv",
    hasHeader: true,
    separatorChar: ',');

// split data
var split = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

// build pipeline
var pipeline = mlContext.Transforms.Concatenate(
        "Features",
        nameof(ModelInput.land_area),
        nameof(ModelInput.sale_year),
        nameof(ModelInput.num_bath),
        nameof(ModelInput.num_bed),
        nameof(ModelInput.num_parking),
        nameof(ModelInput.km_from_cbd),
        nameof(ModelInput.suburb_median_income),
        nameof(ModelInput.cash_rate))
    .Append(mlContext.Regression.Trainers.FastTree());

// train
var model = pipeline.Fit(split.TrainSet);

// evaluate
var predictions = model.Transform(split.TestSet);
var metrics = mlContext.Regression.Evaluate(predictions);

Console.WriteLine($"R^2: {metrics.RSquared}");
Console.WriteLine($"MAE: {metrics.MeanAbsoluteError}");

// save model
mlContext.Model.Save(model, data.Schema, "../data/house_price_model.zip");

Console.WriteLine("Model saved!");