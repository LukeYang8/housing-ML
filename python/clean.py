import pandas as pd
import numpy as np

df = pd.read_parquet("../data/sales.parquet")
pd.set_option("display.max_columns", None)

# drop rows where purchase_price is missing
df.dropna(subset=["purchase_price"], inplace=True)  

# remove outliers (housing prices can be very skewed, so we will remove the top and bottom 5% of prices)
low = df["purchase_price"].quantile(0.05)
high = df["purchase_price"].quantile(0.95)
df = df[(df["purchase_price"] >= low) & (df["purchase_price"] <= high)]

# clean locality column
df["locality"] = df["locality"].str.strip().str.replace("\"", "").str.replace("'", "").replace(r"[A-Z]:", "", regex=True).str.upper()

# only want these columns for calculating median price by suburb and visualising trends over time
average_price_by_suburb = df[["street_name", "locality", "purchase_price", "sale_year", "property_type_clean"]].copy()
average_price_by_suburb['locality'].replace('', np.nan, inplace=True)
average_price_by_suburb.dropna(subset=['locality'], inplace=True)

# calculate average price by suburb
suburb_stats = average_price_by_suburb.groupby("locality").agg(
    avg_price=("purchase_price", "mean"),
    median_price=("purchase_price", "median"),
    num_sales=("purchase_price", "count")
).reset_index()
suburb_stats.to_parquet("../data/suburb_stats.parquet", index=False)

# calculate yearly trends by suburb
yearly_trends = average_price_by_suburb.groupby(["locality", "sale_year"]).agg(
    average_price=("purchase_price", "mean"),
    median_price=("purchase_price", "median"),
    num_sales=("purchase_price", "count")
).reset_index()
yearly_trends.to_parquet("../data/suburb_trends.parquet", index=False)


# for the model, we will only use the following features:
ml_features = ["land_area",
    "sale_year",
    "num_bath",
    "num_bed",
    "num_parking",
    "km_from_cbd",
    "suburb_median_income",
    "cash_rate",]

ml_df = df[ml_features + ["purchase_price"]].copy()
ml_df.dropna(inplace=True)  

ml_df.to_parquet("../data/ml_data.parquet", index=False)