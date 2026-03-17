import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_absolute_error, mean_squared_error, r2_score
import numpy as np
import matplotlib.pyplot as plt

df = pd.read_parquet("./data/ml_data.parquet")


# For this model, we will only use the following features:
numeric_cols = [
    "land_area",
    "sale_year",
    "num_bath",
    "num_bed",
    "num_parking",
    "km_from_cbd",
    "suburb_median_income",
    "cash_rate",
]

target = "purchase_price"

X_numerical = df[numeric_cols]
y = df[target]

# split into train and test sets
X_train, X_test, y_train, y_test = train_test_split(X_numerical, y, test_size=0.2, random_state=42)

# random forest regressor
model = RandomForestRegressor(n_estimators=100, random_state=42)
model.fit(X_train, y_train)
y_pred = model.predict(X_test)

# evaluate model
rf_mae = mean_absolute_error(y_test, y_pred)
rf_r2 = r2_score(y_test, y_pred)
print(f"Random Forest MAE: {rf_mae}")
print(f"Random Forest R^2: {rf_r2}")
