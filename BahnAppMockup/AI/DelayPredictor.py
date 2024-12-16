from sklearn.ensemble import GradientBoostingRegressor
from sklearn.model_selection import train_test_split
import pandas as pd
import os

# Get the directory of the current Python file
script_dir = os.path.dirname(os.path.abspath(__file__))

# Load the dataset
data = pd.read_excel(os.path.join(script_dir, "Data_ai2 1.xlsx")).dropna()

# Pivot the data from long to wide format
data_wide = data.pivot(index='Fahrt', columns='Stations', values='Delay in min')
data_wide.columns = [f'Delay_Station_{int(col)}' for col in data_wide.columns]
data_wide = data_wide.reset_index()

# Rename columns for readability
column_mapping = {
    'Delay_Station_1': 'Verspätung Köln Hbf',
    'Delay_Station_2': 'Verspätung Köln Messe/ Deutz Bf',
    'Delay_Station_3': 'Verspätung Köln Buchforst',
    'Delay_Station_4': 'Verspätung Köln Mülheim',
    'Delay_Station_5': 'Verspätung Holweide',
    'Delay_Station_6': 'Verspätung Köln Dellbrück',
    'Delay_Station_7': 'Verspätung Duckterath'
}
data = data_wide.rename(columns=column_mapping)

# Define features and target columns
X = data[['Verspätung Köln Hbf', 'Verspätung Köln Messe/ Deutz Bf']]
y = data[['Verspätung Köln Buchforst', 'Verspätung Köln Mülheim', 'Verspätung Holweide',
          'Verspätung Köln Dellbrück', 'Verspätung Duckterath']]

# Split data into training and test sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Train a model for each target column
models = {}
for column in y.columns:
    model = GradientBoostingRegressor(random_state=42)
    model.fit(X_train, y_train[column])
    models[column] = model

print("Trained models:", models.keys())

# Define a function to make predictions
def predict_delays(delay_koeln_hbf, delay_koeln_messe_deutz):
    # Create a DataFrame for input data
    input_data = pd.DataFrame({
        'Verspätung Köln Hbf': [delay_koeln_hbf],
        'Verspätung Köln Messe/ Deutz Bf': [delay_koeln_messe_deutz]
    })

    # Use each trained model to make predictions
    predictions = {}
    for column, model in models.items():
        predictions[column] = model.predict(input_data)[0]

    return predictions
