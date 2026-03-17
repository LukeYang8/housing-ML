from datasets import load_dataset

sales = load_dataset("thehooklab/nsw-property")

df = sales["train"].to_pandas()

df.to_parquet("./data/sales.parquet", index=False)

print("Data saved to ./data/sales.parquet")